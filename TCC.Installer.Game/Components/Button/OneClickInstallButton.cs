using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Logging;
using osuTK;
using osuTK.Graphics;
using System;
using TCC.Installer.Game.Components.UI;
using TCC.Installer.Game.Graphics;

namespace TCC.Installer.Game.Components
{
    public class OneClickInstallButton : BasicButton
    {
        public SpriteText SpriteTextSecondary;
        public string SecondaryText { get; set; }

        public OneClickInstallButton()
            : base()
        {
            
            Colour = Color4.Gray;
            
        
            Logger.Log("Got the Sprite Text.");
            SpriteTextSecondary = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.TopCentre,
                Depth = -1,
                Font = TCCFont.GetFont(weight: FontWeight.Light, size: 19),
                Colour = Color4.White
            };
        }

        

        protected override SpriteText CreateText()
        {
            return new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.BottomCentre,
                Depth = -1,
                Font = TCCFont.GetFont(size: 39),
                Colour = Color4.White
            };
        }
    }
}