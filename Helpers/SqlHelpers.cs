using System.Reflection;

namespace VersioningDemo.Helpers;

public static class SqlHelpers
{
    public static string GetEmbeddedResource(string resourceName)
    {
        var assembly = typeof(SqlHelpers).GetTypeInfo().Assembly;
        var fullResourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));
        if (fullResourceName == null)
        {
            Console.WriteLine($"Could not find embedded resource named {resourceName}");
            throw new Exception($"Could not find embedded resource named {resourceName}");
        }
        using var stream = assembly.GetManifestResourceStream(fullResourceName);
        using var reader = new StreamReader(stream!);
        return reader.ReadToEnd();
    }
}