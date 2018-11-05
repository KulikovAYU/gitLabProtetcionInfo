using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingGraph;
using Moq;

namespace TestingGraph.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_2_3_6()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 2];
            Arr[0, 0] = 0; Arr[0, 1] = 1;
            algo.type = 2;
            algo.lin = 2;
            int j = 0;
            string[] mas1 = new string[algo.lin];
            mas1[0] = "0"; mas1[1] = "1";

            Assert.AreEqual(algo.RetRow(Arr, j)[0], mas1[0]);
            Assert.AreEqual(algo.RetRow(Arr, j)[1], mas1[1]);
        }

        [TestMethod]
        public void TestMethod1_7_8_6()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 0;
            algo.type = 1;
            algo.lin = 0;
            int j = 0;
            string[] mas1 = new string[1];
            mas1[0] = "0";

            Assert.AreNotEqual(algo.RetRow(Arr, j), mas1);

        }


        [TestMethod]
        public void TestMethod1_7_8_9_10_8_6()
        {
           algorit algo = new algorit();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 1; 
            algo.type = 1;
            algo.lin = 1;
            int j = 0;
            string[] expected = new string[algo.lin];
            expected[0] = "1";
           string[] actual = algo.RetRow(Arr, j);



            Assert.AreEqual(expected[0], actual[0]);


        }


        [TestMethod]
        public void IntegratedTest1()
        {      
            string[] testString = new string[2];


            testString[0] = "1";

            testString[1] = "1";


            int[,] expression = new int[2,2];
            string expected = "1111";
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 1;

            expression[1, 1] = 1;


            var mock = new Mock<algorit>();

            mock.Setup(a => a.RеtRow(expression,1)).Returns(testString);

            algorit algo = mock.Object;

            string actual = algo.Вulid(expression, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IntegratedTest2()
        {
            string[] testString = new string[2];

            testString[0] = "1";

            testString[1] = "0";


            int[,] expression = new int[2, 2];
            string expected = "1010";

            expression[0, 0] = 1;

            expression[0, 1] = 0;

            expression[1, 0] = 1;

            expression[1, 1] = 0;


            var mock = new Mock<algorit>();

            mock.Setup(a => a.RеtRow(expression, 2)).Returns(testString);

            algorit algo = mock.Object;

            string actual = algo.Вulid(expression, 2);

            Assert.AreEqual(expected, actual);
        }




        [TestMethod]
        public void IntegratedTest3()
        {
            string[] testString = new string[2];

            testString[0] = "1";

            testString[1] = "1";


            int[,] expression = new int[2, 2];
            string expected = "1111";

            expression[0, 0] = 1;

            expression[0, 1] = 0;

            expression[1, 0] = 1;

            expression[1, 1] = 0;

            algorit algo = new algorit();

            string actual = algo.Вulid(expression, 1);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void IntegratedTest4()
        {
            string[] testString = new string[2];

            testString[0] = "1";

            testString[1] = "0";


            int[,] expression = new int[2, 2];
            string expected = "1010";

            expression[0, 0] = 1;

            expression[0, 1] = 0;

            expression[1, 0] = 1;

            expression[1, 1] = 0;


            algorit algo = new algorit();

            string actual = algo.Вulid(expression, 2);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod21_2_3_6()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 0; 
            algo.type = 2;
            algo.lin = 0;
            int j = 0;
            int count = 0;

            Assert.AreEqual(algo.CountUnits(Arr, j), count);
        }

        [TestMethod]
        public void TestMethod21_8_9_6()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 2];
            Arr[0, 0] = 1; Arr[0, 1] = 0;
            algo.type = 1;
            algo.lin = 0;
            int j = 0;
            int count = 1;

            Assert.AreNotEqual(algo.CountUnits(Arr, j), count);

        }


        [TestMethod]
        public void TestMethod21_2_3_4_6_3_7()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 0; 
            algo.type = 1;
            algo.lin = 1;
            int j = 0;
            int count = 0;

            Assert.AreEqual(algo.CountUnits(Arr, j), count);


        }


        [TestMethod]
        public void TestMethod21_8_9_10_12_9_7()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 1];
            Arr[0, 0] = 0; 
            algo.type = 1;
            algo.lin = 1;
            int j = 0;
            int count = 0;

            Assert.AreEqual(algo.CountUnits(Arr, j), count);


        }

        [TestMethod]
        public void TestMethod21_2_3_4_5_6_3_7()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 4];
            Arr[0, 0] = 1; Arr[0, 1] = 1; Arr[0, 2] = 1; Arr[0, 3] = 1;
            algo.type = 1;
            algo.lin = 4;
            int j = 0;
            int count = 4;

            Assert.AreEqual(algo.CountUnits(Arr, j), count);


        }


        [TestMethod]
        public void TestMethod21_8_9_10_11_12_9_7()
        {
            algorit algo = new algorit();
            int[,] Arr = new int[1, 4];
            Arr[0, 0] = 1; Arr[0, 1] = 0; Arr[0, 2] = 1; Arr[0, 3] = 0;
            algo.type = 1;
            algo.lin = 4;
            int j = 0;
            int count = 2;

            Assert.AreEqual(algo.CountUnits(Arr, j), count);


        }




        [TestMethod]
        public void IntegratedTest21()
        {

            int[,] exp = new int[2, 1];
            exp[0, 0] = 1;
            exp[1, 0] = 1;

            int[,] mass = new int[1, 2];
            mass[0, 1] = 1;
            mass[0, 0] = 1;

            var mock = new Mock<algorit>();
            mock.Setup(a => a.CountUnits(mass, 0)).Returns(2);
            algorit algo = new algorit();

            bool actual = algo.Check(exp, 2);

            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void IntegratedTest22()
        {
            int[,] exp = new int[2, 2];
            exp[0, 0] = 1;
            exp[1, 0] = 1;
            exp[0, 1] = 1;
            exp[1, 1] = 1;

            int[,] mass = new int[1, 2];
            mass[0, 1] = 1;
            mass[0, 0] = 1;

            var mock = new Mock<algorit>();
            mock.Setup(a => a.CountUnits(mass, 0)).Returns(2);
            algorit algo = new algorit();

            bool actual = algo.Check(exp, 4);

            Assert.AreEqual(actual, true);

        }


        [TestMethod]
        public void IntegratedTest23()
        {
            int[,] exp = new int[2, 2];
            exp[0, 0] = 1;
            exp[1, 0] = 1;
            exp[0, 1] = 1;
            exp[1, 1] = 1;

            int[,] mass = new int[1, 2];
            mass[0, 1] = 1;
            mass[0, 0] = 1;

            var mock = new Mock<algorit>();
            mock.Setup(a => a.CountUnits(mass, 0)).Returns(2);
            algorit algo = new algorit();

            bool actual = algo.Check(exp, 3);

            Assert.AreEqual(actual, false);

        }




        [TestMethod]
        public void IntegratedTest24()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 1;

            expression[1, 1] = 1;

            algorit algo = new algorit();

            bool actual = algo.Check(expression, 4);

            Assert.AreEqual(actual, true);
        }


        [TestMethod]
        public void IntegratedTest25()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 0;

            expression[1, 0] = 1;

            expression[1, 1] = 0;

            algorit algo = new algorit();

            bool actual = algo.Check(expression, 2);

            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void IntegratedTest26()
        {
            int[,] expression = new int[2, 2];
            expression[0, 0] = 1;

            expression[0, 1] = 1;

            expression[1, 0] = 0;

            expression[1, 1] = 0;

            algorit algo = new algorit();

            bool actual = algo.Check(expression, 2);

            Assert.AreEqual(actual, false);
        }



    }
}
