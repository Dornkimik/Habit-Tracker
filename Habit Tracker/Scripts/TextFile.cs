﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_Tracker.Scripts
{
    static class TextFile
    {
        public static string UserDataPath = "Userdata.txt";

        public static void InitializeTextFile()
        {
            if (!File.Exists(UserDataPath))
            {
                var myFile = File.Create(UserDataPath);
                myFile.Close();
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

        static public void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
