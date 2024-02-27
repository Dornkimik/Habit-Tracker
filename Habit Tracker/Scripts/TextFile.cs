using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Habit_Tracker.Scripts
{
    static class TextFile
    {
        public static string UserDataPath = "Userdata.txt";

        public static void InitializeTextFile()
        {
            if (!File.Exists(UserDataPath))
            {
                var userDataFile = File.Create(UserDataPath);
                userDataFile.Close();
            }
        }

        public static void DailyHabitReset()
        {
            FileInfo userDataFileInfo = new FileInfo(UserDataPath);

            if (userDataFileInfo.LastAccessTime.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
            {
                string text = File.ReadAllText(UserDataPath);
                text = text.Replace(",true", ",false");
                File.WriteAllText(UserDataPath, text);
            }
        }

        public static void WriteTextFile(string text)
        {
            using (StreamWriter writetext = File.AppendText(UserDataPath))
            {
                writetext.WriteLine(text);
            }
        }

        public static void ReadTextFile(List<Habit> habits)
        {
            string[] lines = File.ReadAllLines(UserDataPath);

            foreach (string line in lines)
            {
                if (line.Contains(','))
                {
                    string[] onlyHabit = line.Split(',');

                    habits.Add(new Habit(onlyHabit[0], Convert.ToBoolean(onlyHabit[1])));
                }
            }
        }

        static public void LineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        static public void DeleteLine(List<Habit> habitList, DataGrid habitDataGrid)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(TextFile.UserDataPath))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith(habitList[habitDataGrid.SelectedIndex].habitName))
                        sw.WriteLine(line);
                }
            }

            File.Delete(TextFile.UserDataPath);
            File.Move(tempFile, TextFile.UserDataPath);
        }
    }
}
