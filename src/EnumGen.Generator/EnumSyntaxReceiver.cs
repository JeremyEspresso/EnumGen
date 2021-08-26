using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace EnumGen.Generator
{
	internal class EnumSyntaxReceiver : ISyntaxContextReceiver
	{
		public List<(ISymbol, SeparatedSyntaxList<EnumMemberDeclarationSyntax>)> Enums { get; } = new List<(ISymbol, SeparatedSyntaxList<EnumMemberDeclarationSyntax>)>();

		public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
		{
			if (context.Node is EnumDeclarationSyntax { AttributeLists: { Count: > 0 } } eds)
			{
				var enumSymbol = context.SemanticModel.GetDeclaredSymbol(eds);
				var enumGenAttribute = enumSymbol?.GetAttributes().SingleOrDefault(attr => attr.AttributeClass?.ToDisplayString() == "EnumGen.EnumGenAttribute");

				if (enumSymbol != null && enumGenAttribute != null)
				{
					Enums.Add(new(enumSymbol, eds.Members));
				}
			}
		}
	}
}
