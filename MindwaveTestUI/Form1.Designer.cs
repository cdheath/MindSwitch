namespace MindwaveTestUI
{
    partial class UIForm
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
            this.connStatisLbl = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.dataTb = new System.Windows.Forms.RichTextBox();
            this.averLbl = new System.Windows.Forms.Label();
            this.averTB = new System.Windows.Forms.TextBox();
            this.trainingBtn = new System.Windows.Forms.Button();
            this.clickTrainingBtn = new System.Windows.Forms.Button();
            this.relaxAverTb = new System.Windows.Forms.TextBox();
            this.relaxAverLbl = new System.Windows.Forms.Label();
            this.resulLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connStatisLbl
            // 
            this.connStatisLbl.AutoSize = true;
            this.connStatisLbl.Location = new System.Drawing.Point(13, 648);
            this.connStatisLbl.Name = "connStatisLbl";
            this.connStatisLbl.Size = new System.Drawing.Size(97, 13);
            this.connStatisLbl.TabIndex = 0;
            this.connStatisLbl.Text = "Connection Status:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(137, 647);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 1;
            // 
            // dataTb
            // 
            this.dataTb.Location = new System.Drawing.Point(12, 14);
            this.dataTb.Name = "dataTb";
            this.dataTb.ReadOnly = true;
            this.dataTb.Size = new System.Drawing.Size(1093, 631);
            this.dataTb.TabIndex = 2;
            this.dataTb.Text = "";
            // 
            // averLbl
            // 
            this.averLbl.AutoSize = true;
            this.averLbl.Location = new System.Drawing.Point(1112, 13);
            this.averLbl.Name = "averLbl";
            this.averLbl.Size = new System.Drawing.Size(117, 13);
            this.averLbl.TabIndex = 3;
            this.averLbl.Text = "Click Sample Average: ";
            // 
            // averTB
            // 
            this.averTB.Location = new System.Drawing.Point(1235, 6);
            this.averTB.Name = "averTB";
            this.averTB.ReadOnly = true;
            this.averTB.Size = new System.Drawing.Size(100, 20);
            this.averTB.TabIndex = 4;
            // 
            // trainingBtn
            // 
            this.trainingBtn.Location = new System.Drawing.Point(1112, 590);
            this.trainingBtn.Name = "trainingBtn";
            this.trainingBtn.Size = new System.Drawing.Size(357, 43);
            this.trainingBtn.TabIndex = 5;
            this.trainingBtn.Text = "Start Training - Relax";
            this.trainingBtn.UseVisualStyleBackColor = true;
            this.trainingBtn.Click += new System.EventHandler(this.trainingBtn_Click);
            // 
            // clickTrainingBtn
            // 
            this.clickTrainingBtn.Location = new System.Drawing.Point(1115, 541);
            this.clickTrainingBtn.Name = "clickTrainingBtn";
            this.clickTrainingBtn.Size = new System.Drawing.Size(357, 43);
            this.clickTrainingBtn.TabIndex = 6;
            this.clickTrainingBtn.Text = "Start Training  - Click";
            this.clickTrainingBtn.UseVisualStyleBackColor = true;
            this.clickTrainingBtn.Click += new System.EventHandler(this.clickTrainingBtn_Click);
            // 
            // relaxAverTb
            // 
            this.relaxAverTb.Location = new System.Drawing.Point(1235, 45);
            this.relaxAverTb.Name = "relaxAverTb";
            this.relaxAverTb.ReadOnly = true;
            this.relaxAverTb.Size = new System.Drawing.Size(100, 20);
            this.relaxAverTb.TabIndex = 8;
            // 
            // relaxAverLbl
            // 
            this.relaxAverLbl.AutoSize = true;
            this.relaxAverLbl.Location = new System.Drawing.Point(1112, 48);
            this.relaxAverLbl.Name = "relaxAverLbl";
            this.relaxAverLbl.Size = new System.Drawing.Size(121, 13);
            this.relaxAverLbl.TabIndex = 7;
            this.relaxAverLbl.Text = "Relax Sample Average: ";
            // 
            // resulLbl
            // 
            this.resulLbl.AutoSize = true;
            this.resulLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resulLbl.ForeColor = System.Drawing.Color.Red;
            this.resulLbl.Location = new System.Drawing.Point(1115, 259);
            this.resulLbl.Name = "resulLbl";
            this.resulLbl.Size = new System.Drawing.Size(0, 26);
            this.resulLbl.TabIndex = 9;
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 673);
            this.Controls.Add(this.resulLbl);
            this.Controls.Add(this.relaxAverTb);
            this.Controls.Add(this.relaxAverLbl);
            this.Controls.Add(this.clickTrainingBtn);
            this.Controls.Add(this.trainingBtn);
            this.Controls.Add(this.averTB);
            this.Controls.Add(this.averLbl);
            this.Controls.Add(this.dataTb);
            this.Controls.Add(this.status);
            this.Controls.Add(this.connStatisLbl);
            this.Name = "UIForm";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label connStatisLbl;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.RichTextBox dataTb;
        private System.Windows.Forms.Label averLbl;
        private System.Windows.Forms.TextBox averTB;
        private System.Windows.Forms.Button trainingBtn;
        private System.Windows.Forms.Button clickTrainingBtn;
        private System.Windows.Forms.TextBox relaxAverTb;
        private System.Windows.Forms.Label relaxAverLbl;
        private System.Windows.Forms.Label resulLbl;
    }
}

