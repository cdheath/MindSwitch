using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindwaveTestUI
{
    class BrainWaveMatrix
    {
        List<BrainWaveVector> waveMatrix = new List<BrainWaveVector>();
        int numberOfPoints = 0;  //number of vectors in sample - correspondes to matrix rows
        int numberOfVariables = 8;  //corresponds to 8 waves in vector - correspondes to matrix columns 
        int exitCode = 0;
        int numberOfClasses = 2;  //need both resting and click i think
        double[] linearCombiniationArray;

        public void AddVectorToMatrix(BrainWaveVector newWaveVector)
        {
            ///TODO: Should check for duplicates with last value?
            waveMatrix.Add(newWaveVector);
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

                foreach(double value in vector.ReturntVector())
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
    }
}
