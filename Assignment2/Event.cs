using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Event
    {
        private List<Event> newEvent;
        private int numTickets, availableTickets, soldTickets;
        double concessionSales;
        public Stage Stage { get; set; }
        public DateTime EventTime { get; set; }
        public string Title { get; set; }
        public Performer Performer { get; set; }
        public int NumTickets
        {
            get { return availableTickets; }
        }
        public int SoldTickets { get { return soldTickets; } }
        public double TicketPrice { get; set; }
        public int NumberStages { get; set; }
        public int EventMinutes { get; set; }
        public bool ConcessionSales { get; set; }
        public double ConcessionTotal { get { return concessionSales; } }
       

        public Event(string title, int numberStages,  Performer performer, int numTickets, DateTime eventTime, bool concessionSales, double ticketPrice, int eventMinutes,Stage stage)
        {
            this.Title = title;
            this.Performer = performer;
            if (numTickets < 0)
                numTickets = 0;
            this.numTickets = numTickets;
            this.EventTime = eventTime;
            this.Stage = stage;
            this.ConcessionSales = concessionSales;
            this.NumberStages = numberStages;
            this.TicketPrice = ticketPrice;
            this.EventMinutes = eventMinutes;
            newEvent = new List<Event>();
        }

        public void AddEvent(string title, int numberStages, Performer performer, int numTickets, DateTime eventTime, bool concessionSales, double ticketPrice, int eventMinutes, Stage stage)
        {
            newEvent.Add(new Event(title, numberStages, performer, numTickets, eventTime, concessionSales, ticketPrice, eventMinutes, stage));
        }

        public double Profit()
        {
            return Revenue() - EventCost(Title);
        }

        public double Revenue()
        {
            double sales;
            sales = TicketPrice * soldTickets;
            return sales;
        }

        public double EventCost(string Title)
        {
            double totalCost;
            
            //what stage(how long) + performer + cleaning(stage)

            totalCost = ((EventMinutes / 60) * Stage.HourlyRate) +  Stage.CleaningCost + Performer.PerformerCost;

            if (EventTime.DayOfWeek == DayOfWeek.Saturday || EventTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return totalCost;
            }
            else
            {
                return totalCost * .90;
            }
        }

        public double Breakeven()
        {
            double breakeven;

            breakeven = (EventCost(Title) / (TicketPrice - concessionSales));
            return breakeven;
        }

        public double ConcessionPrice(int popcorn, int soda, int candy)
        {
            if (ConcessionSales == true)
            {
                concessionSales = (popcorn * 5)+ (soda * 3) + (candy * 2);
                return concessionSales;
            }
            return 0;
        }

        public double TicketSection(string section)
        {
            switch (section)
            {
                case "A":
                    return TicketPrice + 20;
                case "B":
                    return TicketPrice + 15;
                case "C":
                    return TicketPrice + 10;
                case "D":
                    return TicketPrice + 5;
                case "VIP":
                    return TicketPrice + 50;
                default:
                    return TicketPrice;
            }
        }

        public int SellTickets(int tickets)
        {
            if (numTickets - tickets >= 0)
            {
                availableTickets = numTickets -= tickets;
                soldTickets = tickets;
                return numTickets;
            }
            else
            {
                return numTickets;
            }
        }

        public int ReturnTickets(int tickets)
        {
            numTickets += tickets;
            return numTickets;
            
        }

        public override string ToString()
        {
            string result = Title + " by " + Performer + " on " + EventTime.ToShortDateString();
            result += " at " + EventTime.ToShortTimeString() + ". Concessions: ";
            result += ConcessionSales ? "Yes. " : "No. ";
            result += "Tickets available: " + NumTickets;
            return result;
        }
    }
}
