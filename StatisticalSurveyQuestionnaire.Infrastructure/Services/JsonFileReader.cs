using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text.Json;
namespace StatisticalSurveyQuestionnaire.Infrastructure.Services;

public class JsonFileReader : IJsonFileReader
{
    //private readonly IHostEnvironment _environment;

    //public JsonFileReader(IHostEnvironment environment)
    //{
    //    _environment = environment;
    //}

    public async Task<T?> ReadAsync<T>(string fileName)
    {
        //new
        var assemblyLocation = Path.GetDirectoryName(
          Assembly.GetExecutingAssembly().Location);
        //
        var path = Path.Combine(
           //_environment.ContentRootPath,
           assemblyLocation!,
           "Persistence",
           "Seed",
           "Data",
           fileName);

        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        var json = await File.ReadAllTextAsync(path);

        //return JsonSerializer.Deserialize<T>(json);

        return JsonSerializer.Deserialize<T>(
           json,
           new JsonSerializerOptions
           {
               PropertyNameCaseInsensitive = true
           });
    }
}
