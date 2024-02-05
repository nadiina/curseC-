using Microsoft.AspNetCore.Mvc;

public class FlowersController : Controller
{
    private readonly DataBase _dbContext; // Замените ApplicationDbContext на ваш контекст базы данных

   /* public FlowersController(DataBase dbContext)
    {
        _dbContext = dbContext;
    }*/

    [HttpPost]
    public IActionResult SaveData(List<Flowers> flowers)
    {
        try
        {
            _dbContext.Flowers.AddRange(flowers);
            _dbContext.SaveChanges();
            return Ok("Data saved successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}
