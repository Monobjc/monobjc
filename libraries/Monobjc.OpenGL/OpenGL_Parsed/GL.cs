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

//typedef unsigned int GLenum;
using GLenum = System.UInt32;
//typedef unsigned char GLboolean;
using GLboolean = System.Byte;
//typedef unsigned int GLbitfield;
using GLbitfield = System.UInt32;
//typedef signed char GLbyte;
using GLbyte = System.SByte;
//typedef short GLshort;
using GLshort = System.Int16;
//typedef int GLint;
using GLint = System.Int32;
//typedef int GLsizei;
using GLsizei = System.Int32;
//typedef unsigned char GLubyte;
using GLubyte = System.Byte;
//typedef unsigned short GLushort;
using GLushort = System.UInt16;
//typedef unsigned int GLuint;
using GLuint = System.UInt32;
//typedef float GLfloat;
using GLfloat = System.Single;
//typedef float GLclampf;
using GLclampf = System.Single;
//typedef double GLdouble;
using GLdouble = System.Double;
//typedef double GLclampd;
using GLclampd = System.Double;
//typedef void GLvoid;
using GLvoid = System.IntPtr;
//typedef long GLintptr;
using GLintptr = System.IntPtr;
//typedef long GLsizeiptr;
using GLsizeiptr = System.IntPtr;
//typedef char GLchar;
using GLchar = System.SByte;

/*
** License Applicability. Except to the extent portions of this file are
** made subject to an alternative license as permitted in the SGI Free
** Software License B, Version 1.1 (the "License"), the contents of this
** file are subject only to the provisions of the License. You may not use
** this file except in compliance with the License. You may obtain a copy
** of the License at Silicon Graphics, Inc., attn: Legal Services, 1600
** Amphitheatre Parkway, Mountain View, CA 94043-1351, or at:
** 
** http://oss.sgi.com/projects/FreeB
** 
** Note that, as provided in the License, the Software is distributed on an
** "AS IS" basis, with ALL EXPRESS AND IMPLIED WARRANTIES AND CONDITIONS
** DISCLAIMED, INCLUDING, WITHOUT LIMITATION, ANY IMPLIED WARRANTIES AND
** CONDITIONS OF MERCHANTABILITY, SATISFACTORY QUALITY, FITNESS FOR A
** PARTICULAR PURPOSE, AND NON-INFRINGEMENT.
** 
** Original Code. The Original Code is: OpenGL Sample Implementation,
** Version 1.2.1, released January 26, 2000, developed by Silicon Graphics,
** Inc. The Original Code is Copyright (c) 1991-2000 Silicon Graphics, Inc.
** Copyright in any portions created by third parties is as indicated
** elsewhere herein. All Rights Reserved.
** 
** Additional Notice Provisions: This software was created using the
** OpenGL(R) version 1.2.1 Sample Implementation published by SGI, but has
** not been independently verified as being compliant with the OpenGL(R)
** version 1.2.1 Specification.
*/
namespace Monobjc.OpenGL
{
    public partial class GL
    {
        public const string OPENGL = "/System/Library/Frameworks/OpenGL.framework/OpenGL";
    }
}