namespace ConsoleApp1.Recipes.Inhredients;

public class Sugar : Ingredient
{
    public override int Id => 5;

    public override string Name => "Sugar";
    public override string PreparationInstructions => $"{base.PreparationInstructions}";
}
