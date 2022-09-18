using LearningMAUI_2022_23_Blazor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMAUI_2022_23_Blazor.Data
{
    public class WriteToCsv
    {
        public static void WriteDataToCsv(ToDoModel data, string path)
        {
            var sw = new StreamWriter(path);

            sw.WriteLine("TaskName,TaskDescription,TaskDate,TaskType");

            //foreach (var item in data)
            //{

                sw.WriteLine($"{data.Name},{data.Description},{data.TaskDate},{data.TaskType},");

            //}
            sw.Close();
            Console.WriteLine("Success");
        }

        public static void Wr2(ToDoModel data, string path)
        {
            var csv = new StringBuilder();

            //Suggestion made by KyleMit
            var newLine = string.Format("{0},{1},{2},{3}", data.Name, data.Description, data.TaskDate, data.TaskType);
            csv.AppendLine(newLine);

            //after your loop
            File.AppendAllText(path, csv.ToString());
        }
    }
}
