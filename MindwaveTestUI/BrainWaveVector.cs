using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindwaveTestUI
{
   public class BrainWaveVector
    {
      double[] waveVector = new double[8];

        //position represents the wave from the reading, 0 = theta, 1 = delta, 2 = alpha1, 3 = alpha2, 4 = beta1, 5 = beta2, 6 = gamma1, 7= gamma2
        public void AddValue(int position, double waveValue)
        {
            if(position >= 0 && position <= 7 )
            {
                waveVector[position] = waveValue;
            }
        }

        public double[] ReturntVector()
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
    }
}
