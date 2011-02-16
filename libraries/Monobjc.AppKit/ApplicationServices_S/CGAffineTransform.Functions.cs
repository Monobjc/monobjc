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

namespace Monobjc.ApplicationServices
{
    public partial struct CGAffineTransform
    {
        /// <summary>
        /// <para>Returns an affine transformation matrix constructed by combining two existing affine transforms.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformConcat ( CGAffineTransform t1, CGAffineTransform t2 );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="t1">The first affine transform.</param>
        /// <param name="t2">The second affine transform. This affine transform is concatenated to the first affine transform.</param>
        /// <returns>A new affine transformation matrix. That is, t’ = t1*t2.</returns>
        public static CGAffineTransform Concat(CGAffineTransform t1, CGAffineTransform t2)
        {
            // TODO : To implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// <para>Checks whether two affine transforms are equal.</para>
        /// <para>Original signature is : bool CGAffineTransformEqualToTransform ( CGAffineTransform t1, CGAffineTransform t2 );</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        /// <param name="t1">An affine transform.</param>
        /// <param name="t2">An affine transform.</param>
        /// <returns>Returns true if t1 and t2 are equal, false otherwise.</returns>
        public static bool EqualToTransform(CGAffineTransform t1, CGAffineTransform t2)
        {
            return Equals(t1, t2);
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed by inverting an existing affine transform.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformInvert ( CGAffineTransform t );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="t">An existing affine transform.</param>
        /// <returns>A new affine transformation matrix. If the affine transform passed in parameter t cannot be inverted, Quartz returns the affine transform unchanged.</returns>
        public static CGAffineTransform Invert(CGAffineTransform t)
        {
            // TODO : To implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// <para>Checks whether an affine transform is the identity transform.</para>
        /// <para>Original signature is : bool CGAffineTransformIsIdentity ( CGAffineTransform t );</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        /// <param name="t">The affine transform to check.</param>
        /// <returns>Returns true if t is the identity transform, false otherwise.</returns>
        public static bool IsIdentity(CGAffineTransform t)
        {
            return ((t.a == 1.0f) &&
                    (t.b == 0.0f) &&
                    (t.c == 0.0f) &&
                    (t.d == 1.0f) &&
                    (t.tx == 0.0f) &&
                    (t.ty == 0.0f));
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed from values you provide.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformMake ( CGFloat a, CGFloat b, CGFloat c, CGFloat d, CGFloat tx, CGFloat ty );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="a">The value at position [1,1] in the matrix.</param>
        /// <param name="b">The value at position [1,2] in the matrix.</param>
        /// <param name="c">The value at position [2,1] in the matrix.</param>
        /// <param name="d">The value at position [2,2] in the matrix.</param>
        /// <param name="tx">The value at position [3,1] in the matrix.</param>
        /// <param name="ty">The value at position [3,2] in the matrix.</param>
        /// <returns>A new affine transform matrix constructed from the values you specify.</returns>
        public static CGAffineTransform Make(float a, float b, float c, float d, float tx, float ty)
        {
            return new CGAffineTransform
                       {
                           a = a, 
                           b = b, 
                           c = c, 
                           d = d,
                           tx = tx, 
                           ty = ty
                       };
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed from a rotation value you provide.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformMakeRotation ( CGFloat angle );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="angle">The angle, in radians, by which this matrix rotates the coordinate system axes. A positive value specifies clockwise rotation, a negative value specifies counterclockwise.</param>
        /// <returns>A new affine transformation matrix.</returns>
        public static CGAffineTransform MakeRotation(float angle)
        {
            return new CGAffineTransform
                       {
                           a = ((float) Math.Cos(angle)),
                           b = ((float) Math.Sin(angle)), 
                           c = (-(float) Math.Sin(angle)),
                           d = ((float) Math.Cos(angle)), 
                           tx = 0.0f,
                           ty = 0.0f
                       };
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed from scaling values you provide.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformMakeScale ( CGFloat sx, CGFloat sy );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="sx">The factor by which to scale the x-axis of the coordinate system.</param>
        /// <param name="sy">The factor by which to scale the y-axis of the coordinate system.</param>
        /// <returns>A new affine transformation matrix.</returns>
        public static CGAffineTransform MakeScale(float sx, float sy)
        {
            return new CGAffineTransform
                       {
                           a = sx, 
                           b = 0.0f, 
                           c = 0.0f, 
                           d = sy, 
                           tx = 0.0f, 
                           ty = 0.0f
                       };
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed from translation values you provide.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformMakeTranslation ( CGFloat tx, CGFloat ty );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="tx">The value by which to move the x-axis of the coordinate system.</param>
        /// <param name="ty">The value by which to move the y-axis of the coordinate system.</param>
        /// <returns>A new affine transform matrix.</returns>
        public static CGAffineTransform MakeTranslation(float tx, float ty)
        {
            return new CGAffineTransform
                       {
                           a = 1.0f, 
                           b = 0.0f, 
                           c = 0.0f, 
                           d = 1.0f, 
                           tx = tx, 
                           ty = ty
                       };
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed by rotating an existing affine transform.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformRotate ( CGAffineTransform t, CGFloat angle );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="t">An existing affine transform.</param>
        /// <param name="angle">The angle, in radians, by which to rotate the affine transform.</param>
        /// <returns>A new affine transformation matrix.</returns>
        public static CGAffineTransform Rotate(CGAffineTransform t, float angle)
        {
            return new CGAffineTransform
                       {
                           a = ((float) (t.a*Math.Cos(angle) - t.b*Math.Sin(angle))),     
                           b = ((float) (t.a*Math.Sin(angle) + t.b*Math.Cos(angle))),      
                           c = ((float) (t.c*Math.Cos(angle) - t.d*Math.Sin(angle))),        
                           d = ((float) (t.c*Math.Sin(angle) + t.d*Math.Cos(angle))),        
                           tx = ((float) (t.tx*Math.Cos(angle) - t.ty*Math.Sin(angle))),       
                           ty = ((float) (t.tx*Math.Sin(angle) + t.ty*Math.Cos(angle)))
                       };
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed by scaling an existing affine transform.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformScale ( CGAffineTransform t, CGFloat sx, CGFloat sy );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="t">An existing affine transform.</param>
        /// <param name="sx">The value by which to scale x values of the affine transform.</param>
        /// <param name="sy">The value by which to scale y values of the affine transform.</param>
        /// <returns>A new affine transformation matrix.</returns>
        public static CGAffineTransform Scale(CGAffineTransform t, float sx, float sy)
        {
            return new CGAffineTransform
                       {
                           a = (t.a*sx), 
                           b = (t.b*sx), 
                           c = (t.c*sy),
                           d = (t.d*sy),
                           tx = (t.tx*sx),
                           ty = (t.ty*sy)
                       };
        }

        /// <summary>
        /// <para>Returns an affine transformation matrix constructed by translating an existing affine transform.</para>
        /// <para>Original signature is : CGAffineTransform CGAffineTransformTranslate ( CGAffineTransform t, CGFloat tx, CGFloat ty );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="t">An existing affine transform.</param>
        /// <param name="tx">The value by which to move x values with the affine transform.</param>
        /// <param name="ty">The value by which to move y values with the affine transform.</param>
        /// <returns>A new affine transformation matrix.</returns>
        public static CGAffineTransform Translate(CGAffineTransform t, float tx, float ty)
        {
            return new CGAffineTransform
                       {
                           a = t.a,
                           b = t.b,
                           c = t.c, 
                           d = t.d,
                           tx = (t.tx + tx),
                           ty = (t.ty + ty)
                       };
        }

        /// <summary>
        /// <para>Returns the point resulting from an affine transformation of an existing point.</para>
        /// <para>Original signature is : CGPoint CGPointApplyAffineTransform ( CGPoint point, CGAffineTransform t );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="point">A point that specifies the x- and y-coordinates to transform.</param>
        /// <param name="t">The affine transform to apply.</param>
        /// <returns>A new point resulting from applying the specified affine transform to the existing point.</returns>
        public static CGPoint CGPointApplyAffineTransform(CGPoint point, CGAffineTransform t)
        {
            return new CGPoint
                       {
                           x = (t.a*point.x + t.c*point.y + t.tx), 
                           y = (t.b*point.x + t.d*point.y + t.ty)
                       };
        }

        /// <summary>
        /// <para>Applies an affine transform to a rectangle.</para>
        /// <para>Original signature is : CGRect CGRectApplyAffineTransform ( CGRect rect, CGAffineTransform t );</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        /// <param name="rect">The rectangle whose corner points you want to transform.</param>
        /// <param name="t">The affine transform to apply to the rect parameter.</param>
        /// <returns>The transformed rectangle.</returns>
        public static CGRect CGRectApplyAffineTransform(CGRect rect, CGAffineTransform t)
        {
            // TODO : To implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// <para>Returns the height and width resulting from a transformation of an existing height and width.</para>
        /// <para>Original signature is : CGSize CGSizeApplyAffineTransform ( CGSize size, CGAffineTransform t );</para>
        /// <para>Available in Mac OS X version 10.0 and later.</para>
        /// </summary>
        /// <param name="size">A size that specifies the height and width to transform.</param>
        /// <param name="t">The affine transform to apply.</param>
        /// <returns>A new size resulting from applying the specified affine transform to the existing size.</returns>
        public static CGSize CGSizeApplyAffineTransform(CGSize size, CGAffineTransform t)
        {
            return new CGSize
                       {
                           width = (t.a*size.width + t.c*size.height + t.tx), 
                           height = (t.b*size.width + t.d*size.height + t.ty)
                       };
        }

        /// <summary>
        /// <para>The identity transform.</para>
        /// <para>Original signature is : const CGAffineTransform CGAffineTransformIdentity;</para>
        /// </summary>
        public static CGAffineTransform CGAffineTransformIdentity()
        {
            return new CGAffineTransform(1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f);
        }
    }
}