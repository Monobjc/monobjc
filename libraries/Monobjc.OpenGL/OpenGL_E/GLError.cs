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
namespace Monobjc.OpenGL
{
    /// <summary>
    /// </summary>
    public enum CGLError
    {
        /// <summary>
        ///   <para>no error</para>
        /// </summary>
        kCGLNoError = 0,
        /// <summary>
        ///   <para>invalid pixel format attribute</para>
        /// </summary>
        kCGLBadAttribute = 10000,
        /// <summary>
        ///   <para>invalid renderer property</para>
        /// </summary>
        kCGLBadProperty = 10001,
        /// <summary>
        ///   <para>invalid pixel format</para>
        /// </summary>
        kCGLBadPixelFormat = 10002,
        /// <summary>
        ///   <para>invalid renderer info</para>
        /// </summary>
        kCGLBadRendererInfo = 10003,
        /// <summary>
        ///   <para>invalid context</para>
        /// </summary>
        kCGLBadContext = 10004,
        /// <summary>
        ///   <para>invalid drawable</para>
        /// </summary>
        kCGLBadDrawable = 10005,
        /// <summary>
        ///   <para>invalid graphics device</para>
        /// </summary>
        kCGLBadDisplay = 10006,
        /// <summary>
        ///   <para>invalid context state</para>
        /// </summary>
        kCGLBadState = 10007,
        /// <summary>
        ///   <para>invalid numerical value</para>
        /// </summary>
        kCGLBadValue = 10008,
        /// <summary>
        ///   <para>invalid share context</para>
        /// </summary>
        kCGLBadMatch = 10009,
        /// <summary>
        ///   <para>invalid enumerant</para>
        /// </summary>
        kCGLBadEnumeration = 10010,
        /// <summary>
        ///   <para>invalid offscreen drawable</para>
        /// </summary>
        kCGLBadOffScreen = 10011,
        /// <summary>
        ///   <para>invalid offscreen drawable</para>
        /// </summary>
        kCGLBadFullScreen = 10012,
        /// <summary>
        ///   <para>invalid window</para>
        /// </summary>
        kCGLBadWindow = 10013,
        /// <summary>
        ///   <para>invalid pointer</para>
        /// </summary>
        kCGLBadAddress = 10014,
        /// <summary>
        ///   <para>invalid code module</para>
        /// </summary>
        kCGLBadCodeModule = 10015,
        /// <summary>
        ///   <para>invalid memory allocation</para>
        /// </summary>
        kCGLBadAlloc = 10016,
        /// <summary>
        ///   <para>invalid CoreGraphics connection</para>
        /// </summary>
        kCGLBadConnection = 10017
    }
}