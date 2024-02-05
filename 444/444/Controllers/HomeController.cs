// HomeController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Display the form
    public IActionResult Index()
    {
        return View();
    }

    // Handle the file upload and save data to the database
    [HttpPost]
    public IActionResult UploadJsonFile()
    {
        try
        {
            var file = Request.Form.Files["files"]; // Assuming the input file has the name "files"
            if (file != null && file.Length > 0)
            {
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    var flowersJsonData = stream.ReadToEnd();
                    var flowers = JsonSerializer.Deserialize<List<Flowers>>(flowersJsonData);

                    if (flowers != null)
                    {
                        using (var db = new DataBase())
                        {
                            db.Flowers?.AddRange(flowers);
                            db.SaveChanges();
                        }
                    }

                    _logger.LogInformation("Data saved successfully.");
                }
            }

            return RedirectToAction("Index"); // Redirect to the form page
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing file upload: {ex.Message}");
            // Handle the error appropriately, e.g., display an error message to the user
            return RedirectToAction("Index");
        }
    }
    public IActionResult ShowTree()
    {
        using (var db = new DataBase())
        {
            var flowers = db.Flowers.ToList();
            return View(flowers);
        }
    }


}
