using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components;

namespace TCC.Installer.Game.Screen
{
    public class BackgroundScreen : osu.Framework.Screens.Screen
    {
        public static Container BackgroundSpriteContainer;

        // Workaround to making sure the background screen is still visable when the MainScreen is shown
        public override double LifetimeEnd => double.MaxValue;

        [BackgroundDependencyLoader]
        private void load()
        {
            
            RelativePositionAxes = Axes.Both;
            RelativeSizeAxes = Axes.Both;
            AddInternal(
                BackgroundSpriteContainer = new Container
                {
                    Child = new BackgroundComponent(),
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopLeft
                
            });
            AddInternal(new MenuBarComponent
            {
                Anchor = Anchor.TopLeft,
                Depth = -999
            });

            OnLoadComplete += BackgroundScreen_OnLoadComplete;
            
        }

        private void BackgroundScreen_OnLoadComplete(Drawable obj) => this.Push(TCCInstallerGame.mainScreen = new MainScreen());
    }
}
