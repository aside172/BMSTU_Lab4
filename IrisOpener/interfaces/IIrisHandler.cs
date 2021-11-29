using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;


namespace IrisOpener
{
    interface IIrisHandler
    {
        /// <summary>
        /// Создание 3 усредненных векторов
        /// </summary>
        /// <returns>Массив усредненных векторов</returns>
        List<MathVector> AverageForAllCount();

        /// <summary>
        /// Подсчет одного среднего значения
        /// </summary>
        /// <param name="parametr">Параметр, который необходимо считать</param>
        /// <param name="vector">Тип ирис-вектора, для которых среднее подсчитывается</param>
        /// <returns></returns>
        double OneAverageCount(int parametr, int vector);

        /// <summary>
        /// Подсчет евклидовых расстояний для 3 усредненных векторов
        /// </summary>
        /// <returns>Массив из 3 чисел - евклидовых расстояний</returns>
        MathVector EvcledeanCount();

    }
}
