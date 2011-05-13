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
/* For compatibility with OpenGL v1.0 */
        public const uint GL_LOGIC_OP = GL_INDEX_LOGIC_OP;
        public const uint GL_TEXTURE_COMPONENTS = GL_TEXTURE_INTERNAL_FORMAT;

/* Version */
        public const uint GL_VERSION_1_1 = 1;
        public const uint GL_VERSION_1_2 = 1;
        public const uint GL_VERSION_1_3 = 1;
        public const uint GL_VERSION_1_4 = 1;
        public const uint GL_VERSION_1_5 = 1;
        public const uint GL_VERSION_2_0 = 1;
        public const uint GL_VERSION_2_1 = 1;

/* AccumOp */
        public const uint GL_ACCUM = 0x0100;
        public const uint GL_LOAD = 0x0101;
        public const uint GL_RETURN = 0x0102;
        public const uint GL_MULT = 0x0103;
        public const uint GL_ADD = 0x0104;

/* AlphaFunction */
        public const uint GL_NEVER = 0x0200;
        public const uint GL_LESS = 0x0201;
        public const uint GL_EQUAL = 0x0202;
        public const uint GL_LEQUAL = 0x0203;
        public const uint GL_GREATER = 0x0204;
        public const uint GL_NOTEQUAL = 0x0205;
        public const uint GL_GEQUAL = 0x0206;
        public const uint GL_ALWAYS = 0x0207;

/* AttribMask */
        public const uint GL_CURRENT_BIT = 0x00000001;
        public const uint GL_POINT_BIT = 0x00000002;
        public const uint GL_LINE_BIT = 0x00000004;
        public const uint GL_POLYGON_BIT = 0x00000008;
        public const uint GL_POLYGON_STIPPLE_BIT = 0x00000010;
        public const uint GL_PIXEL_MODE_BIT = 0x00000020;
        public const uint GL_LIGHTING_BIT = 0x00000040;
        public const uint GL_FOG_BIT = 0x00000080;
        public const uint GL_DEPTH_BUFFER_BIT = 0x00000100;
        public const uint GL_ACCUM_BUFFER_BIT = 0x00000200;
        public const uint GL_STENCIL_BUFFER_BIT = 0x00000400;
        public const uint GL_VIEWPORT_BIT = 0x00000800;
        public const uint GL_TRANSFORM_BIT = 0x00001000;
        public const uint GL_ENABLE_BIT = 0x00002000;
        public const uint GL_COLOR_BUFFER_BIT = 0x00004000;
        public const uint GL_HINT_BIT = 0x00008000;
        public const uint GL_EVAL_BIT = 0x00010000;
        public const uint GL_LIST_BIT = 0x00020000;
        public const uint GL_TEXTURE_BIT = 0x00040000;
        public const uint GL_SCISSOR_BIT = 0x00080000;
        public const uint GL_ALL_ATTRIB_BITS = 0x000fffff;

/* BeginMode */
        public const uint GL_POINTS = 0x0000;
        public const uint GL_LINES = 0x0001;
        public const uint GL_LINE_LOOP = 0x0002;
        public const uint GL_LINE_STRIP = 0x0003;
        public const uint GL_TRIANGLES = 0x0004;
        public const uint GL_TRIANGLE_STRIP = 0x0005;
        public const uint GL_TRIANGLE_FAN = 0x0006;
        public const uint GL_QUADS = 0x0007;
        public const uint GL_QUAD_STRIP = 0x0008;
        public const uint GL_POLYGON = 0x0009;

/* BlendEquationMode */
/*      GL_LOGIC_OP */
/*      GL_FUNC_ADD */
/*      GL_MIN */
/*      GL_MAX */
/*      GL_FUNC_SUBTRACT */
/*      GL_FUNC_REVERSE_SUBTRACT */

/* BlendingFactorDest */
        public const uint GL_ZERO = 0;
        public const uint GL_ONE = 1;
        public const uint GL_SRC_COLOR = 0x0300;
        public const uint GL_ONE_MINUS_SRC_COLOR = 0x0301;
        public const uint GL_SRC_ALPHA = 0x0302;
        public const uint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
        public const uint GL_DST_ALPHA = 0x0304;
        public const uint GL_ONE_MINUS_DST_ALPHA = 0x0305;
/*      GL_CONSTANT_COLOR */
/*      GL_ONE_MINUS_CONSTANT_COLOR */
/*      GL_CONSTANT_ALPHA */
/*      GL_ONE_MINUS_CONSTANT_ALPHA */

/* BlendingFactorSrc */
/*      GL_ZERO */
/*      GL_ONE */
        public const uint GL_DST_COLOR = 0x0306;
        public const uint GL_ONE_MINUS_DST_COLOR = 0x0307;
        public const uint GL_SRC_ALPHA_SATURATE = 0x0308;
/*      GL_SRC_ALPHA */
/*      GL_ONE_MINUS_SRC_ALPHA */
/*      GL_DST_ALPHA */
/*      GL_ONE_MINUS_DST_ALPHA */
/*      GL_CONSTANT_COLOR */
/*      GL_ONE_MINUS_CONSTANT_COLOR */
/*      GL_CONSTANT_ALPHA */
/*      GL_ONE_MINUS_CONSTANT_ALPHA */

/* Boolean */
        public const uint GL_TRUE = 1;
        public const uint GL_FALSE = 0;

/* ClearBufferMask */
/*      GL_COLOR_BUFFER_BIT */
/*      GL_ACCUM_BUFFER_BIT */
/*      GL_STENCIL_BUFFER_BIT */
/*      GL_DEPTH_BUFFER_BIT */

/* ClientArrayType */
/*      GL_VERTEX_ARRAY */
/*      GL_NORMAL_ARRAY */
/*      GL_COLOR_ARRAY */
/*      GL_INDEX_ARRAY */
/*      GL_TEXTURE_COORD_ARRAY */
/*      GL_EDGE_FLAG_ARRAY */

/* ClipPlaneName */
        public const uint GL_CLIP_PLANE0 = 0x3000;
        public const uint GL_CLIP_PLANE1 = 0x3001;
        public const uint GL_CLIP_PLANE2 = 0x3002;
        public const uint GL_CLIP_PLANE3 = 0x3003;
        public const uint GL_CLIP_PLANE4 = 0x3004;
        public const uint GL_CLIP_PLANE5 = 0x3005;

/* ColorMaterialFace */
/*      GL_FRONT */
/*      GL_BACK */
/*      GL_FRONT_AND_BACK */

/* ColorMaterialParameter */
/*      GL_AMBIENT */
/*      GL_DIFFUSE */
/*      GL_SPECULAR */
/*      GL_EMISSION */
/*      GL_AMBIENT_AND_DIFFUSE */

/* ColorPointerType */
/*      GL_BYTE */
/*      GL_UNSIGNED_BYTE */
/*      GL_SHORT */
/*      GL_UNSIGNED_SHORT */
/*      GL_INT */
/*      GL_UNSIGNED_INT */
/*      GL_FLOAT */
/*      GL_DOUBLE */

/* ColorTableParameterPName */
/*      GL_COLOR_TABLE_SCALE */
/*      GL_COLOR_TABLE_BIAS */

/* ColorTableTarget */
/*      GL_COLOR_TABLE */
/*      GL_POST_CONVOLUTION_COLOR_TABLE */
/*      GL_POST_COLOR_MATRIX_COLOR_TABLE */
/*      GL_PROXY_COLOR_TABLE */
/*      GL_PROXY_POST_CONVOLUTION_COLOR_TABLE */
/*      GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE */

/* ConvolutionBorderMode */
/*      GL_REDUCE */
/*      GL_IGNORE_BORDER */
/*      GL_CONSTANT_BORDER */

/* ConvolutionParameter */
/*      GL_CONVOLUTION_BORDER_MODE */
/*      GL_CONVOLUTION_FILTER_SCALE */
/*      GL_CONVOLUTION_FILTER_BIAS */

/* ConvolutionTarget */
/*      GL_CONVOLUTION_1D */
/*      GL_CONVOLUTION_2D */

/* CullFaceMode */
/*      GL_FRONT */
/*      GL_BACK */
/*      GL_FRONT_AND_BACK */

/* DataType */
        public const uint GL_BYTE = 0x1400;
        public const uint GL_UNSIGNED_BYTE = 0x1401;
        public const uint GL_SHORT = 0x1402;
        public const uint GL_UNSIGNED_SHORT = 0x1403;
        public const uint GL_INT = 0x1404;
        public const uint GL_UNSIGNED_INT = 0x1405;
        public const uint GL_FLOAT = 0x1406;
        public const uint GL_2_BYTES = 0x1407;
        public const uint GL_3_BYTES = 0x1408;
        public const uint GL_4_BYTES = 0x1409;
        public const uint GL_DOUBLE = 0x140A;

/* DepthFunction */
/*      GL_NEVER */
/*      GL_LESS */
/*      GL_EQUAL */
/*      GL_LEQUAL */
/*      GL_GREATER */
/*      GL_NOTEQUAL */
/*      GL_GEQUAL */
/*      GL_ALWAYS */

/* DrawBufferMode */
        public const uint GL_NONE = 0;
        public const uint GL_FRONT_LEFT = 0x0400;
        public const uint GL_FRONT_RIGHT = 0x0401;
        public const uint GL_BACK_LEFT = 0x0402;
        public const uint GL_BACK_RIGHT = 0x0403;
        public const uint GL_FRONT = 0x0404;
        public const uint GL_BACK = 0x0405;
        public const uint GL_LEFT = 0x0406;
        public const uint GL_RIGHT = 0x0407;
        public const uint GL_FRONT_AND_BACK = 0x0408;
        public const uint GL_AUX0 = 0x0409;
        public const uint GL_AUX1 = 0x040A;
        public const uint GL_AUX2 = 0x040B;
        public const uint GL_AUX3 = 0x040C;

