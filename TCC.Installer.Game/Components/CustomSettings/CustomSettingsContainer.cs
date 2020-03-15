using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components.CustomSettings
{
    public class CustomSettingsContainer : DrawSizePreservingFillContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {

            AddInternal(new SpriteText { 
                Text = "helloworld", 
                Anchor = osu.Framework.Graphics.Anchor.Centre});
            
        }
    }
}
