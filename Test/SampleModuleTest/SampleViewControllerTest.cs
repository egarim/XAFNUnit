using NUnit.Framework;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Win.SystemModule;
using System.Linq;
using System;

namespace Test.SampleModuleTest
{
    [TestFixture]
    public class SampleViewControllerTest : TestBase
    {
      
        [SetUp]
        public void SetUp()
        {
         
        }

        [Test]
        public void When_Create10RecordsDoExecute_Expect_ResultCountIs10_Web()
        {
            var Controller = this.SetupListViewForController<SampleViewController, SampleDomainObject>(this.AspApp, true);
            Controller.Create10Records.DoExecute();
            var Count = this.AspApp.CreateObjectSpace().GetObjectsCount(typeof(SampleDomainObject), null);
            Assert.AreEqual(Count, 10);
        }

        [Test]
        public void When_ListViewCreated_Expect_ActionOnlyEnableOnDetailViewShouldBeActive_Asp()
        {
            var Controller = this.SetupListViewForController<SampleViewController, SampleDomainObject>(this.AspApp, true);
           
            Assert.AreEqual(Controller.ActionOnlyEnableOnDetailView.Active.ResultValue, true);
        }
        [Test]
        public void When_ListViewCreated_Expect_ActionOnlyEnableOnDetailViewShouldBeInactive_Asp()
        {
            var Controller = this.SetupDetailViewControllerForNewObject<SampleViewController, SampleDomainObject>(this.AspApp, true);

            Assert.AreEqual(Controller.ActionOnlyEnableOnDetailView.Active.ResultValue, false);
        }

        [Test]
        public void When_ListViewCreated_Expect_ActionOnlyEnableOnDetailViewShouldBeInactive_AspNew()
        {

            var os = this.AspApp.CreateObjectSpace();
            var Instance=os.CreateObject<SampleDomainObject>();
            Instance.Number = 7;
            var Controller = this.SetupDetailViewControllerForExistingObject<SampleViewController>(this.AspApp, Instance, os);

            DetailView detailView = (Controller.View as DetailView);
            var Items = detailView.Items;
            var ViewItem= detailView.FindItem("Number");
          
            var Control= ViewItem.Control;

            Assert.AreEqual(Controller.ActionOnlyEnableOnDetailView.Active.ResultValue, false);
        }


        [Test]
        public void When_Create10RecordsDoExecute_Expect_ResultCountIs10_Win()
        {
           var Controller= this.SetupListViewForController<SampleViewController, SampleDomainObject>(this.WinApp, true);
           Controller.Create10Records.DoExecute();
           var Count= this.WinApp.CreateObjectSpace().GetObjectsCount(typeof(SampleDomainObject), null);
           Assert.AreEqual(Count, 10);
        }

     
    }
}
