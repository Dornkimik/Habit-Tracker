﻿using Habit_Tracker.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

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
            TextFile.InitializeTextFile();
            TextFile.ReadTextFile(habits);
            TextFile.DailyHabitReset();
            Habit_DataGrid.ItemsSource = habits;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            AddHabit();
            HabitInput.Text = "";
        }

        private void AddHabit()
        {
            foreach (Habit habit in habits)
            {
                if (HabitInput.Text == habit.habitName)
                {
                    return;
                }
            }

            if (HabitInput.Text == "") { Utils.SendErrorMessage("Habit cant be empty", "Error"); return; };
            if (HabitInput.Text.Contains(",")) { Utils.SendErrorMessage(", is not allowed", "Error"); return; };

            TextFile.WriteTextFile($"{HabitInput.Text},false");
            habits.Add(new Habit(HabitInput.Text));
            RefreshHabits();
        }

        private void RefreshHabits()
        {
            Habit_DataGrid.ItemsSource = null;
            Habit_DataGrid.ItemsSource = habits;
        }

        private void HabitInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && HabitInput.Text != null)
            {
                AddHabit();
                HabitInput.Text = "";
            }
        }

        void OnChecked(object sender, RoutedEventArgs e)
        {
            if (Habit_DataGrid.SelectedIndex >= 0)
            {
                habits[Habit_DataGrid.SelectedIndex].isCompleted = true;

                TextFile.LineChanger($"{habits[Habit_DataGrid.SelectedIndex].habitName},true", TextFile.UserDataPath, Habit_DataGrid.SelectedIndex);
            }
        }

        void OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (Habit_DataGrid.SelectedIndex >= 0)
            {
                habits[Habit_DataGrid.SelectedIndex].isCompleted = false;
                TextFile.LineChanger($"{habits[Habit_DataGrid.SelectedIndex].habitName},false", TextFile.UserDataPath, Habit_DataGrid.SelectedIndex);
            }
        }

        private void Habit_DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && Habit_DataGrid.SelectedIndex >= 0)
            {
                TextFile.DeleteLine(habits, Habit_DataGrid);
                habits.RemoveAt(Habit_DataGrid.SelectedIndex);
                RefreshHabits();
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            habits.Clear();
            TextFile.ReadTextFile(habits);
            RefreshHabits();
        }
    }
}
