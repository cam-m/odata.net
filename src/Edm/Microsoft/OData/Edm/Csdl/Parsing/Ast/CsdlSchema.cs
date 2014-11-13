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

using System;
using System.Collections.Generic;

namespace Microsoft.OData.Edm.Csdl.Parsing.Ast
{
    /// <summary>
    /// Represents a CSDL schema.
    /// </summary>
    internal class CsdlSchema : CsdlElementWithDocumentation
    {
        private readonly List<CsdlStructuredType> structuredTypes;
        private readonly List<CsdlEnumType> enumTypes;
        private readonly List<CsdlOperation> operations;
        private readonly List<CsdlTerm> terms;
        private readonly List<CsdlEntityContainer> entityContainers;
        private readonly List<CsdlAnnotations> outOfLineAnnotations;
        private readonly List<CsdlTypeDefinition> typeDefinitions;

        private readonly string alias;
        private readonly string namespaceName;
        private readonly Version version;

        public CsdlSchema(
            string namespaceName,
            string alias,
            Version version,
            IEnumerable<CsdlStructuredType> structuredTypes,
            IEnumerable<CsdlEnumType> enumTypes,
            IEnumerable<CsdlOperation> operations,
            IEnumerable<CsdlTerm> terms,
            IEnumerable<CsdlEntityContainer> entityContainers,
            IEnumerable<CsdlAnnotations> outOfLineAnnotations,
            IEnumerable<CsdlTypeDefinition> typeDefinitions,
            CsdlDocumentation documentation,
            CsdlLocation location)
            : base(documentation, location)
        {
            this.alias = alias;
            this.namespaceName = namespaceName;
            this.version = version;
            this.structuredTypes = new List<CsdlStructuredType>(structuredTypes);
            this.enumTypes = new List<CsdlEnumType>(enumTypes);
            this.operations = new List<CsdlOperation>(operations);
            this.terms = new List<CsdlTerm>(terms);
            this.entityContainers = new List<CsdlEntityContainer>(entityContainers);
            this.outOfLineAnnotations = new List<CsdlAnnotations>(outOfLineAnnotations);
            this.typeDefinitions = new List<CsdlTypeDefinition>(typeDefinitions);
        }

        public IEnumerable<CsdlStructuredType> StructuredTypes
        {
            get { return this.structuredTypes; }
        }

        public IEnumerable<CsdlEnumType> EnumTypes
        {
            get { return this.enumTypes; }
        }

        public IEnumerable<CsdlOperation> Operations
        {
            get { return this.operations; }
        }

        public IEnumerable<CsdlTerm> Terms
        {
            get { return this.terms; }
        }

        public IEnumerable<CsdlEntityContainer> EntityContainers
        {
            get { return this.entityContainers; }
        }

        public IEnumerable<CsdlAnnotations> OutOfLineAnnotations
        {
            get { return this.outOfLineAnnotations; }
        }

        public IEnumerable<CsdlTypeDefinition> TypeDefinitions
        {
            get { return this.typeDefinitions; }
        }

        public string Alias
        {
            get { return this.alias; }
        }

        public string Namespace
        {
            get { return this.namespaceName; }
        }

        public Version Version
        {
            get { return this.version; }
        }
    }
}
