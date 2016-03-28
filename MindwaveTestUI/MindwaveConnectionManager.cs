﻿using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindwaveTestUI
{
    public static class MindwaveConnectionManager
    {
        static Connector connector;
        static byte poorSig;
        static UIForm form;
        static double[] dataBuffer;
        static int BUFFER_SIZE = 5;
        static int bufferPointer = 0;
        static bool collectRelaxTrainingSample = false;
        static BrainWaveMatrix relaxTrainingSample = new BrainWaveMatrix();
        static bool collectClickTrainingSample = false;
        static BrainWaveMatrix clickTrainingSample = new BrainWaveMatrix();
        static bool finishedTraining = false;
        static decimal THRESHOLD_VALUE = 1000;

        public static void SetFormReference(UIForm formReference)
        {
            form = formReference;
        }

        public static void Connect()
        {
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
            BrainWaveVector waveVector = new BrainWaveVector();

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
                    //Check if correspondes to ClickTrainingSample

                }
                else if(collectClickTrainingSample && waveVector.HasValue())
                {
                    clickTrainingSample.AddVectorToMatrix(waveVector);
                }
                else if(collectRelaxTrainingSample && waveVector.HasValue())
                {
                    relaxTrainingSample.AddVectorToMatrix(waveVector);
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
            collectClickTrainingSample = true;
        }

        public static void StopCollectingClickTrainingSample()
        {
            collectClickTrainingSample = false;
            //    form.SetClickAverageText(clickTrainingSample.Average().ToString());
            clickTrainingSample.PreformLDAonMatrix();
            finishedTraining = true;
        }

        public static void StartCollectingRelaxTrainingSample()
        {
            collectRelaxTrainingSample = true;
        }

        public static void StopCollectingRelaxTrainingSample()
        {
            collectRelaxTrainingSample = false;
            //   form.SetRelaxAverageText(relaxTrainingSample.Average().ToString());
            relaxTrainingSample.PreformLDAonMatrix();
        }

        public static bool CheckForEvent(double[] collectedData, double sampleAverage)
        {
            double collectedDataAverage = 0;

            foreach(double datum in collectedData)
            {
                collectedDataAverage += datum;
            }

            collectedDataAverage = collectedDataAverage / collectedData.Length;

            return Math.Abs((decimal)(sampleAverage - collectedDataAverage)) < THRESHOLD_VALUE ? true : false;
        }
    }
}
