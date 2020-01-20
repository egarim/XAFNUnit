using DevExpress.ExpressApp.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Fakes
{
    public class FakeAppearanceTarget : IAppearanceEnabled
    {
        #region IAppearanceEnabled Members
        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        public void ResetEnabled()
        {
            Enabled = true;
        }
        #endregion
    }
}
