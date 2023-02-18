using System.Net.Http.Json;
using TestApp.Models;

namespace TestApp.Clients;
public class NasaClient{

    private readonly HttpClient _client;

    //constructor
    public NasaClient(HttpClient Client){
        _client = Client;
    }

    public async Task<NasaResponse> GetNasa(){
        return await _client.GetFromJsonAsync<NasaResponse>("https://api.nasa.gov/planetary/apod?api_key=Jb4h5MSk4dpkM9zyt6jkI41PeMagJWLJjAAM0l0E");
    }

}