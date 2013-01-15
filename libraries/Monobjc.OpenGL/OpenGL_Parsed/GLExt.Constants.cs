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
#define GL_ARB_imaging
#define GL_ARB_transpose_matrix
#define GL_ARB_multitexture
#define GL_ARB_texture_env_add
#define GL_ARB_texture_env_combine
#define GL_ARB_texture_env_dot3
#define GL_ARB_texture_env_crossbar
#define GL_ARB_texture_cube_map
#define GL_ARB_texture_compression
#define GL_ARB_multisample
#define GL_ARB_texture_border_clamp
#define GL_ARB_point_parameters
#define GL_ARB_vertex_program
#define GL_ARB_fragment_program
#define GL_ARB_fragment_program_shadow
#define GL_ARB_texture_mirrored_repeat
#define GL_ARB_depth_texture
#define GL_ARB_shadow
#define GL_ARB_shadow_ambient
#define GL_ARB_vertex_blend
#define GL_ARB_window_pos
#define GL_ARB_occlusion_query
#define GL_ARB_shader_objects
#define GL_ARB_vertex_shader
#define GL_ARB_fragment_shader
#define GL_ARB_shading_language_100
#define GL_ARB_vertex_buffer_object
#define GL_ARB_point_sprite
#define GL_ARB_texture_non_power_of_two
#define GL_ARB_texture_rectangle
#define GL_ARB_draw_buffers
#define GL_ARB_pixel_buffer_object
#define GL_ARB_shader_texture_lod
#define GL_ARB_texture_float
#define GL_ARB_half_float_pixel
#define GL_ARB_color_buffer_float
#define GL_ARB_half_float_vertex
#define GL_ARB_texture_compression_rgtc
#define GL_ARB_texture_rg
#define GL_ARB_uniform_buffer_object
#define GL_ARB_framebuffer_object
#define GL_ARB_instanced_arrays
#define GL_ARB_depth_buffer_float
//#define GL_EXT_draw_instanced               
#define GL_EXT_clip_volume_hint
#define GL_EXT_rescale_normal
#define GL_EXT_blend_color
#define GL_EXT_blend_minmax
#define GL_EXT_blend_subtract
#define GL_EXT_compiled_vertex_array
#define GL_EXT_texture_array
#define GL_EXT_texture_lod_bias
#define GL_EXT_texture_env_add
#define GL_EXT_abgr
#define GL_EXT_bgra
#define GL_EXT_texture_filter_anisotropic
#define GL_EXT_secondary_color
#define GL_EXT_separate_specular_color
#define GL_EXT_texture_compression_s3tc
#define GL_EXT_texture_rectangle
#define GL_EXT_fog_coord
#define GL_EXT_draw_range_elements
#define GL_EXT_stencil_wrap
#define GL_EXT_blend_func_separate
#define GL_EXT_multi_draw_arrays
#define GL_EXT_shadow_funcs
#define GL_EXT_stencil_two_side
#define GL_EXT_depth_bounds_test
#define GL_EXT_blend_equation_separate
#define GL_EXT_texture_mirror_clamp
#define GL_EXT_texture_compression_dxt1
#define GL_EXT_texture_sRGB
#define GL_EXT_framebuffer_object
#define GL_EXT_framebuffer_blit
#define GL_EXT_framebuffer_multisample
#define GL_EXT_packed_depth_stencil
#define GL_EXT_gpu_program_parameters
#define GL_EXT_geometry_shader4
#define GL_EXT_transform_feedback
#define GL_EXT_bindable_uniform
#define GL_EXT_texture_integer
#define GL_EXT_gpu_shader4
#define GL_EXT_draw_buffers2
#define GL_EXT_framebuffer_sRGB
#define GL_EXT_packed_float
#define GL_EXT_texture_shared_exponent
#define GL_EXT_provoking_vertex
#define GL_EXT_vertex_array_bgra
#define GL_APPLE_flush_buffer_range
#define GL_APPLE_specular_vector
#define GL_APPLE_transform_hint
#define GL_APPLE_packed_pixels
#define GL_APPLE_client_storage
#define GL_APPLE_ycbcr_422
#define GL_APPLE_texture_range
#define GL_APPLE_fence
#define GL_APPLE_vertex_array_range
#define GL_APPLE_vertex_array_object
#define GL_APPLE_element_array
#define GL_APPLE_vertex_program_evaluators
#define GL_APPLE_float_pixels
#define GL_APPLE_flush_render
#define GL_APPLE_pixel_buffer
#define GL_APPLE_aux_depth_stencil
#define GL_APPLE_row_bytes
#define GL_APPLE_object_purgeable
#define GL_APPLE_rgb_422
#define GL_ATI_point_cull_mode
#define GL_ATI_texture_mirror_once
#define GL_ATI_pn_triangles
#define GL_ATI_blend_equation_separate
#define GL_ATI_blend_weighted_minmax
#define GL_ATI_texture_env_combine3
#define GL_ATI_separate_stencil
#define GL_ATI_texture_compression_3dc
#define GL_ATI_texture_float
#define GL_ATIX_pn_triangles
#define GL_IBM_rasterpos_clip
#define GL_NV_point_sprite
#define GL_NV_blend_square
#define GL_NV_fog_distance
#define GL_NV_multisample_filter_hint
#define GL_NV_texgen_reflection
#define GL_NV_depth_clamp
#define GL_NV_light_max_exponent
#define GL_NV_fragment_program_option
#define GL_NV_fragment_program2
#define GL_NV_vertex_program2_option
#define GL_NV_vertex_program3
#define GL_NV_conditional_render
#define GL_SGI_color_matrix
#define GL_SGIS_texture_edge_clamp
#define GL_SGIS_generate_mipmap
#define GL_SGIS_texture_lod

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
//using GLvoid=System.Void;
//typedef long GLintptr;
using GLintptr = System.IntPtr;
//typedef long GLsizeiptr;
using GLsizeiptr = System.IntPtr;
//typedef char GLchar;
using GLchar = System.SByte;
#if GL_ARB_shader_objects
//typedef char GLcharARB;
using GLcharARB = System.SByte;
//typedef void *GLhandleARB;
using GLhandleARB = System.IntPtr;
#endif
#if GL_ARB_vertex_buffer_object
//typedef long GLintptrARB;
using GLintptrARB = System.IntPtr;
//typedef long GLsizeiptrARB;
using GLsizeiptrARB = System.IntPtr;
#endif
#if GL_ARB_half_float_pixel
//typedef unsigned short GLhalfARB;
using GLhalfARB = System.UInt16;
#endif
#if GL_ARB_half_float_vertex
//typedef unsigned short GLhalf;
using GLhalf = System.UInt16;
#endif

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
        public const uint GL_GLEXT_VERSION = 7;

#if GL_ARB_multitexture
        public const uint GL_TEXTURE0_ARB = 0x84C0;
        public const uint GL_TEXTURE1_ARB = 0x84C1;
        public const uint GL_TEXTURE2_ARB = 0x84C2;
        public const uint GL_TEXTURE3_ARB = 0x84C3;
        public const uint GL_TEXTURE4_ARB = 0x84C4;
        public const uint GL_TEXTURE5_ARB = 0x84C5;
        public const uint GL_TEXTURE6_ARB = 0x84C6;
        public const uint GL_TEXTURE7_ARB = 0x84C7;
        public const uint GL_TEXTURE8_ARB = 0x84C8;
        public const uint GL_TEXTURE9_ARB = 0x84C9;
        public const uint GL_TEXTURE10_ARB = 0x84CA;
        public const uint GL_TEXTURE11_ARB = 0x84CB;
        public const uint GL_TEXTURE12_ARB = 0x84CC;
        public const uint GL_TEXTURE13_ARB = 0x84CD;
        public const uint GL_TEXTURE14_ARB = 0x84CE;
        public const uint GL_TEXTURE15_ARB = 0x84CF;
        public const uint GL_TEXTURE16_ARB = 0x84D0;
        public const uint GL_TEXTURE17_ARB = 0x84D1;
        public const uint GL_TEXTURE18_ARB = 0x84D2;
        public const uint GL_TEXTURE19_ARB = 0x84D3;
        public const uint GL_TEXTURE20_ARB = 0x84D4;
        public const uint GL_TEXTURE21_ARB = 0x84D5;
        public const uint GL_TEXTURE22_ARB = 0x84D6;
        public const uint GL_TEXTURE23_ARB = 0x84D7;
        public const uint GL_TEXTURE24_ARB = 0x84D8;
        public const uint GL_TEXTURE25_ARB = 0x84D9;
        public const uint GL_TEXTURE26_ARB = 0x84DA;
        public const uint GL_TEXTURE27_ARB = 0x84DB;
        public const uint GL_TEXTURE28_ARB = 0x84DC;
        public const uint GL_TEXTURE29_ARB = 0x84DD;
        public const uint GL_TEXTURE30_ARB = 0x84DE;
        public const uint GL_TEXTURE31_ARB = 0x84DF;
        public const uint GL_ACTIVE_TEXTURE_ARB = 0x84E0;
        public const uint GL_CLIENT_ACTIVE_TEXTURE_ARB = 0x84E1;
        public const uint GL_MAX_TEXTURE_UNITS_ARB = 0x84E2;
#endif

#if GL_ARB_transpose_matrix
        public const uint GL_TRANSPOSE_MODELVIEW_MATRIX_ARB = 0x84E3;
        public const uint GL_TRANSPOSE_PROJECTION_MATRIX_ARB = 0x84E4;
        public const uint GL_TRANSPOSE_TEXTURE_MATRIX_ARB = 0x84E5;
        public const uint GL_TRANSPOSE_COLOR_MATRIX_ARB = 0x84E6;
#endif

#if GL_ARB_multisample
        public const uint GL_MULTISAMPLE_ARB = 0x809D;
        public const uint GL_SAMPLE_ALPHA_TO_COVERAGE_ARB = 0x809E;
        public const uint GL_SAMPLE_ALPHA_TO_ONE_ARB = 0x809F;
        public const uint GL_SAMPLE_COVERAGE_ARB = 0x80A0;
        public const uint GL_SAMPLE_BUFFERS_ARB = 0x80A8;
        public const uint GL_SAMPLES_ARB = 0x80A9;
        public const uint GL_SAMPLE_COVERAGE_VALUE_ARB = 0x80AA;
        public const uint GL_SAMPLE_COVERAGE_INVERT_ARB = 0x80AB;
        public const uint GL_MULTISAMPLE_BIT_ARB = 0x20000000;
#endif

#if GL_ARB_texture_cube_map
        public const uint GL_NORMAL_MAP_ARB = 0x8511;
        public const uint GL_REFLECTION_MAP_ARB = 0x8512;
        public const uint GL_TEXTURE_CUBE_MAP_ARB = 0x8513;
        public const uint GL_TEXTURE_BINDING_CUBE_MAP_ARB = 0x8514;
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 0x8515;
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 0x8516;
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 0x8517;
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 0x8518;
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 0x8519;
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 0x851A;
        public const uint GL_PROXY_TEXTURE_CUBE_MAP_ARB = 0x851B;
        public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE_ARB = 0x851C;
#endif

#if GL_ARB_texture_compression
        public const uint GL_COMPRESSED_ALPHA_ARB = 0x84E9;
        public const uint GL_COMPRESSED_LUMINANCE_ARB = 0x84EA;
        public const uint GL_COMPRESSED_LUMINANCE_ALPHA_ARB = 0x84EB;
        public const uint GL_COMPRESSED_INTENSITY_ARB = 0x84EC;
        public const uint GL_COMPRESSED_RGB_ARB = 0x84ED;
        public const uint GL_COMPRESSED_RGBA_ARB = 0x84EE;
        public const uint GL_TEXTURE_COMPRESSION_HINT_ARB = 0x84EF;
        public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = 0x86A0;
        public const uint GL_TEXTURE_COMPRESSED_ARB = 0x86A1;
        public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A2;
        public const uint GL_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A3;
#endif

#if GL_ARB_vertex_blend
        public const uint GL_MAX_VERTEX_UNITS_ARB = 0x86A4;
        public const uint GL_ACTIVE_VERTEX_UNITS_ARB = 0x86A5;
        public const uint GL_WEIGHT_SUM_UNITY_ARB = 0x86A6;
        public const uint GL_VERTEX_BLEND_ARB = 0x86A7;
        public const uint GL_CURRENT_WEIGHT_ARB = 0x86A8;
        public const uint GL_WEIGHT_ARRAY_TYPE_ARB = 0x86A9;
        public const uint GL_WEIGHT_ARRAY_STRIDE_ARB = 0x86AA;
        public const uint GL_WEIGHT_ARRAY_SIZE_ARB = 0x86AB;
        public const uint GL_WEIGHT_ARRAY_POINTER_ARB = 0x86AC;
        public const uint GL_WEIGHT_ARRAY_ARB = 0x86AD;
        public const uint GL_MODELVIEW0_ARB = 0x1700;
        public const uint GL_MODELVIEW1_ARB = 0x850A;
        public const uint GL_MODELVIEW2_ARB = 0x8722;
        public const uint GL_MODELVIEW3_ARB = 0x8723;
        public const uint GL_MODELVIEW4_ARB = 0x8724;
        public const uint GL_MODELVIEW5_ARB = 0x8725;
        public const uint GL_MODELVIEW6_ARB = 0x8726;
        public const uint GL_MODELVIEW7_ARB = 0x8727;
        public const uint GL_MODELVIEW8_ARB = 0x8728;
        public const uint GL_MODELVIEW9_ARB = 0x8729;
        public const uint GL_MODELVIEW10_ARB = 0x872A;
        public const uint GL_MODELVIEW11_ARB = 0x872B;
        public const uint GL_MODELVIEW12_ARB = 0x872C;
        public const uint GL_MODELVIEW13_ARB = 0x872D;
        public const uint GL_MODELVIEW14_ARB = 0x872E;
        public const uint GL_MODELVIEW15_ARB = 0x872F;
        public const uint GL_MODELVIEW16_ARB = 0x8730;
        public const uint GL_MODELVIEW17_ARB = 0x8731;
        public const uint GL_MODELVIEW18_ARB = 0x8732;
        public const uint GL_MODELVIEW19_ARB = 0x8733;
        public const uint GL_MODELVIEW20_ARB = 0x8734;
        public const uint GL_MODELVIEW21_ARB = 0x8735;
        public const uint GL_MODELVIEW22_ARB = 0x8736;
        public const uint GL_MODELVIEW23_ARB = 0x8737;
        public const uint GL_MODELVIEW24_ARB = 0x8738;
        public const uint GL_MODELVIEW25_ARB = 0x8739;
        public const uint GL_MODELVIEW26_ARB = 0x873A;
        public const uint GL_MODELVIEW27_ARB = 0x873B;
        public const uint GL_MODELVIEW28_ARB = 0x873C;
        public const uint GL_MODELVIEW29_ARB = 0x873D;
        public const uint GL_MODELVIEW30_ARB = 0x873E;
        public const uint GL_MODELVIEW31_ARB = 0x873F;
#endif

#if GL_ARB_occlusion_query
        public const uint GL_SAMPLES_PASSED_ARB = 0x8914;
        public const uint GL_QUERY_COUNTER_BITS_ARB = 0x8864;
        public const uint GL_CURRENT_QUERY_ARB = 0x8865;
        public const uint GL_QUERY_RESULT_ARB = 0x8866;
        public const uint GL_QUERY_RESULT_AVAILABLE_ARB = 0x8867;
#endif

#if GL_ARB_texture_border_clamp
        public const uint GL_CLAMP_TO_BORDER_ARB = 0x812D;
#endif

#if GL_ARB_depth_texture
        public const uint GL_DEPTH_COMPONENT16_ARB = 0x81A5;
        public const uint GL_DEPTH_COMPONENT24_ARB = 0x81A6;
        public const uint GL_DEPTH_COMPONENT32_ARB = 0x81A7;
        public const uint GL_TEXTURE_DEPTH_SIZE_ARB = 0x884A;
        public const uint GL_DEPTH_TEXTURE_MODE_ARB = 0x884B;
#endif

#if GL_ARB_shadow
        public const uint GL_TEXTURE_COMPARE_MODE_ARB = 0x884C;
        public const uint GL_TEXTURE_COMPARE_FUNC_ARB = 0x884D;
        public const uint GL_COMPARE_R_TO_TEXTURE_ARB = 0x884E;
#endif

#if GL_ARB_shadow_ambient
        public const uint GL_TEXTURE_COMPARE_FAIL_VALUE_ARB = 0x80BF;
#endif

#if GL_ARB_texture_env_combine
        public const uint GL_COMBINE_ARB = 0x8570;
        public const uint GL_COMBINE_RGB_ARB = 0x8571;
        public const uint GL_COMBINE_ALPHA_ARB = 0x8572;
        public const uint GL_RGB_SCALE_ARB = 0x8573;
        public const uint GL_ADD_SIGNED_ARB = 0x8574;
        public const uint GL_INTERPOLATE_ARB = 0x8575;
        public const uint GL_CONSTANT_ARB = 0x8576;
        public const uint GL_PRIMARY_COLOR_ARB = 0x8577;
        public const uint GL_PREVIOUS_ARB = 0x8578;
        public const uint GL_SUBTRACT_ARB = 0x84E7;
        public const uint GL_SOURCE0_RGB_ARB = 0x8580;
        public const uint GL_SOURCE1_RGB_ARB = 0x8581;
        public const uint GL_SOURCE2_RGB_ARB = 0x8582;
        public const uint GL_SOURCE3_RGB_ARB = 0x8583;
        public const uint GL_SOURCE4_RGB_ARB = 0x8584;
        public const uint GL_SOURCE5_RGB_ARB = 0x8585;
        public const uint GL_SOURCE6_RGB_ARB = 0x8586;
        public const uint GL_SOURCE7_RGB_ARB = 0x8587;
        public const uint GL_SOURCE0_ALPHA_ARB = 0x8588;
        public const uint GL_SOURCE1_ALPHA_ARB = 0x8589;
        public const uint GL_SOURCE2_ALPHA_ARB = 0x858A;
        public const uint GL_SOURCE3_ALPHA_ARB = 0x858B;
        public const uint GL_SOURCE4_ALPHA_ARB = 0x858C;
        public const uint GL_SOURCE5_ALPHA_ARB = 0x858D;
        public const uint GL_SOURCE6_ALPHA_ARB = 0x858E;
        public const uint GL_SOURCE7_ALPHA_ARB = 0x858F;
        public const uint GL_OPERAND0_RGB_ARB = 0x8590;
        public const uint GL_OPERAND1_RGB_ARB = 0x8591;
        public const uint GL_OPERAND2_RGB_ARB = 0x8592;
        public const uint GL_OPERAND3_RGB_ARB = 0x8593;
        public const uint GL_OPERAND4_RGB_ARB = 0x8594;
        public const uint GL_OPERAND5_RGB_ARB = 0x8595;
        public const uint GL_OPERAND6_RGB_ARB = 0x8596;
        public const uint GL_OPERAND7_RGB_ARB = 0x8597;
        public const uint GL_OPERAND0_ALPHA_ARB = 0x8598;
        public const uint GL_OPERAND1_ALPHA_ARB = 0x8599;
        public const uint GL_OPERAND2_ALPHA_ARB = 0x859A;
        public const uint GL_OPERAND3_ALPHA_ARB = 0x859B;
        public const uint GL_OPERAND4_ALPHA_ARB = 0x859C;
        public const uint GL_OPERAND5_ALPHA_ARB = 0x859D;
        public const uint GL_OPERAND6_ALPHA_ARB = 0x859E;
        public const uint GL_OPERAND7_ALPHA_ARB = 0x859F;
#endif

#if GL_ARB_texture_mirrored_repeat
        public const uint GL_MIRRORED_REPEAT_ARB = 0x8370;
#endif

#if GL_ARB_texture_env_dot3
        public const uint GL_DOT3_RGB_ARB = 0x86AE;
        public const uint GL_DOT3_RGBA_ARB = 0x86AF;
#endif

#if GL_ARB_point_parameters
        public const uint GL_POINT_SIZE_MIN_ARB = 0x8126;
        public const uint GL_POINT_SIZE_MAX_ARB = 0x8127;
        public const uint GL_POINT_FADE_THRESHOLD_SIZE_ARB = 0x8128;
        public const uint GL_POINT_DISTANCE_ATTENUATION_ARB = 0x8129;
#endif

#if GL_ARB_fragment_program
        public const uint GL_FRAGMENT_PROGRAM_ARB = 0x8804;
        public const uint GL_PROGRAM_ALU_INSTRUCTIONS_ARB = 0x8805;
        public const uint GL_PROGRAM_TEX_INSTRUCTIONS_ARB = 0x8806;
        public const uint GL_PROGRAM_TEX_INDIRECTIONS_ARB = 0x8807;
        public const uint GL_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = 0x8808;
        public const uint GL_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = 0x8809;
        public const uint GL_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = 0x880A;
        public const uint GL_MAX_PROGRAM_ALU_INSTRUCTIONS_ARB = 0x880B;
        public const uint GL_MAX_PROGRAM_TEX_INSTRUCTIONS_ARB = 0x880C;
        public const uint GL_MAX_PROGRAM_TEX_INDIRECTIONS_ARB = 0x880D;
        public const uint GL_MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = 0x880E;
        public const uint GL_MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = 0x880F;
        public const uint GL_MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = 0x8810;
        public const uint GL_MAX_TEXTURE_COORDS_ARB = 0x8871;
        public const uint GL_MAX_TEXTURE_IMAGE_UNITS_ARB = 0x8872;
#endif