/* Enable */
/*      GL_FOG */
/*      GL_LIGHTING */
/*      GL_TEXTURE_1D */
/*      GL_TEXTURE_2D */
/*      GL_LINE_STIPPLE */
/*      GL_POLYGON_STIPPLE */
/*      GL_CULL_FACE */
/*      GL_ALPHA_TEST */
/*      GL_BLEND */
/*      GL_INDEX_LOGIC_OP */
/*      GL_COLOR_LOGIC_OP */
/*      GL_DITHER */
/*      GL_STENCIL_TEST */
/*      GL_DEPTH_TEST */
/*      GL_CLIP_PLANE0 */
/*      GL_CLIP_PLANE1 */
/*      GL_CLIP_PLANE2 */
/*      GL_CLIP_PLANE3 */
/*      GL_CLIP_PLANE4 */
/*      GL_CLIP_PLANE5 */
/*      GL_LIGHT0 */
/*      GL_LIGHT1 */
/*      GL_LIGHT2 */
/*      GL_LIGHT3 */
/*      GL_LIGHT4 */
/*      GL_LIGHT5 */
/*      GL_LIGHT6 */
/*      GL_LIGHT7 */
/*      GL_TEXTURE_GEN_S */
/*      GL_TEXTURE_GEN_T */
/*      GL_TEXTURE_GEN_R */
/*      GL_TEXTURE_GEN_Q */
/*      GL_MAP1_VERTEX_3 */
/*      GL_MAP1_VERTEX_4 */
/*      GL_MAP1_COLOR_4 */
/*      GL_MAP1_INDEX */
/*      GL_MAP1_NORMAL */
/*      GL_MAP1_TEXTURE_COORD_1 */
/*      GL_MAP1_TEXTURE_COORD_2 */
/*      GL_MAP1_TEXTURE_COORD_3 */
/*      GL_MAP1_TEXTURE_COORD_4 */
/*      GL_MAP2_VERTEX_3 */
/*      GL_MAP2_VERTEX_4 */
/*      GL_MAP2_COLOR_4 */
/*      GL_MAP2_INDEX */
/*      GL_MAP2_NORMAL */
/*      GL_MAP2_TEXTURE_COORD_1 */
/*      GL_MAP2_TEXTURE_COORD_2 */
/*      GL_MAP2_TEXTURE_COORD_3 */
/*      GL_MAP2_TEXTURE_COORD_4 */
/*      GL_POINT_SMOOTH */
/*      GL_LINE_SMOOTH */
/*      GL_POLYGON_SMOOTH */
/*      GL_SCISSOR_TEST */
/*      GL_COLOR_MATERIAL */
/*      GL_NORMALIZE */
/*      GL_AUTO_NORMAL */
/*      GL_VERTEX_ARRAY */
/*      GL_NORMAL_ARRAY */
/*      GL_COLOR_ARRAY */
/*      GL_INDEX_ARRAY */
/*      GL_TEXTURE_COORD_ARRAY */
/*      GL_EDGE_FLAG_ARRAY */
/*      GL_POLYGON_OFFSET_POINT */
/*      GL_POLYGON_OFFSET_LINE */
/*      GL_POLYGON_OFFSET_FILL */
/*      GL_COLOR_TABLE */
/*      GL_POST_CONVOLUTION_COLOR_TABLE */
/*      GL_POST_COLOR_MATRIX_COLOR_TABLE */
/*      GL_CONVOLUTION_1D */
/*      GL_CONVOLUTION_2D */
/*      GL_SEPARABLE_2D */
/*      GL_HISTOGRAM */
/*      GL_MINMAX */
/*      GL_RESCALE_NORMAL */
/*      GL_TEXTURE_3D */

/* ErrorCode */
        public const uint GL_NO_ERROR = 0;
        public const uint GL_INVALID_ENUM = 0x0500;
        public const uint GL_INVALID_VALUE = 0x0501;
        public const uint GL_INVALID_OPERATION = 0x0502;
        public const uint GL_STACK_OVERFLOW = 0x0503;
        public const uint GL_STACK_UNDERFLOW = 0x0504;
        public const uint GL_OUT_OF_MEMORY = 0x0505;
/*      GL_TABLE_TOO_LARGE */

/* FeedBackMode */
        public const uint GL_2D = 0x0600;
        public const uint GL_3D = 0x0601;
        public const uint GL_3D_COLOR = 0x0602;
        public const uint GL_3D_COLOR_TEXTURE = 0x0603;
        public const uint GL_4D_COLOR_TEXTURE = 0x0604;

/* FeedBackToken */
        public const uint GL_PASS_THROUGH_TOKEN = 0x0700;
        public const uint GL_POINT_TOKEN = 0x0701;
        public const uint GL_LINE_TOKEN = 0x0702;
        public const uint GL_POLYGON_TOKEN = 0x0703;
        public const uint GL_BITMAP_TOKEN = 0x0704;
        public const uint GL_DRAW_PIXEL_TOKEN = 0x0705;
        public const uint GL_COPY_PIXEL_TOKEN = 0x0706;
        public const uint GL_LINE_RESET_TOKEN = 0x0707;

/* FogMode */
/*      GL_LINEAR */
        public const uint GL_EXP = 0x0800;
        public const uint GL_EXP2 = 0x0801;

/* FogParameter */
/*      GL_FOG_COLOR */
/*      GL_FOG_DENSITY */
/*      GL_FOG_END */
/*      GL_FOG_INDEX */
/*      GL_FOG_MODE */
/*      GL_FOG_START */

/* FrontFaceDirection */
        public const uint GL_CW = 0x0900;
        public const uint GL_CCW = 0x0901;

/* GetColorTableParameterPName */
/*      GL_COLOR_TABLE_SCALE */
/*      GL_COLOR_TABLE_BIAS */
/*      GL_COLOR_TABLE_FORMAT */
/*      GL_COLOR_TABLE_WIDTH */
/*      GL_COLOR_TABLE_RED_SIZE */
/*      GL_COLOR_TABLE_GREEN_SIZE */
/*      GL_COLOR_TABLE_BLUE_SIZE */
/*      GL_COLOR_TABLE_ALPHA_SIZE */
/*      GL_COLOR_TABLE_LUMINANCE_SIZE */
/*      GL_COLOR_TABLE_INTENSITY_SIZE */

/* GetConvolutionParameterPName */
/*      GL_CONVOLUTION_BORDER_COLOR */
/*      GL_CONVOLUTION_BORDER_MODE */
/*      GL_CONVOLUTION_FILTER_SCALE */
/*      GL_CONVOLUTION_FILTER_BIAS */
/*      GL_CONVOLUTION_FORMAT */
/*      GL_CONVOLUTION_WIDTH */
/*      GL_CONVOLUTION_HEIGHT */
/*      GL_MAX_CONVOLUTION_WIDTH */
/*      GL_MAX_CONVOLUTION_HEIGHT */

/* GetHistogramParameterPName */
/*      GL_HISTOGRAM_WIDTH */
/*      GL_HISTOGRAM_FORMAT */
/*      GL_HISTOGRAM_RED_SIZE */
/*      GL_HISTOGRAM_GREEN_SIZE */
/*      GL_HISTOGRAM_BLUE_SIZE */
/*      GL_HISTOGRAM_ALPHA_SIZE */
/*      GL_HISTOGRAM_LUMINANCE_SIZE */
/*      GL_HISTOGRAM_SINK */

/* GetMapTarget */
        public const uint GL_COEFF = 0x0A00;
        public const uint GL_ORDER = 0x0A01;
        public const uint GL_DOMAIN = 0x0A02;

/* GetMinmaxParameterPName */
/*      GL_MINMAX_FORMAT */
/*      GL_MINMAX_SINK */

/* GetPixelMap */
/*      GL_PIXEL_MAP_I_TO_I */
/*      GL_PIXEL_MAP_S_TO_S */
/*      GL_PIXEL_MAP_I_TO_R */
/*      GL_PIXEL_MAP_I_TO_G */
/*      GL_PIXEL_MAP_I_TO_B */
/*      GL_PIXEL_MAP_I_TO_A */
/*      GL_PIXEL_MAP_R_TO_R */
/*      GL_PIXEL_MAP_G_TO_G */
/*      GL_PIXEL_MAP_B_TO_B */
/*      GL_PIXEL_MAP_A_TO_A */

/* GetPointerTarget */
/*      GL_VERTEX_ARRAY_POINTER */
/*      GL_NORMAL_ARRAY_POINTER */
/*      GL_COLOR_ARRAY_POINTER */
/*      GL_INDEX_ARRAY_POINTER */
/*      GL_TEXTURE_COORD_ARRAY_POINTER */
/*      GL_EDGE_FLAG_ARRAY_POINTER */

/* GetTarget */
        public const uint GL_CURRENT_COLOR = 0x0B00;
        public const uint GL_CURRENT_INDEX = 0x0B01;
        public const uint GL_CURRENT_NORMAL = 0x0B02;
        public const uint GL_CURRENT_TEXTURE_COORDS = 0x0B03;
        public const uint GL_CURRENT_RASTER_COLOR = 0x0B04;
        public const uint GL_CURRENT_RASTER_INDEX = 0x0B05;
        public const uint GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
        public const uint GL_CURRENT_RASTER_POSITION = 0x0B07;
        public const uint GL_CURRENT_RASTER_POSITION_VALID = 0x0B08;
        public const uint GL_CURRENT_RASTER_DISTANCE = 0x0B09;
        public const uint GL_POINT_SMOOTH = 0x0B10;
        public const uint GL_POINT_SIZE = 0x0B11;
        public const uint GL_POINT_SIZE_RANGE = 0x0B12;
        public const uint GL_POINT_SIZE_GRANULARITY = 0x0B13;
        public const uint GL_LINE_SMOOTH = 0x0B20;
        public const uint GL_LINE_WIDTH = 0x0B21;
        public const uint GL_LINE_WIDTH_RANGE = 0x0B22;
        public const uint GL_LINE_WIDTH_GRANULARITY = 0x0B23;
        public const uint GL_LINE_STIPPLE = 0x0B24;
        public const uint GL_LINE_STIPPLE_PATTERN = 0x0B25;
        public const uint GL_LINE_STIPPLE_REPEAT = 0x0B26;
