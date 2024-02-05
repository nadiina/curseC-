using ConsoleApp1.DataAccess;
using ConsoleApp1.Recipes.Inhredients;

namespace ConsoleApp1.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringslRepository _stringslRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";
    public RecipesRepository(IStringslRepository stringslRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringslRepository = stringslRepository;
        _ingredientsRegister = ingredientsRegister;

    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringslRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }
        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsString = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsString.Add(string.Join(Separator, allIds));
        }

        _stringslRepository.Write(filePath, recipesAsString);
    }
}
