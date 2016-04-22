using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindwaveTestUI
{
    public partial class UIForm : Form
    {
        private bool lockTraining;
        private bool clickTrainingComplete = false;
        private bool relaxTrainingComplete = false;
        private bool showDebugFields = false;

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
            picture.Visible = false;
            ToggleDebugMode();
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

        public void SetMarginText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetMarginText(text);
                }));
            }
            else
            {
                this.marginTb.Text = text;
            }
        }


        private void Form1_Deactivate(object sender, EventArgs e)
        {

        }

        private void trainingBtn_Click(object sender, EventArgs e)
        {
            if (!lockTraining && !relaxTrainingComplete)
            {
                lockTraining = true;
                MindwaveConnectionManager.StartCollectingRelaxTrainingSample();

                var timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += new EventHandler(TimerTick);
                timer.Start();
                trainingBtn.Text = "Training in Progess";

            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            trainingBtn.Text = "Training Complete";
            MindwaveConnectionManager.StopCollectingRelaxTrainingSample();
            lockTraining = false;
            relaxTrainingComplete = true;
        }

        private void ClickTimerTick(object sender, EventArgs e)
        {
            clickTrainingBtn.Text = "Training Complete";
            MindwaveConnectionManager.StopCollectingClickTrainingSample();
            lockTraining = false;
            clickTrainingComplete = true;
            picture.Visible = false;
        }

        private void clickTrainingBtn_Click(object sender, EventArgs e)
        {
            if (!lockTraining && !clickTrainingComplete)
            {
                lockTraining = true;
                MindwaveConnectionManager.StartCollectingClickTrainingSample();

                var timer = new Timer();
                timer.Interval = 2000;
                timer.Tick += new EventHandler(ClickTimerTick);
                timer.Start();
                clickTrainingBtn.Text = "Training in Progess";
                picture.Visible = true;
            }
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

        public void SetSampleMagnitudeText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetSampleMagnitudeText(text);
                }));
            }
            else
            {
                this.magAverTb.Text = text;
            }
        }

        public void SetMagnitudeEventText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetMagnitudeEventText(text);
                }));
            }
            else
            {
                this.magEventTb.Text = text;
            }
        }

        public void SetMagnitudeMarginText(string text)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetMagnitudeMarginText(text);
                }));
            }
            else
            {
                this.magMarginValTb.Text = text;
            }
        }

        private void debugModeBtn_Click(object sender, EventArgs e)
        {
           ToggleDebugMode();
        }

        private void ToggleDebugMode()
        {
            showDebugFields = !showDebugFields;

            trainingBtn.Visible = showDebugFields;
            dataTb.Visible = showDebugFields;
            averLbl.Visible = showDebugFields;
            relaxAverLbl.Visible = showDebugFields;
            averTB.Visible = showDebugFields;
            relaxAverTb.Visible = showDebugFields;
            sendEnterBtn.Visible = showDebugFields;
            decMagMargValBtn.Visible = showDebugFields;
            incMagMargValBtn.Visible = showDebugFields;
            decreaseMarginBtn.Visible = showDebugFields;
            increaseMarginBtn.Visible = showDebugFields;
            magAverTb.Visible = showDebugFields;
            magEventTb.Visible = showDebugFields;
            magAverLbl.Visible = showDebugFields;
            magEventLbl.Visible = showDebugFields;
            magMarginLbl.Visible = showDebugFields;
            magMarginValTb.Visible = showDebugFields;
            marginLbl.Visible = showDebugFields;
            marginTb.Visible = showDebugFields;
        }

        private void sendEnterBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.TieIntoWindow();
        }

        private void increaseMarginBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.AdjustAverageMargin(true);
        }

        private void decreaseMarginBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.AdjustAverageMargin(false);
        }

        private void UIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MindwaveConnectionManager.CloseConnector();
        }

        private void incMagMargValBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.AdjustMagnitudeMargin(true);
        }

        private void decMagMargValBtn_Click(object sender, EventArgs e)
        {
            MindwaveConnectionManager.AdjustMagnitudeMargin(false);
        }
    }
}