#if GL_ARB_vertex_program
        public const uint GL_VERTEX_PROGRAM_ARB = 0x8620;
        public const uint GL_VERTEX_PROGRAM_POINT_SIZE_ARB = 0x8642;
        public const uint GL_VERTEX_PROGRAM_TWO_SIDE_ARB = 0x8643;
        public const uint GL_PROGRAM_FORMAT_ASCII_ARB = 0x8875;
        public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED_ARB = 0x8622;
        public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE_ARB = 0x8623;
        public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE_ARB = 0x8624;
        public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE_ARB = 0x8625;
        public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = 0x886A;
        public const uint GL_CURRENT_VERTEX_ATTRIB_ARB = 0x8626;
        public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER_ARB = 0x8645;
        public const uint GL_PROGRAM_LENGTH_ARB = 0x8627;
        public const uint GL_PROGRAM_FORMAT_ARB = 0x8876;
        public const uint GL_PROGRAM_NAME_ARB = 0x8677;
        public const uint GL_PROGRAM_BINDING_ARB = 0x8677;
        public const uint GL_PROGRAM_INSTRUCTIONS_ARB = 0x88A0;
        public const uint GL_MAX_PROGRAM_INSTRUCTIONS_ARB = 0x88A1;
        public const uint GL_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A2;
        public const uint GL_MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A3;
        public const uint GL_PROGRAM_TEMPORARIES_ARB = 0x88A4;
        public const uint GL_MAX_PROGRAM_TEMPORARIES_ARB = 0x88A5;
        public const uint GL_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A6;
        public const uint GL_MAX_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A7;
        public const uint GL_PROGRAM_PARAMETERS_ARB = 0x88A8;
        public const uint GL_MAX_PROGRAM_PARAMETERS_ARB = 0x88A9;
        public const uint GL_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AA;
        public const uint GL_MAX_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AB;
        public const uint GL_PROGRAM_ATTRIBS_ARB = 0x88AC;
        public const uint GL_MAX_PROGRAM_ATTRIBS_ARB = 0x88AD;
        public const uint GL_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AE;
        public const uint GL_MAX_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AF;
        public const uint GL_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B0;
        public const uint GL_MAX_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B1;
        public const uint GL_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B2;
        public const uint GL_MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B3;
        public const uint GL_MAX_PROGRAM_LOCAL_PARAMETERS_ARB = 0x88B4;
        public const uint GL_MAX_PROGRAM_ENV_PARAMETERS_ARB = 0x88B5;
        public const uint GL_PROGRAM_UNDER_NATIVE_LIMITS_ARB = 0x88B6;
        public const uint GL_PROGRAM_STRING_ARB = 0x8628;
        public const uint GL_PROGRAM_ERROR_POSITION_ARB = 0x864B;
        public const uint GL_CURRENT_MATRIX_ARB = 0x8641;
        public const uint GL_TRANSPOSE_CURRENT_MATRIX_ARB = 0x88B7;
        public const uint GL_CURRENT_MATRIX_STACK_DEPTH_ARB = 0x8640;
        public const uint GL_MAX_VERTEX_ATTRIBS_ARB = 0x8869;
        public const uint GL_MAX_PROGRAM_MATRICES_ARB = 0x862F;
        public const uint GL_MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB = 0x862E;
        public const uint GL_PROGRAM_ERROR_STRING_ARB = 0x8874;

        public const uint GL_MATRIX0_ARB = 0x88C0;
        public const uint GL_MATRIX1_ARB = 0x88C1;
        public const uint GL_MATRIX2_ARB = 0x88C2;
        public const uint GL_MATRIX3_ARB = 0x88C3;
        public const uint GL_MATRIX4_ARB = 0x88C4;
        public const uint GL_MATRIX5_ARB = 0x88C5;
        public const uint GL_MATRIX6_ARB = 0x88C6;
        public const uint GL_MATRIX7_ARB = 0x88C7;
        public const uint GL_MATRIX8_ARB = 0x88C8;
        public const uint GL_MATRIX9_ARB = 0x88C9;
        public const uint GL_MATRIX10_ARB = 0x88CA;
        public const uint GL_MATRIX11_ARB = 0x88CB;
        public const uint GL_MATRIX12_ARB = 0x88CC;
        public const uint GL_MATRIX13_ARB = 0x88CD;
        public const uint GL_MATRIX14_ARB = 0x88CE;
        public const uint GL_MATRIX15_ARB = 0x88CF;
        public const uint GL_MATRIX16_ARB = 0x88D0;
        public const uint GL_MATRIX17_ARB = 0x88D1;
        public const uint GL_MATRIX18_ARB = 0x88D2;
        public const uint GL_MATRIX19_ARB = 0x88D3;
        public const uint GL_MATRIX20_ARB = 0x88D4;
        public const uint GL_MATRIX21_ARB = 0x88D5;
        public const uint GL_MATRIX22_ARB = 0x88D6;
        public const uint GL_MATRIX23_ARB = 0x88D7;
        public const uint GL_MATRIX24_ARB = 0x88D8;
        public const uint GL_MATRIX25_ARB = 0x88D9;
        public const uint GL_MATRIX26_ARB = 0x88DA;
        public const uint GL_MATRIX27_ARB = 0x88DB;
        public const uint GL_MATRIX28_ARB = 0x88DC;
        public const uint GL_MATRIX29_ARB = 0x88DD;
        public const uint GL_MATRIX30_ARB = 0x88DE;
        public const uint GL_MATRIX31_ARB = 0x88DF;

        public const uint GL_COLOR_SUM_ARB = 0x8458;
#endif

#if GL_ARB_shader_objects
        public const uint GL_PROGRAM_OBJECT_ARB = 0x8B40;
        public const uint GL_OBJECT_TYPE_ARB = 0x8B4E;
        public const uint GL_OBJECT_SUBTYPE_ARB = 0x8B4F;
        public const uint GL_OBJECT_DELETE_STATUS_ARB = 0x8B80;
        public const uint GL_OBJECT_COMPILE_STATUS_ARB = 0x8B81;
        public const uint GL_OBJECT_LINK_STATUS_ARB = 0x8B82;
        public const uint GL_OBJECT_VALIDATE_STATUS_ARB = 0x8B83;
        public const uint GL_OBJECT_INFO_LOG_LENGTH_ARB = 0x8B84;
        public const uint GL_OBJECT_ATTACHED_OBJECTS_ARB = 0x8B85;
        public const uint GL_OBJECT_ACTIVE_UNIFORMS_ARB = 0x8B86;
        public const uint GL_OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = 0x8B87;
        public const uint GL_OBJECT_SHADER_SOURCE_LENGTH_ARB = 0x8B88;
        public const uint GL_SHADER_OBJECT_ARB = 0x8B48;
        public const uint GL_FLOAT_VEC2_ARB = 0x8B50;
        public const uint GL_FLOAT_VEC3_ARB = 0x8B51;
        public const uint GL_FLOAT_VEC4_ARB = 0x8B52;
        public const uint GL_INT_VEC2_ARB = 0x8B53;
        public const uint GL_INT_VEC3_ARB = 0x8B54;
        public const uint GL_INT_VEC4_ARB = 0x8B55;
        public const uint GL_BOOL_ARB = 0x8B56;
        public const uint GL_BOOL_VEC2_ARB = 0x8B57;
        public const uint GL_BOOL_VEC3_ARB = 0x8B58;
        public const uint GL_BOOL_VEC4_ARB = 0x8B59;
        public const uint GL_FLOAT_MAT2_ARB = 0x8B5A;
        public const uint GL_FLOAT_MAT3_ARB = 0x8B5B;
        public const uint GL_FLOAT_MAT4_ARB = 0x8B5C;
        public const uint GL_SAMPLER_1D_ARB = 0x8B5D;
        public const uint GL_SAMPLER_2D_ARB = 0x8B5E;
        public const uint GL_SAMPLER_3D_ARB = 0x8B5F;
        public const uint GL_SAMPLER_CUBE_ARB = 0x8B60;
        public const uint GL_SAMPLER_1D_SHADOW_ARB = 0x8B61;
        public const uint GL_SAMPLER_2D_SHADOW_ARB = 0x8B62;
        public const uint GL_SAMPLER_2D_RECT_ARB = 0x8B63;
        public const uint GL_SAMPLER_2D_RECT_SHADOW_ARB = 0x8B64;
#endif

#if GL_ARB_vertex_shader || GL_NV_vertex_program3
        public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = 0x8B4C;
#endif

#if GL_ARB_vertex_shader
        public const uint GL_VERTEX_SHADER_ARB = 0x8B31;
        public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS_ARB = 0x8B4A;
        //public const uint GL_MAX_TEXTURE_COORDS_ARB = 0x8871;
        //public const uint GL_MAX_TEXTURE_IMAGE_UNITS_ARB = 0x8872;
        public const uint GL_MAX_VARYING_FLOATS_ARB = 0x8B4B;
        //public const uint GL_MAX_VERTEX_ATTRIBS_ARB = 0x8869;
        public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = 0x8B4D;
        //public const uint GL_VERTEX_PROGRAM_POINT_SIZE_ARB = 0x8642;
        //public const uint GL_VERTEX_PROGRAM_TWO_SIDE_ARB = 0x8643;
        public const uint GL_OBJECT_ACTIVE_ATTRIBUTES_ARB = 0x8B89;
        public const uint GL_OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = 0x8B8A;
        //public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED_ARB = 0x8622;
        //public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE_ARB = 0x8623;
        //public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE_ARB = 0x8624;
        //public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE_ARB = 0x8625;
        //public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = 0x886A;
        //public const uint GL_CURRENT_VERTEX_ATTRIB_ARB = 0x8626;
        //public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER_ARB = 0x8645;
#endif

#if GL_ARB_fragment_shader
        public const uint GL_FRAGMENT_SHADER_ARB = 0x8B30;
        public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = 0x8B49;
        public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT_ARB = 0x8B8B;
        //public const uint GL_MAX_TEXTURE_COORDS_ARB = 0x8871;
        //public const uint GL_MAX_TEXTURE_IMAGE_UNITS_ARB = 0x8872;
#endif

#if GL_ARB_shading_language_100
        public const uint GL_SHADING_LANGUAGE_VERSION_ARB = 0x8B8C;
#endif

#if GL_ARB_vertex_buffer_object
        public const uint GL_ARRAY_BUFFER_ARB = 0x8892;
        public const uint GL_ELEMENT_ARRAY_BUFFER_ARB = 0x8893;
        public const uint GL_ARRAY_BUFFER_BINDING_ARB = 0x8894;
        public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING_ARB = 0x8895;
        public const uint GL_VERTEX_ARRAY_BUFFER_BINDING_ARB = 0x8896;
        public const uint GL_NORMAL_ARRAY_BUFFER_BINDING_ARB = 0x8897;
        public const uint GL_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x8898;
        public const uint GL_INDEX_ARRAY_BUFFER_BINDING_ARB = 0x8899;
        public const uint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = 0x889A;
        public const uint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = 0x889B;
        public const uint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x889C;
        public const uint GL_FOG_COORD_ARRAY_BUFFER_BINDING_ARB = 0x889D;
        public const uint GL_WEIGHT_ARRAY_BUFFER_BINDING_ARB = 0x889E;
        public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = 0x889F;
        public const uint GL_STREAM_DRAW_ARB = 0x88E0;
        public const uint GL_STREAM_READ_ARB = 0x88E1;
        public const uint GL_STREAM_COPY_ARB = 0x88E2;
        public const uint GL_STATIC_DRAW_ARB = 0x88E4;
        public const uint GL_STATIC_READ_ARB = 0x88E5;
        public const uint GL_STATIC_COPY_ARB = 0x88E6;
        public const uint GL_DYNAMIC_DRAW_ARB = 0x88E8;
        public const uint GL_DYNAMIC_READ_ARB = 0x88E9;
        public const uint GL_DYNAMIC_COPY_ARB = 0x88EA;
        public const uint GL_READ_ONLY_ARB = 0x88B8;
        public const uint GL_WRITE_ONLY_ARB = 0x88B9;
        public const uint GL_READ_WRITE_ARB = 0x88BA;
        public const uint GL_BUFFER_SIZE_ARB = 0x8764;
        public const uint GL_BUFFER_USAGE_ARB = 0x8765;
        public const uint GL_BUFFER_ACCESS_ARB = 0x88BB;
        public const uint GL_BUFFER_MAPPED_ARB = 0x88BC;
        public const uint GL_BUFFER_MAP_POINTER_ARB = 0x88BD;
        /* Obsolete */
        public const uint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = 0x889D;
#endif

#if GL_ARB_point_sprite
        public const uint GL_POINT_SPRITE_ARB = 0x8861;
        public const uint GL_COORD_REPLACE_ARB = 0x8862;
#endif

#if GL_ARB_texture_rectangle
        public const uint GL_TEXTURE_RECTANGLE_ARB = 0x84F5;
        public const uint GL_TEXTURE_BINDING_RECTANGLE_ARB = 0x84F6;
        public const uint GL_PROXY_TEXTURE_RECTANGLE_ARB = 0x84F7;
        public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE_ARB = 0x84F8;
#endif

#if GL_ARB_draw_buffers
        public const uint GL_MAX_DRAW_BUFFERS_ARB = 0x8824;
        public const uint GL_DRAW_BUFFER0_ARB = 0x8825;
        public const uint GL_DRAW_BUFFER1_ARB = 0x8826;
        public const uint GL_DRAW_BUFFER2_ARB = 0x8827;
        public const uint GL_DRAW_BUFFER3_ARB = 0x8828;
        public const uint GL_DRAW_BUFFER4_ARB = 0x8829;
        public const uint GL_DRAW_BUFFER5_ARB = 0x882A;
        public const uint GL_DRAW_BUFFER6_ARB = 0x882B;
        public const uint GL_DRAW_BUFFER7_ARB = 0x882C;
        public const uint GL_DRAW_BUFFER8_ARB = 0x882D;
        public const uint GL_DRAW_BUFFER9_ARB = 0x882E;
        public const uint GL_DRAW_BUFFER10_ARB = 0x882F;
        public const uint GL_DRAW_BUFFER11_ARB = 0x8830;
        public const uint GL_DRAW_BUFFER12_ARB = 0x8831;
        public const uint GL_DRAW_BUFFER13_ARB = 0x8832;
        public const uint GL_DRAW_BUFFER14_ARB = 0x8833;
        public const uint GL_DRAW_BUFFER15_ARB = 0x8834;
#endif

#if GL_ARB_pixel_buffer_object
        public const uint GL_PIXEL_PACK_BUFFER_ARB = 0x88EB;
        public const uint GL_PIXEL_UNPACK_BUFFER_ARB = 0x88EC;
        public const uint GL_PIXEL_PACK_BUFFER_BINDING_ARB = 0x88ED;
        public const uint GL_PIXEL_UNPACK_BUFFER_BINDING_ARB = 0x88EF;
#endif

#if GL_ARB_texture_float
        public const uint GL_TEXTURE_RED_TYPE_ARB = 0x8C10;
        public const uint GL_TEXTURE_GREEN_TYPE_ARB = 0x8C11;
        public const uint GL_TEXTURE_BLUE_TYPE_ARB = 0x8C12;
        public const uint GL_TEXTURE_ALPHA_TYPE_ARB = 0x8C13;
        public const uint GL_TEXTURE_LUMINANCE_TYPE_ARB = 0x8C14;
        public const uint GL_TEXTURE_INTENSITY_TYPE_ARB = 0x8C15;
        public const uint GL_TEXTURE_DEPTH_TYPE_ARB = 0x8C16;
        public const uint GL_UNSIGNED_NORMALIZED_ARB = 0x8C17;
        public const uint GL_RGBA32F_ARB = 0x8814;
        public const uint GL_RGB32F_ARB = 0x8815;
        public const uint GL_ALPHA32F_ARB = 0x8816;
        public const uint GL_INTENSITY32F_ARB = 0x8817;
        public const uint GL_LUMINANCE32F_ARB = 0x8818;
        public const uint GL_LUMINANCE_ALPHA32F_ARB = 0x8819;
        public const uint GL_RGBA16F_ARB = 0x881A;
        public const uint GL_RGB16F_ARB = 0x881B;
        public const uint GL_ALPHA16F_ARB = 0x881C;
        public const uint GL_INTENSITY16F_ARB = 0x881D;
        public const uint GL_LUMINANCE16F_ARB = 0x881E;
        public const uint GL_LUMINANCE_ALPHA16F_ARB = 0x881F;
#endif

#if GL_ARB_half_float_pixel
        public const uint GL_HALF_FLOAT_ARB = 0x140B;
#endif

#if GL_ARB_color_buffer_float
        public const uint GL_RGBA_FLOAT_MODE_ARB = 0x8820;
        public const uint GL_CLAMP_VERTEX_COLOR_ARB = 0x891A;
        public const uint GL_CLAMP_FRAGMENT_COLOR_ARB = 0x891B;
        public const uint GL_CLAMP_READ_COLOR_ARB = 0x891C;
        public const uint GL_FIXED_ONLY_ARB = 0x891D;
#endif

#if GL_ARB_half_float_vertex
        public const uint GL_HALF_FLOAT = 0x140B;
#endif

#if GL_ARB_texture_rg
        public const uint GL_COMPRESSED_RED = 0x8225;
        public const uint GL_COMPRESSED_RG = 0x8226;
        public const uint GL_RG = 0x8227;
        public const uint GL_RG_INTEGER = 0x8228;
        public const uint GL_R8 = 0x8229;
        public const uint GL_R16 = 0x822A;
        public const uint GL_RG8 = 0x822B;
        public const uint GL_RG16 = 0x822C;
        public const uint GL_R16F = 0x822D;
        public const uint GL_R32F = 0x822E;
        public const uint GL_RG16F = 0x822F;
        public const uint GL_RG32F = 0x8230;
        public const uint GL_R8I = 0x8231;
        public const uint GL_R8UI = 0x8232;
        public const uint GL_R16I = 0x8233;
        public const uint GL_R16UI = 0x8234;
        public const uint GL_R32I = 0x8235;
        public const uint GL_R32UI = 0x8236;
        public const uint GL_RG8I = 0x8237;
        public const uint GL_RG8UI = 0x8238;
        public const uint GL_RG16I = 0x8239;
        public const uint GL_RG16UI = 0x823A;
        public const uint GL_RG32I = 0x823B;
        public const uint GL_RG32UI = 0x823C;
#endif

#if GL_ARB_instanced_arrays
        public const uint GL_VERTEX_ATTRIB_ARRAY_DIVISOR_ARB = 0x88FE;
#endif

#if GL_ARB_uniform_buffer_object
        public const uint GL_UNIFORM_BUFFER = 0x8A11;
        public const uint GL_UNIFORM_BUFFER_BINDING = 0x8A28;
        public const uint GL_UNIFORM_BUFFER_START = 0x8A29;
        public const uint GL_UNIFORM_BUFFER_SIZE = 0x8A2A;
        public const uint GL_MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
        public const uint GL_MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C;
        public const uint GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;
        public const uint GL_MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
        public const uint GL_MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
        public const uint GL_MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
        public const uint GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
        public const uint GL_MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32;
        public const uint GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
        public const uint GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
        public const uint GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
        public const uint GL_ACTIVE_UNIFORM_BLOCKS = 0x8A36;
        public const uint GL_UNIFORM_TYPE = 0x8A37;
        public const uint GL_UNIFORM_SIZE = 0x8A38;
        public const uint GL_UNIFORM_NAME_LENGTH = 0x8A39;
        public const uint GL_UNIFORM_BLOCK_INDEX = 0x8A3A;
        public const uint GL_UNIFORM_OFFSET = 0x8A3B;
        public const uint GL_UNIFORM_ARRAY_STRIDE = 0x8A3C;
        public const uint GL_UNIFORM_MATRIX_STRIDE = 0x8A3D;
        public const uint GL_UNIFORM_IS_ROW_MAJOR = 0x8A3E;
        public const uint GL_UNIFORM_BLOCK_BINDING = 0x8A3F;
        public const uint GL_UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
        public const uint GL_UNIFORM_BLOCK_NAME_LENGTH = 0x8A41;
        public const uint GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
        public const uint GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
        public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
        public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = 0x8A45;
        public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;
        public const uint GL_INVALID_INDEX = 0xFFFFFFFF;
#endif

#if GL_ARB_depth_buffer_float
        public const uint GL_DEPTH_COMPONENT32F = 0x8CAC;
        public const uint GL_DEPTH32F_STENCIL8 = 0x8CAD;
        public const uint GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
#endif

#if GL_EXT_abgr
        public const uint GL_ABGR_EXT = 0x8000;
#endif

#if GL_EXT_blend_color
        public const uint GL_CONSTANT_COLOR_EXT = 0x8001;
        public const uint GL_ONE_MINUS_CONSTANT_COLOR_EXT = 0x8002;
        public const uint GL_CONSTANT_ALPHA_EXT = 0x8003;
        public const uint GL_ONE_MINUS_CONSTANT_ALPHA_EXT = 0x8004;
        public const uint GL_BLEND_COLOR_EXT = 0x8005;
#endif

#if GL_EXT_polygon_offset
public const uint GL_POLYGON_OFFSET_EXT = 0x8037;
public const uint GL_POLYGON_OFFSET_FACTOR_EXT = 0x8038;
public const uint GL_POLYGON_OFFSET_BIAS_EXT = 0x8039;
#endif

#if GL_EXT_texture
public const uint GL_ALPHA4_EXT = 0x803B;
public const uint GL_ALPHA8_EXT = 0x803C;
public const uint GL_ALPHA12_EXT = 0x803D;
public const uint GL_ALPHA16_EXT = 0x803E;
public const uint GL_LUMINANCE4_EXT = 0x803F;
public const uint GL_LUMINANCE8_EXT = 0x8040;
public const uint GL_LUMINANCE12_EXT = 0x8041;
public const uint GL_LUMINANCE16_EXT = 0x8042;
public const uint GL_LUMINANCE4_ALPHA4_EXT = 0x8043;
public const uint GL_LUMINANCE6_ALPHA2_EXT = 0x8044;
public const uint GL_LUMINANCE8_ALPHA8_EXT = 0x8045;
public const uint GL_LUMINANCE12_ALPHA4_EXT = 0x8046;
public const uint GL_LUMINANCE12_ALPHA12_EXT = 0x8047;
public const uint GL_LUMINANCE16_ALPHA16_EXT = 0x8048;
public const uint GL_INTENSITY_EXT = 0x8049;
public const uint GL_INTENSITY4_EXT = 0x804A;
public const uint GL_INTENSITY8_EXT = 0x804B;
public const uint GL_INTENSITY12_EXT = 0x804C;
public const uint GL_INTENSITY16_EXT = 0x804D;
public const uint GL_RGB2_EXT = 0x804E;
public const uint GL_RGB4_EXT = 0x804F;
public const uint GL_RGB5_EXT = 0x8050;
public const uint GL_RGB8_EXT = 0x8051;
public const uint GL_RGB10_EXT = 0x8052;
public const uint GL_RGB12_EXT = 0x8053;
public const uint GL_RGB16_EXT = 0x8054;
public const uint GL_RGBA2_EXT = 0x8055;
public const uint GL_RGBA4_EXT = 0x8056;
public const uint GL_RGB5_A1_EXT = 0x8057;
public const uint GL_RGBA8_EXT = 0x8058;
public const uint GL_RGB10_A2_EXT = 0x8059;
public const uint GL_RGBA12_EXT = 0x805A;
public const uint GL_RGBA16_EXT = 0x805B;
public const uint GL_TEXTURE_RED_SIZE_EXT = 0x805C;
public const uint GL_TEXTURE_GREEN_SIZE_EXT = 0x805D;
public const uint GL_TEXTURE_BLUE_SIZE_EXT = 0x805E;
public const uint GL_TEXTURE_ALPHA_SIZE_EXT = 0x805F;
public const uint GL_TEXTURE_LUMINANCE_SIZE_EXT = 0x8060;
public const uint GL_TEXTURE_INTENSITY_SIZE_EXT = 0x8061;
public const uint GL_REPLACE_EXT = 0x8062;
public const uint GL_PROXY_TEXTURE_1D_EXT = 0x8063;
public const uint GL_PROXY_TEXTURE_2D_EXT = 0x8064;
public const uint GL_TEXTURE_TOO_LARGE_EXT = 0x8065;
#endif