/*      GL_SMOOTH_POINT_SIZE_RANGE */
/*      GL_SMOOTH_POINT_SIZE_GRANULARITY */
/*      GL_SMOOTH_LINE_WIDTH_RANGE */
/*      GL_SMOOTH_LINE_WIDTH_GRANULARITY */
/*      GL_ALIASED_POINT_SIZE_RANGE */
/*      GL_ALIASED_LINE_WIDTH_RANGE */
        public const uint GL_LIST_MODE = 0x0B30;
        public const uint GL_MAX_LIST_NESTING = 0x0B31;
        public const uint GL_LIST_BASE = 0x0B32;
        public const uint GL_LIST_INDEX = 0x0B33;
        public const uint GL_POLYGON_MODE = 0x0B40;
        public const uint GL_POLYGON_SMOOTH = 0x0B41;
        public const uint GL_POLYGON_STIPPLE = 0x0B42;
        public const uint GL_EDGE_FLAG = 0x0B43;
        public const uint GL_CULL_FACE = 0x0B44;
        public const uint GL_CULL_FACE_MODE = 0x0B45;
        public const uint GL_FRONT_FACE = 0x0B46;
        public const uint GL_LIGHTING = 0x0B50;
        public const uint GL_LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        public const uint GL_LIGHT_MODEL_TWO_SIDE = 0x0B52;
        public const uint GL_LIGHT_MODEL_AMBIENT = 0x0B53;
        public const uint GL_SHADE_MODEL = 0x0B54;
        public const uint GL_COLOR_MATERIAL_FACE = 0x0B55;
        public const uint GL_COLOR_MATERIAL_PARAMETER = 0x0B56;
        public const uint GL_COLOR_MATERIAL = 0x0B57;
        public const uint GL_FOG = 0x0B60;
        public const uint GL_FOG_INDEX = 0x0B61;
        public const uint GL_FOG_DENSITY = 0x0B62;
        public const uint GL_FOG_START = 0x0B63;
        public const uint GL_FOG_END = 0x0B64;
        public const uint GL_FOG_MODE = 0x0B65;
        public const uint GL_FOG_COLOR = 0x0B66;
        public const uint GL_DEPTH_RANGE = 0x0B70;
        public const uint GL_DEPTH_TEST = 0x0B71;
        public const uint GL_DEPTH_WRITEMASK = 0x0B72;
        public const uint GL_DEPTH_CLEAR_VALUE = 0x0B73;
        public const uint GL_DEPTH_FUNC = 0x0B74;
        public const uint GL_ACCUM_CLEAR_VALUE = 0x0B80;
        public const uint GL_STENCIL_TEST = 0x0B90;
        public const uint GL_STENCIL_CLEAR_VALUE = 0x0B91;
        public const uint GL_STENCIL_FUNC = 0x0B92;
        public const uint GL_STENCIL_VALUE_MASK = 0x0B93;
        public const uint GL_STENCIL_FAIL = 0x0B94;
        public const uint GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public const uint GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public const uint GL_STENCIL_REF = 0x0B97;
        public const uint GL_STENCIL_WRITEMASK = 0x0B98;
        public const uint GL_MATRIX_MODE = 0x0BA0;
        public const uint GL_NORMALIZE = 0x0BA1;
        public const uint GL_VIEWPORT = 0x0BA2;
        public const uint GL_MODELVIEW_STACK_DEPTH = 0x0BA3;
        public const uint GL_PROJECTION_STACK_DEPTH = 0x0BA4;
        public const uint GL_TEXTURE_STACK_DEPTH = 0x0BA5;
        public const uint GL_MODELVIEW_MATRIX = 0x0BA6;
        public const uint GL_PROJECTION_MATRIX = 0x0BA7;
        public const uint GL_TEXTURE_MATRIX = 0x0BA8;
        public const uint GL_ATTRIB_STACK_DEPTH = 0x0BB0;
        public const uint GL_CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
        public const uint GL_ALPHA_TEST = 0x0BC0;
        public const uint GL_ALPHA_TEST_FUNC = 0x0BC1;
        public const uint GL_ALPHA_TEST_REF = 0x0BC2;
        public const uint GL_DITHER = 0x0BD0;
        public const uint GL_BLEND_DST = 0x0BE0;
        public const uint GL_BLEND_SRC = 0x0BE1;
        public const uint GL_BLEND = 0x0BE2;
        public const uint GL_LOGIC_OP_MODE = 0x0BF0;
        public const uint GL_INDEX_LOGIC_OP = 0x0BF1;
        public const uint GL_COLOR_LOGIC_OP = 0x0BF2;
        public const uint GL_AUX_BUFFERS = 0x0C00;
        public const uint GL_DRAW_BUFFER = 0x0C01;
        public const uint GL_READ_BUFFER = 0x0C02;
        public const uint GL_SCISSOR_BOX = 0x0C10;
        public const uint GL_SCISSOR_TEST = 0x0C11;
        public const uint GL_INDEX_CLEAR_VALUE = 0x0C20;
        public const uint GL_INDEX_WRITEMASK = 0x0C21;
        public const uint GL_COLOR_CLEAR_VALUE = 0x0C22;
        public const uint GL_COLOR_WRITEMASK = 0x0C23;
        public const uint GL_INDEX_MODE = 0x0C30;
        public const uint GL_RGBA_MODE = 0x0C31;
        public const uint GL_DOUBLEBUFFER = 0x0C32;
        public const uint GL_STEREO = 0x0C33;
        public const uint GL_RENDER_MODE = 0x0C40;
        public const uint GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50;
        public const uint GL_POINT_SMOOTH_HINT = 0x0C51;
        public const uint GL_LINE_SMOOTH_HINT = 0x0C52;
        public const uint GL_POLYGON_SMOOTH_HINT = 0x0C53;
        public const uint GL_FOG_HINT = 0x0C54;
        public const uint GL_TEXTURE_GEN_S = 0x0C60;
        public const uint GL_TEXTURE_GEN_T = 0x0C61;
        public const uint GL_TEXTURE_GEN_R = 0x0C62;
        public const uint GL_TEXTURE_GEN_Q = 0x0C63;
        public const uint GL_PIXEL_MAP_I_TO_I = 0x0C70;
        public const uint GL_PIXEL_MAP_S_TO_S = 0x0C71;
        public const uint GL_PIXEL_MAP_I_TO_R = 0x0C72;
        public const uint GL_PIXEL_MAP_I_TO_G = 0x0C73;
        public const uint GL_PIXEL_MAP_I_TO_B = 0x0C74;
        public const uint GL_PIXEL_MAP_I_TO_A = 0x0C75;
        public const uint GL_PIXEL_MAP_R_TO_R = 0x0C76;
        public const uint GL_PIXEL_MAP_G_TO_G = 0x0C77;
        public const uint GL_PIXEL_MAP_B_TO_B = 0x0C78;
        public const uint GL_PIXEL_MAP_A_TO_A = 0x0C79;
        public const uint GL_PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
        public const uint GL_PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
        public const uint GL_PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
        public const uint GL_PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
        public const uint GL_PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
        public const uint GL_PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
        public const uint GL_PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
        public const uint GL_PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
        public const uint GL_PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
        public const uint GL_PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
        public const uint GL_UNPACK_SWAP_BYTES = 0x0CF0;
        public const uint GL_UNPACK_LSB_FIRST = 0x0CF1;
        public const uint GL_UNPACK_ROW_LENGTH = 0x0CF2;
        public const uint GL_UNPACK_SKIP_ROWS = 0x0CF3;
        public const uint GL_UNPACK_SKIP_PIXELS = 0x0CF4;
        public const uint GL_UNPACK_ALIGNMENT = 0x0CF5;
        public const uint GL_PACK_SWAP_BYTES = 0x0D00;
        public const uint GL_PACK_LSB_FIRST = 0x0D01;
        public const uint GL_PACK_ROW_LENGTH = 0x0D02;
        public const uint GL_PACK_SKIP_ROWS = 0x0D03;
        public const uint GL_PACK_SKIP_PIXELS = 0x0D04;
        public const uint GL_PACK_ALIGNMENT = 0x0D05;
        public const uint GL_MAP_COLOR = 0x0D10;
        public const uint GL_MAP_STENCIL = 0x0D11;
        public const uint GL_INDEX_SHIFT = 0x0D12;
        public const uint GL_INDEX_OFFSET = 0x0D13;
        public const uint GL_RED_SCALE = 0x0D14;
        public const uint GL_RED_BIAS = 0x0D15;
        public const uint GL_ZOOM_X = 0x0D16;
        public const uint GL_ZOOM_Y = 0x0D17;
        public const uint GL_GREEN_SCALE = 0x0D18;
        public const uint GL_GREEN_BIAS = 0x0D19;
        public const uint GL_BLUE_SCALE = 0x0D1A;
        public const uint GL_BLUE_BIAS = 0x0D1B;
        public const uint GL_ALPHA_SCALE = 0x0D1C;
        public const uint GL_ALPHA_BIAS = 0x0D1D;
        public const uint GL_DEPTH_SCALE = 0x0D1E;
        public const uint GL_DEPTH_BIAS = 0x0D1F;
        public const uint GL_MAX_EVAL_ORDER = 0x0D30;
        public const uint GL_MAX_LIGHTS = 0x0D31;
        public const uint GL_MAX_CLIP_PLANES = 0x0D32;
        public const uint GL_MAX_TEXTURE_SIZE = 0x0D33;
        public const uint GL_MAX_PIXEL_MAP_TABLE = 0x0D34;
        public const uint GL_MAX_ATTRIB_STACK_DEPTH = 0x0D35;
        public const uint GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
        public const uint GL_MAX_NAME_STACK_DEPTH = 0x0D37;
        public const uint GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38;
        public const uint GL_MAX_TEXTURE_STACK_DEPTH = 0x0D39;
        public const uint GL_MAX_VIEWPORT_DIMS = 0x0D3A;
        public const uint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
        public const uint GL_SUBPIXEL_BITS = 0x0D50;
        public const uint GL_INDEX_BITS = 0x0D51;
        public const uint GL_RED_BITS = 0x0D52;
        public const uint GL_GREEN_BITS = 0x0D53;
        public const uint GL_BLUE_BITS = 0x0D54;
        public const uint GL_ALPHA_BITS = 0x0D55;
        public const uint GL_DEPTH_BITS = 0x0D56;
        public const uint GL_STENCIL_BITS = 0x0D57;
        public const uint GL_ACCUM_RED_BITS = 0x0D58;
        public const uint GL_ACCUM_GREEN_BITS = 0x0D59;
        public const uint GL_ACCUM_BLUE_BITS = 0x0D5A;
        public const uint GL_ACCUM_ALPHA_BITS = 0x0D5B;
        public const uint GL_NAME_STACK_DEPTH = 0x0D70;
        public const uint GL_AUTO_NORMAL = 0x0D80;
        public const uint GL_MAP1_COLOR_4 = 0x0D90;
        public const uint GL_MAP1_INDEX = 0x0D91;
        public const uint GL_MAP1_NORMAL = 0x0D92;
        public const uint GL_MAP1_TEXTURE_COORD_1 = 0x0D93;
        public const uint GL_MAP1_TEXTURE_COORD_2 = 0x0D94;
        public const uint GL_MAP1_TEXTURE_COORD_3 = 0x0D95;
        public const uint GL_MAP1_TEXTURE_COORD_4 = 0x0D96;
        public const uint GL_MAP1_VERTEX_3 = 0x0D97;
        public const uint GL_MAP1_VERTEX_4 = 0x0D98;
        public const uint GL_MAP2_COLOR_4 = 0x0DB0;
        public const uint GL_MAP2_INDEX = 0x0DB1;
        public const uint GL_MAP2_NORMAL = 0x0DB2;
        public const uint GL_MAP2_TEXTURE_COORD_1 = 0x0DB3;
        public const uint GL_MAP2_TEXTURE_COORD_2 = 0x0DB4;
        public const uint GL_MAP2_TEXTURE_COORD_3 = 0x0DB5;
        public const uint GL_MAP2_TEXTURE_COORD_4 = 0x0DB6;
        public const uint GL_MAP2_VERTEX_3 = 0x0DB7;
        public const uint GL_MAP2_VERTEX_4 = 0x0DB8;
        public const uint GL_MAP1_GRID_DOMAIN = 0x0DD0;
        public const uint GL_MAP1_GRID_SEGMENTS = 0x0DD1;
        public const uint GL_MAP2_GRID_DOMAIN = 0x0DD2;
        public const uint GL_MAP2_GRID_SEGMENTS = 0x0DD3;
        public const uint GL_TEXTURE_1D = 0x0DE0;
        public const uint GL_TEXTURE_2D = 0x0DE1;
        public const uint GL_FEEDBACK_BUFFER_POINTER = 0x0DF0;
        public const uint GL_FEEDBACK_BUFFER_SIZE = 0x0DF1;
        public const uint GL_FEEDBACK_BUFFER_TYPE = 0x0DF2;
        public const uint GL_SELECTION_BUFFER_POINTER = 0x0DF3;
        public const uint GL_SELECTION_BUFFER_SIZE = 0x0DF4;
