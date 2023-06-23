using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using SimpleJSON;
//using UnityEngine.Android;


public class WeatherApp : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI statusText;

    public TextMeshProUGUI location;
    public TextMeshProUGUI country;

   // public TextMeshProUGUI mainWeather;
    public TextMeshProUGUI description;
    public TextMeshProUGUI temp;
   // public TextMeshProUGUI feels_like;
    public TextMeshProUGUI temp_min;
    public TextMeshProUGUI temp_max;
    public TextMeshProUGUI pressure;
    public TextMeshProUGUI humidity;
    public TextMeshProUGUI windspeed;
    private LocationInfo JohannesburgLocation;
    private LocationInfo PretoriaLocation;
    private LocationInfo PietermaritzburgLocation;
    private LocationInfo CapeTownLocation;
    private LocationInfo KimberleyLocation;
    private LocationInfo BloemfonteinLocation;
    private LocationInfo MbombelaLocation;
    private LocationInfo EastLondonLocation;
    private LocationInfo PolokwaneLocation;
    private LocationInfo MahikengLocation;

    
    public void UpdateWeatherDataCapeTown() 
    {
        StartCoroutine(FetchWeatherDataFromApi("3369157"));
    }
    public void UpdateWeatherDataJohannesburg() 
    {
        StartCoroutine(FetchWeatherDataFromApi("6556950"));
    }
    public void UpdateWeatherDataKimberley() 
    {
        StartCoroutine(FetchWeatherDataFromApi("990930"));
    }
    public void UpdateWeatherDataPietermaritzburg() 
    {
        StartCoroutine(FetchWeatherDataFromApi("965301"));
    }
    public void UpdateWeatherDataBloemfontein() 
    {
        StartCoroutine(FetchWeatherDataFromApi("1018725"));
    }
    public void UpdateWeatherDataBhisho() 
    {
        StartCoroutine(FetchWeatherDataFromApi("1019330"));
    }
    public void UpdateWeatherDataMbombela() 
    {
        StartCoroutine(FetchWeatherDataFromApi("971534"));
    }
    public void UpdateWeatherDataPolokwane() 
    {
        StartCoroutine(FetchWeatherDataFromApi("965289"));
    }
    public void UpdateWeatherDataMahikeng() 
    {
        StartCoroutine(FetchWeatherDataFromApi("980595"));
    }

    private IEnumerator FetchWeatherDataFromApi(string id)
    {
        string url = "https://api.openweathermap.org/data/2.5/weather?id=" + id + "&appid=4f0e5364e03ad092b91ae4602fdffe59"; 
        UnityWebRequest fetchWeatherRequest = UnityWebRequest.Get(url);
        yield return fetchWeatherRequest.SendWebRequest();
            if (fetchWeatherRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            //Check and print error 
            statusText.text = fetchWeatherRequest.error;
        }
        else
        {
            Debug.Log(fetchWeatherRequest.downloadHandler.text);
            var response = JSON.Parse(fetchWeatherRequest.downloadHandler.text);
            location.text = response["name"];
            country.text = response["country"];

           // mainWeather.text = response["weather"][0]["main"];
            description.text = response["weather"][0]["description"];
            temp.text = "Temp: " + ((int)response["main"]["temp"] - 273.1) + " °C";
            //feels_like.text = "Feels like " + response["main"]["feels_like"] + " C";
            temp_min.text = "Min is " + ((int)response["main"]["temp_min"] - 273.1) + " °C";
            temp_max.text = "Max is " + ((int)response["main"]["temp_max"] -273.1) + " °C";
            pressure.text = "Pressure is " + response["main"]["pressure"] + " Pa";
            humidity.text = response["main"]["humidity"] + " % Humidity";
            windspeed.text = "Windspeed is " + response["wind"]["speed"] + " Km/h";

        }
    }
}



