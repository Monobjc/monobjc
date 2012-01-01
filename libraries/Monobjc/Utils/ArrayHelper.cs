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

namespace Monobjc.Utils
{
    /// <summary>
    ///   Utility class to manipulate <see cref = "Array" /> instances.
    /// </summary>
    internal static class ArrayHelper
    {
        /// <summary>
        ///   Create a new array by prepending the given element.
        /// </summary>
        public static T[] Prepend<T>(T[] array, T element)
        {
            T[] result = new T[array.Length + 1];
            Array.Copy(array, 0, result, 1, array.Length);
            result[0] = element;
            return result;
        }

        /// <summary>
        ///   Create a new array by prepending the given elements.
        /// </summary>
        public static T[] Prepend<T>(T[] array, T element1, T element2)
        {
            T[] result = new T[array.Length + 2];
            Array.Copy(array, 0, result, 2, array.Length);
            result[0] = element1;
            result[1] = element2;
            return result;
        }

        /// <summary>
        ///   Create a new array by appending the given element.
        /// </summary>
        public static T[] Append<T>(T[] array, T element)
        {
            T[] result = new T[array.Length + 1];
            Array.Copy(array, result, array.Length);
            result[array.Length] = element;
            return result;
        }

        /// <summary>
        ///   Create a new array by appending the given elements.
        /// </summary>
        public static T[] Append<T>(T[] array, T element1, T element2)
        {
            T[] result = new T[array.Length + 2];
            Array.Copy(array, result, array.Length);
            result[array.Length] = element1;
            result[array.Length + 1] = element2;
            return result;
        }

        /// <summary>
        ///   Create a new array by removing given amount of element on the left.
        /// </summary>
        public static T[] TrimLeft<T>(T[] array, int amount)
        {
            T[] result = new T[array.Length - amount];
            Array.Copy(array, amount, result, 0, result.Length);
            return result;
        }

        /// <summary>
        ///   Create a new array by removing given amount of element on the right.
        /// </summary>
        public static T[] TrimRight<T>(T[] array, int amount)
        {
            T[] result = new T[array.Length - amount];
            Array.Copy(array, 0, result, 0, result.Length);
            return result;
        }
    }
}