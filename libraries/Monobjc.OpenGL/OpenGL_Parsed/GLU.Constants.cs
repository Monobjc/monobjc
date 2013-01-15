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
/* Extensions */
        public const uint GLU_EXT_object_space_tess = 1;
        public const uint GLU_EXT_nurbs_tessellator = 1;

/* Boolean */
        public const uint GLU_FALSE = 0;
        public const uint GLU_TRUE = 1;

/* Version */
        public const uint GLU_VERSION_1_1 = 1;
        public const uint GLU_VERSION_1_2 = 1;
        public const uint GLU_VERSION_1_3 = 1;

/* StringName */
        public const uint GLU_VERSION = 100800;
        public const uint GLU_EXTENSIONS = 100801;

/* ErrorCode */
        public const uint GLU_INVALID_ENUM = 100900;
        public const uint GLU_INVALID_VALUE = 100901;
        public const uint GLU_OUT_OF_MEMORY = 100902;
        public const uint GLU_INCOMPATIBLE_GL_VERSION = 100903;
        public const uint GLU_INVALID_OPERATION = 100904;


/* NurbsDisplay */
/*      GLU_FILL */
        public const uint GLU_OUTLINE_POLYGON = 100240;
        public const uint GLU_OUTLINE_PATCH = 100241;

/* NurbsCallback */
        public const uint GLU_NURBS_ERROR = 100103;
        public const uint GLU_ERROR = 100103;
        public const uint GLU_NURBS_BEGIN = 100164;
        public const uint GLU_NURBS_BEGIN_EXT = 100164;
        public const uint GLU_NURBS_VERTEX = 100165;
        public const uint GLU_NURBS_VERTEX_EXT = 100165;
        public const uint GLU_NURBS_NORMAL = 100166;
        public const uint GLU_NURBS_NORMAL_EXT = 100166;
        public const uint GLU_NURBS_COLOR = 100167;
        public const uint GLU_NURBS_COLOR_EXT = 100167;
        public const uint GLU_NURBS_TEXTURE_COORD = 100168;
        public const uint GLU_NURBS_TEX_COORD_EXT = 100168;
        public const uint GLU_NURBS_END = 100169;
        public const uint GLU_NURBS_END_EXT = 100169;
        public const uint GLU_NURBS_BEGIN_DATA = 100170;
        public const uint GLU_NURBS_BEGIN_DATA_EXT = 100170;
        public const uint GLU_NURBS_VERTEX_DATA = 100171;
        public const uint GLU_NURBS_VERTEX_DATA_EXT = 100171;
        public const uint GLU_NURBS_NORMAL_DATA = 100172;
        public const uint GLU_NURBS_NORMAL_DATA_EXT = 100172;
        public const uint GLU_NURBS_COLOR_DATA = 100173;
        public const uint GLU_NURBS_COLOR_DATA_EXT = 100173;
        public const uint GLU_NURBS_TEXTURE_COORD_DATA = 100174;
        public const uint GLU_NURBS_TEX_COORD_DATA_EXT = 100174;
        public const uint GLU_NURBS_END_DATA = 100175;
        public const uint GLU_NURBS_END_DATA_EXT = 100175;

