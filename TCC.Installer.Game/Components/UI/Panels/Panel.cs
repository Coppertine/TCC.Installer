using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components.UI.Panels
{
    public class Panel : FocusedOverlayContainer
    {
        private SpriteText text;


        public bool AllowDrag = true;
        public bool LockDrag = false;

        protected virtual string Name
        {
            get => (string)text?.Text ?? "";
            set => text.Text = value;
        }

        public Panel()
        {
            Children = new Drawable[]
            {
                //To avoid making both Pin and Close disappear
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    CornerRadius = 10,
                    Masking = true,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = GDEColors.FromHex("151515")
                        },
                    }
                },
                new FillFlowContainer
                {
                    Depth = -10,
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Direction = FillDirection.Horizontal,
                    AutoSizeAxes = Axes.Both,
                    Margin = new MarginPadding
                    {
                        Top = 17,
                        Right = 17
                    },
                    Children = new Drawable[]
                    {
                        new CloseButton
                        {
                            Origin = Anchor.Centre,
                            Anchor = Anchor.TopRight,
                            Size = new Vector2(20),
                            Colour = GDEColors.FromHex("424242"),
                            Margin = new MarginPadding
                            {
                                Horizontal = 5,
                                Vertical = 7
                            },
                            Action = Hide
                        },

                    }
                },
                text = new SpriteText
                {
                    Text = Name,
                    Margin = new MarginPadding
                    {
                        Horizontal = 5,
                        Vertical = 2
                    }
                }
            };
        }

        protected override void LoadComplete()
        {
            Scale = new Vector2(1, 0);

            base.LoadComplete();
        }

        protected override void PopIn()
        {
            ClearTransforms();

            this.ScaleTo(new Vector2(1, 1), 500, Easing.OutExpo);
            base.PopIn();
        }
        protected override void PopOut()
        {
            ClearTransforms();

            this.ScaleTo(new Vector2(1, 0), 500, Easing.OutExpo);
            base.PopIn();
        }

        protected override void OnDrag(DragEvent e)
        {
            if (AllowDrag || !LockDrag)
            {
                Position += e.Delta;
            }
            else
            { }
        }
        protected override bool OnDragStart(DragStartEvent e) => AllowDrag && !LockDrag;
        protected override void OnDragEnd(DragEndEvent e) { }
    }
}
