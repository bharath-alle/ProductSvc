using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSvc.Test
{
    public class TestData
    {
        public static IEnumerable CustomerTestCases
        {
            get
            {
                yield return new TestCaseData(GetActualCustomer(), GetExceptedCustomer());//.Returns(GetExceptedCustomer());
               // yield return new TestCaseData(12, 2).Returns(6);
              //  yield return new TestCaseData(12, 4).Returns(3);
              
            }
        }
        public static IEnumerable NumberTestCases
        {
            get
            {

                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);

            }
        }
        public static Customer GetActualCustomer()
        {
            return new Customer
            {
                Name = "test",
                Age = 33,
                Salary = 10000
            };
        }

        public static Customer GetExceptedCustomer()
        {
            return new Customer
            {
                Name = "test",
                Age = 33,
                Salary = 10000
            };
        }
       
    }
}
