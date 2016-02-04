using System;
using System.Drawing;

namespace Utilities
{
    public class AquaButtonOK : AquaButton
    {
        public AquaButtonOK()
            : base()
        {
            _AllowAppearanceChanges = true; 
            this.Text = "&OK";
            this.BackColor = Color.DodgerBlue;
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
