using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace WindowsApplication1
{
    public class TouchScrollHelper
    {

        private readonly GridView _View;
        public TouchScrollHelper(GridView view)
        {
            _View = view;
            InitViewProperties();
        }

        private void InitViewProperties()
        {
            _View.OptionsBehavior.Editable = false;
            _View.GridControl.Cursor = Cursors.Hand;
            _View.OptionsSelection.EnableAppearanceFocusedRow = false;
            _View.OptionsSelection.EnableAppearanceFocusedCell = false;
            _View.FocusRectStyle = DrawFocusRectStyle.None;
            _View.OptionsView.ShowIndicator = false;
            _View.MouseDown += _View_MouseDown;
            _View.MouseMove += _View_MouseMove;
            _View.MouseUp += _View_MouseUp;
            _View.Layout += new EventHandler(_View_Layout);
        }

        void _View_Layout(object sender, EventArgs e)
        {
            IsDragging = false;
        }

        int startDragRowHandle = -1;
        int topRowIndex = -1;
        DateTime startTime;
        private int _TopRowDelta;
        private bool _IsDragging;
        public bool IsDragging
        {
            get { return _IsDragging; }
            set
            {
                _IsDragging = value;
                startTime = DateTime.MinValue;
            }
        }

        private int GetRowUnderCursor(Point location)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = _View.CalcHitInfo(location);
            if (hitInfo.InRow)
                return hitInfo.RowHandle;
            return GridControl.InvalidRowHandle;
        }
        private void CheckTime()
        {
            if (startTime == DateTime.MinValue)
                startTime = DateTime.Now;
        }
        private void CheckInertion()
        {
            if (startTime == DateTime.MinValue)
                return;
            DateTime currentTime = DateTime.Now;
            TimeSpan delta = currentTime - startTime;
            _TopRowDelta = _View.TopRowIndex - topRowIndex;
            int absValue = Math.Abs(_TopRowDelta);
            if (delta.TotalMilliseconds < 300 && absValue > 15)
            {
                DoInertion();
            }


        }
        private void DoInertion()
        {
            Timer inertionTimer = new Timer();
            inertionTimer.Interval = 25;
            inertionTimer.Tick += inertionTimer_Tick;
            inertionTimer.Start();
        }

        void inertionTimer_Tick(object sender, EventArgs e)
        {
            _View.TopRowIndex += _TopRowDelta;
            Timer timer = sender as Timer;
            timer.Interval += 25;
            if (timer.Interval == 200)
                timer.Stop();
        }

        private void DoScroll(int delta)
        {
            if (delta == 0)
                return;
            CheckTime();
            _View.TopRowIndex += delta;
        }

        void _View_MouseUp(object sender, MouseEventArgs e)
        {
            CheckInertion();
            IsDragging = false;
        }

        void _View_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                int newRow = GetRowUnderCursor(e.Location);
                if (newRow < 0)
                    return;
                int delta = startDragRowHandle - newRow;
                DoScroll(delta);
            }
        }

        void _View_MouseDown(object sender, MouseEventArgs e)
        {
            IsDragging = true;
            startDragRowHandle = GetRowUnderCursor(e.Location);
            topRowIndex = _View.TopRowIndex;
        }
    }
}
