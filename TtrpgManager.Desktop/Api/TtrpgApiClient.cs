using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TtrpgManager.Desktop.Api;

public sealed class TtrpgApiClient : ITtrpgApiClient
{
    public readonly HttpClient HttpClient;

    public TtrpgApiClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<List<CampaignDto>> GetCampaignsAsync(CancellationToken cancellationToken = default)
    {
        var result = await HttpClient.GetFromJsonAsync<List<CampaignDto>>("/api/campaigns", cancellationToken);
        return result ?? new List<CampaignDto>();
    }
}

