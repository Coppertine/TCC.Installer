using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;
using osu.Framework.Graphics.UserInterface;

namespace TCC.Installer.Game.Components.UI
{
    public class TCCButton : BasicButton
    {
        public TCCButton()
            : base()
        {
            Height = 30;
            CornerRadius = 3;
            Masking = true;

            Colour = Color4.Gray;
        }


        protected override SpriteText CreateText()
        {
            return new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Depth = -1,
                Font = FrameworkFont.Regular,
                Colour = Color4.White
            };
        }
    }
}
