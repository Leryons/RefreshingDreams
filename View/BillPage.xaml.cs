namespace RefreshingDreams.View;

public partial class BillPage : ContentPage
{
	public BillPage(CocktailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}