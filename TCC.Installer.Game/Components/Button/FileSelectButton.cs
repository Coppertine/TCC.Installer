using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Platform;
using System;
using TCC.Installer.Game.Components.UI.FileDialogComponents;
using TCC.Installer.Game.Screen;

namespace TCC.Installer.Game.Components.Button
{
    public class FileSelectButton : CompositeDrawable
    {        

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
            OpenDialog(MainScreen.OpenFileDialogBindable, (string filePath) =>
            {
                Logger.Log($"Got {filePath}");
            });
            return true;
        }



        private void OpenDialog<T>(Bindable<T> bindable, Action<string> onFileSelected) where T : FileDialog
        {

            bindable.Value.ToggleVisibility();

            bindable.Value.OnFileSelected += onFileSelected;

        }

    }
}
