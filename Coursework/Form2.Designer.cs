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
			this.status = new System.Windows.Forms.Label();
			this.computeMatrix = new System.Windows.Forms.Button();
			this.visualize = new System.Windows.Forms.Button();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.getL = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// status
			// 
			this.status.AutoSize = true;
			this.status.Location = new System.Drawing.Point(41, 33);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(51, 20);
			this.status.TabIndex = 0;
			this.status.Text = "label1";
			// 
			// computeMatrix
			// 
			this.computeMatrix.Location = new System.Drawing.Point(441, 33);
			this.computeMatrix.Name = "computeMatrix";
			this.computeMatrix.Size = new System.Drawing.Size(241, 61);
			this.computeMatrix.TabIndex = 1;
			this.computeMatrix.Text = "произвести расчет корреляционной матрицы";
			this.computeMatrix.UseVisualStyleBackColor = true;
			this.computeMatrix.Click += new System.EventHandler(this.computeMatrix_Click);
			// 
			// visualize
			// 
			this.visualize.Location = new System.Drawing.Point(870, 33);
			this.visualize.Name = "visualize";
			this.visualize.Size = new System.Drawing.Size(241, 64);
			this.visualize.TabIndex = 2;
			this.visualize.Text = "визуализировать полученные данные";
			this.visualize.UseVisualStyleBackColor = true;
			this.visualize.Visible = false;
			this.visualize.Click += new System.EventHandler(this.visualize_Click);
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(630, 328);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(100, 23);
			this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progress.TabIndex = 3;
			this.progress.Visible = false;
			// 
			// getL
			// 
			this.getL.Location = new System.Drawing.Point(870, 149);
			this.getL.Name = "getL";
			this.getL.Size = new System.Drawing.Size(241, 74);
			this.getL.TabIndex = 4;
			this.getL.Text = "сгенерировать статистику наблюдений";
			this.getL.UseVisualStyleBackColor = true;
			this.getL.Visible = false;
			this.getL.Click += new System.EventHandler(this.getL_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1338, 740);
			this.Controls.Add(this.getL);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.visualize);
			this.Controls.Add(this.computeMatrix);
			this.Controls.Add(this.status);
			this.Name = "Form2";
			this.Text = "Form2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label status;
		private System.Windows.Forms.Button computeMatrix;
		private System.Windows.Forms.Button visualize;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button getL;
	}
}