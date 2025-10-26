namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;
    
    public class BlackBoxIntegerTest
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxIntegerTest);
            
            ConstructorInfo ctor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

            object instance = ctor.Invoke(null);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split('_');
                string methodName = parts[0];
                int value = int.Parse(parts[1]);
                
                MethodInfo method = type.GetMethod(
                    methodName,
                    BindingFlags.Instance | BindingFlags.NonPublic);

                method.Invoke(instance, new object[] { value });

                FieldInfo field = type.GetField(
                    "innerValue",
                    BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(instance));
            }

        }
    }
}

