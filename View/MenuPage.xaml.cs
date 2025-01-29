namespace RefreshingDreams.View;

public partial class MenuPage : ContentPage
{
    public MenuPage(CocktailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}