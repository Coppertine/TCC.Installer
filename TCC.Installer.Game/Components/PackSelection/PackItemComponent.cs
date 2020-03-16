using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Graphics;
using TCC.Installer.Game.Functions.General;

namespace TCC.Installer.Game.Components.PackSelection
{
    public class PackItemComponent : ClickableContainer
    {
        public string DisplayName { get; set; }

        public Color4 DisplayColour { get; set; }
        /// <summary>
        /// The size of the pack preset.
        /// </summary>
        public long PackSize { get; set; }

        private SpriteText PackSpriteText;
        private SpriteText PackSizeSpriteText;

        private Box ItemBox;

        private Anchor anchorPosition;

        [BackgroundDependencyLoader]
        private void load()
        {


            anchorPosition = Anchor;

            float xPositionBox = anchorPosition != Anchor.Centre ?
                            anchorPosition == Anchor.CentreLeft ?
                            -1 * (800 / 2) : (800 / 2) : 0;
            float xSize = 801 / 3;

            AddInternal(
                ItemBox = new Box
                {
                    Size = new osuTK.Vector2(x: xSize, y: 111),
                    Anchor = Anchor.Centre,
                    Origin = anchorPosition,
                    Position = new osuTK.Vector2(x: xPositionBox, y: 0),
                    Colour = DisplayColour,
                }
            );

            

            AddInternal(
                PackSpriteText = new SpriteText
                {
                    Text = DisplayName.ToUpper(),
                    Font = TCCFont.GetFont(weight: FontWeight.Medium, size: 49),
                    Anchor = anchorPosition,
                    Origin = Anchor.Centre,
                                        
                }
            );

            AddInternal(
                PackSizeSpriteText = new SpriteText
                {
                    Text = SizeConvert.SizeSuffix(PackSize),
                    Font = TCCFont.GetFont(weight: FontWeight.Thin, size: 49),
                    Anchor = anchorPosition,
                    Origin = Anchor.Centre,
                }
            );
            // Positions, since the only way to make sure it's in the middle of the box,
            // is to calculate the draw width, which is after the entire shape is loaded.
            PackSpriteText.Position =
                new osuTK.Vector2(
                        x: (ItemBox.DrawWidth / 2) * (anchorPosition == Anchor.Centre ? 0 : anchorPosition == Anchor.CentreLeft ? 1 : -1),
                        y: PackSizeSpriteText.DrawHeight / 2 * -1);
            PackSizeSpriteText.Position =
                new osuTK.Vector2(
                        x: (ItemBox.DrawWidth / 2) * (anchorPosition == Anchor.Centre ? 0 : anchorPosition == Anchor.CentreLeft ? 1 : -1),
                        y: PackSpriteText.DrawHeight / 2);
        }
        
        protected override bool OnClick(ClickEvent e) => base.OnClick(e);

        protected override bool OnHover(HoverEvent e) => base.OnHover(e);

        protected override void OnHoverLost(HoverLostEvent e) => base.OnHoverLost(e);
    }
}
