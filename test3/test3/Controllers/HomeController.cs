using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IActionResult Index()
    {
        return View();
    }
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult UploadJsonFile()
    {
        try
        {
            var file = Request.Form.Files[0];
            if (file != null && file.Length > 0)
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var json = streamReader.ReadToEnd();
                    var flowers = JsonSerializer.Deserialize<List<Flowers>>(json);
                    using (var db = new DataBase())
                    {
                        foreach (var flower in flowers)
                        {
                            db.Entry(flower).State = EntityState.Added;
                        }

                        db.SaveChanges();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while uploading JSON file and saving to the database.");
        }

        return RedirectToAction("Index");
    }
}
