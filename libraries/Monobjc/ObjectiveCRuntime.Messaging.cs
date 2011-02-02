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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Monobjc.Properties;
using Monobjc.Runtime;

namespace Monobjc
{
    partial class ObjectiveCRuntime
    {
        public static void SendMessage(IntPtr receiver, String selector, params Object[] parameters)
        {
            Messaging.Call(typeof (void).TypeHandle.Value, receiver, selector, parameters);
        }

        public static void SendMessage(IManagedWrapper receiver, String selector, params Object[] parameters)
        {
            Messaging.Call(typeof (void).TypeHandle.Value, receiver.NativePointer, selector, parameters);
        }

        public static T SendMessage<T>(IntPtr receiver, String selector, params Object[] parameters)
        {
            return (T) Messaging.Call(typeof (T).TypeHandle.Value, receiver, selector, parameters);
        }

        public static T SendMessage<T>(IManagedWrapper receiver, String selector, params Object[] parameters)
        {
            return (T) Messaging.Call(typeof (T).TypeHandle.Value, receiver.NativePointer, selector, parameters);
        }

        
        
        public static void SendMessageSuper(IntPtr receiver, Class cls, String selector, params Object[] parameters)
        {
            Messaging.CallSuper(typeof (void).TypeHandle.Value, receiver, cls.pointer, selector, parameters);
        }

        public static void SendMessageSuper(IManagedWrapper receiver, Class cls, String selector, params Object[] parameters)
        {
            Messaging.CallSuper(typeof (void).TypeHandle.Value, receiver.NativePointer, cls.pointer, selector, parameters);
        }

        public static T SendMessageSuper<T>(IntPtr receiver, Class cls, String selector, params Object[] parameters)
        {
            return (T) Messaging.CallSuper(typeof (T).TypeHandle.Value, receiver, cls.pointer, selector, parameters);
        }

        public static T SendMessageSuper<T>(IManagedWrapper receiver, Class cls, String selector, params Object[] parameters)
        {
            return (T) Messaging.CallSuper(typeof (T).TypeHandle.Value, receiver.NativePointer, cls.pointer, selector, parameters);
        }
        
        

        public static void SendMessageVarArgs(IntPtr receiver, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            SendMessage(receiver, selector, parameters);
        }

        public static void SendMessageVarArgs(IManagedWrapper receiver, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            SendMessage(receiver, selector, parameters);
        }
        
        public static TReturnType SendMessageVarArgs<TReturnType>(IntPtr receiver, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            return SendMessage<TReturnType>(receiver, selector, parameters);
        }

        public static TReturnType SendMessageVarArgs<TReturnType>(IManagedWrapper receiver, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            return SendMessage<TReturnType>(receiver, selector, parameters);
        }

        
        
        public static void SendMessageSuperVarArgs(IntPtr receiver, Class cls, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            SendMessageSuper(receiver, cls, selector, parameters);
        }

        public static void SendMessageSuperVarArgs(IManagedWrapper receiver, Class cls, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            SendMessageSuper(receiver, cls, selector, parameters);
        }
        
        public static TReturnType SendMessageSuperVarArgs<TReturnType>(IntPtr receiver, Class cls, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            return SendMessageSuper<TReturnType>(receiver, cls, selector, parameters);
        }

        public static TReturnType SendMessageSuperVarArgs<TReturnType>(IManagedWrapper receiver, Class cls, String selector, params Object[] parameters)
        {
            parameters = MergeParametersVarArgs(selector, parameters);
            return SendMessageSuper<TReturnType>(receiver, cls, selector, parameters);
        }
        
        

        private static Object[] MergeParametersVarArgs(String selector, Object[] parameters)
        {
            if (parameters.Length == 0)
            {
                throw new ArgumentException(Resources.AtLeastOneParameterMustBePassed, "parameters");
            }
            Object[] varargs = (parameters[parameters.Length - 1] as Object[]);
            if (varargs == null)
            {
                throw new ObjectiveCMessagingException(String.Format(CultureInfo.CurrentCulture, Resources.CannotCallVarargsMessage, selector));
            }
            Object[] array = new Object[(parameters.Length - 1) + varargs.Length];
            Array.Copy(parameters, array, parameters.Length - 1);
            Array.Copy(varargs, 0, array, (parameters.Length - 1), varargs.Length);

            return array;
        }
    }
}