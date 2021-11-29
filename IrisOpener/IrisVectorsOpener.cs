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

//интерфейс
namespace IrisOpener
{
    public partial class IrisVectorsOpener : Form
    {
        private Controller controller;
        private const int number_charts = 4;
        private const int number_irises = 3;

        public IrisVectorsOpener()
        {
            InitializeComponent();
        }

       /// <summary>
       /// Метод, вызываемый при нажатии на кнопку "Open File"
       /// </summary>
        public void button1_Click(object sender, EventArgs e)
        {
            string filename = FileAsking();
            try
            {
                controller = new Controller(filename);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found");
                return;
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Too big file");
                return;
            }
            Drawing();
            FilePathLabel.Text = filename;
        }


        /// <summary>
        /// Метод, вызывающий диалоговое окно для открытия файла
        /// </summary>
        /// <returns>Имя выбранного пользователем файла</returns>
        public string FileAsking()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Comma separeted files (*.csv)|*.csv"; //фильтр, чтобы нельзя было открыть ничего кроме csv
            dialog.ShowDialog();
            return dialog.FileName;
        }

        /// <summary>
        /// Рисует все необходимым графики
        /// Сначала обращается к контроллеру для получения усредненных векторов.
        /// Добавляет их в чарты.
        /// Затем отрисовывает круговую диаграмму.
        /// </summary>
        public void Drawing ()
        {
            try
            {
                AllChartsFill(controller.WorkerHandlerAsking());
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong data!");
                return;
            }
            EvcledeanBuild(controller.EvcledeanAsk());
            SqrtBuild(controller.DispSqrtAsk()[1], chartSqrt, "Sqrt");
            SqrtBuild(controller.DispSqrtAsk()[0], chartDisp, "Disp");
        }

        /// <summary>
        /// Заполняет столбчатые диаграммы массивом усредненных векторов
        /// </summary>
        /// <param name="data">Массив усредненных векторов</param>
        public void AllChartsFill(List<MathVector> data)
        {
            string[] speciesname = { "setosa", "versicolor", "virginica" };
            string[] titles = { "sepal_length", "sepal_width", "petal_length", "petal_width" };
            Chart[] charts = new Chart[number_charts];
            Color[] colours = new Color[number_irises];
            colours[0] = Color.Gold; colours[1] = Color.Silver; colours[2] = Color.Pink;
            charts[0] = chart_slength; charts[1] = chart_swidth;
            charts[2] = chart_plength; charts[3] = chart_pwidth;
            for (int j = 0; j < number_charts; j++)
            {
                ClearChart(charts[j]);
                AxesCreate(charts[j], titles[j]);
                for (int i = 0; i < number_irises; i++)
                {
                    OneChartColumnFill(charts[j], speciesname[i], data[i][j], colours[i]);
                }
            }
        }

        /// <summary>
        /// Отрисовывает один столбик диаграммы
        /// </summary>
        /// <param name="charttofill">Элемент, в котором рисуется диаграмма</param>
        /// <param name="serie">Строка-наименование столбца</param>
        /// <param name="data_piece">Число, которое соответствует данной строке</param>
        public void OneChartColumnFill(Chart charttofill, string serie, double data_piece, Color colour)
        {
            Series series = charttofill.Series.Add(serie);
            series.Color = colour;
            series.BorderColor = Color.Aqua;
            series.Points.Add(Math.Round(data_piece, 2));
            series.IsValueShownAsLabel = true;
            series.SmartLabelStyle.Enabled = false;
        }

        /// <summary>
        /// Создает оси для диаграммы
        /// </summary>
        /// <param name="charttofill">Диаграмма для создания осей</param>
        public void AxesCreate(Chart charttofill, string title)
        {
            Axis ax = new Axis();
            ax.Title = title;
            charttofill.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Definitions";
            charttofill.ChartAreas[0].AxisY = ay;
        }

        /// <summary>
        /// Построение круговой диаграммы по Евклидовым расстояниям
        /// </summary>
        /// <param name="data">Массив евклидовых расстояний</param>
        public void EvcledeanBuild(MathVector data)
        {
            ClearChart(chartpie);
            chartpie.Series.Add("Evcledean distance");
            chartpie.Titles.Add("Evcledean distance");
            string[] names = { "setose-versicolor", "versicolor-virginica", "virginica-setosa" };
            Color[] colours = new Color[number_irises];
            colours[0] = Color.Green; colours[1] = Color.GreenYellow; colours[2] = Color.Goldenrod;
            chartpie.Series[0].ChartType = SeriesChartType.Pie;
            for (int i = 0; i < data.Dimensions; i++)
            {
                chartpie.Series[0].Points.Add(data[i]);
                chartpie.Series[0].Points[i].Color = colours[i];
                chartpie.Series[0].BorderColor = Color.Aqua;
                chartpie.Series[0].Points[i].LegendText = names[i];
                chartpie.Series[0].Points[i].Label = (Math.Round(data[i], 2)).ToString();
            }
        }

        public void SqrtBuild(MathVector data, Chart chartToFill, string Title)
        {
            ClearChart(chartToFill);
            chartToFill.Titles.Add(Title);
            string[] names = { "setose", "versicolor", "virginica" };
            Color[] colours = new Color[number_irises];
            colours[0] = Color.Green; colours[1] = Color.GreenYellow; colours[2] = Color.Goldenrod;
            for (int i = 0; i < data.Dimensions; i++)
            {
                OneChartColumnFill(chartToFill, names[i], data[i], colours[i]);
            }
        }


        /// <summary>
        /// Отчистка элемента для дальнейшей работы с ним.
        /// </summary>
        /// <param name="chart_to_clear">Элемент, который нужно отчистить</param>
        public void ClearChart(Chart chart_to_clear)
        {
            chart_to_clear.Series.Clear();
            chart_to_clear.Titles.Clear();
        }
    }
}
