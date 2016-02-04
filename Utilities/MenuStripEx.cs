using System;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public class MenuStripEx : MenuStrip
    {
        public MenuStripEx(): base()
        {
            base.BackColor = Color.LemonChiffon;
            base.Font = Defaults.Font; // new Font(Defaults.Font, FontStyle.Bold);
        }

        protected bool _AllowAppearanceChanges;
        public bool AllowAppearanceChanges
        {
            get { return _AllowAppearanceChanges; }
            set { _AllowAppearanceChanges = value; }
        }

        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (_AllowAppearanceChanges)
                    base.BackColor = value;
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                if (_AllowAppearanceChanges)
                    base.Font = value;
            }
        }
    }
}
