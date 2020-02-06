using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components.UI.FileDialogComponents;
using TCC.Installer.Game.Screen;

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
                Anchor = Anchor.CentreRight,
                Origin = Anchor.CentreRight,
                Margin = new MarginPadding(10),
                Size = folderButton.Size / 2
            });
        }

        protected override bool OnClick(ClickEvent e)
        {
            Logger.Log("Clicked on Folder Icon");
            GetSelectedFolderFromDialog();
            return true;
        }

        //public Bindable<OpenFileDialog> OpenFileDialogBindable =>  mainScreen.OpenFileDialogBindable;

        private void GetSelectedFolderFromDialog()
        {
            //OpenFileDialogBindable.Value.ToggleVisibility();
        }
    }
}
