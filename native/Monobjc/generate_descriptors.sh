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
DIR="sources/descriptors"
CPP="cpp -Isources"
INPUT="$DIR/descriptor.def"

function transform {
    NAME=$1
    MONO=$2
    NATIVE=$3
    STORAGE=$4
    ENCODING=$5
    FFI=$6

    if [ "$NATIVE" == "$STORAGE" ]; then
        DIRECT="1"
    else
        DIRECT="0"
    fi

    OUTPUT="$DIR/descriptor-System.$NAME.mm"

    if [ $INPUT -nt $OUTPUT ]; then
        echo "Writting $OUTPUT..."

        if [ "$DIRECT" == "1" ]; then
            cat $INPUT | sed \
            -e "s/@NAME@/$NAME/g" \
            -e "s/@MONO@/$MONO/g" \
            -e "s/@NATIVE@/$NATIVE/g" \
            -e "s/@STORAGE@/$STORAGE/g" \
            -e "s/@ENCODING@/$ENCODING/g" \
            -e "s/@FFI@/$FFI/g" \
            -e "/@DIRECT_START@/d" \
            -e "/@DIRECT_END@/d" \
            -e "/@INDIRECT_START@/,/@INDIRECT_END@/d" \
            > $OUTPUT
        else
            cat $INPUT | sed \
            -e "s/@NAME@/$NAME/g" \
            -e "s/@MONO@/$MONO/g" \
            -e "s/@NATIVE@/$NATIVE/g" \
            -e "s/@STORAGE@/$STORAGE/g" \
            -e "s/@ENCODING@/$ENCODING/g" \
            -e "s/@FFI@/$FFI/g" \
            -e "/@INDIRECT_START@/d" \
            -e "/@INDIRECT_END@/d" \
            -e "/@DIRECT_START@/,/@DIRECT_END@/d" \
            > $OUTPUT
        fi
    fi
}

#         NAME      MONO        NATIVE      STORAGE     ENCODING    FFI
# ------------------------------------------------------------------------------------
transform "IntPtr"  "intptr"    "void *"    "void *"    "^"         "ffi_type_pointer"

#         NAME      MONO        NATIVE      STORAGE     ENCODING    FFI
# ------------------------------------------------------------------------------------
transform "Boolean" "boolean"   "int8_t"    "int32_t"   "c"         "ffi_type_sint8"
transform "Char"    "char"      "int16_t"   "int32_t"   "S"         "ffi_type_uint16"

#         NAME      MONO        NATIVE      STORAGE     ENCODING    FFI
# ------------------------------------------------------------------------------------
transform "SByte"   "sbyte"     "int8_t"    "int32_t"   "c"         "ffi_type_sint8"
transform "Int16"   "int16"     "int16_t"   "int32_t"   "s"         "ffi_type_sint16"
transform "Int32"   "int32"     "int32_t"   "int32_t"   "i"         "ffi_type_sint32"
transform "Int64"   "int64"     "int64_t"   "int64_t"   "q"         "ffi_type_sint64"

#         NAME      MONO        NATIVE      STORAGE     ENCODING    FFI
# ------------------------------------------------------------------------------------
transform "Byte"    "byte"      "uint8_t"    "uint32_t" "C"         "ffi_type_uint8"
transform "UInt16"  "uint16"    "uint16_t"   "uint32_t" "S"         "ffi_type_uint16"
transform "UInt32"  "uint32"    "uint32_t"   "uint32_t" "I"         "ffi_type_uint32"
transform "UInt64"  "uint64"    "uint64_t"   "uint64_t" "Q"         "ffi_type_uint64"