#if GL_EXT_texture3D
public const uint GL_PACK_SKIP_IMAGES_EXT = 0x806B;
public const uint GL_PACK_IMAGE_HEIGHT_EXT = 0x806C;
public const uint GL_UNPACK_SKIP_IMAGES_EXT = 0x806D;
public const uint GL_UNPACK_IMAGE_HEIGHT_EXT = 0x806E;
public const uint GL_TEXTURE_3D_EXT = 0x806F;
public const uint GL_PROXY_TEXTURE_3D_EXT = 0x8070;
public const uint GL_TEXTURE_DEPTH_EXT = 0x8071;
public const uint GL_TEXTURE_WRAP_R_EXT = 0x8072;
public const uint GL_MAX_3D_TEXTURE_SIZE_EXT = 0x8073;
#endif

#if GL_EXT_histogram
public const uint GL_HISTOGRAM_EXT = 0x8024;
public const uint GL_PROXY_HISTOGRAM_EXT = 0x8025;
public const uint GL_HISTOGRAM_WIDTH_EXT = 0x8026;
public const uint GL_HISTOGRAM_FORMAT_EXT = 0x8027;
public const uint GL_HISTOGRAM_RED_SIZE_EXT = 0x8028;
public const uint GL_HISTOGRAM_GREEN_SIZE_EXT = 0x8029;
public const uint GL_HISTOGRAM_BLUE_SIZE_EXT = 0x802A;
public const uint GL_HISTOGRAM_ALPHA_SIZE_EXT = 0x802B;
public const uint GL_HISTOGRAM_LUMINANCE_SIZE_EXT = 0x802C;
public const uint GL_HISTOGRAM_SINK_EXT = 0x802D;
public const uint GL_MINMAX_EXT = 0x802E;
public const uint GL_MINMAX_FORMAT_EXT = 0x802F;
public const uint GL_MINMAX_SINK_EXT = 0x8030;
public const uint GL_TABLE_TOO_LARGE_EXT = 0x8031;
#endif

#if GL_EXT_convolution
public const uint GL_CONVOLUTION_1D_EXT = 0x8010;
public const uint GL_CONVOLUTION_2D_EXT = 0x8011;
public const uint GL_SEPARABLE_2D_EXT = 0x8012;
public const uint GL_CONVOLUTION_BORDER_MODE_EXT = 0x8013;
public const uint GL_CONVOLUTION_FILTER_SCALE_EXT = 0x8014;
public const uint GL_CONVOLUTION_FILTER_BIAS_EXT = 0x8015;
public const uint GL_REDUCE_EXT = 0x8016;
public const uint GL_CONVOLUTION_FORMAT_EXT = 0x8017;
public const uint GL_CONVOLUTION_WIDTH_EXT = 0x8018;
public const uint GL_CONVOLUTION_HEIGHT_EXT = 0x8019;
public const uint GL_MAX_CONVOLUTION_WIDTH_EXT = 0x801A;
public const uint GL_MAX_CONVOLUTION_HEIGHT_EXT = 0x801B;
public const uint GL_POST_CONVOLUTION_RED_SCALE_EXT = 0x801C;
public const uint GL_POST_CONVOLUTION_GREEN_SCALE_EXT = 0x801D;
public const uint GL_POST_CONVOLUTION_BLUE_SCALE_EXT = 0x801E;
public const uint GL_POST_CONVOLUTION_ALPHA_SCALE_EXT = 0x801F;
public const uint GL_POST_CONVOLUTION_RED_BIAS_EXT = 0x8020;
public const uint GL_POST_CONVOLUTION_GREEN_BIAS_EXT = 0x8021;
public const uint GL_POST_CONVOLUTION_BLUE_BIAS_EXT = 0x8022;
public const uint GL_POST_CONVOLUTION_ALPHA_BIAS_EXT = 0x8023;
#endif

#if GL_EXT_cmyka
public const uint GL_CMYK_EXT = 0x800C;
public const uint GL_CMYKA_EXT = 0x800D;
public const uint GL_PACK_CMYK_HINT_EXT = 0x800E;
public const uint GL_UNPACK_CMYK_HINT_EXT = 0x800F;
#endif

#if GL_EXT_texture_object
public const uint GL_TEXTURE_PRIORITY_EXT = 0x8066;
public const uint GL_TEXTURE_RESIDENT_EXT = 0x8067;
public const uint GL_TEXTURE_1D_BINDING_EXT = 0x8068;
public const uint GL_TEXTURE_2D_BINDING_EXT = 0x8069;
public const uint GL_TEXTURE_3D_BINDING_EXT = 0x806A;
#endif

#if GL_EXT_packed_pixels
public const uint GL_UNSIGNED_BYTE_3_3_2_EXT = 0x8032;
public const uint GL_UNSIGNED_SHORT_4_4_4_4_EXT = 0x8033;
public const uint GL_UNSIGNED_SHORT_5_5_5_1_EXT = 0x8034;
public const uint GL_UNSIGNED_INT_8_8_8_8_EXT = 0x8035;
public const uint GL_UNSIGNED_INT_10_10_10_2_EXT = 0x8036;
#endif

#if GL_EXT_rescale_normal
        public const uint GL_RESCALE_NORMAL_EXT = 0x803A;
#endif

#if GL_EXT_vertex_array
public const uint GL_VERTEX_ARRAY_EXT = 0x8074;
public const uint GL_NORMAL_ARRAY_EXT = 0x8075;
public const uint GL_COLOR_ARRAY_EXT = 0x8076;
public const uint GL_INDEX_ARRAY_EXT = 0x8077;
public const uint GL_TEXTURE_COORD_ARRAY_EXT = 0x8078;
public const uint GL_EDGE_FLAG_ARRAY_EXT = 0x8079;
public const uint GL_VERTEX_ARRAY_SIZE_EXT = 0x807A;
public const uint GL_VERTEX_ARRAY_TYPE_EXT = 0x807B;
public const uint GL_VERTEX_ARRAY_STRIDE_EXT = 0x807C;
public const uint GL_VERTEX_ARRAY_COUNT_EXT = 0x807D;
public const uint GL_NORMAL_ARRAY_TYPE_EXT = 0x807E;
public const uint GL_NORMAL_ARRAY_STRIDE_EXT = 0x807F;
public const uint GL_NORMAL_ARRAY_COUNT_EXT = 0x8080;
public const uint GL_COLOR_ARRAY_SIZE_EXT = 0x8081;
public const uint GL_COLOR_ARRAY_TYPE_EXT = 0x8082;
public const uint GL_COLOR_ARRAY_STRIDE_EXT = 0x8083;
public const uint GL_COLOR_ARRAY_COUNT_EXT = 0x8084;
public const uint GL_INDEX_ARRAY_TYPE_EXT = 0x8085;
public const uint GL_INDEX_ARRAY_STRIDE_EXT = 0x8086;
public const uint GL_INDEX_ARRAY_COUNT_EXT = 0x8087;
public const uint GL_TEXTURE_COORD_ARRAY_SIZE_EXT = 0x8088;
public const uint GL_TEXTURE_COORD_ARRAY_TYPE_EXT = 0x8089;
public const uint GL_TEXTURE_COORD_ARRAY_STRIDE_EXT = 0x808A;
public const uint GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808B;
public const uint GL_EDGE_FLAG_ARRAY_STRIDE_EXT = 0x808C;
public const uint GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808D;
public const uint GL_VERTEX_ARRAY_POINTER_EXT = 0x808E;
public const uint GL_NORMAL_ARRAY_POINTER_EXT = 0x808F;
public const uint GL_COLOR_ARRAY_POINTER_EXT = 0x8090;
public const uint GL_INDEX_ARRAY_POINTER_EXT = 0x8091;
public const uint GL_TEXTURE_COORD_ARRAY_POINTER_EXT = 0x8092;
public const uint GL_EDGE_FLAG_ARRAY_POINTER_EXT = 0x8093;
#endif

#if GL_EXT_blend_minmax
        public const uint GL_FUNC_ADD_EXT = 0x8006;
        public const uint GL_MIN_EXT = 0x8007;
        public const uint GL_MAX_EXT = 0x8008;
        public const uint GL_BLEND_EQUATION_EXT = 0x8009;
#endif

#if GL_EXT_blend_subtract
        public const uint GL_FUNC_SUBTRACT_EXT = 0x800A;
        public const uint GL_FUNC_REVERSE_SUBTRACT_EXT = 0x800B;
#endif

#if GL_EXT_paletted_texture
public const uint GL_COLOR_INDEX1_EXT = 0x80E2;
public const uint GL_COLOR_INDEX2_EXT = 0x80E3;
public const uint GL_COLOR_INDEX4_EXT = 0x80E4;
public const uint GL_COLOR_INDEX8_EXT = 0x80E5;
public const uint GL_COLOR_INDEX12_EXT = 0x80E6;
public const uint GL_COLOR_INDEX16_EXT = 0x80E7;
public const uint GL_TEXTURE_INDEX_SIZE_EXT = 0x80ED;
#endif

#if GL_EXT_clip_volume_hint
        public const uint GL_CLIP_VOLUME_CLIPPING_HINT_EXT = 0x80F0;
#endif

#if GL_EXT_index_material
public const uint GL_INDEX_MATERIAL_EXT = 0x81B8;
public const uint GL_INDEX_MATERIAL_PARAMETER_EXT = 0x81B9;
public const uint GL_INDEX_MATERIAL_FACE_EXT = 0x81BA;
#endif

#if GL_EXT_index_func
public const uint GL_INDEX_TEST_EXT = 0x81B5;
public const uint GL_INDEX_TEST_FUNC_EXT = 0x81B6;
public const uint GL_INDEX_TEST_REF_EXT = 0x81B7;
#endif

#if GL_EXT_index_array_formats
public const uint GL_IUI_V2F_EXT = 0x81AD;
public const uint GL_IUI_V3F_EXT = 0x81AE;
public const uint GL_IUI_N3F_V2F_EXT = 0x81AF;
public const uint GL_IUI_N3F_V3F_EXT = 0x81B0;
public const uint GL_T2F_IUI_V2F_EXT = 0x81B1;
public const uint GL_T2F_IUI_V3F_EXT = 0x81B2;
public const uint GL_T2F_IUI_N3F_V2F_EXT = 0x81B3;
public const uint GL_T2F_IUI_N3F_V3F_EXT = 0x81B4;
#endif

#if GL_EXT_compiled_vertex_array
        public const uint GL_ARRAY_ELEMENT_LOCK_FIRST_EXT = 0x81A8;
        public const uint GL_ARRAY_ELEMENT_LOCK_COUNT_EXT = 0x81A9;
#endif

#if GL_EXT_cull_vertex
public const uint GL_CULL_VERTEX_EXT = 0x81AA;
public const uint GL_CULL_VERTEX_EYE_POSITION_EXT = 0x81AB;
public const uint GL_CULL_VERTEX_OBJECT_POSITION_EXT = 0x81AC;
#endif

#if GL_EXT_draw_range_elements
        public const uint GL_MAX_ELEMENTS_VERTICES_EXT = 0x80E8;
        public const uint GL_MAX_ELEMENTS_INDICES_EXT = 0x80E9;
#endif

#if GL_EXT_light_texture
public const uint GL_FRAGMENT_MATERIAL_EXT = 0x8349;
public const uint GL_FRAGMENT_NORMAL_EXT = 0x834A;
public const uint GL_FRAGMENT_COLOR_EXT = 0x834C;
public const uint GL_ATTENUATION_EXT = 0x834D;
public const uint GL_SHADOW_ATTENUATION_EXT = 0x834E;
public const uint GL_TEXTURE_APPLICATION_MODE_EXT = 0x834F;
public const uint GL_TEXTURE_LIGHT_EXT = 0x8350;
public const uint GL_TEXTURE_MATERIAL_FACE_EXT = 0x8351;
public const uint GL_TEXTURE_MATERIAL_PARAMETER_EXT = 0x8352;
/* reuse GL_FRAGMENT_DEPTH_EXT */
#endif

#if GL_EXT_bgra
        public const uint GL_BGR_EXT = 0x80E0;
        public const uint GL_BGRA_EXT = 0x80E1;
#endif

#if GL_EXT_pixel_transform
public const uint GL_PIXEL_TRANSFORM_2D_EXT = 0x8330;
public const uint GL_PIXEL_MAG_FILTER_EXT = 0x8331;
public const uint GL_PIXEL_MIN_FILTER_EXT = 0x8332;
public const uint GL_PIXEL_CUBIC_WEIGHT_EXT = 0x8333;
public const uint GL_CUBIC_EXT = 0x8334;
public const uint GL_AVERAGE_EXT = 0x8335;
public const uint GL_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = 0x8336;
public const uint GL_MAX_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = 0x8337;
public const uint GL_PIXEL_TRANSFORM_2D_MATRIX_EXT = 0x8338;
#endif

#if GL_EXT_shared_texture_palette
public const uint GL_SHARED_TEXTURE_PALETTE_EXT = 0x81FB;
#endif

#if GL_EXT_separate_specular_color
        public const uint GL_LIGHT_MODEL_COLOR_CONTROL_EXT = 0x81F8;
        public const uint GL_SINGLE_COLOR_EXT = 0x81F9;
        public const uint GL_SEPARATE_SPECULAR_COLOR_EXT = 0x81FA;
#endif

#if GL_EXT_secondary_color
        public const uint GL_COLOR_SUM_EXT = 0x8458;
        public const uint GL_CURRENT_SECONDARY_COLOR_EXT = 0x8459;
        public const uint GL_SECONDARY_COLOR_ARRAY_SIZE_EXT = 0x845A;
        public const uint GL_SECONDARY_COLOR_ARRAY_TYPE_EXT = 0x845B;
        public const uint GL_SECONDARY_COLOR_ARRAY_STRIDE_EXT = 0x845C;
        public const uint GL_SECONDARY_COLOR_ARRAY_POINTER_EXT = 0x845D;
        public const uint GL_SECONDARY_COLOR_ARRAY_EXT = 0x845E;
#endif

#if GL_EXT_texture_perturb_normal
public const uint GL_PERTURB_EXT = 0x85AE;
public const uint GL_TEXTURE_NORMAL_EXT = 0x85AF;
#endif

#if GL_EXT_fog_coord
        public const uint GL_FOG_COORDINATE_SOURCE_EXT = 0x8450;
        public const uint GL_FOG_COORDINATE_EXT = 0x8451;
        public const uint GL_FRAGMENT_DEPTH_EXT = 0x8452;
        public const uint GL_CURRENT_FOG_COORDINATE_EXT = 0x8453;
        public const uint GL_FOG_COORDINATE_ARRAY_TYPE_EXT = 0x8454;
        public const uint GL_FOG_COORDINATE_ARRAY_STRIDE_EXT = 0x8455;
        public const uint GL_FOG_COORDINATE_ARRAY_POINTER_EXT = 0x8456;
        public const uint GL_FOG_COORDINATE_ARRAY_EXT = 0x8457;
#endif

#if GL_EXT_coordinate_frame
public const uint GL_TANGENT_ARRAY_EXT = 0x8439;
public const uint GL_BINORMAL_ARRAY_EXT = 0x843A;
public const uint GL_CURRENT_TANGENT_EXT = 0x843B;
public const uint GL_CURRENT_BINORMAL_EXT = 0x843C;
public const uint GL_TANGENT_ARRAY_TYPE_EXT = 0x843E;
public const uint GL_TANGENT_ARRAY_STRIDE_EXT = 0x843F;
public const uint GL_BINORMAL_ARRAY_TYPE_EXT = 0x8440;
public const uint GL_BINORMAL_ARRAY_STRIDE_EXT = 0x8441;
public const uint GL_TANGENT_ARRAY_POINTER_EXT = 0x8442;
public const uint GL_BINORMAL_ARRAY_POINTER_EXT = 0x8443;
public const uint GL_MAP1_TANGENT_EXT = 0x8444;
public const uint GL_MAP2_TANGENT_EXT = 0x8445;
public const uint GL_MAP1_BINORMAL_EXT = 0x8446;
public const uint GL_MAP2_BINORMAL_EXT = 0x8447;
#endif

#if GL_EXT_texture_env_combine
public const uint GL_COMBINE_EXT = 0x8570;
public const uint GL_COMBINE_RGB_EXT = 0x8571;
public const uint GL_COMBINE_ALPHA_EXT = 0x8572;
public const uint GL_RGB_SCALE_EXT = 0x8573;
public const uint GL_ADD_SIGNED_EXT = 0x8574;
public const uint GL_INTERPOLATE_EXT = 0x8575;
public const uint GL_CONSTANT_EXT = 0x8576;
public const uint GL_PRIMARY_COLOR_EXT = 0x8577;
public const uint GL_PREVIOUS_EXT = 0x8578;
public const uint GL_SOURCE0_RGB_EXT = 0x8580;
public const uint GL_SOURCE1_RGB_EXT = 0x8581;
public const uint GL_SOURCE2_RGB_EXT = 0x8582;
public const uint GL_SOURCE3_RGB_EXT = 0x8583;
public const uint GL_SOURCE4_RGB_EXT = 0x8584;
public const uint GL_SOURCE5_RGB_EXT = 0x8585;
public const uint GL_SOURCE6_RGB_EXT = 0x8586;
public const uint GL_SOURCE7_RGB_EXT = 0x8587;
public const uint GL_SOURCE0_ALPHA_EXT = 0x8588;
public const uint GL_SOURCE1_ALPHA_EXT = 0x8589;
public const uint GL_SOURCE2_ALPHA_EXT = 0x858A;
public const uint GL_SOURCE3_ALPHA_EXT = 0x858B;
public const uint GL_SOURCE4_ALPHA_EXT = 0x858C;
public const uint GL_SOURCE5_ALPHA_EXT = 0x858D;
public const uint GL_SOURCE6_ALPHA_EXT = 0x858E;
public const uint GL_SOURCE7_ALPHA_EXT = 0x858F;
public const uint GL_OPERAND0_RGB_EXT = 0x8590;
public const uint GL_OPERAND1_RGB_EXT = 0x8591;
public const uint GL_OPERAND2_RGB_EXT = 0x8592;
public const uint GL_OPERAND3_RGB_EXT = 0x8593;
public const uint GL_OPERAND4_RGB_EXT = 0x8594;
public const uint GL_OPERAND5_RGB_EXT = 0x8595;
public const uint GL_OPERAND6_RGB_EXT = 0x8596;
public const uint GL_OPERAND7_RGB_EXT = 0x8597;
public const uint GL_OPERAND0_ALPHA_EXT = 0x8598;
public const uint GL_OPERAND1_ALPHA_EXT = 0x8599;
public const uint GL_OPERAND2_ALPHA_EXT = 0x859A;
public const uint GL_OPERAND3_ALPHA_EXT = 0x859B;
public const uint GL_OPERAND4_ALPHA_EXT = 0x859C;
public const uint GL_OPERAND5_ALPHA_EXT = 0x859D;
public const uint GL_OPERAND6_ALPHA_EXT = 0x859E;
public const uint GL_OPERAND7_ALPHA_EXT = 0x859F;
#endif

#if GL_EXT_blend_func_separate
        public const uint GL_BLEND_DST_RGB_EXT = 0x80C8;
        public const uint GL_BLEND_SRC_RGB_EXT = 0x80C9;
        public const uint GL_BLEND_DST_ALPHA_EXT = 0x80CA;
        public const uint GL_BLEND_SRC_ALPHA_EXT = 0x80CB;
#endif

#if GL_EXT_stencil_wrap
        public const uint GL_INCR_WRAP_EXT = 0x8507;
        public const uint GL_DECR_WRAP_EXT = 0x8508;
#endif

#if GL_EXT_422_pixels
public const uint GL_422_EXT = 0x80CC;
public const uint GL_422_REV_EXT = 0x80CD;
public const uint GL_422_AVERAGE_EXT = 0x80CE;
public const uint GL_422_REV_AVERAGE_EXT = 0x80CF;
#endif

#if GL_EXT_texture_cube_map
public const uint GL_NORMAL_MAP_EXT = 0x8511;
public const uint GL_REFLECTION_MAP_EXT = 0x8512;
public const uint GL_TEXTURE_CUBE_MAP_EXT = 0x8513;
public const uint GL_TEXTURE_BINDING_CUBE_MAP_EXT = 0x8514;
public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X_EXT = 0x8515;
public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X_EXT = 0x8516;
public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y_EXT = 0x8517;
public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_EXT = 0x8518;
public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z_EXT = 0x8519;
public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_EXT = 0x851A;
public const uint GL_PROXY_TEXTURE_CUBE_MAP_EXT = 0x851B;
public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE_EXT = 0x851C;
#endif

