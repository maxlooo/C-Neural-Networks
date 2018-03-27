using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractModifySaveTrainingData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program.cs location - C:\Users\David\Documents\Visual Studio 2017\Projects\ExtractModifySaveTrainingData\ExtractModifySaveTrainingData

            string inputFile = "C:\\Users\\David\\Documents\\Visual Studio 2017\\Projects\\ExtractModifySaveTrainingData\\ExtractModifySaveTrainingData\\InputData.txt";
            string outputFile = "..\\..\\outputData.txt";
            string inputLineData = "";
            string outputLineData = "";

            FileStream ifs = new FileStream(inputFile, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            FileStream ofs = new FileStream(outputFile, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(ofs);

            while ((inputLineData = sr.ReadLine()) != null)
            {
                // find start, stop indexes.  get substring.  trim substring.
                int startIndex = inputLineData.IndexOf("{", StringComparison.Ordinal);
                int stopIndex = inputLineData.IndexOf("}", StringComparison.Ordinal);
                Console.WriteLine(startIndex + " - " + stopIndex);

                if (startIndex > 0 && stopIndex > 0)
                {
                    outputLineData = inputLineData.Substring(++startIndex, stopIndex - startIndex - 1);
                    outputLineData = outputLineData.Trim();
                    sw.WriteLine(outputLineData);
                }
            }

            sr.Close();
            ifs.Close();
            sw.Close();
            ofs.Close();
        }
    }
}
