namespace RefreshingDreams.ViewModel;

public partial class UserViewModel : BaseViewModel
{
    private readonly UserServices userServices;

    public UserViewModel(UserServices userServices)
    {
        this.userServices = userServices;
    }

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _lastName;

    [ObservableProperty]
    private string _password;

    [RelayCommand] //Find user
    public async Task LoginUserAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            var user = await userServices.LoginUser(_email, _password);

            if (user != null)
            {
                await Shell.Current.DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");

                await Shell.Current.GoToAsync("MenuPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Ocurrió un error al iniciar sesión", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand] //Add new user
    public async Task RegisterUserAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            bool isRegistered = await userServices.RegisterUser(_email, _name, _lastName, _password);

            if (isRegistered)
            {
                await Shell.Current.DisplayAlert("Éxito", "Registro completado", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "El usuario ya existe", "OK");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally 
        {
            IsBusy = false;
        }
    }
}