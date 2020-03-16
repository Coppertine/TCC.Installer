using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Graphics;

namespace TCC.Installer.Game.Components.CustomSettings
{
    public class CustomSettingsContainer : DrawSizePreservingFillContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {

            AddRangeInternal(new Drawable[]
                {
                    new Box
                    {

                    }
                });
            
        }
    }
}
