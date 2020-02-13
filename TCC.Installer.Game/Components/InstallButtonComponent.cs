using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using TCC.Installer.Game.Components.UI;
using TCCInstaller.Game;

namespace TCC.Installer.Game.Components
{
    internal class InstallButtonComponent : Container
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(new OneClickInstallButton()
            {
                Text = GlobalStore.GetOneClickText().ToUpper(),
                SecondaryText = "INSTALLATION",
                Size = new Vector2(600,100),
                Origin = Anchor.TopCentre,
                BackgroundColour = new osuTK.Graphics.Color4(0,0,0,0.7f)
            });
        }
    }
}