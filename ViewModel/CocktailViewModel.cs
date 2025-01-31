namespace RefreshingDreams.ViewModel;

public partial class CocktailViewModel : BaseViewModel
{
    private readonly CocktailServices cocktailServices;

    public ObservableCollection<Cocktail> Cocktails { get; set; } = []; // Where the Cocktails were added

    public ObservableCollection<Cocktail> SelectedCocktails { get; set; } = []; // Selected Cocktails on View

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

    public void OnCocktailSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.PreviousSelection)
        {
            if (item is Cocktail cocktail)
            {
                SelectedCocktails.Remove(cocktail);
            }
        }

        foreach (var item in e.CurrentSelection)
        {
            if (item is Cocktail cocktail)
            {
                SelectedCocktails.Add(cocktail);
            }
        }
    }

    [RelayCommand]
    private async Task BuyCocktails()
    {
        if (SelectedCocktails.Any())
        {
            decimal total = (decimal)SelectedCocktails.Sum(c => c.Price);

            await Task.Delay(100);
            string invoiceDetails = "Factura:\n\n";
            foreach (var cocktail in SelectedCocktails)
            {
                invoiceDetails += $"{cocktail.Name} - ${cocktail.Price:F2}\n";
            }
            invoiceDetails += $"\nTotal: ${total:F2}";

            await Shell.Current.DisplayAlert("Factura", invoiceDetails, "OK");

        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Selecciona al menos un cóctel", "OK");
        }
    }

    [RelayCommand]
    private async Task Delivery()
    {
        Random random = new Random();

        int randomTime = random.Next(15, 60);
        decimal total = (decimal)SelectedCocktails.Sum(c => c.Price);

        if (SelectedCocktails.Any())
        {
            bool answer = await Shell.Current.DisplayAlert("Confirmar", $"¿Finalizó su pedido? Total: {total}$", "Si", "No");

            if (answer)
            {
                
                string invoiceDetails = "Factura:\n\n";
                foreach (var cocktail in SelectedCocktails)
                {
                    invoiceDetails += $"{cocktail.Name} - ${cocktail.Price:F2}\n";
                }
                invoiceDetails += $"\nTotal: ${total:F2}";

                await Shell.Current.DisplayAlert("Factura", invoiceDetails, "OK");

                await Task.Delay(750);

                Shell.Current.DisplayAlert("Pedido Realizado", $"Su pedido llegará en aproximadamente:  {randomTime} minutos", "OK");

                Shell.Current.GoToAsync("MenuPage");
            }

        }
    }
}