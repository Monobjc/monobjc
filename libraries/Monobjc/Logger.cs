//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
using System.Runtime.CompilerServices;

namespace Monobjc
{
    /// <summary>
    ///   <para>Very basic logger that handles four levels of log.</para>
    ///   <para>The levels are set through an environment variable <c>MONOBJC_LOG_LEVEL</c>. Output logs are printed in a Terminal console.</para>
    ///   <para>The levels are :</para>
    ///   <list type = "table">
    ///     <listheader>
    ///       <term>Level</term><description>Associated Output</description>
    ///     </listheader>
    ///     <item>
    ///       <term>DEBUG (MONOBJC_LOG_LEVEL &gt;= debug)</term><description>Low-level log (class registration, proxy creation, messaging, etc.). Beware that this level will slow down the execution.</description>
    ///     </item>
    ///     <item>
    ///       <term>INFO (MONOBJC_LOG_LEVEL &gt;= info)</term><description>Output informationnal log (bridge starting, architectre and runtime selection, statistics, etc.). Beware that this level may slow down the execution.</description>
    ///     </item>
    ///     <item>
    ///       <term>WARN (MONOBJC_LOG_LEVEL &gt;= warning)</term><description>Output warning log. There is no noticeable impact</description>
    ///     </item>
    ///     <item>
    ///       <term>ERROR (MONOBJC_LOG_LEVEL &gt;= error)</term><description>Output error log. There is no noticeable impact</description>
    ///     </item>
    ///   </list>
    /// </summary>
    public static class Logger
    {
        private static readonly bool DEBUG = IsDebugEnabled();
        private static readonly bool INFO = IsInfoEnabled();
        private static readonly bool WARNING = IsWarningEnabled();
        private static readonly bool ERROR = IsErrorEnabled();

        /// <summary>
        ///   Gets a value indicating whether debug level is enabled.
        /// </summary>
        /// <value><c>true</c> if debug is enabled; otherwise, <c>false</c>.</value>
        public static bool DebugEnabled
        {
            get { return DEBUG; }
        }

        /// <summary>
        ///   Gets a value indicating whether info level is enabled.
        /// </summary>
        /// <value><c>true</c> if info level enabled; otherwise, <c>false</c>.</value>
        public static bool InfoEnabled
        {
            get { return INFO; }
        }

        /// <summary>
        ///   Gets a value indicating whether warning level is enabled.
        /// </summary>
        /// <value><c>true</c> if warning level enabled; otherwise, <c>false</c>.</value>
        public static bool WarningEnabled
        {
            get { return WARNING; }
        }

        /// <summary>
        ///   Gets a value indicating whether warn level is enabled.
        /// </summary>
        /// <value><c>true</c> if warn level enabled; otherwise, <c>false</c>.</value>
        public static bool ErrorEnabled
        {
            get { return ERROR; }
        }

        /// <summary>
        ///   Outputs a DEBUG log.
        /// </summary>
        /// <param name = "source">The source.</param>
        /// <param name = "message">The message.</param>
        public static void Debug(String source, String message)
        {
            LogDebugMessage(source, message);
        }

        /// <summary>
        ///   Outputs an INFO log.
        /// </summary>
        /// <param name = "source">The source.</param>
        /// <param name = "message">The message.</param>
        public static void Info(String source, String message)
        {
            LogInfoMessage(source, message);
        }

        /// <summary>
        ///   Outputs a WARNING log.
        /// </summary>
        /// <param name = "source">The source.</param>
        /// <param name = "message">The message.</param>
        public static void Warn(String source, String message)
        {
            LogWarningMessage(source, message);
        }

        /// <summary>
        ///   Outputs an ERROR log.
        /// </summary>
        /// <param name = "source">The source.</param>
        /// <param name = "message">The message.</param>
        public static void Error(String source, String message)
        {
            LogErrorMessage(source, message);
        }

        /// <summary>
        ///   Internal call to check whether the DEBUG level is enabled.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool IsDebugEnabled();

        /// <summary>
        ///   Internal call to check whether the INFO level is enabled.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern bool IsInfoEnabled();

        /// <summary>
        ///   Internal call to check whether the WARNING level is enabled.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern bool IsWarningEnabled();

        /// <summary>
        ///   Internal call to check whether the ERROR level is enabled.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool IsErrorEnabled();

        /// <summary>
        ///   Internal call to print a DEBUG log.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void LogDebugMessage(String source, String message);

        /// <summary>
        ///   Internal call to print an INFO log.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void LogInfoMessage(String source, String message);

        /// <summary>
        ///   Internal call to print a WARNING log.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void LogWarningMessage(String source, String message);

        /// <summary>
        ///   Internal call to print an ERROR log.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void LogErrorMessage(String source, String message);
    }
}