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
using System;
using System.Runtime.InteropServices;
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
        /// <summary>
        /// <para>Original signature is 'extern void glAccum (GLenum op, GLfloat value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glAccum")]
        public static extern void glAccum(GLenum op, GLfloat value);

        /// <summary>
        /// <para>Original signature is 'extern void glAlphaFunc (GLenum func, GLclampf ref);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glAlphaFunc")]
        public static extern void glAlphaFunc(GLenum func, GLclampf @ref);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glAreTexturesResident (GLsizei n, const GLuint *textures, GLboolean *residences);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glAreTexturesResident")]
        public static extern GLboolean glAreTexturesResident(GLsizei n, IntPtr textures, IntPtr residences);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glAreTexturesResident (GLsizei n, const GLuint *textures, GLboolean *residences);'</para>
        /// </summary>
        public static GLboolean glAreTexturesResident(GLsizei n, IntPtr textures, out GLboolean residences)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLboolean)));
            GLboolean result = glAreTexturesResident(n, textures, __local3);
            residences = (GLboolean)Marshal.ReadByte(__local3);
            Marshal.FreeHGlobal(__local3);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glAreTexturesResident (GLsizei n, const GLuint *textures, GLboolean *residences);'</para>
        /// </summary>
        public static GLboolean glAreTexturesResident(GLsizei n, GLuint[] textures, IntPtr residences)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * textures.Length);
            GLint[] __array2 = Array.ConvertAll(textures, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            GLboolean result = glAreTexturesResident(n, __local2, residences);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glAreTexturesResident (GLsizei n, const GLuint *textures, GLboolean *residences);'</para>
        /// </summary>
        public static GLboolean glAreTexturesResident(GLsizei n, GLuint[] textures, out GLboolean residences)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * textures.Length);
            GLint[] __array2 = Array.ConvertAll(textures, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLboolean)));
            GLboolean result = glAreTexturesResident(n, __local2, __local3);
            Marshal.FreeHGlobal(__local2);
            residences = (GLboolean)Marshal.ReadByte(__local3);
            Marshal.FreeHGlobal(__local3);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glAreTexturesResident (GLsizei n, const GLuint *textures, GLboolean *residences);'</para>
        /// </summary>
        public static GLboolean glAreTexturesResident(GLsizei n, ref GLuint textures, IntPtr residences)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)textures);
            GLboolean result = glAreTexturesResident(n, __local2, residences);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glAreTexturesResident (GLsizei n, const GLuint *textures, GLboolean *residences);'</para>
        /// </summary>
        public static GLboolean glAreTexturesResident(GLsizei n, ref GLuint textures, out GLboolean residences)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)textures);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLboolean)));
            GLboolean result = glAreTexturesResident(n, __local2, __local3);
            Marshal.FreeHGlobal(__local2);
            residences = (GLboolean)Marshal.ReadByte(__local3);
            Marshal.FreeHGlobal(__local3);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern void glArrayElement (GLint i);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glArrayElement")]
        public static extern void glArrayElement(GLint i);

        /// <summary>
        /// <para>Original signature is 'extern void glBegin (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBegin")]
        public static extern void glBegin(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glBindTexture (GLenum target, GLuint texture);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBindTexture")]
        public static extern void glBindTexture(GLenum target, GLuint texture);

        /// <summary>
        /// <para>Original signature is 'extern void glBitmap (GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, const GLubyte *bitmap);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBitmap")]
        public static extern void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, IntPtr bitmap);

        /// <summary>
        /// <para>Original signature is 'extern void glBitmap (GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, const GLubyte *bitmap);'</para>
        /// </summary>
        public static void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, GLubyte[] bitmap)
        {
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * bitmap.Length);
            Marshal.Copy(bitmap, 0, __local7, bitmap.Length);
            glBitmap(width, height, xorig, yorig, xmove, ymove, __local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glBitmap (GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, const GLubyte *bitmap);'</para>
        /// </summary>
        public static void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, ref GLubyte bitmap)
        {
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local7, bitmap);
            glBitmap(width, height, xorig, yorig, xmove, ymove, __local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glBlendColor (GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBlendColor")]
        public static extern void glBlendColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glBlendEquation (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBlendEquation")]
        public static extern void glBlendEquation(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBlendEquationSeparate")]
        public static extern void glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha);

        /// <summary>
        /// <para>Original signature is 'extern void glBlendFunc (GLenum sfactor, GLenum dfactor);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBlendFunc")]
        public static extern void glBlendFunc(GLenum sfactor, GLenum dfactor);

        /// <summary>
        /// <para>Original signature is 'extern void glCallList (GLuint list);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCallList")]
        public static extern void glCallList(GLuint list);

        /// <summary>
        /// <para>Original signature is 'extern void glCallLists (GLsizei n, GLenum type, const GLvoid *lists);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCallLists")]
        public static extern void glCallLists(GLsizei n, GLenum type, IntPtr lists);

        /// <summary>
        /// <para>Original signature is 'extern void glClear (GLbitfield mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClear")]
        public static extern void glClear(GLbitfield mask);

        /// <summary>
        /// <para>Original signature is 'extern void glClearAccum (GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClearAccum")]
        public static extern void glClearAccum(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glClearColor (GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClearColor")]
        public static extern void glClearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glClearDepth (GLclampd depth);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClearDepth")]
        public static extern void glClearDepth(GLclampd depth);

        /// <summary>
        /// <para>Original signature is 'extern void glClearIndex (GLfloat c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClearIndex")]
        public static extern void glClearIndex(GLfloat c);

        /// <summary>
        /// <para>Original signature is 'extern void glClearStencil (GLint s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClearStencil")]
        public static extern void glClearStencil(GLint s);

        /// <summary>
        /// <para>Original signature is 'extern void glClipPlane (GLenum plane, const GLdouble *equation);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClipPlane")]
        public static extern void glClipPlane(GLenum plane, IntPtr equation);

        /// <summary>
        /// <para>Original signature is 'extern void glClipPlane (GLenum plane, const GLdouble *equation);'</para>
        /// </summary>
        public static void glClipPlane(GLenum plane, GLdouble[] equation)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * equation.Length);
            Marshal.Copy(equation, 0, __local2, equation.Length);
            glClipPlane(plane, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glClipPlane (GLenum plane, const GLdouble *equation);'</para>
        /// </summary>
        public static void glClipPlane(GLenum plane, ref GLdouble equation)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(equation, __local2, false);
            glClipPlane(plane, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3b (GLbyte red, GLbyte green, GLbyte blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3b")]
        public static extern void glColor3b(GLbyte red, GLbyte green, GLbyte blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3bv (const GLbyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3bv")]
        public static extern void glColor3bv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glColor3bv(GLbyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)) * v.Length);
            GLubyte[] __array1 = Array.ConvertAll(v, item => (GLubyte)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glColor3bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glColor3bv(ref GLbyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)));
            Marshal.WriteByte(__local1, (GLubyte)v);
            glColor3bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3d (GLdouble red, GLdouble green, GLdouble blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3d")]
        public static extern void glColor3d(GLdouble red, GLdouble green, GLdouble blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3dv")]
        public static extern void glColor3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glColor3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glColor3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glColor3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3f (GLfloat red, GLfloat green, GLfloat blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3f")]
        public static extern void glColor3f(GLfloat red, GLfloat green, GLfloat blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3fv")]
        public static extern void glColor3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glColor3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glColor3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glColor3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3i (GLint red, GLint green, GLint blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3i")]
        public static extern void glColor3i(GLint red, GLint green, GLint blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3iv")]
        public static extern void glColor3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3iv (const GLint *v);'</para>
        /// </summary>
        public static void glColor3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3iv (const GLint *v);'</para>
        /// </summary>
        public static void glColor3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glColor3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3s (GLshort red, GLshort green, GLshort blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3s")]
        public static extern void glColor3s(GLshort red, GLshort green, GLshort blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3sv")]
        public static extern void glColor3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glColor3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glColor3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glColor3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3ub (GLubyte red, GLubyte green, GLubyte blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3ub")]
        public static extern void glColor3ub(GLubyte red, GLubyte green, GLubyte blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3ubv (const GLubyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3ubv")]
        public static extern void glColor3ubv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3ubv (const GLubyte *v);'</para>
        /// </summary>
        public static void glColor3ubv(GLubyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor3ubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3ubv (const GLubyte *v);'</para>
        /// </summary>
        public static void glColor3ubv(ref GLubyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, v);
            glColor3ubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3ui (GLuint red, GLuint green, GLuint blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3ui")]
        public static extern void glColor3ui(GLuint red, GLuint green, GLuint blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3uiv (const GLuint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3uiv")]
        public static extern void glColor3uiv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3uiv (const GLuint *v);'</para>
        /// </summary>
        public static void glColor3uiv(GLuint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * v.Length);
            GLint[] __array1 = Array.ConvertAll(v, item => (GLint)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glColor3uiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3uiv (const GLuint *v);'</para>
        /// </summary>
        public static void glColor3uiv(ref GLuint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local1, (GLint)v);
            glColor3uiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3us (GLushort red, GLushort green, GLushort blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3us")]
        public static extern void glColor3us(GLushort red, GLushort green, GLushort blue);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3usv (const GLushort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor3usv")]
        public static extern void glColor3usv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor3usv (const GLushort *v);'</para>
        /// </summary>
        public static void glColor3usv(GLushort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)) * v.Length);
            GLshort[] __array1 = Array.ConvertAll(v, item => (GLshort)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glColor3usv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor3usv (const GLushort *v);'</para>
        /// </summary>
        public static void glColor3usv(ref GLushort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            Marshal.WriteInt16(__local1, (GLshort)v);
            glColor3usv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4b (GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4b")]
        public static extern void glColor4b(GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4bv (const GLbyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4bv")]
        public static extern void glColor4bv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glColor4bv(GLbyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)) * v.Length);
            GLubyte[] __array1 = Array.ConvertAll(v, item => (GLubyte)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glColor4bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glColor4bv(ref GLbyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)));
            Marshal.WriteByte(__local1, (GLubyte)v);
            glColor4bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4d (GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4d")]
        public static extern void glColor4d(GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4dv")]
        public static extern void glColor4dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glColor4dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glColor4dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glColor4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4f (GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4f")]
        public static extern void glColor4f(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4fv")]
        public static extern void glColor4fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glColor4fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glColor4fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glColor4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4i (GLint red, GLint green, GLint blue, GLint alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4i")]
        public static extern void glColor4i(GLint red, GLint green, GLint blue, GLint alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4iv")]
        public static extern void glColor4iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4iv (const GLint *v);'</para>
        /// </summary>
        public static void glColor4iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4iv (const GLint *v);'</para>
        /// </summary>
        public static void glColor4iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glColor4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4s (GLshort red, GLshort green, GLshort blue, GLshort alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4s")]
        public static extern void glColor4s(GLshort red, GLshort green, GLshort blue, GLshort alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4sv")]
        public static extern void glColor4sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glColor4sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glColor4sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glColor4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4ub (GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4ub")]
        public static extern void glColor4ub(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4ubv (const GLubyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4ubv")]
        public static extern void glColor4ubv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4ubv (const GLubyte *v);'</para>
        /// </summary>
        public static void glColor4ubv(GLubyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glColor4ubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4ubv (const GLubyte *v);'</para>
        /// </summary>
        public static void glColor4ubv(ref GLubyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, v);
            glColor4ubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4ui (GLuint red, GLuint green, GLuint blue, GLuint alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4ui")]
        public static extern void glColor4ui(GLuint red, GLuint green, GLuint blue, GLuint alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4uiv (const GLuint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4uiv")]
        public static extern void glColor4uiv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4uiv (const GLuint *v);'</para>
        /// </summary>
        public static void glColor4uiv(GLuint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * v.Length);
            GLint[] __array1 = Array.ConvertAll(v, item => (GLint)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glColor4uiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4uiv (const GLuint *v);'</para>
        /// </summary>
        public static void glColor4uiv(ref GLuint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local1, (GLint)v);
            glColor4uiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4us (GLushort red, GLushort green, GLushort blue, GLushort alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4us")]
        public static extern void glColor4us(GLushort red, GLushort green, GLushort blue, GLushort alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4usv (const GLushort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColor4usv")]
        public static extern void glColor4usv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glColor4usv (const GLushort *v);'</para>
        /// </summary>
        public static void glColor4usv(GLushort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)) * v.Length);
            GLshort[] __array1 = Array.ConvertAll(v, item => (GLshort)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glColor4usv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColor4usv (const GLushort *v);'</para>
        /// </summary>
        public static void glColor4usv(ref GLushort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            Marshal.WriteInt16(__local1, (GLshort)v);
            glColor4usv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColorMask (GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorMask")]
        public static extern void glColorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);

        /// <summary>
        /// <para>Original signature is 'extern void glColorMaterial (GLenum face, GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorMaterial")]
        public static extern void glColorMaterial(GLenum face, GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glColorPointer (GLint size, GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorPointer")]
        public static extern void glColorPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glColorSubTable (GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorSubTable")]
        public static extern void glColorSubTable(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glColorTable (GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, const GLvoid *table);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorTable")]
        public static extern void glColorTable(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table);

        /// <summary>
        /// <para>Original signature is 'extern void glColorTableParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorTableParameterfv")]
        public static extern void glColorTableParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glColorTableParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glColorTableParameterfv(GLenum target, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glColorTableParameterfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColorTableParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glColorTableParameterfv(GLenum target, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glColorTableParameterfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColorTableParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glColorTableParameteriv")]
        public static extern void glColorTableParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glColorTableParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glColorTableParameteriv(GLenum target, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glColorTableParameteriv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glColorTableParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glColorTableParameteriv(GLenum target, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glColorTableParameteriv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionFilter1D (GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, const GLvoid *image);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glConvolutionFilter1D")]
        public static extern void glConvolutionFilter1D(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image);

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionFilter2D (GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, const GLvoid *image);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glConvolutionFilter2D")]
        public static extern void glConvolutionFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image);

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameterf (GLenum target, GLenum pname, GLfloat params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glConvolutionParameterf")]
        public static extern void glConvolutionParameterf(GLenum target, GLenum pname, GLfloat @params);

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glConvolutionParameterfv")]
        public static extern void glConvolutionParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glConvolutionParameterfv(GLenum target, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glConvolutionParameterfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glConvolutionParameterfv(GLenum target, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glConvolutionParameterfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameteri (GLenum target, GLenum pname, GLint params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glConvolutionParameteri")]
        public static extern void glConvolutionParameteri(GLenum target, GLenum pname, GLint @params);

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glConvolutionParameteriv")]
        public static extern void glConvolutionParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glConvolutionParameteriv(GLenum target, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glConvolutionParameteriv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glConvolutionParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glConvolutionParameteriv(GLenum target, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glConvolutionParameteriv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glCopyColorSubTable (GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyColorSubTable")]
        public static extern void glCopyColorSubTable(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyColorTable (GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyColorTable")]
        public static extern void glCopyColorTable(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyConvolutionFilter1D (GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyConvolutionFilter1D")]
        public static extern void glCopyConvolutionFilter1D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyConvolutionFilter2D (GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyConvolutionFilter2D")]
        public static extern void glCopyConvolutionFilter2D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyPixels (GLint x, GLint y, GLsizei width, GLsizei height, GLenum type);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyPixels")]
        public static extern void glCopyPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyTexImage1D (GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyTexImage1D")]
        public static extern void glCopyTexImage1D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyTexImage2D (GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyTexImage2D")]
        public static extern void glCopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyTexSubImage1D (GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyTexSubImage1D")]
        public static extern void glCopyTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyTexSubImage2D (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyTexSubImage2D")]
        public static extern void glCopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);

        /// <summary>
        /// <para>Original signature is 'extern void glCopyTexSubImage3D (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCopyTexSubImage3D")]
        public static extern void glCopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);

        /// <summary>
        /// <para>Original signature is 'extern void glCullFace (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCullFace")]
        public static extern void glCullFace(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteLists (GLuint list, GLsizei range);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDeleteLists")]
        public static extern void glDeleteLists(GLuint list, GLsizei range);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteTextures (GLsizei n, const GLuint *textures);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDeleteTextures")]
        public static extern void glDeleteTextures(GLsizei n, IntPtr textures);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteTextures (GLsizei n, const GLuint *textures);'</para>
        /// </summary>
        public static void glDeleteTextures(GLsizei n, GLuint[] textures)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * textures.Length);
            GLint[] __array2 = Array.ConvertAll(textures, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glDeleteTextures(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteTextures (GLsizei n, const GLuint *textures);'</para>
        /// </summary>
        public static void glDeleteTextures(GLsizei n, ref GLuint textures)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)textures);
            glDeleteTextures(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glDepthFunc (GLenum func);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDepthFunc")]
        public static extern void glDepthFunc(GLenum func);

        /// <summary>
        /// <para>Original signature is 'extern void glDepthMask (GLboolean flag);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDepthMask")]
        public static extern void glDepthMask(GLboolean flag);

        /// <summary>
        /// <para>Original signature is 'extern void glDepthRange (GLclampd zNear, GLclampd zFar);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDepthRange")]
        public static extern void glDepthRange(GLclampd zNear, GLclampd zFar);

        /// <summary>
        /// <para>Original signature is 'extern void glDisable (GLenum cap);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDisable")]
        public static extern void glDisable(GLenum cap);

        /// <summary>
        /// <para>Original signature is 'extern void glDisableClientState (GLenum array);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDisableClientState")]
        public static extern void glDisableClientState(GLenum array);

        /// <summary>
        /// <para>Original signature is 'extern void glDrawArrays (GLenum mode, GLint first, GLsizei count);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDrawArrays")]
        public static extern void glDrawArrays(GLenum mode, GLint first, GLsizei count);

        /// <summary>
        /// <para>Original signature is 'extern void glDrawBuffer (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDrawBuffer")]
        public static extern void glDrawBuffer(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glDrawElements (GLenum mode, GLsizei count, GLenum type, const GLvoid *indices);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDrawElements")]
        public static extern void glDrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr indices);

        /// <summary>
        /// <para>Original signature is 'extern void glDrawPixels (GLsizei width, GLsizei height, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDrawPixels")]
        public static extern void glDrawPixels(GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glDrawRangeElements (GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, const GLvoid *indices);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDrawRangeElements")]
        public static extern void glDrawRangeElements(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);

        /// <summary>
        /// <para>Original signature is 'extern void glEdgeFlag (GLboolean flag);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEdgeFlag")]
        public static extern void glEdgeFlag(GLboolean flag);

        /// <summary>
        /// <para>Original signature is 'extern void glEdgeFlagPointer (GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEdgeFlagPointer")]
        public static extern void glEdgeFlagPointer(GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glEdgeFlagv (const GLboolean *flag);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEdgeFlagv")]
        public static extern void glEdgeFlagv(IntPtr flag);

        /// <summary>
        /// <para>Original signature is 'extern void glEdgeFlagv (const GLboolean *flag);'</para>
        /// </summary>
        public static void glEdgeFlagv(GLboolean[] flag)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLboolean)) * flag.Length);
            Marshal.Copy(flag, 0, __local1, flag.Length);
            glEdgeFlagv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEdgeFlagv (const GLboolean *flag);'</para>
        /// </summary>
        public static void glEdgeFlagv(ref GLboolean flag)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLboolean)));
            Marshal.WriteByte(__local1, flag);
            glEdgeFlagv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEnable (GLenum cap);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEnable")]
        public static extern void glEnable(GLenum cap);

        /// <summary>
        /// <para>Original signature is 'extern void glEnableClientState (GLenum array);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEnableClientState")]
        public static extern void glEnableClientState(GLenum array);

        /// <summary>
        /// <para>Original signature is 'extern void glEnd (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEnd")]
        public static extern void glEnd();

        /// <summary>
        /// <para>Original signature is 'extern void glEndList (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEndList")]
        public static extern void glEndList();

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1d (GLdouble u);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord1d")]
        public static extern void glEvalCoord1d(GLdouble u);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1dv (const GLdouble *u);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord1dv")]
        public static extern void glEvalCoord1dv(IntPtr u);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1dv (const GLdouble *u);'</para>
        /// </summary>
        public static void glEvalCoord1dv(GLdouble[] u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * u.Length);
            Marshal.Copy(u, 0, __local1, u.Length);
            glEvalCoord1dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1dv (const GLdouble *u);'</para>
        /// </summary>
        public static void glEvalCoord1dv(ref GLdouble u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(u, __local1, false);
            glEvalCoord1dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1f (GLfloat u);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord1f")]
        public static extern void glEvalCoord1f(GLfloat u);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1fv (const GLfloat *u);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord1fv")]
        public static extern void glEvalCoord1fv(IntPtr u);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1fv (const GLfloat *u);'</para>
        /// </summary>
        public static void glEvalCoord1fv(GLfloat[] u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * u.Length);
            Marshal.Copy(u, 0, __local1, u.Length);
            glEvalCoord1fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord1fv (const GLfloat *u);'</para>
        /// </summary>
        public static void glEvalCoord1fv(ref GLfloat u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(u, __local1, false);
            glEvalCoord1fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2d (GLdouble u, GLdouble v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord2d")]
        public static extern void glEvalCoord2d(GLdouble u, GLdouble v);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2dv (const GLdouble *u);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord2dv")]
        public static extern void glEvalCoord2dv(IntPtr u);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2dv (const GLdouble *u);'</para>
        /// </summary>
        public static void glEvalCoord2dv(GLdouble[] u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * u.Length);
            Marshal.Copy(u, 0, __local1, u.Length);
            glEvalCoord2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2dv (const GLdouble *u);'</para>
        /// </summary>
        public static void glEvalCoord2dv(ref GLdouble u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(u, __local1, false);
            glEvalCoord2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2f (GLfloat u, GLfloat v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord2f")]
        public static extern void glEvalCoord2f(GLfloat u, GLfloat v);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2fv (const GLfloat *u);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalCoord2fv")]
        public static extern void glEvalCoord2fv(IntPtr u);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2fv (const GLfloat *u);'</para>
        /// </summary>
        public static void glEvalCoord2fv(GLfloat[] u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * u.Length);
            Marshal.Copy(u, 0, __local1, u.Length);
            glEvalCoord2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalCoord2fv (const GLfloat *u);'</para>
        /// </summary>
        public static void glEvalCoord2fv(ref GLfloat u)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(u, __local1, false);
            glEvalCoord2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glEvalMesh1 (GLenum mode, GLint i1, GLint i2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalMesh1")]
        public static extern void glEvalMesh1(GLenum mode, GLint i1, GLint i2);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalMesh2 (GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalMesh2")]
        public static extern void glEvalMesh2(GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalPoint1 (GLint i);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalPoint1")]
        public static extern void glEvalPoint1(GLint i);

        /// <summary>
        /// <para>Original signature is 'extern void glEvalPoint2 (GLint i, GLint j);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEvalPoint2")]
        public static extern void glEvalPoint2(GLint i, GLint j);

        /// <summary>
        /// <para>Original signature is 'extern void glFeedbackBuffer (GLsizei size, GLenum type, GLfloat *buffer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFeedbackBuffer")]
        public static extern void glFeedbackBuffer(GLsizei size, GLenum type, IntPtr buffer);

        /// <summary>
        /// <para>Original signature is 'extern void glFeedbackBuffer (GLsizei size, GLenum type, GLfloat *buffer);'</para>
        /// </summary>
        public static void glFeedbackBuffer(GLsizei size, GLenum type, out GLfloat buffer)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glFeedbackBuffer(size, type, __local3);
            buffer = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFinish (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFinish")]
        public static extern void glFinish();

        /// <summary>
        /// <para>Original signature is 'extern void glFlush (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFlush")]
        public static extern void glFlush();

        /// <summary>
        /// <para>Original signature is 'extern void glFogf (GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogf")]
        public static extern void glFogf(GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glFogfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogfv")]
        public static extern void glFogfv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glFogfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glFogfv(GLenum pname, GLfloat[] @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local2, @params.Length);
            glFogfv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glFogfv(GLenum pname, ref GLfloat @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local2, false);
            glFogfv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogi (GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogi")]
        public static extern void glFogi(GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glFogiv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogiv")]
        public static extern void glFogiv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glFogiv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glFogiv(GLenum pname, GLint[] @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local2, @params.Length);
            glFogiv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogiv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glFogiv(GLenum pname, ref GLint @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, @params);
            glFogiv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFrontFace (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFrontFace")]
        public static extern void glFrontFace(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glFrustum (GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFrustum")]
        public static extern void glFrustum(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);

        /// <summary>
        /// <para>Original signature is 'extern GLuint glGenLists (GLsizei range);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGenLists")]
        public static extern GLuint glGenLists(GLsizei range);

        /// <summary>
        /// <para>Original signature is 'extern void glGenTextures (GLsizei n, GLuint *textures);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGenTextures")]
        public static extern void glGenTextures(GLsizei n, IntPtr textures);

        /// <summary>
        /// <para>Original signature is 'extern void glGenTextures (GLsizei n, GLuint *textures);'</para>
        /// </summary>
        public static void glGenTextures(GLsizei n, out GLuint textures)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGenTextures(n, __local2);
            textures = (GLuint)Marshal.ReadInt32(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetBooleanv (GLenum pname, GLboolean *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetBooleanv")]
        public static extern void glGetBooleanv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetBooleanv (GLenum pname, GLboolean *params);'</para>
        /// </summary>
        public static void glGetBooleanv(GLenum pname, out GLboolean @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLboolean)));
            glGetBooleanv(pname, __local2);
            @params = (GLboolean)Marshal.ReadByte(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetClipPlane (GLenum plane, GLdouble *equation);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetClipPlane")]
        public static extern void glGetClipPlane(GLenum plane, IntPtr equation);

        /// <summary>
        /// <para>Original signature is 'extern void glGetClipPlane (GLenum plane, GLdouble *equation);'</para>
        /// </summary>
        public static void glGetClipPlane(GLenum plane, out GLdouble equation)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            glGetClipPlane(plane, __local2);
            equation = (GLdouble)Marshal.PtrToStructure(__local2, typeof(GLdouble));
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetColorTable (GLenum target, GLenum format, GLenum type, GLvoid *table);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetColorTable")]
        public static extern void glGetColorTable(GLenum target, GLenum format, GLenum type, IntPtr table);

        /// <summary>
        /// <para>Original signature is 'extern void glGetColorTableParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetColorTableParameterfv")]
        public static extern void glGetColorTableParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetColorTableParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetColorTableParameterfv(GLenum target, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetColorTableParameterfv(target, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetColorTableParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetColorTableParameteriv")]
        public static extern void glGetColorTableParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetColorTableParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetColorTableParameteriv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetColorTableParameteriv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetConvolutionFilter (GLenum target, GLenum format, GLenum type, GLvoid *image);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetConvolutionFilter")]
        public static extern void glGetConvolutionFilter(GLenum target, GLenum format, GLenum type, IntPtr image);

        /// <summary>
        /// <para>Original signature is 'extern void glGetConvolutionParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetConvolutionParameterfv")]
        public static extern void glGetConvolutionParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetConvolutionParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetConvolutionParameterfv(GLenum target, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetConvolutionParameterfv(target, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetConvolutionParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetConvolutionParameteriv")]
        public static extern void glGetConvolutionParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetConvolutionParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetConvolutionParameteriv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetConvolutionParameteriv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetDoublev (GLenum pname, GLdouble *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetDoublev")]
        public static extern void glGetDoublev(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetDoublev (GLenum pname, GLdouble *params);'</para>
        /// </summary>
        public static void glGetDoublev(GLenum pname, out GLdouble @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            glGetDoublev(pname, __local2);
            @params = (GLdouble)Marshal.PtrToStructure(__local2, typeof(GLdouble));
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLenum glGetError (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetError")]
        public static extern GLenum glGetError();

        /// <summary>
        /// <para>Original signature is 'extern void glGetFloatv (GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetFloatv")]
        public static extern void glGetFloatv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetFloatv (GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetFloatv(GLenum pname, out GLfloat @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetFloatv(pname, __local2);
            @params = (GLfloat)Marshal.PtrToStructure(__local2, typeof(GLfloat));
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetHistogram (GLenum target, GLboolean reset, GLenum format, GLenum type, GLvoid *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetHistogram")]
        public static extern void glGetHistogram(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glGetHistogramParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetHistogramParameterfv")]
        public static extern void glGetHistogramParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetHistogramParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetHistogramParameterfv(GLenum target, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetHistogramParameterfv(target, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetHistogramParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetHistogramParameteriv")]
        public static extern void glGetHistogramParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetHistogramParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetHistogramParameteriv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetHistogramParameteriv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetIntegerv (GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetIntegerv")]
        public static extern void glGetIntegerv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetIntegerv (GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetIntegerv(GLenum pname, out GLint @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetIntegerv(pname, __local2);
            @params = (GLint)Marshal.ReadInt32(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetLightfv (GLenum light, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetLightfv")]
        public static extern void glGetLightfv(GLenum light, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetLightfv (GLenum light, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetLightfv(GLenum light, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetLightfv(light, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetLightiv (GLenum light, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetLightiv")]
        public static extern void glGetLightiv(GLenum light, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetLightiv (GLenum light, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetLightiv(GLenum light, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetLightiv(light, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMapdv (GLenum target, GLenum query, GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMapdv")]
        public static extern void glGetMapdv(GLenum target, GLenum query, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMapdv (GLenum target, GLenum query, GLdouble *v);'</para>
        /// </summary>
        public static void glGetMapdv(GLenum target, GLenum query, out GLdouble v)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            glGetMapdv(target, query, __local3);
            v = (GLdouble)Marshal.PtrToStructure(__local3, typeof(GLdouble));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMapfv (GLenum target, GLenum query, GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMapfv")]
        public static extern void glGetMapfv(GLenum target, GLenum query, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMapfv (GLenum target, GLenum query, GLfloat *v);'</para>
        /// </summary>
        public static void glGetMapfv(GLenum target, GLenum query, out GLfloat v)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetMapfv(target, query, __local3);
            v = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMapiv (GLenum target, GLenum query, GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMapiv")]
        public static extern void glGetMapiv(GLenum target, GLenum query, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMapiv (GLenum target, GLenum query, GLint *v);'</para>
        /// </summary>
        public static void glGetMapiv(GLenum target, GLenum query, out GLint v)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetMapiv(target, query, __local3);
            v = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMaterialfv (GLenum face, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMaterialfv")]
        public static extern void glGetMaterialfv(GLenum face, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMaterialfv (GLenum face, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetMaterialfv(GLenum face, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetMaterialfv(face, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMaterialiv (GLenum face, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMaterialiv")]
        public static extern void glGetMaterialiv(GLenum face, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMaterialiv (GLenum face, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetMaterialiv(GLenum face, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetMaterialiv(face, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMinmax (GLenum target, GLboolean reset, GLenum format, GLenum type, GLvoid *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMinmax")]
        public static extern void glGetMinmax(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMinmaxParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMinmaxParameterfv")]
        public static extern void glGetMinmaxParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMinmaxParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetMinmaxParameterfv(GLenum target, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetMinmaxParameterfv(target, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetMinmaxParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetMinmaxParameteriv")]
        public static extern void glGetMinmaxParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetMinmaxParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetMinmaxParameteriv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetMinmaxParameteriv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetPixelMapfv (GLenum map, GLfloat *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetPixelMapfv")]
        public static extern void glGetPixelMapfv(GLenum map, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glGetPixelMapfv (GLenum map, GLfloat *values);'</para>
        /// </summary>
        public static void glGetPixelMapfv(GLenum map, out GLfloat values)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetPixelMapfv(map, __local2);
            values = (GLfloat)Marshal.PtrToStructure(__local2, typeof(GLfloat));
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetPixelMapuiv (GLenum map, GLuint *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetPixelMapuiv")]
        public static extern void glGetPixelMapuiv(GLenum map, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glGetPixelMapuiv (GLenum map, GLuint *values);'</para>
        /// </summary>
        public static void glGetPixelMapuiv(GLenum map, out GLuint values)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGetPixelMapuiv(map, __local2);
            values = (GLuint)Marshal.ReadInt32(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetPixelMapusv (GLenum map, GLushort *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetPixelMapusv")]
        public static extern void glGetPixelMapusv(GLenum map, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glGetPixelMapusv (GLenum map, GLushort *values);'</para>
        /// </summary>
        public static void glGetPixelMapusv(GLenum map, out GLushort values)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            glGetPixelMapusv(map, __local2);
            values = (GLushort)Marshal.ReadInt16(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetPointerv (GLenum pname, GLvoid* *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetPointerv")]
        public static extern void glGetPointerv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetPolygonStipple (GLubyte *mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetPolygonStipple")]
        public static extern void glGetPolygonStipple(IntPtr mask);

        /// <summary>
        /// <para>Original signature is 'extern void glGetPolygonStipple (GLubyte *mask);'</para>
        /// </summary>
        public static void glGetPolygonStipple(out GLubyte mask)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            glGetPolygonStipple(__local1);
            mask = Marshal.ReadByte(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetSeparableFilter (GLenum target, GLenum format, GLenum type, GLvoid *row, GLvoid *column, GLvoid *span);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetSeparableFilter")]
        public static extern void glGetSeparableFilter(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span);

        /// <summary>
        /// <para>Original signature is 'extern const GLubyte * glGetString (GLenum name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetString")]
        public static extern IntPtr glGetString(GLenum name);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexEnvfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexEnvfv")]
        public static extern void glGetTexEnvfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexEnvfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetTexEnvfv(GLenum target, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetTexEnvfv(target, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexEnviv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexEnviv")]
        public static extern void glGetTexEnviv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexEnviv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetTexEnviv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetTexEnviv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexGendv (GLenum coord, GLenum pname, GLdouble *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexGendv")]
        public static extern void glGetTexGendv(GLenum coord, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexGendv (GLenum coord, GLenum pname, GLdouble *params);'</para>
        /// </summary>
        public static void glGetTexGendv(GLenum coord, GLenum pname, out GLdouble @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            glGetTexGendv(coord, pname, __local3);
            @params = (GLdouble)Marshal.PtrToStructure(__local3, typeof(GLdouble));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexGenfv (GLenum coord, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexGenfv")]
        public static extern void glGetTexGenfv(GLenum coord, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexGenfv (GLenum coord, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetTexGenfv(GLenum coord, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetTexGenfv(coord, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexGeniv (GLenum coord, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexGeniv")]
        public static extern void glGetTexGeniv(GLenum coord, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexGeniv (GLenum coord, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetTexGeniv(GLenum coord, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetTexGeniv(coord, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexImage (GLenum target, GLint level, GLenum format, GLenum type, GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexImage")]
        public static extern void glGetTexImage(GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexLevelParameterfv (GLenum target, GLint level, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexLevelParameterfv")]
        public static extern void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexLevelParameterfv (GLenum target, GLint level, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, out GLfloat @params)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetTexLevelParameterfv(target, level, pname, __local4);
            @params = (GLfloat)Marshal.PtrToStructure(__local4, typeof(GLfloat));
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexLevelParameteriv (GLenum target, GLint level, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexLevelParameteriv")]
        public static extern void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexLevelParameteriv (GLenum target, GLint level, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, out GLint @params)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetTexLevelParameteriv(target, level, pname, __local4);
            @params = (GLint)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexParameterfv")]
        public static extern void glGetTexParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexParameterfv (GLenum target, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetTexParameterfv(GLenum target, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetTexParameterfv(target, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetTexParameteriv")]
        public static extern void glGetTexParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetTexParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetTexParameteriv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetTexParameteriv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glHint (GLenum target, GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glHint")]
        public static extern void glHint(GLenum target, GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glHistogram (GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glHistogram")]
        public static extern void glHistogram(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexMask (GLuint mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexMask")]
        public static extern void glIndexMask(GLuint mask);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexPointer (GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexPointer")]
        public static extern void glIndexPointer(GLenum type, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexd (GLdouble c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexd")]
        public static extern void glIndexd(GLdouble c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexdv (const GLdouble *c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexdv")]
        public static extern void glIndexdv(IntPtr c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexdv (const GLdouble *c);'</para>
        /// </summary>
        public static void glIndexdv(GLdouble[] c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * c.Length);
            Marshal.Copy(c, 0, __local1, c.Length);
            glIndexdv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexdv (const GLdouble *c);'</para>
        /// </summary>
        public static void glIndexdv(ref GLdouble c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(c, __local1, false);
            glIndexdv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexf (GLfloat c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexf")]
        public static extern void glIndexf(GLfloat c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexfv (const GLfloat *c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexfv")]
        public static extern void glIndexfv(IntPtr c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexfv (const GLfloat *c);'</para>
        /// </summary>
        public static void glIndexfv(GLfloat[] c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * c.Length);
            Marshal.Copy(c, 0, __local1, c.Length);
            glIndexfv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexfv (const GLfloat *c);'</para>
        /// </summary>
        public static void glIndexfv(ref GLfloat c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(c, __local1, false);
            glIndexfv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexi (GLint c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexi")]
        public static extern void glIndexi(GLint c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexiv (const GLint *c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexiv")]
        public static extern void glIndexiv(IntPtr c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexiv (const GLint *c);'</para>
        /// </summary>
        public static void glIndexiv(GLint[] c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * c.Length);
            Marshal.Copy(c, 0, __local1, c.Length);
            glIndexiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexiv (const GLint *c);'</para>
        /// </summary>
        public static void glIndexiv(ref GLint c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, c);
            glIndexiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexs (GLshort c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexs")]
        public static extern void glIndexs(GLshort c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexsv (const GLshort *c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexsv")]
        public static extern void glIndexsv(IntPtr c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexsv (const GLshort *c);'</para>
        /// </summary>
        public static void glIndexsv(GLshort[] c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * c.Length);
            Marshal.Copy(c, 0, __local1, c.Length);
            glIndexsv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexsv (const GLshort *c);'</para>
        /// </summary>
        public static void glIndexsv(ref GLshort c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, c);
            glIndexsv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexub (GLubyte c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexub")]
        public static extern void glIndexub(GLubyte c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexubv (const GLubyte *c);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIndexubv")]
        public static extern void glIndexubv(IntPtr c);

        /// <summary>
        /// <para>Original signature is 'extern void glIndexubv (const GLubyte *c);'</para>
        /// </summary>
        public static void glIndexubv(GLubyte[] c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * c.Length);
            Marshal.Copy(c, 0, __local1, c.Length);
            glIndexubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glIndexubv (const GLubyte *c);'</para>
        /// </summary>
        public static void glIndexubv(ref GLubyte c)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, c);
            glIndexubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glInitNames (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glInitNames")]
        public static extern void glInitNames();

        /// <summary>
        /// <para>Original signature is 'extern void glInterleavedArrays (GLenum format, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glInterleavedArrays")]
        public static extern void glInterleavedArrays(GLenum format, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsEnabled (GLenum cap);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsEnabled")]
        public static extern GLboolean glIsEnabled(GLenum cap);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsList (GLuint list);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsList")]
        public static extern GLboolean glIsList(GLuint list);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsTexture (GLuint texture);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsTexture")]
        public static extern GLboolean glIsTexture(GLuint texture);

        /// <summary>
        /// <para>Original signature is 'extern void glLightModelf (GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightModelf")]
        public static extern void glLightModelf(GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glLightModelfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightModelfv")]
        public static extern void glLightModelfv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glLightModelfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glLightModelfv(GLenum pname, GLfloat[] @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local2, @params.Length);
            glLightModelfv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLightModelfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glLightModelfv(GLenum pname, ref GLfloat @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local2, false);
            glLightModelfv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLightModeli (GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightModeli")]
        public static extern void glLightModeli(GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glLightModeliv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightModeliv")]
        public static extern void glLightModeliv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glLightModeliv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glLightModeliv(GLenum pname, GLint[] @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local2, @params.Length);
            glLightModeliv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLightModeliv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glLightModeliv(GLenum pname, ref GLint @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, @params);
            glLightModeliv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLightf (GLenum light, GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightf")]
        public static extern void glLightf(GLenum light, GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glLightfv (GLenum light, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightfv")]
        public static extern void glLightfv(GLenum light, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glLightfv (GLenum light, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glLightfv(GLenum light, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glLightfv(light, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLightfv (GLenum light, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glLightfv(GLenum light, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glLightfv(light, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLighti (GLenum light, GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLighti")]
        public static extern void glLighti(GLenum light, GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glLightiv (GLenum light, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLightiv")]
        public static extern void glLightiv(GLenum light, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glLightiv (GLenum light, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glLightiv(GLenum light, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glLightiv(light, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLightiv (GLenum light, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glLightiv(GLenum light, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glLightiv(light, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLineStipple (GLint factor, GLushort pattern);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLineStipple")]
        public static extern void glLineStipple(GLint factor, GLushort pattern);

        /// <summary>
        /// <para>Original signature is 'extern void glLineWidth (GLfloat width);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLineWidth")]
        public static extern void glLineWidth(GLfloat width);

        /// <summary>
        /// <para>Original signature is 'extern void glListBase (GLuint base);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glListBase")]
        public static extern void glListBase(GLuint @base);

        /// <summary>
        /// <para>Original signature is 'extern void glLoadIdentity (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLoadIdentity")]
        public static extern void glLoadIdentity();

        /// <summary>
        /// <para>Original signature is 'extern void glLoadMatrixd (const GLdouble *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLoadMatrixd")]
        public static extern void glLoadMatrixd(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glLoadMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glLoadMatrixd(GLdouble[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glLoadMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glLoadMatrixd(ref GLdouble m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(m, __local1, false);
            glLoadMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadMatrixf (const GLfloat *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLoadMatrixf")]
        public static extern void glLoadMatrixf(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glLoadMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glLoadMatrixf(GLfloat[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glLoadMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glLoadMatrixf(ref GLfloat m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(m, __local1, false);
            glLoadMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadName (GLuint name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLoadName")]
        public static extern void glLoadName(GLuint name);

        /// <summary>
        /// <para>Original signature is 'extern void glLogicOp (GLenum opcode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLogicOp")]
        public static extern void glLogicOp(GLenum opcode);

        /// <summary>
        /// <para>Original signature is 'extern void glMap1d (GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, const GLdouble *points);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMap1d")]
        public static extern void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, IntPtr points);

        /// <summary>
        /// <para>Original signature is 'extern void glMap1d (GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, const GLdouble *points);'</para>
        /// </summary>
        public static void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, GLdouble[] points)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * points.Length);
            Marshal.Copy(points, 0, __local6, points.Length);
            glMap1d(target, u1, u2, stride, order, __local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap1d (GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, const GLdouble *points);'</para>
        /// </summary>
        public static void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, ref GLdouble points)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(points, __local6, false);
            glMap1d(target, u1, u2, stride, order, __local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap1f (GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, const GLfloat *points);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMap1f")]
        public static extern void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, IntPtr points);

        /// <summary>
        /// <para>Original signature is 'extern void glMap1f (GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, const GLfloat *points);'</para>
        /// </summary>
        public static void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, GLfloat[] points)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * points.Length);
            Marshal.Copy(points, 0, __local6, points.Length);
            glMap1f(target, u1, u2, stride, order, __local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap1f (GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, const GLfloat *points);'</para>
        /// </summary>
        public static void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, ref GLfloat points)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(points, __local6, false);
            glMap1f(target, u1, u2, stride, order, __local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap2d (GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, const GLdouble *points);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMap2d")]
        public static extern void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, IntPtr points);

        /// <summary>
        /// <para>Original signature is 'extern void glMap2d (GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, const GLdouble *points);'</para>
        /// </summary>
        public static void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble[] points)
        {
            IntPtr __local10 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * points.Length);
            Marshal.Copy(points, 0, __local10, points.Length);
            glMap2d(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, __local10);
            Marshal.FreeHGlobal(__local10);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap2d (GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, const GLdouble *points);'</para>
        /// </summary>
        public static void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, ref GLdouble points)
        {
            IntPtr __local10 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(points, __local10, false);
            glMap2d(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, __local10);
            Marshal.FreeHGlobal(__local10);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap2f (GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, const GLfloat *points);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMap2f")]
        public static extern void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, IntPtr points);

        /// <summary>
        /// <para>Original signature is 'extern void glMap2f (GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, const GLfloat *points);'</para>
        /// </summary>
        public static void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat[] points)
        {
            IntPtr __local10 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * points.Length);
            Marshal.Copy(points, 0, __local10, points.Length);
            glMap2f(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, __local10);
            Marshal.FreeHGlobal(__local10);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMap2f (GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, const GLfloat *points);'</para>
        /// </summary>
        public static void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, ref GLfloat points)
        {
            IntPtr __local10 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(points, __local10, false);
            glMap2f(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, __local10);
            Marshal.FreeHGlobal(__local10);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMapGrid1d (GLint un, GLdouble u1, GLdouble u2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMapGrid1d")]
        public static extern void glMapGrid1d(GLint un, GLdouble u1, GLdouble u2);

        /// <summary>
        /// <para>Original signature is 'extern void glMapGrid1f (GLint un, GLfloat u1, GLfloat u2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMapGrid1f")]
        public static extern void glMapGrid1f(GLint un, GLfloat u1, GLfloat u2);

        /// <summary>
        /// <para>Original signature is 'extern void glMapGrid2d (GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMapGrid2d")]
        public static extern void glMapGrid2d(GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2);

        /// <summary>
        /// <para>Original signature is 'extern void glMapGrid2f (GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMapGrid2f")]
        public static extern void glMapGrid2f(GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2);

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialf (GLenum face, GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMaterialf")]
        public static extern void glMaterialf(GLenum face, GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialfv (GLenum face, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMaterialfv")]
        public static extern void glMaterialfv(GLenum face, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialfv (GLenum face, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glMaterialfv(GLenum face, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glMaterialfv(face, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialfv (GLenum face, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glMaterialfv(GLenum face, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glMaterialfv(face, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMateriali (GLenum face, GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMateriali")]
        public static extern void glMateriali(GLenum face, GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialiv (GLenum face, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMaterialiv")]
        public static extern void glMaterialiv(GLenum face, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialiv (GLenum face, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glMaterialiv(GLenum face, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glMaterialiv(face, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMaterialiv (GLenum face, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glMaterialiv(GLenum face, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glMaterialiv(face, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMatrixMode (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMatrixMode")]
        public static extern void glMatrixMode(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glMinmax (GLenum target, GLenum internalformat, GLboolean sink);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMinmax")]
        public static extern void glMinmax(GLenum target, GLenum internalformat, GLboolean sink);

        /// <summary>
        /// <para>Original signature is 'extern void glMultMatrixd (const GLdouble *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultMatrixd")]
        public static extern void glMultMatrixd(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glMultMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glMultMatrixd(GLdouble[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glMultMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glMultMatrixd(ref GLdouble m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(m, __local1, false);
            glMultMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultMatrixf (const GLfloat *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultMatrixf")]
        public static extern void glMultMatrixf(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glMultMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glMultMatrixf(GLfloat[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glMultMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glMultMatrixf(ref GLfloat m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(m, __local1, false);
            glMultMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNewList (GLuint list, GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNewList")]
        public static extern void glNewList(GLuint list, GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3b (GLbyte nx, GLbyte ny, GLbyte nz);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3b")]
        public static extern void glNormal3b(GLbyte nx, GLbyte ny, GLbyte nz);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3bv (const GLbyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3bv")]
        public static extern void glNormal3bv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glNormal3bv(GLbyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)) * v.Length);
            GLubyte[] __array1 = Array.ConvertAll(v, item => (GLubyte)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glNormal3bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glNormal3bv(ref GLbyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)));
            Marshal.WriteByte(__local1, (GLubyte)v);
            glNormal3bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3d (GLdouble nx, GLdouble ny, GLdouble nz);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3d")]
        public static extern void glNormal3d(GLdouble nx, GLdouble ny, GLdouble nz);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3dv")]
        public static extern void glNormal3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glNormal3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glNormal3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glNormal3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glNormal3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3f (GLfloat nx, GLfloat ny, GLfloat nz);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3f")]
        public static extern void glNormal3f(GLfloat nx, GLfloat ny, GLfloat nz);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3fv")]
        public static extern void glNormal3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glNormal3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glNormal3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glNormal3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glNormal3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3i (GLint nx, GLint ny, GLint nz);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3i")]
        public static extern void glNormal3i(GLint nx, GLint ny, GLint nz);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3iv")]
        public static extern void glNormal3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3iv (const GLint *v);'</para>
        /// </summary>
        public static void glNormal3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glNormal3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3iv (const GLint *v);'</para>
        /// </summary>
        public static void glNormal3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glNormal3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3s (GLshort nx, GLshort ny, GLshort nz);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3s")]
        public static extern void glNormal3s(GLshort nx, GLshort ny, GLshort nz);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormal3sv")]
        public static extern void glNormal3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glNormal3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glNormal3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormal3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glNormal3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glNormal3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glNormalPointer (GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glNormalPointer")]
        public static extern void glNormalPointer(GLenum type, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glOrtho (GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glOrtho")]
        public static extern void glOrtho(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);

        /// <summary>
        /// <para>Original signature is 'extern void glPassThrough (GLfloat token);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPassThrough")]
        public static extern void glPassThrough(GLfloat token);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapfv (GLenum map, GLint mapsize, const GLfloat *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelMapfv")]
        public static extern void glPixelMapfv(GLenum map, GLint mapsize, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapfv (GLenum map, GLint mapsize, const GLfloat *values);'</para>
        /// </summary>
        public static void glPixelMapfv(GLenum map, GLint mapsize, GLfloat[] values)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * values.Length);
            Marshal.Copy(values, 0, __local3, values.Length);
            glPixelMapfv(map, mapsize, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapfv (GLenum map, GLint mapsize, const GLfloat *values);'</para>
        /// </summary>
        public static void glPixelMapfv(GLenum map, GLint mapsize, ref GLfloat values)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(values, __local3, false);
            glPixelMapfv(map, mapsize, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapuiv (GLenum map, GLint mapsize, const GLuint *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelMapuiv")]
        public static extern void glPixelMapuiv(GLenum map, GLint mapsize, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapuiv (GLenum map, GLint mapsize, const GLuint *values);'</para>
        /// </summary>
        public static void glPixelMapuiv(GLenum map, GLint mapsize, GLuint[] values)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * values.Length);
            GLint[] __array3 = Array.ConvertAll(values, item => (GLint)item);
            Marshal.Copy(__array3, 0, __local3, __array3.Length);
            glPixelMapuiv(map, mapsize, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapuiv (GLenum map, GLint mapsize, const GLuint *values);'</para>
        /// </summary>
        public static void glPixelMapuiv(GLenum map, GLint mapsize, ref GLuint values)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local3, (GLint)values);
            glPixelMapuiv(map, mapsize, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapusv (GLenum map, GLint mapsize, const GLushort *values);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelMapusv")]
        public static extern void glPixelMapusv(GLenum map, GLint mapsize, IntPtr values);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapusv (GLenum map, GLint mapsize, const GLushort *values);'</para>
        /// </summary>
        public static void glPixelMapusv(GLenum map, GLint mapsize, GLushort[] values)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)) * values.Length);
            GLshort[] __array3 = Array.ConvertAll(values, item => (GLshort)item);
            Marshal.Copy(__array3, 0, __local3, __array3.Length);
            glPixelMapusv(map, mapsize, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPixelMapusv (GLenum map, GLint mapsize, const GLushort *values);'</para>
        /// </summary>
        public static void glPixelMapusv(GLenum map, GLint mapsize, ref GLushort values)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            Marshal.WriteInt16(__local3, (GLshort)values);
            glPixelMapusv(map, mapsize, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPixelStoref (GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelStoref")]
        public static extern void glPixelStoref(GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelStorei (GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelStorei")]
        public static extern void glPixelStorei(GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelTransferf (GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelTransferf")]
        public static extern void glPixelTransferf(GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelTransferi (GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelTransferi")]
        public static extern void glPixelTransferi(GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glPixelZoom (GLfloat xfactor, GLfloat yfactor);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPixelZoom")]
        public static extern void glPixelZoom(GLfloat xfactor, GLfloat yfactor);

        /// <summary>
        /// <para>Original signature is 'extern void glPointSize (GLfloat size);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPointSize")]
        public static extern void glPointSize(GLfloat size);

        /// <summary>
        /// <para>Original signature is 'extern void glPolygonMode (GLenum face, GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPolygonMode")]
        public static extern void glPolygonMode(GLenum face, GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glPolygonOffset (GLfloat factor, GLfloat units);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPolygonOffset")]
        public static extern void glPolygonOffset(GLfloat factor, GLfloat units);

        /// <summary>
        /// <para>Original signature is 'extern void glPolygonStipple (const GLubyte *mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPolygonStipple")]
        public static extern void glPolygonStipple(IntPtr mask);

        /// <summary>
        /// <para>Original signature is 'extern void glPolygonStipple (const GLubyte *mask);'</para>
        /// </summary>
        public static void glPolygonStipple(GLubyte[] mask)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * mask.Length);
            Marshal.Copy(mask, 0, __local1, mask.Length);
            glPolygonStipple(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPolygonStipple (const GLubyte *mask);'</para>
        /// </summary>
        public static void glPolygonStipple(ref GLubyte mask)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, mask);
            glPolygonStipple(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPopAttrib (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPopAttrib")]
        public static extern void glPopAttrib();

        /// <summary>
        /// <para>Original signature is 'extern void glPopClientAttrib (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPopClientAttrib")]
        public static extern void glPopClientAttrib();

        /// <summary>
        /// <para>Original signature is 'extern void glPopMatrix (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPopMatrix")]
        public static extern void glPopMatrix();

        /// <summary>
        /// <para>Original signature is 'extern void glPopName (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPopName")]
        public static extern void glPopName();

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPrioritizeTextures")]
        public static extern void glPrioritizeTextures(GLsizei n, IntPtr textures, IntPtr priorities);

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, IntPtr textures, GLclampf[] priorities)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLclampf)) * priorities.Length);
            Marshal.Copy(priorities, 0, __local3, priorities.Length);
            glPrioritizeTextures(n, textures, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, IntPtr textures, ref GLclampf priorities)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLclampf)));
            Marshal.StructureToPtr(priorities, __local3, false);
            glPrioritizeTextures(n, textures, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, GLuint[] textures, IntPtr priorities)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * textures.Length);
            GLint[] __array2 = Array.ConvertAll(textures, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glPrioritizeTextures(n, __local2, priorities);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, GLuint[] textures, GLclampf[] priorities)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * textures.Length);
            GLint[] __array2 = Array.ConvertAll(textures, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLclampf)) * priorities.Length);
            Marshal.Copy(priorities, 0, __local3, priorities.Length);
            glPrioritizeTextures(n, __local2, __local3);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, GLuint[] textures, ref GLclampf priorities)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * textures.Length);
            GLint[] __array2 = Array.ConvertAll(textures, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLclampf)));
            Marshal.StructureToPtr(priorities, __local3, false);
            glPrioritizeTextures(n, __local2, __local3);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, ref GLuint textures, IntPtr priorities)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)textures);
            glPrioritizeTextures(n, __local2, priorities);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, ref GLuint textures, GLclampf[] priorities)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)textures);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLclampf)) * priorities.Length);
            Marshal.Copy(priorities, 0, __local3, priorities.Length);
            glPrioritizeTextures(n, __local2, __local3);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPrioritizeTextures (GLsizei n, const GLuint *textures, const GLclampf *priorities);'</para>
        /// </summary>
        public static void glPrioritizeTextures(GLsizei n, ref GLuint textures, ref GLclampf priorities)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)textures);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLclampf)));
            Marshal.StructureToPtr(priorities, __local3, false);
            glPrioritizeTextures(n, __local2, __local3);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPushAttrib (GLbitfield mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPushAttrib")]
        public static extern void glPushAttrib(GLbitfield mask);

        /// <summary>
        /// <para>Original signature is 'extern void glPushClientAttrib (GLbitfield mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPushClientAttrib")]
        public static extern void glPushClientAttrib(GLbitfield mask);

        /// <summary>
        /// <para>Original signature is 'extern void glPushMatrix (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPushMatrix")]
        public static extern void glPushMatrix();

        /// <summary>
        /// <para>Original signature is 'extern void glPushName (GLuint name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPushName")]
        public static extern void glPushName(GLuint name);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2d (GLdouble x, GLdouble y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2d")]
        public static extern void glRasterPos2d(GLdouble x, GLdouble y);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2dv")]
        public static extern void glRasterPos2dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glRasterPos2dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glRasterPos2dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glRasterPos2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2f (GLfloat x, GLfloat y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2f")]
        public static extern void glRasterPos2f(GLfloat x, GLfloat y);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2fv")]
        public static extern void glRasterPos2fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glRasterPos2fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glRasterPos2fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glRasterPos2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2i (GLint x, GLint y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2i")]
        public static extern void glRasterPos2i(GLint x, GLint y);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2iv")]
        public static extern void glRasterPos2iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2iv (const GLint *v);'</para>
        /// </summary>
        public static void glRasterPos2iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2iv (const GLint *v);'</para>
        /// </summary>
        public static void glRasterPos2iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glRasterPos2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2s (GLshort x, GLshort y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2s")]
        public static extern void glRasterPos2s(GLshort x, GLshort y);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos2sv")]
        public static extern void glRasterPos2sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glRasterPos2sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glRasterPos2sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glRasterPos2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3d (GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3d")]
        public static extern void glRasterPos3d(GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3dv")]
        public static extern void glRasterPos3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glRasterPos3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glRasterPos3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glRasterPos3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3f (GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3f")]
        public static extern void glRasterPos3f(GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3fv")]
        public static extern void glRasterPos3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glRasterPos3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glRasterPos3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glRasterPos3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3i (GLint x, GLint y, GLint z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3i")]
        public static extern void glRasterPos3i(GLint x, GLint y, GLint z);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3iv")]
        public static extern void glRasterPos3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3iv (const GLint *v);'</para>
        /// </summary>
        public static void glRasterPos3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3iv (const GLint *v);'</para>
        /// </summary>
        public static void glRasterPos3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glRasterPos3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3s (GLshort x, GLshort y, GLshort z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3s")]
        public static extern void glRasterPos3s(GLshort x, GLshort y, GLshort z);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos3sv")]
        public static extern void glRasterPos3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glRasterPos3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glRasterPos3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glRasterPos3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4d (GLdouble x, GLdouble y, GLdouble z, GLdouble w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4d")]
        public static extern void glRasterPos4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4dv")]
        public static extern void glRasterPos4dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glRasterPos4dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glRasterPos4dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glRasterPos4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4f (GLfloat x, GLfloat y, GLfloat z, GLfloat w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4f")]
        public static extern void glRasterPos4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4fv")]
        public static extern void glRasterPos4fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glRasterPos4fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glRasterPos4fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glRasterPos4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4i (GLint x, GLint y, GLint z, GLint w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4i")]
        public static extern void glRasterPos4i(GLint x, GLint y, GLint z, GLint w);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4iv")]
        public static extern void glRasterPos4iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4iv (const GLint *v);'</para>
        /// </summary>
        public static void glRasterPos4iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4iv (const GLint *v);'</para>
        /// </summary>
        public static void glRasterPos4iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glRasterPos4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4s (GLshort x, GLshort y, GLshort z, GLshort w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4s")]
        public static extern void glRasterPos4s(GLshort x, GLshort y, GLshort z, GLshort w);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRasterPos4sv")]
        public static extern void glRasterPos4sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glRasterPos4sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glRasterPos4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRasterPos4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glRasterPos4sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glRasterPos4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glReadBuffer (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glReadBuffer")]
        public static extern void glReadBuffer(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glReadPixels (GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glReadPixels")]
        public static extern void glReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glRectd (GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRectd")]
        public static extern void glRectd(GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRectdv")]
        public static extern void glRectdv(IntPtr v1, IntPtr v2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(IntPtr v1, GLdouble[] v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectdv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(IntPtr v1, ref GLdouble v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v2, __local2, false);
            glRectdv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(GLdouble[] v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            glRectdv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(GLdouble[] v1, GLdouble[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectdv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(GLdouble[] v1, ref GLdouble v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v2, __local2, false);
            glRectdv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(ref GLdouble v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v1, __local1, false);
            glRectdv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(ref GLdouble v1, GLdouble[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v1, __local1, false);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectdv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectdv (const GLdouble *v1, const GLdouble *v2);'</para>
        /// </summary>
        public static void glRectdv(ref GLdouble v1, ref GLdouble v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v1, __local1, false);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v2, __local2, false);
            glRectdv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectf (GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRectf")]
        public static extern void glRectf(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRectfv")]
        public static extern void glRectfv(IntPtr v1, IntPtr v2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(IntPtr v1, GLfloat[] v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectfv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(IntPtr v1, ref GLfloat v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v2, __local2, false);
            glRectfv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(GLfloat[] v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            glRectfv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(GLfloat[] v1, GLfloat[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectfv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(GLfloat[] v1, ref GLfloat v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v2, __local2, false);
            glRectfv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(ref GLfloat v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v1, __local1, false);
            glRectfv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(ref GLfloat v1, GLfloat[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v1, __local1, false);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectfv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectfv (const GLfloat *v1, const GLfloat *v2);'</para>
        /// </summary>
        public static void glRectfv(ref GLfloat v1, ref GLfloat v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v1, __local1, false);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v2, __local2, false);
            glRectfv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRecti (GLint x1, GLint y1, GLint x2, GLint y2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRecti")]
        public static extern void glRecti(GLint x1, GLint y1, GLint x2, GLint y2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRectiv")]
        public static extern void glRectiv(IntPtr v1, IntPtr v2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(IntPtr v1, GLint[] v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectiv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(IntPtr v1, ref GLint v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v2);
            glRectiv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(GLint[] v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            glRectiv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(GLint[] v1, GLint[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectiv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(GLint[] v1, ref GLint v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v2);
            glRectiv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(ref GLint v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v1);
            glRectiv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(ref GLint v1, GLint[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v1);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectiv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectiv (const GLint *v1, const GLint *v2);'</para>
        /// </summary>
        public static void glRectiv(ref GLint v1, ref GLint v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v1);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v2);
            glRectiv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRects (GLshort x1, GLshort y1, GLshort x2, GLshort y2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRects")]
        public static extern void glRects(GLshort x1, GLshort y1, GLshort x2, GLshort y2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRectsv")]
        public static extern void glRectsv(IntPtr v1, IntPtr v2);

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(IntPtr v1, GLshort[] v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectsv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(IntPtr v1, ref GLshort v2)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v2);
            glRectsv(v1, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(GLshort[] v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            glRectsv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(GLshort[] v1, GLshort[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectsv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(GLshort[] v1, ref GLshort v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v1.Length);
            Marshal.Copy(v1, 0, __local1, v1.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v2);
            glRectsv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(ref GLshort v1, IntPtr v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v1);
            glRectsv(__local1, v2);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(ref GLshort v1, GLshort[] v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v1);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v2.Length);
            Marshal.Copy(v2, 0, __local2, v2.Length);
            glRectsv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glRectsv (const GLshort *v1, const GLshort *v2);'</para>
        /// </summary>
        public static void glRectsv(ref GLshort v1, ref GLshort v2)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v1);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v2);
            glRectsv(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint glRenderMode (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRenderMode")]
        public static extern GLint glRenderMode(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glResetHistogram (GLenum target);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glResetHistogram")]
        public static extern void glResetHistogram(GLenum target);

        /// <summary>
        /// <para>Original signature is 'extern void glResetMinmax (GLenum target);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glResetMinmax")]
        public static extern void glResetMinmax(GLenum target);

        /// <summary>
        /// <para>Original signature is 'extern void glRotated (GLdouble angle, GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRotated")]
        public static extern void glRotated(GLdouble angle, GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glRotatef (GLfloat angle, GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glRotatef")]
        public static extern void glRotatef(GLfloat angle, GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glScaled (GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glScaled")]
        public static extern void glScaled(GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glScalef (GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glScalef")]
        public static extern void glScalef(GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glScissor (GLint x, GLint y, GLsizei width, GLsizei height);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glScissor")]
        public static extern void glScissor(GLint x, GLint y, GLsizei width, GLsizei height);

        /// <summary>
        /// <para>Original signature is 'extern void glSelectBuffer (GLsizei size, GLuint *buffer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSelectBuffer")]
        public static extern void glSelectBuffer(GLsizei size, IntPtr buffer);

        /// <summary>
        /// <para>Original signature is 'extern void glSelectBuffer (GLsizei size, GLuint *buffer);'</para>
        /// </summary>
        public static void glSelectBuffer(GLsizei size, out GLuint buffer)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glSelectBuffer(size, __local2);
            buffer = (GLuint)Marshal.ReadInt32(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSeparableFilter2D (GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, const GLvoid *row, const GLvoid *column);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSeparableFilter2D")]
        public static extern void glSeparableFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column);

        /// <summary>
        /// <para>Original signature is 'extern void glShadeModel (GLenum mode);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glShadeModel")]
        public static extern void glShadeModel(GLenum mode);

        /// <summary>
        /// <para>Original signature is 'extern void glStencilFunc (GLenum func, GLint ref, GLuint mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glStencilFunc")]
        public static extern void glStencilFunc(GLenum func, GLint @ref, GLuint mask);

        /// <summary>
        /// <para>Original signature is 'extern void glStencilMask (GLuint mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glStencilMask")]
        public static extern void glStencilMask(GLuint mask);

        /// <summary>
        /// <para>Original signature is 'extern void glStencilOp (GLenum fail, GLenum zfail, GLenum zpass);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glStencilOp")]
        public static extern void glStencilOp(GLenum fail, GLenum zfail, GLenum zpass);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1d (GLdouble s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1d")]
        public static extern void glTexCoord1d(GLdouble s);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1dv")]
        public static extern void glTexCoord1dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord1dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord1dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord1dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord1dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1f (GLfloat s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1f")]
        public static extern void glTexCoord1f(GLfloat s);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1fv")]
        public static extern void glTexCoord1fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord1fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord1fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord1fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord1fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1i (GLint s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1i")]
        public static extern void glTexCoord1i(GLint s);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1iv")]
        public static extern void glTexCoord1iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord1iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord1iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord1iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glTexCoord1iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1s (GLshort s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1s")]
        public static extern void glTexCoord1s(GLshort s);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord1sv")]
        public static extern void glTexCoord1sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord1sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord1sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord1sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord1sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glTexCoord1sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2d (GLdouble s, GLdouble t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2d")]
        public static extern void glTexCoord2d(GLdouble s, GLdouble t);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2dv")]
        public static extern void glTexCoord2dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord2dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord2dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2f (GLfloat s, GLfloat t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2f")]
        public static extern void glTexCoord2f(GLfloat s, GLfloat t);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2fv")]
        public static extern void glTexCoord2fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord2fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord2fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2i (GLint s, GLint t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2i")]
        public static extern void glTexCoord2i(GLint s, GLint t);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2iv")]
        public static extern void glTexCoord2iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord2iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord2iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glTexCoord2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2s (GLshort s, GLshort t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2s")]
        public static extern void glTexCoord2s(GLshort s, GLshort t);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord2sv")]
        public static extern void glTexCoord2sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord2sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord2sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glTexCoord2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3d (GLdouble s, GLdouble t, GLdouble r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3d")]
        public static extern void glTexCoord3d(GLdouble s, GLdouble t, GLdouble r);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3dv")]
        public static extern void glTexCoord3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3f (GLfloat s, GLfloat t, GLfloat r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3f")]
        public static extern void glTexCoord3f(GLfloat s, GLfloat t, GLfloat r);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3fv")]
        public static extern void glTexCoord3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3i (GLint s, GLint t, GLint r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3i")]
        public static extern void glTexCoord3i(GLint s, GLint t, GLint r);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3iv")]
        public static extern void glTexCoord3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glTexCoord3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3s (GLshort s, GLshort t, GLshort r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3s")]
        public static extern void glTexCoord3s(GLshort s, GLshort t, GLshort r);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord3sv")]
        public static extern void glTexCoord3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glTexCoord3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4d (GLdouble s, GLdouble t, GLdouble r, GLdouble q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4d")]
        public static extern void glTexCoord4d(GLdouble s, GLdouble t, GLdouble r, GLdouble q);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4dv")]
        public static extern void glTexCoord4dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord4dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glTexCoord4dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4f (GLfloat s, GLfloat t, GLfloat r, GLfloat q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4f")]
        public static extern void glTexCoord4f(GLfloat s, GLfloat t, GLfloat r, GLfloat q);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4fv")]
        public static extern void glTexCoord4fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord4fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glTexCoord4fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glTexCoord4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4i (GLint s, GLint t, GLint r, GLint q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4i")]
        public static extern void glTexCoord4i(GLint s, GLint t, GLint r, GLint q);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4iv")]
        public static extern void glTexCoord4iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord4iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4iv (const GLint *v);'</para>
        /// </summary>
        public static void glTexCoord4iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glTexCoord4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4s (GLshort s, GLshort t, GLshort r, GLshort q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4s")]
        public static extern void glTexCoord4s(GLshort s, GLshort t, GLshort r, GLshort q);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoord4sv")]
        public static extern void glTexCoord4sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord4sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glTexCoord4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoord4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glTexCoord4sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glTexCoord4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexCoordPointer (GLint size, GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexCoordPointer")]
        public static extern void glTexCoordPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnvf (GLenum target, GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexEnvf")]
        public static extern void glTexEnvf(GLenum target, GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnvfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexEnvfv")]
        public static extern void glTexEnvfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnvfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glTexEnvfv(GLenum target, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexEnvfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnvfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glTexEnvfv(GLenum target, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glTexEnvfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnvi (GLenum target, GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexEnvi")]
        public static extern void glTexEnvi(GLenum target, GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnviv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexEnviv")]
        public static extern void glTexEnviv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnviv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glTexEnviv(GLenum target, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexEnviv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexEnviv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glTexEnviv(GLenum target, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glTexEnviv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexGend (GLenum coord, GLenum pname, GLdouble param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexGend")]
        public static extern void glTexGend(GLenum coord, GLenum pname, GLdouble param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexGendv (GLenum coord, GLenum pname, const GLdouble *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexGendv")]
        public static extern void glTexGendv(GLenum coord, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexGendv (GLenum coord, GLenum pname, const GLdouble *params);'</para>
        /// </summary>
        public static void glTexGendv(GLenum coord, GLenum pname, GLdouble[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexGendv(coord, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexGendv (GLenum coord, GLenum pname, const GLdouble *params);'</para>
        /// </summary>
        public static void glTexGendv(GLenum coord, GLenum pname, ref GLdouble @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(@params, __local3, false);
            glTexGendv(coord, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexGenf (GLenum coord, GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexGenf")]
        public static extern void glTexGenf(GLenum coord, GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexGenfv (GLenum coord, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexGenfv")]
        public static extern void glTexGenfv(GLenum coord, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexGenfv (GLenum coord, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glTexGenfv(GLenum coord, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexGenfv(coord, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexGenfv (GLenum coord, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glTexGenfv(GLenum coord, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glTexGenfv(coord, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexGeni (GLenum coord, GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexGeni")]
        public static extern void glTexGeni(GLenum coord, GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexGeniv (GLenum coord, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexGeniv")]
        public static extern void glTexGeniv(GLenum coord, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexGeniv (GLenum coord, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glTexGeniv(GLenum coord, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexGeniv(coord, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexGeniv (GLenum coord, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glTexGeniv(GLenum coord, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glTexGeniv(coord, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexImage1D (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexImage1D")]
        public static extern void glTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glTexImage2D (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexImage2D")]
        public static extern void glTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glTexImage3D (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexImage3D")]
        public static extern void glTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameterf (GLenum target, GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexParameterf")]
        public static extern void glTexParameterf(GLenum target, GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexParameterfv")]
        public static extern void glTexParameterfv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glTexParameterfv(GLenum target, GLenum pname, GLfloat[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexParameterfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameterfv (GLenum target, GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glTexParameterfv(GLenum target, GLenum pname, ref GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local3, false);
            glTexParameterfv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameteri (GLenum target, GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexParameteri")]
        public static extern void glTexParameteri(GLenum target, GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexParameteriv")]
        public static extern void glTexParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glTexParameteriv(GLenum target, GLenum pname, GLint[] @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local3, @params.Length);
            glTexParameteriv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexParameteriv (GLenum target, GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glTexParameteriv(GLenum target, GLenum pname, ref GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, @params);
            glTexParameteriv(target, pname, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glTexSubImage1D (GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexSubImage1D")]
        public static extern void glTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glTexSubImage2D (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexSubImage2D")]
        public static extern void glTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glTexSubImage3D (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, const GLvoid *pixels);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTexSubImage3D")]
        public static extern void glTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);

        /// <summary>
        /// <para>Original signature is 'extern void glTranslated (GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTranslated")]
        public static extern void glTranslated(GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glTranslatef (GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glTranslatef")]
        public static extern void glTranslatef(GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2d (GLdouble x, GLdouble y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2d")]
        public static extern void glVertex2d(GLdouble x, GLdouble y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2dv")]
        public static extern void glVertex2dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glVertex2dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glVertex2dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glVertex2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2f (GLfloat x, GLfloat y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2f")]
        public static extern void glVertex2f(GLfloat x, GLfloat y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2fv")]
        public static extern void glVertex2fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glVertex2fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glVertex2fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glVertex2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2i (GLint x, GLint y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2i")]
        public static extern void glVertex2i(GLint x, GLint y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2iv")]
        public static extern void glVertex2iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2iv (const GLint *v);'</para>
        /// </summary>
        public static void glVertex2iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2iv (const GLint *v);'</para>
        /// </summary>
        public static void glVertex2iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glVertex2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2s (GLshort x, GLshort y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2s")]
        public static extern void glVertex2s(GLshort x, GLshort y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex2sv")]
        public static extern void glVertex2sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glVertex2sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glVertex2sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glVertex2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3d (GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3d")]
        public static extern void glVertex3d(GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3dv")]
        public static extern void glVertex3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glVertex3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glVertex3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glVertex3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3f (GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3f")]
        public static extern void glVertex3f(GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3fv")]
        public static extern void glVertex3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glVertex3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glVertex3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glVertex3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3i (GLint x, GLint y, GLint z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3i")]
        public static extern void glVertex3i(GLint x, GLint y, GLint z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3iv")]
        public static extern void glVertex3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3iv (const GLint *v);'</para>
        /// </summary>
        public static void glVertex3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3iv (const GLint *v);'</para>
        /// </summary>
        public static void glVertex3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glVertex3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3s (GLshort x, GLshort y, GLshort z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3s")]
        public static extern void glVertex3s(GLshort x, GLshort y, GLshort z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex3sv")]
        public static extern void glVertex3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glVertex3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glVertex3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glVertex3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4d (GLdouble x, GLdouble y, GLdouble z, GLdouble w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4d")]
        public static extern void glVertex4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4dv")]
        public static extern void glVertex4dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glVertex4dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glVertex4dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glVertex4dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4f (GLfloat x, GLfloat y, GLfloat z, GLfloat w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4f")]
        public static extern void glVertex4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4fv")]
        public static extern void glVertex4fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glVertex4fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glVertex4fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glVertex4fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4i (GLint x, GLint y, GLint z, GLint w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4i")]
        public static extern void glVertex4i(GLint x, GLint y, GLint z, GLint w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4iv")]
        public static extern void glVertex4iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4iv (const GLint *v);'</para>
        /// </summary>
        public static void glVertex4iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4iv (const GLint *v);'</para>
        /// </summary>
        public static void glVertex4iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glVertex4iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4s (GLshort x, GLshort y, GLshort z, GLshort w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4s")]
        public static extern void glVertex4s(GLshort x, GLshort y, GLshort z, GLshort w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertex4sv")]
        public static extern void glVertex4sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glVertex4sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glVertex4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertex4sv (const GLshort *v);'</para>
        /// </summary>
        public static void glVertex4sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glVertex4sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexPointer (GLint size, GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexPointer")]
        public static extern void glVertexPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glViewport (GLint x, GLint y, GLsizei width, GLsizei height);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glViewport")]
        public static extern void glViewport(GLint x, GLint y, GLsizei width, GLsizei height);


        /// <summary>
        /// <para>Original signature is 'extern void glSampleCoverage (GLclampf value, GLboolean invert);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSampleCoverage")]
        public static extern void glSampleCoverage(GLclampf value, GLboolean invert);

        /// <summary>
        /// <para>Original signature is 'extern void glSamplePass (GLenum pass);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSamplePass")]
        public static extern void glSamplePass(GLenum pass);


        /// <summary>
        /// <para>Original signature is 'extern void glLoadTransposeMatrixf (const GLfloat *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLoadTransposeMatrixf")]
        public static extern void glLoadTransposeMatrixf(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glLoadTransposeMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glLoadTransposeMatrixf(GLfloat[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glLoadTransposeMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadTransposeMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glLoadTransposeMatrixf(ref GLfloat m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(m, __local1, false);
            glLoadTransposeMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadTransposeMatrixd (const GLdouble *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLoadTransposeMatrixd")]
        public static extern void glLoadTransposeMatrixd(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glLoadTransposeMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glLoadTransposeMatrixd(GLdouble[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glLoadTransposeMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glLoadTransposeMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glLoadTransposeMatrixd(ref GLdouble m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(m, __local1, false);
            glLoadTransposeMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultTransposeMatrixf (const GLfloat *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultTransposeMatrixf")]
        public static extern void glMultTransposeMatrixf(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glMultTransposeMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glMultTransposeMatrixf(GLfloat[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glMultTransposeMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultTransposeMatrixf (const GLfloat *m);'</para>
        /// </summary>
        public static void glMultTransposeMatrixf(ref GLfloat m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(m, __local1, false);
            glMultTransposeMatrixf(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultTransposeMatrixd (const GLdouble *m);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultTransposeMatrixd")]
        public static extern void glMultTransposeMatrixd(IntPtr m);

        /// <summary>
        /// <para>Original signature is 'extern void glMultTransposeMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glMultTransposeMatrixd(GLdouble[] m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * m.Length);
            Marshal.Copy(m, 0, __local1, m.Length);
            glMultTransposeMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultTransposeMatrixd (const GLdouble *m);'</para>
        /// </summary>
        public static void glMultTransposeMatrixd(ref GLdouble m)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(m, __local1, false);
            glMultTransposeMatrixd(__local1);
            Marshal.FreeHGlobal(__local1);
        }


        /// <summary>
        /// <para>Original signature is 'extern void glCompressedTexImage3D (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompressedTexImage3D")]
        public static extern void glCompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glCompressedTexImage2D (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompressedTexImage2D")]
        public static extern void glCompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glCompressedTexImage1D (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompressedTexImage1D")]
        public static extern void glCompressedTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glCompressedTexSubImage3D (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompressedTexSubImage3D")]
        public static extern void glCompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glCompressedTexSubImage2D (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompressedTexSubImage2D")]
        public static extern void glCompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glCompressedTexSubImage1D (GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompressedTexSubImage1D")]
        public static extern void glCompressedTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glGetCompressedTexImage (GLenum target, GLint lod, GLvoid *img);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetCompressedTexImage")]
        public static extern void glGetCompressedTexImage(GLenum target, GLint lod, IntPtr img);


        /// <summary>
        /// <para>Original signature is 'extern void glActiveTexture (GLenum texture);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glActiveTexture")]
        public static extern void glActiveTexture(GLenum texture);

        /// <summary>
        /// <para>Original signature is 'extern void glClientActiveTexture (GLenum texture);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glClientActiveTexture")]
        public static extern void glClientActiveTexture(GLenum texture);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1d (GLenum target, GLdouble s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1d")]
        public static extern void glMultiTexCoord1d(GLenum target, GLdouble s);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1dv")]
        public static extern void glMultiTexCoord1dv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1dv(GLenum target, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord1dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1dv(GLenum target, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord1dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1f (GLenum target, GLfloat s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1f")]
        public static extern void glMultiTexCoord1f(GLenum target, GLfloat s);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1fv")]
        public static extern void glMultiTexCoord1fv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1fv(GLenum target, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord1fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1fv(GLenum target, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord1fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1i (GLenum target, GLint s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1i")]
        public static extern void glMultiTexCoord1i(GLenum target, GLint s);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1iv")]
        public static extern void glMultiTexCoord1iv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1iv(GLenum target, GLint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord1iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1iv(GLenum target, ref GLint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v);
            glMultiTexCoord1iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1s (GLenum target, GLshort s);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1s")]
        public static extern void glMultiTexCoord1s(GLenum target, GLshort s);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord1sv")]
        public static extern void glMultiTexCoord1sv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1sv(GLenum target, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord1sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord1sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord1sv(GLenum target, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glMultiTexCoord1sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2d (GLenum target, GLdouble s, GLdouble t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2d")]
        public static extern void glMultiTexCoord2d(GLenum target, GLdouble s, GLdouble t);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2dv")]
        public static extern void glMultiTexCoord2dv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2dv(GLenum target, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord2dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2dv(GLenum target, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord2dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2f (GLenum target, GLfloat s, GLfloat t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2f")]
        public static extern void glMultiTexCoord2f(GLenum target, GLfloat s, GLfloat t);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2fv")]
        public static extern void glMultiTexCoord2fv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2fv(GLenum target, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord2fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2fv(GLenum target, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord2fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2i (GLenum target, GLint s, GLint t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2i")]
        public static extern void glMultiTexCoord2i(GLenum target, GLint s, GLint t);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2iv")]
        public static extern void glMultiTexCoord2iv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2iv(GLenum target, GLint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord2iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2iv(GLenum target, ref GLint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v);
            glMultiTexCoord2iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2s (GLenum target, GLshort s, GLshort t);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2s")]
        public static extern void glMultiTexCoord2s(GLenum target, GLshort s, GLshort t);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord2sv")]
        public static extern void glMultiTexCoord2sv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2sv(GLenum target, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord2sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord2sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord2sv(GLenum target, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glMultiTexCoord2sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3d (GLenum target, GLdouble s, GLdouble t, GLdouble r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3d")]
        public static extern void glMultiTexCoord3d(GLenum target, GLdouble s, GLdouble t, GLdouble r);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3dv")]
        public static extern void glMultiTexCoord3dv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3dv(GLenum target, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord3dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3dv(GLenum target, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord3dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3f (GLenum target, GLfloat s, GLfloat t, GLfloat r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3f")]
        public static extern void glMultiTexCoord3f(GLenum target, GLfloat s, GLfloat t, GLfloat r);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3fv")]
        public static extern void glMultiTexCoord3fv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3fv(GLenum target, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord3fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3fv(GLenum target, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord3fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3i (GLenum target, GLint s, GLint t, GLint r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3i")]
        public static extern void glMultiTexCoord3i(GLenum target, GLint s, GLint t, GLint r);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3iv")]
        public static extern void glMultiTexCoord3iv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3iv(GLenum target, GLint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord3iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3iv(GLenum target, ref GLint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v);
            glMultiTexCoord3iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3s (GLenum target, GLshort s, GLshort t, GLshort r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3s")]
        public static extern void glMultiTexCoord3s(GLenum target, GLshort s, GLshort t, GLshort r);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord3sv")]
        public static extern void glMultiTexCoord3sv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3sv(GLenum target, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord3sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord3sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord3sv(GLenum target, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glMultiTexCoord3sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4d (GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4d")]
        public static extern void glMultiTexCoord4d(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4dv")]
        public static extern void glMultiTexCoord4dv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4dv(GLenum target, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord4dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4dv (GLenum target, const GLdouble *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4dv(GLenum target, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord4dv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4f (GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4f")]
        public static extern void glMultiTexCoord4f(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4fv")]
        public static extern void glMultiTexCoord4fv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4fv(GLenum target, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord4fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4fv (GLenum target, const GLfloat *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4fv(GLenum target, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glMultiTexCoord4fv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4i (GLenum target, GLint, GLint s, GLint t, GLint r);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4i")]
        public static extern void glMultiTexCoord4i(GLenum target, GLint p1, GLint s, GLint t, GLint r);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4iv")]
        public static extern void glMultiTexCoord4iv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4iv(GLenum target, GLint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord4iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4iv (GLenum target, const GLint *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4iv(GLenum target, ref GLint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v);
            glMultiTexCoord4iv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4s (GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4s")]
        public static extern void glMultiTexCoord4s(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiTexCoord4sv")]
        public static extern void glMultiTexCoord4sv(GLenum target, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4sv(GLenum target, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glMultiTexCoord4sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiTexCoord4sv (GLenum target, const GLshort *v);'</para>
        /// </summary>
        public static void glMultiTexCoord4sv(GLenum target, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glMultiTexCoord4sv(target, __local2);
            Marshal.FreeHGlobal(__local2);
        }


        /// <summary>
        /// <para>Original signature is 'extern void glFogCoordf (GLfloat coord);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogCoordf")]
        public static extern void glFogCoordf(GLfloat coord);

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoordfv (const GLfloat *coord);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogCoordfv")]
        public static extern void glFogCoordfv(IntPtr coord);

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoordfv (const GLfloat *coord);'</para>
        /// </summary>
        public static void glFogCoordfv(GLfloat[] coord)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * coord.Length);
            Marshal.Copy(coord, 0, __local1, coord.Length);
            glFogCoordfv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoordfv (const GLfloat *coord);'</para>
        /// </summary>
        public static void glFogCoordfv(ref GLfloat coord)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(coord, __local1, false);
            glFogCoordfv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoordd (GLdouble coord);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogCoordd")]
        public static extern void glFogCoordd(GLdouble coord);

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoorddv (const GLdouble * coord);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogCoorddv")]
        public static extern void glFogCoorddv(IntPtr coord);

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoorddv (const GLdouble * coord);'</para>
        /// </summary>
        public static void glFogCoorddv(GLdouble[] coord)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * coord.Length);
            Marshal.Copy(coord, 0, __local1, coord.Length);
            glFogCoorddv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoorddv (const GLdouble * coord);'</para>
        /// </summary>
        public static void glFogCoorddv(ref GLdouble coord)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(coord, __local1, false);
            glFogCoorddv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glFogCoordPointer (GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glFogCoordPointer")]
        public static extern void glFogCoordPointer(GLenum type, GLsizei stride, IntPtr pointer);


        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3b (GLbyte red, GLbyte green, GLbyte blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3b")]
        public static extern void glSecondaryColor3b(GLbyte red, GLbyte green, GLbyte blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3bv (const GLbyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3bv")]
        public static extern void glSecondaryColor3bv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glSecondaryColor3bv(GLbyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)) * v.Length);
            GLubyte[] __array1 = Array.ConvertAll(v, item => (GLubyte)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glSecondaryColor3bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3bv (const GLbyte *v);'</para>
        /// </summary>
        public static void glSecondaryColor3bv(ref GLbyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)));
            Marshal.WriteByte(__local1, (GLubyte)v);
            glSecondaryColor3bv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3d (GLdouble red, GLdouble green, GLdouble blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3d")]
        public static extern void glSecondaryColor3d(GLdouble red, GLdouble green, GLdouble blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3dv")]
        public static extern void glSecondaryColor3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glSecondaryColor3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glSecondaryColor3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glSecondaryColor3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glSecondaryColor3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3f (GLfloat red, GLfloat green, GLfloat blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3f")]
        public static extern void glSecondaryColor3f(GLfloat red, GLfloat green, GLfloat blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3fv")]
        public static extern void glSecondaryColor3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glSecondaryColor3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glSecondaryColor3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glSecondaryColor3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glSecondaryColor3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3i (GLint red, GLint green, GLint blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3i")]
        public static extern void glSecondaryColor3i(GLint red, GLint green, GLint blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3iv")]
        public static extern void glSecondaryColor3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3iv (const GLint *v);'</para>
        /// </summary>
        public static void glSecondaryColor3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glSecondaryColor3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3iv (const GLint *v);'</para>
        /// </summary>
        public static void glSecondaryColor3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glSecondaryColor3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3s (GLshort red, GLshort green, GLshort blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3s")]
        public static extern void glSecondaryColor3s(GLshort red, GLshort green, GLshort blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3sv")]
        public static extern void glSecondaryColor3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glSecondaryColor3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glSecondaryColor3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glSecondaryColor3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glSecondaryColor3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3ub (GLubyte red, GLubyte green, GLubyte blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3ub")]
        public static extern void glSecondaryColor3ub(GLubyte red, GLubyte green, GLubyte blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3ubv (const GLubyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3ubv")]
        public static extern void glSecondaryColor3ubv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3ubv (const GLubyte *v);'</para>
        /// </summary>
        public static void glSecondaryColor3ubv(GLubyte[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glSecondaryColor3ubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3ubv (const GLubyte *v);'</para>
        /// </summary>
        public static void glSecondaryColor3ubv(ref GLubyte v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, v);
            glSecondaryColor3ubv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3ui (GLuint red, GLuint green, GLuint blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3ui")]
        public static extern void glSecondaryColor3ui(GLuint red, GLuint green, GLuint blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3uiv (const GLuint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3uiv")]
        public static extern void glSecondaryColor3uiv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3uiv (const GLuint *v);'</para>
        /// </summary>
        public static void glSecondaryColor3uiv(GLuint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * v.Length);
            GLint[] __array1 = Array.ConvertAll(v, item => (GLint)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glSecondaryColor3uiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3uiv (const GLuint *v);'</para>
        /// </summary>
        public static void glSecondaryColor3uiv(ref GLuint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local1, (GLint)v);
            glSecondaryColor3uiv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3us (GLushort red, GLushort green, GLushort blue);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3us")]
        public static extern void glSecondaryColor3us(GLushort red, GLushort green, GLushort blue);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3usv (const GLushort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColor3usv")]
        public static extern void glSecondaryColor3usv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3usv (const GLushort *v);'</para>
        /// </summary>
        public static void glSecondaryColor3usv(GLushort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)) * v.Length);
            GLshort[] __array1 = Array.ConvertAll(v, item => (GLshort)item);
            Marshal.Copy(__array1, 0, __local1, __array1.Length);
            glSecondaryColor3usv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColor3usv (const GLushort *v);'</para>
        /// </summary>
        public static void glSecondaryColor3usv(ref GLushort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            Marshal.WriteInt16(__local1, (GLshort)v);
            glSecondaryColor3usv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glSecondaryColorPointer (GLint size, GLenum type, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glSecondaryColorPointer")]
        public static extern void glSecondaryColorPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);


        /// <summary>
        /// <para>Original signature is 'extern void glPointParameterf (GLenum pname, GLfloat param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPointParameterf")]
        public static extern void glPointParameterf(GLenum pname, GLfloat param);

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameterfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPointParameterfv")]
        public static extern void glPointParameterfv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameterfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glPointParameterfv(GLenum pname, GLfloat[] @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * @params.Length);
            Marshal.Copy(@params, 0, __local2, @params.Length);
            glPointParameterfv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameterfv (GLenum pname, const GLfloat *params);'</para>
        /// </summary>
        public static void glPointParameterfv(GLenum pname, ref GLfloat @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(@params, __local2, false);
            glPointParameterfv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameteri (GLenum pname, GLint param);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPointParameteri")]
        public static extern void glPointParameteri(GLenum pname, GLint param);

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameteriv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glPointParameteriv")]
        public static extern void glPointParameteriv(GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameteriv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glPointParameteriv(GLenum pname, GLint[] @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * @params.Length);
            Marshal.Copy(@params, 0, __local2, @params.Length);
            glPointParameteriv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glPointParameteriv (GLenum pname, const GLint *params);'</para>
        /// </summary>
        public static void glPointParameteriv(GLenum pname, ref GLint @params)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, @params);
            glPointParameteriv(pname, __local2);
            Marshal.FreeHGlobal(__local2);
        }


        /// <summary>
        /// <para>Original signature is 'extern void glBlendFuncSeparate (GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBlendFuncSeparate")]
        public static extern void glBlendFuncSeparate(GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);


        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiDrawArrays")]
        public static extern void glMultiDrawArrays(GLenum mode, IntPtr first, IntPtr count, GLsizei primcount);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, IntPtr first, GLsizei[] count, GLsizei primcount)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)) * count.Length);
            Marshal.Copy(count, 0, __local3, count.Length);
            glMultiDrawArrays(mode, first, __local3, primcount);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, IntPtr first, ref GLsizei count, GLsizei primcount)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            Marshal.WriteInt32(__local3, count);
            glMultiDrawArrays(mode, first, __local3, primcount);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, GLint[] first, IntPtr count, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * first.Length);
            Marshal.Copy(first, 0, __local2, first.Length);
            glMultiDrawArrays(mode, __local2, count, primcount);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, GLint[] first, GLsizei[] count, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * first.Length);
            Marshal.Copy(first, 0, __local2, first.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)) * count.Length);
            Marshal.Copy(count, 0, __local3, count.Length);
            glMultiDrawArrays(mode, __local2, __local3, primcount);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, GLint[] first, ref GLsizei count, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * first.Length);
            Marshal.Copy(first, 0, __local2, first.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            Marshal.WriteInt32(__local3, count);
            glMultiDrawArrays(mode, __local2, __local3, primcount);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, ref GLint first, IntPtr count, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, first);
            glMultiDrawArrays(mode, __local2, count, primcount);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, ref GLint first, GLsizei[] count, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, first);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)) * count.Length);
            Marshal.Copy(count, 0, __local3, count.Length);
            glMultiDrawArrays(mode, __local2, __local3, primcount);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawArrays (GLenum mode, const GLint *first, const GLsizei *count, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawArrays(GLenum mode, ref GLint first, ref GLsizei count, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, first);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            Marshal.WriteInt32(__local3, count);
            glMultiDrawArrays(mode, __local2, __local3, primcount);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawElements (GLenum mode, const GLsizei *count, GLenum type, const GLvoid* *indices, GLsizei primcount);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMultiDrawElements")]
        public static extern void glMultiDrawElements(GLenum mode, IntPtr count, GLenum type, IntPtr indices, GLsizei primcount);

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawElements (GLenum mode, const GLsizei *count, GLenum type, const GLvoid* *indices, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawElements(GLenum mode, GLsizei[] count, GLenum type, IntPtr indices, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)) * count.Length);
            Marshal.Copy(count, 0, __local2, count.Length);
            glMultiDrawElements(mode, __local2, type, indices, primcount);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glMultiDrawElements (GLenum mode, const GLsizei *count, GLenum type, const GLvoid* *indices, GLsizei primcount);'</para>
        /// </summary>
        public static void glMultiDrawElements(GLenum mode, ref GLsizei count, GLenum type, IntPtr indices, GLsizei primcount)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            Marshal.WriteInt32(__local2, count);
            glMultiDrawElements(mode, __local2, type, indices, primcount);
            Marshal.FreeHGlobal(__local2);
        }


        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2d (GLdouble x, GLdouble y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2d")]
        public static extern void glWindowPos2d(GLdouble x, GLdouble y);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2dv")]
        public static extern void glWindowPos2dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glWindowPos2dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glWindowPos2dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glWindowPos2dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2f (GLfloat x, GLfloat y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2f")]
        public static extern void glWindowPos2f(GLfloat x, GLfloat y);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2fv")]
        public static extern void glWindowPos2fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glWindowPos2fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glWindowPos2fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glWindowPos2fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2i (GLint x, GLint y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2i")]
        public static extern void glWindowPos2i(GLint x, GLint y);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2iv")]
        public static extern void glWindowPos2iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2iv (const GLint *v);'</para>
        /// </summary>
        public static void glWindowPos2iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2iv (const GLint *v);'</para>
        /// </summary>
        public static void glWindowPos2iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glWindowPos2iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2s (GLshort x, GLshort y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2s")]
        public static extern void glWindowPos2s(GLshort x, GLshort y);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos2sv")]
        public static extern void glWindowPos2sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glWindowPos2sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos2sv (const GLshort *v);'</para>
        /// </summary>
        public static void glWindowPos2sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glWindowPos2sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3d (GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3d")]
        public static extern void glWindowPos3d(GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3dv (const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3dv")]
        public static extern void glWindowPos3dv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glWindowPos3dv(GLdouble[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3dv (const GLdouble *v);'</para>
        /// </summary>
        public static void glWindowPos3dv(ref GLdouble v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local1, false);
            glWindowPos3dv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3f (GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3f")]
        public static extern void glWindowPos3f(GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3fv (const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3fv")]
        public static extern void glWindowPos3fv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glWindowPos3fv(GLfloat[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3fv (const GLfloat *v);'</para>
        /// </summary>
        public static void glWindowPos3fv(ref GLfloat v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local1, false);
            glWindowPos3fv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3i (GLint x, GLint y, GLint z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3i")]
        public static extern void glWindowPos3i(GLint x, GLint y, GLint z);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3iv (const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3iv")]
        public static extern void glWindowPos3iv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3iv (const GLint *v);'</para>
        /// </summary>
        public static void glWindowPos3iv(GLint[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3iv (const GLint *v);'</para>
        /// </summary>
        public static void glWindowPos3iv(ref GLint v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local1, v);
            glWindowPos3iv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3s (GLshort x, GLshort y, GLshort z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3s")]
        public static extern void glWindowPos3s(GLshort x, GLshort y, GLshort z);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3sv (const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glWindowPos3sv")]
        public static extern void glWindowPos3sv(IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glWindowPos3sv(GLshort[] v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local1, v.Length);
            glWindowPos3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glWindowPos3sv (const GLshort *v);'</para>
        /// </summary>
        public static void glWindowPos3sv(ref GLshort v)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local1, v);
            glWindowPos3sv(__local1);
            Marshal.FreeHGlobal(__local1);
        }


        /// <summary>
        /// <para>Original signature is 'extern void glGenQueries(GLsizei n, GLuint *ids);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGenQueries")]
        public static extern void glGenQueries(GLsizei n, IntPtr ids);

        /// <summary>
        /// <para>Original signature is 'extern void glGenQueries(GLsizei n, GLuint *ids);'</para>
        /// </summary>
        public static void glGenQueries(GLsizei n, out GLuint ids)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGenQueries(n, __local2);
            ids = (GLuint)Marshal.ReadInt32(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteQueries(GLsizei n, const GLuint *ids);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDeleteQueries")]
        public static extern void glDeleteQueries(GLsizei n, IntPtr ids);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteQueries(GLsizei n, const GLuint *ids);'</para>
        /// </summary>
        public static void glDeleteQueries(GLsizei n, GLuint[] ids)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * ids.Length);
            GLint[] __array2 = Array.ConvertAll(ids, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glDeleteQueries(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteQueries(GLsizei n, const GLuint *ids);'</para>
        /// </summary>
        public static void glDeleteQueries(GLsizei n, ref GLuint ids)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)ids);
            glDeleteQueries(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsQuery(GLuint id);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsQuery")]
        public static extern GLboolean glIsQuery(GLuint id);

        /// <summary>
        /// <para>Original signature is 'extern void glBeginQuery(GLenum target, GLuint id);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBeginQuery")]
        public static extern void glBeginQuery(GLenum target, GLuint id);

        /// <summary>
        /// <para>Original signature is 'extern void glEndQuery(GLenum target);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEndQuery")]
        public static extern void glEndQuery(GLenum target);

        /// <summary>
        /// <para>Original signature is 'extern void glGetQueryiv(GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetQueryiv")]
        public static extern void glGetQueryiv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetQueryiv(GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetQueryiv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetQueryiv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetQueryObjectiv(GLuint id, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetQueryObjectiv")]
        public static extern void glGetQueryObjectiv(GLuint id, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetQueryObjectiv(GLuint id, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetQueryObjectiv(GLuint id, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetQueryObjectiv(id, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetQueryObjectuiv(GLuint id, GLenum pname, GLuint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetQueryObjectuiv")]
        public static extern void glGetQueryObjectuiv(GLuint id, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetQueryObjectuiv(GLuint id, GLenum pname, GLuint *params);'</para>
        /// </summary>
        public static void glGetQueryObjectuiv(GLuint id, GLenum pname, out GLuint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGetQueryObjectuiv(id, pname, __local3);
            @params = (GLuint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }


        /// <summary>
        /// <para>Original signature is 'extern void glBindBuffer (GLenum target, GLuint buffer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBindBuffer")]
        public static extern void glBindBuffer(GLenum target, GLuint buffer);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteBuffers (GLsizei n, const GLuint *buffers);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDeleteBuffers")]
        public static extern void glDeleteBuffers(GLsizei n, IntPtr buffers);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteBuffers (GLsizei n, const GLuint *buffers);'</para>
        /// </summary>
        public static void glDeleteBuffers(GLsizei n, GLuint[] buffers)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * buffers.Length);
            GLint[] __array2 = Array.ConvertAll(buffers, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glDeleteBuffers(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteBuffers (GLsizei n, const GLuint *buffers);'</para>
        /// </summary>
        public static void glDeleteBuffers(GLsizei n, ref GLuint buffers)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)buffers);
            glDeleteBuffers(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGenBuffers (GLsizei n, GLuint *buffers);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGenBuffers")]
        public static extern void glGenBuffers(GLsizei n, IntPtr buffers);

        /// <summary>
        /// <para>Original signature is 'extern void glGenBuffers (GLsizei n, GLuint *buffers);'</para>
        /// </summary>
        public static void glGenBuffers(GLsizei n, out GLuint buffers)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGenBuffers(n, __local2);
            buffers = (GLuint)Marshal.ReadInt32(__local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsBuffer (GLuint buffer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsBuffer")]
        public static extern GLboolean glIsBuffer(GLuint buffer);

        /// <summary>
        /// <para>Original signature is 'extern void glBufferData (GLenum target, GLsizeiptr size, const GLvoid *data, GLenum usage);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBufferData")]
        public static extern void glBufferData(GLenum target, GLsizeiptr size, IntPtr data, GLenum usage);

        /// <summary>
        /// <para>Original signature is 'extern void glBufferSubData (GLenum target, GLintptr offset, GLsizeiptr size, const GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBufferSubData")]
        public static extern void glBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void glGetBufferSubData (GLenum target, GLintptr offset, GLsizeiptr size, GLvoid *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetBufferSubData")]
        public static extern void glGetBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern GLvoid * glMapBuffer (GLenum target, GLenum access);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glMapBuffer")]
        public static extern IntPtr glMapBuffer(GLenum target, GLenum access);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glUnmapBuffer (GLenum target);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUnmapBuffer")]
        public static extern GLboolean glUnmapBuffer(GLenum target);

        /// <summary>
        /// <para>Original signature is 'extern void glGetBufferParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetBufferParameteriv")]
        public static extern void glGetBufferParameteriv(GLenum target, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetBufferParameteriv (GLenum target, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetBufferParameteriv(GLenum target, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetBufferParameteriv(target, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetBufferPointerv (GLenum target, GLenum pname, GLvoid **params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetBufferPointerv")]
        public static extern void glGetBufferPointerv(GLenum target, GLenum pname, IntPtr @params);


        /// <summary>
        /// <para>Original signature is 'extern void glDrawBuffers (GLsizei n, const GLenum *bufs);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDrawBuffers")]
        public static extern void glDrawBuffers(GLsizei n, IntPtr bufs);

        /// <summary>
        /// <para>Original signature is 'extern void glDrawBuffers (GLsizei n, const GLenum *bufs);'</para>
        /// </summary>
        public static void glDrawBuffers(GLsizei n, GLenum[] bufs)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)) * bufs.Length);
            GLint[] __array2 = Array.ConvertAll(bufs, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glDrawBuffers(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glDrawBuffers (GLsizei n, const GLenum *bufs);'</para>
        /// </summary>
        public static void glDrawBuffers(GLsizei n, ref GLenum bufs)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            Marshal.WriteInt32(__local2, (GLint)bufs);
            glDrawBuffers(n, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1d (GLuint index, GLdouble x);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib1d")]
        public static extern void glVertexAttrib1d(GLuint index, GLdouble x);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib1dv")]
        public static extern void glVertexAttrib1dv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib1dv(GLuint index, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib1dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib1dv(GLuint index, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib1dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1f (GLuint index, GLfloat x);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib1f")]
        public static extern void glVertexAttrib1f(GLuint index, GLfloat x);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib1fv")]
        public static extern void glVertexAttrib1fv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib1fv(GLuint index, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib1fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib1fv(GLuint index, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib1fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1s (GLuint index, GLshort x);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib1s")]
        public static extern void glVertexAttrib1s(GLuint index, GLshort x);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib1sv")]
        public static extern void glVertexAttrib1sv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib1sv(GLuint index, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib1sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib1sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib1sv(GLuint index, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glVertexAttrib1sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2d (GLuint index, GLdouble x, GLdouble y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib2d")]
        public static extern void glVertexAttrib2d(GLuint index, GLdouble x, GLdouble y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib2dv")]
        public static extern void glVertexAttrib2dv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib2dv(GLuint index, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib2dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib2dv(GLuint index, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib2dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2f (GLuint index, GLfloat x, GLfloat y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib2f")]
        public static extern void glVertexAttrib2f(GLuint index, GLfloat x, GLfloat y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib2fv")]
        public static extern void glVertexAttrib2fv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib2fv(GLuint index, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib2fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib2fv(GLuint index, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib2fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2s (GLuint index, GLshort x, GLshort y);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib2s")]
        public static extern void glVertexAttrib2s(GLuint index, GLshort x, GLshort y);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib2sv")]
        public static extern void glVertexAttrib2sv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib2sv(GLuint index, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib2sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib2sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib2sv(GLuint index, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glVertexAttrib2sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3d (GLuint index, GLdouble x, GLdouble y, GLdouble z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib3d")]
        public static extern void glVertexAttrib3d(GLuint index, GLdouble x, GLdouble y, GLdouble z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib3dv")]
        public static extern void glVertexAttrib3dv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib3dv(GLuint index, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib3dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib3dv(GLuint index, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib3dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3f (GLuint index, GLfloat x, GLfloat y, GLfloat z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib3f")]
        public static extern void glVertexAttrib3f(GLuint index, GLfloat x, GLfloat y, GLfloat z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib3fv")]
        public static extern void glVertexAttrib3fv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib3fv(GLuint index, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib3fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib3fv(GLuint index, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib3fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3s (GLuint index, GLshort x, GLshort y, GLshort z);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib3s")]
        public static extern void glVertexAttrib3s(GLuint index, GLshort x, GLshort y, GLshort z);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib3sv")]
        public static extern void glVertexAttrib3sv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib3sv(GLuint index, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib3sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib3sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib3sv(GLuint index, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glVertexAttrib3sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nbv (GLuint index, const GLbyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Nbv")]
        public static extern void glVertexAttrib4Nbv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nbv (GLuint index, const GLbyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nbv(GLuint index, GLbyte[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)) * v.Length);
            GLubyte[] __array2 = Array.ConvertAll(v, item => (GLubyte)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glVertexAttrib4Nbv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nbv (GLuint index, const GLbyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nbv(GLuint index, ref GLbyte v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)));
            Marshal.WriteByte(__local2, (GLubyte)v);
            glVertexAttrib4Nbv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Niv (GLuint index, const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Niv")]
        public static extern void glVertexAttrib4Niv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Niv (GLuint index, const GLint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Niv(GLuint index, GLint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4Niv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Niv (GLuint index, const GLint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Niv(GLuint index, ref GLint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v);
            glVertexAttrib4Niv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nsv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Nsv")]
        public static extern void glVertexAttrib4Nsv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nsv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nsv(GLuint index, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4Nsv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nsv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nsv(GLuint index, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glVertexAttrib4Nsv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nub (GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Nub")]
        public static extern void glVertexAttrib4Nub(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nubv (GLuint index, const GLubyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Nubv")]
        public static extern void glVertexAttrib4Nubv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nubv (GLuint index, const GLubyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nubv(GLuint index, GLubyte[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4Nubv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nubv (GLuint index, const GLubyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nubv(GLuint index, ref GLubyte v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local2, v);
            glVertexAttrib4Nubv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nuiv (GLuint index, const GLuint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Nuiv")]
        public static extern void glVertexAttrib4Nuiv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nuiv (GLuint index, const GLuint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nuiv(GLuint index, GLuint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * v.Length);
            GLint[] __array2 = Array.ConvertAll(v, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glVertexAttrib4Nuiv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nuiv (GLuint index, const GLuint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nuiv(GLuint index, ref GLuint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)v);
            glVertexAttrib4Nuiv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nusv (GLuint index, const GLushort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4Nusv")]
        public static extern void glVertexAttrib4Nusv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nusv (GLuint index, const GLushort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nusv(GLuint index, GLushort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)) * v.Length);
            GLshort[] __array2 = Array.ConvertAll(v, item => (GLshort)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glVertexAttrib4Nusv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4Nusv (GLuint index, const GLushort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4Nusv(GLuint index, ref GLushort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            Marshal.WriteInt16(__local2, (GLshort)v);
            glVertexAttrib4Nusv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4bv (GLuint index, const GLbyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4bv")]
        public static extern void glVertexAttrib4bv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4bv (GLuint index, const GLbyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4bv(GLuint index, GLbyte[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)) * v.Length);
            GLubyte[] __array2 = Array.ConvertAll(v, item => (GLubyte)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glVertexAttrib4bv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4bv (GLuint index, const GLbyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4bv(GLuint index, ref GLbyte v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLbyte)));
            Marshal.WriteByte(__local2, (GLubyte)v);
            glVertexAttrib4bv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4d (GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4d")]
        public static extern void glVertexAttrib4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4dv")]
        public static extern void glVertexAttrib4dv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib4dv(GLuint index, GLdouble[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4dv (GLuint index, const GLdouble *v);'</para>
        /// </summary>
        public static void glVertexAttrib4dv(GLuint index, ref GLdouble v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib4dv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4f (GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4f")]
        public static extern void glVertexAttrib4f(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4fv")]
        public static extern void glVertexAttrib4fv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib4fv(GLuint index, GLfloat[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4fv (GLuint index, const GLfloat *v);'</para>
        /// </summary>
        public static void glVertexAttrib4fv(GLuint index, ref GLfloat v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(v, __local2, false);
            glVertexAttrib4fv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4iv (GLuint index, const GLint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4iv")]
        public static extern void glVertexAttrib4iv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4iv (GLuint index, const GLint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4iv(GLuint index, GLint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4iv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4iv (GLuint index, const GLint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4iv(GLuint index, ref GLint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local2, v);
            glVertexAttrib4iv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4s (GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4s")]
        public static extern void glVertexAttrib4s(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4sv")]
        public static extern void glVertexAttrib4sv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4sv(GLuint index, GLshort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4sv (GLuint index, const GLshort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4sv(GLuint index, ref GLshort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLshort)));
            Marshal.WriteInt16(__local2, v);
            glVertexAttrib4sv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4ubv (GLuint index, const GLubyte *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4ubv")]
        public static extern void glVertexAttrib4ubv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4ubv (GLuint index, const GLubyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4ubv(GLuint index, GLubyte[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * v.Length);
            Marshal.Copy(v, 0, __local2, v.Length);
            glVertexAttrib4ubv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4ubv (GLuint index, const GLubyte *v);'</para>
        /// </summary>
        public static void glVertexAttrib4ubv(GLuint index, ref GLubyte v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local2, v);
            glVertexAttrib4ubv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4uiv (GLuint index, const GLuint *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4uiv")]
        public static extern void glVertexAttrib4uiv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4uiv (GLuint index, const GLuint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4uiv(GLuint index, GLuint[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)) * v.Length);
            GLint[] __array2 = Array.ConvertAll(v, item => (GLint)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glVertexAttrib4uiv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4uiv (GLuint index, const GLuint *v);'</para>
        /// </summary>
        public static void glVertexAttrib4uiv(GLuint index, ref GLuint v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            Marshal.WriteInt32(__local2, (GLint)v);
            glVertexAttrib4uiv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4usv (GLuint index, const GLushort *v);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttrib4usv")]
        public static extern void glVertexAttrib4usv(GLuint index, IntPtr v);

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4usv (GLuint index, const GLushort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4usv(GLuint index, GLushort[] v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)) * v.Length);
            GLshort[] __array2 = Array.ConvertAll(v, item => (GLshort)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            glVertexAttrib4usv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttrib4usv (GLuint index, const GLushort *v);'</para>
        /// </summary>
        public static void glVertexAttrib4usv(GLuint index, ref GLushort v)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLushort)));
            Marshal.WriteInt16(__local2, (GLshort)v);
            glVertexAttrib4usv(index, __local2);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glVertexAttribPointer (GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, const GLvoid *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glVertexAttribPointer")]
        public static extern void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glEnableVertexAttribArray (GLuint index);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glEnableVertexAttribArray")]
        public static extern void glEnableVertexAttribArray(GLuint index);

        /// <summary>
        /// <para>Original signature is 'extern void glDisableVertexAttribArray (GLuint index);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDisableVertexAttribArray")]
        public static extern void glDisableVertexAttribArray(GLuint index);

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribdv (GLuint index, GLenum pname, GLdouble *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetVertexAttribdv")]
        public static extern void glGetVertexAttribdv(GLuint index, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribdv (GLuint index, GLenum pname, GLdouble *params);'</para>
        /// </summary>
        public static void glGetVertexAttribdv(GLuint index, GLenum pname, out GLdouble @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            glGetVertexAttribdv(index, pname, __local3);
            @params = (GLdouble)Marshal.PtrToStructure(__local3, typeof(GLdouble));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribfv (GLuint index, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetVertexAttribfv")]
        public static extern void glGetVertexAttribfv(GLuint index, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribfv (GLuint index, GLenum pname, GLfloat *params);'</para>
        /// </summary>
        public static void glGetVertexAttribfv(GLuint index, GLenum pname, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetVertexAttribfv(index, pname, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribiv (GLuint index, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetVertexAttribiv")]
        public static extern void glGetVertexAttribiv(GLuint index, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribiv (GLuint index, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetVertexAttribiv(GLuint index, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetVertexAttribiv(index, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetVertexAttribPointerv (GLuint index, GLenum pname, GLvoid* *pointer);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetVertexAttribPointerv")]
        public static extern void glGetVertexAttribPointerv(GLuint index, GLenum pname, IntPtr pointer);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteShader (GLuint shader);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDeleteShader")]
        public static extern void glDeleteShader(GLuint shader);

        /// <summary>
        /// <para>Original signature is 'extern void glDetachShader (GLuint program, GLuint shader);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDetachShader")]
        public static extern void glDetachShader(GLuint program, GLuint shader);

        /// <summary>
        /// <para>Original signature is 'extern GLuint glCreateShader (GLenum type);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCreateShader")]
        public static extern GLuint glCreateShader(GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glShaderSource")]
        public static extern void glShaderSource(GLuint shader, GLsizei count, IntPtr @string, IntPtr length);

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, IntPtr @string, GLint[] length)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * length.Length);
            Marshal.Copy(length, 0, __local4, length.Length);
            glShaderSource(shader, count, @string, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, IntPtr @string, ref GLint length)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, length);
            glShaderSource(shader, count, @string, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, GLchar[] @string, IntPtr length)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)) * @string.Length);
            GLubyte[] __array3 = Array.ConvertAll(@string, item => (GLubyte)item);
            Marshal.Copy(__array3, 0, __local3, __array3.Length);
            glShaderSource(shader, count, __local3, length);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, GLchar[] @string, GLint[] length)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)) * @string.Length);
            GLubyte[] __array3 = Array.ConvertAll(@string, item => (GLubyte)item);
            Marshal.Copy(__array3, 0, __local3, __array3.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * length.Length);
            Marshal.Copy(length, 0, __local4, length.Length);
            glShaderSource(shader, count, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, GLchar[] @string, ref GLint length)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)) * @string.Length);
            GLubyte[] __array3 = Array.ConvertAll(@string, item => (GLubyte)item);
            Marshal.Copy(__array3, 0, __local3, __array3.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, length);
            glShaderSource(shader, count, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, ref GLchar @string, IntPtr length)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            Marshal.WriteByte(__local3, (GLubyte)@string);
            glShaderSource(shader, count, __local3, length);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, ref GLchar @string, GLint[] length)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            Marshal.WriteByte(__local3, (GLubyte)@string);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * length.Length);
            Marshal.Copy(length, 0, __local4, length.Length);
            glShaderSource(shader, count, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glShaderSource (GLuint shader, GLsizei count, const GLchar* *string, const GLint *length);'</para>
        /// </summary>
        public static void glShaderSource(GLuint shader, GLsizei count, ref GLchar @string, ref GLint length)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            Marshal.WriteByte(__local3, (GLubyte)@string);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, length);
            glShaderSource(shader, count, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glCompileShader (GLuint shader);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCompileShader")]
        public static extern void glCompileShader(GLuint shader);

        /// <summary>
        /// <para>Original signature is 'extern GLuint glCreateProgram (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glCreateProgram")]
        public static extern GLuint glCreateProgram();

        /// <summary>
        /// <para>Original signature is 'extern void glAttachShader (GLuint program, GLuint shader);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glAttachShader")]
        public static extern void glAttachShader(GLuint program, GLuint shader);

        /// <summary>
        /// <para>Original signature is 'extern void glLinkProgram (GLuint program);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glLinkProgram")]
        public static extern void glLinkProgram(GLuint program);

        /// <summary>
        /// <para>Original signature is 'extern void glUseProgram (GLuint program);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUseProgram")]
        public static extern void glUseProgram(GLuint program);

        /// <summary>
        /// <para>Original signature is 'extern void glDeleteProgram (GLuint program);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glDeleteProgram")]
        public static extern void glDeleteProgram(GLuint program);

        /// <summary>
        /// <para>Original signature is 'extern void glValidateProgram (GLuint program);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glValidateProgram")]
        public static extern void glValidateProgram(GLuint program);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1f (GLint location, GLfloat v0);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform1f")]
        public static extern void glUniform1f(GLint location, GLfloat v0);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2f (GLint location, GLfloat v0, GLfloat v1);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform2f")]
        public static extern void glUniform2f(GLint location, GLfloat v0, GLfloat v1);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3f (GLint location, GLfloat v0, GLfloat v1, GLfloat v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform3f")]
        public static extern void glUniform3f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4f (GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform4f")]
        public static extern void glUniform4f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1i (GLint location, GLint v0);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform1i")]
        public static extern void glUniform1i(GLint location, GLint v0);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2i (GLint location, GLint v0, GLint v1);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform2i")]
        public static extern void glUniform2i(GLint location, GLint v0, GLint v1);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3i (GLint location, GLint v0, GLint v1, GLint v2);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform3i")]
        public static extern void glUniform3i(GLint location, GLint v0, GLint v1, GLint v2);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4i (GLint location, GLint v0, GLint v1, GLint v2, GLint v3);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform4i")]
        public static extern void glUniform4i(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform1fv")]
        public static extern void glUniform1fv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform1fv(GLint location, GLsizei count, GLfloat[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform1fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform1fv(GLint location, GLsizei count, ref GLfloat value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local3, false);
            glUniform1fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform2fv")]
        public static extern void glUniform2fv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform2fv(GLint location, GLsizei count, GLfloat[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform2fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform2fv(GLint location, GLsizei count, ref GLfloat value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local3, false);
            glUniform2fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform3fv")]
        public static extern void glUniform3fv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform3fv(GLint location, GLsizei count, GLfloat[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform3fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform3fv(GLint location, GLsizei count, ref GLfloat value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local3, false);
            glUniform3fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform4fv")]
        public static extern void glUniform4fv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform4fv(GLint location, GLsizei count, GLfloat[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform4fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4fv (GLint location, GLsizei count, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniform4fv(GLint location, GLsizei count, ref GLfloat value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local3, false);
            glUniform4fv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform1iv")]
        public static extern void glUniform1iv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform1iv(GLint location, GLsizei count, GLint[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform1iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform1iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform1iv(GLint location, GLsizei count, ref GLint value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, value);
            glUniform1iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform2iv")]
        public static extern void glUniform2iv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform2iv(GLint location, GLsizei count, GLint[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform2iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform2iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform2iv(GLint location, GLsizei count, ref GLint value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, value);
            glUniform2iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform3iv")]
        public static extern void glUniform3iv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform3iv(GLint location, GLsizei count, GLint[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform3iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform3iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform3iv(GLint location, GLsizei count, ref GLint value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, value);
            glUniform3iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniform4iv")]
        public static extern void glUniform4iv(GLint location, GLsizei count, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform4iv(GLint location, GLsizei count, GLint[] value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * value.Length);
            Marshal.Copy(value, 0, __local3, value.Length);
            glUniform4iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniform4iv (GLint location, GLsizei count, const GLint *value);'</para>
        /// </summary>
        public static void glUniform4iv(GLint location, GLsizei count, ref GLint value)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local3, value);
            glUniform4iv(location, count, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix2fv")]
        public static extern void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix2fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix2fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix3fv")]
        public static extern void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix3fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix3fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix4fv")]
        public static extern void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix4fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix4fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsShader (GLuint shader);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsShader")]
        public static extern GLboolean glIsShader(GLuint shader);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean glIsProgram (GLuint program);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glIsProgram")]
        public static extern GLboolean glIsProgram(GLuint program);

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderiv (GLuint shader, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetShaderiv")]
        public static extern void glGetShaderiv(GLuint shader, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderiv (GLuint shader, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetShaderiv(GLuint shader, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetShaderiv(shader, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetProgramiv (GLuint program, GLenum pname, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetProgramiv")]
        public static extern void glGetProgramiv(GLuint program, GLenum pname, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetProgramiv (GLuint program, GLenum pname, GLint *params);'</para>
        /// </summary>
        public static void glGetProgramiv(GLuint program, GLenum pname, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetProgramiv(program, pname, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetAttachedShaders (GLuint program, GLsizei maxCount, GLsizei *count, GLuint *shaders);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetAttachedShaders")]
        public static extern void glGetAttachedShaders(GLuint program, GLsizei maxCount, IntPtr count, IntPtr shaders);

        /// <summary>
        /// <para>Original signature is 'extern void glGetAttachedShaders (GLuint program, GLsizei maxCount, GLsizei *count, GLuint *shaders);'</para>
        /// </summary>
        public static void glGetAttachedShaders(GLuint program, GLsizei maxCount, IntPtr count, out GLuint shaders)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGetAttachedShaders(program, maxCount, count, __local4);
            shaders = (GLuint)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetAttachedShaders (GLuint program, GLsizei maxCount, GLsizei *count, GLuint *shaders);'</para>
        /// </summary>
        public static void glGetAttachedShaders(GLuint program, GLsizei maxCount, out GLsizei count, IntPtr shaders)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            glGetAttachedShaders(program, maxCount, __local3, shaders);
            count = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetAttachedShaders (GLuint program, GLsizei maxCount, GLsizei *count, GLuint *shaders);'</para>
        /// </summary>
        public static void glGetAttachedShaders(GLuint program, GLsizei maxCount, out GLsizei count, out GLuint shaders)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLuint)));
            glGetAttachedShaders(program, maxCount, __local3, __local4);
            count = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
            shaders = (GLuint)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderInfoLog (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetShaderInfoLog")]
        public static extern void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, IntPtr length, IntPtr infoLog);

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderInfoLog (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        public static void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, IntPtr length, out GLchar infoLog)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetShaderInfoLog(shader, bufSize, length, __local4);
            infoLog = (GLchar)Marshal.ReadByte(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderInfoLog (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        public static void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, out GLsizei length, IntPtr infoLog)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            glGetShaderInfoLog(shader, bufSize, __local3, infoLog);
            length = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderInfoLog (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        public static void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, out GLsizei length, out GLchar infoLog)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetShaderInfoLog(shader, bufSize, __local3, __local4);
            length = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
            infoLog = (GLchar)Marshal.ReadByte(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetProgramInfoLog (GLuint program, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetProgramInfoLog")]
        public static extern void glGetProgramInfoLog(GLuint program, GLsizei bufSize, IntPtr length, IntPtr infoLog);

        /// <summary>
        /// <para>Original signature is 'extern void glGetProgramInfoLog (GLuint program, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        public static void glGetProgramInfoLog(GLuint program, GLsizei bufSize, IntPtr length, out GLchar infoLog)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetProgramInfoLog(program, bufSize, length, __local4);
            infoLog = (GLchar)Marshal.ReadByte(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetProgramInfoLog (GLuint program, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        public static void glGetProgramInfoLog(GLuint program, GLsizei bufSize, out GLsizei length, IntPtr infoLog)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            glGetProgramInfoLog(program, bufSize, __local3, infoLog);
            length = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetProgramInfoLog (GLuint program, GLsizei bufSize, GLsizei *length, GLchar *infoLog);'</para>
        /// </summary>
        public static void glGetProgramInfoLog(GLuint program, GLsizei bufSize, out GLsizei length, out GLchar infoLog)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetProgramInfoLog(program, bufSize, __local3, __local4);
            length = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
            infoLog = (GLchar)Marshal.ReadByte(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint glGetUniformLocation (GLuint program, const GLchar *name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetUniformLocation")]
        public static extern GLint glGetUniformLocation(GLuint program, IntPtr name);

        /// <summary>
        /// <para>Original signature is 'extern GLint glGetUniformLocation (GLuint program, const GLchar *name);'</para>
        /// </summary>
        public static GLint glGetUniformLocation(GLuint program, GLchar[] name)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)) * name.Length);
            GLubyte[] __array2 = Array.ConvertAll(name, item => (GLubyte)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            GLint result = glGetUniformLocation(program, __local2);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint glGetUniformLocation (GLuint program, const GLchar *name);'</para>
        /// </summary>
        public static GLint glGetUniformLocation(GLuint program, ref GLchar name)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            Marshal.WriteByte(__local2, (GLubyte)name);
            GLint result = glGetUniformLocation(program, __local2);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetActiveUniform")]
        public static extern void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, IntPtr type, IntPtr name);

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, IntPtr type, out GLchar name)
        {
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, length, size, type, __local7);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, out GLenum type, IntPtr name)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveUniform(program, index, bufSize, length, size, __local6, name);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, out GLenum type, out GLchar name)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, length, size, __local6, __local7);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, IntPtr type, IntPtr name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetActiveUniform(program, index, bufSize, length, __local5, type, name);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, IntPtr type, out GLchar name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, length, __local5, type, __local7);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, out GLenum type, IntPtr name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveUniform(program, index, bufSize, length, __local5, __local6, name);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, out GLenum type, out GLchar name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, length, __local5, __local6, __local7);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, IntPtr type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            glGetActiveUniform(program, index, bufSize, __local4, size, type, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, IntPtr type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, __local4, size, type, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, out GLenum type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveUniform(program, index, bufSize, __local4, size, __local6, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, out GLenum type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, __local4, size, __local6, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, IntPtr type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetActiveUniform(program, index, bufSize, __local4, __local5, type, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, IntPtr type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, __local4, __local5, type, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, out GLenum type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveUniform(program, index, bufSize, __local4, __local5, __local6, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveUniform (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, out GLenum type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveUniform(program, index, bufSize, __local4, __local5, __local6, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetUniformfv (GLuint program, GLint location, GLfloat *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetUniformfv")]
        public static extern void glGetUniformfv(GLuint program, GLint location, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetUniformfv (GLuint program, GLint location, GLfloat *params);'</para>
        /// </summary>
        public static void glGetUniformfv(GLuint program, GLint location, out GLfloat @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            glGetUniformfv(program, location, __local3);
            @params = (GLfloat)Marshal.PtrToStructure(__local3, typeof(GLfloat));
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetUniformiv (GLuint program, GLint location, GLint *params);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetUniformiv")]
        public static extern void glGetUniformiv(GLuint program, GLint location, IntPtr @params);

        /// <summary>
        /// <para>Original signature is 'extern void glGetUniformiv (GLuint program, GLint location, GLint *params);'</para>
        /// </summary>
        public static void glGetUniformiv(GLuint program, GLint location, out GLint @params)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetUniformiv(program, location, __local3);
            @params = (GLint)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderSource (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *source);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetShaderSource")]
        public static extern void glGetShaderSource(GLuint shader, GLsizei bufSize, IntPtr length, IntPtr source);

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderSource (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *source);'</para>
        /// </summary>
        public static void glGetShaderSource(GLuint shader, GLsizei bufSize, IntPtr length, out GLchar source)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetShaderSource(shader, bufSize, length, __local4);
            source = (GLchar)Marshal.ReadByte(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderSource (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *source);'</para>
        /// </summary>
        public static void glGetShaderSource(GLuint shader, GLsizei bufSize, out GLsizei length, IntPtr source)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            glGetShaderSource(shader, bufSize, __local3, source);
            length = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetShaderSource (GLuint shader, GLsizei bufSize, GLsizei *length, GLchar *source);'</para>
        /// </summary>
        public static void glGetShaderSource(GLuint shader, GLsizei bufSize, out GLsizei length, out GLchar source)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetShaderSource(shader, bufSize, __local3, __local4);
            length = (GLsizei)Marshal.ReadInt32(__local3);
            Marshal.FreeHGlobal(__local3);
            source = (GLchar)Marshal.ReadByte(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glBindAttribLocation (GLuint program, GLuint index, const GLchar *name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glBindAttribLocation")]
        public static extern void glBindAttribLocation(GLuint program, GLuint index, IntPtr name);

        /// <summary>
        /// <para>Original signature is 'extern void glBindAttribLocation (GLuint program, GLuint index, const GLchar *name);'</para>
        /// </summary>
        public static void glBindAttribLocation(GLuint program, GLuint index, GLchar[] name)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)) * name.Length);
            GLubyte[] __array3 = Array.ConvertAll(name, item => (GLubyte)item);
            Marshal.Copy(__array3, 0, __local3, __array3.Length);
            glBindAttribLocation(program, index, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glBindAttribLocation (GLuint program, GLuint index, const GLchar *name);'</para>
        /// </summary>
        public static void glBindAttribLocation(GLuint program, GLuint index, ref GLchar name)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            Marshal.WriteByte(__local3, (GLubyte)name);
            glBindAttribLocation(program, index, __local3);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetActiveAttrib")]
        public static extern void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, IntPtr type, IntPtr name);

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, IntPtr type, out GLchar name)
        {
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, length, size, type, __local7);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, out GLenum type, IntPtr name)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveAttrib(program, index, bufSize, length, size, __local6, name);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, IntPtr size, out GLenum type, out GLchar name)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, length, size, __local6, __local7);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, IntPtr type, IntPtr name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetActiveAttrib(program, index, bufSize, length, __local5, type, name);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, IntPtr type, out GLchar name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, length, __local5, type, __local7);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, out GLenum type, IntPtr name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveAttrib(program, index, bufSize, length, __local5, __local6, name);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, IntPtr length, out GLint size, out GLenum type, out GLchar name)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, length, __local5, __local6, __local7);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, IntPtr type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            glGetActiveAttrib(program, index, bufSize, __local4, size, type, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, IntPtr type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, __local4, size, type, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, out GLenum type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveAttrib(program, index, bufSize, __local4, size, __local6, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, IntPtr size, out GLenum type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, __local4, size, __local6, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, IntPtr type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            glGetActiveAttrib(program, index, bufSize, __local4, __local5, type, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, IntPtr type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, __local4, __local5, type, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, out GLenum type, IntPtr name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            glGetActiveAttrib(program, index, bufSize, __local4, __local5, __local6, name);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glGetActiveAttrib (GLuint program, GLuint index, GLsizei bufSize, GLsizei *length, GLint *size, GLenum *type, GLchar *name);'</para>
        /// </summary>
        public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, out GLenum type, out GLchar name)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLsizei)));
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLenum)));
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            glGetActiveAttrib(program, index, bufSize, __local4, __local5, __local6, __local7);
            length = (GLsizei)Marshal.ReadInt32(__local4);
            Marshal.FreeHGlobal(__local4);
            size = (GLint)Marshal.ReadInt32(__local5);
            Marshal.FreeHGlobal(__local5);
            type = (GLenum)Marshal.ReadInt32(__local6);
            Marshal.FreeHGlobal(__local6);
            name = (GLchar)Marshal.ReadByte(__local7);
            Marshal.FreeHGlobal(__local7);
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint glGetAttribLocation (GLuint program, const GLchar *name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glGetAttribLocation")]
        public static extern GLint glGetAttribLocation(GLuint program, IntPtr name);

        /// <summary>
        /// <para>Original signature is 'extern GLint glGetAttribLocation (GLuint program, const GLchar *name);'</para>
        /// </summary>
        public static GLint glGetAttribLocation(GLuint program, GLchar[] name)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)) * name.Length);
            GLubyte[] __array2 = Array.ConvertAll(name, item => (GLubyte)item);
            Marshal.Copy(__array2, 0, __local2, __array2.Length);
            GLint result = glGetAttribLocation(program, __local2);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint glGetAttribLocation (GLuint program, const GLchar *name);'</para>
        /// </summary>
        public static GLint glGetAttribLocation(GLuint program, ref GLchar name)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLchar)));
            Marshal.WriteByte(__local2, (GLubyte)name);
            GLint result = glGetAttribLocation(program, __local2);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern void glStencilFuncSeparate (GLenum face, GLenum func, GLint ref, GLuint mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glStencilFuncSeparate")]
        public static extern void glStencilFuncSeparate(GLenum face, GLenum func, GLint @ref, GLuint mask);

        /// <summary>
        /// <para>Original signature is 'extern void glStencilOpSeparate (GLenum face, GLenum fail, GLenum zfail, GLenum zpass);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glStencilOpSeparate")]
        public static extern void glStencilOpSeparate(GLenum face, GLenum fail, GLenum zfail, GLenum zpass);

        /// <summary>
        /// <para>Original signature is 'extern void glStencilMaskSeparate (GLenum face, GLuint mask);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glStencilMaskSeparate")]
        public static extern void glStencilMaskSeparate(GLenum face, GLuint mask);


        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2x3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix2x3fv")]
        public static extern void glUniformMatrix2x3fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2x3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix2x3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix2x3fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2x3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix2x3fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix2x3fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3x2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix3x2fv")]
        public static extern void glUniformMatrix3x2fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3x2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix3x2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix3x2fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3x2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix3x2fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix3x2fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2x4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix2x4fv")]
        public static extern void glUniformMatrix2x4fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2x4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix2x4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix2x4fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix2x4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix2x4fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix2x4fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4x2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix4x2fv")]
        public static extern void glUniformMatrix4x2fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4x2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix4x2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix4x2fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4x2fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix4x2fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix4x2fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3x4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix3x4fv")]
        public static extern void glUniformMatrix3x4fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3x4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix3x4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix3x4fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix3x4fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix3x4fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix3x4fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4x3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "glUniformMatrix4x3fv")]
        public static extern void glUniformMatrix4x3fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value);

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4x3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix4x3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * value.Length);
            Marshal.Copy(value, 0, __local4, value.Length);
            glUniformMatrix4x3fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void glUniformMatrix4x3fv (GLint location, GLsizei count, GLboolean transpose, const GLfloat *value);'</para>
        /// </summary>
        public static void glUniformMatrix4x3fv(GLint location, GLsizei count, GLboolean transpose, ref GLfloat value)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(value, __local4, false);
            glUniformMatrix4x3fv(location, count, transpose, __local4);
            Marshal.FreeHGlobal(__local4);
        }
    }
}