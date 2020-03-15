using DiscordRPC;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using System;
using System.Collections.Generic;
using System.Text;


namespace TCC.Installer.Game.Screen
{
    public class InstallScreen : osu.Framework.Screens.Screen
    {
        private Bindable<DiscordRpcClient> richPrecenceBindable = MainScreen.clientBindable;
        public Action Entered;
        public Action Suspended;
        public Action Resumed;
        public Action Exited;

        public IScreen EnteredFrom;
        public IScreen ExitedTo;
        public IScreen SuspendedTo;
        public IScreen ResumedFrom;

        private const int transition_time = 500;


        [BackgroundDependencyLoader]
        private void Load()
        {
            AddInternal(new SpriteText
            {
                Text = "Install Screen"
            });


            richPrecenceBindable.Value.SetPresence(
                new RichPresence
                {
                    Details = "Downloading",
                    State = "Episode 1",

                });
        }
        
        public override void OnEntering(IScreen LastScreen)
        {
            EnteredFrom = LastScreen;
            Entered?.Invoke();
            base.OnEntering(LastScreen);
            Scale = new Vector2(2f, 2f);
            this.Alpha = 0;
            this.FadeIn(1000);
            this.ScaleTo(new Vector2(1, 1), 1000, Easing.OutQuint);
            


        }
    }
}
