using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
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
            Strategy = DrawSizePreservationStrategy.Average;
            //AddInternal();
        }
    }
}
