using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Text;

namespace EnumGen.Generator
{
	[Generator]
	public class EnumExtensionsGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
//#if DEBUG
//			if (!Debugger.IsAttached)
//			{
//				Debugger.Launch();

//			}
//#endif
			context.RegisterForSyntaxNotifications(() => new EnumSyntaxReceiver());
		}

		public void Execute(GeneratorExecutionContext context)
		{
			var syntaxReceiver = (EnumSyntaxReceiver)context.SyntaxContextReceiver;

			foreach (var @enum in syntaxReceiver.Enums)
			{
				var enumNamespace = @enum.ContainingNamespace is null ? "EnumGen.Generated" : @enum.ContainingNamespace.ToDisplayString();


				var sourceText = SourceText.From($@"
namespace {enumNamespace}
{{
	public static partial class {@enum.Name}Extensions
	{{
		public static string MemberString(this {@enum.Name} @enum)
		{{
			return ""hello from generation!"";
		}}
	}}
}}
", Encoding.UTF8);

				context.AddSource($"{enumNamespace}.{@enum.Name}.generated.cs", sourceText);
			}
		}
	}
}
