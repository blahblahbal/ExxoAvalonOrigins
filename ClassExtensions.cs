using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;

namespace ExxoAvalonOrigins
{
    public static class ClassExtensions
    {
        public static bool exists(this Item item)
        {
            return item.type > 0 && item.stack > 0;
        }
        
        public static int AddVariable(this ILContext context, Type type)
        {
            context.Body.Variables.Add(new VariableDefinition(context.Import(type)));
            return context.Body.Variables.Count - 1;
        }
        
        public static int GetArgumentIndex(this ILContext context, string name)
        {
            ParameterDefinition def = context.Method.Parameters.FirstOrDefault(parameter => parameter.Name == name);
            return def?.Index + 1 ?? throw new Exception($"Parameter with name '{name}' does not exist!");
        }
    }
}