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
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    [Serializable]
    [TypeConverter(typeof (NSImageConverter))]
    partial class NSImage : ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NSImage"/> class.
        /// <para>This constructor is called during de-serializatin of embedded images for example.</para>
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        protected NSImage(SerializationInfo info, StreamingContext context)
            : this(DataFromSerialization(info)) {}

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
        /// <exception cref="T:System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            NSAutoreleasePool pool = null;
            try
            {
                // As pool are scoped, it does not hurt if we create ours during the method call.
                pool = new NSAutoreleasePool();

                NSData data = this.TIFFRepresentation;
                info.AddValue("Data", data.GetBuffer(), typeof (byte[]));
            }
            finally
            {
                if (pool != null)
                {
                    pool.Release();
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="NSData"/> instance from the serialization context.
        /// </summary>
        private static NSData DataFromSerialization(SerializationInfo info)
        {
            SerializationInfoEnumerator enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (String.Equals(enumerator.Name, "Data", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        byte[] buffer = (byte[]) enumerator.Value;
                        if (buffer != null)
                        {
                            // Wraps the byte array into a NSdata
                            NSData data = new NSData(buffer);
                            return data.SafeAutorelease<NSData>();
                        }
                    }
                    catch (Exception)
                    {
                        // Do nothing
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// This subclass of <see cref="TypeConverter"/> is used to process resource files (<code>.resources</code> or <code>.resx</code>) during resource embedding.
        /// <para>This class uses the bridge to convert  <see cref="NSImage"/>back and forth to serialized byte array.</para>
        /// </summary>
        public class NSImageConverter : TypeConverter
        {
            /// <summary>
            /// Initializes the <see cref="NSImageConverter"/> class.
            /// </summary>
            static NSImageConverter()
            {
                // We must have a minimal runtime to perform conversion.
                // If the runtime is already up, then it has no effect
                ObjectiveCRuntime.LoadFramework("AppKit");
                ObjectiveCRuntime.Initialize();
            }

            /// <summary>
            /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
            /// <returns>
            /// true if this converter can perform the conversion; otherwise, false.
            /// </returns>
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return (sourceType == typeof (byte[])) || base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// Returns whether this converter can convert the object to the specified type, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
            /// <returns>
            /// true if this converter can perform the conversion; otherwise, false.
            /// </returns>
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return (destinationType == typeof (byte[])) || base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// Converts the given object to the type of this converter, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> that represents the converted value.
            /// </returns>
            /// <exception cref="T:System.NotSupportedException">
            /// The conversion cannot be performed.
            /// </exception>
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                NSAutoreleasePool pool = null;
                try
                {
                    // As pool are scoped, it does not hurt if we create ours during the method call.
                    pool = new NSAutoreleasePool();

                    byte[] rawData = value as byte[];
                    if (rawData == null)
                    {
                        return base.ConvertFrom(context, culture, value);
                    }

                    // The image creation will be based on a NSData instance that wraps the byte array
                    NSData data = new NSData(rawData);
                    NSImage image = new NSImage(data);
                    data.Release();
                    return image; // TODO: Find a way to avoid the memory leak as we do not release the instance...
                }
                finally
                {
                    if (pool != null)
                    {
                        pool.Release();
                    }
                }
            }

            /// <summary>
            /// Converts the given value object to the specified type, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
            /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> that represents the converted value.
            /// </returns>
            /// <exception cref="T:System.ArgumentNullException">
            /// The <paramref name="destinationType"/> parameter is null.
            /// </exception>
            /// <exception cref="T:System.NotSupportedException">
            /// The conversion cannot be performed.
            /// </exception>
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                NSAutoreleasePool pool = null;
                try
                {
                    // As pool are scoped, it does not hurt if we create ours during the method call.
                    pool = new NSAutoreleasePool();

                    if (destinationType != typeof (byte[]))
                    {
                        return base.ConvertTo(context, culture, value, destinationType);
                    }
                    if (value == null)
                    {
                        return new byte[0];
                    }

                    // The byte buffer returned will always be a TIFF representation for simplicity reasons.
                    NSImage image = (NSImage) value;
                    NSData data = image.TIFFRepresentation;
                    return data.GetBuffer();
                }
                finally
                {
                    if (pool != null)
                    {
                        pool.Release();
                    }
                }
            }

            /// <summary>
            /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="value">An <see cref="T:System.Object"/> that specifies the type of array for which to get properties.</param>
            /// <param name="attributes">An array of type <see cref="T:System.Attribute"/> that is used as a filter.</param>
            /// <returns>
            /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for this data type, or null if there are no properties.
            /// </returns>
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                return TypeDescriptor.GetProperties(typeof (NSImage), attributes);
            }

            /// <summary>
            /// Returns whether this object supports properties, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <returns>
            /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
            /// </returns>
            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }
    }
}