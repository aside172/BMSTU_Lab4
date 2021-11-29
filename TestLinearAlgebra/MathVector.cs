using System;
using System.Collections;


namespace LinearAlgebra
{
    public class MathVector : IMathVector
    {
        private double[] elements;
        public enum Operations
        {
            plus,
            multiply,
            divide,
            distance
        }

        /// <summary>
        /// Creates the object of class MathVector with length 0
        /// </summary>
        public MathVector()
        {
            elements = new double[0];
        }

        /// <summary>
        /// Creates the object of class MathVector fulled with 0.
        /// </summary>
        /// <param name="length">Amount of elements in the vector.</param>
        public MathVector(int length)
        {
            elements = new double[length];
            for (int i = 0; i < length; i++)
            {
                elements[i] = 0;
            }
        }

        /// <summary>
        /// Creates the object of class MathVector as a copy of another MathVector
        /// </summary>
        /// <param name="A">Original MathVector.</param>
        public MathVector(MathVector A)
        {
            elements = new double[A.Dimensions];
            for (int i = 0; i < A.Dimensions; i++)
            {
                elements[i] = A.elements[i];
            }
        }

        /// <summary>
        /// Creates the object of class MathVector and fills it in with array.
        /// </summary>
        /// <param name="A">Array with values.</param>
        public MathVector(double[] NewElements)
        {
            for (int i = 0; i < NewElements.Length; i++)
            {
                elements[i] = NewElements[i];
            }
        }

        /// <summary>
        /// Gets number of elements in vector.
        /// </summary>
        /// <returns>
        /// Number of elements in vector.
        /// </returns>
        public int Dimensions
        {
            get
            {
                return elements.Length;
            }
        }

        /// <summary> 
        /// Gets element by its number or sets element with that number with a new value.
        /// </summary> 
        /// <param name="i">Element number</param> 
        /// <returns> 
        /// Value of element with the transmitted number. 
        /// </returns> 
        /// <exception cref="IndexOutOfRangeException">
        /// Unequivalent legth of the vector
        /// </exception>
        public double this[int i]
        {
            get
            {
                ThrowingLenghtException(i);
                return elements[i];
            }
            set
            {
                ThrowingLenghtException(i);
                elements[i] = value;
            }
        }

        /// <summary>
        /// Throws IndexOutOfRangeException
        /// </summary>
        /// <param name="elemnum"></param>
        private void ThrowingLenghtException(int elemnum)
        {
            if (elemnum < 0 || elemnum >= Dimensions)
                throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Puts new element to the end of the vector.
        /// </summary>
        /// <param name="num">New value.</param> 
        public void PutBack(double num)
        {
            Array.Resize<double>(ref elements, Dimensions + 1);
            elements[Dimensions - 1] = num;
        }

        /// <summary> 
        /// Gets vector legth.
        /// </summary> 
        /// <returns>Vector legth. </returns> 
        public double Length
        {
            get
            {
                double result_lenght = 0;
                for (int i = 0; i < Dimensions; i++)
                {
                    result_lenght += this[i] * this[i];
                }
                return Math.Sqrt(result_lenght);
            }
        }

        /// <summary> 
        /// Summerizes each vector elemnet with the transmitted value.
        /// </summary> 
        /// <param name="number">Value to summarize with.</param> 
        /// <returns> 
        /// New vector with summarized values. 
        /// </returns> 
        public IMathVector SumNumber(double number)
        {
            MathVector NewVector = new MathVector(this);
            for (int i = 0; i < Dimensions; i++)
            {
                NewVector[i] += number;
            }
            return NewVector;
        }

        /// <summary> 
        /// Multiplies each vector elemnet with the transmitted value.
        /// </summary> 
        /// <param name="number">Multiplier</param> 
        /// <returns> 
        /// New vector with multiplied values. 
        /// </returns> 
        public IMathVector MultiplyNumber(double number)
        {
            MathVector NewVector = new MathVector(this);
            for (int i = 0; i < Dimensions; i++)
            {
                NewVector[i] *= number;
            }
            return NewVector;
        }

        /// <summary> 
        /// Divides each vector element by the transmitted value.
        /// </summary> 
        /// <param name="number">Divider</param> 
        /// <returns> 
        /// New vector with divided values. 
        /// </returns> 
        /// <exception cref="DivideByZeroException">
        /// Transmitted number is 0.
        /// </exception>
        public IMathVector DivideNumber (double number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException();
            }
            else return MultiplyNumber(1 / number);
        }

