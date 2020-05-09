namespace Coursework
{
	partial class Operations
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
			this.components = new System.ComponentModel.Container();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.log = new System.Windows.Forms.RichTextBox();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.panel = new System.Windows.Forms.Panel();
			this.bBackToInput = new System.Windows.Forms.Button();
			this.bSaveMatrix = new System.Windows.Forms.Button();
			this.bSaveStat = new System.Windows.Forms.Button();
			this.bGetMatrix = new System.Windows.Forms.Button();
			this.bGetStat = new System.Windows.Forms.Button();
			this.bGenMatrix = new System.Windows.Forms.Button();
			this.bGenStat = new System.Windows.Forms.Button();
			this.bSaveData = new System.Windows.Forms.Button();
			this.bGetData = new System.Windows.Forms.Button();
			this.bGenData = new System.Windows.Forms.Button();
			this.bBackToHomepage = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.bVisualize = new System.Windows.Forms.Button();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// progress
			// 
			this.progress.ForeColor = System.Drawing.Color.Blue;
			this.progress.Location = new System.Drawing.Point(35, 743);
			this.progress.Margin = new System.Windows.Forms.Padding(1);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(688, 38);
			this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progress.TabIndex = 3;
			this.progress.Visible = false;
			// 
			// openFile
			// 
			this.openFile.DefaultExt = "txt";
			this.openFile.Filter = "TXT files (*.txt)|*.txt";
			// 
			// log
			// 
			this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.log.Font = new System.Drawing.Font("Century Gothic", 10F);
			this.log.Location = new System.Drawing.Point(35, 38);
			this.log.Name = "log";
			this.log.ReadOnly = true;
			this.log.Size = new System.Drawing.Size(688, 668);
			this.log.TabIndex = 12;
			this.log.Text = "";
			// 
			// saveFile
			// 
			this.saveFile.DefaultExt = "txt";
			this.saveFile.Filter = "TXT files (*.txt)|*.txt";
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel.Controls.Add(this.bBackToInput);
			this.panel.Controls.Add(this.bVisualize);
			this.panel.Controls.Add(this.bSaveMatrix);
			this.panel.Controls.Add(this.bSaveStat);
			this.panel.Controls.Add(this.bGetMatrix);
			this.panel.Controls.Add(this.bGetStat);
			this.panel.Controls.Add(this.bGenMatrix);
			this.panel.Controls.Add(this.bGenStat);
			this.panel.Controls.Add(this.bSaveData);
			this.panel.Controls.Add(this.bGetData);
			this.panel.Controls.Add(this.bGenData);
			this.panel.Controls.Add(this.bBackToHomepage);
			this.panel.Location = new System.Drawing.Point(760, 0);
			this.panel.Margin = new System.Windows.Forms.Padding(0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(600, 800);
			this.panel.TabIndex = 53;
			// 
			// bBackToInput
			// 
			this.bBackToInput.BackColor = System.Drawing.Color.Transparent;
			this.bBackToInput.FlatAppearance.BorderSize = 0;
			this.bBackToInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bBackToInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bBackToInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBackToInput.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bBackToInput.Location = new System.Drawing.Point(200, 600);
			this.bBackToInput.Margin = new System.Windows.Forms.Padding(0);
			this.bBackToInput.Name = "bBackToInput";
			this.bBackToInput.Size = new System.Drawing.Size(200, 200);
			this.bBackToInput.TabIndex = 54;
			this.bBackToInput.Text = "Вернуться к параметрам симуляции";
			this.bBackToInput.UseVisualStyleBackColor = false;
			this.bBackToInput.Click += new System.EventHandler(this.bBackToInput_Click);
			// 
			// bSaveMatrix
			// 
			this.bSaveMatrix.BackColor = System.Drawing.Color.Transparent;
			this.bSaveMatrix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bSaveMatrix.FlatAppearance.BorderSize = 0;
			this.bSaveMatrix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bSaveMatrix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bSaveMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bSaveMatrix.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bSaveMatrix.Location = new System.Drawing.Point(400, 200);
			this.bSaveMatrix.Margin = new System.Windows.Forms.Padding(0);
			this.bSaveMatrix.Name = "bSaveMatrix";
			this.bSaveMatrix.Size = new System.Drawing.Size(200, 200);
			this.bSaveMatrix.TabIndex = 10;
			this.bSaveMatrix.Text = "Сохранить файлы матрицы";
			this.bSaveMatrix.UseVisualStyleBackColor = false;
			this.bSaveMatrix.Click += new System.EventHandler(this.bSaveMatrix_Click);
			// 
			// bSaveStat
			// 
			this.bSaveStat.BackColor = System.Drawing.Color.Transparent;
			this.bSaveStat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bSaveStat.FlatAppearance.BorderSize = 0;
			this.bSaveStat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bSaveStat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bSaveStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bSaveStat.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bSaveStat.Location = new System.Drawing.Point(400, 400);
			this.bSaveStat.Margin = new System.Windows.Forms.Padding(0);
			this.bSaveStat.Name = "bSaveStat";
			this.bSaveStat.Size = new System.Drawing.Size(200, 200);
			this.bSaveStat.TabIndex = 9;
			this.bSaveStat.Text = "Сохранить файл статистики наблюдений";
			this.bSaveStat.UseVisualStyleBackColor = false;
			this.bSaveStat.Click += new System.EventHandler(this.bSaveStat_Click);
			// 
			// bGetMatrix
			// 
			this.bGetMatrix.BackColor = System.Drawing.Color.Transparent;
			this.bGetMatrix.FlatAppearance.BorderSize = 0;
			this.bGetMatrix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bGetMatrix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bGetMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bGetMatrix.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGetMatrix.Location = new System.Drawing.Point(200, 200);
			this.bGetMatrix.Margin = new System.Windows.Forms.Padding(0);
			this.bGetMatrix.Name = "bGetMatrix";
			this.bGetMatrix.Size = new System.Drawing.Size(200, 200);
			this.bGetMatrix.TabIndex = 8;
			this.bGetMatrix.Text = "Загрузить файлы матрицы";
			this.bGetMatrix.UseVisualStyleBackColor = false;
			this.bGetMatrix.Click += new System.EventHandler(this.bGetMatrix_Click);
			// 
			// bGetStat
			// 
			this.bGetStat.BackColor = System.Drawing.Color.Transparent;
			this.bGetStat.FlatAppearance.BorderSize = 0;
			this.bGetStat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bGetStat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bGetStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bGetStat.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGetStat.Location = new System.Drawing.Point(200, 400);
			this.bGetStat.Margin = new System.Windows.Forms.Padding(0);
			this.bGetStat.Name = "bGetStat";
			this.bGetStat.Size = new System.Drawing.Size(200, 200);
			this.bGetStat.TabIndex = 7;
			this.bGetStat.Text = "Загрузить и визуализировать файл статистики наблюдений";
			this.bGetStat.UseVisualStyleBackColor = false;
			this.bGetStat.Click += new System.EventHandler(this.bGetStat_Click);
			// 
			// bGenMatrix
			// 
			this.bGenMatrix.BackColor = System.Drawing.Color.Transparent;
			this.bGenMatrix.FlatAppearance.BorderSize = 0;
			this.bGenMatrix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bGenMatrix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bGenMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bGenMatrix.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGenMatrix.Location = new System.Drawing.Point(0, 200);
			this.bGenMatrix.Margin = new System.Windows.Forms.Padding(0);
			this.bGenMatrix.Name = "bGenMatrix";
			this.bGenMatrix.Size = new System.Drawing.Size(200, 200);
			this.bGenMatrix.TabIndex = 6;
			this.bGenMatrix.Text = "Произвести расчет корреляционной матрицы";
			this.bGenMatrix.UseVisualStyleBackColor = false;
			this.bGenMatrix.Click += new System.EventHandler(this.bGenMatrix_Click);
			// 
			// bGenStat
			// 
			this.bGenStat.BackColor = System.Drawing.Color.Transparent;
			this.bGenStat.FlatAppearance.BorderSize = 0;
			this.bGenStat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bGenStat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bGenStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bGenStat.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGenStat.Location = new System.Drawing.Point(0, 400);
			this.bGenStat.Margin = new System.Windows.Forms.Padding(0);
			this.bGenStat.Name = "bGenStat";
			this.bGenStat.Size = new System.Drawing.Size(200, 200);
			this.bGenStat.TabIndex = 5;
			this.bGenStat.Text = "Сгенерировать и визуализировать статистику наблюдений";
			this.bGenStat.UseVisualStyleBackColor = false;
			this.bGenStat.Click += new System.EventHandler(this.bGenStat_Click);
			// 
			// bSaveData
			// 
			this.bSaveData.BackColor = System.Drawing.Color.Transparent;
			this.bSaveData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bSaveData.FlatAppearance.BorderSize = 0;
			this.bSaveData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bSaveData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bSaveData.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bSaveData.Location = new System.Drawing.Point(400, 0);
			this.bSaveData.Margin = new System.Windows.Forms.Padding(0);
			this.bSaveData.Name = "bSaveData";
			this.bSaveData.Size = new System.Drawing.Size(200, 200);
			this.bSaveData.TabIndex = 4;
			this.bSaveData.Text = "Сохранить файлы наблюдений";
			this.bSaveData.UseVisualStyleBackColor = false;
			this.bSaveData.Click += new System.EventHandler(this.bSaveData_Click);
			// 
			// bGetData
			// 
			this.bGetData.BackColor = System.Drawing.Color.Transparent;
			this.bGetData.FlatAppearance.BorderSize = 0;
			this.bGetData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bGetData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bGetData.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGetData.Location = new System.Drawing.Point(200, 0);
			this.bGetData.Margin = new System.Windows.Forms.Padding(0);
			this.bGetData.Name = "bGetData";
			this.bGetData.Size = new System.Drawing.Size(200, 200);
			this.bGetData.TabIndex = 3;
			this.bGetData.Text = "Загрузить файлы наблюдений";
			this.bGetData.UseVisualStyleBackColor = false;
			this.bGetData.Click += new System.EventHandler(this.bGetData_Click);
			// 
			// bGenData
			// 
			this.bGenData.BackColor = System.Drawing.Color.Transparent;
			this.bGenData.FlatAppearance.BorderSize = 0;
			this.bGenData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bGenData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bGenData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bGenData.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGenData.Location = new System.Drawing.Point(0, 0);
			this.bGenData.Margin = new System.Windows.Forms.Padding(0);
			this.bGenData.Name = "bGenData";
			this.bGenData.Size = new System.Drawing.Size(200, 200);
			this.bGenData.TabIndex = 2;
			this.bGenData.Text = "Сгенерировать наблюдения";
			this.bGenData.UseVisualStyleBackColor = false;
			this.bGenData.Click += new System.EventHandler(this.bGenData_Click);
			// 
			// bBackToHomepage
			// 
			this.bBackToHomepage.BackColor = System.Drawing.Color.Transparent;
			this.bBackToHomepage.FlatAppearance.BorderSize = 0;
			this.bBackToHomepage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bBackToHomepage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bBackToHomepage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBackToHomepage.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bBackToHomepage.Location = new System.Drawing.Point(400, 600);
			this.bBackToHomepage.Margin = new System.Windows.Forms.Padding(0);
			this.bBackToHomepage.Name = "bBackToHomepage";
			this.bBackToHomepage.Size = new System.Drawing.Size(200, 200);
			this.bBackToHomepage.TabIndex = 1;
			this.bBackToHomepage.Text = "Вернуться на главый экран";
			this.bBackToHomepage.UseVisualStyleBackColor = false;
			this.bBackToHomepage.Click += new System.EventHandler(this.bBackToHomepage_Click);
			// 
			// bVisualize
			// 
			this.bVisualize.BackColor = System.Drawing.Color.Transparent;
			this.bVisualize.FlatAppearance.BorderSize = 0;
			this.bVisualize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bVisualize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bVisualize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bVisualize.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bVisualize.Location = new System.Drawing.Point(0, 600);
			this.bVisualize.Margin = new System.Windows.Forms.Padding(0);
			this.bVisualize.Name = "bVisualize";
			this.bVisualize.Size = new System.Drawing.Size(200, 200);
			this.bVisualize.TabIndex = 11;
			this.bVisualize.Text = "Визуализировать полученные данные";
			this.bVisualize.UseVisualStyleBackColor = false;
			this.bVisualize.Click += new System.EventHandler(this.bVisualize_Click);
			// 
			// Operations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1360, 673);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.log);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Operations";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form2";
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.RichTextBox log;
		private System.Windows.Forms.SaveFileDialog saveFile;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button bSaveData;
		private System.Windows.Forms.Button bGetData;
		private System.Windows.Forms.Button bGenData;
		private System.Windows.Forms.Button bBackToHomepage;
		private System.Windows.Forms.Button bBackToInput;
		private System.Windows.Forms.Button bSaveMatrix;
		private System.Windows.Forms.Button bSaveStat;
		private System.Windows.Forms.Button bGetMatrix;
		private System.Windows.Forms.Button bGetStat;
		private System.Windows.Forms.Button bGenMatrix;
		private System.Windows.Forms.Button bGenStat;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button bVisualize;
	}
}