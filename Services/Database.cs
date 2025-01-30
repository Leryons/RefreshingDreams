namespace RefreshingDreams.Services;

public class Database
{
    private readonly SQLiteAsyncConnection sQLite;

    public Database()
    {
        try
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db");
            sQLite = new SQLiteAsyncConnection(path);
            sQLite.CreateTableAsync<User>().Wait();

            Debug.WriteLine($"Path: {path}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex}");
        }
    }

    public SQLiteAsyncConnection sQLiteAsyncConnection => sQLite;
}