#if GL_EXT_texture_lod_bias
        public const uint GL_MAX_TEXTURE_LOD_BIAS_EXT = 0x84FD;
        public const uint GL_TEXTURE_FILTER_CONTROL_EXT = 0x8500;
        public const uint GL_TEXTURE_LOD_BIAS_EXT = 0x8501;
#endif

#if GL_EXT_texture_filter_anisotropic
        public const uint GL_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;
        public const uint GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
#endif

#if GL_EXT_vertex_weighting
public const uint GL_MODELVIEW0_STACK_DEPTH_EXT = GL_MODELVIEW_STACK_DEPTH;
public const uint GL_MODELVIEW1_STACK_DEPTH_EXT = 0x8502;
public const uint GL_MODELVIEW0_MATRIX_EXT = GL_MODELVIEW_MATRIX;
public const uint GL_MODELVIEW_MATRIX1_EXT = 0x8506;
public const uint GL_VERTEX_WEIGHTING_EXT = 0x8509;
public const uint GL_MODELVIEW0_EXT = GL_MODELVIEW;
public const uint GL_MODELVIEW1_EXT = 0x850A;
public const uint GL_CURRENT_VERTEX_WEIGHT_EXT = 0x850B;
public const uint GL_VERTEX_WEIGHT_ARRAY_EXT = 0x850C;
public const uint GL_VERTEX_WEIGHT_ARRAY_SIZE_EXT = 0x850D;
public const uint GL_VERTEX_WEIGHT_ARRAY_TYPE_EXT = 0x850E;
public const uint GL_VERTEX_WEIGHT_ARRAY_STRIDE_EXT = 0x850F;
public const uint GL_VERTEX_WEIGHT_ARRAY_POINTER_EXT = 0x8510;
#endif

#if GL_EXT_texture_compression_s3tc
        public const uint GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0;
        public const uint GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1;
        public const uint GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2;
        public const uint GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3;
#endif

#if GL_EXT_texture_rectangle
        public const uint GL_TEXTURE_RECTANGLE_EXT = 0x84F5;
        public const uint GL_TEXTURE_BINDING_RECTANGLE_EXT = 0x84F6;
        public const uint GL_PROXY_TEXTURE_RECTANGLE_EXT = 0x84F7;
        public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE_EXT = 0x84F8;
#endif

#if GL_EXT_texture_sRGB
        public const uint GL_SRGB_EXT = 0x8C40;
        public const uint GL_SRGB8_EXT = 0x8C41;
        public const uint GL_SRGB_ALPHA_EXT = 0x8C42;
        public const uint GL_SRGB8_ALPHA8_EXT = 0x8C43;
        public const uint GL_SLUMINANCE_ALPHA_EXT = 0x8C44;
        public const uint GL_SLUMINANCE8_ALPHA8_EXT = 0x8C45;
        public const uint GL_SLUMINANCE_EXT = 0x8C46;
        public const uint GL_SLUMINANCE8_EXT = 0x8C47;
        public const uint GL_COMPRESSED_SRGB_EXT = 0x8C48;
        public const uint GL_COMPRESSED_SRGB_ALPHA_EXT = 0x8C49;
        public const uint GL_COMPRESSED_SLUMINANCE_EXT = 0x8C4A;
        public const uint GL_COMPRESSED_SLUMINANCE_ALPHA_EXT = 0x8C4B;
        public const uint GL_COMPRESSED_SRGB_S3TC_DXT1_EXT = 0x8C4C;
        public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = 0x8C4D;
        public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = 0x8C4E;
        public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = 0x8C4F;
#endif

#if GL_EXT_vertex_shader
public const uint GL_VERTEX_SHADER_EXT = 0x8780;
public const uint GL_VARIANT_VALUE_EXT = 0x87E4;
public const uint GL_VARIANT_DATATYPE_EXT = 0x87E5;
public const uint GL_VARIANT_ARRAY_STRIDE_EXT = 0x87E6;
public const uint GL_VARIANT_ARRAY_TYPE_EXT = 0x87E7;
public const uint GL_VARIANT_ARRAY_EXT = 0x87E8;
public const uint GL_VARIANT_ARRAY_POINTER_EXT = 0x87E9;
public const uint GL_INVARIANT_VALUE_EXT = 0x87EA;
public const uint GL_INVARIANT_DATATYPE_EXT = 0x87EB;
public const uint GL_LOCAL_CONSTANT_VALUE_EXT = 0x87EC;
public const uint GL_LOCAL_CONSTANT_DATATYPE_EXT = 0x87Ed;
public const uint GL_OP_INDEX_EXT = 0x8782;
public const uint GL_OP_NEGATE_EXT = 0x8783;
public const uint GL_OP_DOT3_EXT = 0x8784;
public const uint GL_OP_DOT4_EXT = 0x8785;
public const uint GL_OP_MUL_EXT = 0x8786;
public const uint GL_OP_ADD_EXT = 0x8787;
public const uint GL_OP_MADD_EXT = 0x8788;
public const uint GL_OP_FRAC_EXT = 0x8789;
public const uint GL_OP_MAX_EXT = 0x878A;
public const uint GL_OP_MIN_EXT = 0x878B;
public const uint GL_OP_SET_GE_EXT = 0x878C;
public const uint GL_OP_SET_LT_EXT = 0x878D;
public const uint GL_OP_CLAMP_EXT = 0x878E;
public const uint GL_OP_FLOOR_EXT = 0x878F;
public const uint GL_OP_ROUND_EXT = 0x8790;
public const uint GL_OP_EXP_BASE_2_EXT = 0x8791;
public const uint GL_OP_LOG_BASE_2_EXT = 0x8792;
public const uint GL_OP_POWER_EXT = 0x8793;
public const uint GL_OP_RECIP_EXT = 0x8794;
public const uint GL_OP_RECIP_SQRT_EXT = 0x8795;
public const uint GL_OP_SUB_EXT = 0x8796;
public const uint GL_OP_CROSS_PRODUCT_EXT = 0x8797;
public const uint GL_OP_MULTIPLY_MATRIX_EXT = 0x8798;
public const uint GL_OP_MOV_EXT = 0x8799;
public const uint GL_OUTPUT_VERTEX_EXT = 0x879A;
public const uint GL_OUTPUT_COLOR0_EXT = 0x879B;
public const uint GL_OUTPUT_COLOR1_EXT = 0x879C;
public const uint GL_OUTPUT_TEXTURE_COORD0_EXT = 0x879D;
public const uint GL_OUTPUT_TEXTURE_COORD1_EXT = 0x879E;
public const uint GL_OUTPUT_TEXTURE_COORD2_EXT = 0x879F;
public const uint GL_OUTPUT_TEXTURE_COORD3_EXT = 0x87A0;
public const uint GL_OUTPUT_TEXTURE_COORD4_EXT = 0x87A1;
public const uint GL_OUTPUT_TEXTURE_COORD5_EXT = 0x87A2;
public const uint GL_OUTPUT_TEXTURE_COORD6_EXT = 0x87A3;
public const uint GL_OUTPUT_TEXTURE_COORD7_EXT = 0x87A4;
public const uint GL_OUTPUT_TEXTURE_COORD8_EXT = 0x87A5;
public const uint GL_OUTPUT_TEXTURE_COORD9_EXT = 0x87A6;
public const uint GL_OUTPUT_TEXTURE_COORD10_EXT = 0x87A7;
public const uint GL_OUTPUT_TEXTURE_COORD11_EXT = 0x87A8;
public const uint GL_OUTPUT_TEXTURE_COORD12_EXT = 0x87A9;
public const uint GL_OUTPUT_TEXTURE_COORD13_EXT = 0x87AA;
public const uint GL_OUTPUT_TEXTURE_COORD14_EXT = 0x87AB;
public const uint GL_OUTPUT_TEXTURE_COORD15_EXT = 0x87AC;
public const uint GL_OUTPUT_TEXTURE_COORD16_EXT = 0x87AD;
public const uint GL_OUTPUT_TEXTURE_COORD17_EXT = 0x87AE;
public const uint GL_OUTPUT_TEXTURE_COORD18_EXT = 0x87AF;
public const uint GL_OUTPUT_TEXTURE_COORD19_EXT = 0x87B0;
public const uint GL_OUTPUT_TEXTURE_COORD20_EXT = 0x87B1;
public const uint GL_OUTPUT_TEXTURE_COORD21_EXT = 0x87B2;
public const uint GL_OUTPUT_TEXTURE_COORD22_EXT = 0x87B3;
public const uint GL_OUTPUT_TEXTURE_COORD23_EXT = 0x87B4;
public const uint GL_OUTPUT_TEXTURE_COORD24_EXT = 0x87B5;
public const uint GL_OUTPUT_TEXTURE_COORD25_EXT = 0x87B6;
public const uint GL_OUTPUT_TEXTURE_COORD26_EXT = 0x87B7;
public const uint GL_OUTPUT_TEXTURE_COORD27_EXT = 0x87B8;
public const uint GL_OUTPUT_TEXTURE_COORD28_EXT = 0x87B9;
public const uint GL_OUTPUT_TEXTURE_COORD29_EXT = 0x87BA;
public const uint GL_OUTPUT_TEXTURE_COORD30_EXT = 0x87BB;
public const uint GL_OUTPUT_TEXTURE_COORD31_EXT = 0x87BC;
public const uint GL_OUTPUT_FOG_EXT = 0x87BD;
public const uint GL_SCALAR_EXT = 0x87BE;
public const uint GL_VECTOR_EXT = 0x87BF;
public const uint GL_MATRIX_EXT = 0x87C0;
public const uint GL_VARIANT_EXT = 0x87C1;
public const uint GL_INVARIANT_EXT = 0x87C2;
public const uint GL_LOCAL_CONSTANT_EXT = 0x87C3;
public const uint GL_LOCAL_EXT = 0x87C4;
public const uint GL_MAX_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87C5;
public const uint GL_MAX_VERTEX_SHADER_VARIANTS_EXT = 0x87C6;
public const uint GL_MAX_VERTEX_SHADER_INVARIANTS_EXT = 0x87C7;
public const uint GL_MAX_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87C8;
public const uint GL_MAX_VERTEX_SHADER_LOCALS_EXT = 0x87C9;
public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87CA;
public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_VARIANTS_EXT = 0x87CB;
public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87CC;
public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_INVARIANTS_EXT = 0x87CD;
public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_LOCALS_EXT = 0x87CE;
public const uint GL_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87CF;
public const uint GL_VERTEX_SHADER_VARIANTS_EXT = 0x87D0;
public const uint GL_VERTEX_SHADER_INVARIANTS_EXT = 0x87D1;
public const uint GL_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87D2;
public const uint GL_VERTEX_SHADER_LOCALS_EXT = 0x87D3;
public const uint GL_VERTEX_SHADER_BINDING_EXT = 0x8781;
public const uint GL_VERTEX_SHADER_OPTIMIZED_EXT = 0x87D4;
public const uint GL_X_EXT = 0x87D5;
public const uint GL_Y_EXT = 0x87D6;
public const uint GL_Z_EXT = 0x87D7;
public const uint GL_W_EXT = 0x87D8;
public const uint GL_NEGATIVE_X_EXT = 0x87D9;
public const uint GL_NEGATIVE_Y_EXT = 0x87DA;
public const uint GL_NEGATIVE_Z_EXT = 0x87DB;
public const uint GL_NEGATIVE_W_EXT = 0x87DC;
public const uint GL_NEGATIVE_ONE_EXT = 0x87DF;
public const uint GL_NORMALIZED_RANGE_EXT = 0x87E0;
public const uint GL_FULL_RANGE_EXT = 0x87E1;
public const uint GL_CURRENT_VERTEX_EXT = 0x87E2;
public const uint GL_MVP_MATRIX_EXT = 0x87E3;
#endif

#if GL_EXT_fragment_shader
public const uint GL_FRAGMENT_SHADER_EXT = 0x8920;
public const uint GL_REG_0_EXT = 0x8921;
public const uint GL_REG_1_EXT = 0x8922;
public const uint GL_REG_2_EXT = 0x8923;
public const uint GL_REG_3_EXT = 0x8924;
public const uint GL_REG_4_EXT = 0x8925;
public const uint GL_REG_5_EXT = 0x8926;
public const uint GL_REG_6_EXT = 0x8927;
public const uint GL_REG_7_EXT = 0x8928;
public const uint GL_REG_8_EXT = 0x8929;
public const uint GL_REG_9_EXT = 0x892A;
public const uint GL_REG_10_EXT = 0x892B;
public const uint GL_REG_11_EXT = 0x892C;
public const uint GL_REG_12_EXT = 0x892D;
public const uint GL_REG_13_EXT = 0x892E;
public const uint GL_REG_14_EXT = 0x892F;
public const uint GL_REG_15_EXT = 0x8930;
public const uint GL_REG_16_EXT = 0x8931;
public const uint GL_REG_17_EXT = 0x8932;
public const uint GL_REG_18_EXT = 0x8933;
public const uint GL_REG_19_EXT = 0x8934;
public const uint GL_REG_20_EXT = 0x8935;
public const uint GL_REG_21_EXT = 0x8936;
public const uint GL_REG_22_EXT = 0x8937;
public const uint GL_REG_23_EXT = 0x8938;
public const uint GL_REG_24_EXT = 0x8939;
public const uint GL_REG_25_EXT = 0x893A;
public const uint GL_REG_26_EXT = 0x893B;
public const uint GL_REG_27_EXT = 0x893C;
public const uint GL_REG_28_EXT = 0x893D;
public const uint GL_REG_29_EXT = 0x893E;
public const uint GL_REG_30_EXT = 0x893F;
public const uint GL_REG_31_EXT = 0x8940;
public const uint GL_CON_0_EXT = 0x8941;
public const uint GL_CON_1_EXT = 0x8942;
public const uint GL_CON_2_EXT = 0x8943;
public const uint GL_CON_3_EXT = 0x8944;
public const uint GL_CON_4_EXT = 0x8945;
public const uint GL_CON_5_EXT = 0x8946;
public const uint GL_CON_6_EXT = 0x8947;
public const uint GL_CON_7_EXT = 0x8948;
public const uint GL_CON_8_EXT = 0x8949;
public const uint GL_CON_9_EXT = 0x894A;
public const uint GL_CON_10_EXT = 0x894B;
public const uint GL_CON_11_EXT = 0x894C;
public const uint GL_CON_12_EXT = 0x894D;
public const uint GL_CON_13_EXT = 0x894E;
public const uint GL_CON_14_EXT = 0x894F;
public const uint GL_CON_15_EXT = 0x8950;
public const uint GL_CON_16_EXT = 0x8951;
public const uint GL_CON_17_EXT = 0x8952;
public const uint GL_CON_18_EXT = 0x8953;
public const uint GL_CON_19_EXT = 0x8954;
public const uint GL_CON_20_EXT = 0x8955;
public const uint GL_CON_21_EXT = 0x8956;
public const uint GL_CON_22_EXT = 0x8957;
public const uint GL_CON_23_EXT = 0x8958;
public const uint GL_CON_24_EXT = 0x8959;
public const uint GL_CON_25_EXT = 0x895A;
public const uint GL_CON_26_EXT = 0x895B;
public const uint GL_CON_27_EXT = 0x895C;
public const uint GL_CON_28_EXT = 0x895D;
public const uint GL_CON_29_EXT = 0x895E;
public const uint GL_CON_30_EXT = 0x895F;
public const uint GL_CON_31_EXT = 0x8960;
public const uint GL_MOV_EXT = 0x8961;
public const uint GL_ADD_EXT = 0x8963;
public const uint GL_MUL_EXT = 0x8964;
public const uint GL_SUB_EXT = 0x8965;
public const uint GL_DOT3_EXT = 0x8966;
public const uint GL_DOT4_EXT = 0x8967;
public const uint GL_MAD_EXT = 0x8968;
public const uint GL_LERP_EXT = 0x8969;
public const uint GL_CND_EXT = 0x896A;
public const uint GL_CND0_EXT = 0x896B;
public const uint GL_DOT2_ADD_EXT = 0x896C;
public const uint GL_SECONDARY_INTERPOLATOR_EXT = 0x896D;
public const uint GL_NUM_FRAGMENT_REGISTERS_EXT = 0x896E;
public const uint GL_NUM_FRAGMENT_CONSTANTS_EXT = 0x896F;
public const uint GL_NUM_PASSES_EXT = 0x8970;
public const uint GL_NUM_INSTRUCTIONS_PER_PASS_EXT = 0x8971;
public const uint GL_NUM_INSTRUCTIONS_TOTAL_EXT = 0x8972;
public const uint GL_NUM_INPUT_INTERPOLATOR_COMPONENTS_EXT = 0x8973;
public const uint GL_NUM_LOOPBACK_COMPONENTS_EXT = 0x8974;
public const uint GL_COLOR_ALPHA_PAIRING_EXT = 0x8975;
public const uint GL_SWIZZLE_STR_EXT = 0x8976;
public const uint GL_SWIZZLE_STQ_EXT = 0x8977;
public const uint GL_SWIZZLE_STR_DR_EXT = 0x8978;
public const uint GL_SWIZZLE_STQ_DQ_EXT = 0x8979;
public const uint GL_SWIZZLE_STRQ_EXT = 0x897A;
public const uint GL_SWIZZLE_STRQ_DQ_EXT = 0x897B;
public const uint GL_RED_BIT_EXT = 0x00000001;
public const uint GL_GREEN_BIT_EXT = 0x00000002;
public const uint GL_BLUE_BIT_EXT = 0x00000004;
public const uint GL_2X_BIT_EXT = 0x00000001;
public const uint GL_4X_BIT_EXT = 0x00000002;
public const uint GL_8X_BIT_EXT = 0x00000004;
public const uint GL_HALF_BIT_EXT = 0x00000008;
public const uint GL_QUARTER_BIT_EXT = 0x00000010;
public const uint GL_EIGHTH_BIT_EXT = 0x00000020;
public const uint GL_SATURATE_BIT_EXT = 0x00000040;
public const uint GL_COMP_BIT_EXT = 0x00000002;
public const uint GL_NEGATE_BIT_EXT = 0x00000004;
public const uint GL_BIAS_BIT_EXT = 0x00000008;
#endif

#if GL_EXT_multisample
public const uint GL_MULTISAMPLE_EXT = 0x809D;
public const uint GL_SAMPLE_ALPHA_TO_MASK_EXT = 0x809E;
public const uint GL_SAMPLE_ALPHA_TO_ONE_EXT = 0x809F;
public const uint GL_SAMPLE_MASK_EXT = 0x80A0;
public const uint GL_1PASS_EXT = 0x80A1;
public const uint GL_2PASS_0_EXT = 0x80A2;
public const uint GL_2PASS_1_EXT = 0x80A3;
public const uint GL_4PASS_0_EXT = 0x80A4;
public const uint GL_4PASS_1_EXT = 0x80A5;
public const uint GL_4PASS_2_EXT = 0x80A6;
public const uint GL_4PASS_3_EXT = 0x80A7;
public const uint GL_SAMPLE_BUFFERS_EXT = 0x80A8;
public const uint GL_SAMPLES_EXT = 0x80A9;
public const uint GL_SAMPLE_MASK_VALUE_EXT = 0x80AA;
public const uint GL_SAMPLE_MASK_INVERT_EXT = 0x80AB;
public const uint GL_SAMPLE_PATTERN_EXT = 0x80AC;
#endif

#if GL_EXT_stencil_two_side
        public const uint GL_STENCIL_TEST_TWO_SIDE_EXT = 0x8910;
        public const uint GL_ACTIVE_STENCIL_FACE_EXT = 0x8911;
#endif

#if GL_EXT_depth_bounds_test
        public const uint GL_DEPTH_BOUNDS_TEST_EXT = 0x8890;
        public const uint GL_DEPTH_BOUNDS_EXT = 0x8891;
#endif

#if GL_EXT_blend_equation_separate
        public const uint GL_BLEND_EQUATION_RGB_EXT = 0x8009;
        public const uint GL_BLEND_EQUATION_ALPHA_EXT = 0x883D;
#endif

#if GL_EXT_texture_mirror_clamp
        public const uint GL_MIRROR_CLAMP_EXT = 0x8742;
        public const uint GL_MIRROR_CLAMP_TO_EDGE_EXT = 0x8743;
        public const uint GL_MIRROR_CLAMP_TO_BORDER_EXT = 0x8912;
#endif

#if GL_EXT_framebuffer_object
        public const uint GL_FRAMEBUFFER_EXT = 0x8D40;
        public const uint GL_RENDERBUFFER_EXT = 0x8D41;
        public const uint GL_STENCIL_INDEX1_EXT = 0x8D46;
        public const uint GL_STENCIL_INDEX4_EXT = 0x8D47;
        public const uint GL_STENCIL_INDEX8_EXT = 0x8D48;
        public const uint GL_STENCIL_INDEX16_EXT = 0x8D49;
        public const uint GL_RENDERBUFFER_WIDTH_EXT = 0x8D42;
        public const uint GL_RENDERBUFFER_HEIGHT_EXT = 0x8D43;
        public const uint GL_RENDERBUFFER_INTERNAL_FORMAT_EXT = 0x8D44;
        public const uint GL_RENDERBUFFER_RED_SIZE_EXT = 0x8D50;
        public const uint GL_RENDERBUFFER_GREEN_SIZE_EXT = 0x8D51;
        public const uint GL_RENDERBUFFER_BLUE_SIZE_EXT = 0x8D52;
        public const uint GL_RENDERBUFFER_ALPHA_SIZE_EXT = 0x8D53;
        public const uint GL_RENDERBUFFER_DEPTH_SIZE_EXT = 0x8D54;
        public const uint GL_RENDERBUFFER_STENCIL_SIZE_EXT = 0x8D55;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = 0x8CD0;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = 0x8CD1;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = 0x8CD2;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = 0x8CD3;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = 0x8CD4;
        public const uint GL_COLOR_ATTACHMENT0_EXT = 0x8CE0;
        public const uint GL_COLOR_ATTACHMENT1_EXT = 0x8CE1;
        public const uint GL_COLOR_ATTACHMENT2_EXT = 0x8CE2;
        public const uint GL_COLOR_ATTACHMENT3_EXT = 0x8CE3;
        public const uint GL_COLOR_ATTACHMENT4_EXT = 0x8CE4;
        public const uint GL_COLOR_ATTACHMENT5_EXT = 0x8CE5;
        public const uint GL_COLOR_ATTACHMENT6_EXT = 0x8CE6;
        public const uint GL_COLOR_ATTACHMENT7_EXT = 0x8CE7;
        public const uint GL_COLOR_ATTACHMENT8_EXT = 0x8CE8;
        public const uint GL_COLOR_ATTACHMENT9_EXT = 0x8CE9;
        public const uint GL_COLOR_ATTACHMENT10_EXT = 0x8CEA;
        public const uint GL_COLOR_ATTACHMENT11_EXT = 0x8CEB;
        public const uint GL_COLOR_ATTACHMENT12_EXT = 0x8CEC;
        public const uint GL_COLOR_ATTACHMENT13_EXT = 0x8CED;
        public const uint GL_COLOR_ATTACHMENT14_EXT = 0x8CEE;
        public const uint GL_COLOR_ATTACHMENT15_EXT = 0x8CEF;
        public const uint GL_DEPTH_ATTACHMENT_EXT = 0x8D00;
        public const uint GL_STENCIL_ATTACHMENT_EXT = 0x8D20;
        public const uint GL_FRAMEBUFFER_COMPLETE_EXT = 0x8CD5;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = 0x8CD6;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = 0x8CD7;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = 0x8CD9;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 0x8CDA;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = 0x8CDB;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = 0x8CDC;
        public const uint GL_FRAMEBUFFER_UNSUPPORTED_EXT = 0x8CDD;
        public const uint GL_FRAMEBUFFER_BINDING_EXT = 0x8CA6;
        public const uint GL_RENDERBUFFER_BINDING_EXT = 0x8CA7;
        public const uint GL_MAX_COLOR_ATTACHMENTS_EXT = 0x8CDF;
        public const uint GL_MAX_RENDERBUFFER_SIZE_EXT = 0x84E8;
        public const uint GL_INVALID_FRAMEBUFFER_OPERATION_EXT = 0x0506;
