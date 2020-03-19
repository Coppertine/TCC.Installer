using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using TCC.Installer.Game.Components.Button;

namespace TCC.Installer.Game.Components
{
    public class CustomSettingsButtonComponent : DrawSizePreservingFillContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(new CustomSettingsButton
            {
                Size = new Vector2(450, 100),
                Origin = Anchor.TopCentre,
            });

            
        }
    }
}