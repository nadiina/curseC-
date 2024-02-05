namespace ConsoleApp1.Recipes.Inhredients;

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions} ";

}
