using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SampleViewController:ViewController
    {
        SimpleAction create10Records;
        SimpleAction actionOnlyEnableOnDetailView;
        /// <summary>
        /// <para>Creates an instance of the <see cref="SampleViewController"/> class.</para>
        /// </summary>
        public SampleViewController()
        {
            create10Records = new SimpleAction(this, "Create10Records","View",new SimpleActionExecuteEventHandler(Create10RecordsExecute));


            actionOnlyEnableOnDetailView = new SimpleAction(this, "ActionOnlyEnableOnDetailView", "View", new SimpleActionExecuteEventHandler(DoNothing));
            actionOnlyEnableOnDetailView.TargetViewType = ViewType.ListView;
        }

        private void DoNothing(object sender, SimpleActionExecuteEventArgs e)
        {
            
        }

        private void Create10RecordsExecute(object sender, SimpleActionExecuteEventArgs e)
        {
            for (int i = 0; i <= 9; i++)
            {
                this.ObjectSpace.CreateObject<SampleDomainObject>().Number = i;
            }
            if (this.ObjectSpace.IsModified)
                this.ObjectSpace.CommitChanges();
        }

        public SimpleAction Create10Records { get => create10Records; set => create10Records = value; }
        public SimpleAction ActionOnlyEnableOnDetailView { get => actionOnlyEnableOnDetailView; set => actionOnlyEnableOnDetailView = value; }
    }
}
