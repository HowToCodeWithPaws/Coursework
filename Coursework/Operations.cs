using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadarLib;
using System.Diagnostics;
using System.IO;
using MatlabFuncs;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

namespace Coursework
{
	public partial class Operations : Form
	{
		Color backColor = Color.FromArgb(46, 76, 86);
		Color panelColor = Color.FromArgb(89, 139, 155);
		Color hoverColor = Color.FromArgb(125, 167, 181);
		Color textColor = Color.FromArgb(160, 238, 230);

		Input prevForm;
		Homescreen homescreen;

		Funcs funcs;

		float Um, Vm, du, dv, u, v, a, Tc, up1,
			up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H;

		int N, Mu, Mv, pq, M;

		bool dataE, matrixE, statE;

		public Operations(Input form, Homescreen homescreen, Funcs funcs, int N, int Mu, int Mv,
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

			this.BackColor = backColor;
			panel.BackColor = panelColor;
			log.BackColor = backColor;
			log.ForeColor = textColor;

			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.FlatAppearance.MouseOverBackColor = hoverColor;
				b.ForeColor = textColor;
				//		b.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 138, 162);
			}
		}

		public async void BeginData()
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

				progress.Visible = false;
				log.Text += $"\nНаблюдения сгенерированы за "
					+ TimeFormat(double.Parse(res[0].ToString()));

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

		public async void BeginMatrix()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем вычисление корреляционной матрицы";

				RadarOperations test = new RadarOperations(pq, _mu, M, N);

				string res = "";

				await Task.Run(() => { res = test.Start(); });

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

		public async void BeginL()
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

				progress.Visible = false;
				log.Text += $"\nРасчет статистики наблюдений закончен за "
					+ TimeFormat(double.Parse(res[0].ToString()));
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

		public async void BeginVis()
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

				progress.Visible = false;
				log.Text += $"\nВизуализация закончена за "
					+ TimeFormat(double.Parse(res[0].ToString()));
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

		private void bGenData_Click(object sender, EventArgs e)
		{
			BeginData();
		}

		private void bGenMatrix_Click(object sender, EventArgs e)
		{
			BeginMatrix();
		}

		private void bGenStat_Click(object sender, EventArgs e)
		{
			BeginL();
		}

		private void bVisualize_Click(object sender, EventArgs e)
		{
			BeginVis();
		}

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

		private void bSaveMatrix_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файлов матрицы";
			progress.Visible = true;

			SaveFile("Rx.txt");
			SaveFile("Ry.txt");

			progress.Visible = false;
			log.Text += "\nСохранение файлов матрицы закончено";
		}

		private void bSaveStat_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файла статистики";
			progress.Visible = true;

			SaveFile("Lfile.txt");

			progress.Visible = false;
			log.Text += "\nСохранение файлов статистики закончено";
		}

		private void bBackToHomepage_Click(object sender, EventArgs e)
		{
			prevForm.Close();
			this.Close();
			homescreen.Show();
		}

		private void bBackToInput_Click(object sender, EventArgs e)
		{
			this.Close();
			prevForm.Show();
		}

		public bool CheckData(string path, bool checkLen, int expectedLen)
		{
			StreamReader filestr =
				new StreamReader(new FileStream(path, FileMode.Open));

			float num;
			int length = 0;

			while (true)
			{
				var t = NextWord(filestr);

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

		string NextWord(StreamReader s)
		{
			int c = s.Peek();

			while (c != -1 && Char.IsWhiteSpace(Convert.ToChar(c)))
			{
				s.Read();
				c = s.Peek();
			}

			if (c == -1) return "";

			StringBuilder b = new StringBuilder();

			while (c != -1 && !Char.IsWhiteSpace(Convert.ToChar(c)))
			{
				b.Append(Convert.ToChar(c));
				s.Read();
				c = s.Peek();
			}

			return b.ToString();
		}

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

		void Disable()
		{
			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.Enabled = false;
			}
		}

		public string TimeFormat(double time)
		{
			double hours = Math.Floor(time / 3600);
			double minutes = Math.Floor(Math.Floor((time - 3600 * hours) / 60));
			double seconds = time - 3600 * hours - 60 * minutes;

			string hrs = hours >= 10 ? $"{hours}" : $"0{hours}";
			string mts = minutes >= 10 ? $"{minutes}" : $"0{minutes}";
			string scs = seconds >= 10 ? $"{seconds}" : $"0{seconds}";

			return hrs + ":" + mts + ":" + scs;
		}
	}
}
