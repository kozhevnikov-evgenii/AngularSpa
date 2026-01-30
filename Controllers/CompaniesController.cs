using angularSPA.Data;
using angularSPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angularSPA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await context.Companies
            .Include(x => x.Activity)
            .ToListAsync();
        return Ok(companies);
    }
}
