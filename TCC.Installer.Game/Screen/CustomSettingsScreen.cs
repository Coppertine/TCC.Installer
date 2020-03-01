using osu.Framework.Allocation;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components.CustomSettings;
using osu.Framework.Graphics;
using osuTK;

namespace TCC.Installer.Game.Screen
{
    public class CustomSettingsScreen : osu.Framework.Screens.Screen
    {
        CustomSettingsContainer settingsContainer;
       
        [BackgroundDependencyLoader]
        private void load()
        {
            settingsContainer = new CustomSettingsContainer()
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both
            };
        }
        //
    }
}
