using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    [Appearance("RedColor", AppearanceItemType = "ViewItem", TargetItems = "*",
    Criteria = "Number>5", Context = "DetailView", BackColor = "Red",
        FontColor = "Maroon", Priority = 2)]
    public class SampleDomainObject:BaseObject
    {
        /// <summary>
        /// <para>Used to initialize a new instance of a <see cref="SampleDomainObject"/> descendant, in a particular Session.</para>
        /// </summary>
        /// <param name="session">A DevExpress.Xpo.Session object which represents a persistent object&#39;s cache where the business object will be instantiated.</param>
        public SampleDomainObject(Session session) : base(session)
        {

        }

        /// <summary>
        /// <para>Creates a new instance of the <see cref="SampleDomainObject"/> class.</para>
        /// </summary>
        public SampleDomainObject()
        {

        }

        int number;

        public int Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }
    }
}
