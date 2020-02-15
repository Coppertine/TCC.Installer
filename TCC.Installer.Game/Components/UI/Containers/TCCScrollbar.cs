using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using osuTK.Input;

namespace TCC.Installer.Game.Components.UI.Containers
{
    public partial class TCCScrollContainer
    {
        protected class TCCScrollbar : ScrollbarContainer
        {
            private const float dimSize = 10;
            private const float margin = 3;

            private Color4 hoverColour;
            private Color4 defaultColour;
            private Color4 highlightColour;

            private readonly Box box;

            public TCCScrollbar(Direction scrollDir)
                : base(scrollDir)
            {
                Blending = BlendingParameters.Additive;

                CornerRadius = 5;
                Masking = true;
                Margin = new MarginPadding
                {
                    Horizontal = scrollDir == Direction.Vertical ? margin : 0,
                    Vertical = scrollDir == Direction.Horizontal ? margin : 0,
                };

                Child = box = new Box { RelativeSizeAxes = Axes.Both };

                ResizeTo(1);
            }

            [BackgroundDependencyLoader]
            private void load()
            {
                Colour = defaultColour = TCCColours.FromHex("888");
                hoverColour = TCCColours.FromHex("fff");
                highlightColour = TCCColours.FromHex("88b300");
            }

            public override void ResizeTo(float val, int duration = 0, Easing easing = Easing.None)
            {
                Vector2 size = new Vector2(dimSize)
                {
                    [(int)ScrollDirection] = val
                };
                this.ResizeTo(size, duration, easing);
            }

            protected override bool OnHover(HoverEvent e)
            {
                this.FadeColour(hoverColour, 100);
                return true;
            }
            protected override void OnHoverLost(HoverLostEvent e)
            {
                this.FadeColour(defaultColour, 100);
            }

            protected override bool OnMouseDown(MouseDownEvent e)
            {
                if (!base.OnMouseDown(e))
                    return false;

                box.FadeColour(highlightColour, 100);
                return true;
            }
            protected override void OnMouseUp(MouseUpEvent e)
            {
                if (e.Button != MouseButton.Left)
                { }
                else
                {
                    box.FadeColour(Color4.White, 100);
                    base.OnMouseUp(e);
                }
            }
        }
    }
}
