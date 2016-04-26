using NeuroSky.ThinkGear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace MindwaveTestUI
{
    public static class MindwaveConnectionManager
    {
        static Connector connector;
        static byte poorSig;
        static UIForm form;
        static double[] dataBuffer;
        static int BUFFER_SIZE = 1000;
        static int bufferPointer = 0;
        static bool collectRelaxTrainingSample = false;
        static BrainWaveMatrix relaxTrainingSample = new BrainWaveMatrix();
        static bool collectClickTrainingSample = false;
        static BrainWaveMatrix clickTrainingSample = new BrainWaveMatrix();
        static BrainWaveMatrix jointTrainingSample = new BrainWaveMatrix();
        static bool finishedTraining = false;
        static double averageMargin = 0.15;
        static double magnitudeMargin = 10;
        static double trainingClassNumber = -1;
        static double distance = 0;
        static List<double> rawTrainingSampleArray;
        static double rawTrainingSampleAverage = 0;
        static double rawDataAverage = 0;
        private const int WM_KEYDOWN = 0x0100;
        private static int matchCounter = 0;
        private static int transformedMatchCounter = 0;
        private static  int numberOfConsecutiveMatchesRequired = 15;
        static alglib.complex[] dataComplex;
        static alglib.complex[] rawTrainingSampleComplex;
        static double rawDataMagnitudeAverage = 0;
        static double sampleMagnitudeAverage = 0;
        public static bool allowKeyEvent = true;

        public static void SetFormReference(UIForm formReference)
        {
            form = formReference;
        }

        public static void Connect()
        {
            form.SetMarginText(averageMargin.ToString());
            form.SetMagnitudeMarginText(magnitudeMargin.ToString());
            connector = new Connector();
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);


            // Scan for devices across COM ports
            // The COM port named will be the first COM port that is checked.
            connector.ConnectScan("COM3");

            // Blink detection needs to be manually turned on
            connector.setBlinkDetectionEnabled(false);
            connector.setMentalEffortEnable(true);
            connector.setMentalEffortRunContinuous(true);
            //Thread.Sleep(450000);


            form.ChangeStatusMessage("Connecting...");
            dataBuffer = new double[BUFFER_SIZE];
        }

        static void OnDeviceConnected(object sender, EventArgs e)
        {
            Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

            // Console.WriteLine("Device found on: " + de.Device.PortName);
            form.SetDataText("Device found on: " + de.Device.PortName);
            de.Device.DataReceived += new EventHandler(OnDataReceived);
        }

        static void OnDeviceFail(object sender, EventArgs e)
        {
            //Console.WriteLine("No devices found! :(");
            form.SetStatusText("No devices found! :(");
        }

        static void OnDeviceValidating(object sender, EventArgs e)
        {
           // Console.WriteLine("Validating: ");
            form.SetStatusText("Validating...");
        }

        static void OnDataReceived(object sender, EventArgs e)
        {
            BrainWaveVector waveVector = new BrainWaveVector(trainingClassNumber);

            //Device d = (Device)sender;
            form.SetStatusText("Receiving Data");

            Device.DataEventArgs de = (Device.DataEventArgs)e;
            DataRow[] tempDataRowArray = de.DataRowArray;

            TGParser tgParser = new TGParser();
            tgParser.Read(de.DataRowArray);

      //      MentalEffort mentalEffort = new MentalEffort();
      //      mentalEffort.CalculateMentalEffort(, TGsensorType.);

            /* Loops through the newly parsed data of the connected headset*/
            // The comments below indicate and can be used to print out the different data outputs. 

            for (int i = 0; i < tgParser.ParsedData.Length; i++)
            {

                #region Build waveVector with ParsedData
                if(tgParser.ParsedData[i].ContainsKey("Raw"))
                {
                   if(collectClickTrainingSample)
                    {
                        rawTrainingSampleArray.Add(tgParser.ParsedData[i]["Raw"]);
                    }
                   else if(finishedTraining)
                    {
                        AddData(tgParser.ParsedData[i]["Raw"]);
                    }
                }
                #region Parse EEG Power Values
                if (tgParser.ParsedData[i].ContainsKey("EegPowerTheta"))
                {
                    waveVector.AddValue(0, tgParser.ParsedData[i]["EegPowerTheta"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
                {
                    waveVector.AddValue(1, tgParser.ParsedData[i]["EegPowerDelta"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha1"))
                {
                    waveVector.AddValue(2, tgParser.ParsedData[i]["EegPowerAlpha1"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha2"))
                {
                    waveVector.AddValue(3, tgParser.ParsedData[i]["EegPowerAlpha2"]);
                }

                if(tgParser.ParsedData[i].ContainsKey("EegPowerBeta1"))
                {
                    waveVector.AddValue(4, tgParser.ParsedData[i]["EegPowerBeta1"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta2"))
                {
                    waveVector.AddValue(5, tgParser.ParsedData[i]["EegPowerBeta2"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma1"))
                {
                    waveVector.AddValue(6, tgParser.ParsedData[i]["EegPowerGamma1"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma2"))
                {
                    waveVector.AddValue(7, tgParser.ParsedData[i]["EegPowerGamma2"]);
                }
                #endregion
                #endregion

                #region ParsedData if statements from sample - kept for reference

                if (tgParser.ParsedData[i].ContainsKey("Raw"))
                {

                    //Console.WriteLine("Raw Value:" + tgParser.ParsedData[i]["Raw"]);
                    //                  form.SetDataText((tgParser.ParsedData[i]["Raw"]) +"\t");
                    //                   AddData(tgParser.ParsedData[i]["Raw"]);

                }

                if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
                {

                    //The following line prints the Time associated with the parsed data
                    //Console.WriteLine("Time:" + tgParser.ParsedData[i]["Time"]);

                    //A Poor Signal value of 0 indicates that your headset is fitting properly
                    //                    Console.WriteLine("Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);

                    //                    poorSig = (byte)tgParser.ParsedData[i]["PoorSignal"];
                }


                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {

                    //Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);

                }


                if (tgParser.ParsedData[i].ContainsKey("Meditation"))
                {

                    //Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);

                }

                if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
                {

                    //Console.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);

                }

                /*                if (tgParser.ParsedData[i].ContainsKey("MentalEffort"))
                                {

                                    form.SetDataText((tgParser.ParsedData[i]["MentalEffort"]) + "\t");
                                    AddData(tgParser.ParsedData[i]["MentalEffort"]);
                                } */

                /*                foreach(string key in tgParser.ParsedData[i].Keys.ToArray())
                                {
                                    form.SetDataText(key + "\t");
                                } */
                //                CalculateAndDisplayAverage();

                #endregion

                if(finishedTraining)
                {
                    if (waveVector.HasValue())
                    {
                        //Check if correspondes to ClickTrainingSample
                       // form.SetClickAverageText(CheckForEvent(clickTrainingSample, waveVector).ToString());
            //            form.SetDataText(waveVector.ReturnVector()[1].ToString() + '\t');
                    }
                    bool sampleMatch = CheckForEvent(dataBuffer, rawTrainingSampleAverage, out rawDataAverage);
                    bool complexSampleMatch = CheckForEvent(sampleMagnitudeAverage, dataComplex, out rawDataMagnitudeAverage);
                    form.SetRelaxAverageText(sampleMatch.ToString());
                    form.SetClickAverageText(rawTrainingSampleAverage.ToString());
                    //form.SetDataText(rawDataAverage.ToString() + '\t');
                    form.SetDataText(rawDataMagnitudeAverage.ToString() + '\t');
                    form.SetMagnitudeEventText(complexSampleMatch.ToString());

                    if(sampleMatch)
                    {
                        if (matchCounter >= numberOfConsecutiveMatchesRequired && allowKeyEvent)
                        {
                            //                           TieIntoWindow();
                           // allowKeyEvent = false;
                            matchCounter = 0;
                        }
                        matchCounter++;
                    }
                    else
                    {
                        matchCounter = 0;
                    }

                    if (complexSampleMatch)
                    {
                        if (transformedMatchCounter >= numberOfConsecutiveMatchesRequired && allowKeyEvent)
                        {
                            TieIntoWindow();
                            allowKeyEvent = false;
                            ResetDataBuffer();
                            //timer ensures event cannot be read for 1 second
                            // form.StartEventRestTimer();

                            transformedMatchCounter = 0;
                        }
                        transformedMatchCounter++;
                    }
                    else
                    {
                        transformedMatchCounter = 0;
                        allowKeyEvent = true;
                    }

                }
                else if(collectClickTrainingSample && waveVector.HasValue())
                {
                    clickTrainingSample.AddVectorToMatrix(waveVector);
                    jointTrainingSample.AddVectorToMatrix(waveVector);
                }
                else if(collectRelaxTrainingSample && waveVector.HasValue())
                {
                    relaxTrainingSample.AddVectorToMatrix(waveVector);
                    jointTrainingSample.AddVectorToMatrix(waveVector);
                }


            }

        }

        static void AddData(double data)
        {
            if(bufferPointer >= BUFFER_SIZE)
            {
                bufferPointer = 0;
            }

            dataBuffer[bufferPointer] = data;
            bufferPointer++;

            alglib.fftr1d(dataBuffer, out dataComplex);
        }

        static void ResetDataBuffer()
        {
            for(int index = 0; index < dataBuffer.Length; index++)
            {
                dataBuffer[index] = 0;
            }
            bufferPointer = 0;
        }

        static void CalculateAndDisplayAverage()
        {
            double total = 0;
            double average = 0;
            foreach (var datum in dataBuffer)
            {
                total += datum;
            }

            average = total / dataBuffer.Length;

            form.SetClickAverageText(average.ToString());
        }

        public static void CloseConnector()
        {

           if( connector.getState() == (State.connected))
                {
                connector.Disconnect();
                connector.Close();
            }
            
        }

        public static void StartCollectingClickTrainingSample()
        {
            rawTrainingSampleArray = new List<double>();
            collectClickTrainingSample = true;
            trainingClassNumber = 1;
        }

        public static void StopCollectingClickTrainingSample()
        {
            collectClickTrainingSample = false;
            // form.SetClickAverageText(clickTrainingSample.Average().ToString());
            //clickTrainingSample.PreformLDAonMatrix();
            //jointTrainingSample.PreformLDAonMatrix();
            rawTrainingSampleAverage = CalculateSampleAverage(rawTrainingSampleArray);
            finishedTraining = true;
            clickTrainingSample.CreateMeanVector();
            alglib.fftr1d(rawTrainingSampleArray.ToArray(), out rawTrainingSampleComplex);
            sampleMagnitudeAverage = AverageMagnitudeOfComplex(rawTrainingSampleComplex);
            form.SetSampleMagnitudeText(sampleMagnitudeAverage.ToString());
            ResetDataBuffer();
        }

        public static void StartCollectingRelaxTrainingSample()
        {
            collectRelaxTrainingSample = true;
            trainingClassNumber = 0;
        }

        public static void StopCollectingRelaxTrainingSample()
        {
            collectRelaxTrainingSample = false;
           // form.SetRelaxAverageText(relaxTrainingSample.Average().ToString());
            relaxTrainingSample.PreformLDAonMatrix();
        }

        public static bool CheckForEvent(double[] collectedData, double sampleAverage, out double collectedAverage)
        {
            double collectedDataAverage = 0;

            foreach(double datum in collectedData)
            {
                collectedDataAverage += datum;
            }

            collectedDataAverage = collectedDataAverage / collectedData.Length;
            
            collectedAverage = collectedDataAverage;
            
            return Math.Abs((sampleAverage - collectedDataAverage)) < averageMargin ? true : false;
        }

        public static bool CheckForEvent(BrainWaveMatrix trainedSampleMatrix, BrainWaveVector collectedVector)
        {
            return trainedSampleMatrix.CheckForMatch(collectedVector.ReturnVector(), out distance);
        }
        
        public static bool CheckForEvent(double sampleAverageMagnitude, alglib.complex[] array2, out double averageMagnitude2)
        {
            averageMagnitude2 = AverageMagnitudeOfComplex(array2);

            return Math.Abs(averageMagnitude2 - sampleAverageMagnitude) <= magnitudeMargin;
        }

        private static double CalculateSampleAverage(List<double> sampleArray)
        {
            double tempValue = 0;
            foreach(double value in sampleArray)
            {
                tempValue += value;
            }

            return tempValue / rawTrainingSampleArray.Count();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, Keys wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, Keys wParam, IntPtr lParam);

        public static void TieIntoWindow()
        {
            //get using spy++
            //     IntPtr readiumHandle = (IntPtr)000706F0;
            IntPtr readiumHandle = FindWindow("Chrome_WidgetWin_1", "Readium");
            SetForegroundWindow(readiumHandle);
            SendKeys.SendWait("{ENTER}");

          //  PostMessage(readiumHandle, WM_KEYDOWN, Keys.Enter, IntPtr.Zero);
          //  SendMessage(readiumHandle, WM_KEYDOWN, Keys.Enter, IntPtr.Zero);
        }

        public static void AdjustAverageMargin(bool increaseErrorMargin)
        {
            if(increaseErrorMargin)
            {
                averageMargin += 0.01;
            }
            else
            {
                averageMargin -= 0.01;
            }

            form.SetMarginText(averageMargin.ToString());
        }

        public static void AdjustMagnitudeMargin(bool increaseErrorMargin)
        {
            if (increaseErrorMargin)
            {
                magnitudeMargin += 5;
            }
            else
            {
                magnitudeMargin -= 5;
            }

            form.SetMagnitudeMarginText(magnitudeMargin.ToString());
        }

        public static double AverageMagnitudeOfComplex(alglib.complex[] array)
        {
            double averageMagnitude = 0;

            foreach(var frequency in array)
            {
                averageMagnitude += alglib.math.abscomplex(frequency);
            }

            return averageMagnitude / array.Length;
        }

    }
}
