//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
using System;
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    public partial class NSWindow
    {
        /// <summary>
        ///   <para>The number of window levels reserved by Apple for internal use. Application frameworks such as Carbon and Cocoa use this constant during compilation.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGNumReservedWindowLevels = 16;

        /// <summary>
        ///   <para>The base key used to define window levels. Do not use.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGBaseWindowLevel = Int32.MinValue;

        /// <summary>
        ///   <para>The lowest available window level.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGMinimumWindowLevel = kCGBaseWindowLevel + 1;

        /// <summary>
        ///   <para>The level for the desktop.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGDesktopWindowLevel = kCGMinimumWindowLevel;

        /// <summary>
        ///   <para>The level for desktop icons.</para>
        ///   <para>Available in Mac OS X v10.1 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGDesktopIconWindowLevel = kCGMinimumWindowLevel + 20;

        /// <summary>
        ///   <para>The level of the backstop menu.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGBackstopMenuLevel = -20;

        /// <summary>
        ///   <para>The level for normal windows.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGNormalWindowLevel = 0;

        /// <summary>
        ///   <para>The level for floating windows.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGFloatingWindowLevel = 3;

        /// <summary>
        ///   <para>The level for torn off menus.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGTornOffMenuWindowLevel = 3;

        /// <summary>
        ///   <para>The level for the dock.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGDockWindowLevel = 20;

        /// <summary>
        ///   <para>The level for the menus displayed in the menu bar.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGMainMenuWindowLevel = 24;

        /// <summary>
        ///   <para>The level for status windows.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGStatusWindowLevel = 25;

        /// <summary>
        ///   <para>The level for modal panels.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGModalPanelWindowLevel = 8;

        /// <summary>
        ///   <para>The level for pop-up menus.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGPopUpMenuWindowLevel = 101;

        /// <summary>
        ///   <para>The level for a window being dragged.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGDraggingWindowLevel = 500;

        /// <summary>
        ///   <para>The level for screen savers.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGScreenSaverWindowLevel = 1000;

        /// <summary>
        ///   <para>The level for the cursor.</para>
        ///   <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGCursorWindowLevel = 2000;

        /// <summary>
        ///   <para>The level for overlay windows.</para>
        ///   <para>Available in Mac OS X v10.1 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGOverlayWindowLevel = 102;

        /// <summary>
        ///   <para>The level for help windows.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGHelpWindowLevel = 200;

        /// <summary>
        ///   <para>The level for utility windows.</para>
        ///   <para>Available in Mac OS X v10.1 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGUtilityWindowLevel = 19;

        ///// <summary>
        ///// 
        ///// </summary>
        //public static readonly NSInteger kCGAssistiveTechHighWindowLevel = 1500;

        /// <summary>
        ///   <para>The highest allowed window level.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger kCGMaximumWindowLevel = Int32.MaxValue - kCGNumReservedWindowLevels;

        /// <summary>
        ///   <para>The default level for NSWindow objects.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSNormalWindowLevel = kCGNormalWindowLevel;

        /// <summary>
        ///   <para>Useful for floating palettes.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSFloatingWindowLevel = kCGFloatingWindowLevel;

        /// <summary>
        ///   <para>Reserved for submenus. Synonymous with <see cref = "NSTornOffMenuWindowLevel" />, which is preferred.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSSubmenuWindowLevel = kCGTornOffMenuWindowLevel;

        /// <summary>
        ///   <para>The level for a torn-off menu. Synonymous with <see cref = "NSSubmenuWindowLevel" />.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSTornOffMenuWindowLevel = kCGTornOffMenuWindowLevel;

        /// <summary>
        ///   <para>Reserved for the applicationís main menu.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSMainMenuWindowLevel = kCGMainMenuWindowLevel;

        /// <summary>
        ///   <para>The level for a status window.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSStatusWindowLevel = kCGStatusWindowLevel;

        /// <summary>
        ///   <para>The level for a modal panel.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSModalPanelWindowLevel = kCGModalPanelWindowLevel;

        /// <summary>
        ///   <para>The level for a pop-up menu.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSPopUpMenuWindowLevel = kCGPopUpMenuWindowLevel;

        /// <summary>
        ///   <para>The level for a screen saver.</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSInteger NSScreenSaverWindowLevel = kCGScreenSaverWindowLevel;
    }
}