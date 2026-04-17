using BcPhoRag.App.Configuration;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

var documentIntelligence = configuration
    .GetRequiredSection(AzureDocumentIntelligenceOptions.SectionName)
    .Get<AzureDocumentIntelligenceOptions>() ?? new AzureDocumentIntelligenceOptions();

var azureOpenAi = configuration
    .GetRequiredSection(AzureOpenAiOptions.SectionName)
    .Get<AzureOpenAiOptions>() ?? new AzureOpenAiOptions();

Console.WriteLine("BcPhoRag learning scaffold is ready.");
Console.WriteLine($"Document Intelligence configured: {IsConfigured(documentIntelligence.Endpoint)}");
Console.WriteLine($"Azure OpenAI configured: {IsConfigured(azureOpenAi.Endpoint)}");

return;

static string IsConfigured(string? value) => string.IsNullOrWhiteSpace(value) ? "no" : "yes";
