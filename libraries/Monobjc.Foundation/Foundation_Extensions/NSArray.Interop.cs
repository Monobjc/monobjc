//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
using System.Collections.Generic;

namespace Monobjc.Foundation
{
    partial class NSArray
    {
        /// <summary>
        /// Create an instance of <see cref="NSArray"/> from a <see cref="IList{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>An <see cref="NSArray"/> instance.</returns>
        public static NSArray ArrayWithList<T>(IList<T> list) where T : Id
        {
            int count = list.Count;
            switch (count)
            {
                case 0:
                    return Array;
                case 1:
                    return ArrayWithObject(list[0]);
                default:
                    T firstObject = list[0];
                    T[] otherObjects = new T[count - 1];
                    list.CopyTo(otherObjects, 1);
                    return ArrayWithObjects(firstObject, otherObjects, null);
            }
        }

        /// <summary>
        /// Converts the elements in the current <see cref="NSArray"/> to another type, and returns a list containing the converted elements.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="converter">The converter.</param>
        /// <returns>
        /// A <see cref="Converter{TInput,TOutput}"/> delegate that converts each element from one type to another type.
        /// </returns>
        public List<TOutput> ConvertAll<TInput, TOutput>(Converter<TInput, TOutput> converter) where TInput : class, IManagedWrapper
            where TOutput : class, IManagedWrapper
        {
            List<TOutput> result = new List<TOutput>();
            foreach (TInput value in this.GetEnumerator<TInput>())
            {
                result.Add(converter(value));
            }
            return result;
        }

        /// <summary>
        /// Determines whether the <see cref="NSArray"/> contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the <see cref="NSArray"/> contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public virtual bool Exists<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            foreach (T value in this.GetEnumerator<T>())
            {
                if (match(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire <see cref="NSArray"/>.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.</returns>
        public virtual T Find<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            foreach (T value in this.GetEnumerator<T>())
            {
                if (match(value))
                {
                    return value;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>A <see cref="List{T}"/> containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty <see cref="List{T}"/>.</returns>
        public virtual List<T> FindAll<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            List<T> result = new List<T>();
            foreach (T value in this.GetEnumerator<T>())
            {
                if (match(value))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="NSArray"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, '1.</returns>
        public int FindIndex<T>(int startIndex, int count, Predicate<T> match) where T : class, IManagedWrapper
        {
            if (startIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if ((startIndex + count) >= this.Count)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            for (int i = startIndex; count > 0; i++, count--)
            {
                T value = this[i].CastTo<T>();
                if (match(value))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="NSArray"/> that extends from the specified index to the last element.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, '1.</returns>
        public int FindIndex<T>(int startIndex, Predicate<T> match) where T : class, IManagedWrapper
        {
            return this.FindIndex(startIndex, (int) (uint)this.Count, match);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire <see cref="NSArray"/>.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, '1.</returns>
        public int FindIndex<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            return this.FindIndex(0, match);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire <see cref="NSArray"/>.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The last element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.</returns>
        public T FindLast<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            for (int i = (int) (uint)this.Count; i >= 0; i--)
            {
                T value = this[i].CastTo<T>();
                if (match(value))
                {
                    return value;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the <see cref="NSArray"/> that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, '1.</returns>
        public int FindLastIndex<T>(int startIndex, int count, Predicate<T> match) where T : class, IManagedWrapper
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if ((startIndex - count) < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            for (int i = startIndex; count > 0; i--, count--)
            {
                T value = this[i].CastTo<T>();
                if (match(value))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the <see cref="NSArray"/> that extends from the first element to the specified index.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, '1.</returns>
        public int FindLastIndex<T>(int startIndex, Predicate<T> match) where T : class, IManagedWrapper
        {
            return this.FindLastIndex(startIndex, (int) (uint)this.Count, match);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire <see cref="NSArray"/>.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, '1.</returns>
        public int FindLastIndex<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            return this.FindLastIndex(0, match);
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="NSArray"/>.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="NSArray"/>.</param>
        public virtual void ForEach<T>(Action<T> action) where T : class, IManagedWrapper
        {
            foreach (T value in this.GetEnumerator<T>())
            {
                action(value);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="NSArray"/>.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <returns>An typed enumarator</returns>
        public virtual IEnumerable<T> GetEnumerator<T>() where T : class, IManagedWrapper
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i].CastTo<T>();
            }
        }

        /// <summary>
        /// Determines whether every element in the <see cref="NSArray"/> matches the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions to check against the elements.</param>
        /// <returns>true if every element in the <see cref="NSArray"/> matches the conditions defined by the specified predicate; otherwise, false. If the list has no elements, the return value is true.</returns>
        public virtual bool TrueForAll<T>(Predicate<T> match) where T : class, IManagedWrapper
        {
            foreach (T value in this.GetEnumerator<T>())
            {
                if (!match(value))
                {
                    return false;
                }
            }
            return true;
        }
		
        /// <summary>
        /// <para>Returns the object located at index.</para>
        /// <para>Original signature is '- (id)objectAtIndex:( NSUInteger)index'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="index">An index within the bounds of the receiver.</param>
        /// <returns>The object located at index.</returns>
        public virtual T ObjectAtIndex<T>(NSUInteger index) where T : IManagedWrapper
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return ObjectiveCRuntime.SendMessage<T>(this, "objectAtIndex:", (ulong) index);
            }
            else
            {
                return ObjectiveCRuntime.SendMessage<T>(this, "objectAtIndex:", (uint) index);
            }
        }
    }
}