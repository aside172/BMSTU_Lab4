using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;

namespace IrisOpener
{
    /// <summary>
    /// Класс обработчика ирисов
    /// </summary>
    public class IrisModel : IIrisHandler
    {
        private List<List<MathVector>> irisvectors;
        private List<MathVector> results;
        private const int number_irises = 3;
        private const int number_charts = 4;

        /// <summary>
        /// создание объекта ирис-обработчик, запись в него матрицы векторов
        /// </summary>
        /// <param name="vectorslist">Матрица векторов для записи</param>
        public IrisModel(List<List<MathVector>> vectorslist)
        {
            irisvectors = new List<List<MathVector>>();
            int q = 0;
            foreach (List<MathVector> i in vectorslist)
            {
                irisvectors.Add(new List<MathVector>());
                foreach (MathVector j in i)
                {
                    irisvectors[q].Add(new MathVector(j));
                }
                q++;
            }
        }

        /// <summary>
        /// Создание 3 усредненных векторов
        /// </summary>
        /// <returns>Массив усредненных векторов</returns>
        public List<MathVector> AverageForAllCount()
        {
            results = new List<MathVector>();
            for (int i = 0; i < number_irises; i++)
            {
                MathVector tmp = new MathVector(number_charts);
                for (int j = 0; j < number_charts; j++)
                {
                    tmp[j] = OneAverageCount(j, i);
                }
                results.Add(tmp);
            }
            return results;
        }

        /// <summary>
        /// Подсчет одного среднего значения
        /// </summary>
        /// <param name="parametr">Параметр, который необходимо считать</param>
        /// <param name="vector">Тип ирис-вектора, для которых среднее подсчитывается</param>
        /// <returns></returns>
        public double OneAverageCount(int parametr, int vector)
        {
            double sum = 0;
            for (int i = 0; i < irisvectors[vector].Count; i++)
            {
                sum += irisvectors[vector][i][parametr];
            }
            double result;
            if (irisvectors[vector].Count == 0) //проверка на наличие векторов нужного типа
                result = 0;
            else
                result = sum / irisvectors[vector].Count;
            return result;
        }

        /// <summary>
        /// Подсчет евклидовых расстояний для 3 усредненных векторов
        /// </summary>
        /// <returns>Массив из 3 чисел - евклидовых расстояний</returns>
        public MathVector EvcledeanCount ()
        {
            MathVector res = new MathVector(results.Count);
            for (int i = 0; i < results.Count; i++)
            {
                int tmp_counter = i+1;
                if (i == results.Count - 1)
                    tmp_counter = 0;
                res[i] = results[i].CalcDistance(results[tmp_counter]);
            }
            return res;
        }

        public List<MathVector> DispSqrtFind()
        {
            List<MathVector> DispRes = new List<MathVector>();
            MathVector tmp = FindFullDisp();
            DispRes.Add(new MathVector(tmp));
            tmp = FindFinalDeviation(tmp);
            DispRes.Add(new MathVector(tmp));
            return DispRes;
        }

        private MathVector FindFinalDeviation(MathVector mathVector)
        {
            MathVector res = new MathVector(number_irises);
            for(int i = 0; i < number_irises; i++)
            {
                res[i] = Math.Sqrt(mathVector[i] / 4);
            }
            return res;
        }

        private MathVector FindFullDisp()
        {
            MathVector sqrtRes = new MathVector(number_irises);
            for (int i = 0; i < number_irises; i++)
            {
                double sumIris = 0;
                for (int j = 0; j < number_charts; j++)
                {
                    double sumIrisOnePar = 0;
                    for (int q = 0; q < irisvectors[i].Count; q++)
                    {
                        sumIrisOnePar += FindOneDisp(i, q, j);
                    }
                    sumIris += sumIrisOnePar / irisvectors[i].Count;
                }
                //sqrtRes[i] = Math.Sqrt(sumIris / 4);
                sqrtRes[i] = sumIris;
            }
            return sqrtRes;
        }


        private double FindOneDisp(int iristype, int chartindex, int vectorindex)
        {
            return Math.Abs(results[iristype][vectorindex] - irisvectors[iristype][chartindex][vectorindex]);
        }
    }
}