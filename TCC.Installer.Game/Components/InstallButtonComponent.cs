using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using TCC.Installer.Game.Components.UI;

namespace TCC.Installer.Game.Components
{
    internal class InstallButtonComponent : Container
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(new OneClickInstallButton()
            {
                Text = "ONE-CLICK",
                SecondaryText = "INSTALLATION",
                Size = new Vector2(600,72),
                Origin = Anchor.TopCentre,
            });
        }
    }
}