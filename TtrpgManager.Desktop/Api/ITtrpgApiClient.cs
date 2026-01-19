using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TtrpgManager.Desktop.Api;

public interface ITtrpgApiClient
{
    Task<List<CampaignDto>> GetCampaignsAsync(
        CancellationToken cancellationToken = default);
}