/*      GL_TEXTURE_BINDING_1D */
/*      GL_TEXTURE_BINDING_2D */
/*      GL_TEXTURE_BINDING_3D */
/*      GL_VERTEX_ARRAY */
/*      GL_NORMAL_ARRAY */
/*      GL_COLOR_ARRAY */
/*      GL_INDEX_ARRAY */
/*      GL_TEXTURE_COORD_ARRAY */
/*      GL_EDGE_FLAG_ARRAY */
/*      GL_VERTEX_ARRAY_SIZE */
/*      GL_VERTEX_ARRAY_TYPE */
/*      GL_VERTEX_ARRAY_STRIDE */
/*      GL_NORMAL_ARRAY_TYPE */
/*      GL_NORMAL_ARRAY_STRIDE */
/*      GL_COLOR_ARRAY_SIZE */
/*      GL_COLOR_ARRAY_TYPE */
/*      GL_COLOR_ARRAY_STRIDE */
/*      GL_INDEX_ARRAY_TYPE */
/*      GL_INDEX_ARRAY_STRIDE */
/*      GL_TEXTURE_COORD_ARRAY_SIZE */
/*      GL_TEXTURE_COORD_ARRAY_TYPE */
/*      GL_TEXTURE_COORD_ARRAY_STRIDE */
/*      GL_EDGE_FLAG_ARRAY_STRIDE */
/*      GL_POLYGON_OFFSET_FACTOR */
/*      GL_POLYGON_OFFSET_UNITS */
/*      GL_COLOR_TABLE */
/*      GL_POST_CONVOLUTION_COLOR_TABLE */
/*      GL_POST_COLOR_MATRIX_COLOR_TABLE */
/*      GL_CONVOLUTION_1D */
/*      GL_CONVOLUTION_2D */
/*      GL_SEPARABLE_2D */
/*      GL_POST_CONVOLUTION_RED_SCALE */
/*      GL_POST_CONVOLUTION_GREEN_SCALE */
/*      GL_POST_CONVOLUTION_BLUE_SCALE */
/*      GL_POST_CONVOLUTION_ALPHA_SCALE */
/*      GL_POST_CONVOLUTION_RED_BIAS */
/*      GL_POST_CONVOLUTION_GREEN_BIAS */
/*      GL_POST_CONVOLUTION_BLUE_BIAS */
/*      GL_POST_CONVOLUTION_ALPHA_BIAS */
/*      GL_COLOR_MATRIX */
/*      GL_COLOR_MATRIX_STACK_DEPTH */
/*      GL_MAX_COLOR_MATRIX_STACK_DEPTH */
/*      GL_POST_COLOR_MATRIX_RED_SCALE */
/*      GL_POST_COLOR_MATRIX_GREEN_SCALE */
/*      GL_POST_COLOR_MATRIX_BLUE_SCALE */
/*      GL_POST_COLOR_MATRIX_ALPHA_SCALE */
/*      GL_POST_COLOR_MATRIX_RED_BIAS */
/*      GL_POST_COLOR_MATRIX_GREEN_BIAS */
/*      GL_POST_COLOR_MATRIX_BLUE_BIAS */
/*      GL_POST_COLOR_MATRIX_ALPHA_BIAS */
/*      GL_HISTOGRAM */
/*      GL_MINMAX */
/*      GL_MAX_ELEMENTS_VERTICES */
/*      GL_MAX_ELEMENTS_INDICES */
/*      GL_RESCALE_NORMAL */
/*      GL_LIGHT_MODEL_COLOR_CONTROL */
/*      GL_PACK_SKIP_IMAGES */
/*      GL_PACK_IMAGE_HEIGHT */
/*      GL_UNPACK_SKIP_IMAGES */
/*      GL_UNPACK_IMAGE_HEIGHT */
/*      GL_TEXTURE_3D */
/*      GL_MAX_3D_TEXTURE_SIZE */
/*      GL_BLEND_COLOR */
/*      GL_BLEND_EQUATION */

/* GetTextureParameter */
/*      GL_TEXTURE_MAG_FILTER */
/*      GL_TEXTURE_MIN_FILTER */
/*      GL_TEXTURE_WRAP_S */
/*      GL_TEXTURE_WRAP_T */
        public const uint GL_TEXTURE_WIDTH = 0x1000;
        public const uint GL_TEXTURE_HEIGHT = 0x1001;
        public const uint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
        public const uint GL_TEXTURE_BORDER_COLOR = 0x1004;
        public const uint GL_TEXTURE_BORDER = 0x1005;
/*      GL_TEXTURE_RED_SIZE */
/*      GL_TEXTURE_GREEN_SIZE */
/*      GL_TEXTURE_BLUE_SIZE */
/*      GL_TEXTURE_ALPHA_SIZE */
/*      GL_TEXTURE_LUMINANCE_SIZE */
/*      GL_TEXTURE_INTENSITY_SIZE */
/*      GL_TEXTURE_PRIORITY */
/*      GL_TEXTURE_RESIDENT */
/*      GL_TEXTURE_DEPTH */
/*      GL_TEXTURE_WRAP_R */
/*      GL_TEXTURE_MIN_LOD */
/*      GL_TEXTURE_MAX_LOD */
/*      GL_TEXTURE_BASE_LEVEL */
/*      GL_TEXTURE_MAX_LEVEL */

/* HintMode */
        public const uint GL_DONT_CARE = 0x1100;
        public const uint GL_FASTEST = 0x1101;
        public const uint GL_NICEST = 0x1102;

/* HintTarget */
/*      GL_PERSPECTIVE_CORRECTION_HINT */
/*      GL_POINT_SMOOTH_HINT */
/*      GL_LINE_SMOOTH_HINT */
/*      GL_POLYGON_SMOOTH_HINT */
/*      GL_FOG_HINT */

/* HistogramTarget */
/*      GL_HISTOGRAM */
/*      GL_PROXY_HISTOGRAM */

/* IndexPointerType */
/*      GL_SHORT */
/*      GL_INT */
/*      GL_FLOAT */
/*      GL_DOUBLE */

/* LightModelColorControl */
/*      GL_SINGLE_COLOR */
/*      GL_SEPARATE_SPECULAR_COLOR */

/* LightModelParameter */
/*      GL_LIGHT_MODEL_AMBIENT */
/*      GL_LIGHT_MODEL_LOCAL_VIEWER */
/*      GL_LIGHT_MODEL_TWO_SIDE */
/*      GL_LIGHT_MODEL_COLOR_CONTROL */

/* LightName */
        public const uint GL_LIGHT0 = 0x4000;
        public const uint GL_LIGHT1 = 0x4001;
        public const uint GL_LIGHT2 = 0x4002;
        public const uint GL_LIGHT3 = 0x4003;
        public const uint GL_LIGHT4 = 0x4004;
        public const uint GL_LIGHT5 = 0x4005;
        public const uint GL_LIGHT6 = 0x4006;
        public const uint GL_LIGHT7 = 0x4007;

/* LightParameter */
        public const uint GL_AMBIENT = 0x1200;
        public const uint GL_DIFFUSE = 0x1201;
        public const uint GL_SPECULAR = 0x1202;
        public const uint GL_POSITION = 0x1203;
        public const uint GL_SPOT_DIRECTION = 0x1204;
        public const uint GL_SPOT_EXPONENT = 0x1205;
        public const uint GL_SPOT_CUTOFF = 0x1206;
        public const uint GL_CONSTANT_ATTENUATION = 0x1207;
        public const uint GL_LINEAR_ATTENUATION = 0x1208;
        public const uint GL_QUADRATIC_ATTENUATION = 0x1209;

/* InterleavedArrays */
/*      GL_V2F */
/*      GL_V3F */
/*      GL_C4UB_V2F */
/*      GL_C4UB_V3F */
/*      GL_C3F_V3F */
/*      GL_N3F_V3F */
/*      GL_C4F_N3F_V3F */
/*      GL_T2F_V3F */
/*      GL_T4F_V4F */
/*      GL_T2F_C4UB_V3F */
/*      GL_T2F_C3F_V3F */
/*      GL_T2F_N3F_V3F */
/*      GL_T2F_C4F_N3F_V3F */
/*      GL_T4F_C4F_N3F_V4F */

/* ListMode */
        public const uint GL_COMPILE = 0x1300;
        public const uint GL_COMPILE_AND_EXECUTE = 0x1301;

/* ListNameType */
/*      GL_BYTE */
/*      GL_UNSIGNED_BYTE */
/*      GL_SHORT */
/*      GL_UNSIGNED_SHORT */
/*      GL_INT */
/*      GL_UNSIGNED_INT */
/*      GL_FLOAT */
/*      GL_2_BYTES */
/*      GL_3_BYTES */
/*      GL_4_BYTES */

/* LogicOp */
        public const uint GL_CLEAR = 0x1500;
        public const uint GL_AND = 0x1501;
        public const uint GL_AND_REVERSE = 0x1502;
        public const uint GL_COPY = 0x1503;
        public const uint GL_AND_INVERTED = 0x1504;
        public const uint GL_NOOP = 0x1505;
        public const uint GL_XOR = 0x1506;
        public const uint GL_OR = 0x1507;
        public const uint GL_NOR = 0x1508;
        public const uint GL_EQUIV = 0x1509;
        public const uint GL_INVERT = 0x150A;
        public const uint GL_OR_REVERSE = 0x150B;
        public const uint GL_COPY_INVERTED = 0x150C;
        public const uint GL_OR_INVERTED = 0x150D;
        public const uint GL_NAND = 0x150E;
        public const uint GL_SET = 0x150F;

/* MapTarget */
/*      GL_MAP1_COLOR_4 */
/*      GL_MAP1_INDEX */
/*      GL_MAP1_NORMAL */
/*      GL_MAP1_TEXTURE_COORD_1 */
/*      GL_MAP1_TEXTURE_COORD_2 */
/*      GL_MAP1_TEXTURE_COORD_3 */
/*      GL_MAP1_TEXTURE_COORD_4 */
/*      GL_MAP1_VERTEX_3 */
/*      GL_MAP1_VERTEX_4 */
/*      GL_MAP2_COLOR_4 */
/*      GL_MAP2_INDEX */
/*      GL_MAP2_NORMAL */
/*      GL_MAP2_TEXTURE_COORD_1 */
/*      GL_MAP2_TEXTURE_COORD_2 */
/*      GL_MAP2_TEXTURE_COORD_3 */
/*      GL_MAP2_TEXTURE_COORD_4 */
/*      GL_MAP2_VERTEX_3 */
/*      GL_MAP2_VERTEX_4 */

/* MaterialFace */
/*      GL_FRONT */
/*      GL_BACK */
/*      GL_FRONT_AND_BACK */

/* MaterialParameter */
        public const uint GL_EMISSION = 0x1600;
        public const uint GL_SHININESS = 0x1601;
        public const uint GL_AMBIENT_AND_DIFFUSE = 0x1602;
        public const uint GL_COLOR_INDEXES = 0x1603;
/*      GL_AMBIENT */
/*      GL_DIFFUSE */
/*      GL_SPECULAR */

/* MatrixMode */
        public const uint GL_MODELVIEW = 0x1700;
        public const uint GL_PROJECTION = 0x1701;
        public const uint GL_TEXTURE = 0x1702;

/* MeshMode1 */
/*      GL_POINT */
/*      GL_LINE */

/* MeshMode2 */
/*      GL_POINT */
/*      GL_LINE */
/*      GL_FILL */

/* MinmaxTarget */
/*      GL_MINMAX */

/* NormalPointerType */
/*      GL_BYTE */
/*      GL_SHORT */
/*      GL_INT */
/*      GL_FLOAT */
/*      GL_DOUBLE */

/* PixelCopyType */
        public const uint GL_COLOR = 0x1800;
        public const uint GL_DEPTH = 0x1801;
        public const uint GL_STENCIL = 0x1802;

/* PixelFormat */
        public const uint GL_COLOR_INDEX = 0x1900;
        public const uint GL_STENCIL_INDEX = 0x1901;
        public const uint GL_DEPTH_COMPONENT = 0x1902;
        public const uint GL_RED = 0x1903;
        public const uint GL_GREEN = 0x1904;
        public const uint GL_BLUE = 0x1905;
        public const uint GL_ALPHA = 0x1906;
        public const uint GL_RGB = 0x1907;
        public const uint GL_RGBA = 0x1908;
        public const uint GL_LUMINANCE = 0x1909;
        public const uint GL_LUMINANCE_ALPHA = 0x190A;
