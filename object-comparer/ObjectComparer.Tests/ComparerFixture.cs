using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void ForNullValues()
        {
            string first = null, second = null;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForSimilarIntValue()
        {
            int first = 1, second = 1;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForNonSimilarIntValue()
        {
            int first = 1, second = 2;
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }


        [TestMethod]
        public void ForSimilarStringValue()
        {
            string first = "test", second = "test";
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForNonSimilarStringValue()
        {
            string first = "test", second = "testFail";
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForSimilarArrays()
        {
            int[] first = { 1, 2, 3, 4 };
            int[] second = { 1, 2, 3, 4 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForUnsortedArrays()
        {
            int[] first = { 1, 3, 2, 4 };
            int[] second = { 1, 2, 3, 4 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForDiffrentArrays()
        {
            int[] first = { 1, 2, 3 };
            int[] second = { 1, 2, 3, 4 };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForNonSimilarArrays()
        {
            int[] first = { 1, 2, 5, 4 };
            int[] second = { 1, 2, 3, 4 };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ForSimilarClassObject()
        {
            var firstStudent = new Student();
            var secondStudent = new Student();
            firstStudent.Name = "John";
            firstStudent.Id = 100;
            firstStudent.Marks = new[] { 80, 90, 100 };

            secondStudent.Name = "John";
            secondStudent.Id = 100;
            secondStudent.Marks = new[] { 80, 100, 90 };

            Assert.IsTrue(Comparer.AreSimilar(firstStudent, secondStudent));
        }

        [TestMethod]
        public void ForNonSimilarClassObject1()
        {
            var firstStudent = new Student();
            var secondStudent = new Student();
            firstStudent.Name = "John";
            firstStudent.Id = 1000;
            firstStudent.Marks = new[] { 80, 90, 100 };

            secondStudent.Name = "John";
            secondStudent.Id = 100;
            secondStudent.Marks = new[] { 80, 100, 90 };

            Assert.IsFalse(Comparer.AreSimilar(firstStudent, secondStudent));
        }

        [TestMethod]
        public void ForNonSimilarClassObject2()
        {
            var firstStudent = new Student();
            var secondStudent = new Student();
            firstStudent.Name = "John Doe";
            firstStudent.Id = 100;
            firstStudent.Marks = new[] { 80, 90, 100 };

            secondStudent.Name = "John";
            secondStudent.Id = 100;
            secondStudent.Marks = new[] { 80, 100, 90 };

            Assert.IsFalse(Comparer.AreSimilar(firstStudent, secondStudent));
        }

        [TestMethod]
        public void ForNonSimilarClassObject3()
        {
            var firstStudent = new Student();
            var secondStudent = new Student();
            firstStudent.Name = "John";
            firstStudent.Id = 100;
            firstStudent.Marks = new[] { 80, 90, 100 };

            secondStudent.Name = "John";
            secondStudent.Id = 100;
            secondStudent.Marks = new[] { 80, 60, 90 };

            Assert.IsFalse(Comparer.AreSimilar(firstStudent, secondStudent));
        }
    }
}
