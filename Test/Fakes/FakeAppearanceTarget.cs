using DevExpress.ExpressApp.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Fakes
{
    public class FakeAppearanceTarget : System.ComponentModel.INotifyPropertyChanged, IAppearanceEnabled, IAppearanceFormat, IAppearanceVisibility
    {
        public FakeAppearanceTarget()
        {
            //Defining default apperance
            ResetAllApperance();

            PropertyChanged += FakeAppearanceTarget_PropertyChanged;
        }

        private void ResetApperance()
        {
            this.ResetBackColor();
            this.ResetFontColor();
            this.ResetFontStyle();
        }

        private void FakeAppearanceTarget_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           


            if (e.PropertyName==nameof(IAppearanceFormat.BackColor) || e.PropertyName == nameof(IAppearanceFormat.FontColor) || e.PropertyName == nameof(IAppearanceFormat.FontStyle))
            {
                IAppearanceFormatApplied = true;
                RuleApplied = true;
            }
            if (e.PropertyName == nameof(IAppearanceEnabled.Enabled))
            {
                IAppearanceEnabledApplied = true;
                RuleApplied = true;
            }
            if (e.PropertyName == nameof(IAppearanceVisibility.Visibility))
            {
                IAppearanceVisibilityApplied = true;
                RuleApplied = true;
            }
        }

        /// <summary>
        /// True if the rule was applied otherwise false
        /// </summary>
        public bool RuleApplied { get; set; }
        /// <summary>
        /// True if any of the properties exposed by IAppearanceFormatApplied changed
        /// </summary>
        public bool IAppearanceFormatApplied { get; set; }
        /// <summary>
        /// True if any of the properties exposed by IAppearanceVisibilityApplied changed
        /// </summary>
        public bool IAppearanceVisibilityApplied { get; set; }

        /// <summary>
        /// True if any of the properties exposed by IAppearanceEnabledApplied changed
        /// </summary>
        public bool IAppearanceEnabledApplied { get; set; }
        #region IAppearanceEnabled Members

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        bool enabled;
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (enabled == value)
                {
                    return;
                }

                enabled = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Enabled)));
            }
        }

        FontStyle fontStyle;
        public FontStyle FontStyle
        {
            get
            {
                return fontStyle;
            }
            set
            {
                if (fontStyle == value)
                {
                    return;
                }

                fontStyle = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(FontStyle)));
            }
        }
        Color fontColor;
        public Color FontColor
        {
            get
            {
                return fontColor;
            }
            set
            {
                if (fontColor == value)
                {
                    return;
                }

                fontColor = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(FontColor)));
            }
        }
        Color backColor;
        public Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                if (backColor == value)
                {
                    return;
                }

                backColor = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(BackColor)));
            }
        }

        public void ResetBackColor()
        {
            BackColor = Color.Transparent;
        }

        public void ResetEnabled()
        {
            Enabled = true;
        }

        public void ResetFontColor()
        {
            FontColor = Color.Black;
        }

        public void ResetFontStyle()
        {
            FontStyle = FontStyle.Regular;
        }
        #endregion



        public void ResetAllApperance()
        {
            ResetApperance();
            ResetEnabled();
            ResetVisibility();
            RuleApplied = false;
        }

        #region IAppearanceVisibility Members
        public void ResetVisibility()
        {
            this.Visibility = ViewItemVisibility.Show;
        }

        ViewItemVisibility visibility;
        public ViewItemVisibility Visibility
        {
            get => visibility; set
            {
                if (visibility == value)
                {
                    return;
                }

                visibility = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Visibility)));
            }
        }
        #endregion
    }
}
