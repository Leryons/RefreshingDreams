namespace RefreshingDreams.Model;

public class Cocktail
{
    [JsonProperty("nombre")]
    public string? Name { get; set; }

    [JsonProperty("descripcion")]
    public string? Description { get; set; }

    [JsonProperty("precio")]
    public float? Price { get; set; }

    [JsonProperty("imagen")]
    public string? Img { get; set; }
}
