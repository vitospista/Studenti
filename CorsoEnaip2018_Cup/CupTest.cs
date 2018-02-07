using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorsoEnaip2018_Cup
{
    [TestClass]
    public class CupTest
    {
        [TestMethod]
        public void new_Cup_is_empty()
        {
            var c = new Cup();
            Assert.AreEqual(0, c.Quantity);
        }

        [TestMethod]
        public void filled_Cup_is_full()
        {
            var c = new Cup();
            c.Fill();
            Assert.AreEqual(10, c.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void full_Cup_cannot_be_filled_again()
        {
            var c = new Cup();
            c.Fill();
            c.Fill();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void empty_Cup_cannot_be_emptied()
        {
            var c = new Cup();
            c.Empty();
        }

        [TestMethod]
        public void emptied_Cup_is_empty()
        {
            var c = new Cup();
            c.Fill();
            c.Empty();
            Assert.AreEqual(0, c.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void emptied_Cup_cannot_be_emptied_again()
        {
            var c = new Cup();
            c.Fill();
            c.Empty();
            c.Empty();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void cannot_Drink_from_an_empty_Cup()
        {
            var c = new Cup();
            c.Drink(5, new Person());
        }

        [TestMethod]
        public void Drink_leaves_correct_quantity_in_Cup()
        {
            var c = new Cup();
            c.Fill();
            c.Drink(3, new Person());
            Assert.AreEqual(7, c.Quantity);
        }

        [TestMethod]
        public void Drink_more_times_leaves_correct_quantity_in_Cup()
        {
            var p = new Person();

            var c = new Cup();
            c.Fill();
            c.Drink(3, p);
            c.Drink(6, p);
            Assert.AreEqual(1, c.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void cannot_Drink_more_than_available_quantity()
        {
            var p = new Person();

            var c = new Cup();
            c.Fill();
            c.Drink(4, p);
            c.Drink(8, p);
        }

        [TestMethod]
        public void Empty_post_Drink_empties_the_Cup()
        {
            var c = new Cup();
            c.Fill();
            c.Drink(4, new Person());
            c.Empty();
            Assert.AreEqual(0, c.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void another_person_cannot_Drink_from_the_same_Cup()
        {
            var c = new Cup();
            c.Fill();
            c.Drink(4, new Person());
            c.Drink(3, new Person());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void another_person_cannot_Drink_from_the_same_Cup_even_if_emptied()
        {
            var c = new Cup();
            c.Fill();
            c.Drink(4, new Person());
            c.Empty();
            c.Fill();
            c.Drink(3, new Person());
        }

        [TestMethod]
        public void two_Cups_can_be_drunk_by_two_different_people()
        {
            var c1 = new Cup();
            c1.Fill();
            var p1 = new Person();

            var c2 = new Cup();
            c2.Fill();
            var p2 = new Person();

            c1.Drink(5, p1);
            c2.Drink(2, p2);

            Assert.AreEqual(5, c1.Quantity);
            Assert.AreEqual(8, c2.Quantity);
        }

        [TestMethod]
        public void a_washed_Cup_is_empty()
        {
            var c = new Cup();
            c.Fill();
            c.Wash();

            Assert.AreEqual(0, c.Quantity);
        }

        [TestMethod]
        public void a_washed_Cup_can_be_drunk_by_another_person()
        {
            var c = new Cup();

            c.Fill();

            c.Drink(3, new Person());

            c.Wash();

            c.Fill();

            c.Drink(7, new Person());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_Person_cannot_drink()
        {
            var c = new Cup();
            c.Fill();
            c.Drink(1, null);
        }

        public void AWashedCupCanBeDrunkByAnotherPerson()
        {

        }
    }
}
