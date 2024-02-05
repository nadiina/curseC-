namespace ConsoleApp1.Recipes.Inhredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
{
    new WheatFlour(),
    new Butter(),
    new Chocolate(),
    new Sugar(),
    new Cardamom(),
    new Cinnamon(),
    new CocoaPowder(),
};

    public Ingredient GetById(int id)
    {
        foreach (var inhredient in All)
        {
            if (inhredient.Id == id)
            {
                return inhredient;
            }
        }
        return null;
    }
}
