using System.Net.Http.Json;
using TestApp.Models;

namespace TestApp.Clients;
public class NasaClient{

    private readonly HttpClient _client;

    //constructor
    public NasaClient(HttpClient Client){
        _client = Client;
    }

    public async Task<NasaResponse> GetNasa(string date){

        string url = "https://api.nasa.gov/planetary/apod?api_key=Jb4h5MSk4dpkM9zyt6jkI41PeMagJWLJjAAM0l0E";
        if(date != null){
            url += "&date=" + date;
        }

        return await _client.GetFromJsonAsync<NasaResponse>(url);
    }

}