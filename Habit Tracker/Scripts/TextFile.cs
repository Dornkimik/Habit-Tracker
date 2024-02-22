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
                habits.Add(new Habit(line, false));
            }
        }
    }
}
