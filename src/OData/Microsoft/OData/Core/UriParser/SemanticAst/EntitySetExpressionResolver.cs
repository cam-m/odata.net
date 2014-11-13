//   OData .NET Libraries ver. 6.8.1
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 
//   MIT License
//   Permission is hereby granted, free of charge, to any person obtaining a copy of
//   this software and associated documentation files (the "Software"), to deal in
//   the Software without restriction, including without limitation the rights to use,
//   copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
//   Software, and to permit persons to whom the Software is furnished to do so,
//   subject to the following conditions:

//   The above copyright notice and this permission notice shall be included in all
//   copies or substantial portions of the Software.

//   THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//   FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//   IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//   CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace Microsoft.OData.Core.UriParser
{
    using System;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Edm.Expressions;
    using ODataErrorStrings = Microsoft.OData.Core.Strings;

    /// <summary>
    /// Class that knows how to resolve an IEdmExpression to find its associated EntitySet.
    /// This functionality is needed to determine what a EntitySets a FunctionImport applies to.
    /// </summary>
    internal static class EntitySetExpressionResolver
    {
        /// <summary>
        /// Resolves an IEdmExpression to an IEdmEntitySet.
        /// </summary>
        /// <param name="expression">Expression to resolve.</param>
        /// <returns>The resolved EntitySet.</returns>
        internal static IEdmEntitySet ResolveEntitySetFromExpression(IEdmExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            switch (expression.ExpressionKind)
            {
                case EdmExpressionKind.EntitySetReference:
                    return ((IEdmEntitySetReferenceExpression)expression).ReferencedEntitySet;
                default:
                    // TODO: we should support all the other options
                    throw new NotSupportedException(
                        ODataErrorStrings.Nodes_NonStaticEntitySetExpressionsAreNotSupportedInThisRelease);
            }
        }
    }
}