        /// <summary> 
        /// Summerizes two vectors with the same length element by element.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to summarize with.</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new summurazed values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public IMathVector Sum(IMathVector vector)
        {
            MathVector newvector = DoVectorOperations(vector, Operations.plus);
            return newvector;
        }

        /// <summary> 
        /// Multiplies two vectors element by element.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to multiply with.</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new multiplied values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public IMathVector Multiply(IMathVector vector)
        {
            MathVector newvector = DoVectorOperations(vector, Operations.multiply);
            return newvector;
        }

        /// <summary> 
        /// Divides elements of main vector by elements (element by element) of transmitted vector (mustn't contain 0). 
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector-divider</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new divided values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        /// <exception cref="DivideByZeroException">
        /// One of the element of vector-divider is 0.
        /// </exception>
        public IMathVector Divide(IMathVector vector)
        {
            MathVector newvector = DoVectorOperations(vector, Operations.divide);
            return newvector;
        }

        /// <summary> 
        /// Finds scalar multiplication with the values of two vectors.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to find scalar multiplication with.</param> 
        /// <returns> 
        /// Scalar multiplication.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public double ScalarMultiply(IMathVector vector)
        {
            double result = 0;
            result = DoNumberOperations(vector, Operations.multiply);
            return result;
        }

        /// <summary> 
        /// Finds Evclidean distance with the values of two vectors.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to find Evclidean distance with.</param> 
        /// <returns> 
        /// Evclidean distance between two vectors.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public double CalcDistance(IMathVector vector)
        {
            double result = 0;
            result = DoNumberOperations(vector, Operations.distance);
            result = Math.Sqrt(result);
            return result;
        }

        /// <summary>
        /// Processes operations between two vectors.
        /// </summary>
        /// <param name="vector">Vector to carry out the operation with</param>
        /// <param name="operation">Operation to carry with</param>
        /// <returns>New vector with the applied operation.</returns>
        private MathVector DoVectorOperations(IMathVector vector, Operations operation)
        {
            MathVector newvector = null;
            if (AreEqvivalent(vector))
            {
                newvector = new MathVector(this);
                for (int i = 0; i < Dimensions; i++)
                {
                    newvector[i] = DoOperation(this[i], vector[i], operation);
                }
            }
            else
                this.UnequivalentExeptionThrow();
            return newvector;
        }

        /// <summary>
        /// Processes operations between two vectors which returns number.
        /// </summary>
        /// <param name="vector">Vector to carry out the operation with</param>
        /// <param name="operation">Operation to carry out</param>
        /// <returns>Result of the operation.</returns>
        private double DoNumberOperations(IMathVector vector, Operations operation)
        {
            double result = 0;
            if (AreEqvivalent(vector))
            {
                for (int i = 0; i < Dimensions; i++)
                {
                    result += DoOperation(vector[i], this[i], operation);
                }
            }
            else
                this.UnequivalentExeptionThrow();
            return result;
        }

