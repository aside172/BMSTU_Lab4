using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LinearAlgebra
{
    public interface IMathVector : IEnumerable
    {
        /// <summary>
        /// Gets number of elements in vector.
        /// </summary>
        /// <returns>
        /// Number of elements in vector.
        /// </returns>
        int Dimensions { get; }

        /// <summary> 
        /// Gets element by its number or sets element with that number with a new value.
        /// Index mustn't be negative and mustn't be more than number of vector elements.
        /// </summary> 
        /// <param name="i">Element number</param> 
        /// <returns> 
        /// Value of element with the transmitted number. 
        /// </returns> 
        /// <exception cref="IndexOutOfRangeException">
        /// Unequivalent legth of the vector
        /// </exception>
        double this[int i] { get; set; }

        /// <summary> 
        /// Gets vector legth.
        /// </summary> 
        /// <returns>Vector legth. </returns> 
        double Length { get; }

        /// <summary> 
        /// Summerizes each vector elemnet with the transmitted value.
        /// </summary> 
        /// <param name="number">Value to summarize with.</param> 
        /// <returns> 
        /// New vector with summarized values. 
        /// </returns> 
        IMathVector SumNumber(double number);

        /// <summary> 
        /// Multiplies each vector elemnet with the transmitted value.
        /// </summary> 
        /// <param name="number">Multiplier</param> 
        /// <returns> 
        /// New vector with multiplied values. 
        /// </returns> 
        IMathVector MultiplyNumber(double number);

        /// <summary> 
        /// Divides each vector element by the transmitted value.
        /// Number mustn't be 0.
        /// </summary> 
        /// <param name="number">Divider</param> 
        /// <returns> 
        /// New vector with divided values. 
        /// </returns> 
        /// <exception cref="DivideByZeroException">
        /// Transmitted number is 0.
        /// </exception>
        IMathVector DivideNumber(double number);

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
        IMathVector Sum(IMathVector vector);

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
        IMathVector Multiply(IMathVector vector);

        /// <summary> 
        /// Divides elements of main vector by elements (element by element) of transmitted vector.
        /// Vector must have the same number of elements.
        /// Transmitted vector mustn't contain 0.
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
        IMathVector Divide(IMathVector vector);

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
        double ScalarMultiply(IMathVector vector);

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
        double CalcDistance(IMathVector vector);
    }
}
