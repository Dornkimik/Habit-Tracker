using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_Tracker
{
    public class Habit
    {
        public string HabitName { get; set; }
        public bool IsCompleted { get; set; }

        public Habit(string habitName, bool isCompleted = false)
        {
            HabitName = habitName;
            IsCompleted = isCompleted;
        }
    }
}
