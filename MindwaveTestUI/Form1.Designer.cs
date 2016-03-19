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
            this.averLbl.Size = new System.Drawing.Size(53, 13);
            this.averLbl.TabIndex = 3;
            this.averLbl.Text = "Average: ";
            // 
            // averTB
            // 
            this.averTB.Location = new System.Drawing.Point(1171, 6);
            this.averTB.Name = "averTB";
            this.averTB.ReadOnly = true;
            this.averTB.Size = new System.Drawing.Size(100, 20);
            this.averTB.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 673);
            this.Controls.Add(this.averTB);
            this.Controls.Add(this.averLbl);
            this.Controls.Add(this.dataTb);
            this.Controls.Add(this.status);
            this.Controls.Add(this.connStatisLbl);
            this.Name = "Form1";
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
    }
}

