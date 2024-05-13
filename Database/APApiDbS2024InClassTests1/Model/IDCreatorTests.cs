using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatingApp.Model.IDcreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Model.IDcreator.Tests
{
    [TestClass()]
    public class IDCreatorTests
    {
        [TestMethod()]
        public void GetUniqueIntIDTesttrue()
        {
            //ARRANGE
            IDCreator creator = new IDCreator();
            bool match = false;
            int random = 12;


            //ACT
            int test = creator.GetUniqueIntID(match, random);



            //ASSERT
            Assert.IsTrue(test == 12);



        }
        [TestMethod()]
        public void GetUniqueIntIDTestfalse()
        {
            //ARRANGE
            IDCreator creator = new IDCreator();
            bool match = false;
            int random = 921879455;


            //ACT
            int test = creator.GetUniqueIntID(match, random);



            //ASSERT
            Assert.IsTrue(test == -1);


        }
        [TestMethod()]
        public void TestCompare_UniqueInt()
        {
            //ARRANGE
            IDCreator creator = new IDCreator();
            bool match = false;
            int random = 921879455;


            //ACT
            bool test = creator.CheckUniqueID(random, match);
            bool test2 = creator.CheckUniqueID(10, match);


            //ASSERT
            Assert.IsTrue(test == true);
            Assert.IsTrue(test2 == false);


        }
    }
}