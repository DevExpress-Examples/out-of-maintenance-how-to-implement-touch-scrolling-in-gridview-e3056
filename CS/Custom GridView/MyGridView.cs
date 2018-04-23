using System;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors;

namespace MyXtraGrid {
	public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView {
		public MyGridView() : this(null) {}
		public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
			// put your initialization code here
		}
		protected override string ViewName { get { return "MyGridView"; } }

        protected override DevExpress.XtraGrid.Scrolling.ScrollInfo CreateScrollInfo()
        {
            return new MyScrollInfo(this);
        }

        
	}
}