using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Xpo;
using System;

namespace Test
{
    public class TestApplicationWin : WinApplication
    {
        //protected override LayoutManager CreateLayoutManagerCore(bool simple)
        //{
        //    return null;
        //}

        public TestApplicationWin()
        {
            this.DatabaseVersionMismatch += TestApplication_DatabaseVersionMismatch;
        }

        private void TestApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
        {
            e.Updater.Update();
            e.Handled = true;
        }
     
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            //HACK in case we need the security system
            //args.ObjectSpaceProviders.Add(new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, XPObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection, true), false));

            XPObjectSpaceProvider objectSpaceProvider =
               new XPObjectSpaceProvider(new MemoryDataStoreProvider());

            args.ObjectSpaceProviders.Add(objectSpaceProvider);
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }
    }
}