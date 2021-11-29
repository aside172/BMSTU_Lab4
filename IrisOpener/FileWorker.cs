using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;
using System.IO;

namespace IrisOpener
{
    /// <summary>
    /// Класс обработчика файла 
    /// </summary>
    public class FileWorker : IFileWorker
    {
        string path;
        const int maxFileSizeByte = 10240; //размер файла в байтах 
        private const int number_irises = 3; //кол-во типов ирисов
        private const int number_charts = 4; //кол-во графиков

        public FileWorker(string filename)
        {
            path = filename;
            if (filename == "") //проверка на наличие имени файла
            {
                throw new FileNotFoundException();
            }
            FileInfo file = new FileInfo(path); // информация о файле
            if (file.Length >= maxFileSizeByte) //проверка на размер файла
            {
                throw new FileLoadException();
            }
        }

       /// <summary>
       /// Считывает матрицу векторов
       /// Одна строка матрицы - один тип векторов (iris species)
       /// Изначально создает массив строк, который потом передает в другую функцию
       /// </summary>
       /// <returns>Возвращает матрицу векторов-ирис</returns>
       /// <exception cref="FileNotFoundException">
       /// Исключение для случая, когда файл не найден
       /// </exception>"
        public List<List<MathVector>> ReadFullFile()
        {
            if (Existion()) //проверка на существование файла
            {
                List<List<MathVector>> irisvectors = new List<List<MathVector>>();
                for (int i = 0; i < number_irises; i++)
                    irisvectors.Add(new List<MathVector>());
                string[] filestrings = File.ReadAllLines(path);
                AllVectorsCreate(filestrings, irisvectors);
                return irisvectors;
            }
            else
                throw new FileNotFoundException(); //если нет файла
        }

        /// <summary>
        /// Проверка на существование файла
        /// </summary>
        /// <returns>Существует файл или нет</returns>
        public bool Existion() // вызываем выше
        {
            bool result;
            if (File.Exists(path) && path != "")
                result = true;
            else
                result = false;
            return result;
        }

        /// <summary>
        /// Считывание данных всех векторов
        /// </summary>
        /// <param name="filestrings">Массив строк, которые необходимо преобразовать в векторы</param>
        /// <param name="irisvectors">Матрица для записи получившихся векторов</param>
        public void AllVectorsCreate(string[] filestrings, List<List<MathVector>> irisvectors)
        {
            for (int i = 1; i < filestrings.Length; i++)
            {
                MathVector tmp = new MathVector(number_charts);
                string[] subs = filestrings[i].Split(',');
                SplitNumberCheck(subs);
                VectorCreate(tmp, subs);
                IrisTypeChoose(subs[number_charts], irisvectors, tmp);
            }
        }

        /// <summary>
        /// Проверяет количество параметров в строке
        /// </summary>
        /// <param name="strings">Строка для проверки</param>
        /// <exception cref="Exception("Wrong number of iris parametrs!")>Ошибка, возвращаемая в случае, если количество параметров больше или меньше нужного</exception>"
        public void SplitNumberCheck(string[] strings)
        {
            if (strings.Length != number_charts + 1)
                throw new Exception("Wrong number of iris parametrs!");
        }

        /// <summary>
        /// Записывает данные в один вектор.
        /// </summary>
        /// <param name="tmp">Вектор для записи</param>
        /// <param name="subs"></param>
        public void VectorCreate(MathVector tmp, string[] subs)
        {
            for (int j = 0; j < number_charts; j++)
            {
                if (DoubleCheck(subs[j])) //проверка на то что это число, а не что-то другое
                    tmp[j] = Convert.ToDouble(subs[j], System.Globalization.CultureInfo.InvariantCulture);
                else
                    throw new Exception("Parametr not a number");
            }
        }

        /// <summary>
        /// Проверка, ялвяется ли строка числом
        /// </summary>
        /// <param name="to_check">Строка для проверки</param>
        public bool DoubleCheck(string to_check)
        {
            bool res = true;
            bool dot = false;
            for (int i = 0; i < to_check.Length; i++)
            {
                if (Char.IsNumber(to_check[i]) || (dot == false && to_check[i] == '.'))
                {
                    if (to_check[i] == '.')
                        dot = true;
                }
                else
                    res = false;
            }
            return res;
        }

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
        public void IrisTypeChoose(string irisname, List<List<MathVector>> irisvectors, MathVector tmp)
        {
            if (irisname == "setosa")
                irisvectors[0].Add(tmp);
            else if (irisname == "versicolor")
                irisvectors[1].Add(tmp);
            else if (irisname == "virginica")
                irisvectors[2].Add(tmp);
            else
                throw new Exception("Unknow iris type!");
        }
    }
}
