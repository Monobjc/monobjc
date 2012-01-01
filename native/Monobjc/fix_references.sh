#!/bin/bash
# 
# This file is part of Monobjc, a .NET/Objective-C bridge
# Copyright (C) 2007-2012  Laurent Etiemble
# 
# Monobjc is free software: you can redistribute it and/or modify
# it under the terms of the GNU Lesser General Public License as published
# by the Free Software Foundation, either version 3 of the License, or
# any later version.
# 
# Monobjc is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
# 
# You should have received a copy of the GNU Lesser General Public License
# along with Monobjc. If not, see <http://www.gnu.org/licenses/>.
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
