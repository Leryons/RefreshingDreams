namespace RefreshingDreams.View;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}