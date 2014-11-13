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

namespace Microsoft.OData.Edm.Library
{
    /// <summary>
    /// Represents an EDM value term.
    /// </summary>
    public class EdmTerm : EdmNamedElement, IEdmValueTerm
    {
        private readonly string namespaceName;
        private readonly IEdmTypeReference type;
        private readonly string appliesTo;
        private readonly string defaultValue;

        /// <summary>
        /// Initializes a new instance of <see cref="EdmTerm"/> class.
        /// The new term will be of the nullable primitive <paramref name="type"/>.
        /// </summary>
        /// <param name="namespaceName">Namespace of the term.</param>
        /// <param name="name">Name of the term.</param>
        /// <param name="type">Type of the term.</param>
        public EdmTerm(string namespaceName, string name, EdmPrimitiveTypeKind type)
            : this(namespaceName, name, type, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EdmTerm"/> class.
        /// The new term will be of the nullable primitive <paramref name="type"/>.
        /// </summary>
        /// <param name="namespaceName">Namespace of the term.</param>
        /// <param name="name">Name of the term.</param>
        /// <param name="type">Type of the term.</param>
        /// <param name="appliesTo">AppliesTo of the term.</param>
        public EdmTerm(string namespaceName, string name, EdmPrimitiveTypeKind type, string appliesTo)
            : this(namespaceName, name, EdmCoreModel.Instance.GetPrimitive(type, true), appliesTo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmTerm"/> class.
        /// </summary>
        /// <param name="namespaceName">Namespace of the term.</param>
        /// <param name="name">Name of the term.</param>
        /// <param name="type">Type of the term.</param>
        public EdmTerm(string namespaceName, string name, IEdmTypeReference type)
            : this(namespaceName, name, type, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmTerm"/> class.
        /// </summary>
        /// <param name="namespaceName">Namespace of the term.</param>
        /// <param name="name">Name of the term.</param>
        /// <param name="type">Type of the term.</param>
        /// <param name="appliesTo">AppliesTo of the term.</param>
        public EdmTerm(string namespaceName, string name, IEdmTypeReference type, string appliesTo)
            : this(namespaceName, name, type, appliesTo, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmTerm"/> class.
        /// </summary>
        /// <param name="namespaceName">Namespace of the term.</param>
        /// <param name="name">Name of the term.</param>
        /// <param name="type">Type of the term.</param>
        /// <param name="appliesTo">AppliesTo of the term.</param>
        /// <param name="defaultValue">DefaultValue of the term.</param>
        public EdmTerm(string namespaceName, string name, IEdmTypeReference type, string appliesTo, string defaultValue)
            : base(name)
        {
            EdmUtil.CheckArgumentNull(namespaceName, "namespaceName");
            EdmUtil.CheckArgumentNull(type, "type");

            this.namespaceName = namespaceName;
            this.type = type;
            this.appliesTo = appliesTo;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Gets the namespace of this term.
        /// </summary>
        public string Namespace
        {
            get { return this.namespaceName; }
        }

        /// <summary>
        /// Gets the kind of this term.
        /// </summary>
        public EdmTermKind TermKind
        {
            get { return EdmTermKind.Value; }
        }

        /// <summary>
        /// Gets the type of this term.
        /// </summary>
        public IEdmTypeReference Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Gets the AppliesTo of this term.
        /// </summary>
        public string AppliesTo
        {
            get { return this.appliesTo; }
        }

        /// <summary>
        /// Gets the DefaultValue of this term.
        /// </summary>
        public string DefaultValue
        {
            get { return this.defaultValue; }
        }

        /// <summary>
        /// Gets the schema element kind of this term.
        /// </summary>
        public EdmSchemaElementKind SchemaElementKind
        {
            get { return EdmSchemaElementKind.ValueTerm; }
        }
    }
}
