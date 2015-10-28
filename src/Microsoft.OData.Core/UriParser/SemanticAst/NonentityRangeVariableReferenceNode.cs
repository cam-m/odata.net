﻿//---------------------------------------------------------------------
// <copyright file="NonentityRangeVariableReferenceNode.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.OData.Core.UriParser.Semantic
{
    #region Namespaces
    using System;
    using Microsoft.OData.Core.UriParser.TreeNodeKinds;
    using Microsoft.OData.Core.UriParser.Visitors;
    using Microsoft.OData.Edm;
    #endregion Namespaces

    /// <summary>
    /// A node that represents a rangeVariable that iterates over a non entity collection.
    /// </summary>
    public sealed class NonentityRangeVariableReferenceNode : SingleValueNode
    {
        /// <summary>
        ///  The name of the associated rangeVariable
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The type item referred to by this rangeVariable.
        /// </summary>
        private readonly IEdmTypeReference typeReference;

        /// <summary>
        /// Reference to a rangeVariable on the binding stack.
        /// </summary>
        private readonly NonentityRangeVariable rangeVariable;

        /// <summary>
        /// Creates a <see cref="NonentityRangeVariableReferenceNode"/>.
        /// </summary>
        /// <param name="name"> The name of the associated rangeVariable</param>
        /// <param name="rangeVariable">Reference to a rangeVariable on the binding stack.</param>
        /// <exception cref="System.ArgumentNullException">Throws if input name or rangeVariable is null.</exception>
        public NonentityRangeVariableReferenceNode(string name, NonentityRangeVariable rangeVariable)
        {
            ExceptionUtils.CheckArgumentNotNull(name, "name");
            ExceptionUtils.CheckArgumentNotNull(rangeVariable, "rangeVariable");
            this.name = name;
            this.typeReference = rangeVariable.TypeReference;
            this.rangeVariable = rangeVariable;
        }

        /// <summary>
        /// Gets the name of the associated rangeVariable.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the type item referred to by this rangeVariable.
        /// </summary>
        public override IEdmTypeReference TypeReference
        {
            get { return this.typeReference; }
        }

        /// <summary>
        /// Gets the reference to a rangeVariable on the binding stack.
        /// </summary>
        public NonentityRangeVariable RangeVariable
        {
            get { return this.rangeVariable; }
        }

        /// <summary>
        /// Gets the kind of this node.
        /// </summary>
        internal override InternalQueryNodeKind InternalKind
        {
            get
            {
                return InternalQueryNodeKind.NonentityRangeVariableReference;
            }
        }

        /// <summary>
        /// Accept a <see cref="QueryNodeVisitor{T}"/> that walks a tree of <see cref="QueryNode"/>s.
        /// </summary>
        /// <typeparam name="T">Type that the visitor will return after visiting this token.</typeparam>
        /// <param name="visitor">An implementation of the visitor interface.</param>
        /// <returns>An object whose type is determined by the type parameter of the visitor.</returns>
        /// <exception cref="System.ArgumentNullException">Throws if the input visitor is null.</exception>
        public override T Accept<T>(QueryNodeVisitor<T> visitor)
        {
            ExceptionUtils.CheckArgumentNotNull(visitor, "visitor");
            return visitor.Visit(this);
        }
    }
}