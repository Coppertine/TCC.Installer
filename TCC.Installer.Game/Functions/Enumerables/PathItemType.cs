﻿using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components.UI.FileDialogComponents;

namespace TCC.Installer.Game.Functions.Enumerables
{
    /// <summary>Represents the type of an item in a path.</summary>
    public enum PathItemType
    {
        /// <summary>Represents a file.</summary>
        File,
        /// <summary>Represents a directory.</summary>
        Directory,
        /// <summary>Represents a volume.</summary>
        Volume,
    }
}
