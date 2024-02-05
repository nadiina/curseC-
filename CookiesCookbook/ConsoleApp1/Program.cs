using ConsoleApp1.App;
using ConsoleApp1.DataAccess;
using ConsoleApp1.FileAccess;
using ConsoleApp1.Recipes;
using ConsoleApp1.Recipes.Inhredients;
using System.Text.Json;
var ingredientsRegister = new IngredientsRegister();



const FileFormat Format = FileFormat.Json;
IStringslRepository stringslRepository = Format == FileFormat.Json ?
    new StringJsonRepository() : new StringTextualRepository();

const string FileName = "recipes";
var fileMetadata = new FileMetadata(FileName, Format);

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(stringslRepository,
    ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister));
cookiesRecipesApp.Run(fileMetadata.ToPath());


