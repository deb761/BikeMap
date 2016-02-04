using System;
using System.Drawing;

namespace Utilities
{
    public class AquaButtonCancel : AquaButton
    {
        public AquaButtonCancel()
            : base()
        {
            _AllowAppearanceChanges = true;
            this.Text = "&Abbrechen";
            this.BackColor = Color.OrangeRed;
            //_AllowAppearanceChanges = false;
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (_AllowAppearanceChanges)
                    base.Text = value;
            }
        }
    }
}
