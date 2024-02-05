namespace ConsoleApp1.Recipes.Inhredients;

public class CocoaPowder : Ingredient
{
    public override int Id => 8;

    public override string Name => "Cocoa powder";
    public override string PreparationInstructions => $"{base.PreparationInstructions}";
}
