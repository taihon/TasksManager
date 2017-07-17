using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManager.ViewModels
{
    public class RangeFilter<T> where T : struct
    {
        public T? From { get; set; }
        public T? To { get; set; }
    }
}
