using System.Text.Json;
using Azure.Identity;
using Pipeline.Core;

var repo = GetOption(args, "--repo");
var prValue = GetOption(args, "--pr");
var buildValue = GetOption(args, "--build");

if (repo is null)
{
    PrintUsage();
    return 1;
}

var parts = repo.Split('/');
if (parts.Length != 2)
{
    Console.Error.WriteLine($"Error: --repo must be in owner/repository format, got '{repo}'");
    return 1;
}

var owner = parts[0];
var repository = parts[1];

if (prValue is null && buildValue is null)
{
    PrintUsage();
    return 1;
}

var credential = new DefaultAzureCredential();
var helix = await Helix.CreateAsync(credential);

List<HelixWorkItem> workItems;
if (prValue is not null)
{
    if (!int.TryParse(prValue, out var prNumber))
    {
        Console.Error.WriteLine($"Error: --pr must be an integer, got '{prValue}'");
        return 1;
    }
    workItems = await helix.GetHelixWorkItemsForPullRequestAsync(owner, repository, prNumber);
}
else
{
    if (!int.TryParse(buildValue, out var buildNumber))
    {
        Console.Error.WriteLine($"Error: --build must be an integer, got '{buildValue}'");
        return 1;
    }
    workItems = await helix.GetHelixWorkItemsForBuild(owner, repository, buildNumber);
}

var options = new JsonSerializerOptions { WriteIndented = true };
Console.WriteLine(JsonSerializer.Serialize(workItems, options));
return 0;

static string? GetOption(string[] args, string name)
{
    for (int i = 0; i < args.Length - 1; i++)
    {
        if (args[i] == name)
            return args[i + 1];
    }
    return null;
}

static void PrintUsage()
{
    Console.Error.WriteLine("Usage:");
    Console.Error.WriteLine("  pipeline --repo <owner/repo> --pr <number>");
    Console.Error.WriteLine("  pipeline --repo <owner/repo> --build <number>");
}
