using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Testing;
using TCC.Installer.Game.Components;

namespace TCC.Installer.Game.Tests.Visual
{
    [TestFixture]
    public class TestCaseTCCTextBox : TestScene
    {

        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(TCCTextBox),
        };

        [TestCase]
        public void TestTextBox() => createTextBox();

        private void createTextBox()
        {
            AddStep("create component", () =>
            {
                TCCTextBox component;

                Child = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Width = 500,
                    AutoSizeAxes = Axes.Y,
                    Child = component = new TCCTextBox
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        PlaceholderText = "This is definitely working as intended",
                        Text = "This is now workling"
                    }
                };

                
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.X,
                Padding = new MarginPadding { Left = 150, Right = 150 },
                Child = new TCCTextBox
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    PlaceholderText = "This is definitely working as intended",
                }
            };
        }
    }
}
