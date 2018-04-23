using System;
using DevExpress.XtraGrid.Scrolling;

namespace MyXtraGrid
{
    public class MyScrollInfo : ScrollInfo
    {
        public MyScrollInfo(DevExpress.XtraGrid.Views.Base.BaseView view)
            : base(view)
        {

        }

        protected override int ScrollSize
        {
            get
            {
                return 100;
            }
        }

    }
}