#endif

#if GL_EXT_framebuffer_blit
        public const uint GL_READ_FRAMEBUFFER_EXT = 0x8CA8;
        public const uint GL_DRAW_FRAMEBUFFER_EXT = 0x8CA9;
        public const uint GL_DRAW_FRAMEBUFFER_BINDING_EXT = 0x8CA6;
        public const uint GL_READ_FRAMEBUFFER_BINDING_EXT = 0x8CAA;
#endif

#if GL_EXT_framebuffer_multisample
        public const uint GL_RENDERBUFFER_SAMPLES_EXT = 0x8CAB;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_EXT = 0x8D56;
        public const uint GL_MAX_SAMPLES_EXT = 0x8D57;
#endif

#if GL_ARB_framebuffer_object
        public const uint GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
        public const uint GL_FRAMEBUFFER_DEFAULT = 0x8218;
        public const uint GL_FRAMEBUFFER_UNDEFINED = 0x8219;
        public const uint GL_DEPTH_STENCIL_ATTACHMENT = 0x821A;
        public const uint GL_MAX_RENDERBUFFER_SIZE = 0x84E8;
        public const uint GL_DEPTH_STENCIL = 0x84F9;
        public const uint GL_UNSIGNED_INT_24_8 = 0x84FA;
        public const uint GL_DEPTH24_STENCIL8 = 0x88F0;
        public const uint GL_TEXTURE_STENCIL_SIZE = 0x88F1;
        public const uint GL_TEXTURE_RED_TYPE = 0x8C10;
        public const uint GL_TEXTURE_GREEN_TYPE = 0x8C11;
        public const uint GL_TEXTURE_BLUE_TYPE = 0x8C12;
        public const uint GL_TEXTURE_ALPHA_TYPE = 0x8C13;
        public const uint GL_TEXTURE_DEPTH_TYPE = 0x8C16;
        public const uint GL_UNSIGNED_NORMALIZED = 0x8C17;
        public const uint GL_FRAMEBUFFER_BINDING = 0x8CA6;
        public const uint GL_DRAW_FRAMEBUFFER_BINDING = GL_FRAMEBUFFER_BINDING;
        public const uint GL_RENDERBUFFER_BINDING = 0x8CA7;
        public const uint GL_READ_FRAMEBUFFER = 0x8CA8;
        public const uint GL_DRAW_FRAMEBUFFER = 0x8CA9;
        public const uint GL_READ_FRAMEBUFFER_BINDING = 0x8CAA;
        public const uint GL_RENDERBUFFER_SAMPLES = 0x8CAB;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
        public const uint GL_FRAMEBUFFER_COMPLETE = 0x8CD5;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC;
        public const uint GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD;
        public const uint GL_MAX_COLOR_ATTACHMENTS = 0x8CDF;
        public const uint GL_COLOR_ATTACHMENT0 = 0x8CE0;
        public const uint GL_COLOR_ATTACHMENT1 = 0x8CE1;
        public const uint GL_COLOR_ATTACHMENT2 = 0x8CE2;
        public const uint GL_COLOR_ATTACHMENT3 = 0x8CE3;
        public const uint GL_COLOR_ATTACHMENT4 = 0x8CE4;
        public const uint GL_COLOR_ATTACHMENT5 = 0x8CE5;
        public const uint GL_COLOR_ATTACHMENT6 = 0x8CE6;
        public const uint GL_COLOR_ATTACHMENT7 = 0x8CE7;
        public const uint GL_COLOR_ATTACHMENT8 = 0x8CE8;
        public const uint GL_COLOR_ATTACHMENT9 = 0x8CE9;
        public const uint GL_COLOR_ATTACHMENT10 = 0x8CEA;
        public const uint GL_COLOR_ATTACHMENT11 = 0x8CEB;
        public const uint GL_COLOR_ATTACHMENT12 = 0x8CEC;
        public const uint GL_COLOR_ATTACHMENT13 = 0x8CED;
        public const uint GL_COLOR_ATTACHMENT14 = 0x8CEE;
        public const uint GL_COLOR_ATTACHMENT15 = 0x8CEF;
        public const uint GL_DEPTH_ATTACHMENT = 0x8D00;
        public const uint GL_STENCIL_ATTACHMENT = 0x8D20;
        public const uint GL_FRAMEBUFFER = 0x8D40;
        public const uint GL_RENDERBUFFER = 0x8D41;
        public const uint GL_RENDERBUFFER_WIDTH = 0x8D42;
        public const uint GL_RENDERBUFFER_HEIGHT = 0x8D43;
        public const uint GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
        public const uint GL_STENCIL_INDEX1 = 0x8D46;
        public const uint GL_STENCIL_INDEX4 = 0x8D47;
        public const uint GL_STENCIL_INDEX8 = 0x8D48;
        public const uint GL_STENCIL_INDEX16 = 0x8D49;
        public const uint GL_RENDERBUFFER_RED_SIZE = 0x8D50;
        public const uint GL_RENDERBUFFER_GREEN_SIZE = 0x8D51;
        public const uint GL_RENDERBUFFER_BLUE_SIZE = 0x8D52;
        public const uint GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53;
        public const uint GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54;
        public const uint GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
        public const uint GL_MAX_SAMPLES = 0x8D57;
#endif


#if GL_EXT_packed_depth_stencil
        public const uint GL_DEPTH_STENCIL_EXT = 0x84F9;
        public const uint GL_UNSIGNED_INT_24_8_EXT = 0x84FA;
        public const uint GL_DEPTH24_STENCIL8_EXT = 0x88F0;
        public const uint GL_TEXTURE_STENCIL_SIZE_EXT = 0x88F1;
#endif

#if GL_EXT_geometry_shader4
        public const uint GL_GEOMETRY_SHADER_EXT = 0x8DD9;
        public const uint GL_GEOMETRY_VERTICES_OUT_EXT = 0x8DDA;
        public const uint GL_GEOMETRY_INPUT_TYPE_EXT = 0x8DDB;
        public const uint GL_GEOMETRY_OUTPUT_TYPE_EXT = 0x8DDC;
        public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT = 0x8C29;
        public const uint GL_MAX_GEOMETRY_VARYING_COMPONENTS_EXT = 0x8DDD;
        public const uint GL_MAX_VERTEX_VARYING_COMPONENTS_EXT = 0x8DDE;
        public const uint GL_MAX_VARYING_COMPONENTS_EXT = 0x8B4B;
        public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS_EXT = 0x8DDF;
        public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES_EXT = 0x8DE0;
        public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_EXT = 0x8DE1;
        public const uint GL_LINES_ADJACENCY_EXT = 0xA;
        public const uint GL_LINE_STRIP_ADJACENCY_EXT = 0xB;
        public const uint GL_TRIANGLES_ADJACENCY_EXT = 0xC;
        public const uint GL_TRIANGLE_STRIP_ADJACENCY_EXT = 0xD;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT = 0x8DA8;
        public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT = 0x8DA9;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED_EXT = 0x8DA7;
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT = 0x8CD4;
        public const uint GL_PROGRAM_POINT_SIZE_EXT = 0x8642;
#endif

#if GL_EXT_transform_feedback
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_EXT = 0x8C8E;
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START_EXT = 0x8C84;
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE_EXT = 0x8C85;
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING_EXT = 0x8C8F;
        public const uint GL_INTERLEAVED_ATTRIBS_EXT = 0x8C8C;
        public const uint GL_SEPARATE_ATTRIBS_EXT = 0x8C8D;
        public const uint GL_PRIMITIVES_GENERATED_EXT = 0x8C87;
        public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_EXT = 0x8C88;
        public const uint GL_RASTERIZER_DISCARD_EXT = 0x8C89;
        public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_EXT = 0x8C8A;
        public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_EXT = 0x8C8B;
        public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_EXT = 0x8C80;
        public const uint GL_TRANSFORM_FEEDBACK_VARYINGS_EXT = 0x8C83;
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE_EXT = 0x8C7F;
        public const uint GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH_EXT = 0x8C76;
#endif

#if GL_EXT_bindable_uniform
        public const uint GL_MAX_VERTEX_BINDABLE_UNIFORMS_EXT = 0x8DE2;
        public const uint GL_MAX_FRAGMENT_BINDABLE_UNIFORMS_EXT = 0x8DE3;
        public const uint GL_MAX_GEOMETRY_BINDABLE_UNIFORMS_EXT = 0x8DE4;
        public const uint GL_MAX_BINDABLE_UNIFORM_SIZE_EXT = 0x8DED;
        public const uint GL_UNIFORM_BUFFER_BINDING_EXT = 0x8DEF;
        public const uint GL_UNIFORM_BUFFER_EXT = 0x8DEE;
#endif

#if GL_EXT_texture_integer
        public const uint GL_RGBA_INTEGER_MODE_EXT = 0x8D9E;
        public const uint GL_RGBA32UI_EXT = 0x8D70;
        public const uint GL_RGB32UI_EXT = 0x8D71;
        public const uint GL_ALPHA32UI_EXT = 0x8D72;
        public const uint GL_INTENSITY32UI_EXT = 0x8D73;
        public const uint GL_LUMINANCE32UI_EXT = 0x8D74;
        public const uint GL_LUMINANCE_ALPHA32UI_EXT = 0x8D75;
        public const uint GL_RGBA16UI_EXT = 0x8D76;
        public const uint GL_RGB16UI_EXT = 0x8D77;
        public const uint GL_ALPHA16UI_EXT = 0x8D78;
        public const uint GL_INTENSITY16UI_EXT = 0x8D79;
        public const uint GL_LUMINANCE16UI_EXT = 0x8D7A;
        public const uint GL_LUMINANCE_ALPHA16UI_EXT = 0x8D7B;
        public const uint GL_RGBA8UI_EXT = 0x8D7C;
        public const uint GL_RGB8UI_EXT = 0x8D7D;
        public const uint GL_ALPHA8UI_EXT = 0x8D7E;
        public const uint GL_INTENSITY8UI_EXT = 0x8D7F;
        public const uint GL_LUMINANCE8UI_EXT = 0x8D80;
        public const uint GL_LUMINANCE_ALPHA8UI_EXT = 0x8D81;
        public const uint GL_RGBA32I_EXT = 0x8D82;
        public const uint GL_RGB32I_EXT = 0x8D83;
        public const uint GL_ALPHA32I_EXT = 0x8D84;
        public const uint GL_INTENSITY32I_EXT = 0x8D85;
        public const uint GL_LUMINANCE32I_EXT = 0x8D86;
        public const uint GL_LUMINANCE_ALPHA32I_EXT = 0x8D87;
        public const uint GL_RGBA16I_EXT = 0x8D88;
        public const uint GL_RGB16I_EXT = 0x8D89;
        public const uint GL_ALPHA16I_EXT = 0x8D8A;
        public const uint GL_INTENSITY16I_EXT = 0x8D8B;
        public const uint GL_LUMINANCE16I_EXT = 0x8D8C;
        public const uint GL_LUMINANCE_ALPHA16I_EXT = 0x8D8D;
        public const uint GL_RGBA8I_EXT = 0x8D8E;
        public const uint GL_RGB8I_EXT = 0x8D8F;
        public const uint GL_ALPHA8I_EXT = 0x8D90;
        public const uint GL_INTENSITY8I_EXT = 0x8D91;
        public const uint GL_LUMINANCE8I_EXT = 0x8D92;
        public const uint GL_LUMINANCE_ALPHA8I_EXT = 0x8D93;
        public const uint GL_RED_INTEGER_EXT = 0x8D94;
        public const uint GL_GREEN_INTEGER_EXT = 0x8D95;
        public const uint GL_BLUE_INTEGER_EXT = 0x8D96;
        public const uint GL_ALPHA_INTEGER_EXT = 0x8D97;
        public const uint GL_RGB_INTEGER_EXT = 0x8D98;
        public const uint GL_RGBA_INTEGER_EXT = 0x8D99;
        public const uint GL_BGR_INTEGER_EXT = 0x8D9A;
        public const uint GL_BGRA_INTEGER_EXT = 0x8D9B;
        public const uint GL_LUMINANCE_INTEGER_EXT = 0x8D9C;
        public const uint GL_LUMINANCE_ALPHA_INTEGER_EXT = 0x8D9D;
#endif

#if GL_EXT_texture_array
        public const uint GL_TEXTURE_1D_ARRAY_EXT = 0x8C18;
        public const uint GL_PROXY_TEXTURE_1D_ARRAY_EXT = 0x8C19;
        public const uint GL_TEXTURE_2D_ARRAY_EXT = 0x8C1A;
        public const uint GL_PROXY_TEXTURE_2D_ARRAY_EXT = 0x8C1B;
        public const uint GL_TEXTURE_BINDING_1D_ARRAY_EXT = 0x8C1C;
        public const uint GL_TEXTURE_BINDING_2D_ARRAY_EXT = 0x8C1D;
        public const uint GL_MAX_ARRAY_TEXTURE_LAYERS_EXT = 0x88FF;
        public const uint GL_COMPARE_REF_DEPTH_TO_TEXTURE_EXT = 0x884E;
        /* reuse GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT */
        /* reuse GL_SAMPLER_1D_ARRAY_EXT */
        /* reuse GL_SAMPLER_2D_ARRAY_EXT */
        /* reuse GL_SAMPLER_1D_ARRAY_SHADOW_EXT */
        /* reuse GL_SAMPLER_2D_ARRAY_SHADOW_EXT */
#endif

#if GL_EXT_gpu_shader4
        public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER_EXT = 0x88FD;
        public const uint GL_SAMPLER_1D_ARRAY_EXT = 0x8DC0;
        public const uint GL_SAMPLER_2D_ARRAY_EXT = 0x8DC1;
        public const uint GL_SAMPLER_BUFFER_EXT = 0x8DC2;
        public const uint GL_SAMPLER_1D_ARRAY_SHADOW_EXT = 0x8DC3;
        public const uint GL_SAMPLER_2D_ARRAY_SHADOW_EXT = 0x8DC4;
        public const uint GL_SAMPLER_CUBE_SHADOW_EXT = 0x8DC5;
        public const uint GL_UNSIGNED_INT_VEC2_EXT = 0x8DC6;
        public const uint GL_UNSIGNED_INT_VEC3_EXT = 0x8DC7;
        public const uint GL_UNSIGNED_INT_VEC4_EXT = 0x8DC8;
        public const uint GL_INT_SAMPLER_1D_EXT = 0x8DC9;
        public const uint GL_INT_SAMPLER_2D_EXT = 0x8DCA;
        public const uint GL_INT_SAMPLER_3D_EXT = 0x8DCB;
        public const uint GL_INT_SAMPLER_CUBE_EXT = 0x8DCC;
        public const uint GL_INT_SAMPLER_2D_RECT_EXT = 0x8DCD;
        public const uint GL_INT_SAMPLER_1D_ARRAY_EXT = 0x8DCE;
        public const uint GL_INT_SAMPLER_2D_ARRAY_EXT = 0x8DCF;
        public const uint GL_INT_SAMPLER_BUFFER_EXT = 0x8DD0;
        public const uint GL_UNSIGNED_INT_SAMPLER_1D_EXT = 0x8DD1;
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_EXT = 0x8DD2;
        public const uint GL_UNSIGNED_INT_SAMPLER_3D_EXT = 0x8DD3;
        public const uint GL_UNSIGNED_INT_SAMPLER_CUBE_EXT = 0x8DD4;
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_RECT_EXT = 0x8DD5;
        public const uint GL_UNSIGNED_INT_SAMPLER_1D_ARRAY_EXT = 0x8DD6;
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_ARRAY_EXT = 0x8DD7;
        public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER_EXT = 0x8DD8;
        public const uint GL_MIN_PROGRAM_TEXEL_OFFSET_EXT = 0x8904;
        public const uint GL_MAX_PROGRAM_TEXEL_OFFSET_EXT = 0x8905;
#endif

#if GL_EXT_provoking_vertex
        public const uint GL_FIRST_VERTEX_CONVENTION_EXT = 0x8E4D;
        public const uint GL_LAST_VERTEX_CONVENTION_EXT = 0x8E4E;
        public const uint GL_PROVOKING_VERTEX_EXT = 0x8E4F;
        public const uint GL_QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION_EXT = 0x8E4C;
#endif

#if GL_EXT_vertex_array_bgra
        //public const uint GL_BGRA = 0x80E1;
#endif

#if GL_EXT_framebuffer_sRGB
        public const uint GL_FRAMEBUFFER_SRGB_EXT = 0x8DB9;
        public const uint GL_FRAMEBUFFER_SRGB_CAPABLE_EXT = 0x8DBA;
#endif

#if GL_EXT_packed_float
        public const uint GL_R11F_G11F_B10F_EXT = 0x8C3A;
        public const uint GL_UNSIGNED_INT_10F_11F_11F_REV_EXT = 0x8C3B;
        public const uint GL_RGBA_SIGNED_COMPONENTS_EXT = 0x8C3C;
#endif

#if GL_EXT_texture_shared_exponent
        public const uint GL_RGB9_E5_EXT = 0x8C3D;
        public const uint GL_UNSIGNED_INT_5_9_9_9_REV_EXT = 0x8C3E;
        public const uint GL_TEXTURE_SHARED_SIZE_EXT = 0x8C3F;
#endif

#if GL_APPLE_vertex_array_range
        public const uint GL_VERTEX_ARRAY_RANGE_APPLE = 0x851D;
        public const uint GL_VERTEX_ARRAY_RANGE_LENGTH_APPLE = 0x851E;
        public const uint GL_MAX_VERTEX_ARRAY_RANGE_ELEMENT_APPLE = 0x8520;
        public const uint GL_VERTEX_ARRAY_RANGE_POINTER_APPLE = 0x8521;
        public const uint GL_VERTEX_ARRAY_STORAGE_HINT_APPLE = 0x851F;
        public const uint GL_STORAGE_CLIENT_APPLE = 0x85B4;
        public const uint GL_STORAGE_PRIVATE_APPLE = 0x85BD;
        public const uint GL_STORAGE_CACHED_APPLE = 0x85BE;
        public const uint GL_STORAGE_SHARED_APPLE = 0x85BF;
#endif

#if GL_APPLE_vertex_array_object
        public const uint GL_VERTEX_ARRAY_BINDING_APPLE = 0x85B5;
#endif

#if GL_APPLE_element_array
        public const uint GL_ELEMENT_ARRAY_APPLE = 0x8A0C;
        public const uint GL_ELEMENT_ARRAY_TYPE_APPLE = 0x8A0D;
        public const uint GL_ELEMENT_ARRAY_POINTER_APPLE = 0x8A0E;
#endif

#if GL_APPLE_fence
        public const uint GL_DRAW_PIXELS_APPLE = 0x8A0A;
        public const uint GL_FENCE_APPLE = 0x8A0B;
        public const uint GL_BUFFER_OBJECT_APPLE = 0x85B3;
#endif

#if GL_APPLE_specular_vector
        public const uint GL_LIGHT_MODEL_SPECULAR_VECTOR_APPLE = 0x85B0;
#endif

#if GL_APPLE_transform_hint
        public const uint GL_TRANSFORM_HINT_APPLE = 0x85B1;
#endif

#if GL_APPLE_client_storage
        public const uint GL_UNPACK_CLIENT_STORAGE_APPLE = 0x85B2;
#endif

#if GL_APPLE_ycbcr_422
        public const uint GL_YCBCR_422_APPLE = 0x85B9;
#endif

#if GL_APPLE_rgb_422
        public const uint GL_RGB_422_APPLE = 0x8A1F;
#endif

#if GL_APPLE_ycbcr_422 || GL_APPLE_rgb_422
        public const uint GL_UNSIGNED_SHORT_8_8_APPLE = 0x85BA;
        public const uint GL_UNSIGNED_SHORT_8_8_REV_APPLE = 0x85BB;
#endif

#if GL_APPLE_texture_range
        public const uint GL_TEXTURE_RANGE_LENGTH_APPLE = 0x85B7;
        public const uint GL_TEXTURE_RANGE_POINTER_APPLE = 0x85B8;
        public const uint GL_TEXTURE_STORAGE_HINT_APPLE = 0x85BC;
        public const uint GL_TEXTURE_MINIMIZE_STORAGE_APPLE = 0x85B6;
        //public const uint GL_STORAGE_PRIVATE_APPLE = 0x85BD;
        //public const uint GL_STORAGE_CACHED_APPLE = 0x85BE;
        //public const uint GL_STORAGE_SHARED_APPLE = 0x85BF;
