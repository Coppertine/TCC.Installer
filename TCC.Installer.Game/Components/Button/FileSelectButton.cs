using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components.Button
{
    public class FileSelectButton : CompositeDrawable
    {
        private const float rightMargin = 10.0f;

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore store)
        {
            Texture folderButton = store.Get("Folder Button");
            Size = folderButton.Size / 2;
            AddInternal(new Sprite
            {
                Texture = folderButton,
                Anchor = osu.Framework.Graphics.Anchor.CentreRight,
                Origin = osu.Framework.Graphics.Anchor.CentreRight,
                Margin = new MarginPadding(10),
                Size = folderButton.Size / 2
            });
        }

        protected override bool OnClick(ClickEvent e)
        {
            Logger.Log("Clicked on Folder Icon");

            return true;
        }
    }
}
