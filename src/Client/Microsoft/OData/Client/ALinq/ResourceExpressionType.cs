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

namespace Microsoft.OData.Client
{
    /// <summary>Enum for resource expression types</summary>
    internal enum ResourceExpressionType
    {
        /// <summary>ResourceSet Expression</summary>
        RootResourceSet = 10000,

        /// <summary>Single resource expression, used to represent singleton.</summary>
        RootSingleResource,

        /// <summary>Resource Navigation Expression</summary>
        ResourceNavigationProperty,

        /// <summary>Resource Navigation Expression to Singleton</summary>
        ResourceNavigationPropertySingleton,

        /// <summary>Take Query Option Expression</summary>
        TakeQueryOption,

        /// <summary>Skip Query Option Expression</summary>
        SkipQueryOption,

        /// <summary>OrderBy Query Option Expression</summary>
        OrderByQueryOption,

        /// <summary>Filter Query Option Expression</summary>
        FilterQueryOption,

        /// <summary>Reference to a bound component of the resource set path</summary>
        InputReference,

        /// <summary>Projection Query Option Expression</summary>
        ProjectionQueryOption,

        /// <summary>Expand Query Option Expression</summary>
        ExpandQueryOption,
    }
}
