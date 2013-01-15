//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
using System.Runtime.Serialization;

namespace Monobjc
{
	/// <summary>
	///   Exception raised if a something failed inside the bridge.
	/// </summary>
	[Serializable]
	public class ObjectiveCException : Exception
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCException" /> class.
		/// </summary>
		public ObjectiveCException ()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		public ObjectiveCException (String message)
            : base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		/// <param name = "innerException">The inner exception.</param>
		public ObjectiveCException (String message, Exception innerException)
            : base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCException" /> class.
		/// </summary>
		/// <param name = "info">The <see cref = "T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name = "context">The <see cref = "T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult"></see> is zero (0). </exception>
		/// <exception cref = "T:System.ArgumentNullException">The info parameter is null. </exception>
		protected ObjectiveCException (SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
	}

	/// <summary>
	///   Exception raised if a dynamic class cast failed.
	/// </summary>
	[Serializable]
	public class ObjectiveCClassCastException : ObjectiveCException
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassCastException" /> class.
		/// </summary>
		public ObjectiveCClassCastException ()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassCastException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		public ObjectiveCClassCastException (String message)
            : base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassCastException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		/// <param name = "innerException">The inner exception.</param>
		public ObjectiveCClassCastException (String message, Exception innerException)
            : base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassCastException" /> class.
		/// </summary>
		/// <param name = "info">The <see cref = "T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name = "context">The <see cref = "T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult"></see> is zero (0). </exception>
		/// <exception cref = "T:System.ArgumentNullException">The info parameter is null. </exception>
		protected ObjectiveCClassCastException (SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
	}

	/// <summary>
	///   Exception raised if a class mapping failed.
	/// </summary>
	[Serializable]
	public class ObjectiveCClassMappingException : ObjectiveCException
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassMappingException" /> class.
		/// </summary>
		public ObjectiveCClassMappingException ()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassMappingException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		public ObjectiveCClassMappingException (String message)
            : base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassMappingException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		/// <param name = "innerException">The inner exception.</param>
		public ObjectiveCClassMappingException (String message, Exception innerException)
            : base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassMappingException" /> class.
		/// </summary>
		/// <param name = "info">The <see cref = "T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name = "context">The <see cref = "T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult"></see> is zero (0). </exception>
		/// <exception cref = "T:System.ArgumentNullException">The info parameter is null. </exception>
		protected ObjectiveCClassMappingException (SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
	}

	/// <summary>
	///   Exception raised if a category mapping failed.
	/// </summary>
	[Serializable]
	public class ObjectiveCCategoryMappingException : ObjectiveCException
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCategoryMappingException" /> class.
		/// </summary>
		public ObjectiveCCategoryMappingException ()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCategoryMappingException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		public ObjectiveCCategoryMappingException (String message)
            : base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCategoryMappingException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		/// <param name = "innerException">The inner exception.</param>
		public ObjectiveCCategoryMappingException (String message, Exception innerException)
            : base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCategoryMappingException" /> class.
		/// </summary>
		/// <param name = "info">The <see cref = "T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name = "context">The <see cref = "T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult"></see> is zero (0). </exception>
		/// <exception cref = "T:System.ArgumentNullException">The info parameter is null. </exception>
		protected ObjectiveCCategoryMappingException (SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
	}

	/// <summary>
	///   Exception raised if a dynamic code generation failed.
	/// </summary>
	[Serializable]
	public class ObjectiveCCodeGenerationException : ObjectiveCException
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCodeGenerationException" /> class.
		/// </summary>
		public ObjectiveCCodeGenerationException ()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCodeGenerationException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		public ObjectiveCCodeGenerationException (String message)
            : base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCodeGenerationException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		/// <param name = "innerException">The inner exception.</param>
		public ObjectiveCCodeGenerationException (String message, Exception innerException)
            : base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCodeGenerationException" /> class.
		/// </summary>
		/// <param name = "info">The <see cref = "T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name = "context">The <see cref = "T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult"></see> is zero (0). </exception>
		/// <exception cref = "T:System.ArgumentNullException">The info parameter is null. </exception>
		protected ObjectiveCCodeGenerationException (SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
	}

	/// <summary>
	///   Exception raised if a message passing failed.
	/// </summary>
	[Serializable]
	public class ObjectiveCMessagingException : ObjectiveCException
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCMessagingException" /> class.
		/// </summary>
		public ObjectiveCMessagingException ()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCMessagingException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		public ObjectiveCMessagingException (String message)
            : base(message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCMessagingException" /> class.
		/// </summary>
		/// <param name = "message">The message.</param>
		/// <param name = "innerException">The inner exception.</param>
		public ObjectiveCMessagingException (String message, Exception innerException)
            : base(message, innerException)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCMessagingException" /> class.
		/// </summary>
		/// <param name = "info">The <see cref = "T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name = "context">The <see cref = "T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref = "T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref = "P:System.Exception.HResult"></see> is zero (0). </exception>
		/// <exception cref = "T:System.ArgumentNullException">The info parameter is null. </exception>
		protected ObjectiveCMessagingException (SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
	}
}