/*      GL_ABGR */

/* PixelInternalFormat */
/*      GL_ALPHA4 */
/*      GL_ALPHA8 */
/*      GL_ALPHA12 */
/*      GL_ALPHA16 */
/*      GL_LUMINANCE4 */
/*      GL_LUMINANCE8 */
/*      GL_LUMINANCE12 */
/*      GL_LUMINANCE16 */
/*      GL_LUMINANCE4_ALPHA4 */
/*      GL_LUMINANCE6_ALPHA2 */
/*      GL_LUMINANCE8_ALPHA8 */
/*      GL_LUMINANCE12_ALPHA4 */
/*      GL_LUMINANCE12_ALPHA12 */
/*      GL_LUMINANCE16_ALPHA16 */
/*      GL_INTENSITY */
/*      GL_INTENSITY4 */
/*      GL_INTENSITY8 */
/*      GL_INTENSITY12 */
/*      GL_INTENSITY16 */
/*      GL_R3_G3_B2 */
/*      GL_RGB4 */
/*      GL_RGB5 */
/*      GL_RGB8 */
/*      GL_RGB10 */
/*      GL_RGB12 */
/*      GL_RGB16 */
/*      GL_RGBA2 */
/*      GL_RGBA4 */
/*      GL_RGB5_A1 */
/*      GL_RGBA8 */
/*      GL_RGB10_A2 */
/*      GL_RGBA12 */
/*      GL_RGBA16 */

/* PixelMap */
/*      GL_PIXEL_MAP_I_TO_I */
/*      GL_PIXEL_MAP_S_TO_S */
/*      GL_PIXEL_MAP_I_TO_R */
/*      GL_PIXEL_MAP_I_TO_G */
/*      GL_PIXEL_MAP_I_TO_B */
/*      GL_PIXEL_MAP_I_TO_A */
/*      GL_PIXEL_MAP_R_TO_R */
/*      GL_PIXEL_MAP_G_TO_G */
/*      GL_PIXEL_MAP_B_TO_B */
/*      GL_PIXEL_MAP_A_TO_A */

/* PixelStore */
/*      GL_UNPACK_SWAP_BYTES */
/*      GL_UNPACK_LSB_FIRST */
/*      GL_UNPACK_ROW_LENGTH */
/*      GL_UNPACK_SKIP_ROWS */
/*      GL_UNPACK_SKIP_PIXELS */
/*      GL_UNPACK_ALIGNMENT */
/*      GL_PACK_SWAP_BYTES */
/*      GL_PACK_LSB_FIRST */
/*      GL_PACK_ROW_LENGTH */
/*      GL_PACK_SKIP_ROWS */
/*      GL_PACK_SKIP_PIXELS */
/*      GL_PACK_ALIGNMENT */
/*      GL_PACK_SKIP_IMAGES */
/*      GL_PACK_IMAGE_HEIGHT */
/*      GL_UNPACK_SKIP_IMAGES */
/*      GL_UNPACK_IMAGE_HEIGHT */

/* PixelTransfer */
/*      GL_MAP_COLOR */
/*      GL_MAP_STENCIL */
/*      GL_INDEX_SHIFT */
/*      GL_INDEX_OFFSET */
/*      GL_RED_SCALE */
/*      GL_RED_BIAS */
/*      GL_GREEN_SCALE */
/*      GL_GREEN_BIAS */
/*      GL_BLUE_SCALE */
/*      GL_BLUE_BIAS */
/*      GL_ALPHA_SCALE */
/*      GL_ALPHA_BIAS */
/*      GL_DEPTH_SCALE */
/*      GL_DEPTH_BIAS */
/*      GL_POST_CONVOLUTION_RED_SCALE */
/*      GL_POST_CONVOLUTION_GREEN_SCALE */
/*      GL_POST_CONVOLUTION_BLUE_SCALE */
/*      GL_POST_CONVOLUTION_ALPHA_SCALE */
/*      GL_POST_CONVOLUTION_RED_BIAS */
/*      GL_POST_CONVOLUTION_GREEN_BIAS */
/*      GL_POST_CONVOLUTION_BLUE_BIAS */
/*      GL_POST_CONVOLUTION_ALPHA_BIAS */
/*      GL_POST_COLOR_MATRIX_RED_SCALE */
/*      GL_POST_COLOR_MATRIX_GREEN_SCALE */
/*      GL_POST_COLOR_MATRIX_BLUE_SCALE */
/*      GL_POST_COLOR_MATRIX_ALPHA_SCALE */
/*      GL_POST_COLOR_MATRIX_RED_BIAS */
/*      GL_POST_COLOR_MATRIX_GREEN_BIAS */
/*      GL_POST_COLOR_MATRIX_BLUE_BIAS */
/*      GL_POST_COLOR_MATRIX_ALPHA_BIAS */

/* PixelType */
        public const uint GL_BITMAP = 0x1A00;
/*      GL_BYTE */
/*      GL_UNSIGNED_BYTE */
/*      GL_SHORT */
/*      GL_UNSIGNED_SHORT */
/*      GL_INT */
/*      GL_UNSIGNED_INT */
/*      GL_FLOAT */
/*      GL_BGR */
/*      GL_BGRA */
/*      GL_UNSIGNED_BYTE_3_3_2 */
/*      GL_UNSIGNED_SHORT_4_4_4_4 */
/*      GL_UNSIGNED_SHORT_5_5_5_1 */
/*      GL_UNSIGNED_INT_8_8_8_8 */
/*      GL_UNSIGNED_INT_10_10_10_2 */
/*      GL_UNSIGNED_SHORT_5_6_5 */
/*      GL_UNSIGNED_BYTE_2_3_3_REV */
/*      GL_UNSIGNED_SHORT_5_6_5_REV */
/*      GL_UNSIGNED_SHORT_4_4_4_4_REV */
/*      GL_UNSIGNED_SHORT_1_5_5_5_REV */
/*      GL_UNSIGNED_INT_8_8_8_8_REV */
/*      GL_UNSIGNED_INT_2_10_10_10_REV */

/* PolygonMode */
        public const uint GL_POINT = 0x1B00;
        public const uint GL_LINE = 0x1B01;
        public const uint GL_FILL = 0x1B02;

/* ReadBufferMode */
/*      GL_FRONT_LEFT */
/*      GL_FRONT_RIGHT */
/*      GL_BACK_LEFT */
/*      GL_BACK_RIGHT */
/*      GL_FRONT */
/*      GL_BACK */
/*      GL_LEFT */
/*      GL_RIGHT */
/*      GL_AUX0 */
/*      GL_AUX1 */
/*      GL_AUX2 */
/*      GL_AUX3 */

/* RenderingMode */
        public const uint GL_RENDER = 0x1C00;
        public const uint GL_FEEDBACK = 0x1C01;
        public const uint GL_SELECT = 0x1C02;

/* SeparableTarget */
/*      GL_SEPARABLE_2D */

/* ShadingModel */
        public const uint GL_FLAT = 0x1D00;
        public const uint GL_SMOOTH = 0x1D01;

/* StencilFunction */
/*      GL_NEVER */
/*      GL_LESS */
/*      GL_EQUAL */
/*      GL_LEQUAL */
/*      GL_GREATER */
/*      GL_NOTEQUAL */
/*      GL_GEQUAL */
/*      GL_ALWAYS */

/* StencilOp */
/*      GL_ZERO */
        public const uint GL_KEEP = 0x1E00;
        public const uint GL_REPLACE = 0x1E01;
        public const uint GL_INCR = 0x1E02;
        public const uint GL_DECR = 0x1E03;
/*      GL_INVERT */

/* StringName */
        public const uint GL_VENDOR = 0x1F00;
        public const uint GL_RENDERER = 0x1F01;
        public const uint GL_VERSION = 0x1F02;
        public const uint GL_EXTENSIONS = 0x1F03;

/* TextureCoordName */
        public const uint GL_S = 0x2000;
        public const uint GL_T = 0x2001;
        public const uint GL_R = 0x2002;
        public const uint GL_Q = 0x2003;

/* TexCoordPointerType */
/*      GL_SHORT */
/*      GL_INT */
/*      GL_FLOAT */
/*      GL_DOUBLE */

/* TextureEnvMode */
        public const uint GL_MODULATE = 0x2100;
        public const uint GL_DECAL = 0x2101;
/*      GL_BLEND */
/*      GL_REPLACE */

/* TextureEnvParameter */
        public const uint GL_TEXTURE_ENV_MODE = 0x2200;
        public const uint GL_TEXTURE_ENV_COLOR = 0x2201;

/* TextureEnvTarget */
        public const uint GL_TEXTURE_ENV = 0x2300;

/* TextureGenMode */
        public const uint GL_EYE_LINEAR = 0x2400;
        public const uint GL_OBJECT_LINEAR = 0x2401;
        public const uint GL_SPHERE_MAP = 0x2402;

/* TextureGenParameter */
        public const uint GL_TEXTURE_GEN_MODE = 0x2500;
        public const uint GL_OBJECT_PLANE = 0x2501;
        public const uint GL_EYE_PLANE = 0x2502;

/* TextureMagFilter */
        public const uint GL_NEAREST = 0x2600;
        public const uint GL_LINEAR = 0x2601;

/* TextureMinFilter */
/*      GL_NEAREST */
/*      GL_LINEAR */
        public const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
        public const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
        public const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
        public const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;

/* TextureParameterName */
        public const uint GL_TEXTURE_MAG_FILTER = 0x2800;
        public const uint GL_TEXTURE_MIN_FILTER = 0x2801;
        public const uint GL_TEXTURE_WRAP_S = 0x2802;
        public const uint GL_TEXTURE_WRAP_T = 0x2803;
/*      GL_TEXTURE_BORDER_COLOR */
/*      GL_TEXTURE_PRIORITY */
/*      GL_TEXTURE_WRAP_R */
/*      GL_TEXTURE_MIN_LOD */
/*      GL_TEXTURE_MAX_LOD */
/*      GL_TEXTURE_BASE_LEVEL */
/*      GL_TEXTURE_MAX_LEVEL */

/* TextureTarget */
/*      GL_TEXTURE_1D */
/*      GL_TEXTURE_2D */
/*      GL_PROXY_TEXTURE_1D */
/*      GL_PROXY_TEXTURE_2D */
/*      GL_TEXTURE_3D */
/*      GL_PROXY_TEXTURE_3D */

/* TextureWrapMode */
        public const uint GL_CLAMP = 0x2900;
        public const uint GL_REPEAT = 0x2901;
/*      GL_CLAMP_TO_EDGE */

/* VertexPointerType */
/*      GL_SHORT */
/*      GL_INT */
/*      GL_FLOAT */
/*      GL_DOUBLE */

/* ClientAttribMask */
        public const uint GL_CLIENT_PIXEL_STORE_BIT = 0x00000001;
        public const uint GL_CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
        public const uint GL_CLIENT_ALL_ATTRIB_BITS = 0xffffffff;

/* polygon_offset */
        public const uint GL_POLYGON_OFFSET_FACTOR = 0x8038;
        public const uint GL_POLYGON_OFFSET_UNITS = 0x2A00;
        public const uint GL_POLYGON_OFFSET_POINT = 0x2A01;
        public const uint GL_POLYGON_OFFSET_LINE = 0x2A02;
        public const uint GL_POLYGON_OFFSET_FILL = 0x8037;

