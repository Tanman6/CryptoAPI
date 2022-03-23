using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace CryptoAPI
{
    class Program
    {
        static void Main(string[] args)

        {

            // gets all prices formatted with initial coin followed by the coin the price is exchanged to
            // example: symbol "ETHBTC" is how much bitcoin you can trade for one Ethereum token

            // need to grab all data symbols ending in UDS and USDT

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.binance.com/api/v1/ticker/price")
            };

            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                var binanceBody = response.Content.ReadAsStringAsync().Result;
                var binanceParse = JArray.Parse(binanceBody);

                Console.WriteLine(binanceParse);


            }


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.coinbase.com/v2/exchange-rates?currency=USDC")
            };
            //pulls coinbase prices. Amount 1 USD is currently worth per coin
            using (var response = client2.Send(request2))
            {
                response.EnsureSuccessStatusCode();
                var coinbaseBody = response.Content.ReadAsStringAsync().Result;
                var coinbaseParseData = JObject.Parse(coinbaseBody).GetValue("data").ToString();
                var coinbaseParseRates = JObject.Parse(coinbaseParseData).GetValue("rates").ToString();
                Console.WriteLine(coinbaseParseRates);
            }


        }
    }
}
