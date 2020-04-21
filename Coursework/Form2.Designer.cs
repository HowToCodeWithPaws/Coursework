namespace Coursework
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.generateMatrix = new System.Windows.Forms.Button();
			this.visualize = new System.Windows.Forms.Button();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.generateL = new System.Windows.Forms.Button();
			this.generateData = new System.Windows.Forms.Button();
			this.getData = new System.Windows.Forms.Button();
			this.openFileInput = new System.Windows.Forms.OpenFileDialog();
			this.getMatrix = new System.Windows.Forms.Button();
			this.getL = new System.Windows.Forms.Button();
			this.saveData = new System.Windows.Forms.Button();
			this.saveMatrix = new System.Windows.Forms.Button();
			this.saveL = new System.Windows.Forms.Button();
			this.log = new System.Windows.Forms.RichTextBox();
			this.formBack = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// generateMatrix
			// 
			this.generateMatrix.Location = new System.Drawing.Point(340, 165);
			this.generateMatrix.Name = "generateMatrix";
			this.generateMatrix.Size = new System.Drawing.Size(200, 85);
			this.generateMatrix.TabIndex = 1;
			this.generateMatrix.Text = "произвести расчет корреляционной матрицы";
			this.generateMatrix.UseVisualStyleBackColor = true;
			this.generateMatrix.Click += new System.EventHandler(this.generateMatrix_Click);
			// 
			// visualize
			// 
			this.visualize.Location = new System.Drawing.Point(340, 435);
			this.visualize.Name = "visualize";
			this.visualize.Size = new System.Drawing.Size(200, 85);
			this.visualize.TabIndex = 2;
			this.visualize.Text = "визуализировать полученные данные";
			this.visualize.UseVisualStyleBackColor = true;
			this.visualize.Visible = false;
			this.visualize.Click += new System.EventHandler(this.visualize_Click);
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(980, 497);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(200, 23);
			this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progress.TabIndex = 3;
			this.progress.Visible = false;
			// 
			// generateL
			// 
			this.generateL.Location = new System.Drawing.Point(340, 300);
			this.generateL.Name = "generateL";
			this.generateL.Size = new System.Drawing.Size(200, 85);
			this.generateL.TabIndex = 4;
			this.generateL.Text = "сгенерировать статистику наблюдений";
			this.generateL.UseVisualStyleBackColor = true;
			this.generateL.Visible = false;
			this.generateL.Click += new System.EventHandler(this.generateL_Click);
			// 
			// generateData
			// 
			this.generateData.Location = new System.Drawing.Point(340, 30);
			this.generateData.Name = "generateData";
			this.generateData.Size = new System.Drawing.Size(200, 85);
			this.generateData.TabIndex = 5;
			this.generateData.Text = "сгенерировать наблюдения";
			this.generateData.UseVisualStyleBackColor = true;
			this.generateData.Click += new System.EventHandler(this.generateData_Click);
			// 
			// getData
			// 
			this.getData.Location = new System.Drawing.Point(660, 30);
			this.getData.Name = "getData";
			this.getData.Size = new System.Drawing.Size(200, 85);
			this.getData.TabIndex = 6;
			this.getData.Text = "загрузить готовые файлы наблюдений";
			this.getData.UseVisualStyleBackColor = true;
			this.getData.Click += new System.EventHandler(this.getData_Click);
			// 
			// openFileInput
			// 
			this.openFileInput.DefaultExt = "txt";
			this.openFileInput.Filter = "TXT files (*.txt)|*.txt";
			// 
			// getMatrix
			// 
			this.getMatrix.Location = new System.Drawing.Point(660, 165);
			this.getMatrix.Name = "getMatrix";
			this.getMatrix.Size = new System.Drawing.Size(200, 85);
			this.getMatrix.TabIndex = 7;
			this.getMatrix.Text = "загрузить готовые файлы матрицы";
			this.getMatrix.UseVisualStyleBackColor = true;
			this.getMatrix.Click += new System.EventHandler(this.getMatrix_Click);
			// 
			// getL
			// 
			this.getL.Location = new System.Drawing.Point(660, 300);
			this.getL.Name = "getL";
			this.getL.Size = new System.Drawing.Size(200, 85);
			this.getL.TabIndex = 8;
			this.getL.Text = "загрузить готовый файл статистики наблюдений";
			this.getL.UseVisualStyleBackColor = true;
			this.getL.Click += new System.EventHandler(this.getL_Click);
			// 
			// saveData
			// 
			this.saveData.Location = new System.Drawing.Point(980, 30);
			this.saveData.Name = "saveData";
			this.saveData.Size = new System.Drawing.Size(200, 85);
			this.saveData.TabIndex = 9;
			this.saveData.Text = "сохранить файлы наблюдений";
			this.saveData.UseVisualStyleBackColor = true;
			this.saveData.Click += new System.EventHandler(this.saveData_Click);
			// 
			// saveMatrix
			// 
			this.saveMatrix.Location = new System.Drawing.Point(980, 165);
			this.saveMatrix.Name = "saveMatrix";
			this.saveMatrix.Size = new System.Drawing.Size(200, 85);
			this.saveMatrix.TabIndex = 10;
			this.saveMatrix.Text = "сохранить файлы матрицы";
			this.saveMatrix.UseVisualStyleBackColor = true;
			this.saveMatrix.Click += new System.EventHandler(this.saveMatrix_Click);
			// 
			// saveL
			// 
			this.saveL.Location = new System.Drawing.Point(980, 300);
			this.saveL.Name = "saveL";
			this.saveL.Size = new System.Drawing.Size(200, 85);
			this.saveL.TabIndex = 11;
			this.saveL.Text = "сохранить файл статистики наблюдений";
			this.saveL.UseVisualStyleBackColor = true;
			this.saveL.Click += new System.EventHandler(this.saveL_Click);
			// 
			// log
			// 
			this.log.Location = new System.Drawing.Point(25, 30);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(293, 490);
			this.log.TabIndex = 12;
			this.log.Text = "";
			// 
			// formBack
			// 
			this.formBack.Location = new System.Drawing.Point(980, 580);
			this.formBack.Name = "formBack";
			this.formBack.Size = new System.Drawing.Size(200, 85);
			this.formBack.TabIndex = 13;
			this.formBack.Text = "вернуться к предыдущей форме";
			this.formBack.UseVisualStyleBackColor = true;
			this.formBack.Click += new System.EventHandler(this.formBack_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1338, 740);
			this.Controls.Add(this.formBack);
			this.Controls.Add(this.log);
			this.Controls.Add(this.saveL);
			this.Controls.Add(this.saveMatrix);
			this.Controls.Add(this.saveData);
			this.Controls.Add(this.getL);
			this.Controls.Add(this.getMatrix);
			this.Controls.Add(this.getData);
			this.Controls.Add(this.generateData);
			this.Controls.Add(this.generateL);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.visualize);
			this.Controls.Add(this.generateMatrix);
			this.Name = "Form2";
			this.Text = "Form2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button generateMatrix;
		private System.Windows.Forms.Button visualize;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button generateL;
		private System.Windows.Forms.Button generateData;
		private System.Windows.Forms.Button getData;
		private System.Windows.Forms.OpenFileDialog openFileInput;
		private System.Windows.Forms.Button getMatrix;
		private System.Windows.Forms.Button getL;
		private System.Windows.Forms.Button saveData;
		private System.Windows.Forms.Button saveMatrix;
		private System.Windows.Forms.Button saveL;
		private System.Windows.Forms.RichTextBox log;
		private System.Windows.Forms.Button formBack;
	}
}