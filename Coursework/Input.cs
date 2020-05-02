using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
	/// <summary>
	/// Форма, на которой происходит задание параметров
	/// симуляции посредством ввода в текстовые поля на
	/// форме, либо загрузки из файла с последующей
	/// возможностью сохранения параметров в выбранный
	/// пользователем файл.
	/// </summary>
	public partial class Input : Form
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
		/// Поле для ссылки на предыдущую форму,
		/// которая откроется в случае закрытия этой.
		/// </summary>
		Homescreen prevForm;

		/// <summary>
		/// Поле для ссылки на экземпляр класса
		/// функций матлаб.
		/// </summary>
		MatlabFuncs.Funcs funcs;

		/// <summary>
		/// Поля для параметров симуляции.
		/// </summary>
		float Um, Vm, du, dv, u, v, a, Tc, up1, up2, 
			vp1, vp2, Ap1, Ap2, gamma, _mu, H;
		int N, Mu, Mv, pq;

		/// <summary>
		/// Конструктор формы, определающий внешний вид формы 
		/// и вызывающий метод, приводящий форму к дефолтному
		/// состоянию.
		/// </summary>
		/// <param name="homescreen"> Параметр для ссылки на
		/// предыдущую форму. </param>
		/// <param name="funcs"> Параметр для экземпляра класса
		/// функций матлаб. </param>
		public Input(Homescreen homescreen, MatlabFuncs.Funcs funcs)
		{
			this.funcs = funcs;
			prevForm = homescreen;

			System.Globalization.CultureInfo.CurrentCulture
				= new System.Globalization.CultureInfo("en-US", false);

			this.BackColor = backColor;

			InitializeComponent();

			Begin();
		}

		/// <summary>
		/// Метод, задающий внешний вид формы и значения 
		/// параметров симуляции их дефолтными значениями,
		/// тут же происходит натсройка текста надписей 
		/// и подсказок для пользователя.
		/// </summary>
		void Begin()
		{
			panel.BackColor = panelColor;

			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.FlatAppearance.MouseOverBackColor = hoverColor;
				b.ForeColor = textColor;
			}

			foreach (Label l in GetAllControlsOfType<Label>(this))
			{
				l.ForeColor = textColor;
			}

			du = dv = Um = Vm = 0.1666667f;
			u = v = vp1 = vp2 = gamma = 0;
			a = 0.42f;
			Tc = 20;
			up1 = 0.03125f;
			up2 = -0.03125f;
			Ap1 = Ap2 = 300;
			_mu = 3000; H = 7;
			N = 128;
			Mu = Mv = 8;
			pq = 576;

			lN.Text = $"N = {N}";
			lMu.Text = $"Mu = {Mv}";
			lMv.Text = $"Mv = {Mu}";
			lUm.Text = $"Um = {Um}";
			lVm.Text = $"Vm = {Vm}";
			ldu.Text = $"du = {dv}";
			ldv.Text = $"dv = {dv}";
			lu.Text = $"u = {u}";
			lv.Text = $"v = {v}";
			lTc.Text = $"Tc = {Tc}";
			la.Text = $"a = {a}";
			lup1.Text = $"up1 = {up1}";
			lup2.Text = $"up2 = {up2}";
			lvp1.Text = $"vp1 = {vp1}";
			lvp2.Text = $"vp2 = {vp2}";
			lAp1.Text = $"Ap1 = {Ap1}";
			lAp2.Text = $"Ap2 = {Ap2}";
			lgamma.Text = $"gamma = {gamma}";
			l_mu.Text = $"_mu = {_mu}";
			lH.Text = $"H = {H}";
			lpq.Text = $"pq = {pq}";

			InN.Text = N.ToString();
			InMu.Text = Mu.ToString();
			InMv.Text = Mu.ToString();
			InUm.Text = Um.ToString();
			InVm.Text = Vm.ToString();
			Indu.Text = dv.ToString();
			Indv.Text = dv.ToString();
			Inu.Text = u.ToString();
			Inv.Text = v.ToString();
			InTc.Text = Tc.ToString();
			Ina.Text = a.ToString();
			Inup1.Text = up1.ToString();
			Inup2.Text = up2.ToString();
			Invp1.Text = vp1.ToString();
			Invp2.Text = vp2.ToString();
			InAp1.Text = Ap1.ToString();
			InAp2.Text = Ap2.ToString();
			Ingamma.Text = gamma.ToString();
			In_mu.Text = _mu.ToString();
			InH.Text = H.ToString();
			Inpq.Text = pq.ToString();

			toolTip.SetToolTip(lN, "Количество векторов наблюдений," +
				"\nпо которым формируется статистика." +
				"\nЧисло должно быть целое и больше 0");
			toolTip.SetToolTip(lMu, "Количество модулей, на которые" +
				"\nразбивается антенная решетка по длине" +
				"\nЧисло должно быть целое и больше 0");
			toolTip.SetToolTip(lMv, "Количество модулей, на которые" +
				"\nразбивается антенная решетка по ширине" +
				"\nЧисло должно быть целое и больше 0");
			toolTip.SetToolTip(lUm, "Ширина главного лепестка диаграммы" +
				"\nнаправленности модуля по одному углу." +
				"\nРекомендуемое значение: эффективная" +
				"\nразрешающая способность модуля " +
				"\nпо одному измерению - 1/6 радиана");
			toolTip.SetToolTip(lVm, "Ширина главного лепестка диаграммы" +
				"\nнаправленности модуля по другому углу." +
				"\nРекомендуемое значение: эффективная" +
				"\nразрешающая способность модуля " +
				"\nпо одному измерению - 1/6 радиана");
			toolTip.SetToolTip(ldu, "Сдвиг до центра " +
				"просматриваемого сектора\nпо одному углу");
			toolTip.SetToolTip(ldv, "Сдвиг до центра" +
				" просматриваемого сектора\nпо другому углу");
			toolTip.SetToolTip(lu, "Предполагаемое положение" +
				" цели по одному углу,\nизменяется от -1/12 " +
				"до 1/12 радиана с шагом 1/48 радиана");
			toolTip.SetToolTip(lv, "Предполагаемое положение" +
				" цели по другому углу,\nизменяется от -1/12" +
				" до 1/12 радиана с шагом 1/48 радиана");
			toolTip.SetToolTip(la, "Мощность приходящего сигнала." +
				"\nЧисло должно быть больше 0");
			toolTip.SetToolTip(lTc, "Начало прихода сигнала");
			toolTip.SetToolTip(lvp1, "Положение помех по другому углу");
			toolTip.SetToolTip(lvp2, "Положение помех по другому углу");
			toolTip.SetToolTip(lup1, "Положение помех по одному углу");
			toolTip.SetToolTip(lup2, "Положение помех по одному углу");
			toolTip.SetToolTip(lAp1, "Мощность помех. " +
				"Число должно быть больше 0");
			toolTip.SetToolTip(lAp2, "Мощность помех. " +
				"Число должно быть больше 0");
			toolTip.SetToolTip(lgamma, "Параметр гамма");
			toolTip.SetToolTip(l_mu, "Параметр регуляризации корреляционной" +
				" матрицы.\nЧисло должно быть больше 0");
			toolTip.SetToolTip(lH, "Пороговое значение мощности сигнала" +
				" для вывода точки.\nЧисло должно быть больше 0");
			toolTip.SetToolTip(lpq, "Количество блоков в 36 областях," +
				"\nпо которым составляется корреляционная матрица." +
				"\nРекомендуемое значение:" +
				"\n36 * 2000 отсчетов по времени / N векторов выборки," +
				"\nв противном случае размерности матриц будут конфликтующими.");
			toolTip.SetToolTip(bGet, "Для того, чтобы загрузить параметры из файла,\n" +
				"файл должен соответствовать определенным требованиям:" +
				"\n-расширение .txt\n-параметры записаны каждый с новой строки без" +
				"\nдругих разделителей\n-дробные числа записаны через ." +
				"\n-параметры в файле идут в такой последовательности:" +
				"\nN, Mu, Mv, Um, Vm, du, dv, u,\nv, a, Tc, up1, up2, vp1, vp2,\n" +
				"Ap1, Ap2, gamma, mu, H, pq." +
				"\nВ противном случае считывание будет некорректным.");
			toolTip.SetToolTip(bExit, "Внимание!" +
				"\nПри возвращении прогресс текущей сессии будет потерян." +
				"\nУбедитесь в том, что вы сохранили все файлы," +
				"\nкоторые не хотите потерять.");
		}

		/// <summary>
		/// Обработчик нажатия на кнопку загрузки параметров
		/// из файла. Появляется диалоговое окно для выбора
		/// файла, затем вызывается метод получения параметров
		/// из файла. Обрабатываются исключения, которые
		/// могут возникнуть при чтении файла.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bGet_Click(object sender, EventArgs e)
		{
			string inputPath = "";

			if (openFileInput.ShowDialog()
				== DialogResult.OK)
			{
				inputPath = openFileInput.FileName;
			}

			try
			{
				GetFromFile(File.ReadAllLines(inputPath));
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали файл.");
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
			}
		}

		/// <summary>
		/// Метод для добавления параметров симуляции из
		/// файла. Для считанных строк по одной на каждую
		/// переменную в требуемом порядке их следования
		/// вызывается метод изменения значения параметра
		/// с проверкой корректности. Если данных не хватает,
		/// оставшиеся параметры не меняются.
		/// </summary>
		/// <param name="inputStrings"> Параметр для строк,
		/// считанных из файла. </param>
		void GetFromFile(string[] inputStrings)
		{
			try
			{
				ChangeValueI(ref N, inputStrings[0], InN, lN, 1);

				ChangeValueI(ref Mu, inputStrings[1], InMu, lMu, 1);

				ChangeValueI(ref Mv, inputStrings[2], InMv, lMv, 1);

				ChangeValueF(ref Um, inputStrings[3], InUm, lUm, 0 + float.Epsilon);

				ChangeValueF(ref Vm, inputStrings[4], InVm, lVm, 0 + float.Epsilon);

				ChangeValueF(ref du, inputStrings[5], Indu, ldu);

				ChangeValueF(ref dv, inputStrings[6], Indv, ldv);

				ChangeValueF(ref u, inputStrings[7], Inu, lu,
					(float)(-1 / 12.0), (float)(1 / 12.0));

				ChangeValueF(ref v, inputStrings[8], Inv, lv,
					(float)(-1 / 12.0), (float)(1 / 12.0));

				ChangeValueF(ref a, inputStrings[9], Ina, la);

				ChangeValueF(ref Tc, inputStrings[10], InTc, lTc);

				ChangeValueF(ref up1, inputStrings[11], Inup1, lup1);

				ChangeValueF(ref up2, inputStrings[12], Inup2, lup2);

				ChangeValueF(ref vp1, inputStrings[13], Invp1, lvp1);

				ChangeValueF(ref vp2, inputStrings[14], Invp2, lvp2);

				ChangeValueF(ref Ap1, inputStrings[15], InAp1, lAp1);

				ChangeValueF(ref Ap2, inputStrings[16], InAp2, lAp2);

				ChangeValueF(ref gamma, inputStrings[17], Ingamma, lgamma);

				ChangeValueF(ref _mu, inputStrings[18], In_mu, l_mu);

				ChangeValueF(ref H, inputStrings[19], InH, lH, 0 + float.Epsilon);

				ChangeValueI(ref pq, inputStrings[20], Inpq, lpq, 1);

			}
			catch (IndexOutOfRangeException)
			{
				MessageBox.Show("Информации в файле не хватает, но поля по максимуму заполнены");
			}
			finally { MessageBox.Show("Все корректные данные добавлены"); }
		}

		/// <summary>
		/// Метод для изменения значения параметра
		/// типа int. Вызывается метод проверки корректности
		/// задаваемого значения, если данные корректны,
		/// меняется поле параметра, надпись в связанном с
		/// ним текстовом поле и поле ввода, иначе значение
		/// не изменяется, а в поле ввода возвращается
		/// предыдущее корректное значение.
		/// </summary>
		/// <param name="value"> Параметр для изменяемого
		/// поля. </param>
		/// <param name="newvalue"> Параметр для значения,
		/// которое пользователь пытается задать. </param>
		/// <param name="Invalue"> Параметр для текстового
		/// поля, связанного с параметром симуляции. </param>
		/// <param name="lvalue"> Параметр для лейбла,
		/// связанного с параметром симуляции. </param>
		/// <param name="min"> Минимальное значение,
		/// допустимое для данного параметра. </param>
		/// <param name="max"> Маскимальное значение,
		/// допустимое для данного параметра. </param>
		void ChangeValueI(ref int value, string newvalue, 
			TextBox Invalue, Label lvalue,
			int min = int.MinValue, int max = int.MaxValue)
		{
			int num;

			if (!CheckValidityFailedI(newvalue, out num, min, max))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
				Invalue.Text = value.ToString();
			}

			else
			{
				Invalue.Text = value.ToString();
			}
		}

		/// <summary>
		/// Метод для изменения значения параметра
		/// типа float. Вызывается метод проверки корректности
		/// задаваемого значения, если данные корректны,
		/// меняется поле параметра, надпись в связанном с
		/// ним текстовом поле и поле ввода, иначе значение
		/// не изменяется, а в поле ввода возвращается
		/// предыдущее корректное значение.
		/// </summary>
		/// <param name="value"> Параметр для изменяемого
		/// поля. </param>
		/// <param name="newvalue"> Параметр для значения,
		/// которое пользователь пытается задать. </param>
		/// <param name="Invalue"> Параметр для текстового
		/// поля, связанного с параметром симуляции. </param>
		/// <param name="lvalue"> Параметр для лейбла,
		/// связанного с параметром симуляции. </param>
		/// <param name="min"> Минимальное значение,
		/// допустимое для данного параметра. </param>
		/// <param name="max"> Маскимальное значение,
		/// допустимое для данного параметра. </param>
		void ChangeValueF(ref float value, string newvalue, 
			TextBox Invalue, Label lvalue,
			float min = float.MinValue, float max = float.MaxValue)
		{
			float num;

			if (!CheckValidityFailedF(newvalue, out num, min, max))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
				Invalue.Text = value.ToString();
			}
			else
			{
				Invalue.Text = value.ToString();
			}
		}

		/// <summary>
		/// Метод проверки корректности вводимых данных
		/// для параметра типа float. Проверяется то, что 
		/// принимаемая на вход строка не пуста, что 
		/// она парсится в число требуемого типа, что
		/// значение этого числа лежит в требуемых границах.
		/// Если что-то из этого не выполняется, 
		/// возвращается булевое значение, говорящее о том,
		/// что попытка изменения некорректна.
		/// </summary>
		/// <param name="newText"> Параметр для проверяемой
		/// строки с значением, на которое пользователь
		/// хочет изменить параметр. </param>
		/// <param name="number"> Метод возвращает через
		/// модификатор out число, полученное в результате
		/// парсинга. </param>
		/// <param name="min"> Минимальное значение, 
		/// возможное для параметра. </param>
		/// <param name="max"> Максимальное значение, 
		/// возможное для параметра. </param>
		/// <returns></returns>
		public bool CheckValidityFailedF(string newText, out float number,
			float min, float max)
		{
			number = 0;

			if (string.IsNullOrEmpty(newText))
			{
				return true;
			}

			if (!float.TryParse(newText, out number))
			{
				MessageBox.Show("Вы не можете изменить значение " +
					"ячейки на такое значение!");

				return true;
			}

			if (number < min || number > max)
			{
				MessageBox.Show("Число находится вне " +
					"границ, допустимых для этого параметра!");

				return true;
			}

			return false;
		}

		/// <summary>
		/// Метод проверки корректности вводимых данных
		/// для параметра типа int. Проверяется то, что 
		/// принимаемая на вход строка не пуста, что 
		/// она парсится в число требуемого типа, что
		/// значение этого числа лежит в требуемых границах.
		/// Если что-то из этого не выполняется, 
		/// возвращается булевое значение, говорящее о том,
		/// что попытка изменения некорректна.
		/// </summary>
		/// <param name="newText"> Параметр для проверяемой
		/// строки с значением, на которое пользователь
		/// хочет изменить параметр. </param>
		/// <param name="number"> Метод возвращает через
		/// модификатор out число, полученное в результате
		/// парсинга. </param>
		/// <param name="min"> Минимальное значение, 
		/// возможное для параметра. </param>
		/// <param name="max"> Максимальное значение, 
		/// возможное для параметра. </param>
		/// <returns></returns>
		public bool CheckValidityFailedI(string newText, out int number,
			int min, int max)
		{
			number = 0;

			if (string.IsNullOrEmpty(newText))
			{
				return true;
			}

			if (!int.TryParse(newText, out number))
			{
				MessageBox.Show("Вы не можете изменить значение " +
					"ячейки на такое значение!");

				return true;
			}

			if (number < min || number > max)
			{
				MessageBox.Show("Число находится вне " +
					"границ, допустимых для этого параметра!");

				return true;
			}

			return false;
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра N. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InN_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref N, InN.Text, InN, lN, 1);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Mv. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InMv_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref Mv, InMv.Text, InMv, lMv, 1);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Mu. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InMu_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref Mu,InMu.Text, InMu, lMu, 1);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра mu. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void In_mu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref _mu, In_mu.Text, In_mu, l_mu);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Um. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InUm_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Um, InUm.Text, InUm, lUm, 0 + float.Epsilon);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Vm. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InVm_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Vm, InVm.Text, InVm, lVm, 0 + float.Epsilon);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра du. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Indu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref du,Indu.Text, Indu, ldu);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра dv. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Indv_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref dv, Indv.Text, Indv, ldv);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра u. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Inu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref u,Inu.Text, Inu, lu, (float)(-1 / 12.0), (float)(1 / 12.0));
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра v. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Inv_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref v, Inv.Text,Inv, lv, (float)(-1 / 12.0), (float)(1 / 12.0));
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра a. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ina_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref a, Ina.Text,Ina, la);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Tc. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InTc_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Tc, InTc.Text, InTc, lTc);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра H. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InH_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref H, InH.Text, InH, lH, 0 + float.Epsilon);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра up1. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Inup1_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref up1, Inup1.Text, Inup1, lup1);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра up2. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Inup2_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref up2, Inup2.Text, Inup2, lup2);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра vp1. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Invp1_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref vp1, Invp1.Text, Invp1, lvp1);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра vp2. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Invp2_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref vp2, Invp2.Text, Invp2, lvp2);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Ap1. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InAp1_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Ap1, InAp1.Text, InAp1, lAp1);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра Ap2. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InAp2_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Ap2, InAp2.Text, InAp2, lAp2);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра gamma. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Ingamma_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref gamma, Ingamma.Text, Ingamma, lgamma);
		}

		/// <summary>
		/// Обработчик покидания текстового поля для задания
		/// параметра pq. Вызывается метод изменения значения
		/// параметра с проверкой корректности.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Inpq_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref pq, Inpq.Text, Inpq, lpq, 1);
		}

		/// <summary>
		/// Обработчик нажатия на кнопку сохранения параметров.
		/// Появляется окно выбора директории, затем файл 
		/// записывается в выбранное место. Также обрабатываются
		/// исключения, которые могут возникнуть при записи.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSave_Click(object sender, EventArgs e)
		{
			string path = "";

			if (saveFileInput.ShowDialog()
				== DialogResult.OK)
			{
				path = saveFileInput.FileName;
			}

			try
			{
				File.WriteAllLines(path, new string[]
				{ N.ToString(), Mu.ToString(), Mv.ToString(),Um.ToString(), Vm.ToString(),
				du.ToString(), dv.ToString(), u.ToString(), v.ToString(), a.ToString(),
				Tc.ToString(), up1.ToString(), up2.ToString(), vp1.ToString(),vp2.ToString(),
				Ap1.ToString(),Ap2.ToString(), gamma.ToString(), _mu.ToString(), H.ToString(),
				pq.ToString() });
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
			}
			finally { MessageBox.Show("Работа с файлом окончена."); }
		}

		/// <summary>
		/// Обработчик нажатия на кнопку перехода к
		/// дальнейшей работе с данными, происходит
		/// запись файла входных параметров, создание
		/// и открытие новой формы на основе текущей,
		/// сокрытие текущей формы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bProceed_Click(object sender, EventArgs e)
		{
			try
			{
				File.WriteAllLines("Input.txt", new string[]
				{ N.ToString(), Mu.ToString(), Mv.ToString(),Um.ToString(), Vm.ToString(),
				du.ToString(), dv.ToString(),  u.ToString(), v.ToString(), a.ToString(),
				Tc.ToString(), up1.ToString(), up2.ToString(), vp1.ToString(),vp2.ToString(),
				Ap1.ToString(),Ap2.ToString(), gamma.ToString(), _mu.ToString(), H.ToString(),
				pq.ToString() });
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
			}

			this.Hide();

			new Operations(this, prevForm, funcs, N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc,
				up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H, pq).Show();
		}

		/// <summary>
		/// Обработчик кнопки закрытия формы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Обработчик закрытия формы, который
		/// открывает предыдущую форму
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Input_FormClosing(object sender,
			FormClosingEventArgs e)
		{
			prevForm.Show();
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
	}
}
