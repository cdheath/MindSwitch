﻿namespace MindwaveTestUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIForm));
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.debugModeBtn = new System.Windows.Forms.Button();
            this.sendEnterBtn = new System.Windows.Forms.Button();
            this.increaseMarginBtn = new System.Windows.Forms.Button();
            this.decreaseMarginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.marginTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
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
            this.dataTb.Size = new System.Drawing.Size(1093, 619);
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
            this.trainingBtn.Size = new System.Drawing.Size(360, 43);
            this.trainingBtn.TabIndex = 5;
            this.trainingBtn.Text = "Start Training - Relax";
            this.trainingBtn.UseVisualStyleBackColor = true;
            this.trainingBtn.Click += new System.EventHandler(this.trainingBtn_Click);
            // 
            // clickTrainingBtn
            // 
            this.clickTrainingBtn.Location = new System.Drawing.Point(1111, 541);
            this.clickTrainingBtn.Name = "clickTrainingBtn";
            this.clickTrainingBtn.Size = new System.Drawing.Size(361, 43);
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
            this.relaxAverLbl.Size = new System.Drawing.Size(85, 13);
            this.relaxAverLbl.TabIndex = 7;
            this.relaxAverLbl.Text = "Event Detected:";
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
            // picture
            // 
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.Location = new System.Drawing.Point(280, 24);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(642, 624);
            this.picture.TabIndex = 10;
            this.picture.TabStop = false;
            // 
            // debugModeBtn
            // 
            this.debugModeBtn.Location = new System.Drawing.Point(1425, 648);
            this.debugModeBtn.Name = "debugModeBtn";
            this.debugModeBtn.Size = new System.Drawing.Size(29, 23);
            this.debugModeBtn.TabIndex = 11;
            this.debugModeBtn.UseVisualStyleBackColor = true;
            this.debugModeBtn.Click += new System.EventHandler(this.debugModeBtn_Click);
            // 
            // sendEnterBtn
            // 
            this.sendEnterBtn.Location = new System.Drawing.Point(1112, 498);
            this.sendEnterBtn.Name = "sendEnterBtn";
            this.sendEnterBtn.Size = new System.Drawing.Size(360, 23);
            this.sendEnterBtn.TabIndex = 12;
            this.sendEnterBtn.Text = "Send Enter Event";
            this.sendEnterBtn.UseVisualStyleBackColor = true;
            this.sendEnterBtn.Click += new System.EventHandler(this.sendEnterBtn_Click);
            // 
            // increaseMarginBtn
            // 
            this.increaseMarginBtn.Location = new System.Drawing.Point(1115, 149);
            this.increaseMarginBtn.Name = "increaseMarginBtn";
            this.increaseMarginBtn.Size = new System.Drawing.Size(137, 23);
            this.increaseMarginBtn.TabIndex = 13;
            this.increaseMarginBtn.Text = "Increase Margin";
            this.increaseMarginBtn.UseVisualStyleBackColor = true;
            this.increaseMarginBtn.Click += new System.EventHandler(this.increaseMarginBtn_Click);
            // 
            // decreaseMarginBtn
            // 
            this.decreaseMarginBtn.Location = new System.Drawing.Point(1115, 190);
            this.decreaseMarginBtn.Name = "decreaseMarginBtn";
            this.decreaseMarginBtn.Size = new System.Drawing.Size(137, 23);
            this.decreaseMarginBtn.TabIndex = 14;
            this.decreaseMarginBtn.Text = "Decrease Margin";
            this.decreaseMarginBtn.UseVisualStyleBackColor = true;
            this.decreaseMarginBtn.Click += new System.EventHandler(this.decreaseMarginBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1115, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Margin Value:";
            // 
            // marginTb
            // 
            this.marginTb.Location = new System.Drawing.Point(1235, 100);
            this.marginTb.Name = "marginTb";
            this.marginTb.ReadOnly = true;
            this.marginTb.Size = new System.Drawing.Size(100, 20);
            this.marginTb.TabIndex = 16;
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 673);
            this.Controls.Add(this.marginTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decreaseMarginBtn);
            this.Controls.Add(this.increaseMarginBtn);
            this.Controls.Add(this.sendEnterBtn);
            this.Controls.Add(this.debugModeBtn);
            this.Controls.Add(this.picture);
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
            this.Text = "TrainingWindow";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
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
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button debugModeBtn;
        private System.Windows.Forms.Button sendEnterBtn;
        private System.Windows.Forms.Button increaseMarginBtn;
        private System.Windows.Forms.Button decreaseMarginBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox marginTb;
    }
}

