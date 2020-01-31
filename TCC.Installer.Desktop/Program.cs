// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Platform;
using osu.Framework;
using TCC.Installer.Game;

namespace TCC.Installer.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"TCC.Installer"))
            using (osu.Framework.Game game = new TCCInstallerGame())
                host.Run(game);
        }
    }
}
