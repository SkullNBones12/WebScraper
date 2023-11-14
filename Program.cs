﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Globalization;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Xml.Linq;

namespace WebScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // send get request weather
            String url = "https://weather.com/weather/today/l/Brunswick+OH?canonicalCityId=62374489fbc9483eee2bc88e2f1dce8a96bcfc656c3418d24dd57fd921ccfa20";
            var httpClient  = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // get location data
            var locationElement1 = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location1 = locationElement1.InnerText;
            var locationElement2 = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--timestamp--1ybTk']");
            var location2 = locationElement2.InnerText;
            Console.WriteLine(location1 + " " + location2);

            // get temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            // get current conditions
            var conditionsElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var conditions = conditionsElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            // get high/low
            var highElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[1]/div[2]/span[1]");
            var high = highElement.InnerText.Trim();
            var lowElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[1]/div[2]/span[2]");
            var low = lowElement.InnerText.Trim();
            Console.WriteLine("High / Low: " + high + " / " + low);

            // get humidity
            var humidityElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[3]/div[2]/span");
            var humidity = humidityElement.InnerText.Trim();
            Console.WriteLine("Humidity: " + humidity);

            // get pressure
            var pressureElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[5]/div[2]/span");
            var pressure  = pressureElement.InnerText.Trim();
            Console.WriteLine("Pressure: " + pressure);

            // get visibility
            var visibilityElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[7]/div[2]/span");
            var visibility = visibilityElement.InnerText.Trim();
            Console.WriteLine("Visibility: " + visibility);

            // get wind
            var windElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[2]/div[2]/span/span[2]");
            var wind = windElement.InnerText.Trim();
            Console.WriteLine("Wind: " + wind + " mph");

            // get dew point
            var dewPointElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[4]/div[2]/span");
            var dewPoint= dewPointElement.InnerText.Trim();
            Console.WriteLine("Dew Point: " + dewPoint);

            // get uv index
            var uVIndexElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[6]/div[2]/span");
            var uVIndex= uVIndexElement.InnerText.Trim();
            Console.WriteLine("UV Index: " + uVIndex);

            // get moon phase
            var moonPhaseElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[2]/div[8]/div[2]");
            var moonPhase= moonPhaseElement.InnerText.Trim();
            Console.WriteLine("Moon Phase: " + moonPhase);

            //get sunup/sundown
            var sunUpElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[1]/div[2]/div/div/div/div[1]/p");
            var sunUp = sunUpElement.InnerText.Trim();
            var sunDownElement = htmlDocument.DocumentNode.SelectSingleNode("//html/body/div[1]/main/div[2]/main/div[6]/section/div/div[1]/div[2]/div/div/div/div[2]/p");
            var sunDown = sunDownElement.InnerText.Trim();
            Console.WriteLine("Sun Up / Down: " + sunUp + " / " + sunDown );






        }

    }
}
