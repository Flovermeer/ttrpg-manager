using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TtrpgManager.Desktop.Api;
public sealed class TtrpgApiClient
{
    public readonly HttpClient HttpClient;

    public TtrpgApiClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<List<CampaignDto>> ListCampaignsAsync(CancellationToken cancellationToken = default)
    {
        var result = await HttpClient.GetFromJsonAsync<List<CampaignDto>>("/api/campaigns", cancellationToken);
        return result ?? new List<CampaignDto>();
    }
}

