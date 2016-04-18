using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindwaveTestUI
{
    public class BrainWaveMatrix
    {
        List<BrainWaveVector> waveMatrix = new List<BrainWaveVector>();
        int numberOfPoints = 0;  //number of vectors in sample - correspondes to matrix rows
        int numberOfVariables = 8;  //corresponds to 8 waves in vector - correspondes to matrix columns 
        int exitCode = 0;
        int numberOfClasses = 2;  //need both resting and click i think
        double[] linearCombiniationArray;
        double[] meanVector = new double[8];

        public void AddVectorToMatrix(BrainWaveVector newWaveVector)
        {
            if (waveMatrix.Count() != 0) 
            {
                if (EucledianDistance(waveMatrix[waveMatrix.Count() - 1].ReturnVector(), newWaveVector.ReturnVector()) != 0)
                {
                    waveMatrix.Add(newWaveVector);
                }
            }
            else
            {
                waveMatrix.Add(newWaveVector);
            }
        }

        public void PreformLDAonMatrix()
        {
            ExectuteLDA(this.ConvertVectorList());
        }

        private double[,] ConvertVectorList()
        {
            numberOfPoints = waveMatrix.Count;
            var tempMatrix = new double[numberOfPoints, numberOfVariables + 1]; //+ 1 for class column

            int matrixRow = 0;

            foreach(BrainWaveVector vector in waveMatrix)
            {
                int matrixColumn = 0;

                foreach(double value in vector.ReturnVector())
                {
                    tempMatrix[matrixRow, matrixColumn] = value;
                    matrixColumn++;
                }
                matrixRow++;
            }

            return tempMatrix;
        }

        private void ExectuteLDA(double[,] matrix)
        {
            alglib.fisherlda(matrix, numberOfPoints, numberOfVariables, numberOfClasses, out exitCode, out linearCombiniationArray);
        }

        public void CreateMeanVector()
        {
            double[] meanCalcVector = new double[8];
            
            foreach(BrainWaveVector vector in waveMatrix)
            {
               for(int index = 0; index < 8; index++)
                {
                    meanCalcVector[index] += vector.ReturnValueAtIndex(index);
                }
            }

            for(int index = 0; index < meanCalcVector.Length; index++)
            {
                meanVector[index] = meanCalcVector[index] / waveMatrix.Count();
            }
        }

        private double EucledianDistance(double[] vector1, double[] vector2)
        {
            double runningTotal = 0;

            for (int index = 0; index < vector1.Length; index++)
            {
                runningTotal += Math.Pow((vector1[index] - vector2[index]), 2);
            }

            return Math.Sqrt(runningTotal);
        }

        public bool CheckForMatch(double[] checkVector, out double distance)
        {
            double ErrorMargin = 1000; //what should this value be?

            distance = EucledianDistance(meanVector, checkVector);

            return Math.Abs(distance) <= ErrorMargin;
        }
    }
}
