namespace RefreshingDreams.Services;

public class CocktailServices
{
    private readonly HttpClient httpClient;
    private List<Cocktail> cocktails;

    public CocktailServices() 
    {
        this.httpClient = new HttpClient();
        cocktails = new List<Cocktail>();
    }

    public async Task<List<Cocktail>> GetCocktails()
    {
        var url = "https://raw.githubusercontent.com/Leryons/Cocktails/refs/heads/main/Cocktails.json";
        HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
        responseMessage.EnsureSuccessStatusCode();

        string responsebody = await responseMessage.Content.ReadAsStringAsync();
        var jArray = JArray.Parse(responsebody);

        if (cocktails != null)
        {
            cocktails.Clear();
        }

        foreach (var prop in jArray)
        {
            Cocktail cocktail = new Cocktail
            {
                Name = prop["nombre"]?.ToString(),
                Description = prop["descripcion"]?.ToString(),
                Price = prop["precio"]?.ToObject<float>(),
                Img = prop["imagen"]?.ToString(),

            };

            cocktails.Add(cocktail);
        }
        return cocktails;
    }
}
