using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace GenerateClasses
{
    [Generator]
    public class GeneratorOwnClass : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);


            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch();
            //}

            foreach (var syntaxTree in context.Compilation.SyntaxTrees)
            {
                var model = context.Compilation.GetSemanticModel(syntaxTree);

                var classes = syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>();

                foreach (var classDecl in classes)
                {
                    var classSymbol = model.GetDeclaredSymbol(classDecl);

                    if (classSymbol.GetAttributes().Any(att => att.AttributeClass.ToDisplayString().Contains("MonAttribut")))
                    {

                    }
                }

            }


            //context.AddSource($"{mainMethod.ContainingType.Name}.g.cs", "public class HelloWorld {}");
        }

        public void Initialize(GeneratorInitializationContext context)
        {

        }
    }
}
