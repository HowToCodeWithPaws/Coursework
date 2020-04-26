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

		float Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, _mu, H;

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
					" Начните заново, либо перейдите к другому шагу." + e.Message);
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
					" Начните заново, либо перейдите к другому шагу." + e.Message);
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
					" Начните заново, либо перейдите к другому шагу." + e.Message);
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
					" Начните заново, либо перейдите к другому шагу." + e.Message);
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
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				log.Text += "\nДобавляем файлы наблюдений";

				string pathSx, pathSy, pathUx, pathUy, pathYX, pathYY;
				pathSy = pathSx = pathUx = pathUy = pathYX = pathYY = "";

				MessageBox.Show("Вам нужно выбрать файл Sx");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathSx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Sx выбран. Теперь нужно выбрать файл Sy");

				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathSy = openFileInput.FileName;
				}

				MessageBox.Show("Файл Sy выбран. Теперь нужно выбрать файл Ux");

				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathUx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Ux выбран. Теперь нужно выбрать файл Uy");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathUy = openFileInput.FileName;
				}

				MessageBox.Show("Файл Uy выбран. Теперь нужно выбрать файл YX");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathYX = openFileInput.FileName;
				}

				MessageBox.Show("Файл YX выбран. Теперь нужно выбрать файл YY");

				if (openFileInput.ShowDialog()
					  == DialogResult.OK)
				{
					pathYY = openFileInput.FileName;
				}

				if (CheckData(pathYY) && CheckData(pathYX)
					&& CheckData(pathSx) && CheckData(pathSy)
					&& CheckData(pathUx) && CheckData(pathUy))
				{
					File.Copy(pathSx, "Sx.txt", true);
					File.Copy(pathSy, "Sy.txt", true);
					File.Copy(pathUx, "Ux.txt", true);
					File.Copy(pathUy, "Uy.txt", true);
					File.Copy(pathYX, "YX.txt", true);
					File.Copy(pathYY, "YY.txt", true);

					log.Text += "\nФайлы наблюдений добавлены";
					generateMatrix.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали файл.");

				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void getMatrix_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				log.Text += "\nДобавляем файлы матрицы";

				string pathRx, pathRy;
				pathRy = pathRx = "";

				MessageBox.Show("Вам нужно выбрать файл Rx");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathRx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Rx выбран. Теперь нужно выбрать файл Ry");

				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathRy = openFileInput.FileName;
				}

				if (CheckData(pathRx) && CheckData(pathRy))
				{
					File.Copy(pathRx, "Rx.txt", true);
					File.Copy(pathRy, "Ry.txt", true);

					log.Text += "\nФайлы матрицы добавлены";
					generateL.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали файл.");

				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void getL_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				log.Text += "\nДобавляем файл статистики";

				string pathL; ;
				pathL = "";

				MessageBox.Show("Вам нужно выбрать файл L");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathL = openFileInput.FileName;
				}

				if (CheckData(pathL))
				{
					File.Copy(pathL, "Lfile.txt", true);

					log.Text += "\nФайл статистики добавлен";
					visualize.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали файл.");

				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void saveData_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				log.Text += "\nСохраняем файлы наблюдений";

				string pathSx, pathSy, pathUx, pathUy, pathYX, pathYY;
				pathSy = pathSx = pathUx = pathUy = pathYX = pathYY = "";

				MessageBox.Show("Вам нужно выбрать, куда сохранить файл Sx");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathSx = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла Sx выбран. " +
					"Теперь нужно выбрать, куда сохранить файл Sy");

				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathSy = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла Sy выбран. " +
					"Теперь нужно выбрать, куда сохранить файл Ux");

				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathUx = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла Ux выбран." +
					" Теперь нужно выбрать, куда сохранить файл Uy");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathUy = openFileInput.FileName;
				}


				MessageBox.Show("Путь для файла Uy выбран." +
					" Теперь нужно выбрать, куда сохранить файл YX");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathYX = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла YX выбран." +
					" Теперь нужно выбрать, куда сохранить файл YY");

				if (openFileInput.ShowDialog()
					  == DialogResult.OK)
				{
					pathYY = openFileInput.FileName;
				}

				File.Copy("Sx.txt", pathSx, true);
				File.Copy("Sy.txt", pathSy, true);
				File.Copy("Ux.txt", pathUx, true);
				File.Copy("Uy.txt", pathUy, true);
				File.Copy("YX.txt", pathYX, true);
				File.Copy("YY.txt", pathYY, true);

				log.Text += "\nФайлы наблюдений сохранены";
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали путь для файла.");

				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
		}

		private void saveMatrix_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				log.Text += "\nСохраняем файлы матрицы";

				string pathRx, pathRy;
				pathRy = pathRx = "";

				MessageBox.Show("Вам нужно выбрать," +
					" куда сохранить файл Rx");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathRx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Rx выбран. " +
					"Теперь нужно выбрать, куда сохранить файл Ry");

				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathRy = openFileInput.FileName;
				}

				File.Copy("Rx.txt", pathRx, true);
				File.Copy("Ry.txt", pathRy, true);

				log.Text += "\nФайлы матрицы сохранены";
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали путь для файла.");

				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
		}

		private void saveL_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				log.Text += "\nСохраняем файл статистики";

				string pathL; ;
				pathL = "";

				MessageBox.Show("Вам нужно выбрать, куда сохранить файл L");

				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathL = openFileInput.FileName;
				}

				if (CheckData(pathL))
				{
					File.Copy("Lfile.txt", pathL, true);

					log.Text += "\nФайл статистики сохранен";
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не выбрали путь для файла.");

				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка: " + ex.Message);
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
		}

		//TODO
		public bool CheckData(string path)
		{
			return true;
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
