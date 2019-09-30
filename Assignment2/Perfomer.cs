using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Performer
    {
        private List<Performer> addPerformer;
        public string PerformerName { get; set; }
        public double PerformerCost { get; set; }

        public Performer(string performerName, double performerCost)
        {
            this.PerformerName = performerName;
            this.PerformerCost = performerCost;
            addPerformer = new List<Performer>();
        }

        public void PerformerCount()
        {
            addPerformer.Add(new Performer(PerformerName, PerformerCost));
        }
    }
}