#endif

#if GL_APPLE_float_pixels
        public const uint GL_HALF_APPLE = 0x140B;
        public const uint GL_COLOR_FLOAT_APPLE = 0x8A0F;
        public const uint GL_RGBA_FLOAT32_APPLE = 0x8814;
        public const uint GL_RGB_FLOAT32_APPLE = 0x8815;
        public const uint GL_ALPHA_FLOAT32_APPLE = 0x8816;
        public const uint GL_INTENSITY_FLOAT32_APPLE = 0x8817;
        public const uint GL_LUMINANCE_FLOAT32_APPLE = 0x8818;
        public const uint GL_LUMINANCE_ALPHA_FLOAT32_APPLE = 0x8819;
        public const uint GL_RGBA_FLOAT16_APPLE = 0x881A;
        public const uint GL_RGB_FLOAT16_APPLE = 0x881B;
        public const uint GL_ALPHA_FLOAT16_APPLE = 0x881C;
        public const uint GL_INTENSITY_FLOAT16_APPLE = 0x881D;
        public const uint GL_LUMINANCE_FLOAT16_APPLE = 0x881E;
        public const uint GL_LUMINANCE_ALPHA_FLOAT16_APPLE = 0x881F;
#endif

#if GL_APPLE_pixel_buffer
        public const uint GL_MIN_PBUFFER_VIEWPORT_DIMS_APPLE = 0x8A10;
#endif

#if GL_APPLE_vertex_program_evaluators
        public const uint GL_VERTEX_ATTRIB_MAP1_APPLE = 0x8A00;
        public const uint GL_VERTEX_ATTRIB_MAP2_APPLE = 0x8A01;
        public const uint GL_VERTEX_ATTRIB_MAP1_SIZE_APPLE = 0x8A02;
        public const uint GL_VERTEX_ATTRIB_MAP1_COEFF_APPLE = 0x8A03;
        public const uint GL_VERTEX_ATTRIB_MAP1_ORDER_APPLE = 0x8A04;
        public const uint GL_VERTEX_ATTRIB_MAP1_DOMAIN_APPLE = 0x8A05;
        public const uint GL_VERTEX_ATTRIB_MAP2_SIZE_APPLE = 0x8A06;
        public const uint GL_VERTEX_ATTRIB_MAP2_COEFF_APPLE = 0x8A07;
        public const uint GL_VERTEX_ATTRIB_MAP2_ORDER_APPLE = 0x8A08;
        public const uint GL_VERTEX_ATTRIB_MAP2_DOMAIN_APPLE = 0x8A09;
#endif

#if GL_APPLE_flush_buffer_range
        public const uint GL_BUFFER_SERIALIZED_MODIFY_APPLE = 0x8A12;
        public const uint GL_BUFFER_FLUSHING_UNMAP_APPLE = 0x8A13;
#endif

#if GL_APPLE_aux_depth_stencil
        public const uint GL_AUX_DEPTH_STENCIL_APPLE = 0x8A14;
#endif

#if GL_APPLE_row_bytes
        public const uint GL_PACK_ROW_BYTES_APPLE = 0x8A15;
        public const uint GL_UNPACK_ROW_BYTES_APPLE = 0x8A16;
        public const uint GL_PACK_IMAGE_BYTES_APPLE = 0x8A17;
        public const uint GL_UNPACK_IMAGE_BYTES_APPLE = 0x8A18;
#endif

#if GL_APPLE_object_purgeable
        public const uint GL_RELEASED_APPLE = 0x8A19;
        public const uint GL_VOLATILE_APPLE = 0x8A1A;
        public const uint GL_RETAINED_APPLE = 0x8A1B;
        public const uint GL_UNDEFINED_APPLE = 0x8A1C;
        public const uint GL_PURGEABLE_APPLE = 0x8A1D;
#endif

#if GL_APPLE_vertex_point_size
public const uint GL_VERTEX_POINT_SIZE_APPLE = 0x8A26;
public const uint GL_CURRENT_POINT_SIZE_APPLE = 0x8A27;
public const uint GL_POINT_SIZE_ARRAY_APPLE = 0x8B9C;
public const uint GL_POINT_SIZE_ARRAY_TYPE_APPLE = 0x898A;
public const uint GL_POINT_SIZE_ARRAY_STRIDE_APPLE = 0x898B;
public const uint GL_POINT_SIZE_ARRAY_POINTER_APPLE = 0x898C;
public const uint GL_POINT_SIZE_ARRAY_BUFFER_BINDING_APPLE = 0x8B9F;
#endif

#if GL_ATI_blend_weighted_minmax
        public const uint GL_MIN_WEIGHTED_ATI = 0x877D;
        public const uint GL_MAX_WEIGHTED_ATI = 0x877E;
#endif

#if GL_ATI_texture_env_combine3
        public const uint GL_MODULATE_ADD_ATI = 0x8744;
        public const uint GL_MODULATE_SIGNED_ADD_ATI = 0x8745;
        public const uint GL_MODULATE_SUBTRACT_ATI = 0x8746;
#endif

#if GL_ATI_separate_stencil
        public const uint GL_STENCIL_BACK_FUNC_ATI = 0x8800;
        public const uint GL_STENCIL_BACK_FAIL_ATI = 0x8801;
        public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL_ATI = 0x8802;
        public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS_ATI = 0x8803;
#endif

#if GL_ATI_array_rev_comps_in_4_bytes
public const uint GL_ARRAY_REV_COMPS_IN_4_BYTES_ATI = 0x897C;
#endif

#if GL_ATI_texture_mirror_once
        public const uint GL_MIRROR_CLAMP_ATI = 0x8742;
        public const uint GL_MIRROR_CLAMP_TO_EDGE_ATI = 0x8743;
#endif

#if GL_ATI_pn_triangles
        public const uint GL_PN_TRIANGLES_ATI = 0x6090;
        public const uint GL_MAX_PN_TRIANGLES_TESSELATION_LEVEL_ATI = 0x6091;
        public const uint GL_PN_TRIANGLES_POINT_MODE_ATI = 0x6092;
        public const uint GL_PN_TRIANGLES_NORMAL_MODE_ATI = 0x6093;
        public const uint GL_PN_TRIANGLES_TESSELATION_LEVEL_ATI = 0x6094;
        public const uint GL_PN_TRIANGLES_POINT_MODE_LINEAR_ATI = 0x6095;
        public const uint GL_PN_TRIANGLES_POINT_MODE_CUBIC_ATI = 0x6096;
        public const uint GL_PN_TRIANGLES_NORMAL_MODE_LINEAR_ATI = 0x6097;
        public const uint GL_PN_TRIANGLES_NORMAL_MODE_QUADRATIC_ATI = 0x6098;
#endif

#if GL_ATI_text_fragment_shader
public const uint GL_TEXT_FRAGMENT_SHADER_ATI = 0x8200;
#endif

#if GL_ATI_blend_equation_separate
        public const uint GL_ALPHA_BLEND_EQUATION_ATI = 0x883D;
#endif

#if GL_ATI_point_cull_mode
        public const uint GL_POINT_CULL_MODE_ATI = 0x60B3;
        public const uint GL_POINT_CULL_CENTER_ATI = 0x60B4;
        public const uint GL_POINT_CULL_CLIP_ATI = 0x60B5;
#endif

#if GL_ATIX_pn_triangles
        public const uint GL_PN_TRIANGLES_ATIX = 0x6090;
        public const uint GL_MAX_PN_TRIANGLES_TESSELATION_LEVEL_ATIX = 0x6091;
        public const uint GL_PN_TRIANGLES_POINT_MODE_ATIX = 0x6092;
        public const uint GL_PN_TRIANGLES_NORMAL_MODE_ATIX = 0x6093;
        public const uint GL_PN_TRIANGLES_TESSELATION_LEVEL_ATIX = 0x6094;
        public const uint GL_PN_TRIANGLES_POINT_MODE_LINEAR_ATIX = 0x6095;
        public const uint GL_PN_TRIANGLES_POINT_MODE_CUBIC_ATIX = 0x6096;
        public const uint GL_PN_TRIANGLES_NORMAL_MODE_LINEAR_ATIX = 0x6097;
        public const uint GL_PN_TRIANGLES_NORMAL_MODE_QUADRATIC_ATIX = 0x6098;
#endif

#if GL_ATI_texture_compression_3dc
        public const uint GL_COMPRESSED_LUMINANCE_ALPHA_3DC_ATI = 0x8837;
#endif

#if GL_ARB_texture_compression_rgtc
        public const uint GL_COMPRESSED_RED_RGTC1 = 0x8DBB;
        public const uint GL_COMPRESSED_SIGNED_RED_RGTC1 = 0x8DBC;
        public const uint GL_COMPRESSED_RG_RGTC2 = 0x8DBD;
        public const uint GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE;
#endif

#if GL_ATI_texture_float
        public const uint GL_RGBA_FLOAT32_ATI = 0x8814;
        public const uint GL_RGB_FLOAT32_ATI = 0x8815;
        public const uint GL_ALPHA_FLOAT32_ATI = 0x8816;
        public const uint GL_INTENSITY_FLOAT32_ATI = 0x8817;
        public const uint GL_LUMINANCE_FLOAT32_ATI = 0x8818;
        public const uint GL_LUMINANCE_ALPHA_FLOAT32_ATI = 0x8819;
        public const uint GL_RGBA_FLOAT16_ATI = 0x881A;
        public const uint GL_RGB_FLOAT16_ATI = 0x881B;
        public const uint GL_ALPHA_FLOAT16_ATI = 0x881C;
        public const uint GL_INTENSITY_FLOAT16_ATI = 0x881D;
        public const uint GL_LUMINANCE_FLOAT16_ATI = 0x881E;
        public const uint GL_LUMINANCE_ALPHA_FLOAT16_ATI = 0x881F;
#endif


#if GL_HP_image_transform
public const uint GL_IMAGE_SCALE_X_HP = 0x8155;
public const uint GL_IMAGE_SCALE_Y_HP = 0x8156;
public const uint GL_IMAGE_TRANSLATE_X_HP = 0x8157;
public const uint GL_IMAGE_TRANSLATE_Y_HP = 0x8158;
public const uint GL_IMAGE_ROTATE_ANGLE_HP = 0x8159;
public const uint GL_IMAGE_ROTATE_ORIGIN_X_HP = 0x815A;
public const uint GL_IMAGE_ROTATE_ORIGIN_Y_HP = 0x815B;
public const uint GL_IMAGE_MAG_FILTER_HP = 0x815C;
public const uint GL_IMAGE_MIN_FILTER_HP = 0x815D;
public const uint GL_IMAGE_CUBIC_WEIGHT_HP = 0x815E;
public const uint GL_CUBIC_HP = 0x815F;
public const uint GL_AVERAGE_HP = 0x8160;
public const uint GL_IMAGE_TRANSFORM_2D_HP = 0x8161;
public const uint GL_POST_IMAGE_TRANSFORM_COLOR_TABLE_HP = 0x8162;
public const uint GL_PROXY_POST_IMAGE_TRANSFORM_COLOR_TABLE_HP = 0x8163;
#endif

#if GL_HP_convolution_border_modes
public const uint GL_IGNORE_BORDER_HP = 0x8150;
public const uint GL_CONSTANT_BORDER_HP = 0x8151;
public const uint GL_REPLICATE_BORDER_HP = 0x8153;
public const uint GL_CONVOLUTION_BORDER_COLOR_HP = 0x8154;
#endif

#if GL_HP_texture_lighting
public const uint GL_TEXTURE_LIGHTING_MODE_HP = 0x8167;
public const uint GL_TEXTURE_POST_SPECULAR_HP = 0x8168;
public const uint GL_TEXTURE_PRE_SPECULAR_HP = 0x8169;
#endif

#if GL_HP_occlusion_test
public const uint GL_OCCLUSION_TEST_HP = 0x8165;
public const uint GL_OCCLUSION_TEST_RESULT_HP = 0x8166;
#endif


#if GL_IBM_rasterpos_clip
        public const uint GL_RASTER_POSITION_UNCLIPPED_IBM = 0x19262;
#endif

#if GL_IBM_cull_vertex
public const uint GL_CULL_VERTEX_IBM = 103050;
#endif

#if GL_IBM_vertex_array_lists
public const uint GL_VERTEX_ARRAY_LIST_IBM = 103070;
public const uint GL_NORMAL_ARRAY_LIST_IBM = 103071;
public const uint GL_COLOR_ARRAY_LIST_IBM = 103072;
public const uint GL_INDEX_ARRAY_LIST_IBM = 103073;
public const uint GL_TEXTURE_COORD_ARRAY_LIST_IBM = 103074;
public const uint GL_EDGE_FLAG_ARRAY_LIST_IBM = 103075;
public const uint GL_FOG_COORDINATE_ARRAY_LIST_IBM = 103076;
public const uint GL_SECONDARY_COLOR_ARRAY_LIST_IBM = 103077;
public const uint GL_VERTEX_ARRAY_LIST_STRIDE_IBM = 103080;
public const uint GL_NORMAL_ARRAY_LIST_STRIDE_IBM = 103081;
public const uint GL_COLOR_ARRAY_LIST_STRIDE_IBM = 103082;
public const uint GL_INDEX_ARRAY_LIST_STRIDE_IBM = 103083;
public const uint GL_TEXTURE_COORD_ARRAY_LIST_STRIDE_IBM = 103084;
public const uint GL_EDGE_FLAG_ARRAY_LIST_STRIDE_IBM = 103085;
public const uint GL_FOG_COORDINATE_ARRAY_LIST_STRIDE_IBM = 103086;
public const uint GL_SECONDARY_COLOR_ARRAY_LIST_STRIDE_IBM = 103087;
#endif


#if GL_INGR_color_clamp
public const uint GL_RED_MIN_CLAMP_INGR = 0x8560;
public const uint GL_GREEN_MIN_CLAMP_INGR = 0x8561;
public const uint GL_BLUE_MIN_CLAMP_INGR = 0x8562;
public const uint GL_ALPHA_MIN_CLAMP_INGR = 0x8563;
public const uint GL_RED_MAX_CLAMP_INGR = 0x8564;
public const uint GL_GREEN_MAX_CLAMP_INGR = 0x8565;
public const uint GL_BLUE_MAX_CLAMP_INGR = 0x8566;
public const uint GL_ALPHA_MAX_CLAMP_INGR = 0x8567;
#endif

#if GL_INGR_interlace_read
public const uint GL_INTERLACE_READ_INGR = 0x8568;
#endif


#if GL_INTEL_parallel_arrays
public const uint GL_PARALLEL_ARRAYS_INTEL = 0x83F4;
public const uint GL_VERTEX_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F5;
public const uint GL_NORMAL_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F6;
public const uint GL_COLOR_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F7;
public const uint GL_TEXTURE_COORD_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F8;
#endif


#if GL_NV_texgen_reflection
        public const uint GL_NORMAL_MAP_NV = 0x8511;
        public const uint GL_REFLECTION_MAP_NV = 0x8512;
#endif

#if GL_NV_light_max_exponent
        public const uint GL_MAX_SHININESS_NV = 0x8504;
        public const uint GL_MAX_SPOT_EXPONENT_NV = 0x8505;
#endif

#if GL_NV_vertex_array_range
public const uint GL_VERTEX_ARRAY_RANGE_NV = 0x851D;
public const uint GL_VERTEX_ARRAY_RANGE_LENGTH_NV = 0x851E;
public const uint GL_VERTEX_ARRAY_RANGE_VALID_NV = 0x851F;
public const uint GL_MAX_VERTEX_ARRAY_RANGE_ELEMENT_NV = 0x8520;
public const uint GL_VERTEX_ARRAY_RANGE_POINTER_NV = 0x8521;
#endif

#if GL_NV_vertex_array_range2
public const uint GL_VERTEX_ARRAY_RANGE_WITHOUT_FLUSH_NV = 0x8533;
#endif

#if GL_NV_register_combiners
public const uint GL_REGISTER_COMBINERS_NV = 0x8522;
public const uint GL_VARIABLE_A_NV = 0x8523;
public const uint GL_VARIABLE_B_NV = 0x8524;
public const uint GL_VARIABLE_C_NV = 0x8525;
public const uint GL_VARIABLE_D_NV = 0x8526;
public const uint GL_VARIABLE_E_NV = 0x8527;
public const uint GL_VARIABLE_F_NV = 0x8528;
public const uint GL_VARIABLE_G_NV = 0x8529;
public const uint GL_CONSTANT_COLOR0_NV = 0x852A;
public const uint GL_CONSTANT_COLOR1_NV = 0x852B;
public const uint GL_PRIMARY_COLOR_NV = 0x852C;
public const uint GL_SECONDARY_COLOR_NV = 0x852D;
public const uint GL_SPARE0_NV = 0x852E;
public const uint GL_SPARE1_NV = 0x852F;
public const uint GL_DISCARD_NV = 0x8530;
public const uint GL_E_TIMES_F_NV = 0x8531;
public const uint GL_SPARE0_PLUS_SECONDARY_COLOR_NV = 0x8532;
public const uint GL_UNSIGNED_IDENTITY_NV = 0x8536;
public const uint GL_UNSIGNED_INVERT_NV = 0x8537;
public const uint GL_EXPAND_NORMAL_NV = 0x8538;
public const uint GL_EXPAND_NEGATE_NV = 0x8539;
public const uint GL_HALF_BIAS_NORMAL_NV = 0x853A;
public const uint GL_HALF_BIAS_NEGATE_NV = 0x853B;
public const uint GL_SIGNED_IDENTITY_NV = 0x853C;
public const uint GL_SIGNED_NEGATE_NV = 0x853D;
public const uint GL_SCALE_BY_TWO_NV = 0x853E;
public const uint GL_SCALE_BY_FOUR_NV = 0x853F;
public const uint GL_SCALE_BY_ONE_HALF_NV = 0x8540;
public const uint GL_BIAS_BY_NEGATIVE_ONE_HALF_NV = 0x8541;
public const uint GL_COMBINER_INPUT_NV = 0x8542;
public const uint GL_COMBINER_MAPPING_NV = 0x8543;
public const uint GL_COMBINER_COMPONENT_USAGE_NV = 0x8544;
public const uint GL_COMBINER_AB_DOT_PRODUCT_NV = 0x8545;
public const uint GL_COMBINER_CD_DOT_PRODUCT_NV = 0x8546;
public const uint GL_COMBINER_MUX_SUM_NV = 0x8547;
public const uint GL_COMBINER_SCALE_NV = 0x8548;
public const uint GL_COMBINER_BIAS_NV = 0x8549;
public const uint GL_COMBINER_AB_OUTPUT_NV = 0x854A;
public const uint GL_COMBINER_CD_OUTPUT_NV = 0x854B;
public const uint GL_COMBINER_SUM_OUTPUT_NV = 0x854C;
public const uint GL_MAX_GENERAL_COMBINERS_NV = 0x854D;
public const uint GL_NUM_GENERAL_COMBINERS_NV = 0x854E;
public const uint GL_COLOR_SUM_CLAMP_NV = 0x854F;
public const uint GL_COMBINER0_NV = 0x8550;
public const uint GL_COMBINER1_NV = 0x8551;
public const uint GL_COMBINER2_NV = 0x8552;
public const uint GL_COMBINER3_NV = 0x8553;
public const uint GL_COMBINER4_NV = 0x8554;
public const uint GL_COMBINER5_NV = 0x8555;
public const uint GL_COMBINER6_NV = 0x8556;
public const uint GL_COMBINER7_NV = 0x8557;
/* reuse GL_TEXTURE0_ARB */
/* reuse GL_TEXTURE1_ARB */
/* reuse GL_ZERO */
/* reuse GL_NONE */
/* reuse GL_FOG */
#endif

#if GL_NV_register_combiners2
public const uint GL_PER_STAGE_CONSTANTS_NV = 0x8535;
#endif

#if GL_NV_fog_distance
        public const uint GL_FOG_DISTANCE_MODE_NV = 0x855A;
        public const uint GL_EYE_RADIAL_NV = 0x855B;
        public const uint GL_EYE_PLANE_ABSOLUTE_NV = 0x855C;
        /* reuse GL_EYE_PLANE */
#endif

#if GL_NV_texgen_emboss
public const uint GL_EMBOSS_LIGHT_NV = 0x855D;
public const uint GL_EMBOSS_CONSTANT_NV = 0x855E;
public const uint GL_EMBOSS_MAP_NV = 0x855F;
#endif

