using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

// Rajapinta, joka määrittelee metodin musiikkigenrejen hakemiseen
public interface IApiService
{
    Task<List<string>> GetStringsAsync();
}

// Rajapinnan toteutus, joka käyttää HttpClientia API-kutsuihin
public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    // alustetaan HttpClient
    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Metodi hakee 5 satunnaista musiikkigenreä API:sta
    public async Task<List<string>> GetStringsAsync()
    {
        var url = "https://binaryjazz.us/wp-json/genrenator/v1/genre/5";

        try
        {
            // Lähetetään GET-pyyntö API:lle
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Luetaan vastaus JSON-muodossa
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // muutetaan JSON lista-muotoon
            var genres = JsonSerializer.Deserialize<List<string>>(jsonResponse);

            return genres ?? new List<string>();
        }
        catch (Exception ex)
        {
            // Virheilmoitus
            Console.WriteLine($"Tapahtui virhe genrejen haussa: {ex.Message}");
            return new List<string> { "Virhe genrejen haussa" };
        }
    }
}


class Program
{

    static async Task Main(string[] args)
    {
        using var httpClient = new HttpClient();

        // Luodaan ApiService-olio
        IApiService apiService = new ApiService(httpClient);

        // Haetaan musiikkigenret
        var result = await apiService.GetStringsAsync();

        // Tulostetaan genret konsoliin
        Console.WriteLine("Satunnaiset musiikkigenret:");
        foreach (var str in result)
        {
            Console.WriteLine(str);
        }
    }
}
