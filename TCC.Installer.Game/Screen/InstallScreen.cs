using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Text;


namespace TCC.Installer.Game.Screen
{
    public class InstallScreen : osu.Framework.Screens.Screen
    {

        [BackgroundDependencyLoader]
        private void Load()
        {
            AddInternal(new SpriteText
            {
                Text = "Install Screen"
            });

            MainScreen.clientBindable.Value.SetPresence(
                new DiscordRPC.RichPresence
                {
                    Details = "Downloading",
                    State = "Episode 1",

                });
        }
    }
}
