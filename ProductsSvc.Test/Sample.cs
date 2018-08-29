using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using NUnit.DeepObjectCompare;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ProductsSvc.Test
{
    [TestFixture]
    public class Sample
    {


        static object[] TestDataSample =
        {
            new object[] { TestData.GetActualCustomer(), TestData.GetExceptedCustomer() }
        };
        [Test]
        public void sampleTest()
        {
            //Assign
            int a = 10;
            int b = 10;

            //Action
            int sum = a + b;
            //Assert

            Assert.AreEqual(20, sum);
        }

        [TestCase(10, 10, 20)]
        [TestCase(5, 5, 10)]
        public void sampleTestWithParameter(int a, int b, int excepted)
        {
          
            int sum = a + b;
           

            Assert.AreEqual(excepted, sum);
        }

        [Test]
        public void sampleObjectCompare()
        {
            var actual = TestData.GetActualCustomer();
            var excepted = TestData.GetActualCustomer();
           AssertHelper.PropertyValuesAreEquals(actual, excepted);
           
        }

        [Test, TestCaseSource("TestDataSample")]
        public void sampleObjectCompareWithParameter(Customer actual, Customer excepted)
        {
          
            AssertHelper.PropertyValuesAreEquals(actual, excepted);
         
        }

        [Test, TestCaseSource(typeof(TestData), "CustomerTestCases")]
        public void sampleObjectCompareWithParameter1(Customer actual, Customer excepted)
        {
          
            AssertHelper.PropertyValuesAreEquals(actual, excepted);
           
        }

        [Test, TestCaseSource(typeof(TestData), "NumberTestCases")]
        public int SampleWithParamter(int n, int d)
        {
            return n / d;
        }

        [Test]
        public void sampleObjectDEEPCompare()
        {
            var actual = TestData.GetActualCustomer();
            var excepted = TestData.GetActualCustomer();
            //excepted.Age = 123;
            Assert.That(actual, NUnit.DeepObjectCompare.Is.DeepEqualTo(excepted));
            
        }
        [Test]
        public void JSOnAssert()
        {
             JObject actual = JObject.Parse(File.ReadAllText(@"D:\study\TDD\ProductsSvc\ProductsSvc.Test\json1.json"));
            JObject excepted = JObject.Parse(File.ReadAllText(@"D:\study\TDD\ProductsSvc\ProductsSvc.Test\json2.json"));

            

            Assert.IsTrue(JToken.DeepEquals(actual, excepted),
                              $"expected: {excepted}\n" +
                              $"actual: {actual}");
        }
        [Test]
        public void XMLAssert()
        {
            string x1 = File.ReadAllText(@"D:\study\TDD\ProductsSvc\ProductsSvc.Test\note.xml");
            string x2 = File.ReadAllText(@"D:\study\TDD\ProductsSvc\ProductsSvc.Test\note1.xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(x1);

            XmlDocument xd1 = new XmlDocument();
            xd1.LoadXml(x2);
            Assert.That(xd, NUnit.DeepObjectCompare.Is.DeepEqualTo(xd1));
        }


    }
}
