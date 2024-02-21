using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Habit_Tracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Habit> habits = new List<Habit>();

        public MainWindow()
        {
            InitializeComponent();

            Habit_DataGrid.ItemsSource = habits;
        }

        public class Habit
        {
            public string habitName {  get; set; }
            public bool isCompleted {  get; set; }

            public Habit(string habitName, bool isCompleted = false)
            {
                this.habitName = habitName;
                this.isCompleted = isCompleted;
            }
        }

        private void Habit_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Habit habit in habits)
            {
                if (HabitInput.Text == habit.habitName)
                {
                    return;
                }
            }

            habits.Add(new Habit(HabitInput.Text));

            Habit_DataGrid.ItemsSource = null;
            Habit_DataGrid.ItemsSource = habits;
        }
    }
}
