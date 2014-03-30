#!/bin/bash
#
# This file is part of Monobjc, a .NET/Objective-C bridge
# Copyright (C) 2007-2014 - Laurent Etiemble
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
# copies of the Software, and to permit persons to whom the Software is
# furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in
# all copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
# THE SOFTWARE.
# 
TARGET=$CONFIGURATION_BUILD_DIR/$EXECUTABLE_NAME
MONO_LIB="/Library/Frameworks/Mono.framework/Versions/Current/lib"

# Search for version specific references
REFERENCES=`otool -L $TARGET | grep -v "/Mono.framework/Versions/Current/" | awk -F" " '/Mono\.framework/ { print $1 }'`

# Iterate over references and replace them with version agnostic ones
for ref in $REFERENCES; do
    echo "Processing $TARGET: remapping $ref..."
    lib=`echo $ref | awk -F"/" '{ print $NF; }'`
    install_name_tool -change $ref "$MONO_LIB/$lib" $TARGET
done
