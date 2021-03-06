﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindwaveTestUI
{
   public class BrainWaveVector
    {
      double[] waveVector = new double[9]; //8 waves plus 1 final spot for class
        double classNum;
        alglib.complex[] fftComplex;

        //classNum either 0 for relax or 1 for click
        public BrainWaveVector(double classNumber)
        {
            classNum = classNumber;
        }

        //position represents the wave from the reading, 0 = theta, 1 = delta, 2 = alpha1, 3 = alpha2, 4 = beta1, 5 = beta2, 6 = gamma1, 7= gamma2

        public void AddValue(int position, double waveValue)
        {
            if(position >= 0 && position <= 7 )
            {
                waveVector[position] = waveValue;
            }
            waveVector[8] = classNum;
        }

        public double[] ReturnVector()
        {
            return waveVector;
        }

        public bool HasValue()
        {
            foreach(double value in waveVector)
            {
                if(value != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public double ReturnValueAtIndex(int index)
        {
            return waveVector[index];
        }

        public void CalculateFFT()
        {
            alglib.fftr1d(waveVector, out fftComplex);
        }
    }
}
