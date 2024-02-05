namespace ConsoleApp1.Recipes.Inhredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions =>
        $"Sieve. {base.PreparationInstructions}";
}
