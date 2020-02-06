using osu.Framework.Graphics;
using osu.Framework.Testing;
using osuTK;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components.UI.FileDialogComponents;

namespace TCC.Installer.Game.Tests.Visual
{
    public class TestSceneFileDialog : TestScene
    {
        private OpenFileDialog openFileDialog;

        public TestSceneFileDialog()
        {
            Children = new Drawable[]
            {
                openFileDialog = new OpenFileDialog
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(0.8f),
                    Depth = -10
                },
            };

            openFileDialog.ToggleVisibility();
        }
    }

}
