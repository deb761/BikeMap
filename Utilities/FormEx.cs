using System;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public class FormEx: Form
    {
        public FormEx()
            : base()
        {
            base.BackColor = Color.Ivory;
            base.Font = Defaults.Font;
        }

        protected bool _AllowAppearanceChanges;
        public bool AllowAppearanceChanges
        {
            get { return _AllowAppearanceChanges; }
            set { _AllowAppearanceChanges = value; }
        }

        public override Color BackColor
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
