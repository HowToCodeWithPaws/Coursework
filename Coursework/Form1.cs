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
		string[] inputStrings;

		string inputPath = "";

		float Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, mu, H;
		int N, Mu, Mv, pq;

		public Form1()
		{
			System.Globalization.CultureInfo.CurrentCulture
				= new System.Globalization.CultureInfo("en-US", false);
			InitializeComponent();
			Begin();
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
			mu = 3000; H = 7;
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
			l_mu.Text = $"mu = {mu}";
			lH.Text = $"H = {H}";
			lpq.Text = $"pq = {pq}";

			InN.Text = N.ToString();
			InMu.Text = Mu.ToString();
			InMv.Text = Mu.ToString();
			InUm.Text = Um.ToString();
			InVm.Text = Vm.ToString();
			InDu.Text = dv.ToString();
			InDv.Text = dv.ToString();
			InU.Text = u.ToString();
			InV.Text = v.ToString();
			InTc.Text = Tc.ToString();
			InA.Text = a.ToString();
			InUp1.Text = up1.ToString();
			InUp2.Text = up2.ToString();
			InVp1.Text = vp1.ToString();
			InVp2.Text = vp2.ToString();
			InAp1.Text = Ap1.ToString();
			InAp2.Text = Ap2.ToString();
			InGamma.Text = gamma.ToString();
			In_Mu.Text = mu.ToString();
			InH.Text = H.ToString();
			InPq.Text = pq.ToString();

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
				int number;
				float num;

				if (!CheckValidityI(inputStrings[0], out number))
				{
					N = number;
					lN.Text = $"N = {N}";
					InN.Text = N.ToString();
				}
				if (!CheckValidityI(inputStrings[1], out number))
				{
					Mu = number;
					lMu.Text = $"Mu = {Mu}";
					InMu.Text = Mu.ToString();
				}
				if (!CheckValidityI(inputStrings[2], out number))
				{
					Mv = number;
					lMv.Text = $"Mv = {Mv}";
					InMv.Text = Mv.ToString();
				}
				if (!CheckValidityF(inputStrings[3], out num))
				{
					Um = num;
					lUm.Text = $"Um = {Um}";
					InUm.Text = Um.ToString();
				}
				if (!CheckValidityF(inputStrings[4], out num))
				{
					Vm = num;
					lVm.Text = $"Vm = {Vm}";
					InVm.Text = Vm.ToString();
				}
				if (!CheckValidityF(inputStrings[5], out num))
				{
					du = num;
					ldu.Text = $"du = {dv}";
					InDu.Text = dv.ToString();
				}
				if (!CheckValidityF(inputStrings[6], out num))
				{
					dv = num;
					ldv.Text = $"dv = {dv}";
					InDv.Text = dv.ToString();
				}
				if (!CheckValidityF(inputStrings[7], out num))
				{
					u = num;
					lu.Text = $"u = {u}";
					InU.Text = u.ToString();
				}
				if (!CheckValidityF(inputStrings[8], out num))
				{
					v = num;
					lv.Text = $"v = {v}";
					InV.Text = v.ToString();
				}
				if (!CheckValidityF(inputStrings[9], out num))
				{
					a = num;
					la.Text = $"a = {a}";
					InA.Text = a.ToString();
				}
				if (!CheckValidityF(inputStrings[10], out num))
				{
					Tc = num;
					lTc.Text = $"Tc = {Tc}";
					InTc.Text = Tc.ToString();
				}
				if (!CheckValidityF(inputStrings[11], out num))
				{
					up1 = num;
					lup1.Text = $"up1 = {up1}";
					InUp1.Text = up1.ToString();
				}
				if (!CheckValidityF(inputStrings[12], out num))
				{
					up2 = num;
					lup2.Text = $"up2 = {up2}";
					InUp2.Text = up2.ToString();
				}
				if (!CheckValidityF(inputStrings[13], out num))
				{
					vp1 = num;
					lvp1.Text = $"vp1 = {vp1}";
					InVp1.Text = vp1.ToString();
				}
				if (!CheckValidityF(inputStrings[14], out num))
				{
					vp2 = num;
					lvp2.Text = $"vp2 = {vp2}";
					InVp2.Text = vp2.ToString();
				}
				if (!CheckValidityF(inputStrings[15], out num))
				{
					Ap1 = num;
					lAp1.Text = $"Ap1 = {Ap1}";
					InAp1.Text = Ap1.ToString();
				}
				if (!CheckValidityF(inputStrings[16], out num))
				{
					Ap2 = num;
					lAp2.Text = $"Ap2 = {Ap2}";
					InAp2.Text = Ap2.ToString();
				}
				if (!CheckValidityF(inputStrings[17], out num))
				{
					gamma = num;
					lgamma.Text = $"gamma = {gamma}";
					InGamma.Text = gamma.ToString();
				}
				if (!CheckValidityF(inputStrings[18], out num))
				{
					mu = num;
					l_mu.Text = $"mu = {mu}";
					In_Mu.Text = mu.ToString();
				}
				if (!CheckValidityF(inputStrings[19], out num))
				{
					H = num;
					lH.Text = $"H = {H}";
					InH.Text = H.ToString();
				}
				if (!CheckValidityI(inputStrings[20], out number))
				{
					pq = number;
					lpq.Text = $"pq = {pq}";
					InPq.Text = pq.ToString();
				}
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
				Ap1.ToString(),Ap2.ToString(), gamma.ToString(), mu.ToString(), H.ToString(),
				pq.ToString() });
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
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
				MessageBox.Show(ex.Message);
			}
			finally { MessageBox.Show("Запись в файл окончена."); }
		}
		private void inputUpload_Click(object sender, EventArgs e)
		{
			if (openFileInput.ShowDialog()
				== DialogResult.OK)
			{
				inputPath = openFileInput.FileName;
			}

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				inputStrings = File.ReadAllLines(inputPath);
				GetFromFile();
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
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
				MessageBox.Show(ex.Message);
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
				Ap1.ToString(),Ap2.ToString(), gamma.ToString(), mu.ToString(), H.ToString(),
				pq.ToString() });
			}
			catch (Exception ex)
			{
				MessageBox.Show("trouble" + ex.Message);
			}


			this.Hide();

			// Создание новой формы на основе
			// текущей формы 
			new Form2(this, N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1,
				up2, vp1, vp2, Ap1, Ap2, gamma, mu, H, pq, false).Show();

			// Вызов метода, приводящего форму
			// к начальному виду.
			Begin();
		}

		private void proceedWithData_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Для того, чтобы продолжить с уже сгенерированными" +
				" данными, вам нужно иметь файл с параметрами симуляции в требуемом" +
	"формате. Для начала вы должны выбрать его.");

			if (openFileInput.ShowDialog()
				   == DialogResult.OK)
			{
				inputPath = openFileInput.FileName;
			}

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				inputStrings = File.ReadAllLines(inputPath);
				GetFromFile();

				string pathSx, pathSy, pathUx, pathUy, pathYX, pathYY;
				pathSy = pathSx = pathUx = pathUy = pathYX = pathYY = "";

				MessageBox.Show("Файл с параметрами загружен. Теперь нужно выбрать файл Sx");
				// File Sx
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathSx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Sx. Теперь нужно выбрать файл Sy");
				// File Sy
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathSy = openFileInput.FileName;
				}

				MessageBox.Show("Файл Sy. Теперь нужно выбрать файл Ux");
				// File Ux
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathUx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Ux. Теперь нужно выбрать файл Uy");
				// File Uy				
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathUy = openFileInput.FileName;
				}


				MessageBox.Show("Файл Uy. Теперь нужно выбрать файл YX");
				// File YX
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathYX = openFileInput.FileName;
				}

				MessageBox.Show("Файл YX. Теперь нужно выбрать файл YY");
				// File YY
				if (openFileInput.ShowDialog()
					  == DialogResult.OK)
				{
					pathYY = openFileInput.FileName;
				}

				if (CheckData(pathYY) && CheckData(pathYX)
					&& CheckData(pathSx) && CheckData(pathSy)
					&& CheckData(pathUx) && CheckData(pathUy))
				{
					File.WriteAllLines("Input.txt", new string[]
					{ N.ToString(), Mu.ToString(), Mv.ToString(),Um.ToString(), Vm.ToString(),
				du.ToString(), dv.ToString(),  u.ToString(), v.ToString(), a.ToString(),
				Tc.ToString(), up1.ToString(), up2.ToString(), vp1.ToString(),vp2.ToString(),
				Ap1.ToString(),Ap2.ToString(), gamma.ToString(), mu.ToString(), H.ToString(),
				pq.ToString() });
					File.Copy(pathSx, "Sx.txt");
					File.Copy(pathSy, "Sy.txt");
					File.Copy(pathUx, "Ux.txt");
					File.Copy(pathUy, "Uy.txt");
					File.Copy(pathYX, "YX.txt");
					File.Copy(pathYY, "YY.txt");

					this.Hide();

					// Создание новой формы на основе
					// текущей формы 
					new Form2(this, N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1,
						up2, vp1, vp2, Ap1, Ap2, gamma, mu, H, pq, true).Show();

					// Вызов метода, приводящего форму
					// к начальному виду.
					Begin();
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
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
				MessageBox.Show(ex.Message);
			}
		}

		public bool CheckData(string path)
		{
			return true;
		}

		public bool CheckValidityF(string newText, out float number,
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

			// Если вводится число меньше 0 либо больше
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

		public bool CheckValidityI(string newText, out int number,
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

			// Если вводится число меньше 0 либо больше
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

		private void InMu_TextChanged(object sender, EventArgs e)
		{
			int num;

			if (!CheckValidityI(InMu.Text, out num))
			{
				Mu = num;
				lMu.Text = $"Mu = {Mu}";
			}
			else
			{
				InMu.Text = Mu.ToString();
			}
		}

		private void InMv_TextChanged(object sender, EventArgs e)
		{
			int num;

			if (!CheckValidityI(InMv.Text, out num))
			{
				Mv = num;
				lMv.Text = $"Mv = {Mv}";
			}
			else
			{
				InMv.Text = Mv.ToString();
			}
		}

		private void InN_TextChanged(object sender, EventArgs e)
		{
			int num;

			if (!CheckValidityI(InN.Text, out num))
			{
				N = num;
				lN.Text = $"N = {N}";
			}
			else
			{
				InN.Text = N.ToString();
			}
		}

		private void InUm_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InUm.Text, out num))
			{
				Um = num;
				lUm.Text = $"Um = {Um}";
			}
			else
			{
				InUm.Text = Um.ToString();
			}
		}

		private void InVm_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InVm.Text, out num))
			{
				Vm = num;
				lVm.Text = $"Vm = {Vm}";
			}
			else
			{
				InVm.Text = Vm.ToString();
			}
		}

		private void InDu_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InDu.Text, out num))
			{
				du = num;
				ldu.Text = $"du = {du}";
			}
			else
			{
				InDu.Text = du.ToString();
			}
		}

		private void InDv_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InDv.Text, out num))
			{
				dv = num;
				ldv.Text = $"dv = {dv}";
			}
			else
			{
				InDv.Text = dv.ToString();
			}
		}

		private void InU_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InU.Text, out num))
			{
				u = num;
				lu.Text = $"u = {u}";
			}
			else
			{
				InU.Text = u.ToString();
			}
		}

		private void InV_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InV.Text, out num))
			{
				v = num;
				lv.Text = $"v = {v}";
			}
			else
			{
				InV.Text = v.ToString();
			}
		}

		private void InA_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InA.Text, out num))
			{
				a = num;
				la.Text = $"a = {a}";
			}
			else
			{
				InA.Text = a.ToString();
			}
		}

		private void InTc_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InTc.Text, out num))
			{
				Tc = num;
				lTc.Text = $"Tc = {Tc}";
			}
			else
			{
				InTc.Text = Tc.ToString();
			}
		}

		private void InUp1_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InUp1.Text, out num))
			{
				up1 = num;
				lup1.Text = $"up1 = {up1}";
			}
			else
			{
				InUp1.Text = up1.ToString();
			}
		}

		private void InUp2_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InUp2.Text, out num))
			{
				up2 = num;
				lup2.Text = $"up2 = {up2}";
			}
			else
			{
				InUp2.Text = up2.ToString();
			}
		}

		private void InVp1_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InVp1.Text, out num))
			{
				vp1 = num;
				lvp1.Text = $"vp1 = {vp1}";
			}
			else
			{
				InVp1.Text = vp1.ToString();
			}
		}

		private void InVp2_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InVp2.Text, out num))
			{
				vp2 = num;
				lvp2.Text = $"vp2 = {vp2}";
			}
			else
			{
				InVp2.Text = vp2.ToString();
			}
		}

		private void InAp1_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InAp1.Text, out num))
			{
				Ap1 = num;
				lAp1.Text = $"Ap1 = {Ap1}";
			}
			else
			{
				InAp1.Text = Ap1.ToString();
			}
		}

		private void InAp2_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InAp2.Text, out num))
			{
				Ap2 = num;
				lAp2.Text = $"Ap2 = {Ap2}";
			}
			else
			{
				InAp2.Text = Ap2.ToString();
			}
		}

		private void InGamma_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InGamma.Text, out num))
			{
				gamma = num;
				lgamma.Text = $"gamma = {gamma}";
			}
			else
			{
				InGamma.Text = gamma.ToString();
			}
		}

		private void In_Mu_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(In_Mu.Text, out num))
			{
				mu = num;
				l_mu.Text = $"mu = {mu}";
			}
			else
			{
				In_Mu.Text = mu.ToString();
			}
		}

		private void InH_TextChanged(object sender, EventArgs e)
		{
			float num;

			if (!CheckValidityF(InH.Text, out num))
			{
				H = num;
				lH.Text = $"H = {H}";
			}
			else
			{
				InH.Text = H.ToString();
			}
		}

		private void InPq_TextChanged(object sender, EventArgs e)
		{
			int num;

			if (!CheckValidityI(InPq.Text, out num))
			{
				pq = num;
				lpq.Text = $"pq = {pq}";
			}
			else
			{
				InPq.Text = pq.ToString();
			}
		}

	}
}
