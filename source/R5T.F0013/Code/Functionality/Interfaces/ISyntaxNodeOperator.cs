using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;
using R5T.T0134;


namespace R5T.F0013
{
    [FunctionalityMarker]
    public interface ISyntaxNodeOperator : IFunctionalityMarker,
        T0134.ISyntaxNodeOperator
    {
        public TParentNode AddNode<TParentNode, TNode>(
            TParentNode parentNode,
            TNode node,
            out ISyntaxNodeAnnotation<TNode> nodeAnnotation,
            Func<TParentNode, TNode, TParentNode> addSimple)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var annotatedNode = this.Annotate(node, out nodeAnnotation);

            parentNode = addSimple(parentNode, annotatedNode);

            return parentNode;
        }

        public CompilationUnitSyntax AddNamespace(
            CompilationUnitSyntax compilationUnit,
            NamespaceDeclarationSyntax @namespace,
            out ISyntaxNodeAnnotation<NamespaceDeclarationSyntax> namespaceAnnotation)
        {
            return this.AddNode(
                compilationUnit,
                @namespace,
                out namespaceAnnotation,
                Instances.SyntaxOperator.AddNamespace);
        }

        public CompilationUnitSyntax AddUsingDirective(
            CompilationUnitSyntax compilationUnit,
            UsingDirectiveSyntax usingDirective,
            out ISyntaxNodeAnnotation<UsingDirectiveSyntax> usingDirectiveAnnotation)
        {
            return this.AddNode(
                compilationUnit,
                usingDirective,
                out usingDirectiveAnnotation,
                Instances.SyntaxOperator.AddUsingDirective);
        }
    }
}