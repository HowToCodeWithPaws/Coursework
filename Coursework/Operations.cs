using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadarLib;
using System.IO;
using MatlabFuncs;
using MathWorks.MATLAB.NET.Arrays;

namespace Coursework
{
	/// <summary>
	/// Форма для загрузки, генерирования и сохранения
	/// файлов наблюдений, корреляционной матрицы,
	/// статистики наблюдений и визуализации.
	/// </summary>
	public partial class Operations : Form
	{
		/// <summary>
		/// Поля для цветов, которые определяют внешний 
		/// вид формы.
		/// </summary>
		Color backColor = Color.FromArgb(46, 76, 86);
		Color panelColor = Color.FromArgb(89, 139, 155);
		Color hoverColor = Color.FromArgb(125, 167, 181);
		Color textColor = Color.FromArgb(160, 238, 230);

		/// <summary>
		/// Поля для предыдущей формы и начального экрана.
		/// </summary>
		Input prevForm;
		Homescreen homescreen;

		/// <summary>
		/// Поле для экземпляра класса функций матлаб.
		/// </summary>
		Funcs funcs;

		/// <summary>
		/// Поля для параметров симуляции.
		/// </summary>
		float Um, Vm, du, dv, u, v, a, Tc, up1,
			up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H;
		int N, Mu, Mv, pq, M;

		/// <summary>
		/// Поля-флаги для определения стадии работы
		/// и мониторинга добавленной информации и 
		/// опций, открытых в зависимости от этого.
		/// </summary>
		bool dataE, matrixE, statE;

		/// <summary>
		/// Конструктор для формы с параметрами - параметрами симуляции.
		/// Задает внешний вид формы, значения полей, настраивает 
		/// подсказки для пользователя.
		/// </summary>
		/// <param name="form"> Параметр для предыдущей формы. </param>
		/// <param name="homescreen"> Параметр для начального экрана. </param>
		/// <param name="funcs"> Параметр для экземпляра класса функций
		/// матлаб. </param>
		/// <param name="N"> Параметр для количества векторов, по которым
		/// составляются наблюдения. </param>
		/// <param name="Mu"> Параметр для размера решетки радиолокатора 
		/// по длине. </param>
		/// <param name="Mv"> Параметр для размера решетки радиолокатора 
		/// по ширине. </param>
		/// <param name="Um"> Параметр для ширины главного лепестка
		/// диаграммы направленности модуля по одному углу. </param>
		/// <param name="Vm"> Параметр для ширины главного лепестка
		/// диаграммы направленности модуля по другому углу. </param>
		/// <param name="du"> Параметр для сдвига до центра
		/// просматриваемого сектора по одному углу. </param>
		/// <param name="dv"> Параметр для сдвига до центра
		/// просматриваемого сектора по другому углу. </param>
		/// <param name="u"> Параметр для предполагаемого положения
		/// цели по одному углу. </param>
		/// <param name="v"> Параметр для предполагаемого положения
		/// цели по одному углу. </param>
		/// <param name="a"> Параметр для мощности сигнала. </param>
		/// <param name="Tc"> Параметр для времени начала прихода
		/// сигнала. </param>
		/// <param name="up1"> Параметр для первой компоненты
		/// положения помех по одному углу. </param>
		/// <param name="up2"> Параметр для второй компоненты
		/// положения помех по одному углу. </param>
		/// <param name="vp1"> Параметр для первой компоненты
		/// положения помех по другому углу. </param>
		/// <param name="vp2"> Параметр для второй компоненты
		/// положения помех по другому углу. </param>
		/// <param name="Ap1"> Параметр для первой компоненты
		/// мощности помех. </param>
		/// <param name="Ap2"> Параметр для второй компоненты
		/// мощности помех. </param>
		/// <param name="gamma"> Параметр гамма. </param>
		/// <param name="_mu"> Параметр для коэффициента
		/// регуляризации корреляционной матрицы. </param>
		/// <param name="H"> Параметр для порогового значения
		/// мощности сигнала. </param>
		/// <param name="pq"> Параметр для количества блоков,
		/// по которым составляется корреляционная матрица. </param>
		public Operations(Input form, Homescreen homescreen,
			Funcs funcs, int N, int Mu, int Mv,
			float Um, float Vm, float du, float dv, float u, float v,
			float a, float Tc, float up1, float up2, float vp1, float vp2,
			float Ap1, float Ap2, float gamma, float _mu, float H, int pq)
		{
			this.Mu = Mu;
			this.Mv = Mv;
			this.Um = Um;
			this.Vm = Vm;
			this.u = u;
			this.v = v;
			this.du = du;
			this.dv = dv;
			this.a = a;
			this.Tc = Tc;
			this.up1 = up1;
			this.up2 = up2;
			this.vp1 = vp1;
			this.vp2 = vp2;
			this.Ap1 = Ap1;
			this.Ap2 = Ap2;
			this.H = H;
			this._mu = _mu;
			this.pq = pq;
			this.N = N;
			this.gamma = gamma;
			this.funcs = funcs;
			prevForm = form;
			this.homescreen = homescreen;
			M = Mu * Mv;

			InitializeComponent();

			log.Text = "Параметры симуляции определены";

			dataE = matrixE = statE = bSaveData.Enabled
				= bGenMatrix.Enabled = bSaveMatrix.Enabled
				= bGenStat.Enabled = bSaveStat.Enabled
				= bVisualize.Enabled = false;

			this.BackColor = log.BackColor = backColor;
			panel.BackColor = panelColor;
			log.ForeColor = textColor;

			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.FlatAppearance.MouseOverBackColor = hoverColor;
				b.ForeColor = textColor;
			}

