using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinearAlgebra;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

//контроллер кнопок(прословйка между интерфейсом и моделью)
namespace IrisOpener
{
    class Controller
    {
        private IrisModel handler;
        private FileWorker worker;

        public Controller(string filename)
        {
            WorkerCreating(filename);
        }

        /// <summary>
        /// Создает объект Обработчик файла, передавая ему имя файла, выбранного пользователем
        /// </summary>
        /// <param name="filename">Имя файла, выбранное пользователем</param>
        
        public void WorkerCreating(string filename)
        {
            worker = new FileWorker(filename);
        }

        /// <summary>
        /// Создает обработчик и передает в него данные файла, возвращает результаты работы 
        /// </summary>
        public List<MathVector> WorkerHandlerAsking()
        {
            handler = new IrisModel(worker.ReadFullFile());
            return handler.AverageForAllCount();
        }
        
        public MathVector EvcledeanAsk()
        {
            return handler.EvcledeanCount();
        }

        /*public MathVector SqrtAsk()
        {
            return handler.sqrtFind();
        }*/

        public List<MathVector> DispSqrtAsk()
        {
            return handler.DispSqrtFind();
        }
    }
}
