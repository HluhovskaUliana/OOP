namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "HARVEST")
                    break;

                FieldInfo[] fields = type.GetFields(
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (FieldInfo field in fields)
                {
                    string accessModifier = GetAccessModifier(field);

                    if (command == "all" || command == accessModifier)
                    {
                        Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                    }
                }
            }
        }
        
        static string GetAccessModifier(FieldInfo field)
        {
            if (field.IsPrivate) return "private";
            if (field.IsPublic) return "public";
            if (field.IsFamily) return "protected"; 
            return "unknown";
        }

    }
}

