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
namespace Monobjc.ScriptingBridge
{
	/// <summary>
	/// <para>Specify the mode for sending evetns to an application.</para>
	/// <para>Available in Mac OS X v10.5 and later.</para>
	/// </summary>
	public enum AESendMode
	{
		/// <summary>
		/// sender doesn't want a reply to event
		/// </summary>
		kAENoReply = 0x00000001,
		/// <summary>
		/// sender wants a reply but won't wait
		/// </summary>
		kAEQueueReply = 0x00000002,
		/// <summary>
		/// sender wants a reply and will wait
		/// </summary>
		kAEWaitReply = 0x00000003,
		/// <summary>
		/// don't reconnect if there is a sessClosedErr from PPCToolbox
		/// </summary>
		kAEDontReconnect = 0x00000080,
		/// <summary>
		/// (nReturnReceipt) sender wants a receipt of message
		/// </summary>
		kAEWantReceipt = 0x00000200,
		/// <summary>
		/// server should not interact with user
		/// </summary>
		kAENeverInteract = 0x00000010,
		/// <summary>
		/// server may try to interact with user
		/// </summary>
		kAECanInteract = 0x00000020,
		/// <summary>
		/// server should always interact with user where appropriate
		/// </summary>
		kAEAlwaysInteract = 0x00000030,
		/// <summary>
		/// interaction may switch layer
		/// </summary>
		kAECanSwitchLayer = 0x00000040,
		/// <summary>
		/// don't record this event - available only in vers 1.0.1 and greater
		/// </summary>
		kAEDontRecord = 0x00001000,
		/// <summary>
		/// don't send the event for recording - available only in vers 1.0.1 and greater
		/// </summary>
		kAEDontExecute = 0x00002000,
		/// <summary>
		/// allow processing of non-reply events while awaiting synchronous AppleEvent reply
		/// </summary>
		kAEProcessNonReplyEvents = 0x00008000
	}
}
