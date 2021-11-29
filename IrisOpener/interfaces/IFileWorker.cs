using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;
using System.IO;

namespace IrisOpener
{
    interface IFileWorker
    {
        /// <summary>
        /// Считывает матрицу векторов
        /// Одна строка матрицы - один тип векторов (iris species)
        /// Изначально создает массив строк, который потом передает в другую функцию
        /// </summary>
        /// <returns>Возвращает матрицу векторов-ирис</returns>
        /// <exception cref="FileNotFoundException">
        /// Исключение для случая, когда файл не найден
        /// </exception>"
        List<List<MathVector>> ReadFullFile();

        /// <summary>
        /// Проверка на существование файла
        /// </summary>
        /// <returns>Существует файл или нет</returns>
        bool Existion();

        /// <summary>
        /// Считывание данных всех векторов
        /// </summary>
        /// <param name="filestrings">Массив строк, которые необходимо преобразовать в векторы</param>
        /// <param name="irisvectors">Матрица для записи получившихся векторов</param>
        void AllVectorsCreate(string[] filestrings, List<List<MathVector>> irisvectors);

        /// <summary>
        /// Записывает данные в один вектор.
        /// </summary>
        /// <param name="tmp">Вектор для записи</param>
        /// <param name="subs"></param>
        void VectorCreate(MathVector tmp, string[] subs);

        /// <summary>
        /// Проверка, ялвяется ли строка числом
        /// </summary>
        /// <param name="to_check">Строка для проверки</param>
        bool DoubleCheck(string to_check);

        /// <summary>
        /// Выбирает, какой тип ирис-вектора был получен
        /// Записывает его в соответвующую строку матрицы
        /// </summary>
        /// <param name="irisname">Тип данного ирис-вектора</param>
        /// <param name="irisvectors">Матрица ирис-векторов, в которую будет записан новый</param>
        /// <param name="tmp">Данный ирис-вектор</param>
        /// <exception cref="Exception("Unknown iris type")">
        /// Ошибка, выбрасываемая в случае, если тип ирис-вектора неправильный
        /// </exception>"
        void IrisTypeChoose(string irisname, List<List<MathVector>> irisvectors, MathVector tmp);
    }
}