#if GL_NV_vertex_program
public const uint GL_VERTEX_PROGRAM_NV = 0x8620;
public const uint GL_VERTEX_STATE_PROGRAM_NV = 0x8621;
public const uint GL_ATTRIB_ARRAY_SIZE_NV = 0x8623;
public const uint GL_ATTRIB_ARRAY_STRIDE_NV = 0x8624;
public const uint GL_ATTRIB_ARRAY_TYPE_NV = 0x8625;
public const uint GL_CURRENT_ATTRIB_NV = 0x8626;
public const uint GL_PROGRAM_LENGTH_NV = 0x8627;
public const uint GL_PROGRAM_STRING_NV = 0x8628;
public const uint GL_MODELVIEW_PROJECTION_NV = 0x8629;
public const uint GL_IDENTITY_NV = 0x862A;
public const uint GL_INVERSE_NV = 0x862B;
public const uint GL_TRANSPOSE_NV = 0x862C;
public const uint GL_INVERSE_TRANSPOSE_NV = 0x862D;
public const uint GL_MAX_TRACK_MATRIX_STACK_DEPTH_NV = 0x862E;
public const uint GL_MAX_TRACK_MATRICES_NV = 0x862F;
public const uint GL_MATRIX0_NV = 0x8630;
public const uint GL_MATRIX1_NV = 0x8631;
public const uint GL_MATRIX2_NV = 0x8632;
public const uint GL_MATRIX3_NV = 0x8633;
public const uint GL_MATRIX4_NV = 0x8634;
public const uint GL_MATRIX5_NV = 0x8635;
public const uint GL_MATRIX6_NV = 0x8636;
public const uint GL_MATRIX7_NV = 0x8637;
public const uint GL_CURRENT_MATRIX_STACK_DEPTH_NV = 0x8640;
public const uint GL_CURRENT_MATRIX_NV = 0x8641;
public const uint GL_VERTEX_PROGRAM_POINT_SIZE_NV = 0x8642;
public const uint GL_VERTEX_PROGRAM_TWO_SIDE_NV = 0x8643;
public const uint GL_PROGRAM_PARAMETER_NV = 0x8644;
public const uint GL_ATTRIB_ARRAY_POINTER_NV = 0x8645;
public const uint GL_PROGRAM_TARGET_NV = 0x8646;
public const uint GL_PROGRAM_RESIDENT_NV = 0x8647;
public const uint GL_TRACK_MATRIX_NV = 0x8648;
public const uint GL_TRACK_MATRIX_TRANSFORM_NV = 0x8649;
public const uint GL_VERTEX_PROGRAM_BINDING_NV = 0x864A;
public const uint GL_PROGRAM_ERROR_POSITION_NV = 0x864B;
public const uint GL_VERTEX_ATTRIB_ARRAY0_NV = 0x8650;
public const uint GL_VERTEX_ATTRIB_ARRAY1_NV = 0x8651;
public const uint GL_VERTEX_ATTRIB_ARRAY2_NV = 0x8652;
public const uint GL_VERTEX_ATTRIB_ARRAY3_NV = 0x8653;
public const uint GL_VERTEX_ATTRIB_ARRAY4_NV = 0x8654;
public const uint GL_VERTEX_ATTRIB_ARRAY5_NV = 0x8655;
public const uint GL_VERTEX_ATTRIB_ARRAY6_NV = 0x8656;
public const uint GL_VERTEX_ATTRIB_ARRAY7_NV = 0x8657;
public const uint GL_VERTEX_ATTRIB_ARRAY8_NV = 0x8658;
public const uint GL_VERTEX_ATTRIB_ARRAY9_NV = 0x8659;
public const uint GL_VERTEX_ATTRIB_ARRAY10_NV = 0x865A;
public const uint GL_VERTEX_ATTRIB_ARRAY11_NV = 0x865B;
public const uint GL_VERTEX_ATTRIB_ARRAY12_NV = 0x865C;
public const uint GL_VERTEX_ATTRIB_ARRAY13_NV = 0x865D;
public const uint GL_VERTEX_ATTRIB_ARRAY14_NV = 0x865E;
public const uint GL_VERTEX_ATTRIB_ARRAY15_NV = 0x865F;
public const uint GL_MAP1_VERTEX_ATTRIB0_4_NV = 0x8660;
public const uint GL_MAP1_VERTEX_ATTRIB1_4_NV = 0x8661;
public const uint GL_MAP1_VERTEX_ATTRIB2_4_NV = 0x8662;
public const uint GL_MAP1_VERTEX_ATTRIB3_4_NV = 0x8663;
public const uint GL_MAP1_VERTEX_ATTRIB4_4_NV = 0x8664;
public const uint GL_MAP1_VERTEX_ATTRIB5_4_NV = 0x8665;
public const uint GL_MAP1_VERTEX_ATTRIB6_4_NV = 0x8666;
public const uint GL_MAP1_VERTEX_ATTRIB7_4_NV = 0x8667;
public const uint GL_MAP1_VERTEX_ATTRIB8_4_NV = 0x8668;
public const uint GL_MAP1_VERTEX_ATTRIB9_4_NV = 0x8669;
public const uint GL_MAP1_VERTEX_ATTRIB10_4_NV = 0x866A;
public const uint GL_MAP1_VERTEX_ATTRIB11_4_NV = 0x866B;
public const uint GL_MAP1_VERTEX_ATTRIB12_4_NV = 0x866C;
public const uint GL_MAP1_VERTEX_ATTRIB13_4_NV = 0x866D;
public const uint GL_MAP1_VERTEX_ATTRIB14_4_NV = 0x866E;
public const uint GL_MAP1_VERTEX_ATTRIB15_4_NV = 0x866F;
public const uint GL_MAP2_VERTEX_ATTRIB0_4_NV = 0x8670;
public const uint GL_MAP2_VERTEX_ATTRIB1_4_NV = 0x8671;
public const uint GL_MAP2_VERTEX_ATTRIB2_4_NV = 0x8672;
public const uint GL_MAP2_VERTEX_ATTRIB3_4_NV = 0x8673;
public const uint GL_MAP2_VERTEX_ATTRIB4_4_NV = 0x8674;
public const uint GL_MAP2_VERTEX_ATTRIB5_4_NV = 0x8675;
public const uint GL_MAP2_VERTEX_ATTRIB6_4_NV = 0x8676;
public const uint GL_MAP2_VERTEX_ATTRIB7_4_NV = 0x8677;
public const uint GL_MAP2_VERTEX_ATTRIB8_4_NV = 0x8678;
public const uint GL_MAP2_VERTEX_ATTRIB9_4_NV = 0x8679;
public const uint GL_MAP2_VERTEX_ATTRIB10_4_NV = 0x867A;
public const uint GL_MAP2_VERTEX_ATTRIB11_4_NV = 0x867B;
public const uint GL_MAP2_VERTEX_ATTRIB12_4_NV = 0x867C;
public const uint GL_MAP2_VERTEX_ATTRIB13_4_NV = 0x867D;
public const uint GL_MAP2_VERTEX_ATTRIB14_4_NV = 0x867E;
public const uint GL_MAP2_VERTEX_ATTRIB15_4_NV = 0x867F;
#endif

#if GL_NV_texture_shader
public const uint GL_RGBA_UNSIGNED_DOT_PRODUCT_MAPPING_NV = 0x86D9;
public const uint GL_UNSIGNED_INT_S8_S8_8_8_NV = 0x86DA;
public const uint GL_UNSIGNED_INT_8_8_S8_S8_REV_NV = 0x86DB;
public const uint GL_DSDT_MAG_INTENSITY_NV = 0x86DC;
public const uint GL_TEXTURE_SHADER_NV = 0x86DE;
public const uint GL_SHADER_OPERATION_NV = 0x86DF;

public const uint GL_CULL_MODES_NV = 0x86E0;
public const uint GL_OFFSET_TEXTURE_MATRIX_NV = 0x86E1;
public const uint GL_OFFSET_TEXTURE_SCALE_NV = 0x86E2;
public const uint GL_OFFSET_TEXTURE_BIAS_NV = 0x86E3;
public const uint GL_OFFSET_TEXTURE_2D_MATRIX_NV = GL_OFFSET_TEXTURE_MATRIX_NV;
public const uint GL_OFFSET_TEXTURE_2D_SCALE_NV = GL_OFFSET_TEXTURE_SCALE_NV;
public const uint GL_OFFSET_TEXTURE_2D_BIAS_NV = GL_OFFSET_TEXTURE_BIAS_NV;
public const uint GL_PREVIOUS_TEXTURE_INPUT_NV = 0x86E4;
public const uint GL_CONST_EYE_NV = 0x86E5;
public const uint GL_SHADER_CONSISTENT_NV = 0x86DD;
public const uint GL_PASS_THROUGH_NV = 0x86E6;
public const uint GL_CULL_FRAGMENT_NV = 0x86E7;
public const uint GL_OFFSET_TEXTURE_2D_NV = 0x86E8;
public const uint GL_OFFSET_TEXTURE_RECTANGLE_NV = 0x864C;
public const uint GL_OFFSET_TEXTURE_RECTANGLE_SCALE_NV = 0x864D;
public const uint GL_DEPENDENT_AR_TEXTURE_2D_NV = 0x86E9;
public const uint GL_DEPENDENT_GB_TEXTURE_2D_NV = 0x86EA;
public const uint GL_DOT_PRODUCT_NV = 0x86EC;
public const uint GL_DOT_PRODUCT_DEPTH_REPLACE_NV = 0x86ED;
public const uint GL_DOT_PRODUCT_TEXTURE_2D_NV = 0x86EE;
public const uint GL_DOT_PRODUCT_TEXTURE_RECTANGLE_NV = 0x864E;
public const uint GL_DOT_PRODUCT_TEXTURE_CUBE_MAP_NV = 0x86F0;
public const uint GL_DOT_PRODUCT_DIFFUSE_CUBE_MAP_NV = 0x86F1;
public const uint GL_DOT_PRODUCT_REFLECT_CUBE_MAP_NV = 0x86F2;
public const uint GL_DOT_PRODUCT_CONST_EYE_REFLECT_CUBE_MAP_NV = 0x86F3;
public const uint GL_HILO_NV = 0x86F4;
public const uint GL_DSDT_NV = 0x86F5;
public const uint GL_DSDT_MAG_NV = 0x86F6;
public const uint GL_DSDT_MAG_VIB_NV = 0x86F7;
public const uint GL_HILO16_NV = 0x86F8;
public const uint GL_SIGNED_HILO_NV = 0x86F9;
public const uint GL_SIGNED_HILO16_NV = 0x86FA;
public const uint GL_SIGNED_RGBA_NV = 0x86FB;
public const uint GL_SIGNED_RGBA8_NV = 0x86FC;
public const uint GL_SIGNED_RGB_NV = 0x86FE;
public const uint GL_SIGNED_RGB8_NV = 0x86FF;
public const uint GL_SIGNED_LUMINANCE_NV = 0x8701;
public const uint GL_SIGNED_LUMINANCE8_NV = 0x8702;
public const uint GL_SIGNED_LUMINANCE_ALPHA_NV = 0x8703;
public const uint GL_SIGNED_LUMINANCE8_ALPHA8_NV = 0x8704;
public const uint GL_SIGNED_ALPHA_NV = 0x8705;
public const uint GL_SIGNED_ALPHA8_NV = 0x8706;
public const uint GL_SIGNED_INTENSITY_NV = 0x8707;
public const uint GL_SIGNED_INTENSITY8_NV = 0x8708;
public const uint GL_DSDT8_NV = 0x8709;
public const uint GL_DSDT8_MAG8_NV = 0x870A;
public const uint GL_DSDT8_MAG8_INTENSITY8_NV = 0x870B;
public const uint GL_SIGNED_RGB_UNSIGNED_ALPHA_NV = 0x870C;
public const uint GL_SIGNED_RGB8_UNSIGNED_ALPHA8_NV = 0x870D;
public const uint GL_HI_SCALE_NV = 0x870E;
public const uint GL_LO_SCALE_NV = 0x870F;
public const uint GL_DS_SCALE_NV = 0x8710;
public const uint GL_DT_SCALE_NV = 0x8711;
public const uint GL_MAGNITUDE_SCALE_NV = 0x8712;
public const uint GL_VIBRANCE_SCALE_NV = 0x8713;
public const uint GL_HI_BIAS_NV = 0x8714;
public const uint GL_LO_BIAS_NV = 0x8715;
public const uint GL_DS_BIAS_NV = 0x8716;
public const uint GL_DT_BIAS_NV = 0x8717;
public const uint GL_MAGNITUDE_BIAS_NV = 0x8718;
public const uint GL_VIBRANCE_BIAS_NV = 0x8719;
public const uint GL_TEXTURE_BORDER_VALUES_NV = 0x871A;
public const uint GL_TEXTURE_HI_SIZE_NV = 0x871B;
public const uint GL_TEXTURE_LO_SIZE_NV = 0x871C;
public const uint GL_TEXTURE_DS_SIZE_NV = 0x871D;
public const uint GL_TEXTURE_DT_SIZE_NV = 0x871E;
public const uint GL_TEXTURE_MAG_SIZE_NV = 0x871F;
#endif

#if GL_NV_texture_shader2
public const uint GL_DOT_PRODUCT_TEXTURE_3D_NV = 0x86EF;
#endif

#if GL_NV_texture_shader3
public const uint GL_OFFSET_PROJECTIVE_TEXTURE_2D_NV = 0x8850;
public const uint GL_OFFSET_PROJECTIVE_TEXTURE_2D_SCALE_NV = 0x8851;
public const uint GL_OFFSET_PROJECTIVE_TEXTURE_RECTANGLE_NV = 0x8852;
public const uint GL_OFFSET_PROJECTIVE_TEXTURE_RECTANGLE_SCALE_NV = 0x8853;
public const uint GL_OFFSET_HILO_TEXTURE_2D_NV = 0x8854;
public const uint GL_OFFSET_HILO_TEXTURE_RECTANGLE_NV = 0x8855;
public const uint GL_OFFSET_HILO_PROJECTIVE_TEXTURE_2D_NV = 0x8856;
public const uint GL_OFFSET_HILO_PROJECTIVE_TEXTURE_RECTANGLE_NV = 0x8857;
public const uint GL_DEPENDENT_HILO_TEXTURE_2D_NV = 0x8858;
public const uint GL_DEPENDENT_RGB_TEXTURE_3D_NV = 0x8859;
public const uint GL_DEPENDENT_RGB_TEXTURE_CUBE_MAP_NV = 0x885A;
public const uint GL_DOT_PRODUCT_PASS_THROUGH_NV = 0x885B;
public const uint GL_DOT_PRODUCT_TEXTURE_1D_NV = 0x885C;
public const uint GL_DOT_PRODUCT_AFFINE_DEPTH_REPLACE_NV = 0x885D;
public const uint GL_HILO8_NV = 0x885E;
public const uint GL_SIGNED_HILO8_NV = 0x885F;
public const uint GL_FORCE_BLUE_TO_ONE_NV = 0x8860;
#endif

#if GL_NV_point_sprite
        public const uint GL_POINT_SPRITE_NV = 0x8861;
        public const uint GL_COORD_REPLACE_NV = 0x8862;
        public const uint GL_POINT_SPRITE_R_MODE_NV = 0x8863;
#endif

#if GL_NV_depth_clamp
        public const uint GL_DEPTH_CLAMP_NV = 0x864F;
#endif

#if GL_NV_multisample_filter_hint
        public const uint GL_MULTISAMPLE_FILTER_HINT_NV = 0x8534;
#endif

#if GL_NV_light_max_exponent
        //public const uint GL_MAX_SHININESS_NV = 0x8504;
        //public const uint GL_MAX_SPOT_EXPONENT_NV = 0x8505;
#endif

#if GL_NV_fragment_program2 || GL_NV_vertex_program2_option
        public const uint GL_MAX_PROGRAM_EXEC_INSTRUCTIONS_NV = 0x88F4;
        public const uint GL_MAX_PROGRAM_CALL_DEPTH_NV = 0x88F5;
#endif

#if GL_NV_fragment_program2
        public const uint GL_MAX_PROGRAM_IF_DEPTH_NV = 0x88F6;
        public const uint GL_MAX_PROGRAM_LOOP_DEPTH_NV = 0x88F7;
        public const uint GL_MAX_PROGRAM_LOOP_COUNT_NV = 0x88F8;
#endif

#if GL_NV_conditional_render
        public const uint GL_QUERY_WAIT_NV = 0x8E13;
        public const uint GL_QUERY_NO_WAIT_NV = 0x8E14;
        public const uint GL_QUERY_BY_REGION_WAIT_NV = 0x8E15;
        public const uint GL_QUERY_BY_REGION_NO_WAIT_NV = 0x8E16;
#endif

#if GL_PGI_vertex_hints
public const uint GL_VERTEX_DATA_HINT_PGI = 0x1A22A;
public const uint GL_VERTEX_CONSISTENT_HINT_PGI = 0x1A22B;
public const uint GL_MATERIAL_SIDE_HINT_PGI = 0x1A22C;
public const uint GL_MAX_VERTEX_HINT_PGI = 0x1A22D;
public const uint GL_COLOR3_BIT_PGI = 0x00010000;
public const uint GL_COLOR4_BIT_PGI = 0x00020000;
public const uint GL_EDGEFLAG_BIT_PGI = 0x00040000;
public const uint GL_INDEX_BIT_PGI = 0x00080000;
public const uint GL_MAT_AMBIENT_BIT_PGI = 0x00100000;
public const uint GL_MAT_AMBIENT_AND_DIFFUSE_BIT_PGI = 0x00200000;
public const uint GL_MAT_DIFFUSE_BIT_PGI = 0x00400000;
public const uint GL_MAT_EMISSION_BIT_PGI = 0x00800000;
public const uint GL_MAT_COLOR_INDEXES_BIT_PGI = 0x01000000;
public const uint GL_MAT_SHININESS_BIT_PGI = 0x02000000;
public const uint GL_MAT_SPECULAR_BIT_PGI = 0x04000000;
public const uint GL_NORMAL_BIT_PGI = 0x08000000;
public const uint GL_TEXCOORD1_BIT_PGI = 0x10000000;
public const uint GL_TEXCOORD2_BIT_PGI = 0x20000000;
public const uint GL_TEXCOORD3_BIT_PGI = 0x40000000;
public const uint GL_TEXCOORD4_BIT_PGI = 0x80000000;
public const uint GL_VERTEX23_BIT_PGI = 0x00000004;
public const uint GL_VERTEX4_BIT_PGI = 0x00000008;
#endif

#if GL_PGI_misc_hints
public const uint GL_PREFER_DOUBLEBUFFER_HINT_PGI = 0x1A1F8;
public const uint GL_CONSERVE_MEMORY_HINT_PGI = 0x1A1FD;
public const uint GL_RECLAIM_MEMORY_HINT_PGI = 0x1A1FE;
public const uint GL_NATIVE_GRAPHICS_HANDLE_PGI = 0x1A202;
public const uint GL_NATIVE_GRAPHICS_BEGIN_HINT_PGI = 0x1A203;
public const uint GL_NATIVE_GRAPHICS_END_HINT_PGI = 0x1A204;
public const uint GL_ALWAYS_FAST_HINT_PGI = 0x1A20C;
public const uint GL_ALWAYS_SOFT_HINT_PGI = 0x1A20D;
public const uint GL_ALLOW_DRAW_OBJ_HINT_PGI = 0x1A20E;
public const uint GL_ALLOW_DRAW_WIN_HINT_PGI = 0x1A20F;
public const uint GL_ALLOW_DRAW_FRG_HINT_PGI = 0x1A210;
public const uint GL_ALLOW_DRAW_MEM_HINT_PGI = 0x1A211;
public const uint GL_STRICT_DEPTHFUNC_HINT_PGI = 0x1A216;
public const uint GL_STRICT_LIGHTING_HINT_PGI = 0x1A217;
public const uint GL_STRICT_SCISSOR_HINT_PGI = 0x1A218;
public const uint GL_FULL_STIPPLE_HINT_PGI = 0x1A219;
public const uint GL_CLIP_NEAR_HINT_PGI = 0x1A220;
public const uint GL_CLIP_FAR_HINT_PGI = 0x1A221;
public const uint GL_WIDE_LINE_HINT_PGI = 0x1A222;
public const uint GL_BACK_NORMALS_HINT_PGI = 0x1A223;
#endif


#if GL_REND_screen_coordinates
public const uint GL_SCREEN_COORDINATES_REND = 0x8490;
public const uint GL_INVERTED_SCREEN_W_REND = 0x8491;
#endif


#if GL_SGI_color_matrix
        public const uint GL_COLOR_MATRIX_SGI = 0x80B1;
        public const uint GL_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B2;
        public const uint GL_MAX_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B3;
        public const uint GL_POST_COLOR_MATRIX_RED_SCALE_SGI = 0x80B4;
        public const uint GL_POST_COLOR_MATRIX_GREEN_SCALE_SGI = 0x80B5;
        public const uint GL_POST_COLOR_MATRIX_BLUE_SCALE_SGI = 0x80B6;
        public const uint GL_POST_COLOR_MATRIX_ALPHA_SCALE_SGI = 0x80B7;
        public const uint GL_POST_COLOR_MATRIX_RED_BIAS_SGI = 0x80B8;
        public const uint GL_POST_COLOR_MATRIX_GREEN_BIAS_SGI = 0x80B9;
        public const uint GL_POST_COLOR_MATRIX_BLUE_BIAS_SGI = 0x80BA;
        public const uint GL_POST_COLOR_MATRIX_ALPHA_BIAS_SGI = 0x80BB;
#endif

#if GL_SGI_color_table
public const uint GL_COLOR_TABLE_SGI = 0x80D0;
public const uint GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1;
public const uint GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2;
public const uint GL_PROXY_COLOR_TABLE_SGI = 0x80D3;
public const uint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D4;
public const uint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D5;
public const uint GL_COLOR_TABLE_SCALE_SGI = 0x80D6;
public const uint GL_COLOR_TABLE_BIAS_SGI = 0x80D7;
public const uint GL_COLOR_TABLE_FORMAT_SGI = 0x80D8;
public const uint GL_COLOR_TABLE_WIDTH_SGI = 0x80D9;
public const uint GL_COLOR_TABLE_RED_SIZE_SGI = 0x80DA;
public const uint GL_COLOR_TABLE_GREEN_SIZE_SGI = 0x80DB;
public const uint GL_COLOR_TABLE_BLUE_SIZE_SGI = 0x80DC;
public const uint GL_COLOR_TABLE_ALPHA_SIZE_SGI = 0x80DD;
public const uint GL_COLOR_TABLE_LUMINANCE_SIZE_SGI = 0x80DE;
public const uint GL_COLOR_TABLE_INTENSITY_SIZE_SGI = 0x80DF;
#endif

#if GL_SGI_texture_color_table
public const uint GL_TEXTURE_COLOR_TABLE_SGI = 0x80BC;
public const uint GL_PROXY_TEXTURE_COLOR_TABLE_SGI = 0x80BD;
#endif

#if GL_SGI_depth_pass_instrument
public const uint GL_DEPTH_PASS_INSTRUMENT_SGIX = 0x8310;
public const uint GL_DEPTH_PASS_INSTRUMENT_COUNTERS_SGIX = 0x8311;
public const uint GL_DEPTH_PASS_INSTRUMENT_MAX_SGIX = 0x8312;
#endif

#if GL_SGIS_texture_filter4
public const uint GL_FILTER4_SGIS = 0x8146;
public const uint GL_TEXTURE_FILTER4_SIZE_SGIS = 0x8147;
#endif

#if GL_SGIS_pixel_texture
public const uint GL_PIXEL_TEXTURE_SGIS = 0x8353;
public const uint GL_PIXEL_FRAGMENT_RGB_SOURCE_SGIS = 0x8354;
public const uint GL_PIXEL_FRAGMENT_ALPHA_SOURCE_SGIS = 0x8355;
public const uint GL_PIXEL_GROUP_COLOR_SGIS = 0x8356;
#endif

