using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Tests
{
    [TestClass()]
    public class EventTests
    {
        Event test;
        Event test2;
        Event test3;
        Event test4;
        Event testSameName;
        DateTime testDay = new DateTime(2017, 10, 10);

        Stage mainStage;
        Stage loungeStage;

        Performer oshkoshNorth;
        Performer oshkoshSouth;
        Performer oshkoshEast;
        Performer oshkoshWest;

        [TestInitialize]
        public void SetUp()
        {
            mainStage = new Stage("Main Stage", 100, 150);
            loungeStage = new Stage("Lounge Stage", 75, 50);

            oshkoshNorth = new Performer("Oshkosh North", 100);
            oshkoshSouth = new Performer("Oshkosh South", 200);
            oshkoshEast = new Performer("Oshkosh East", 300);
            oshkoshWest = new Performer("Oshkosh West", 400);

            test = new Event("Romeo and Juliet", 1,oshkoshNorth, 100, DateTime.Now, true,20,120,mainStage);
            test2 = new Event("Shrek", 2, oshkoshSouth, 500, DateTime.Now, false, 10, 180,mainStage);
            test3 = new Event("Mama Mia", 4, oshkoshWest, 200, DateTime.Now, false, 30, 90,loungeStage);
            test4 = new Event("IT", 2, oshkoshEast, 300, testDay, true, 15, 120,mainStage);
            testSameName = new Event("Mama Mia", 3, oshkoshWest, 200, DateTime.Now, false, 30, 90,loungeStage);

            test.AddEvent("Romeo and Juliet", 1, oshkoshNorth, 100, DateTime.Now, true, 20, 120, mainStage);
            test2.AddEvent("Shrek", 2, oshkoshSouth, 500, DateTime.Now, false, 10, 180, mainStage);
            test3.AddEvent("Mama Mia", 4, oshkoshWest, 200, DateTime.Now, false, 30, 90, loungeStage);
            testSameName.AddEvent("Mama Mia", 3, oshkoshWest, 200, DateTime.Now, false, 30, 90, loungeStage);
            test4.AddEvent("IT", 2, oshkoshEast, 300, testDay, true, 15, 120,mainStage);

        }
        [TestMethod()]
        public void NumberTickets()
        {
            test.SellTickets(10);
            Assert.AreEqual(90, test.SellTickets(0));

            //test to see if sell tickets can equal  0
            Assert.AreEqual(0, test.SellTickets(90));

            //test to see if sell tickets doesn't go below 0
            Assert.AreEqual(0, test.SellTickets(1));
            Assert.AreEqual(99, test.ReturnTickets(99));
            Assert.AreEqual(100, test.ReturnTickets(1));
            //Assert.AreEqual(100, test.ReturnTickets(1));
        }

        [TestMethod()]
        public void TestCost()
        {
            //assuming one stage is filled
            Assert.AreEqual(450, test.EventCost("Romeo and Juliet"));
            //assuming 2 stages are filled
            Assert.AreEqual(650, test2.EventCost("Shrek"));
            //assuming 4 stages are filled
            Assert.AreEqual(525, test3.EventCost("Mama Mia"));
            //Testing Weeknight Disount
            Assert.AreEqual(585, test4.EventCost("It"));
        }

        [TestMethod()]
        public void TestProfit()
        {
            //test full ticket selling of test 1
            test.SellTickets(100);
            test.Profit();
            Assert.AreEqual(1550, test.Profit());

            //test partial ticket selling of test 2
            test2.SellTickets(250);
            test2.Profit();
            Assert.AreEqual(1850, test2.Profit());

            //test partial ticket selling of test 3
            test3.SellTickets(10);
            test3.Profit();
            Assert.AreEqual(-225, test3.Profit());

            //test partial ticket selling of test 4
            test4.SellTickets(150);
            test4.Profit();
            Assert.AreEqual(1665, test4.Profit());
        }

        [TestMethod()]
        public void TestConcession()
        {
            Assert.IsTrue(test.ConcessionSales);
            Assert.IsFalse(test2.ConcessionSales);
            Assert.IsFalse(test3.ConcessionSales);
            Assert.IsTrue(test4.ConcessionSales);

            Assert.AreEqual(18, test.ConcessionPrice(2, 2, 1));
            Assert.AreEqual(0, test2.ConcessionPrice(2, 2, 2));
            Assert.AreEqual(0, test3.ConcessionPrice(4, 2, 2));
            Assert.AreEqual(10, test4.ConcessionPrice(0, 2, 2));
        }

        [TestMethod()]
        public void CountPerfomer()
        {
            List<Performer> addPerformer;
            addPerformer = new List<Performer>();

            addPerformer.Add(oshkoshSouth);
            addPerformer.Add(oshkoshSouth);
            addPerformer.Add(oshkoshWest);
            addPerformer.Add(oshkoshEast);

            Assert.AreEqual(true, addPerformer.Contains(oshkoshSouth));
            Assert.AreEqual(false, addPerformer.Contains(oshkoshNorth));
            Assert.AreEqual(true, addPerformer.Contains(oshkoshEast));
            Assert.AreEqual(true, addPerformer.Contains(oshkoshWest));
        }
        
        [TestMethod()]
        public void BreakevenTest()
        {
            Assert.AreEqual(22.5, test.Breakeven());
            Assert.AreEqual(65, test2.Breakeven());
            Assert.AreEqual(17.5, test3.Breakeven());
            Assert.AreEqual(39, test4.Breakeven());
        }

        [TestMethod()]
        public void TicketSectionTest()
        {
            Assert.AreEqual(40, test.TicketSection("A"));
            Assert.AreEqual(35, test.TicketSection("B"));
            Assert.AreEqual(30, test.TicketSection("C"));
            Assert.AreEqual(25, test.TicketSection("D"));
            Assert.AreEqual(70, test.TicketSection("VIP"));
            Assert.AreEqual(20, test.TicketSection("GA"));
        }
    }
}