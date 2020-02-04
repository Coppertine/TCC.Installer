using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components;

namespace TCC.Installer.Game.Screen
{
 
    public class MainScreen : osu.Framework.Screens.Screen
    {
        private GridContainer TopBarContainer;
        private Container backgroundSpriteContainer;
        private Container FormContainer;
        
        public MainScreen()
        {
            RelativePositionAxes = Axes.Both;
            RelativeSizeAxes = Axes.Both;
            InternalChildren = new Drawable[]
            {
                backgroundSpriteContainer = new Container
                {
                    Child = new BackgroundComponent(),
                    RelativeSizeAxes = Axes.Both,
                    Anchor=Anchor.TopLeft
                },
                FormContainer = new BasicSelectionComponent()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both
                }
                
            };
        }

       

    }
}
