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
    public class FakeAppearanceTarget : System.ComponentModel.INotifyPropertyChanged, IAppearanceEnabled, IAppearanceFormat//, IAppearanceVisibility
    {
        public FakeAppearanceTarget()
        {
            PropertyChanged += FakeAppearanceTarget_PropertyChanged;
        }

        private void FakeAppearanceTarget_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           
            if (e.PropertyName==nameof(IAppearanceFormat.BackColor) || e.PropertyName == nameof(IAppearanceFormat.FontColor) || e.PropertyName == nameof(IAppearanceFormat.FontStyle))
            {
                IAppearanceFormatApplied = true;
                RuleApplied = true;
            }
        }

        public bool RuleApplied { get; set; }

        public bool IAppearanceFormatApplied { get; set; }


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
    }
}
