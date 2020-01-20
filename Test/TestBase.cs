using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;

namespace Test
{
    public class TestBase
    {
        private TestApplicationWin winApp;
        private TestApplicationAsp aspApp;
        private List<ModuleBase> modules = SetupModules(null);

        public TestApplicationWin WinApp
        {
            get
            {
                if (winApp == null)
                {
                    winApp = new TestApplicationWin();
                    SetupApp(WinApp, new SystemWindowsFormsModule(), Modules);
                }
                   
                return winApp;
            }
        }
        public TestApplicationAsp AspApp
        {
            get
            {
                if (aspApp==null)
                { 
                    aspApp = new TestApplicationAsp();
                    SetupApp(AspApp, new SystemAspNetModule(), Modules);
                }
                return aspApp;
            }
        }

        public List<ModuleBase> Modules { get => modules; private set => modules = value; }

       
      

        private static List<ModuleBase> SetupModules(IList<Type> AdditionalExportedTypes)
        {
            List<ModuleBase> Modules = new List<ModuleBase>();
            SampleModule MainDemoModule = new SampleModule();

            Modules.Add(MainDemoModule);

            if (AdditionalExportedTypes == null)
                return Modules;

            foreach (Type type in AdditionalExportedTypes)
            {
                MainDemoModule.AdditionalExportedTypes.Add(type);
            }
         
            return Modules;
        }


        protected virtual T SetupListViewForController<T,P>(XafApplication App, bool IsRoot) where T : ViewController where P: PersistentBase
        {
            var controller = (T)Activator.CreateInstance(typeof(T));
            ListView ListView = App.CreateListView(typeof(P), IsRoot);
            Frame frame = App.CreateFrame(TemplateContext.ApplicationWindow);
            frame.SetView(ListView);
            frame.RegisterController(controller);
            return controller;
        }
        /// <summary>
        /// Setup a detail view for a new object and instantiate a controller        
        /// </summary>
        /// <typeparam name="T">The type of the view controller to instantiate</typeparam>
        /// <typeparam name="P">The type of the persistent object</typeparam>
        /// <param name="App">A decendent of a XAF application, this can be your own application or the provided TestApplicationAsp or TestApplicationWin</param>
        /// <param name="IsRoot"></param>
        /// <returns></returns>
        protected virtual T SetupDetailViewControllerForNewObject<T,P>(XafApplication App, bool IsRoot) where T : ViewController where P: PersistentBase
        {
            var controller = (T)Activator.CreateInstance(typeof(T));
            var ObjectSpace = App.CreateObjectSpace();
            var ObjectInstance = ObjectSpace.CreateObject<P>();
            var View = App.CreateDetailView(ObjectSpace,ObjectInstance, IsRoot);
            Frame frame = App.CreateFrame(TemplateContext.ApplicationWindow);
            //frame.CreateTemplate();
            frame.SetView(View);
            frame.RegisterController(controller);
            return controller;
        }
        /// <summary>
        /// Setup a detail view for an existing object and instantiate a controller
        /// </summary>
        /// <typeparam name="T">The type of the view controller to instantiate</typeparam>
        /// <param name="App">A decendent of a XAF application, this can be your own application or the provided TestApplicationAsp or TestApplicationWin</param>
        /// <param name="ObjectInstance">An instance of the persistent object you want to display on the detail view</param>
        /// <returns></returns>
        protected virtual T SetupDetailViewControllerForExistingObject<T>(XafApplication App, object ObjectInstance,IObjectSpace OwnerObjectSpace) where T : ViewController
        {
            var controller = (T)Activator.CreateInstance(typeof(T));
            var View = App.CreateDetailView(OwnerObjectSpace,ObjectInstance, true);
            Frame frame = App.CreateFrame(TemplateContext.ApplicationWindow);
            frame.SetView(View);
            frame.RegisterController(controller);
            return controller;
        }

        /// <summary>
        /// Execute the setup process for a Xaf application
        /// </summary>
        /// <param name="App">The Xaf application to setup</param>
        /// <param name="SystemModule">The system module for the Platform, this can be SystemWindowsFormsModule or SystemAspNetModule</param>
        /// <param name="Modules"></param>
        /// <returns></returns>
        public virtual XafApplication SetupApp(XafApplication App,ModuleBase SystemModule,List<ModuleBase> Modules)
        {


            App.Modules.Add(SystemModule);
            foreach (var Module in Modules)
            {
                Module.Setup(App);
                App.Modules.Add(Module);
            }
            App.Setup();
            return App;
        }
    }
}