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

        public void SetClickAverageText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetClickAverageText(text);
                }));
            }
            else
            {
                this.averTB.Text = text;
            }
        }

        public void SetRelaxAverageText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetRelaxAverageText(text);
                }));
            }
            else
            {
                this.relaxAverTb.Text = text;
            }
        }


        private void Form1_Deactivate(object sender, EventArgs e)
        {
            MindwaveConnectionManager.CloseConnector();
        }

        private void trainingBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.StartCollectingRelaxTrainingSample();

            var timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
            trainingBtn.Text = "Training in Progess";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            trainingBtn.Text = "Training Complete";
            MindwaveConnectionManager.StopCollectingRelaxTrainingSample();
        }

        private void ClickTimerTick(object sender, EventArgs e)
        {
            clickTrainingBtn.Text = "Training Complete";
            MindwaveConnectionManager.StopCollectingClickTrainingSample();
        }

        private void clickTrainingBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.StartCollectingClickTrainingSample();

            var timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += new EventHandler(ClickTimerTick);
            timer.Start();
            clickTrainingBtn.Text = "Training in Progess";
        }

        public void SetResultText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetResultText(text);
                }));
            }
            else
            {
                this.resulLbl.Text = text;
            }
        }
    }
}