/* texture */
        public const uint GL_ALPHA4 = 0x803B;
        public const uint GL_ALPHA8 = 0x803C;
        public const uint GL_ALPHA12 = 0x803D;
        public const uint GL_ALPHA16 = 0x803E;
        public const uint GL_LUMINANCE4 = 0x803F;
        public const uint GL_LUMINANCE8 = 0x8040;
        public const uint GL_LUMINANCE12 = 0x8041;
        public const uint GL_LUMINANCE16 = 0x8042;
        public const uint GL_LUMINANCE4_ALPHA4 = 0x8043;
        public const uint GL_LUMINANCE6_ALPHA2 = 0x8044;
        public const uint GL_LUMINANCE8_ALPHA8 = 0x8045;
        public const uint GL_LUMINANCE12_ALPHA4 = 0x8046;
        public const uint GL_LUMINANCE12_ALPHA12 = 0x8047;
        public const uint GL_LUMINANCE16_ALPHA16 = 0x8048;
        public const uint GL_INTENSITY = 0x8049;
        public const uint GL_INTENSITY4 = 0x804A;
        public const uint GL_INTENSITY8 = 0x804B;
        public const uint GL_INTENSITY12 = 0x804C;
        public const uint GL_INTENSITY16 = 0x804D;
        public const uint GL_R3_G3_B2 = 0x2A10;
        public const uint GL_RGB4 = 0x804F;
        public const uint GL_RGB5 = 0x8050;
        public const uint GL_RGB8 = 0x8051;
        public const uint GL_RGB10 = 0x8052;
        public const uint GL_RGB12 = 0x8053;
        public const uint GL_RGB16 = 0x8054;
        public const uint GL_RGBA2 = 0x8055;
        public const uint GL_RGBA4 = 0x8056;
        public const uint GL_RGB5_A1 = 0x8057;
        public const uint GL_RGBA8 = 0x8058;
        public const uint GL_RGB10_A2 = 0x8059;
        public const uint GL_RGBA12 = 0x805A;
        public const uint GL_RGBA16 = 0x805B;
        public const uint GL_TEXTURE_RED_SIZE = 0x805C;
        public const uint GL_TEXTURE_GREEN_SIZE = 0x805D;
        public const uint GL_TEXTURE_BLUE_SIZE = 0x805E;
        public const uint GL_TEXTURE_ALPHA_SIZE = 0x805F;
        public const uint GL_TEXTURE_LUMINANCE_SIZE = 0x8060;
        public const uint GL_TEXTURE_INTENSITY_SIZE = 0x8061;
        public const uint GL_PROXY_TEXTURE_1D = 0x8063;
        public const uint GL_PROXY_TEXTURE_2D = 0x8064;

/* texture_object */
        public const uint GL_TEXTURE_PRIORITY = 0x8066;
        public const uint GL_TEXTURE_RESIDENT = 0x8067;
        public const uint GL_TEXTURE_BINDING_1D = 0x8068;
        public const uint GL_TEXTURE_BINDING_2D = 0x8069;
        public const uint GL_TEXTURE_BINDING_3D = 0x806A;

/* vertex_array */
        public const uint GL_VERTEX_ARRAY = 0x8074;
        public const uint GL_NORMAL_ARRAY = 0x8075;
        public const uint GL_COLOR_ARRAY = 0x8076;
        public const uint GL_INDEX_ARRAY = 0x8077;
        public const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
        public const uint GL_EDGE_FLAG_ARRAY = 0x8079;
        public const uint GL_VERTEX_ARRAY_SIZE = 0x807A;
        public const uint GL_VERTEX_ARRAY_TYPE = 0x807B;
        public const uint GL_VERTEX_ARRAY_STRIDE = 0x807C;
        public const uint GL_NORMAL_ARRAY_TYPE = 0x807E;
        public const uint GL_NORMAL_ARRAY_STRIDE = 0x807F;
        public const uint GL_COLOR_ARRAY_SIZE = 0x8081;
        public const uint GL_COLOR_ARRAY_TYPE = 0x8082;
        public const uint GL_COLOR_ARRAY_STRIDE = 0x8083;
        public const uint GL_INDEX_ARRAY_TYPE = 0x8085;
        public const uint GL_INDEX_ARRAY_STRIDE = 0x8086;
        public const uint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        public const uint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        public const uint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
        public const uint GL_EDGE_FLAG_ARRAY_STRIDE = 0x808C;
        public const uint GL_VERTEX_ARRAY_POINTER = 0x808E;
        public const uint GL_NORMAL_ARRAY_POINTER = 0x808F;
        public const uint GL_COLOR_ARRAY_POINTER = 0x8090;
        public const uint GL_INDEX_ARRAY_POINTER = 0x8091;
        public const uint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        public const uint GL_EDGE_FLAG_ARRAY_POINTER = 0x8093;
        public const uint GL_V2F = 0x2A20;
        public const uint GL_V3F = 0x2A21;
        public const uint GL_C4UB_V2F = 0x2A22;
        public const uint GL_C4UB_V3F = 0x2A23;
        public const uint GL_C3F_V3F = 0x2A24;
        public const uint GL_N3F_V3F = 0x2A25;
        public const uint GL_C4F_N3F_V3F = 0x2A26;
        public const uint GL_T2F_V3F = 0x2A27;
        public const uint GL_T4F_V4F = 0x2A28;
        public const uint GL_T2F_C4UB_V3F = 0x2A29;
        public const uint GL_T2F_C3F_V3F = 0x2A2A;
        public const uint GL_T2F_N3F_V3F = 0x2A2B;
        public const uint GL_T2F_C4F_N3F_V3F = 0x2A2C;
        public const uint GL_T4F_C4F_N3F_V4F = 0x2A2D;

/* bgra */
        public const uint GL_BGR = 0x80E0;
        public const uint GL_BGRA = 0x80E1;

/* blend_color */
        public const uint GL_CONSTANT_COLOR = 0x8001;
        public const uint GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public const uint GL_CONSTANT_ALPHA = 0x8003;
        public const uint GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;
        public const uint GL_BLEND_COLOR = 0x8005;

/* blend_minmax */
        public const uint GL_FUNC_ADD = 0x8006;
        public const uint GL_MIN = 0x8007;
        public const uint GL_MAX = 0x8008;
        public const uint GL_BLEND_EQUATION = 0x8009;

/* blend_equation_separate */
        public const uint GL_BLEND_EQUATION_RGB = 0x8009;
        public const uint GL_BLEND_EQUATION_ALPHA = 0x883D;

/* blend_subtract */
        public const uint GL_FUNC_SUBTRACT = 0x800A;
        public const uint GL_FUNC_REVERSE_SUBTRACT = 0x800B;

/* color_matrix */
        public const uint GL_COLOR_MATRIX = 0x80B1;
        public const uint GL_COLOR_MATRIX_STACK_DEPTH = 0x80B2;
        public const uint GL_MAX_COLOR_MATRIX_STACK_DEPTH = 0x80B3;
        public const uint GL_POST_COLOR_MATRIX_RED_SCALE = 0x80B4;
        public const uint GL_POST_COLOR_MATRIX_GREEN_SCALE = 0x80B5;
        public const uint GL_POST_COLOR_MATRIX_BLUE_SCALE = 0x80B6;
        public const uint GL_POST_COLOR_MATRIX_ALPHA_SCALE = 0x80B7;
        public const uint GL_POST_COLOR_MATRIX_RED_BIAS = 0x80B8;
        public const uint GL_POST_COLOR_MATRIX_GREEN_BIAS = 0x80B9;
        public const uint GL_POST_COLOR_MATRIX_BLUE_BIAS = 0x80BA;
        public const uint GL_POST_COLOR_MATRIX_ALPHA_BIAS = 0x80BB;

/* color_table */
        public const uint GL_COLOR_TABLE = 0x80D0;
        public const uint GL_POST_CONVOLUTION_COLOR_TABLE = 0x80D1;
        public const uint GL_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D2;
        public const uint GL_PROXY_COLOR_TABLE = 0x80D3;
        public const uint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE = 0x80D4;
        public const uint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D5;
        public const uint GL_COLOR_TABLE_SCALE = 0x80D6;
        public const uint GL_COLOR_TABLE_BIAS = 0x80D7;
        public const uint GL_COLOR_TABLE_FORMAT = 0x80D8;
        public const uint GL_COLOR_TABLE_WIDTH = 0x80D9;
        public const uint GL_COLOR_TABLE_RED_SIZE = 0x80DA;
        public const uint GL_COLOR_TABLE_GREEN_SIZE = 0x80DB;
        public const uint GL_COLOR_TABLE_BLUE_SIZE = 0x80DC;
        public const uint GL_COLOR_TABLE_ALPHA_SIZE = 0x80DD;
        public const uint GL_COLOR_TABLE_LUMINANCE_SIZE = 0x80DE;
        public const uint GL_COLOR_TABLE_INTENSITY_SIZE = 0x80DF;

/* convolution */
        public const uint GL_CONVOLUTION_1D = 0x8010;
        public const uint GL_CONVOLUTION_2D = 0x8011;
        public const uint GL_SEPARABLE_2D = 0x8012;
        public const uint GL_CONVOLUTION_BORDER_MODE = 0x8013;
        public const uint GL_CONVOLUTION_FILTER_SCALE = 0x8014;
        public const uint GL_CONVOLUTION_FILTER_BIAS = 0x8015;
        public const uint GL_REDUCE = 0x8016;
        public const uint GL_CONVOLUTION_FORMAT = 0x8017;
        public const uint GL_CONVOLUTION_WIDTH = 0x8018;
        public const uint GL_CONVOLUTION_HEIGHT = 0x8019;
        public const uint GL_MAX_CONVOLUTION_WIDTH = 0x801A;
        public const uint GL_MAX_CONVOLUTION_HEIGHT = 0x801B;
        public const uint GL_POST_CONVOLUTION_RED_SCALE = 0x801C;
        public const uint GL_POST_CONVOLUTION_GREEN_SCALE = 0x801D;
        public const uint GL_POST_CONVOLUTION_BLUE_SCALE = 0x801E;
        public const uint GL_POST_CONVOLUTION_ALPHA_SCALE = 0x801F;
        public const uint GL_POST_CONVOLUTION_RED_BIAS = 0x8020;
        public const uint GL_POST_CONVOLUTION_GREEN_BIAS = 0x8021;
        public const uint GL_POST_CONVOLUTION_BLUE_BIAS = 0x8022;
        public const uint GL_POST_CONVOLUTION_ALPHA_BIAS = 0x8023;
        public const uint GL_CONSTANT_BORDER = 0x8151;
        public const uint GL_REPLICATE_BORDER = 0x8153;
        public const uint GL_CONVOLUTION_BORDER_COLOR = 0x8154;

/* draw_range_elements */
        public const uint GL_MAX_ELEMENTS_VERTICES = 0x80E8;
        public const uint GL_MAX_ELEMENTS_INDICES = 0x80E9;

