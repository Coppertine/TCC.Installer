using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Screen;

namespace TCC.Installer.Game.Components.Button
{
    public class ScrollDownButton : ClickableContainer
    {
        private Texture ChevronTexture;
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore store)
        {
            Action = () =>
            {
                MainScreen.FormContainer.MoveToY(-1050, 700, Easing.OutQuint);
            };

            ChevronTexture = store.Get("chevron");
            AddInternal(new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = ChevronTexture,
                Size = new Vector2(50, 50),
            });
            
        }
    }
}
