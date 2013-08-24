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
using Monobjc.Foundation;
using Monobjc.AppKit;

namespace Monobjc.GameKit
{
#if MACOSX_10_9
    public partial class GKLocalPlayer
    {
        /// <summary>
        /// <para>A handler called to process an authentication-related event.</para>
        /// <para>Original signature is '@property(nonatomic, copy) void(^authenticateHandler)(NSViewController *viewController, NSError *error)'</para>
        /// <para>Available in OS X v10.9 and later.</para>
        /// </summary>
        public virtual void SetAuthenticateHandler(Action<NSViewController, NSError> authenticateHandler)
        {
            using (var block = Block.Create(authenticateHandler))
                this.AuthenticateHandler = block;
        }
    }

    public partial class GKMatchRequest
    {
        /// <summary>
        /// <para>A block to be called when a response from an invited player is returned to your game.</para>
        /// <para>Original signature is '@property(nonatomic, copy) void(^inviteeResponseHandler)(NSString *playerID, GKInviteeResponse response)'</para>
        /// <para>Available in OS X v10.9 and later.</para>
        /// </summary>
        public virtual void SetInviteeResponseHandler(Action<NSString, GKInviteeResponse> inviteeResponseHandler)
        {
            using (var block = Block.Create(inviteeResponseHandler))
                this.InviteeResponseHandler = block;
        }
    }
#endif

#if MACOSX_10_8
    public partial class GKMatchmaker
    {
        /// <summary>
        /// <para>A block to be called when an invitation to join a match is accepted by the local player.</para>
        /// <para>Original signature is '@property(nonatomic, copy) void(^inviteHandler)(GKInvite *acceptedInvite, NSArray *playersToInvite)'</para>
        /// <para>Available in OS X v10.8 and later.</para>
        /// </summary>
        public virtual void SetInviteHandler(Action<GKInvite, NSArray> inviteHandler)
        {
            using (var block = Block.Create(inviteHandler))
                this.InviteHandler = block;
        }
    }

    public partial class GKVoiceChat
    {
        /// <summary>
        /// <para>A block that is called when a participant changes state.</para>
        /// <para>Original signature is '@property(nonatomic, copy) void(^playerStateUpdateHandler)(NSString *playerID, GKVoiceChatPlayerState state)'</para>
        /// <para>Available in OS X v10.8 and later.</para>
        /// </summary>
        public virtual void SetPlayerStateUpdateHandler(Action<NSString, GKVoiceChatPlayerState> playerStateUpdateHandler)
        {
            using (var block = Block.Create(playerStateUpdateHandler))
                this.PlayerStateUpdateHandler = block;
        }
    }
#endif
}

