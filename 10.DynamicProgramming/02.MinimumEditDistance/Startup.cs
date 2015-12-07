namespace MinimumEditDistance
{
    using System;

    public class Startup
    {
        private static double[,] matrix;

        private const double ReplaceCosts = 1;
        private const double DeleteCosts = 0.9;
        private const double InsertCosts = 0.8;

        public static void Main()
        {
            string firstWord = "developer";
            string secondWord = "enveloped";

            matrix = new double[firstWord.Length + 1, secondWord.Length + 1];

            FillFirstRow();
            FillFirstColumn();
            FillMatrix(secondWord, firstWord);

            Console.WriteLine("answer = {0}", matrix[matrix.GetLongLength(0) - 1, matrix.GetLongLength(1) - 1]);
        }

        private static void FillFirstRow()
        {
            for (int col = 1; col < matrix.GetLongLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + DeleteCosts;
            }
        }

        private static void FillFirstColumn()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + DeleteCosts;
            }
        }

        private static void FillMatrix(string output, string input)
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    var replaceCosts = matrix[row - 1, col - 1];
                    if (output[col - 1] != input[row - 1])
                    {
                        replaceCosts += ReplaceCosts;
                    }

                    var addCosts = matrix[row, col - 1] + InsertCosts;
                    var removeCosts = matrix[row - 1, col] + DeleteCosts;

                    var minCosts = Math.Min(Math.Min(replaceCosts, removeCosts), addCosts);
                    matrix[row, col] = minCosts;
                }
            }
        }
    }
}
