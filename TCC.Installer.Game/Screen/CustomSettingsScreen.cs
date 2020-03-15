using osu.Framework.Allocation;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components.CustomSettings;
using osu.Framework.Graphics;
using osuTK;
using osu.Framework.Screens;

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

        public override bool OnExiting(IScreen next)
        {
   

            this.MoveTo(new Vector2(0, DrawSize.Y), 1500, Easing.OutQuint);
            return base.OnExiting(next);
        }

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);
            this.MoveTo(new Vector2(0, DrawSize.Y));
            this.MoveTo(Vector2.Zero, 1500, Easing.OutQuint);
            this.FadeIn(1000);
        }
        public override void OnSuspending(IScreen next)
        {
           base.OnSuspending(next);
            this.MoveTo(new Vector2(0, DrawSize.Y), 1500, Easing.OutQuint);
        }

        public override void OnResuming(IScreen last)
        {
           
            base.OnResuming(last);
            this.MoveTo(Vector2.Zero, 1500, Easing.OutQuint);
        }

        //
    }
}
