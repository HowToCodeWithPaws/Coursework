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
	public partial class Form1 : Form
	{
		CreateFiles.MatlabFuncs funcs = new CreateFiles.MatlabFuncs();

		string[] inputStrings;

		string inputPath = "";

		float Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H;

		int N, Mu, Mv, pq;

		public Form1()
		{
			System.Globalization.CultureInfo.CurrentCulture
				= new System.Globalization.CultureInfo("en-US", false);
			InitializeComponent();
			Begin();
		}

		private void info_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Это программа для симуляции и визуализации работы" +
				" радиолокатора. Она разделена на несколько стадий:" +
				" задание параметров симуляции, создание наблюдений, расчет " +
				"корреляционной матрицы, формирование статистики и визуализация." +
				" На всех этапах кроме последнего генерируются файлы, которые" +
				" можно сохранить в какое-то удобное место, кроме того, этап можно" +
				"пропустить при условии, что у вас есть файлы, которые должны быть" +
				" сформированы на пропускаемом этапе и файл с параметрами симуляции." +
				" Если файлы не будут согласованы друг с другом или с параметрами" +
				" симуляции, будет выведено сообщение об ошибке, и вы сможете загрузить" +
				" другие файлы, либо сгенерировать их. Также при противоречивых или " +
				"некорректных для симуляции параметрах могут быть получены некорректные" +
				" результаты, но всегда есть возможность задать их заново и повторить" +
				" работу программы. Рекомендуется не задавать слишком большие числа," +
				" потому что тогда программа может работать чудовищно долго.");
		}

		public void Begin()
		{
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

			toolTipN.SetToolTip(lN, "КОЛИЧЕСТВО ВЕКТОРОВ НАБЛЮДЕНИЙ, ПО КОТОРЫМ " +
				"ФОРМИРУЕТСЯ СТАТИСТИКА");
			toolTipMu.SetToolTip(lMu, "КОЛИЧЕСТВО ПРИЕМНЫХ ЭЛЕМЕНТОВ ПО ДЛИНЕ");
			toolTipMv.SetToolTip(lMv, "КОЛИЧЕСТВО ПРИЕМНЫХ ЭЛЕМЕНТОВ ПО ШИРИНЕ");
			toolTipUm.SetToolTip(lUm, "ШИРИНА ДН МОДУЛЯ ПО ОДНОЙ ОСИ");
			toolTipVm.SetToolTip(lVm, "ШИРИНА ДН МОДУЛЯ ПО ДРУГОЙ ОСИ");
			toolTipDu.SetToolTip(ldu, "СДВИГ ДО ЦЕНТРА СЕКТОРА ПО ОДНОЙ КООРДИНАТЕ");
			toolTipDv.SetToolTip(ldv, "СДВИГ ДО ЦЕНТРА СЕКТОРА ПО ДРУГОЙ КООРДИНАТЕ");
			toolTipU.SetToolTip(lu, "ПОЛОЖЕНИЕ ЦЕЛИ ПО ОДНОЙ КООРДИНАТЕ");
			toolTipV.SetToolTip(lv, "ПОЛОЖЕНИЕ ЦЕЛИ ПО ДРКГОЙ КООРДИНАТЕ");
			toolTipA.SetToolTip(la, "МОЩНОСТЬ СИГНАЛА");
			toolTipTc.SetToolTip(lTc, "НАЧАЛО ПРИХОДА СИГНАЛА");
			toolTipVp1.SetToolTip(lvp1, "ПОЛОЖЕНИЕ ПОМЕХ ПО ДРУГОЙ КООРДИНАТЕ");
			toolTipVp2.SetToolTip(lvp2, "ПОЛОЖЕНИЕ ПОМЕХ ПО ДРУГОЙ КООРДИНАТЕ");
			toolTipUp1.SetToolTip(lup1, "ПОЛОЖЕНИЕ ПОМЕХ ПО ОДНОЙ КООРДИНАТЕ");
			toolTipUp2.SetToolTip(lup2, "ПОЛОЖЕНИЕ ПОМЕХ ПО ОДНОЙ КООРДИНАТЕ");
			toolTipAp1.SetToolTip(lAp1, "МОЩНОСТЬ ПОМЕХ");
			toolTipAp2.SetToolTip(lAp2, "МОЩНОСТЬ ПОМЕХ");
			toolTipGamma.SetToolTip(lgamma, "ПАРАМЕТР ГАММА");
			toolTip_Mu.SetToolTip(l_mu, "ПАРАМЕТР РЕГУЛЯРИЗАЦИИ МАТРИЦЫ МЮ");
			toolTipH.SetToolTip(lH, "ПОРОГОВОЕ ЗНАЧЕНИЕ МОЩНОСТИ СИГНАЛА");
			toolTipPq.SetToolTip(lpq, "ПАРАМЕТР ПКУ");
		}

		public void GetFromFile()
		{
			try
			{
				ChangeValueFromFileI(ref N, inputStrings[0], InN, lN);

				ChangeValueFromFileI(ref Mu, inputStrings[1], InMu, lMu);

				ChangeValueFromFileI(ref Mv, inputStrings[2], InMv, lMv);

				ChangeValueFromFileF(ref Um, inputStrings[3], InUm, lUm);

				ChangeValueFromFileF(ref Vm, inputStrings[4], InVm, lVm);

				ChangeValueFromFileF(ref du, inputStrings[5], Indu, ldu);

				ChangeValueFromFileF(ref dv, inputStrings[6], Indv, ldv);

				ChangeValueFromFileF(ref u, inputStrings[7], Inu, lu);

				ChangeValueFromFileF(ref v, inputStrings[8], Inv, lv);

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

				ChangeValueFromFileF(ref H, inputStrings[19], InH, lH);

				ChangeValueFromFileI(ref pq, inputStrings[20], Inpq, lpq);

			}
			catch (IndexOutOfRangeException)
			{
				MessageBox.Show("Информации в файле не хватает, но поля по максимуму заполнены");
			}
			finally { MessageBox.Show("Все корректные данные добавлены"); }
		}

		private void inputDownload_Click(object sender, EventArgs e)
		{
			string path = "";

			if (openFileInput.ShowDialog()
				== DialogResult.OK)
			{
				path = openFileInput.FileName;
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
		private void inputUpload_Click(object sender, EventArgs e)
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

		private void proceed_Click(object sender, EventArgs e)
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
			new Form2(this, funcs, N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc,
				up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H, pq).Show();

			// Вызов метода, приводящего форму
			// к начальному виду.
			Begin();
		}

		void ChangeValueFromFileI(ref int value, string newvalue,
			TextBox Invalue, Label lvalue)
		{
			int num;

			if (!CheckValidityFailedI(newvalue, out num))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
				Invalue.Text = value.ToString();
			}
		}

		void ChangeValueFromFileF(ref float value, string newvalue,
			TextBox Invalue, Label lvalue)
		{
			float num;

			if (!CheckValidityFailedF(newvalue, out num))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
				Invalue.Text = value.ToString();
			}
		}

		void ChangeValueI(ref int value, TextBox Invalue, Label lvalue)
		{
			int num;

			if (!CheckValidityFailedI(Invalue.Text, out num))
			{
				value = num;
				lvalue.Text = $"{lvalue.Name.Substring(1)} = {value}";
			}

			else
			{
				Invalue.Text = value.ToString();
			}
		}

		void ChangeValueF(ref float value, TextBox Invalue, Label lvalue)
		{
			float num;

			if (!CheckValidityFailedF(Invalue.Text, out num))
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
			float min = float.MinValue, float max = float.MaxValue)
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
			int min = int.MinValue, int max = int.MaxValue)
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
			ChangeValueI(ref Mu, InMu, lMu);
		}
		private void In_mu_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref _mu, In_mu, l_mu);
		}

		private void InUm_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Um, InUm, lUm);
		}

		private void InVm_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref Vm, InVm, lVm);
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
			ChangeValueF(ref u, Inu, lu);
		}

		private void Inv_Leave(object sender, EventArgs e)
		{
			ChangeValueF(ref v, Inv, lv);
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
			ChangeValueF(ref H, InH, lH);
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
			ChangeValueI(ref pq, Inpq, lpq);
		}

		private void InN_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref N, InN, lN);
		}

		private void InMv_Leave(object sender, EventArgs e)
		{
			ChangeValueI(ref Mv, InMv, lMv);
		}
	}
}
