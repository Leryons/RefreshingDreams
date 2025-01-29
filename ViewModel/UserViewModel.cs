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
            await userServices.LoginUser(_email, _password);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
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
            await userServices.RegisterUser(_email, _name, _lastName, _password);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
}