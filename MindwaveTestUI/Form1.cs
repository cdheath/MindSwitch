using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindwaveTestUI
{
    public partial class UIForm : Form
    {
        public UIForm()
        {
            InitializeComponent();
        }

        public void AppendDataTextBox(string newString)
        {
            dataTb.AppendText(newString = "\r\n");
        }

        public void ChangeStatusMessage(string newStatus)
        {
            status.Text = newStatus;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MindwaveConnectionManager.SetFormReference(this);
            MindwaveConnectionManager.Connect();
        }

        public void SetDataText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetDataText(text);
                }));
            }
            else
            {
                this.dataTb.AppendText(text);
            }
        }

        public void SetStatusText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetStatusText(text);
                }));
            }
            else
            {
                this.status.Text = text;
            }
        }

        public void SetAverageText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetAverageText(text);
                }));
            }
            else
            {
                this.averTB.Text = text;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            MindwaveConnectionManager.CloseConnector();
        }
    }
}
