using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
	public partial class Input : Form
	{
		Color backColor = Color.FromArgb(46, 76, 86);
		Color panelColor = Color.FromArgb(89, 139, 155);
		Color hoverColor = Color.FromArgb(125, 167, 181);
		Color textColor = Color.FromArgb(160, 238, 230);

		Homescreen prevForm;

		MatlabFuncs.Funcs funcs;

		string[] inputStrings;

		string inputPath = "";

		float Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H;

		int N, Mu, Mv, pq;

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

		public void Begin()
		{
			panel.BackColor = panelColor;

			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.FlatAppearance.MouseOverBackColor = hoverColor;
				b.ForeColor = textColor;
				//		b.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 138, 162);
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
			toolTip.SetToolTip(ldu, "Сдвиг до центра просматриваемого сектора" +
				"\nпо одному углу");
			toolTip.SetToolTip(ldv, "Сдвиг до центра просматриваемого сектора" +
				"\nпо другому углу");
			toolTip.SetToolTip(lu, "Предполагаемое положение цели по одному углу," +
				"\nизменяется от -1/12 до 1/12 радиана с шагом 1/48 радиана");
			toolTip.SetToolTip(lv, "Предполагаемое положение цели по другому углу," +
				"\nизменяется от -1/12 до 1/12 радиана с шагом 1/48 радиана");
			toolTip.SetToolTip(la, "Мощность приходящего сигнала." +
				"\nЧисло должно быть больше 0");
			toolTip.SetToolTip(lTc, "Начало прихода сигнала");
			toolTip.SetToolTip(lvp1, "Положение помех по другому углу");
			toolTip.SetToolTip(lvp2, "Положение помех по другому углу");
			toolTip.SetToolTip(lup1, "Положение помех по одному углу");
			toolTip.SetToolTip(lup2, "Положение помех по одному углу");
			toolTip.SetToolTip(lAp1, "Мощность помех. Число должно быть больше 0");
			toolTip.SetToolTip(lAp2, "Мощность помех. Число должно быть больше 0");
			toolTip.SetToolTip(lgamma, "Параметр гамма");
			toolTip.SetToolTip(l_mu, "Параметр регуляризации корреляционной матрицы." +
				"\nЧисло должно быть больше 0");
			toolTip.SetToolTip(lH, "Пороговое значение мощности сигнала для вывода точки." +
				"\nЧисло должно быть больше 0");
			toolTip.SetToolTip(lpq, "Количество блоков в 36 областях," +
				"\nпо которым составляется корреляционная матрица." +
				"\nРекомендуемое значение:" +
				"\n36 * 2000 отсчетов по времени / N векторов выборки," +
				"\nв противном случае размерности матриц будут конфликтующими.");
		}

		public void GetFromFile()
		{
			try
			{
				ChangeValueFromFileI(ref N, inputStrings[0], InN, lN, 1);

				ChangeValueFromFileI(ref Mu, inputStrings[1], InMu, lMu, 1);

				ChangeValueFromFileI(ref Mv, inputStrings[2], InMv, lMv, 1);

				ChangeValueFromFileF(ref Um, inputStrings[3], InUm, lUm, 0 + float.Epsilon);

				ChangeValueFromFileF(ref Vm, inputStrings[4], InVm, lVm, 0 + float.Epsilon);

				ChangeValueFromFileF(ref du, inputStrings[5], Indu, ldu);

				ChangeValueFromFileF(ref dv, inputStrings[6], Indv, ldv);

				ChangeValueFromFileF(ref u, inputStrings[7], Inu, lu,
					(float)(-1 / 12.0), (float)(1 / 12.0));

				ChangeValueFromFileF(ref v, inputStrings[8], Inv, lv,
					(float)(-1 / 12.0), (float)(1 / 12.0));

				ChangeValueFromFileF(ref a, inputStrings[9], Ina, la);

				ChangeValueFromFileF(ref Tc, inputStrings[10], InTc, lTc);

				ChangeValueFromFileF(ref up1, inputStrings[11], Inup1, lup1);

				ChangeValueFromFileF(ref up2, inputStrings[12], Inup2, lup2);

				ChangeValueFromFileF(ref vp1, inputStrings[13], Invp1, lvp1);

				ChangeValueFromFileF(ref vp2, inputStrings[14], Invp2, lvp2);

				ChangeValueFromFileF(ref Ap1, inputStrings[15], InAp1, lAp1);

				ChangeValueFromFileF(ref Ap2, inputStrings[16], InAp2, lAp2);

				ChangeValueFromFileF(ref gamma, inputStrings[17], Ingamma, lgamma);

				ChangeValueFromFileF(ref _mu, inputStrings[18], In_mu, l_mu);

				ChangeValueFromFileF(ref H, inputStrings[19], InH, lH, 0 + float.Epsilon);

				ChangeValueFromFileI(ref pq, inputStrings[20], Inpq, lpq, 1);

			}
			catch (IndexOutOfRangeException)
			{
				MessageBox.Show("Информации в файле не хватает, но поля по максимуму заполнены");
			}
			finally { MessageBox.Show("Все корректные данные добавлены"); }
		}

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
				if (string.IsNullOrEmpty(path))
				{
					path = inputPath;
				}

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

		private void bGet_Click(object sender, EventArgs e)
		{
			if (openFileInput.ShowDialog()
				== DialogResult.OK)
			{
				inputPath = openFileInput.FileName;
			}

			try
			{
				inputStrings = File.ReadAllLines(inputPath);
				GetFromFile();
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

			// Создание новой формы на основе
			// текущей формы 
			new Operations(this, prevForm, funcs, N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc,
				up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H, pq).Show();

			// Вызов метода, приводящего форму
			// к начальному виду.
			Begin();
		}

		void ChangeValueFromFileI(ref int value, string newvalue,
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
		}

		void ChangeValueFromFileF(ref float value, string newvalue,
			TextBox Invalue, Label lvalue,
			float min = float.MinValue,	float max = float.MaxValue)
		{
			float num;

			if (!CheckValidityFailedF(newvalue, out num, min, max))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
				Invalue.Text = value.ToString();
			}
		}

		void ChangeValueI(ref int value, TextBox Invalue, Label lvalue,
			int min = int.MinValue, int max = int.MaxValue)
		{
			int num;

			if (!CheckValidityFailedI(Invalue.Text, out num, min, max))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
			}

			else
			{
				Invalue.Text = value.ToString();
			}
		}

		void ChangeValueF(ref float value, TextBox Invalue, Label lvalue,
			float min = float.MinValue, float max = float.MaxValue)
		{
			float num;

			if (!CheckValidityFailedF(Invalue.Text, out num, min, max))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
			}
			else
			{
				Invalue.Text = value.ToString();
			}
		}

		public bool CheckValidityFailedF(string newText, out float number,
			float min, float max)
		{
			number = 0;

			if (string.IsNullOrEmpty(newText))
			{
				return true;
			}

			// Если вводится нечисловое значение,
			// изменение не допускается.
			if (!float.TryParse(newText, out number))
			{
				MessageBox.Show("Вы не можете изменить значение " +
					"ячейки на нечисловое значение!");

				return true;
			}

			// Если вводится число меньше минимального, либо больше
			// максимального возможного значения, 
			// изменение не допускается.
			if (number < min || number > max)
			{
				MessageBox.Show("Число находится вне " +
					"границ, допустимых для этого параметра!");

				return true;
			}

			return false;
		}

		public bool CheckValidityFailedI(string newText, out int number,
			int min, int max)
		{
			number = 0;

			if (string.IsNullOrEmpty(newText))
			{
				return true;
			}

			// Если вводится нечисловое значение,
			// изменение не допускается.
			if (!int.TryParse(newText, out number))
			{
				MessageBox.Show("Вы не можете изменить значение " +
					"ячейки на такое значение!");

				return true;
			}

			// Если вводится число меньше минимального, либо больше
			// максимального возможного значения, 
			// изменение не допускается.
			if (number < min || number > max)
			{
				MessageBox.Show("Число находится вне " +
					"границ, допустимых для этого параметра!");

				return true;
			}

			return false;
		}

		private void InMu_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref Mu, InMu, lMu, 1);
		}
		private void In_mu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref _mu, In_mu, l_mu);
		}

		private void InUm_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Um, InUm, lUm, 0 + float.Epsilon);
		}

		private void InVm_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Vm, InVm, lVm, 0 + float.Epsilon);
		}

		private void Indu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref du, Indu, ldu);
		}

		private void Indv_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref dv, Indv, ldv);
		}

		private void Inu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref u, Inu, lu, (float)(-1 / 12.0), (float)(1 / 12.0));
		}

		private void Inv_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref v, Inv, lv, (float)(-1 / 12.0), (float)(1 / 12.0));
		}

		private void Ina_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref a, Ina, la);
		}

		private void InTc_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Tc, InTc, lTc);
		}

		private void InH_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref H, InH, lH, 0+float.Epsilon);
		}

		private void Inup1_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref up1, Inup1, lup1);
		}

		private void Inup2_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref up2, Inup2, lup2);
		}

		private void Invp1_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref vp1, Invp1, lvp1);
		}

		private void Invp2_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref vp2, Invp2, lvp2);
		}

		private void InAp1_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Ap1, InAp1, lAp1);
		}

		private void InAp2_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Ap2, InAp2, lAp2);
		}

		private void Ingamma_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref gamma, Ingamma, lgamma);
		}

		private void Inpq_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref pq, Inpq, lpq, 1);
		}

		private void InN_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref N, InN, lN, 1);
		}

		private void InMv_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref Mv, InMv, lMv, 1);
		}

		private void Input_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevForm.Show();
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

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
