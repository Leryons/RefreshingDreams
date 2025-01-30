namespace RefreshingDreams.View;

public partial class LoginPage : ContentPage
{
	public LoginPage(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void SignUp(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("SignUpPage");
	}
}