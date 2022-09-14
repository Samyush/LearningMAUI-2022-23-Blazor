using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMAUI_2022_23_Blazor.Data
{
    public class WriteToFileServices
    {
        public string data;
        public string fileName;

        public WriteToFileServices(string data, string fileName)
        {
            this.data = data;
            this.fileName = fileName;
            WriteToTxtFile(data, fileName);
        }

        static void WriteToTxtFile(string dataIs, string fileName)
        {
            //StreamWriter sw = new StreamWriter("../../../CategoryFile.txt", true);
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLineAsync(dataIs);
            sw.Close();
        }
    }
}