        /// <summary>
        /// Does transmitted operation between two transmitted numbers
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="operation">Operation to carry out</param>
        /// <returns>Result of the operation</returns>
        private double DoOperation(double num1, double num2, Operations operation)
        {
            double result = 0;
            switch (operation)
            {
                case Operations.plus:
                    result = num1 + num2;
                    break;
                case Operations.multiply:
                    result = num1 * num2;
                    break;
                case Operations.divide:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        throw new DivideByZeroException();
                    }
                    break;
                case Operations.distance:
                    result = Math.Pow((num1 - num2), 2);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Checks if two vectors have the same number of elements.
        /// </summary>
        private bool AreEqvivalent(IMathVector vector)
        {
            return Dimensions == vector.Dimensions;
        }
        
        /// <summary>
        /// Writes vector values on Console.
        /// </summary>
        public void ConsoleWrite()
        {
            for (int i = 0; i < Dimensions; i++)
                Console.WriteLine(this[i]);
        }

        /// <summary>
        /// Throws exception when vector number of elements are not the same.
        /// </summary>
        private void UnequivalentExeptionThrow()
        {
            throw new Exception("Unequivalent length of the vectors");
            //throw new InvalidOperationException("Unequivalent length of the vectors");
        }

        /*
        + - покомпонентное сложение с числом или другим вектором
        - - покомпонентное вычитание с числом или другим вектором
        * - покомпонентное умножение с числом или другим вектором
        / - покомпонентное деление с числом или другим вектором
        % - скалярное умножение двух векторов*/

        /// <summary> 
        /// Overloaded plus: summerizes each vector elemnet with the transmitted value.
        /// </summary> 
        /// <param name="number">Value to summarize with.</param> 
        /// <returns> 
        /// New vector with summarized values. 
        /// </returns> 
        public static IMathVector operator +(MathVector vector1, MathVector vector2)
        {
            return vector1.Sum(vector2);
        }

        /// <summary> 
        /// Overloaded plus: Summerizes two vectors with the same length element by element.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to summarize with.</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new summurazed values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public static IMathVector operator +(MathVector vector, double number)
        {
            return vector.SumNumber(number);
        }

        /// <summary> 
        /// Overloaded minus: substarcts transmitted value from each vector element value.
        /// </summary> 
        /// <param name="number">Value to summarize with.</param> 
        /// <returns> 
        /// New vector with summarized values. 
        /// </returns> 
        public static IMathVector operator -(MathVector vector1, MathVector vector2)
        {
            return vector1.Sum(vector2.MultiplyNumber(-1));
        }

        /// <summary> 
        /// Overloaded minus: substracts each element value of transmitted vector from the element values of the main vector.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to summarize with.</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new summurazed values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public static IMathVector operator -(MathVector vector, double number)
        {
            return vector.SumNumber((-1) * number);
        }

        /// <summary> 
        /// Overloaded multiplication: Multiplies each vector elemnet with the transmitted value.
        /// </summary> 
        /// <param name="number">Multiplier</param> 
        /// <returns> 
        /// New vector with multiplied values. 
        /// </returns> 
        public static IMathVector operator *(MathVector vector1, MathVector vector2)
        {
            return vector1.Multiply(vector2);
        }

        /// <summary> 
        /// Overloaded multiplication: multiplies two vectors element by element.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to multiply with.</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new multiplied values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public static IMathVector operator *(MathVector vector, double number)
        {
            return vector.MultiplyNumber(number);
        }

        /// <summary> 
        /// Overloaded division: Divides each vector elemnet by the transmitted value.
        /// Value mustn't be 0.
        /// </summary> 
        /// <param name="number">Divider</param> 
        /// <returns> 
        /// New vector with divided values values. 
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// Transmitted number is 0.
        /// </exception>
        public static IMathVector operator /(MathVector vector1, MathVector vector2)
        {
            return vector1.Divide(vector2);
        }

        /// <summary> 
        /// Overloaded division: divides elements of main vector by elements (element by element) of transmitted vector (mustn't contain 0). 
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector-divider</param> 
        /// <returns> 
        /// New vector with the same number of elements as transmitted vectors and new divided values.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        /// <exception cref="DivideByZeroException">
        /// One of the element of vector-divider is 0.
        /// </exception>
        public static IMathVector operator /(MathVector vector, double number)
        {
            return vector.DivideNumber(number);
        }

        /// <summary> 
        /// Overloaded %: finds scalar multiplication with the values of two vectors.
        /// Vector must have the same number of elements.
        /// </summary> 
        /// <param name="vector">Vector to find scalar multiplication with.</param> 
        /// <returns> 
        /// Scalar multiplication.
        /// </returns> 
        /// <exception cref=Exception("Unequivalent length of the vectors")">
        /// Vector's number of elements are not the same.
        /// </exception>
        public static double operator %(MathVector vector1, MathVector vector2)
        {
            return vector1.ScalarMultiply(vector2);
        }

        /// <summary>
        /// Returns enumerator for the vector.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}