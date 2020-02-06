﻿using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components.UI
{
    public class FadeSearchContainer : SearchContainer
    {
        public override void Add(Drawable drawable)
        {
            // I don't like the way the drawables enter the container, something must be done here too
            // The fade is barely noticeable because of this effect
            // ~ AlFas
            var finalAlpha = drawable.Alpha;
            drawable.Alpha = 0;
            base.Add(drawable);
            drawable.FadeTo(finalAlpha, 100, Easing.OutQuint);
        }
        public override bool Remove(Drawable drawable)
        {
            drawable.FadeTo(0, 100, Easing.InQuint).OnComplete(HandleRemovalAnimationCompletion);
            return false;
        }

        private void HandleRemovalAnimationCompletion(Drawable drawable) => base.Remove(drawable);
    }

}
