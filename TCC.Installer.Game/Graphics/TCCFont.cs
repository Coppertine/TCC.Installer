﻿using osu.Framework.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Graphics
{
    public class TCCFont
    {
        /// <summary>
        /// The default font size.
        /// </summary>
        public const float DEFAULT_FONT_SIZE = 16;

        /// <summary>
        /// The default font.
        /// </summary>
        public static FontUsage Default => GetFont();

        /// <summary>
        /// Retrieves a <see cref="FontUsage"/>.
        /// </summary>
        /// <param name="typeface">The font typeface.</param>
        /// <param name="size">The size of the text in local space. For a value of 16, a single line will have a height of 16px.</param>
        /// <param name="weight">The font weight.</param>
        /// <param name="italics">Whether the font is italic.</param>
        /// <param name="fixedWidth">Whether all characters should be spaced the same distance apart.</param>
        /// <returns>The <see cref="FontUsage"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static FontUsage GetFont(Typeface typeface = Typeface.Ageo, float size = DEFAULT_FONT_SIZE, FontWeight weight = FontWeight.Medium, bool fixedWidth = false, bool italics = false)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return new FontUsage(GetFamilyString(typeface), size, GetWeightString(typeface, weight), italics, fixedWidth);
        }

        /// <summary>
        /// Retrieves the string representation of a <see cref="Typeface"/>.
        /// </summary>
        /// <param name="typeface">The <see cref="Typeface"/>.</param>
        /// <returns>The string representation.</returns>
        public static string GetFamilyString(Typeface typeface)
        {
            switch (typeface)
            {
                case Typeface.Ageo:
                    return "Ageo";
            }

            return null;
        }

        /// <summary>
        /// Retrieves the string representation of a <see cref="FontWeight"/>.
        /// </summary>
        /// <param name="typeface">The <see cref="Typeface"/>.</param>
        /// <param name="weight">The <see cref="FontWeight"/>.</param>
        /// <returns>The string representation of <paramref name="weight"/> in the specified <paramref name="typeface"/>.</returns>
        public static string GetWeightString(Typeface typeface, FontWeight weight)
            => GetWeightString(GetFamilyString(typeface), weight);

        /// <summary>
        /// Retrieves the string representation of a <see cref="FontWeight"/>.
        /// </summary>
        /// <param name="family">The family string.</param>
        /// <param name="weight">The <see cref="FontWeight"/>.</param>
        /// <returns>The string representation of <paramref name="weight"/> in the specified <paramref name="family"/>.</returns>
        public static string GetWeightString(string family, FontWeight weight)
            => weight.ToString();


    }

    public static class TCCFontExtensions
    {
        /// <summary>
        /// Creates a new <see cref="FontUsage"/> by applying adjustments to this <see cref="FontUsage"/>.
        /// </summary>
        /// <param name="usage">The base <see cref="FontUsage"/>.</param>
        /// <param name="typeface">The font typeface. If null, the value is copied from this <see cref="FontUsage"/>.</param>
        /// <param name="size">The text size. If null, the value is copied from this <see cref="FontUsage"/>.</param>
        /// <param name="weight">The font weight. If null, the value is copied from this <see cref="FontUsage"/>.</param>
        /// <param name="italics">Whether the font is italic. If null, the value is copied from this <see cref="FontUsage"/>.</param>
        /// <param name="fixedWidth">Whether all characters should be spaced apart the same distance. If null, the value is copied from this <see cref="FontUsage"/>.</param>
        /// <returns>The resulting <see cref="FontUsage"/>.</returns>
        public static FontUsage With(this FontUsage usage, Typeface? typeface = null, float? size = null, FontWeight? weight = null, bool? italics = null, bool? fixedWidth = null)
        {
            string familyString = typeface != null ? TCCFont.GetFamilyString(typeface.Value) : usage.Family;
            string weightString = weight != null ? TCCFont.GetWeightString(familyString, weight.Value) : usage.Weight;

            return usage.With(familyString, size, weightString, italics, fixedWidth);
        }
    }

    public enum Typeface
    {
        Ageo
    }

    public enum FontWeight
    {
        Light,
        Regular,     
        Medium,
        Thin
    }


}