#if GL_SGIS_texture4D
public const uint GL_PACK_SKIP_VOLUMES_SGIS = 0x8130;
public const uint GL_PACK_IMAGE_DEPTH_SGIS = 0x8131;
public const uint GL_UNPACK_SKIP_VOLUMES_SGIS = 0x8132;
public const uint GL_UNPACK_IMAGE_DEPTH_SGIS = 0x8133;
public const uint GL_TEXTURE_4D_SGIS = 0x8134;
public const uint GL_PROXY_TEXTURE_4D_SGIS = 0x8135;
public const uint GL_TEXTURE_4DSIZE_SGIS = 0x8136;
public const uint GL_TEXTURE_WRAP_Q_SGIS = 0x8137;
public const uint GL_MAX_4D_TEXTURE_SIZE_SGIS = 0x8138;
public const uint GL_TEXTURE_4D_BINDING_SGIS = 0x814F;
#endif

#if GL_SGIS_detail_texture
public const uint GL_DETAIL_TEXTURE_2D_SGIS = 0x8095;
public const uint GL_DETAIL_TEXTURE_2D_BINDING_SGIS = 0x8096;
public const uint GL_LINEAR_DETAIL_SGIS = 0x8097;
public const uint GL_LINEAR_DETAIL_ALPHA_SGIS = 0x8098;
public const uint GL_LINEAR_DETAIL_COLOR_SGIS = 0x8099;
public const uint GL_DETAIL_TEXTURE_LEVEL_SGIS = 0x809A;
public const uint GL_DETAIL_TEXTURE_MODE_SGIS = 0x809B;
public const uint GL_DETAIL_TEXTURE_FUNC_POINTS_SGIS = 0x809C;
#endif

#if GL_SGIS_sharpen_texture
public const uint GL_LINEAR_SHARPEN_SGIS = 0x80AD;
public const uint GL_LINEAR_SHARPEN_ALPHA_SGIS = 0x80AE;
public const uint GL_LINEAR_SHARPEN_COLOR_SGIS = 0x80AF;
public const uint GL_SHARPEN_TEXTURE_FUNC_POINTS_SGIS = 0x80B0;
#endif

#if GL_SGIS_texture_lod
        public const uint GL_TEXTURE_MIN_LOD_SGIS = 0x813A;
        public const uint GL_TEXTURE_MAX_LOD_SGIS = 0x813B;
        public const uint GL_TEXTURE_BASE_LEVEL_SGIS = 0x813C;
        public const uint GL_TEXTURE_MAX_LEVEL_SGIS = 0x813D;
#endif

#if GL_SGIS_multisample
public const uint GL_MULTISAMPLE_SGIS = 0x809D;
public const uint GL_SAMPLE_ALPHA_TO_MASK_SGIS = 0x809E;
public const uint GL_SAMPLE_ALPHA_TO_ONE_SGIS = 0x809F;
public const uint GL_SAMPLE_MASK_SGIS = 0x80A0;
public const uint GL_1PASS_SGIS = 0x80A1;
public const uint GL_2PASS_0_SGIS = 0x80A2;
public const uint GL_2PASS_1_SGIS = 0x80A3;
public const uint GL_4PASS_0_SGIS = 0x80A4;
public const uint GL_4PASS_1_SGIS = 0x80A5;
public const uint GL_4PASS_2_SGIS = 0x80A6;
public const uint GL_4PASS_3_SGIS = 0x80A7;
public const uint GL_SAMPLE_BUFFERS_SGIS = 0x80A8;
public const uint GL_SAMPLES_SGIS = 0x80A9;
public const uint GL_SAMPLE_MASK_VALUE_SGIS = 0x80AA;
public const uint GL_SAMPLE_MASK_INVERT_SGIS = 0x80AB;
public const uint GL_SAMPLE_PATTERN_SGIS = 0x80AC;
#endif

#if GL_SGIS_generate_mipmap
        public const uint GL_GENERATE_MIPMAP_SGIS = 0x8191;
        public const uint GL_GENERATE_MIPMAP_HINT_SGIS = 0x8192;
#endif

#if GL_SGIS_texture_edge_clamp
        public const uint GL_CLAMP_TO_EDGE_SGIS = 0x812F;
#endif

#if GL_SGIS_texture_border_clamp
public const uint GL_CLAMP_TO_BORDER_SGIS = 0x812D;
#endif

#if GL_SGIS_texture_select
public const uint GL_DUAL_ALPHA4_SGIS = 0x8110;
public const uint GL_DUAL_ALPHA8_SGIS = 0x8111;
public const uint GL_DUAL_ALPHA12_SGIS = 0x8112;
public const uint GL_DUAL_ALPHA16_SGIS = 0x8113;
public const uint GL_DUAL_LUMINANCE4_SGIS = 0x8114;
public const uint GL_DUAL_LUMINANCE8_SGIS = 0x8115;
public const uint GL_DUAL_LUMINANCE12_SGIS = 0x8116;
public const uint GL_DUAL_LUMINANCE16_SGIS = 0x8117;
public const uint GL_DUAL_INTENSITY4_SGIS = 0x8118;
public const uint GL_DUAL_INTENSITY8_SGIS = 0x8119;
public const uint GL_DUAL_INTENSITY12_SGIS = 0x811A;
public const uint GL_DUAL_INTENSITY16_SGIS = 0x811B;
public const uint GL_DUAL_LUMINANCE_ALPHA4_SGIS = 0x811C;
public const uint GL_DUAL_LUMINANCE_ALPHA8_SGIS = 0x811D;
public const uint GL_QUAD_ALPHA4_SGIS = 0x811E;
public const uint GL_QUAD_ALPHA8_SGIS = 0x811F;
public const uint GL_QUAD_LUMINANCE4_SGIS = 0x8120;
public const uint GL_QUAD_LUMINANCE8_SGIS = 0x8121;
public const uint GL_QUAD_INTENSITY4_SGIS = 0x8122;
public const uint GL_QUAD_INTENSITY8_SGIS = 0x8123;
public const uint GL_DUAL_TEXTURE_SELECT_SGIS = 0x8124;
public const uint GL_QUAD_TEXTURE_SELECT_SGIS = 0x8125;
#endif

#if GL_SGIS_point_parameters
public const uint GL_POINT_SIZE_MIN_EXT = 0x8126;
public const uint GL_POINT_SIZE_MIN_SGIS = 0x8126;
public const uint GL_POINT_SIZE_MAX_EXT = 0x8127;
public const uint GL_POINT_SIZE_MAX_SGIS = 0x8127;
public const uint GL_POINT_FADE_THRESHOLD_SIZE_EXT = 0x8128;
public const uint GL_POINT_FADE_THRESHOLD_SIZE_SGIS = 0x8128;
public const uint GL_DISTANCE_ATTENUATION_EXT = 0x8129;
public const uint GL_DISTANCE_ATTENUATION_SGIS = 0x8129;
#endif

#if GL_SGIS_fog_function
public const uint GL_FOG_FUNC_SGIS = 0x812A;
public const uint GL_FOG_FUNC_POINTS_SGIS = 0x812B;
public const uint GL_MAX_FOG_FUNC_POINTS_SGIS = 0x812C;
#endif

#if GL_SGIS_point_line_texgen
public const uint GL_EYE_DISTANCE_TO_POINT_SGIS = 0x81F0;
public const uint GL_OBJECT_DISTANCE_TO_POINT_SGIS = 0x81F1;
public const uint GL_EYE_DISTANCE_TO_LINE_SGIS = 0x81F2;
public const uint GL_OBJECT_DISTANCE_TO_LINE_SGIS = 0x81F3;
public const uint GL_EYE_POINT_SGIS = 0x81F4;
public const uint GL_OBJECT_POINT_SGIS = 0x81F5;
public const uint GL_EYE_LINE_SGIS = 0x81F6;
public const uint GL_OBJECT_LINE_SGIS = 0x81F7;
#endif

#if GL_SGIS_texture_color_mask
public const uint GL_TEXTURE_COLOR_WRITEMASK_SGIS = 0x81EF;
#endif

#if GL_SGIX_pixel_texture
public const uint GL_PIXEL_TEX_GEN_SGIX = 0x8139;
public const uint GL_PIXEL_TEX_GEN_MODE_SGIX = 0x832B;
#endif

#if GL_SGIX_clipmap
public const uint GL_LINEAR_CLIPMAP_LINEAR_SGIX = 0x8170;
public const uint GL_TEXTURE_CLIPMAP_CENTER_SGIX = 0x8171;
public const uint GL_TEXTURE_CLIPMAP_FRAME_SGIX = 0x8172;
public const uint GL_TEXTURE_CLIPMAP_OFFSET_SGIX = 0x8173;
public const uint GL_TEXTURE_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8174;
public const uint GL_TEXTURE_CLIPMAP_LOD_OFFSET_SGIX = 0x8175;
public const uint GL_TEXTURE_CLIPMAP_DEPTH_SGIX = 0x8176;
public const uint GL_MAX_CLIPMAP_DEPTH_SGIX = 0x8177;
public const uint GL_MAX_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8178;
public const uint GL_NEAREST_CLIPMAP_NEAREST_SGIX = 0x844D;
public const uint GL_NEAREST_CLIPMAP_LINEAR_SGIX = 0x844E;
public const uint GL_LINEAR_CLIPMAP_NEAREST_SGIX = 0x844F;
#endif

#if GL_SGIX_shadow
public const uint GL_TEXTURE_COMPARE_SGIX = 0x819A;
public const uint GL_TEXTURE_COMPARE_OPERATOR_SGIX = 0x819B;
public const uint GL_TEXTURE_LEQUAL_R_SGIX = 0x819C;
public const uint GL_TEXTURE_GEQUAL_R_SGIX = 0x819D;
#endif

#if GL_SGIX_interlace
public const uint GL_INTERLACE_SGIX = 0x8094;
#endif

#if GL_SGIX_pixel_tiles
public const uint GL_PIXEL_TILE_BEST_ALIGNMENT_SGIX = 0x813E;
public const uint GL_PIXEL_TILE_CACHE_INCREMENT_SGIX = 0x813F;
public const uint GL_PIXEL_TILE_WIDTH_SGIX = 0x8140;
public const uint GL_PIXEL_TILE_HEIGHT_SGIX = 0x8141;
public const uint GL_PIXEL_TILE_GRID_WIDTH_SGIX = 0x8142;
public const uint GL_PIXEL_TILE_GRID_HEIGHT_SGIX = 0x8143;
public const uint GL_PIXEL_TILE_GRID_DEPTH_SGIX = 0x8144;
public const uint GL_PIXEL_TILE_CACHE_SIZE_SGIX = 0x8145;
#endif

#if GL_SGIX_sprite
public const uint GL_SPRITE_SGIX = 0x8148;
public const uint GL_SPRITE_MODE_SGIX = 0x8149;
public const uint GL_SPRITE_AXIS_SGIX = 0x814A;
public const uint GL_SPRITE_TRANSLATION_SGIX = 0x814B;
public const uint GL_SPRITE_AXIAL_SGIX = 0x814C;
public const uint GL_SPRITE_OBJECT_ALIGNED_SGIX = 0x814D;
public const uint GL_SPRITE_EYE_ALIGNED_SGIX = 0x814E;
#endif

#if GL_SGIX_texture_multi_buffer
public const uint GL_TEXTURE_MULTI_BUFFER_HINT_SGIX = 0x812E;
#endif

#if GL_SGIX_instruments
public const uint GL_INSTRUMENT_BUFFER_POINTER_SGIX = 0x8180;
public const uint GL_INSTRUMENT_MEASUREMENTS_SGIX = 0x8181;
#endif

#if GL_SGIX_texture_scale_bias
public const uint GL_POST_TEXTURE_FILTER_BIAS_SGIX = 0x8179;
public const uint GL_POST_TEXTURE_FILTER_SCALE_SGIX = 0x817A;
public const uint GL_POST_TEXTURE_FILTER_BIAS_RANGE_SGIX = 0x817B;
public const uint GL_POST_TEXTURE_FILTER_SCALE_RANGE_SGIX = 0x817C;
#endif

#if GL_SGIX_framezoom
public const uint GL_FRAMEZOOM_SGIX = 0x818B;
public const uint GL_FRAMEZOOM_FACTOR_SGIX = 0x818C;
public const uint GL_MAX_FRAMEZOOM_FACTOR_SGIX = 0x818D;
#endif

#if GL_SGIX_polynomial_ffd
public const uint GL_GEOMETRY_DEFORMATION_SGIX = 0x8194;
public const uint GL_TEXTURE_DEFORMATION_SGIX = 0x8195;
public const uint GL_DEFORMATIONS_MASK_SGIX = 0x8196;
public const uint GL_MAX_DEFORMATION_ORDER_SGIX = 0x8197;
#endif

#if GL_SGIX_reference_plane
public const uint GL_REFERENCE_PLANE_SGIX = 0x817D;
public const uint GL_REFERENCE_PLANE_EQUATION_SGIX = 0x817E;
#endif

#if GL_SGIX_depth_texture
public const uint GL_DEPTH_COMPONENT16_SGIX = 0x81A5;
public const uint GL_DEPTH_COMPONENT24_SGIX = 0x81A6;
public const uint GL_DEPTH_COMPONENT32_SGIX = 0x81A7;
#endif

#if GL_SGIX_fog_offset
public const uint GL_FOG_OFFSET_SGIX = 0x8198;
public const uint GL_FOG_OFFSET_VALUE_SGIX = 0x8199;
#endif

#if GL_SGIX_texture_add_env
public const uint GL_TEXTURE_ENV_BIAS_SGIX = 0x80BE;
#endif

#if GL_SGIX_list_priority
public const uint GL_LIST_PRIORITY_SGIX = 0x8182;
#endif

#if GL_SGIX_ir_instrument1
public const uint GL_IR_INSTRUMENT1_SGIX = 0x817F;
#endif

#if GL_SGIX_calligraphic_fragment
public const uint GL_CALLIGRAPHIC_FRAGMENT_SGIX = 0x8183;
#endif

#if GL_SGIX_texture_lod_bias
public const uint GL_TEXTURE_LOD_BIAS_S_SGIX = 0x818E;
public const uint GL_TEXTURE_LOD_BIAS_T_SGIX = 0x818F;
public const uint GL_TEXTURE_LOD_BIAS_R_SGIX = 0x8190;
#endif

#if GL_SGIX_ycrcb
public const uint GL_YCRCB_422_SGIX = 0x81BB;
public const uint GL_YCRCB_444_SGIX = 0x81BC;
#endif

#if GL_SGIX_fragment_lighting
public const uint GL_FRAGMENT_LIGHTING_SGIX = 0x8400;
public const uint GL_FRAGMENT_COLOR_MATERIAL_SGIX = 0x8401;
public const uint GL_FRAGMENT_COLOR_MATERIAL_FACE_SGIX = 0x8402;
public const uint GL_FRAGMENT_COLOR_MATERIAL_PARAMETER_SGIX = 0x8403;
public const uint GL_MAX_FRAGMENT_LIGHTS_SGIX = 0x8404;
public const uint GL_MAX_ACTIVE_LIGHTS_SGIX = 0x8405;
public const uint GL_CURRENT_RASTER_NORMAL_SGIX = 0x8406;
public const uint GL_LIGHT_ENV_MODE_SGIX = 0x8407;
public const uint GL_FRAGMENT_LIGHT_MODEL_LOCAL_VIEWER_SGIX = 0x8408;
public const uint GL_FRAGMENT_LIGHT_MODEL_TWO_SIDE_SGIX = 0x8409;
public const uint GL_FRAGMENT_LIGHT_MODEL_AMBIENT_SGIX = 0x840A;
public const uint GL_FRAGMENT_LIGHT_MODEL_NORMAL_INTERPOLATION_SGIX = 0x840B;
public const uint GL_FRAGMENT_LIGHT0_SGIX = 0x840C;
public const uint GL_FRAGMENT_LIGHT1_SGIX = 0x840D;
public const uint GL_FRAGMENT_LIGHT2_SGIX = 0x840E;
public const uint GL_FRAGMENT_LIGHT3_SGIX = 0x840F;
public const uint GL_FRAGMENT_LIGHT4_SGIX = 0x8410;
public const uint GL_FRAGMENT_LIGHT5_SGIX = 0x8411;
public const uint GL_FRAGMENT_LIGHT6_SGIX = 0x8412;
public const uint GL_FRAGMENT_LIGHT7_SGIX = 0x8413;
#endif

#if GL_SGIX_blend_alpha_minmax
public const uint GL_ALPHA_MIN_SGIX = 0x8320;
public const uint GL_ALPHA_MAX_SGIX = 0x8321;
#endif

#if GL_SGIX_async
public const uint GL_ASYNC_MARKER_SGIX = 0x8329;
#endif

#if GL_SGIX_async_pixel
public const uint GL_ASYNC_TEX_IMAGE_SGIX = 0x835C;
public const uint GL_ASYNC_DRAW_PIXELS_SGIX = 0x835D;
public const uint GL_ASYNC_READ_PIXELS_SGIX = 0x835E;
public const uint GL_MAX_ASYNC_TEX_IMAGE_SGIX = 0x835F;
public const uint GL_MAX_ASYNC_DRAW_PIXELS_SGIX = 0x8360;
public const uint GL_MAX_ASYNC_READ_PIXELS_SGIX = 0x8361;
#endif

#if GL_SGIX_async_histogram
public const uint GL_ASYNC_HISTOGRAM_SGIX = 0x832C;
public const uint GL_MAX_ASYNC_HISTOGRAM_SGIX = 0x832D;
#endif

#if GL_SGIX_fog_scale
public const uint GL_FOG_SCALE_SGIX = 0x81FC;
public const uint GL_FOG_SCALE_VALUE_SGIX = 0x81FD;
#endif

#if GL_SGIX_subsample
public const uint GL_PACK_SUBSAMPLE_RATE_SGIX = 0x85A0;
public const uint GL_UNPACK_SUBSAMPLE_RATE_SGIX = 0x85A1;
public const uint GL_PIXEL_SUBSAMPLE_4444_SGIX = 0x85A2;
public const uint GL_PIXEL_SUBSAMPLE_2424_SGIX = 0x85A3;
public const uint GL_PIXEL_SUBSAMPLE_4242_SGIX = 0x85A4;
#endif

#if GL_SGIX_ycrcba
public const uint GL_YCRCB_SGIX = 0x8318;
public const uint GL_YCRCBA_SGIX = 0x8319;
#endif

#if GL_SGIX_vertex_preclip
public const uint GL_VERTEX_PRECLIP_SGIX = 0x83EE;
public const uint GL_VERTEX_PRECLIP_HINT_SGIX = 0x83EF;
#endif

#if GL_SGIX_convolution_accuracy
public const uint GL_CONVOLUTION_HINT_SGIX = 0x8316;
#endif

#if GL_SGIX_resample
public const uint GL_PACK_RESAMPLE_SGIX = 0x842C;
public const uint GL_UNPACK_RESAMPLE_SGIX = 0x842D;
public const uint GL_RESAMPLE_REPLICATE_SGIX = 0x842E;
public const uint GL_RESAMPLE_ZERO_FILL_SGIX = 0x842F;
public const uint GL_RESAMPLE_DECIMATE_SGIX = 0x8430;
#endif


#if GL_SUN_global_alpha
public const uint GL_GLOBAL_ALPHA_SUN = 0x81D9;
public const uint GL_GLOBAL_ALPHA_FACTOR_SUN = 0x81DA;
#endif

#if GL_SUN_triangle_list
public const uint GL_RESTART_SUN = 0x01;
public const uint GL_REPLACE_MIDDLE_SUN = 0x02;
public const uint GL_REPLACE_OLDEST_SUN = 0x03;
public const uint GL_TRIANGLE_LIST_SUN = 0x81D7;
public const uint GL_REPLACEMENT_CODE_SUN = 0x81D8;
public const uint GL_REPLACEMENT_CODE_ARRAY_SUN = 0x85C0;
public const uint GL_REPLACEMENT_CODE_ARRAY_TYPE_SUN = 0x85C1;
public const uint GL_REPLACEMENT_CODE_ARRAY_STRIDE_SUN = 0x85C2;
public const uint GL_REPLACEMENT_CODE_ARRAY_POINTER_SUN = 0x85C3;
public const uint GL_R1UI_V3F_SUN = 0x85C4;
public const uint GL_R1UI_C4UB_V3F_SUN = 0x85C5;
public const uint GL_R1UI_C3F_V3F_SUN = 0x85C6;
public const uint GL_R1UI_N3F_V3F_SUN = 0x85C7;
public const uint GL_R1UI_C4F_N3F_V3F_SUN = 0x85C8;
public const uint GL_R1UI_T2F_V3F_SUN = 0x85C9;
public const uint GL_R1UI_T2F_N3F_V3F_SUN = 0x85CA;
public const uint GL_R1UI_T2F_C4F_N3F_V3F_SUN = 0x85CB;
#endif

#if GL_SUN_convolution_border_modes
public const uint GL_WRAP_BORDER_SUN = 0x81D4;
#endif

#if GL_SUNX_constant_data
public const uint GL_UNPACK_CONSTANT_DATA_SUNX = 0x81D5;
public const uint GL_TEXTURE_CONSTANT_DATA_SUNX = 0x81D6;
#endif


#if GL_WIN_phong_shading
public const uint GL_PHONG_WIN = 0x80EA;
public const uint GL_PHONG_HINT_WIN = 0x80EB;
#endif

#if GL_WIN_specular_fog
public const uint GL_FOG_SPECULAR_TEXTURE_WIN = 0x80EC;
#endif


#if GL_3DFX_texture_compression_FXT1
public const uint GL_COMPRESSED_RGB_FXT1_3DFX = 0x86B0;
public const uint GL_COMPRESSED_RGBA_FXT1_3DFX = 0x86B1;
#endif

#if GL_3DFX_multisample
public const uint GL_MULTISAMPLE_3DFX = 0x86B2;
public const uint GL_SAMPLE_BUFFERS_3DFX = 0x86B3;
public const uint GL_SAMPLES_3DFX = 0x86B4;
public const uint GL_MULTISAMPLE_BIT_3DFX = 0x20000000;
#endif
    }
}
