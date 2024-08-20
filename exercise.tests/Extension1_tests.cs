﻿using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class Extension1_tests
    {
        public void SetBsketSizeToThirty( Customer p)
        {
            Manager M = new Manager("Manager");
            M.SetMaxSize(30, p);
        }
        
        public void PoppulateBaskets(int i, Customer p,bagleType productType)
        {

            for (int j = 0; j < i; j++)
            {
                p.addItemToBascet(productType);
            }

        }

        [Test]
        public void SixBagles_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p,bagleType.BGLO);
            Assert.That(p.ImplementDiscount() == 2.49f);
        }

        [Test]
        public void Twelve_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(12, p, bagleType.BGLP);
            Assert.That(p.ImplementDiscount() == 3.99f);
        }

        [Test]
        public void BGLE_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, bagleType.BGLE);
            Assert.That(p.ImplementDiscount() == 2.49f);
        }

        [Test]
        public void COFB_DiscountTest()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            p.addItemToBascet(bagleType.BGLO);
            p.addItemToBascet(drinkType.COFB);
            Assert.That(p.ImplementDiscount() == 1.25f);
        }

        [Test]
        public void comboTest_1()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, bagleType.BGLE);
            PoppulateBaskets(6, p, bagleType.BGLO);
            Assert.That(p.ImplementDiscount() == (3.99f));
        }

        [Test]
        public void comboTest_2()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, bagleType.BGLE);
            PoppulateBaskets(6, p, bagleType.BGLO);
            PoppulateBaskets(6, p, bagleType.BGLO);
            Assert.That(p.ImplementDiscount() == (float)Math.Round((3.99f + 2.49f),2));
        }

        [Test]
        public void comboTest_3()
        {
            Customer p = new Customer("Tom");
            SetBsketSizeToThirty(p);
            PoppulateBaskets(6, p, bagleType.BGLE);
            PoppulateBaskets(12, p, bagleType.BGLO);
            PoppulateBaskets(3, p, bagleType.BGLP);
            p.addItemToBascet(drinkType.COFB);
            p.addItemToBascet(drinkType.COFB);

            Assert.That(p.ImplementDiscount() == (float)Math.Round((3.99f + 2.49f+1.25f +1.25f + 0.39f), 2));
        }
    }
}

