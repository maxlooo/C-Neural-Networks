using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractDataFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFile = "C:\\Users\\David\\Documents\\Visual Studio 2017\\Projects\\ExtractDataFromFile\\ExtractDataFromFile\\MessyProgram.txt";
            string outputFile = "C:\\Users\\David\\Documents\\Visual Studio 2017\\Projects\\ExtractDataFromFile\\ExtractDataFromFile\\Less MessyProgram.txt";
            string uploadedLineData = "";
            string[] divideLineData = null;

            FileStream ifs = new FileStream(dataFile, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            FileStream ofs = new FileStream(outputFile, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(ofs);

            while ((uploadedLineData = sr.ReadLine()) != null)
            {
                divideLineData = uploadedLineData.Split(';');
                for (int i=0; i < divideLineData.Length; ++i)
                {
                    sw.WriteLine(divideLineData[i] + ";");
                }
                sw.WriteLine(";");
            }

            sr.Close();
            ifs.Close();
            sw.Close();
            ofs.Close();
        }
    }
}
