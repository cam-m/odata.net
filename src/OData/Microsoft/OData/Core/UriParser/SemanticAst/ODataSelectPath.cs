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

namespace Microsoft.OData.Core.UriParser.Semantic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using ODataErrorStrings = Microsoft.OData.Core.Strings;

    /// <summary>
    /// A specific type of <see cref="ODataPath"/> which can only contain instances of <see cref="TypeSegment"/>, <see cref="NavigationPropertySegment"/>,
    /// <see cref="PropertySegment"/>, <see cref="OperationSegment"/>, or <see cref="OpenPropertySegment"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "ODataSelectPathCollection just doesn't sound right")]
    public class ODataSelectPath : ODataPath
    {
        /// <summary>
        /// Create an ODataSelectPath
        /// </summary>
        /// <param name="segments">The list of segments that makes up this path.</param>
        /// <exception cref="ODataException">Throws if the list of segments doesn't match the requirements for a path in $select</exception>
        public ODataSelectPath(IEnumerable<ODataPathSegment> segments)
            : base(segments)
        {
            this.ValidatePath();
        }

        /// <summary>
        /// Create an ODataPath object based on a single segment
        /// </summary>
        /// <param name="segments">The list of segments that makes up this path.</param>
        /// <exception cref="ODataException">Throws if the list of segments doesn't match the requirements for a path in $select</exception>
        public ODataSelectPath(params ODataPathSegment[] segments)
            : base(segments)
        {
            this.ValidatePath();
        }

        /// <summary>
        /// Ensure that the segments given to us are valid select segments.
        /// </summary>
        /// <exception cref="ODataException">Throws if the list of segments doesn't match the requirements for a path in $select</exception>
        private void ValidatePath()
        {
            int index = 0;
            foreach (ODataPathSegment segment in this)
            {
                if (segment is NavigationPropertySegment)
                {
                    if (index != this.Count - 1)
                    {
                        throw new ODataException(ODataErrorStrings.ODataSelectPath_NavPropSegmentCanOnlyBeLastSegment);
                    }
                }
                else if (segment is OperationSegment)
                {
                    if (index != this.Count - 1)
                    {
                        throw new ODataException(ODataErrorStrings.ODataSelectPath_OperationSegmentCanOnlyBeLastSegment);
                    }
                }
                else if (segment is TypeSegment)
                {
                    if (index == this.Count - 1)
                    {
                        throw new ODataException(ODataErrorStrings.ODataSelectPath_CannotEndInTypeSegment);
                    }
                }
                else if (segment is OpenPropertySegment || segment is PropertySegment)
                {
                    continue;
                }
                else
                {
                    throw new ODataException(ODataErrorStrings.ODataSelectPath_InvalidSelectPathSegmentType(segment.GetType().Name));
                }

                index++;
            }
        }
    }
}
