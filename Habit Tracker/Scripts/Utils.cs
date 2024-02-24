using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Habit_Tracker.MainWindow;

namespace Habit_Tracker
{
    static class Utils
    {
        static public void TestWrite()
        {
            Console.WriteLine("Hey");
        }

        static public void SendErrorMessage(string errorMessage, string caption)
        {
            MessageBox.Show(errorMessage, caption);
        }
    }
}
