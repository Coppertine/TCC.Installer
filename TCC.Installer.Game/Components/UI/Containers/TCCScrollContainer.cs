using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osuTK.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components.UI.Containers
{
    public partial class TCCScrollContainer : ScrollContainer<Drawable>
    {
        private bool mouseScrollBarDragging;

        /// <summary>Allows controlling the scroll bar from any position in the container using the right mouse button. Uses the value of <see cref="DistanceDecayOnRightMouseScrollbar"/> to smoothly scroll to the dragged location.</summary>
        public bool RightMouseScrollbar = false;

        /// <summary>Controls the rate with which the target position is approached when performing a relative drag. Default is 0.02.</summary>
        public double DistanceDecayOnRightMouseScrollbar = 0.02;

        // Still does not affect Home and End buttons, only a per-framework level would change that
        public bool ScrollOnKeyDown { get; set; }

        protected override bool IsDragging => base.IsDragging || mouseScrollBarDragging;

        public TCCScrollContainer(Direction scrollDirection = Direction.Vertical)
            : base(scrollDirection) { }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (!ScrollOnKeyDown)
                return false;

            return base.OnKeyDown(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            if (ShouldPerformRightMouseScroll(e))
            {
                ScrollToRelative(e.MousePosition[ScrollDim]);
                return true;
            }

            return base.OnMouseDown(e);
        }

        protected override void OnDrag(DragEvent e)
        {
            if (mouseScrollBarDragging)
            {
                ScrollToRelative(e.MousePosition[ScrollDim]);
            }
            else 
            {
                base.OnDrag(e);
            }
        }
        protected override bool OnDragStart(DragStartEvent e)
        {
            if (ShouldPerformRightMouseScroll(e))
                return mouseScrollBarDragging = true;

            return base.OnDragStart(e);
        }
        protected override void OnDragEnd(DragEndEvent e)
        {
            if (mouseScrollBarDragging)
            {
                if (!(mouseScrollBarDragging = false)) { }
                else
                {
                    base.OnDragEnd(e);
                }
            }
        }

        protected override ScrollbarContainer CreateScrollbar(Direction direction) => new TCCScrollbar(direction);

        private bool ShouldPerformRightMouseScroll(MouseButtonEvent e) => RightMouseScrollbar && e.Button == MouseButton.Right;

        private void ScrollToRelative(float value) => ScrollTo(Clamp((value - Scrollbar.DrawSize[ScrollDim] / 2) / Scrollbar.Size[ScrollDim]), true, DistanceDecayOnRightMouseScrollbar);
    }
}
