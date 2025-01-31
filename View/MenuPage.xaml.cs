namespace RefreshingDreams.View;

public partial class MenuPage : ContentPage
{
    public MenuPage(CocktailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCocktailSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext is CocktailViewModel viewModel)
        {
            viewModel.OnCocktailSelectionChanged(sender, e);
        }
    }

    private async void GoToBill(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirmación.", "¿Desea continuar?", "Aceptar", "Cancelar");

        if (answer)
        {
            Shell.Current.GoToAsync(nameof(BillPage));
        }
    }
}