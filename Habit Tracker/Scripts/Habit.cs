using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habit_Tracker
{
    public class Habit
    {
        public string habitName { get; set; }
        public bool isCompleted { get; set; }

        public Habit(string habitName, bool isCompleted = false)
        {
            this.habitName = habitName;
            this.isCompleted = isCompleted;
        }
    }
}