			toolTip.SetToolTip(bBackToHomepage, "Внимание!" +
				"\nПри возвращении прогресс текущей сессии будет потерян." +
				"\nУбедитесь в том, что вы сохранили все файлы," +
				"\nкоторые не хотите потерять.");
			toolTip.SetToolTip(bBackToInput, "Внимание!" +
				"\nПри возвращении прогресс текущей сессии," +
				"\nкроме параметров симуляции, будет потерян." +
				"\nУбедитесь в том, что вы сохранили все файлы," +
				"\nкоторые не хотите потерять.");
		}

		/// <summary>
		/// Обработчик нажатия на кнопку добавления файлов наблюдений.
		/// Вызывает метод открытия желаемых файлов с проверкой длины,
		/// обновляет информацию в логгере, в случае успеха меняет
		/// флаг наличия файлов наблюдений и активизирует связанные с
		/// этим кнопки.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGetData_Click(object sender, EventArgs e)
		{
			log.Text += "\nДобавляем файлы наблюдений";

			progress.Visible = true;

			if (OpenFile("Sx.txt", false, 0) && OpenFile("Sy.txt", false, 0)
				&& OpenFile("Ux.txt", false, 0) && OpenFile("Uy.txt", false, 0)
				&& OpenFile("YX.txt", true, M * N * pq)
				&& OpenFile("YY.txt", true, M * N * pq))
			{
				progress.Visible = false;
				log.Text += "\nФайлы наблюдений добавлены";
				dataE = bGenMatrix.Enabled = bSaveData.Enabled = true;
			}
			else
			{
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		/// <summary>
		/// Обработчик нажатия на кнопку добавления файлов матрицы.
		/// Вызывает метод открытия желаемых файлов с проверкой длины,
		/// обновляет информацию в логгере, в случае успеха меняет
		/// флаг наличия файлов матрицы и активизирует связанные с
		/// этим кнопки.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGetMatrix_Click(object sender, EventArgs e)
		{
			log.Text += "\nДобавляем файлы матрицы";
			progress.Visible = true;

			if (OpenFile("Rx.txt", true, M * M * pq)
				&& OpenFile("Ry.txt", true, M * M * pq))
			{
				progress.Visible = false;
				log.Text += "\nФайлы матрицы добавлены";
				matrixE = bGenStat.Enabled = bSaveMatrix.Enabled = true;
			}
			else
			{
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		/// <summary>
		/// Обработчик нажатия на кнопку добавления файла статистики.
		/// Вызывает метод открытия желаемого файла с проверкой длины,
		/// обновляет информацию в логгере, в случае успеха меняет
		/// флаг наличия файла статистики и активизирует связанные с
		/// этим кнопки.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGetStat_Click(object sender, EventArgs e)
		{
			log.Text += "\nДобавляем файл статистики";
			progress.Visible = true;

			if (OpenFile("Lfile.txt", true, 9 * 9 * N / 9))
			{
				progress.Visible = false;
				log.Text += "\nФайл статистики добавлен";
				statE = bVisualize.Enabled = bSaveStat.Enabled = true;
			}
			else
			{
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		/// <summary>
		/// Метод для добавления информации из файлов.
		/// Открывает диалоговое окно для выбора файла,
		/// вызывает метод проверки корректности файла,
		/// в случае корректности данных копирует 
		/// выбранный файл в соответсвующий рабочий файл,
		/// сохраняет изменения в логгер, обрабатывает
		/// исключения, которые могут возникнуть при
		/// открытии и чтении файла.
		/// </summary>
		/// <param name="name"> Параметр для имени
		/// рабочего файла, в который должна быть
		/// скопирована информация. </param>
		/// <param name="checkLen"> Параметр для флага,
		/// нужно ли проверять длину файла. </param>
		/// <param name="len"> Параметр для ожидаемой
		/// длины файла. </param>
		/// <returns> возвращает результат успешности
		/// добавления файла. </returns>
		bool OpenFile(string name, bool checkLen, int len)
		{
			try
			{
				log.Text += "\nДобавляем файл " + name;
				MessageBox.Show("Вам нужно выбрать файл " + name);

				string path;
				openFile.FileName = null;
				openFile.ShowDialog();
				path = openFile.FileName;

				if (CheckData(path, checkLen, len))
				{
					File.Copy(path, name, true);
					log.Text += "\nФайл " + name + " добавлен";
					return true;
				}
				else return false;
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show("Вы не выбрали путь для файла.\n" + ex.Message);

				log.Text += "\nОшибка при добавлении файла " + name;

				return false;
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при добавлении файла " + name;

				return false;
			}
			catch (IOException ex)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при добавлении файла " + name;

				return false;
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при добавлении файла " + name;

				return false;
			}
			catch (System.Security.SecurityException ex)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при добавлении файла " + name;

				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nОшибка при добавлении файла " + name;

				return false;
			}
		}

		/// <summary>
		/// Метод для проверки корректности загружаемых файлов.
		/// Вызывает метод считывания чисел и проверяет соответствие
		/// каждого числа требуемому типу, также сравнивает длину 
		/// файла с ожидаемой длиной и возвращает результат соответствия
		/// файла требованиям.
		/// </summary>
		/// <param name="path"> Параметр для пути к проверяемому
		/// файлу. </param>
		/// <param name="checkLen"> Параметр для флага, нужна ли
		/// для этого файла проверка длины. </param>
		/// <param name="expectedLen"> Параметр для ожидаемой длины
		/// файла. </param>
		/// <returns> возвращает булевое true, если файл содержит
		/// числа в нужном количестве, и false в противном случае. </returns>
		bool CheckData(string path, bool checkLen, int expectedLen)
		{
			StreamReader filestr =
				new StreamReader(new FileStream(path, FileMode.Open));

			float num;
			int length = 0;

			while (true)
			{
				var t = NextNumber(filestr);

				if (t == "") break;

				if (!float.TryParse(t, out num))
				{
					MessageBox.Show($"В файле {path} находятся данные" +
						$" не в требуемом числовом формате");

					return false;
				}

				length++;
			}

			filestr.Dispose();

			if (checkLen && (expectedLen > length))
			{
				MessageBox.Show($"В файле {path} находятся данные" +
						$" не в требуемом количестве {length}");

				return false;
			}

			return true;
		}

		/// <summary>
		/// Метод для считывания следующего числа из
		/// файлового потока.
		/// </summary>
		/// <param name="streamReader"> Параметр для потока
		/// чтения. </param>
		/// <returns> Возвращает следующее число или пустую
		/// строку, если файл закончился. </returns>
		string NextNumber(StreamReader streamReader)
		{
			int c = streamReader.Peek();

			while (c != -1 && Char.IsWhiteSpace(Convert.ToChar(c)))
			{
				streamReader.Read();
				c = streamReader.Peek();
			}

			if (c == -1) return "";

			StringBuilder b = new StringBuilder();

			while (c != -1 && !Char.IsWhiteSpace(Convert.ToChar(c)))
			{
				b.Append(Convert.ToChar(c));
				streamReader.Read();
				c = streamReader.Peek();
			}

			return b.ToString();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку генерации наблюдений.
		/// Вызывает асинхронный метод генерации наблюдений.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGenData_Click(object sender, EventArgs e)
		{
			BeginData();
		}

		/// <summary>
		/// Метод для генерирования наблюдений, настраивает
		/// вид формы на время осуществления процесса и вызывает
		/// метод генерирования наблюдений из экемпляра класса
		/// функций матлаб, засекает время за которое процесс
		/// завершается, обновляет информацию в логгере и флаг
		/// наличия наблюдений в случае успеха.
		/// </summary>
		async void BeginData()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем генерацию наблюдений";

				MWArray[] res = null;

				await Task.Run(() =>
				{
					res = funcs.CreateFiles(1, N, Mu, Mv, Um, Vm, du, dv,
					u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu);
				});

				TimeSpan timeSpan = TimeSpan.FromSeconds(double.Parse(res[0].ToString()));
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
					timeSpan.Milliseconds / 10);

				progress.Visible = false;
				log.Text += $"\nНаблюдения сгенерированы за " + elapsedTime;

				dataE = true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Произошла ошибка при генерации наблюдений." +
					" Начните заново, либо перейдите к другому шагу.\n" + e.Message);
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка при генерации наблюдений";
			}
			finally { Enable(); }
		}

		/// <summary>
		/// Обработчик нажатия на кнопку расчета корреляционной матрицы.
		/// Вызывает асинхронный метод расчета корреляционной матрицы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGenMatrix_Click(object sender, EventArgs e)
		{
			BeginMatrix();
		}

		/// <summary>
		/// Метод для расчета корреляционной матрицы, настраивает
		/// вид формы на время осуществления процесса и вызывает
		/// метод расчета матрицы из класса библиотеки, засекает
		/// время за которое процесс завершается, обновляет 
		/// информацию в логгере и флаг наличия матрицы в случае успеха.
		/// </summary>
		async void BeginMatrix()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем вычисление корреляционной матрицы";

				string res = "";

				await Task.Run(() => { res = RadarOperations.Start(Mu * Mv, N, pq, _mu); });

				progress.Visible = false;
				log.Text += $"\nВычисление матрицы закончено за {res}";
				matrixE = true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Произошла ошибка при расчете корреляционной матрицы." +
					" Начните заново, либо перейдите к другому шагу.\n" + e.Message);
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка при расчете корреляционной матрицы";
			}
			finally { Enable(); }
		}

		/// <summary>
		/// Обработчик нажатия на кнопку расчета статистики.
		/// Вызывает асинхронный метод расчета статистики.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGenStat_Click(object sender, EventArgs e)
		{
			BeginL();
		}

		/// <summary>
		/// Метод для расчета статистики наблюдений, настраивает
		/// вид формы на время осуществления процесса и вызывает
		/// метод расчета статистики наблюдений из экемпляра класса
		/// функций матлаб, засекает время за которое процесс
		/// завершается, обновляет информацию в логгере и флаг
		/// наличия статистики наблюдений в случае успеха.
		/// </summary>
		async void BeginL()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем расчет статистики наблюдений";

				MWArray[] res = null;

				await Task.Run(() =>
				{
					res = funcs.CreateL(1, N, Mu, Mv, Um, Vm, _mu);
				});

				TimeSpan timeSpan = TimeSpan.FromSeconds(double.Parse(res[0].ToString()));
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
					timeSpan.Milliseconds / 10);

				progress.Visible = false;
				log.Text += $"\nРасчет статистики наблюдений закончен за " + elapsedTime;
				statE = true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Произошла ошибка при расчете статистики наблюдений." +
					" Начните заново, либо перейдите к другому шагу.\n" + e.Message);
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка при расчете статистики наблюдений";
			}
			finally { Enable(); }
		}

		/// <summary>
		/// Обработчик нажатия на кнопку визуализации данных.
		/// Вызывает асинхронный метод визуализации.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bVisualize_Click(object sender, EventArgs e)
		{
			BeginVis();
		}

		/// <summary>
		/// Метод для визуализации данных статистики, настраивает
		/// вид формы на время осуществления процесса и вызывает
		/// метод визуализации из экемпляра класса
		/// функций матлаб, засекает время за которое процесс
		/// завершается, обновляет информацию в логгере.
		/// </summary>
		async void BeginVis()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем визуализацию";

				MWArray[] res = null;

				await Task.Run(() =>
				{
					res = funcs.CreatePicture(1, N, Um, Vm, H);
				});

				TimeSpan timeSpan = TimeSpan.FromSeconds(double.Parse(res[0].ToString()));
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
					timeSpan.Milliseconds / 10);

				progress.Visible = false;
				log.Text += $"\nВизуализация закончена за " + elapsedTime;
			}
			catch (Exception e)
			{
				MessageBox.Show("Произошла ошибка при визуализации." +
					" Начните заново, либо перейдите к другому шагу.\n" + e.Message);
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка при визуализации";
			}
			finally { Enable(); }
		}

		/// <summary>
		/// Обработчик нажатия на кнопку сохранения файлов
		/// наблюдений. В логгер заносится запись о текущем 
		/// процессе и вызывается метод копирования файла.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSaveData_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файлов наблюдений";
			progress.Visible = true;

			SaveFile("Sx.txt");
			SaveFile("Sy.txt");
			SaveFile("Ux.txt");
			SaveFile("Uy.txt");
			SaveFile("YX.txt");
			SaveFile("YY.txt");

			progress.Visible = false;
			log.Text += "\nСохранение файлов наблюдений закончено";
		}

		/// <summary>
		/// Обработчик нажатия на кнопку сохранения файлов
		/// скорреляционной матрицы. В логгер заносится запись
		/// о текущем процессе и вызывается метод копирования файла.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSaveMatrix_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файлов матрицы";
			progress.Visible = true;

			SaveFile("Rx.txt");
			SaveFile("Ry.txt");

			progress.Visible = false;
			log.Text += "\nСохранение файлов матрицы закончено";
		}

		/// <summary>
		/// Обработчик нажатия на кнопку сохранения файла 
		/// статистики. В логгер заносится запись о текущем
		/// процессе и вызывается метод копирования файла.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSaveStat_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файла статистики";
			progress.Visible = true;

			SaveFile("Lfile.txt");

			progress.Visible = false;
			log.Text += "\nСохранение файлов статистики закончено";
		}

		/// <summary>
		/// Метод для сохранения файлов в выбранное пользователем место. 
		/// Заносит состояние задания в логгер, открывает диалоговое окно
		/// для сохранения файла и копирует рабочий файл в требуемую
		/// директорию. Также обрабатываютяс возможные исключения.
		/// </summary>
		/// <param name="name"> Параметр для имени копируемого файла.
		/// Он же адрес в силу организации работы с файлами в программе. </param>
		void SaveFile(string name)
		{
			try
			{
				log.Text += "\nСохраняем файл " + name;
				MessageBox.Show("Вам нужно выбрать, куда сохранить файл " + name);

				string path;
				saveFile.FileName = null;
				saveFile.ShowDialog();
				path = saveFile.FileName;

				File.Copy(name, path, true);

				log.Text += "\nФайл " + name + " сохранен";
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show("Вы не выбрали путь для файла.\n" + ex.Message);

				log.Text += "\nОшибка при сохранении файла " + name;
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при сохранении файла " + name;
			}
			catch (IOException ex)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при сохранении файла " + name;
			}
			catch (UnauthorizedAccessException ex)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при сохранении файла " + name;
			}
			catch (System.Security.SecurityException ex)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.\n" + ex.Message);
				log.Text += "\nОшибка при сохранении файла " + name;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nОшибка при сохранении файла " + name;
			}
		}

		/// <summary>
		/// Обработчик нажатия на кнопку возвращения к 
		/// предыдущей форме. Текущая форма закрывается
		/// и показывается предыдущая.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bBackToInput_Click(object sender, EventArgs e)
		{
			this.Close();
			prevForm.Show();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку возвращения на главную
		/// страницу. Закрываются предыдущая и текущая формы,
		/// открывается форма главной страницы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bBackToHomepage_Click(object sender, EventArgs e)
		{
			prevForm.Close();
			this.Close();
			homescreen.Show();
		}

		/// <summary>
		/// Метод, позволяющий получить все элементы
		/// определенного типа на форме для их 
		/// более удобной настройки.
		/// </summary>
		/// <typeparam name="T"> Параметр для типа
		/// желаемых элементов. </typeparam>
		/// <param name="container"> Параметр для
		/// контейнера, на котором требуется найти
		/// элементы желаемого типа. </param>
		/// <returns> Возвращает список элементов
		/// контроля желаемого типа. </returns>
		static private List<Control> GetAllControlsOfType<T>(Control container)
		{
			List<Control> controlList = new List<Control>();
			foreach (Control c in container.Controls)
			{
				controlList.AddRange(GetAllControlsOfType<T>(c));

				if (c is T)
				{
					controlList.Add(c);
				}
			}

			return controlList;
		}

		/// <summary>
		/// Метод, который переводит кнопки в активное состояние
		/// в зависимости от того, могут ли они быть активными
		/// (была ли добавлена информация, с которой связана их
		/// работа).
		/// </summary>
		void Enable()
		{
			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.Enabled = true;
			}

			bVisualize.Enabled = bSaveStat.Enabled = statE;
			bGenStat.Enabled = bSaveMatrix.Enabled = matrixE;
			bGenMatrix.Enabled = bSaveData.Enabled = dataE;
		}

		/// <summary>
		/// Метод, переводящий все кнопки в неактивное состояние.
		/// </summary>
		void Disable()
		{
			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.Enabled = false;
			}
		}
	}
}
