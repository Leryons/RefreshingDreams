namespace RefreshingDreams.Services;

public class UserServices
{
    private readonly Database db;

    public UserServices(Database database)
    {
        db = database;
    }

    public async Task<User> LoginUser(string email, string password)
    {
        return await db.sQLiteAsyncConnection.Table<User>()
                                             .Where(p => p.Email == email && p.Password == password)
                                             .FirstOrDefaultAsync();
    }

    public async Task<bool> RegisterUser(string email, string name, string lastname,string password)
    {
        var existingUser = await db.sQLiteAsyncConnection.Table<User>()
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

        await db.sQLiteAsyncConnection.InsertAsync(newUser);
        return true;
    }
}
