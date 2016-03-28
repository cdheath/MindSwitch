using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindwaveTestUI
{
    public class DeltaWaveArray
    {
        List<double> valueSet = new List<double>();

        public void AddValue(double newValue)
        {
            valueSet.Add(newValue);
        }

        public double Average()
        {
            double total = 0;

            foreach(double value in valueSet)
            {
                total += value;
            }

            return total / valueSet.Count;
        }
    }
}
