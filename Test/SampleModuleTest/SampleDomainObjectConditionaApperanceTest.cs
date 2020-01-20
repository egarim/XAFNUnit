using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SampleModuleTest
{
 
    [TestFixture]
    public class SampleDomainObjectConditionaApperanceTest : TestBase
    {

        [SetUp]
        public void SetUp()
        {

        }

     

 

        [Test]
        public void When_SampleDomainObjectNumberGreaterThan5_Expect_RuleToBeApplied_Win()
        {

            var os = this.AspApp.CreateObjectSpace();
            var Instance = os.CreateObject<SampleDomainObject>();
            Instance.Number = 7;
            Assert.AreEqual(this.EvaluateApperanceRuleForDetailView(this.AspApp, Instance, os, "RedColor"),true);
        }


        [Test]
        public void When_SampleDomainObjectNumberLessThan5_Expect_RuleToBeApplied_Win()
        {

            var os = this.AspApp.CreateObjectSpace();
            var Instance = os.CreateObject<SampleDomainObject>();
            Instance.Number = 4;
            Assert.AreEqual(this.EvaluateApperanceRuleForDetailView(this.AspApp, Instance, os, "RedColor"), false);
        }


    }
}
