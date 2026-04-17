namespace BcPhoRag.App.Configuration;

public sealed class AzureOpenAiOptions
{
    public const string SectionName = "AzureOpenAI";

    public string? Endpoint { get; init; }

    public string? ApiKey { get; init; }

    public string? EmbeddingsDeployment { get; init; }

    public string? ChatDeployment { get; init; }
}
