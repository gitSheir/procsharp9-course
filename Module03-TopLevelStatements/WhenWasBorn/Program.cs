using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

// TODO: As a top-level statements exercise, use only this single file to define everything!

if (args.Length != 1)
{
    // TODO: define local PrintHelp function to print help and exit
    void PrintHelp()
    {
        System.Console.WriteLine("Help!");
    }
    PrintHelp();
}

// TODO: utilize https://swapi.dev/ to search for a person with a given name
//       Hint: Use https://swapi.dev/documentation and look for "Searching"
using HttpClient client = new HttpClient();
var requestUri = "https://swapi.dev/api/people/?search=r2";

try
{
    var response = await client.GetFromJsonAsync<PersonsDTO>(requestUri);
    Debug.WriteLine(response);

    if (response?.Count != 1)
    {
        Console.WriteLine("There is no single answer to your question!");
    }
    else
    {
        // TODO: 
        //Console.WriteLine($"{person.Name} was born {person.Birth_Year}.");
        foreach (PersonDTO person in response.Persons)
        {
            Console.WriteLine($"{person.Name} was born {person.BirthYear}.");
        }
    }
}
catch (Exception ex)
{
    Debug.WriteLine(ex);
    throw;
}

// TODO: define PersonDTO and PersonsDTO records to deserialize (only necessary)
//       fields from https://swapi.dev/api/people/?search=... results.

public record PersonDTO([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("birth_year")] string BirthYear)
{
    [JsonPropertyName("eye_color")]
    public string EyeColour { get; init; }

    [JsonPropertyName("gender")]
    public string Gender { get; init; }

    [JsonPropertyName("hair_color")]
    public string HairColor { get; init; }

    [JsonPropertyName("height")]
    public string Height { get; init; }

    [JsonPropertyName("mass")]
    public string Mass { get; init; }   //in KG

    [JsonPropertyName("skin_color")]
    public string SkinColor{ get; init; }

    [JsonPropertyName("homeworld")]
    public string Homeworld { get; init; }


    [JsonPropertyName("url")]
    public string URL { get; init; }

    [JsonPropertyName("created")]
    public string CreatedDate { get; init; }

    [JsonPropertyName("edited")]
    public string EditedDate { get; init; }


    [JsonPropertyName("films")]
    public List<string> Films { get; init; }

    [JsonPropertyName("species")]
    public List<string> Species { get; init; }

    [JsonPropertyName("starships")]
    public List<string> Starships { get; init; }

    [JsonPropertyName("vehicles")]
    public List<string> Vehicles { get; init; }
};

public record PersonsDTO()
{
    [JsonPropertyName("count")]
    public int Count { get; init; }


    [JsonPropertyName("next")]
    public string Next { get; init; }

    [JsonPropertyName("previous")]
    public string Previous { get; init; }


    [JsonPropertyName("results")]
    public List<PersonDTO> Persons { get; init; }
}
