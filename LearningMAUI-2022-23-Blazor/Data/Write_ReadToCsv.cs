using LearningMAUI_2022_23_Blazor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMAUI_2022_23_Blazor.Data
{
    public class Write_ReadToCsv
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


        //this method is designed to write in new line
        public static void WriteToCsvNewLine(ToDoModel data, string path)
        {
            var csv = new StringBuilder();

            //Suggestion made by KyleMit
            var newLine = string.Format("{0},{1},{2},{3}", data.Name, data.Description, data.TaskDate, data.TaskType);
            csv.AppendLine(newLine);

            //after your loop
            File.AppendAllText(path, csv.ToString());
        }

        public static async void ReadToCsvAsync()
        {
            var column1 = new List<string>();
            var column3 = new List<string>();
            using (var rd = new StreamReader("C:\\Development\\.Net\\Islington\\LearningMAUI-2022-23-Blazor\\todo2.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var splits = (await rd.ReadLineAsync())?.Split(',');

                    if (splits == null) continue;
                    column1.Add(splits[0]);
                    column3.Add(splits[1]);
                }
            }

            for (var v = 1; v < column1.Count; v++)
            {
                Console.WriteLine($"pageId: {column1[v]} , filePath: {column3[v]}");
                if (string.IsNullOrEmpty(column3[v]))
                {
                    Console.WriteLine("File path is empty. Error!");
                    continue;
                }

            }
        }

        public async static Task<List<ToDoModel>> ExportCsvData()
        {

            var toDoModels = new List<ToDoModel>();

            using (var rd = new StreamReader("C:\\Development\\.Net\\Islington\\LearningMAUI-2022-23-Blazor\\todo2.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var splits = (await rd.ReadLineAsync())?.Split(',');

                    if (splits == null) continue;

                    toDoModels.Add(new ToDoModel
                    {
                        Name = splits[0],
                        Description = splits[1],
                        TaskDate = splits[2],
                        TaskType = splits[3]

                    });
                }
            }

            return toDoModels;
        }
    }
}
