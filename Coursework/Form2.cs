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
using CreateFiles;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

namespace Coursework
{
	public partial class Form2 : Form
	{
		Form1 prevForm;

		MatlabFuncs funcs;

		float Um, Vm, du, dv, u, v, a, Tc, up1,
			up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H;

		int N, Mu, Mv, pq, M;

		public Form2(Form1 form, MatlabFuncs funcs, int N, int Mu, int Mv,
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
			M = Mu * Mv;

			InitializeComponent();

			log.Text = "Параметры симуляции определены";
			generateData.Visible = true;
			getData.Visible = true;
			saveData.Visible = false;
			generateMatrix.Visible = false;
			getMatrix.Visible = true;
			saveMatrix.Visible = false;
			generateL.Visible = false;
			getL.Visible = true;
			saveL.Visible = false;
			visualize.Visible = false;
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
				saveData.Visible = true;
				generateMatrix.Visible = true;
				getMatrix.Visible = true;
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
				saveMatrix.Visible = true;
				generateL.Visible = true;
				getL.Visible = true;
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
					res = funcs.CreateL(1, N, Mu, Mv, Um, Vm, du, dv,
					u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu);
				});

				progress.Visible = false;
				log.Text += $"\nРасчет статистики наблюдений закончен за "
					+ TimeFormat(double.Parse(res[0].ToString()));
				saveL.Visible = true;
				visualize.Visible = true;
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
					res = funcs.CreatePicture(1, N, Mu, Mv, Um, Vm, H);
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

		private void generateData_Click(object sender, EventArgs e)
		{
			BeginData();
		}

		private void generateMatrix_Click(object sender, EventArgs e)
		{
			BeginMatrix();
		}

		private void generateL_Click(object sender, EventArgs e)
		{
			BeginL();
		}

		private void visualize_Click(object sender, EventArgs e)
		{
			BeginVis();
		}

		private void getData_Click(object sender, EventArgs e)
		{
			log.Text += "\nДобавляем файлы наблюдений";

			if (OpenFile("Sx.txt", false, 0) && OpenFile("Sy.txt", false, 0)
				&& OpenFile("Ux.txt", false, 0) && OpenFile("Uy.txt", false, 0)
				&& OpenFile("YX.txt", true, M * N * pq) 
				&& OpenFile("YY.txt", true, M * N * pq))
			{
				log.Text += "\nФайлы наблюдений добавлены";
				generateMatrix.Visible = true;
			}
			else
			{
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void getMatrix_Click(object sender, EventArgs e)
		{
			log.Text += "\nДобавляем файлы матрицы";

			if (OpenFile("Rx.txt", true, M * M * pq) 
				&& OpenFile("Ry.txt", true, M * M * pq))
			{
				log.Text += "\nФайлы матрицы добавлены";
				generateL.Visible = true;
			}
			else
			{
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void getL_Click(object sender, EventArgs e)
		{
			log.Text += "\nДобавляем файл статистики";

			if (OpenFile("Lfile.txt", true, 9 * 9 * N / 9))
			{
				log.Text += "\nФайл статистики добавлен";
				visualize.Visible = true;
			}
			else
			{
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void saveData_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файлов наблюдений";

			SaveFile("Sx.txt");
			SaveFile("Sy.txt");
			SaveFile("Ux.txt");
			SaveFile("Uy.txt");
			SaveFile("YX.txt");
			SaveFile("YY.txt");

			log.Text += "\nСохранение файлов наблюдений закончено";
		}

		private void saveMatrix_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файлов матрицы";

			SaveFile("Rx.txt");
			SaveFile("Ry.txt");

			log.Text += "\nСохранение файлов матрицы закончено";
		}

		private void saveL_Click(object sender, EventArgs e)
		{
			log.Text += "\nНачинаем сохранение файла статистики";

			SaveFile("Lfile.txt");

			log.Text += "\nСохранение файлов статистики закончено";
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

				openFile.FileName = null;
				string path;

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

				saveFile.FileName = null;
				string path;

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
			double minutes = Math.Floor(Math.Floor((time - hours) / 60));
			double seconds = time - hours - minutes;

			string hrs = hours >= 10 ? $"{hours}" : $"0{hours}";
			string mts = minutes >= 10 ? $"{minutes}" : $"0{minutes}";
			string scs = seconds >= 10 ? $"{seconds}" : $"0{seconds}";

			return hrs + ":" + mts + ":" + scs;
		}

		private void formBack_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevForm.Show();
		}
	}
}
