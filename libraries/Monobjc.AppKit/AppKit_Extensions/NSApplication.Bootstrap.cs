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
    public partial class NSApplication
    {
        /// <summary>
        /// Autorelease pool created by default when launching a GUI application
        /// </summary>
        public static readonly NSAutoreleasePool AutoreleasePool = new NSAutoreleasePool();

        /// <summary>
        /// Bootstrap the process instance and install the <see cref="NSAutoreleasePool"/> on the main thread.
        /// </summary>
        public static void Bootstrap()
        {
            if (Logger.InfoEnabled)
            {
                Logger.Info("NSApplication", "Bootstrap");
            }

			// NSDictionary dictionary = NSBundle.MainBundle.InfoDictionary;
			// if (dictionary == null) {
			// return;
			// }
			//			
			// NSNumber backgroundOnly = dictionary.ObjectForKey<NSNumber>((NSString)"LSBackgroundOnly");
			// if (backgroundOnly != null && backgroundOnly.BoolValue) {
			// return;
			// }
			//			
			// NSString uiElement = dictionary.ObjectForKey<NSString>((NSString)"LSUIElement");
			// if (uiElement != null && uiElement.IsEqualToString("1")) {
			// return;
			// }
			
			ProcessSerialNumber psn;
			ProcessManager.GetCurrentProcess(out psn);
			ProcessManager.TransformProcessType(ref psn, ProcessApplicationTransformState.kProcessTransformToForegroundApplication);
			ProcessManager.SetFrontProcess(ref psn);
        }

        /// <summary>
        /// Loads the nib and assings ownership to the <see cref="SharedApplication"/> instance.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public static void LoadNib(String filename)
        {
            if (Logger.InfoEnabled)
            {
                Logger.Info("NSApplication", "Loading NIB " + filename);
            }

#if MACOSX_10_8
			NSArray topLevelObjets;
			if (!NSBundle.MainBundle.LoadNibNamedOwnerTopLevelObjects(filename, SharedApplication, out topLevelObjets))
			{
				Logger.Error("NSApplication", "Error while loading the NIB file");
			}
#else
			if (!NSBundle_AppKitAdditions.LoadNibNamedOwner(filename, SharedApplication))
			{
				Logger.Error("NSApplication", "Error while loading the NIB file");
			}
#endif
        }

        /// <summary>
        /// Runs the main event loop.
        /// </summary>
        public static void RunApplication()
        {
            if (Logger.InfoEnabled)
            {
                Logger.Debug("NSApplication", "Running Application");
            }
            SharedApplication.Run();
        }
    }
}