/* histogram */
        public const uint GL_HISTOGRAM = 0x8024;
        public const uint GL_PROXY_HISTOGRAM = 0x8025;
        public const uint GL_HISTOGRAM_WIDTH = 0x8026;
        public const uint GL_HISTOGRAM_FORMAT = 0x8027;
        public const uint GL_HISTOGRAM_RED_SIZE = 0x8028;
        public const uint GL_HISTOGRAM_GREEN_SIZE = 0x8029;
        public const uint GL_HISTOGRAM_BLUE_SIZE = 0x802A;
        public const uint GL_HISTOGRAM_ALPHA_SIZE = 0x802B;
        public const uint GL_HISTOGRAM_LUMINANCE_SIZE = 0x802C;
        public const uint GL_HISTOGRAM_SINK = 0x802D;
        public const uint GL_MINMAX = 0x802E;
        public const uint GL_MINMAX_FORMAT = 0x802F;
        public const uint GL_MINMAX_SINK = 0x8030;
        public const uint GL_TABLE_TOO_LARGE = 0x8031;

/* packed_pixels */
        public const uint GL_UNSIGNED_BYTE_3_3_2 = 0x8032;
        public const uint GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        public const uint GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        public const uint GL_UNSIGNED_INT_8_8_8_8 = 0x8035;
        public const uint GL_UNSIGNED_INT_10_10_10_2 = 0x8036;
        public const uint GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;
        public const uint GL_UNSIGNED_SHORT_5_6_5 = 0x8363;
        public const uint GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;
        public const uint GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
        public const uint GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
        public const uint GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;
        public const uint GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;

/* rescale_normal */
        public const uint GL_RESCALE_NORMAL = 0x803A;

/* separate_specular_color */
        public const uint GL_LIGHT_MODEL_COLOR_CONTROL = 0x81F8;
        public const uint GL_SINGLE_COLOR = 0x81F9;
        public const uint GL_SEPARATE_SPECULAR_COLOR = 0x81FA;

/* texture3D */
        public const uint GL_PACK_SKIP_IMAGES = 0x806B;
        public const uint GL_PACK_IMAGE_HEIGHT = 0x806C;
        public const uint GL_UNPACK_SKIP_IMAGES = 0x806D;
        public const uint GL_UNPACK_IMAGE_HEIGHT = 0x806E;
        public const uint GL_TEXTURE_3D = 0x806F;
        public const uint GL_PROXY_TEXTURE_3D = 0x8070;
        public const uint GL_TEXTURE_DEPTH = 0x8071;
        public const uint GL_TEXTURE_WRAP_R = 0x8072;
        public const uint GL_MAX_3D_TEXTURE_SIZE = 0x8073;

/* texture_edge_clamp */
        public const uint GL_CLAMP_TO_EDGE = 0x812F;
        public const uint GL_CLAMP_TO_BORDER = 0x812D;

/* texture_lod */
        public const uint GL_TEXTURE_MIN_LOD = 0x813A;
        public const uint GL_TEXTURE_MAX_LOD = 0x813B;
        public const uint GL_TEXTURE_BASE_LEVEL = 0x813C;
        public const uint GL_TEXTURE_MAX_LEVEL = 0x813D;

/* GetTarget1_2 */
        public const uint GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;
        public const uint GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
        public const uint GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
        public const uint GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
        public const uint GL_ALIASED_POINT_SIZE_RANGE = 0x846D;
        public const uint GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;

        public const uint GL_TEXTURE0 = 0x84C0;
        public const uint GL_TEXTURE1 = 0x84C1;
        public const uint GL_TEXTURE2 = 0x84C2;
        public const uint GL_TEXTURE3 = 0x84C3;
        public const uint GL_TEXTURE4 = 0x84C4;
        public const uint GL_TEXTURE5 = 0x84C5;
        public const uint GL_TEXTURE6 = 0x84C6;
        public const uint GL_TEXTURE7 = 0x84C7;
        public const uint GL_TEXTURE8 = 0x84C8;
        public const uint GL_TEXTURE9 = 0x84C9;
        public const uint GL_TEXTURE10 = 0x84CA;
        public const uint GL_TEXTURE11 = 0x84CB;
        public const uint GL_TEXTURE12 = 0x84CC;
        public const uint GL_TEXTURE13 = 0x84CD;
        public const uint GL_TEXTURE14 = 0x84CE;
        public const uint GL_TEXTURE15 = 0x84CF;
        public const uint GL_TEXTURE16 = 0x84D0;
        public const uint GL_TEXTURE17 = 0x84D1;
        public const uint GL_TEXTURE18 = 0x84D2;
        public const uint GL_TEXTURE19 = 0x84D3;
        public const uint GL_TEXTURE20 = 0x84D4;
        public const uint GL_TEXTURE21 = 0x84D5;
        public const uint GL_TEXTURE22 = 0x84D6;
        public const uint GL_TEXTURE23 = 0x84D7;
        public const uint GL_TEXTURE24 = 0x84D8;
        public const uint GL_TEXTURE25 = 0x84D9;
        public const uint GL_TEXTURE26 = 0x84DA;
        public const uint GL_TEXTURE27 = 0x84DB;
        public const uint GL_TEXTURE28 = 0x84DC;
        public const uint GL_TEXTURE29 = 0x84DD;
        public const uint GL_TEXTURE30 = 0x84DE;
        public const uint GL_TEXTURE31 = 0x84DF;
        public const uint GL_ACTIVE_TEXTURE = 0x84E0;
        public const uint GL_CLIENT_ACTIVE_TEXTURE = 0x84E1;
        public const uint GL_MAX_TEXTURE_UNITS = 0x84E2;

        public const uint GL_COMBINE = 0x8570;
        public const uint GL_COMBINE_RGB = 0x8571;
        public const uint GL_COMBINE_ALPHA = 0x8572;
        public const uint GL_RGB_SCALE = 0x8573;
        public const uint GL_ADD_SIGNED = 0x8574;
        public const uint GL_INTERPOLATE = 0x8575;
        public const uint GL_CONSTANT = 0x8576;
        public const uint GL_PRIMARY_COLOR = 0x8577;
        public const uint GL_PREVIOUS = 0x8578;
        public const uint GL_SUBTRACT = 0x84E7;

        public const uint GL_SRC0_RGB = 0x8580;
        public const uint GL_SRC1_RGB = 0x8581;
        public const uint GL_SRC2_RGB = 0x8582;
        public const uint GL_SRC3_RGB = 0x8583;
        public const uint GL_SRC4_RGB = 0x8584;
        public const uint GL_SRC5_RGB = 0x8585;
        public const uint GL_SRC6_RGB = 0x8586;
        public const uint GL_SRC7_RGB = 0x8587;
        public const uint GL_SRC0_ALPHA = 0x8588;
        public const uint GL_SRC1_ALPHA = 0x8589;
        public const uint GL_SRC2_ALPHA = 0x858A;
        public const uint GL_SRC3_ALPHA = 0x858B;
        public const uint GL_SRC4_ALPHA = 0x858C;
        public const uint GL_SRC5_ALPHA = 0x858D;
        public const uint GL_SRC6_ALPHA = 0x858E;
        public const uint GL_SRC7_ALPHA = 0x858F;

/* Obsolete */
        public const uint GL_SOURCE0_RGB = 0x8580;
        public const uint GL_SOURCE1_RGB = 0x8581;
        public const uint GL_SOURCE2_RGB = 0x8582;
        public const uint GL_SOURCE3_RGB = 0x8583;
        public const uint GL_SOURCE4_RGB = 0x8584;
        public const uint GL_SOURCE5_RGB = 0x8585;
        public const uint GL_SOURCE6_RGB = 0x8586;
        public const uint GL_SOURCE7_RGB = 0x8587;
        public const uint GL_SOURCE0_ALPHA = 0x8588;
        public const uint GL_SOURCE1_ALPHA = 0x8589;
        public const uint GL_SOURCE2_ALPHA = 0x858A;
        public const uint GL_SOURCE3_ALPHA = 0x858B;
        public const uint GL_SOURCE4_ALPHA = 0x858C;
        public const uint GL_SOURCE5_ALPHA = 0x858D;
        public const uint GL_SOURCE6_ALPHA = 0x858E;
        public const uint GL_SOURCE7_ALPHA = 0x858F;

        public const uint GL_OPERAND0_RGB = 0x8590;
        public const uint GL_OPERAND1_RGB = 0x8591;
        public const uint GL_OPERAND2_RGB = 0x8592;
        public const uint GL_OPERAND3_RGB = 0x8593;
        public const uint GL_OPERAND4_RGB = 0x8594;
        public const uint GL_OPERAND5_RGB = 0x8595;
        public const uint GL_OPERAND6_RGB = 0x8596;
        public const uint GL_OPERAND7_RGB = 0x8597;
        public const uint GL_OPERAND0_ALPHA = 0x8598;
        public const uint GL_OPERAND1_ALPHA = 0x8599;
        public const uint GL_OPERAND2_ALPHA = 0x859A;
        public const uint GL_OPERAND3_ALPHA = 0x859B;
        public const uint GL_OPERAND4_ALPHA = 0x859C;
        public const uint GL_OPERAND5_ALPHA = 0x859D;
        public const uint GL_OPERAND6_ALPHA = 0x859E;
        public const uint GL_OPERAND7_ALPHA = 0x859F;

        public const uint GL_DOT3_RGB = 0x86AE;
        public const uint GL_DOT3_RGBA = 0x86AF;

        public const uint GL_TRANSPOSE_MODELVIEW_MATRIX = 0x84E3;
        public const uint GL_TRANSPOSE_PROJECTION_MATRIX = 0x84E4;
        public const uint GL_TRANSPOSE_TEXTURE_MATRIX = 0x84E5;
        public const uint GL_TRANSPOSE_COLOR_MATRIX = 0x84E6;

        public const uint GL_NORMAL_MAP = 0x8511;
        public const uint GL_REFLECTION_MAP = 0x8512;
        public const uint GL_TEXTURE_CUBE_MAP = 0x8513;
        public const uint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        public const uint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;
        public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;

        public const uint GL_COMPRESSED_ALPHA = 0x84E9;
        public const uint GL_COMPRESSED_LUMINANCE = 0x84EA;
        public const uint GL_COMPRESSED_LUMINANCE_ALPHA = 0x84EB;
        public const uint GL_COMPRESSED_INTENSITY = 0x84EC;
        public const uint GL_COMPRESSED_RGB = 0x84ED;
        public const uint GL_COMPRESSED_RGBA = 0x84EE;
        public const uint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;
        public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
        public const uint GL_TEXTURE_COMPRESSED = 0x86A1;
        public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
        public const uint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;

        public const uint GL_MULTISAMPLE = 0x809D;
        public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        public const uint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;
        public const uint GL_SAMPLE_COVERAGE = 0x80A0;
        public const uint GL_SAMPLE_BUFFERS = 0x80A8;
        public const uint GL_SAMPLES = 0x80A9;
        public const uint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;
        public const uint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;
        public const uint GL_MULTISAMPLE_BIT = 0x20000000;

        public const uint GL_DEPTH_COMPONENT16 = 0x81A5;
        public const uint GL_DEPTH_COMPONENT24 = 0x81A6;
        public const uint GL_DEPTH_COMPONENT32 = 0x81A7;
        public const uint GL_TEXTURE_DEPTH_SIZE = 0x884A;
        public const uint GL_DEPTH_TEXTURE_MODE = 0x884B;

        public const uint GL_TEXTURE_COMPARE_MODE = 0x884C;
        public const uint GL_TEXTURE_COMPARE_FUNC = 0x884D;
        public const uint GL_COMPARE_R_TO_TEXTURE = 0x884E;

