﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class StringExtensions
    {

        // graphics/color mode ESC[1;2;...m
        private const string GraphicsRegex = @"(\x1b\[\d+(;\d+)*m)";

        // CSI escape sequences
        private const string CsiRegex = @"(\x1b\[\?\d+[hl])";

        // replace regex with .NET 6 API once available
        internal static readonly Regex AnsiRegex = new Regex($"{GraphicsRegex}|{CsiRegex}", RegexOptions.Compiled);
        public static string ToPlainText(this string output)
        {
            return AnsiRegex.Replace(output, string.Empty);
    }
    }
}
