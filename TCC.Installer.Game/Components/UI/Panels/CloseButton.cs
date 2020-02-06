using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using System;

namespace TCC.Installer.Game.Components.UI.Panels
{
    public class CloseButton : BasicButton
    {
        public CloseButton()
        {
            AddInternal(new SpriteIcon
            {
                Icon = FontAwesome.Regular.WindowClose,
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                RelativeSizeAxes = Axes.Both
            });
        }
    }
}