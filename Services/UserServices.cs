namespace RefreshingDreams.Services;

public class UserServices : ContentPage
{
    private readonly SQLiteAsyncConnection sQLite;

    public UserServices()
    {
        sQLite = new SQLiteAsyncConnection(".//User.db3");
        sQLite.CreateTableAsync<User>().Wait();
    }

    public Task<User> LoginUser(string email, string password)
    {
        return sQLite.Table<User>()
                     .Where(p => p.Email == email && p.Password == password)
                     .FirstOrDefaultAsync();
    }

    public async Task<bool> RegisterUser(string email, string name, string lastname,string password)
    {
        var existingUser = await sQLite.Table<User>()
                                       .Where(p => p.Email == email) 
                                       .FirstOrDefaultAsync();

        if (existingUser != null)
        {
            return false;
        }

        var newUser = new User
        {
            Email = email,
            Name = name,
            LastName = lastname,
            Password = password
        };

        await sQLite.InsertAsync(newUser);

        await DisplayAlert("Éxito", "Registro completado", "OK");
        return true;
    }
}
