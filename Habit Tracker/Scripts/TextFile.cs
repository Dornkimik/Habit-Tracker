using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_Tracker.Scripts
{
    static class TextFile
    {
        public static void WriteTextFile(string text)
        {
            using (StreamWriter writetext = File.AppendText("write.txt"))
            {
                writetext.WriteLine(text);
            }
        }

        public static void ReadTextFile(List<Habit> habits)
        {
            string[] lines = File.ReadAllLines("write.txt");

            foreach (string line in lines)
            {
                if (line.Contains(','))
                {
                    string[] onlyHabit = line.Split(',');

                    habits.Add(new Habit(onlyHabit[0], Convert.ToBoolean(onlyHabit[1])));
                }
            }
        }
    }
}
