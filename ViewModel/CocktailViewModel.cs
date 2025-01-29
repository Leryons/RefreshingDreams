namespace RefreshingDreams.ViewModel;

public partial class CocktailViewModel : BaseViewModel
{
    private readonly CocktailServices cocktailServices;

    public ObservableCollection<Cocktail> Cocktails { get; set; } = new();

    public CocktailViewModel(CocktailServices cocktailServices)
    {
        this.cocktailServices = cocktailServices;

        LoadCocktails();
    }

    private async void LoadCocktails()
    {
        var cocktailList = await cocktailServices.GetCocktails();

        foreach (var cocktail in cocktailList)
        {
            Cocktails.Add(cocktail);
        }
    }
}