/* NurbsError */
        public const uint GLU_NURBS_ERROR1 = 100251 /* spline order un-supported = */;
        public const uint GLU_NURBS_ERROR2 = 100252 /* too few knots = */;
        public const uint GLU_NURBS_ERROR3 = 100253 /* valid knot range is empty = */;
        public const uint GLU_NURBS_ERROR4 = 100254 /* decreasing knot sequence = */;
        public const uint GLU_NURBS_ERROR5 = 100255 /* knot multiplicity > spline order = */;
        public const uint GLU_NURBS_ERROR6 = 100256 /* endcurve() must follow bgncurve() = */;
        public const uint GLU_NURBS_ERROR7 = 100257 /* bgncurve() must precede endcurve() = */;
        public const uint GLU_NURBS_ERROR8 = 100258 /* ctrlarray or knot vector is NULL = */;
        public const uint GLU_NURBS_ERROR9 = 100259 /* can't draw pwlcurves = */;
        public const uint GLU_NURBS_ERROR10 = 100260 /* missing gluNurbsCurve() = */;
        public const uint GLU_NURBS_ERROR11 = 100261 /* missing gluNurbsSurface() = */;
        public const uint GLU_NURBS_ERROR12 = 100262 /* endtrim() must precede endsurface() = */;
        public const uint GLU_NURBS_ERROR13 = 100263 /* bgnsurface() must precede endsurface() = */;
        public const uint GLU_NURBS_ERROR14 = 100264 /* curve of improper type passed as trim curve = */;
        public const uint GLU_NURBS_ERROR15 = 100265 /* bgnsurface() must precede bgntrim() = */;
        public const uint GLU_NURBS_ERROR16 = 100266 /* endtrim() must follow bgntrim() = */;
        public const uint GLU_NURBS_ERROR17 = 100267 /* bgntrim() must precede = endtrim()*/;
        public const uint GLU_NURBS_ERROR18 = 100268 /* invalid or missing trim = curve*/;
        public const uint GLU_NURBS_ERROR19 = 100269 /* bgntrim() must precede pwlcurve() = */;
        public const uint GLU_NURBS_ERROR20 = 100270 /* pwlcurve referenced = twice*/;
        public const uint GLU_NURBS_ERROR21 = 100271 /* pwlcurve and nurbscurve mixed = */;
        public const uint GLU_NURBS_ERROR22 = 100272 /* improper usage of trim data type = */;
        public const uint GLU_NURBS_ERROR23 = 100273 /* nurbscurve referenced twice = */;
        public const uint GLU_NURBS_ERROR24 = 100274 /* nurbscurve and pwlcurve mixed = */;
        public const uint GLU_NURBS_ERROR25 = 100275 /* nurbssurface referenced twice = */;
        public const uint GLU_NURBS_ERROR26 = 100276 /* invalid property = */;
        public const uint GLU_NURBS_ERROR27 = 100277 /* endsurface() must follow bgnsurface() = */;
        public const uint GLU_NURBS_ERROR28 = 100278 /* intersecting or misoriented trim curves = */;
        public const uint GLU_NURBS_ERROR29 = 100279 /* intersecting trim curves = */;
        public const uint GLU_NURBS_ERROR30 = 100280 /* UNUSED = */;
        public const uint GLU_NURBS_ERROR31 = 100281 /* unconnected trim curves = */;
        public const uint GLU_NURBS_ERROR32 = 100282 /* unknown knot error = */;
        public const uint GLU_NURBS_ERROR33 = 100283 /* negative vertex count encountered = */;
        public const uint GLU_NURBS_ERROR34 = 100284 /* negative byte-stride = */;
        public const uint GLU_NURBS_ERROR35 = 100285 /* unknown type descriptor = */;
        public const uint GLU_NURBS_ERROR36 = 100286 /* null control point reference = */;
        public const uint GLU_NURBS_ERROR37 = 100287 /* duplicate point on pwlcurve = */;

/* NurbsProperty */
        public const uint GLU_AUTO_LOAD_MATRIX = 100200;
        public const uint GLU_CULLING = 100201;
        public const uint GLU_SAMPLING_TOLERANCE = 100203;
        public const uint GLU_DISPLAY_MODE = 100204;
        public const uint GLU_PARAMETRIC_TOLERANCE = 100202;
        public const uint GLU_SAMPLING_METHOD = 100205;
        public const uint GLU_U_STEP = 100206;
        public const uint GLU_V_STEP = 100207;
        public const uint GLU_NURBS_MODE = 100160;
        public const uint GLU_NURBS_MODE_EXT = 100160;
        public const uint GLU_NURBS_TESSELLATOR = 100161;
        public const uint GLU_NURBS_TESSELLATOR_EXT = 100161;
        public const uint GLU_NURBS_RENDERER = 100162;
        public const uint GLU_NURBS_RENDERER_EXT = 100162;

