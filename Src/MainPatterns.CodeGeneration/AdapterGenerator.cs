using System;
using Microsoft.CodeAnalysis;

//#pragma warning disable RS1035

namespace MainPatterns.CodeGeneration
{
    [Generator]
    public class AdapterGenerator : ISourceGenerator
    {

        //public IMovable Generate(Type type)
        //{
        //    this.classType = type;

        //    return (IMovable)Expression.Lambda<Action>(Expression.Block(Expression.Constant(GenerateClass(type))))
        //        .Compile().DynamicInvoke();
        //}

        //public object GetAdapter(Type type)
        //{
        //    var compiler = new CSharpCodeProvider();

        //    var parameters = new CompilerParameters
        //    {

        //    };

        //    var results = compiler
        //        .CompileAssemblyFromSource(parameters, GenerateClass(type)); //todo Отвал System.PlatformNotSupportedException: "Operation is not supported on this platform."

        //    var adapter = results
        //        .CompiledAssembly.GetType("TypeAdapter");

        //    return Activator.CreateInstance(adapter);
        //}

        //public void GenerateCsClassFile(Type type)
        //{
        //    //FileManager.Save(GenerateClass(type), FileManager.GetFilePath(type));
        //}

        //public string GenerateClass(Type type)
        //{
        //    var builder = new StringBuilder();

        //    //builder.AppendLine($"//Этот класс был сгенерирован в {DateTime.Now}");
        //    builder.AppendLine("using System;");
        //    builder.AppendLine("using MainPatterns.SpaceBattle.Actions;");
        //    builder.AppendLine("using MainPatterns.SpaceBattle.Calculations;");
        //    builder.AppendLine($"public class {type.Name}Adapter : {type}");
        //    builder.AppendLine("{");
        //    builder.AppendLine($"{typeof(SpaceObject)} obj;");
        //    builder.AppendLine($"public {type.Name}Adapter({typeof(SpaceObject)} obj) {{ this.obj = obj; }} ");

        //    GenerateCtor(type, builder);

        //    foreach (var method in type.GetMethods())
        //        GenerateMethod(type, method, builder);

        //    builder.AppendLine("}");
        //    return builder.ToString();
        //}

        //public void GenerateCtor(Type type, StringBuilder builder)
        //{
        //    builder.AppendLine("public IMovableAdapter() { }");
        //}

        //public void GenerateMethod(Type type, MethodInfo methodInfo, StringBuilder builder)
        //{
        //    var methodType = methodInfo.Name.Substring(0, 3);
        //    var attribute = methodInfo.Name.Substring(3);

        //    var parameterType = methodInfo.ReturnType.ToString();

        //    if (methodInfo.ReturnType == typeof(void)) parameterType = "void";

        //    builder.Append($"public {parameterType} {methodInfo.Name}(");

        //    GenerateParameters(methodInfo, builder);

        //    builder.Append(")\n{");

        //    switch (methodType)
        //    {
        //        case "set":
        //            builder.AppendLine(
        //                $"\nreturn IoC.Resolve<{methodInfo.ReturnType}>(\"{type.Name}.{attribute}.set\", obj, " +
        //                $"{methodInfo.GetParameters()[0].Name});");
        //            break;
        //        case "get":
        //            builder.AppendLine(
        //                $"\nreturn IoC.Resolve<{methodInfo.ReturnType}>(\"{type.Name}.{attribute}\", obj);");
        //            break;

        //        default:
        //            builder.Append(TryGetCurrentMethodRealization(methodInfo.Name, type));
        //            break;
        //    }

        //    builder.AppendLine("}");
        //}

        //public void GenerateParameters(MethodInfo methodInfo, StringBuilder builder)
        //{
        //    var parameters = methodInfo.GetParameters();

        //    for (var i = 0; i < parameters.Length; i++)
        //    {
        //        builder.Append($"{parameters[i].ParameterType} {parameters[i].Name}");

        //        if (i < parameters.Length - 1) builder.Append(", ");
        //    }
        //}

        //private string TryGetCurrentMethodRealization(string methodName, Type type)
        //{
        //    var filePath = FileManager.GetFilePath(type);

        //    var content = FileManager.Read(filePath);

        //    if (content.Contains(methodName))
        //    {
        //        var methodStart = content.IndexOf(methodName, StringComparison.Ordinal);
        //        methodStart = content.IndexOf("{", methodStart, StringComparison.Ordinal);
        //        var methodEnd = FindEndOfMethod(content, methodStart);
        //        return content.Substring(methodStart + 1, methodEnd - 1 - methodStart);
        //    }

        //    return "throw new Exception();";
        //}

        //public int FindEndOfMethod(string content, int methodStart)
        //{
        //    var methodEnd = content.IndexOf("}", methodStart, StringComparison.Ordinal);

        //    var unclosed = 1;

        //    for (var i = methodStart + 1; i < content.Length; i++)
        //    {
        //        switch (content[i])
        //        {
        //            case '{':
        //                unclosed++;
        //                break;

        //            case '}':
        //                unclosed--;
        //                break;
        //        }

        //        if (unclosed == 0) return i;
        //    }
        //    return methodEnd;
        //}

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // Find the main method
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

            // Build up the source code
            string source = $@"// <auto-generated/>
using System;

namespace {mainMethod.ContainingNamespace.ToDisplayString()}
{{
    public static partial class {mainMethod.ContainingType.Name}
    {{
        static partial void HelloFrom(string name) =>
            Console.WriteLine($""Generator says: Hi from '{{name}}'"");
    }}
}}
";
            var typeName = mainMethod.ContainingType.Name;

            // Add the source code to the compilation
            context.AddSource($"{typeName}.g.cs", source);
        }
    }
}