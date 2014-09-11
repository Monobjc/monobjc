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

/**
 * @file    icalls-Monobjc.Foundation.NSString.mm
 * @brief   Contains the internal calls for the Monobjc.Foundation.NSString type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2013-2014
 */
#include "logging.h"
#include "support-mono.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Internal call to convert a NSString to a MonoString.
 * @param   ptr     The pointer to the NSString object or NULL.
 * @return  Return a MonoString object if the NSString object is defined and can be converted; NULL otherwise.
 */
MonoString *icall_Monobjc_Foundation_NSString_ToString(void *ptr) {
    if (!ptr) {
        return NULL;
    }
    
    NSString *obj = (NSString *)ptr;
    mono_unichar2 *data = (mono_unichar2 *) [obj cStringUsingEncoding:NSUTF16StringEncoding];
    if (!data) {
        LOG_WARNING(MONOBJC_DOMAIN_GENERAL, "Cannot convert NSString to MonoString at %p", ptr);
        return NULL;
    }
    return mono_string_from_utf16(data);
}
