using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Stage
    {
        public string StageName { get; set; }
        public double HourlyRate { get; set; }
        public double CleaningCost { get; set; }

        public Stage(string stageName, double hourlyRate, double cleaningCost)
        {
            this.StageName = stageName;
            this.HourlyRate = hourlyRate;
            this.CleaningCost = cleaningCost;
        }


    }
}
