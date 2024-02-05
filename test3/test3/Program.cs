/*using System.Text.Json;

string flowersJsonData = File.ReadAllText("json.json");
var flowers = JsonSerializer.Deserialize<List<Flowers>>(flowersJsonData);

if (flowers != null)
{
    foreach (var flower in flowers)
    {
        Console.WriteLine(flower.FlowerName);
    }
}

Console.WriteLine("Saving");

var db = new DataBase();

db.Flowers?.AddRange(flowers);
    db.SaveChanges();
Console.WriteLine("saved");*/


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
