using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TtrpgManager.Domain;
using TtrpgManager.Infrastructure.Persistence;

namespace TtrpgManager.Api.Controllers;

[ApiController]
[Route("api/campaigns")]
public class CampaignsController : ControllerBase
{
    private readonly TtrpgManagerDbContext _db;

    public CampaignsController(TtrpgManagerDbContext db)
    {
        _db = db;
    }

    // GET /api/campaigns
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var campaigns = await _db.Campaigns
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CampaignDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                CoverImageId = c.CoverImageId
            })
            .ToListAsync();

        return Ok(campaigns);
    }

    // GET /api/campaigns/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var campaign = await _db.Campaigns
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new CampaignDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                CoverImageId = c.CoverImageId
            })
            .FirstOrDefaultAsync();

        if (campaign is null)
            return NotFound();

        return Ok(campaign);
    }

    // POST /api/campaigns
    [HttpPost]
    public async Task<IActionResult> Create(CreateCampaignRequest request)
    {
        var campaign = new Campaign(request.Name, request.Description);

        _db.Campaigns.Add(campaign);
        await _db.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = campaign.Id },
            new { campaign.Id }
        );
    }

    // ===== DTOs =====

    public sealed class CampaignDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = "";
        public string? Description { get; init; }
        public string? CoverImageId { get; init; }
    }

    public sealed class CreateCampaignRequest
    {
        public string Name { get; init; } = "";
        public string? Description { get; init; }
    }
}

