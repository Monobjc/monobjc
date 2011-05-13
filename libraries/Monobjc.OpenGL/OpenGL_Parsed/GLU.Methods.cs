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
using System.Linq;
using System.Runtime.InteropServices;
using Monobjc;

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
        /// <summary>
        /// <para>Original signature is 'extern void gluBeginCurve (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBeginCurve")]
        public static extern void gluBeginCurve(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern void gluBeginPolygon (GLUtesselator* tess);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBeginPolygon")]
        public static extern void gluBeginPolygon(IntPtr tess);

        /// <summary>
        /// <para>Original signature is 'extern void gluBeginSurface (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBeginSurface")]
        public static extern void gluBeginSurface(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern void gluBeginTrim (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBeginTrim")]
        public static extern void gluBeginTrim(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluBuild1DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBuild1DMipmapLevels")]
        public static extern GLint gluBuild1DMipmapLevels(GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, GLint level, GLint @base, GLint max);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluBuild1DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, const void *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBuild1DMipmaps")]
        public static extern GLint gluBuild1DMipmaps(GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluBuild2DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBuild2DMipmapLevels")]
        public static extern GLint gluBuild2DMipmapLevels(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, GLint level, GLint @base, GLint max);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluBuild2DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, const void *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBuild2DMipmaps")]
        public static extern GLint gluBuild2DMipmaps(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluBuild3DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBuild3DMipmapLevels")]
        public static extern GLint gluBuild3DMipmapLevels(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint level, GLint @base, GLint max);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluBuild3DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, const void *data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluBuild3DMipmaps")]
        public static extern GLint gluBuild3DMipmaps(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluCheckExtension")]
        public static extern GLboolean gluCheckExtension(IntPtr extName, IntPtr extString);

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(IntPtr extName, GLubyte[] extString)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * extString.Length);
            Marshal.Copy(extString, 0, __local2, extString.Length);
            GLboolean result = gluCheckExtension(extName, __local2);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(IntPtr extName, ref GLubyte extString)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local2, extString);
            GLboolean result = gluCheckExtension(extName, __local2);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(GLubyte[] extName, IntPtr extString)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * extName.Length);
            Marshal.Copy(extName, 0, __local1, extName.Length);
            GLboolean result = gluCheckExtension(__local1, extString);
            Marshal.FreeHGlobal(__local1);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(GLubyte[] extName, GLubyte[] extString)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * extName.Length);
            Marshal.Copy(extName, 0, __local1, extName.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * extString.Length);
            Marshal.Copy(extString, 0, __local2, extString.Length);
            GLboolean result = gluCheckExtension(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(GLubyte[] extName, ref GLubyte extString)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * extName.Length);
            Marshal.Copy(extName, 0, __local1, extName.Length);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local2, extString);
            GLboolean result = gluCheckExtension(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(ref GLubyte extName, IntPtr extString)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, extName);
            GLboolean result = gluCheckExtension(__local1, extString);
            Marshal.FreeHGlobal(__local1);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(ref GLubyte extName, GLubyte[] extString)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, extName);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)) * extString.Length);
            Marshal.Copy(extString, 0, __local2, extString.Length);
            GLboolean result = gluCheckExtension(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);'</para>
        /// </summary>
        public static GLboolean gluCheckExtension(ref GLubyte extName, ref GLubyte extString)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local1, extName);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLubyte)));
            Marshal.WriteByte(__local2, extString);
            GLboolean result = gluCheckExtension(__local1, __local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluCylinder (GLUquadric* quad, GLdouble base, GLdouble top, GLdouble height, GLint slices, GLint stacks);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluCylinder")]
        public static extern void gluCylinder(IntPtr quad, GLdouble @base, GLdouble top, GLdouble height, GLint slices, GLint stacks);

        /// <summary>
        /// <para>Original signature is 'extern void gluDeleteNurbsRenderer (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluDeleteNurbsRenderer")]
        public static extern void gluDeleteNurbsRenderer(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern void gluDeleteQuadric (GLUquadric* quad);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluDeleteQuadric")]
        public static extern void gluDeleteQuadric(IntPtr quad);

        /// <summary>
        /// <para>Original signature is 'extern void gluDeleteTess (GLUtesselator* tess);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluDeleteTess")]
        public static extern void gluDeleteTess(IntPtr tess);

        /// <summary>
        /// <para>Original signature is 'extern void gluDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluDisk")]
        public static extern void gluDisk(IntPtr quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops);

        /// <summary>
        /// <para>Original signature is 'extern void gluEndCurve (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluEndCurve")]
        public static extern void gluEndCurve(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern void gluEndPolygon (GLUtesselator* tess);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluEndPolygon")]
        public static extern void gluEndPolygon(IntPtr tess);

        /// <summary>
        /// <para>Original signature is 'extern void gluEndSurface (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluEndSurface")]
        public static extern void gluEndSurface(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern void gluEndTrim (GLUnurbs* nurb);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluEndTrim")]
        public static extern void gluEndTrim(IntPtr nurb);

        /// <summary>
        /// <para>Original signature is 'extern const GLubyte * gluErrorString (GLenum error);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluErrorString")]
        public static extern IntPtr gluErrorString(GLenum error);

        /// <summary>
        /// <para>Original signature is 'extern void gluGetNurbsProperty (GLUnurbs* nurb, GLenum property, GLfloat* data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluGetNurbsProperty")]
        public static extern void gluGetNurbsProperty(IntPtr nurb, GLenum property, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern const GLubyte * gluGetString (GLenum name);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluGetString")]
        public static extern IntPtr gluGetString(GLenum name);

        /// <summary>
        /// <para>Original signature is 'extern void gluGetTessProperty (GLUtesselator* tess, GLenum which, GLdouble* data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluGetTessProperty")]
        public static extern void gluGetTessProperty(IntPtr tess, GLenum which, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluLoadSamplingMatrices")]
        public static extern void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, IntPtr perspective, IntPtr view);

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, IntPtr perspective, GLint[] view)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, model, perspective, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, IntPtr perspective, ref GLint view)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, model, perspective, __local4);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, GLfloat[] perspective, IntPtr view)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            gluLoadSamplingMatrices(nurb, model, __local3, view);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, GLfloat[] perspective, GLint[] view)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, model, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, GLfloat[] perspective, ref GLint view)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, model, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, ref GLfloat perspective, IntPtr view)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            gluLoadSamplingMatrices(nurb, model, __local3, view);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, ref GLfloat perspective, GLint[] view)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, model, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, IntPtr model, ref GLfloat perspective, ref GLint view)
        {
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, model, __local3, __local4);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, IntPtr perspective, IntPtr view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            gluLoadSamplingMatrices(nurb, __local2, perspective, view);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, IntPtr perspective, GLint[] view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, __local2, perspective, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, IntPtr perspective, ref GLint view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, __local2, perspective, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, GLfloat[] perspective, IntPtr view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            gluLoadSamplingMatrices(nurb, __local2, __local3, view);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, GLfloat[] perspective, GLint[] view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, GLfloat[] perspective, ref GLint view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, ref GLfloat perspective, IntPtr view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            gluLoadSamplingMatrices(nurb, __local2, __local3, view);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, ref GLfloat perspective, GLint[] view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, GLfloat[] model, ref GLfloat perspective, ref GLint view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * model.Length);
            Marshal.Copy(model, 0, __local2, model.Length);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, IntPtr perspective, IntPtr view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            gluLoadSamplingMatrices(nurb, __local2, perspective, view);
            Marshal.FreeHGlobal(__local2);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, IntPtr perspective, GLint[] view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, __local2, perspective, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, IntPtr perspective, ref GLint view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, __local2, perspective, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, GLfloat[] perspective, IntPtr view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            gluLoadSamplingMatrices(nurb, __local2, __local3, view);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, GLfloat[] perspective, GLint[] view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, GLfloat[] perspective, ref GLint view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)) * perspective.Length);
            Marshal.Copy(perspective, 0, __local3, perspective.Length);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, ref GLfloat perspective, IntPtr view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            gluLoadSamplingMatrices(nurb, __local2, __local3, view);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, ref GLfloat perspective, GLint[] view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local4, view.Length);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);'</para>
        /// </summary>
        public static void gluLoadSamplingMatrices(IntPtr nurb, ref GLfloat model, ref GLfloat perspective, ref GLint view)
        {
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(model, __local2, false);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLfloat)));
            Marshal.StructureToPtr(perspective, __local3, false);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local4, view);
            gluLoadSamplingMatrices(nurb, __local2, __local3, __local4);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluLookAt (GLdouble eyeX, GLdouble eyeY, GLdouble eyeZ, GLdouble centerX, GLdouble centerY, GLdouble centerZ, GLdouble upX, GLdouble upY, GLdouble upZ);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluLookAt")]
        public static extern void gluLookAt(GLdouble eyeX, GLdouble eyeY, GLdouble eyeZ, GLdouble centerX, GLdouble centerY, GLdouble centerZ, GLdouble upX, GLdouble upY, GLdouble upZ);

        /// <summary>
        /// <para>Original signature is 'extern GLUnurbs* gluNewNurbsRenderer (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNewNurbsRenderer")]
        public static extern IntPtr gluNewNurbsRenderer();

        /// <summary>
        /// <para>Original signature is 'extern GLUquadric* gluNewQuadric (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNewQuadric")]
        public static extern IntPtr gluNewQuadric();

        /// <summary>
        /// <para>Original signature is 'extern GLUtesselator* gluNewTess (void);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNewTess")]
        public static extern IntPtr gluNewTess();

        /// <summary>
        /// <para>Original signature is 'extern void gluNextContour (GLUtesselator* tess, GLenum type);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNextContour")]
        public static extern void gluNextContour(IntPtr tess, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern void gluNurbsCallbackData (GLUnurbs* nurb, GLvoid* userData);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNurbsCallbackData")]
        public static extern void gluNurbsCallbackData(IntPtr nurb, IntPtr userData);

        /// <summary>
        /// <para>Original signature is 'extern void gluNurbsCallbackDataEXT (GLUnurbs* nurb, GLvoid* userData);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNurbsCallbackDataEXT")]
        public static extern void gluNurbsCallbackDataEXT(IntPtr nurb, IntPtr userData);

        /// <summary>
        /// <para>Original signature is 'extern void gluNurbsCurve (GLUnurbs* nurb, GLint knotCount, GLfloat *knots, GLint stride, GLfloat *control, GLint order, GLenum type);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNurbsCurve")]
        public static extern void gluNurbsCurve(IntPtr nurb, GLint knotCount, IntPtr knots, GLint stride, IntPtr control, GLint order, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern void gluNurbsProperty (GLUnurbs* nurb, GLenum property, GLfloat value);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNurbsProperty")]
        public static extern void gluNurbsProperty(IntPtr nurb, GLenum property, GLfloat value);

        /// <summary>
        /// <para>Original signature is 'extern void gluNurbsSurface (GLUnurbs* nurb, GLint sKnotCount, GLfloat* sKnots, GLint tKnotCount, GLfloat* tKnots, GLint sStride, GLint tStride, GLfloat* control, GLint sOrder, GLint tOrder, GLenum type);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluNurbsSurface")]
        public static extern void gluNurbsSurface(IntPtr nurb, GLint sKnotCount, IntPtr sKnots, GLint tKnotCount, IntPtr tKnots, GLint sStride, GLint tStride, IntPtr control, GLint sOrder, GLint tOrder, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern void gluOrtho2D (GLdouble left, GLdouble right, GLdouble bottom, GLdouble top);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluOrtho2D")]
        public static extern void gluOrtho2D(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top);

        /// <summary>
        /// <para>Original signature is 'extern void gluPartialDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops, GLdouble start, GLdouble sweep);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluPartialDisk")]
        public static extern void gluPartialDisk(IntPtr quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops, GLdouble start, GLdouble sweep);

        /// <summary>
        /// <para>Original signature is 'extern void gluPerspective (GLdouble fovy, GLdouble aspect, GLdouble zNear, GLdouble zFar);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluPerspective")]
        public static extern void gluPerspective(GLdouble fovy, GLdouble aspect, GLdouble zNear, GLdouble zFar);

        /// <summary>
        /// <para>Original signature is 'extern void gluPickMatrix (GLdouble x, GLdouble y, GLdouble delX, GLdouble delY, GLint *viewport);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluPickMatrix")]
        public static extern void gluPickMatrix(GLdouble x, GLdouble y, GLdouble delX, GLdouble delY, IntPtr viewport);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluProject")]
        public static extern GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, IntPtr proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, IntPtr proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, model, proj, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, IntPtr proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, model, proj, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, GLdouble[] proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            GLint result = gluProject(objX, objY, objZ, model, __local5, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, GLdouble[] proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, model, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, GLdouble[] proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, model, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, ref GLdouble proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            GLint result = gluProject(objX, objY, objZ, model, __local5, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, ref GLdouble proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, model, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, IntPtr model, ref GLdouble proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, model, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, IntPtr proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, proj, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, IntPtr proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, proj, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, IntPtr proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, __local4, proj, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, GLdouble[] proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, GLdouble[] proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, GLdouble[] proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, ref GLdouble proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, ref GLdouble proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble[] model, ref GLdouble proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, IntPtr proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            GLint result = gluProject(objX, objY, objZ, __local4, proj, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, IntPtr proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, proj, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, IntPtr proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, __local4, proj, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, GLdouble[] proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, GLdouble[] proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, GLdouble[] proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, ref GLdouble proj, IntPtr view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, view, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, ref GLdouble proj, GLint[] view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);'</para>
        /// </summary>
        public static GLint gluProject(GLdouble objX, GLdouble objY, GLdouble objZ, ref GLdouble model, ref GLdouble proj, ref GLint view, IntPtr winX, IntPtr winY, IntPtr winZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluProject(objX, objY, objZ, __local4, __local5, __local6, winX, winY, winZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern void gluPwlCurve (GLUnurbs* nurb, GLint count, GLfloat* data, GLint stride, GLenum type);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluPwlCurve")]
        public static extern void gluPwlCurve(IntPtr nurb, GLint count, IntPtr data, GLint stride, GLenum type);

        /// <summary>
        /// <para>Original signature is 'extern void gluQuadricDrawStyle (GLUquadric* quad, GLenum draw);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluQuadricDrawStyle")]
        public static extern void gluQuadricDrawStyle(IntPtr quad, GLenum draw);

        /// <summary>
        /// <para>Original signature is 'extern void gluQuadricNormals (GLUquadric* quad, GLenum normal);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluQuadricNormals")]
        public static extern void gluQuadricNormals(IntPtr quad, GLenum normal);

        /// <summary>
        /// <para>Original signature is 'extern void gluQuadricOrientation (GLUquadric* quad, GLenum orientation);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluQuadricOrientation")]
        public static extern void gluQuadricOrientation(IntPtr quad, GLenum orientation);

        /// <summary>
        /// <para>Original signature is 'extern void gluQuadricTexture (GLUquadric* quad, GLboolean texture);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluQuadricTexture")]
        public static extern void gluQuadricTexture(IntPtr quad, GLboolean texture);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluScaleImage (GLenum format, GLsizei wIn, GLsizei hIn, GLenum typeIn, const void *dataIn, GLsizei wOut, GLsizei hOut, GLenum typeOut, GLvoid* dataOut);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluScaleImage")]
        public static extern GLint gluScaleImage(GLenum format, GLsizei wIn, GLsizei hIn, GLenum typeIn, GLsizei wOut, GLsizei hOut, GLenum typeOut, IntPtr dataOut);

        /// <summary>
        /// <para>Original signature is 'extern void gluSphere (GLUquadric* quad, GLdouble radius, GLint slices, GLint stacks);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluSphere")]
        public static extern void gluSphere(IntPtr quad, GLdouble radius, GLint slices, GLint stacks);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessBeginContour (GLUtesselator* tess);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessBeginContour")]
        public static extern void gluTessBeginContour(IntPtr tess);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessBeginPolygon (GLUtesselator* tess, GLvoid* data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessBeginPolygon")]
        public static extern void gluTessBeginPolygon(IntPtr tess, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessEndContour (GLUtesselator* tess);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessEndContour")]
        public static extern void gluTessEndContour(IntPtr tess);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessEndPolygon (GLUtesselator* tess);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessEndPolygon")]
        public static extern void gluTessEndPolygon(IntPtr tess);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessNormal (GLUtesselator* tess, GLdouble valueX, GLdouble valueY, GLdouble valueZ);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessNormal")]
        public static extern void gluTessNormal(IntPtr tess, GLdouble valueX, GLdouble valueY, GLdouble valueZ);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessProperty (GLUtesselator* tess, GLenum which, GLdouble data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessProperty")]
        public static extern void gluTessProperty(IntPtr tess, GLenum which, GLdouble data);

        /// <summary>
        /// <para>Original signature is 'extern void gluTessVertex (GLUtesselator* tess, GLdouble *location, GLvoid* data);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluTessVertex")]
        public static extern void gluTessVertex(IntPtr tess, IntPtr location, IntPtr data);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluUnProject")]
        public static extern GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, IntPtr proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, IntPtr proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, model, proj, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, IntPtr proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, model, proj, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, GLdouble[] proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            GLint result = gluUnProject(winX, winY, winZ, model, __local5, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, GLdouble[] proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, model, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, GLdouble[] proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, model, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, ref GLdouble proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            GLint result = gluUnProject(winX, winY, winZ, model, __local5, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, ref GLdouble proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, model, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, IntPtr model, ref GLdouble proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, model, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, IntPtr proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, proj, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, IntPtr proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, proj, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, IntPtr proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, __local4, proj, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, GLdouble[] proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, GLdouble[] proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, GLdouble[] proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, ref GLdouble proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, ref GLdouble proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble[] model, ref GLdouble proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local4, model.Length);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, IntPtr proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            GLint result = gluUnProject(winX, winY, winZ, __local4, proj, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, IntPtr proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, proj, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, IntPtr proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, __local4, proj, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, GLdouble[] proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, GLdouble[] proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, GLdouble[] proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local5, proj.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, ref GLdouble proj, IntPtr view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, view, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, ref GLdouble proj, GLint[] view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local6, view.Length);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);'</para>
        /// </summary>
        public static GLint gluUnProject(GLdouble winX, GLdouble winY, GLdouble winZ, ref GLdouble model, ref GLdouble proj, ref GLint view, IntPtr objX, IntPtr objY, IntPtr objZ)
        {
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local4, false);
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local6, view);
            GLint result = gluUnProject(winX, winY, winZ, __local4, __local5, __local6, objX, objY, objZ);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        [DllImport(OPENGL, EntryPoint = "gluUnProject4")]
        public static extern GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, IntPtr proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW);

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, IntPtr proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, proj, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, IntPtr proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, proj, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, GLdouble[] proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, __local6, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, GLdouble[] proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, GLdouble[] proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, ref GLdouble proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, __local6, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, ref GLdouble proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, IntPtr model, ref GLdouble proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, model, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, IntPtr proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, proj, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, IntPtr proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, proj, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, IntPtr proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, proj, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, GLdouble[] proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, GLdouble[] proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, GLdouble[] proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, ref GLdouble proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, ref GLdouble proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble[] model, ref GLdouble proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * model.Length);
            Marshal.Copy(model, 0, __local5, model.Length);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, IntPtr proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, proj, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, IntPtr proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, proj, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, IntPtr proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, proj, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, GLdouble[] proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, GLdouble[] proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, GLdouble[] proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)) * proj.Length);
            Marshal.Copy(proj, 0, __local6, proj.Length);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, ref GLdouble proj, IntPtr view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, view, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, ref GLdouble proj, GLint[] view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)) * view.Length);
            Marshal.Copy(view, 0, __local7, view.Length);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }

        /// <summary>
        /// <para>Original signature is 'extern GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearPlane, GLdouble farPlane, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);'</para>
        /// </summary>
        public static GLint gluUnProject4(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, ref GLdouble model, ref GLdouble proj, ref GLint view, GLdouble nearPlane, GLdouble farPlane, IntPtr objX, IntPtr objY, IntPtr objZ, IntPtr objW)
        {
            IntPtr __local5 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(model, __local5, false);
            IntPtr __local6 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLdouble)));
            Marshal.StructureToPtr(proj, __local6, false);
            IntPtr __local7 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLint)));
            Marshal.WriteInt32(__local7, view);
            GLint result = gluUnProject4(winX, winY, winZ, clipW, __local5, __local6, __local7, nearPlane, farPlane, objX, objY, objZ, objW);
            Marshal.FreeHGlobal(__local5);
            Marshal.FreeHGlobal(__local6);
            Marshal.FreeHGlobal(__local7);
            return result;
        }
    }
}