/* NurbsSampling */
        public const uint GLU_OBJECT_PARAMETRIC_ERROR = 100208;
        public const uint GLU_OBJECT_PARAMETRIC_ERROR_EXT = 100208;
        public const uint GLU_OBJECT_PATH_LENGTH = 100209;
        public const uint GLU_OBJECT_PATH_LENGTH_EXT = 100209;
        public const uint GLU_PATH_LENGTH = 100215;
        public const uint GLU_PARAMETRIC_ERROR = 100216;
        public const uint GLU_DOMAIN_DISTANCE = 100217;

/* NurbsTrim */
        public const uint GLU_MAP1_TRIM_2 = 100210;
        public const uint GLU_MAP1_TRIM_3 = 100211;

/* QuadricDrawStyle */
        public const uint GLU_POINT = 100010;
        public const uint GLU_LINE = 100011;
        public const uint GLU_FILL = 100012;
        public const uint GLU_SILHOUETTE = 100013;

/* QuadricCallback */
/*      GLU_ERROR */

/* QuadricNormal */
        public const uint GLU_SMOOTH = 100000;
        public const uint GLU_FLAT = 100001;
        public const uint GLU_NONE = 100002;

/* QuadricOrientation */
        public const uint GLU_OUTSIDE = 100020;
        public const uint GLU_INSIDE = 100021;

/* TessCallback */
        public const uint GLU_TESS_BEGIN = 100100;
        public const uint GLU_BEGIN = 100100;
        public const uint GLU_TESS_VERTEX = 100101;
        public const uint GLU_VERTEX = 100101;
        public const uint GLU_TESS_END = 100102;
        public const uint GLU_END = 100102;
        public const uint GLU_TESS_ERROR = 100103;
        public const uint GLU_TESS_EDGE_FLAG = 100104;
        public const uint GLU_EDGE_FLAG = 100104;
        public const uint GLU_TESS_COMBINE = 100105;
        public const uint GLU_TESS_BEGIN_DATA = 100106;
        public const uint GLU_TESS_VERTEX_DATA = 100107;
        public const uint GLU_TESS_END_DATA = 100108;
        public const uint GLU_TESS_ERROR_DATA = 100109;
        public const uint GLU_TESS_EDGE_FLAG_DATA = 100110;
        public const uint GLU_TESS_COMBINE_DATA = 100111;

/* TessContour */
        public const uint GLU_CW = 100120;
        public const uint GLU_CCW = 100121;
        public const uint GLU_INTERIOR = 100122;
        public const uint GLU_EXTERIOR = 100123;
        public const uint GLU_UNKNOWN = 100124;

/* TessProperty */
        public const uint GLU_TESS_WINDING_RULE = 100140;
        public const uint GLU_TESS_BOUNDARY_ONLY = 100141;
        public const uint GLU_TESS_TOLERANCE = 100142;

/* TessError */
        public const uint GLU_TESS_ERROR1 = 100151;
        public const uint GLU_TESS_ERROR2 = 100152;
        public const uint GLU_TESS_ERROR3 = 100153;
        public const uint GLU_TESS_ERROR4 = 100154;
        public const uint GLU_TESS_ERROR5 = 100155;
        public const uint GLU_TESS_ERROR6 = 100156;
        public const uint GLU_TESS_ERROR7 = 100157;
        public const uint GLU_TESS_ERROR8 = 100158;
        public const uint GLU_TESS_MISSING_BEGIN_POLYGON = 100151;
        public const uint GLU_TESS_MISSING_BEGIN_CONTOUR = 100152;
        public const uint GLU_TESS_MISSING_END_POLYGON = 100153;
        public const uint GLU_TESS_MISSING_END_CONTOUR = 100154;
        public const uint GLU_TESS_COORD_TOO_LARGE = 100155;
        public const uint GLU_TESS_NEED_COMBINE_CALLBACK = 100156;

/* TessWinding */
        public const uint GLU_TESS_WINDING_ODD = 100130;
        public const uint GLU_TESS_WINDING_NONZERO = 100131;
        public const uint GLU_TESS_WINDING_POSITIVE = 100132;
        public const uint GLU_TESS_WINDING_NEGATIVE = 100133;
        public const uint GLU_TESS_WINDING_ABS_GEQ_TWO = 100134;
    }
}