/* occlusion_query */
        public const uint GL_QUERY_COUNTER_BITS = 0x8864;
        public const uint GL_CURRENT_QUERY = 0x8865;
        public const uint GL_QUERY_RESULT = 0x8866;
        public const uint GL_QUERY_RESULT_AVAILABLE = 0x8867;
        public const uint GL_SAMPLES_PASSED = 0x8914;

        public const uint GL_FOG_COORD_SRC = 0x8450;
        public const uint GL_FOG_COORD = 0x8451;
        public const uint GL_FRAGMENT_DEPTH = 0x8452;
        public const uint GL_CURRENT_FOG_COORD = 0x8453;
        public const uint GL_FOG_COORD_ARRAY_TYPE = 0x8454;
        public const uint GL_FOG_COORD_ARRAY_STRIDE = 0x8455;
        public const uint GL_FOG_COORD_ARRAY_POINTER = 0x8456;
        public const uint GL_FOG_COORD_ARRAY = 0x8457;

/* Obsolete */
        public const uint GL_FOG_COORDINATE_SOURCE = 0x8450;
        public const uint GL_FOG_COORDINATE = 0x8451;
        public const uint GL_CURRENT_FOG_COORDINATE = 0x8453;
        public const uint GL_FOG_COORDINATE_ARRAY_TYPE = 0x8454;
        public const uint GL_FOG_COORDINATE_ARRAY_STRIDE = 0x8455;
        public const uint GL_FOG_COORDINATE_ARRAY_POINTER = 0x8456;
        public const uint GL_FOG_COORDINATE_ARRAY = 0x8457;

        public const uint GL_COLOR_SUM = 0x8458;
        public const uint GL_CURRENT_SECONDARY_COLOR = 0x8459;
        public const uint GL_SECONDARY_COLOR_ARRAY_SIZE = 0x845A;
        public const uint GL_SECONDARY_COLOR_ARRAY_TYPE = 0x845B;
        public const uint GL_SECONDARY_COLOR_ARRAY_STRIDE = 0x845C;
        public const uint GL_SECONDARY_COLOR_ARRAY_POINTER = 0x845D;
        public const uint GL_SECONDARY_COLOR_ARRAY = 0x845E;

        public const uint GL_POINT_SIZE_MIN = 0x8126;
        public const uint GL_POINT_SIZE_MAX = 0x8127;
        public const uint GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
        public const uint GL_POINT_DISTANCE_ATTENUATION = 0x8129;

        public const uint GL_BLEND_DST_RGB = 0x80C8;
        public const uint GL_BLEND_SRC_RGB = 0x80C9;
        public const uint GL_BLEND_DST_ALPHA = 0x80CA;
        public const uint GL_BLEND_SRC_ALPHA = 0x80CB;

        public const uint GL_GENERATE_MIPMAP = 0x8191;
        public const uint GL_GENERATE_MIPMAP_HINT = 0x8192;

        public const uint GL_INCR_WRAP = 0x8507;
        public const uint GL_DECR_WRAP = 0x8508;

        public const uint GL_MIRRORED_REPEAT = 0x8370;

        public const uint GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
        public const uint GL_TEXTURE_FILTER_CONTROL = 0x8500;
        public const uint GL_TEXTURE_LOD_BIAS = 0x8501;

/* vertex_buffer_object */
        public const uint GL_ARRAY_BUFFER = 0x8892;
        public const uint GL_ELEMENT_ARRAY_BUFFER = 0x8893;
        public const uint GL_ARRAY_BUFFER_BINDING = 0x8894;
        public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
        public const uint GL_VERTEX_ARRAY_BUFFER_BINDING = 0x8896;
        public const uint GL_NORMAL_ARRAY_BUFFER_BINDING = 0x8897;
        public const uint GL_COLOR_ARRAY_BUFFER_BINDING = 0x8898;
        public const uint GL_INDEX_ARRAY_BUFFER_BINDING = 0x8899;
        public const uint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING = 0x889A;
        public const uint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING = 0x889B;
        public const uint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING = 0x889C;
        public const uint GL_FOG_COORD_ARRAY_BUFFER_BINDING = 0x889D;
        public const uint GL_WEIGHT_ARRAY_BUFFER_BINDING = 0x889E;
        public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
        public const uint GL_STREAM_DRAW = 0x88E0;
        public const uint GL_STREAM_READ = 0x88E1;
        public const uint GL_STREAM_COPY = 0x88E2;
        public const uint GL_STATIC_DRAW = 0x88E4;
        public const uint GL_STATIC_READ = 0x88E5;
        public const uint GL_STATIC_COPY = 0x88E6;
        public const uint GL_DYNAMIC_DRAW = 0x88E8;
        public const uint GL_DYNAMIC_READ = 0x88E9;
        public const uint GL_DYNAMIC_COPY = 0x88EA;
        public const uint GL_READ_ONLY = 0x88B8;
        public const uint GL_WRITE_ONLY = 0x88B9;
        public const uint GL_READ_WRITE = 0x88BA;
        public const uint GL_BUFFER_SIZE = 0x8764;
        public const uint GL_BUFFER_USAGE = 0x8765;
        public const uint GL_BUFFER_ACCESS = 0x88BB;
        public const uint GL_BUFFER_MAPPED = 0x88BC;
        public const uint GL_BUFFER_MAP_POINTER = 0x88BD;
/* Obsolete */
        public const uint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING = 0x889D;

/* OpenGL 2.0 */
        public const uint GL_CURRENT_PROGRAM = 0x8B8D;
        public const uint GL_SHADER_TYPE = 0x8B4F;
        public const uint GL_DELETE_STATUS = 0x8B80;
        public const uint GL_COMPILE_STATUS = 0x8B81;
        public const uint GL_LINK_STATUS = 0x8B82;
        public const uint GL_VALIDATE_STATUS = 0x8B83;
        public const uint GL_INFO_LOG_LENGTH = 0x8B84;
        public const uint GL_ATTACHED_SHADERS = 0x8B85;
        public const uint GL_ACTIVE_UNIFORMS = 0x8B86;
        public const uint GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        public const uint GL_SHADER_SOURCE_LENGTH = 0x8B88;
        public const uint GL_FLOAT_VEC2 = 0x8B50;
        public const uint GL_FLOAT_VEC3 = 0x8B51;
        public const uint GL_FLOAT_VEC4 = 0x8B52;
        public const uint GL_INT_VEC2 = 0x8B53;
        public const uint GL_INT_VEC3 = 0x8B54;
        public const uint GL_INT_VEC4 = 0x8B55;
        public const uint GL_BOOL = 0x8B56;
        public const uint GL_BOOL_VEC2 = 0x8B57;
        public const uint GL_BOOL_VEC3 = 0x8B58;
        public const uint GL_BOOL_VEC4 = 0x8B59;
        public const uint GL_FLOAT_MAT2 = 0x8B5A;
        public const uint GL_FLOAT_MAT3 = 0x8B5B;
        public const uint GL_FLOAT_MAT4 = 0x8B5C;
        public const uint GL_SAMPLER_1D = 0x8B5D;
        public const uint GL_SAMPLER_2D = 0x8B5E;
        public const uint GL_SAMPLER_3D = 0x8B5F;
        public const uint GL_SAMPLER_CUBE = 0x8B60;
        public const uint GL_SAMPLER_1D_SHADOW = 0x8B61;
        public const uint GL_SAMPLER_2D_SHADOW = 0x8B62;
        public const uint GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
        public const uint GL_VERTEX_SHADER = 0x8B31;
        public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        public const uint GL_MAX_VARYING_FLOATS = 0x8B4B;
        public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        public const uint GL_ACTIVE_ATTRIBUTES = 0x8B89;
        public const uint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        public const uint GL_FRAGMENT_SHADER = 0x8B30;
        public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        public const uint GL_MAX_VERTEX_ATTRIBS = 0x8869;
        public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        public const uint GL_CURRENT_VERTEX_ATTRIB = 0x8626;
        public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        public const uint GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;
        public const uint GL_VERTEX_PROGRAM_TWO_SIDE = 0x8643;
        public const uint GL_MAX_TEXTURE_COORDS = 0x8871;
        public const uint GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        public const uint GL_MAX_DRAW_BUFFERS = 0x8824;
        public const uint GL_DRAW_BUFFER0 = 0x8825;
        public const uint GL_DRAW_BUFFER1 = 0x8826;
        public const uint GL_DRAW_BUFFER2 = 0x8827;
        public const uint GL_DRAW_BUFFER3 = 0x8828;
        public const uint GL_DRAW_BUFFER4 = 0x8829;
        public const uint GL_DRAW_BUFFER5 = 0x882A;
        public const uint GL_DRAW_BUFFER6 = 0x882B;
        public const uint GL_DRAW_BUFFER7 = 0x882C;
        public const uint GL_DRAW_BUFFER8 = 0x882D;
        public const uint GL_DRAW_BUFFER9 = 0x882E;
        public const uint GL_DRAW_BUFFER10 = 0x882F;
        public const uint GL_DRAW_BUFFER11 = 0x8830;
        public const uint GL_DRAW_BUFFER12 = 0x8831;
        public const uint GL_DRAW_BUFFER13 = 0x8832;
        public const uint GL_DRAW_BUFFER14 = 0x8833;
        public const uint GL_DRAW_BUFFER15 = 0x8834;
        public const uint GL_POINT_SPRITE = 0x8861;
        public const uint GL_COORD_REPLACE = 0x8862;
        public const uint GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
        public const uint GL_LOWER_LEFT = 0x8CA1;
        public const uint GL_UPPER_LEFT = 0x8CA2;
        public const uint GL_STENCIL_BACK_FUNC = 0x8800;
        public const uint GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;
        public const uint GL_STENCIL_BACK_REF = 0x8CA3;
        public const uint GL_STENCIL_BACK_FAIL = 0x8801;
        public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        public const uint GL_STENCIL_BACK_WRITEMASK = 0x8CA5;

/* OpenGL 2.1 */
        public const uint GL_CURRENT_RASTER_SECONDARY_COLOR = 0x845F;
        public const uint GL_PIXEL_PACK_BUFFER = 0x88EB;
        public const uint GL_PIXEL_UNPACK_BUFFER = 0x88EC;
        public const uint GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED;
        public const uint GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
        public const uint GL_FLOAT_MAT2x3 = 0x8B65;
        public const uint GL_FLOAT_MAT2x4 = 0x8B66;
        public const uint GL_FLOAT_MAT3x2 = 0x8B67;
        public const uint GL_FLOAT_MAT3x4 = 0x8B68;
        public const uint GL_FLOAT_MAT4x2 = 0x8B69;
        public const uint GL_FLOAT_MAT4x3 = 0x8B6A;
        public const uint GL_SRGB = 0x8C40;
        public const uint GL_SRGB8 = 0x8C41;
        public const uint GL_SRGB_ALPHA = 0x8C42;
        public const uint GL_SRGB8_ALPHA8 = 0x8C43;
        public const uint GL_SLUMINANCE_ALPHA = 0x8C44;
        public const uint GL_SLUMINANCE8_ALPHA8 = 0x8C45;
        public const uint GL_SLUMINANCE = 0x8C46;
        public const uint GL_SLUMINANCE8 = 0x8C47;
        public const uint GL_COMPRESSED_SRGB = 0x8C48;
        public const uint GL_COMPRESSED_SRGB_ALPHA = 0x8C49;
        public const uint GL_COMPRESSED_SLUMINANCE = 0x8C4A;
        public const uint GL_COMPRESSED_SLUMINANCE_ALPHA = 0x8C4B;
    }
}