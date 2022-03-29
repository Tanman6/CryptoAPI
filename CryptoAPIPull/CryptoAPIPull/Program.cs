using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
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
                var binanceParse = JArray.Parse(binanceBody)


                    .ToArray()
                    .Where(item => ((dynamic)item).symbol.ToString().StartsWith("USD") || ((dynamic)item).symbol.ToString().StartsWith("USDT"))
                    .OrderBy(x => x.ToString());

                Console.WriteLine(binanceParse.ToArray()[0]);
                Console.WriteLine(binanceParse.ToArray()[2]);
                Console.WriteLine(binanceParse.ToArray()[9]);
                Console.WriteLine(binanceParse.ToArray()[13]);
                Console.WriteLine(binanceParse.ToArray()[14]);
                Console.WriteLine(binanceParse.ToArray()[15]);
                Console.WriteLine(binanceParse.ToArray()[16]);
                Console.WriteLine(binanceParse.ToArray()[17]);
                Console.WriteLine(binanceParse.ToArray()[18]);
                Console.WriteLine(binanceParse.ToArray()[19]);
                Console.WriteLine(binanceParse.ToArray()[20]);
                Console.WriteLine(binanceParse.ToArray()[21]);
                Console.WriteLine(binanceParse.ToArray()[22]);
                Console.WriteLine(binanceParse.ToArray()[23]);
                Console.WriteLine(binanceParse.ToArray()[24]);


            }


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.coinbase.com/v2/exchange-rates?currency=USDC")
            };
            //pulls coinbase prices. Amount 1 Token is currently worth in USD
            using (var response = client2.Send(request2))
            {
                response.EnsureSuccessStatusCode();
                var coinbaseBody = response.Content.ReadAsStringAsync().Result;
                var coinbaseParseData = JObject.Parse(coinbaseBody).GetValue("data").ToString();
                var coinbaseParseRates = JObject.Parse(coinbaseParseData).GetValue("rates").ToString();
                var zarString = JObject.Parse(coinbaseParseRates).GetValue("ZAR").ToString();
                var paxString  = JObject.Parse(coinbaseParseRates).GetValue("PAX").ToString();
                var brlString = JObject.Parse(coinbaseParseRates).GetValue("BRL").ToString();
                var daiString = JObject.Parse(coinbaseParseRates).GetValue("DAI").ToString();
                var gyenString = JObject.Parse(coinbaseParseRates).GetValue("GYEN").ToString();
                var idrString = JObject.Parse(coinbaseParseRates).GetValue("IDR").ToString();
                var ngnString = JObject.Parse(coinbaseParseRates).GetValue("NGN").ToString();
                var rubString = JObject.Parse(coinbaseParseRates).GetValue("RUB").ToString();
                var tryString = JObject.Parse(coinbaseParseRates).GetValue("TRY").ToString();
                var uahString = JObject.Parse(coinbaseParseRates).GetValue("UAH").ToString();



                var PAX = Convert.ToDouble(paxString);
                var BRL = Convert.ToDouble(brlString);
                var DAI = Convert.ToDouble(daiString);
                var GYEN = Convert.ToDouble(gyenString);
                var IDR = Convert.ToDouble(idrString);
                var NGN = Convert.ToDouble(ngnString);
                var RUB = Convert.ToDouble(rubString);
                var TRY = Convert.ToDouble(tryString);
                var UAH = Convert.ToDouble(uahString);
                var ZAR = Convert.ToDouble(zarString);

                Console.WriteLine(PAX);
                Console.WriteLine(BRL);
                Console.WriteLine(DAI);
                Console.WriteLine(GYEN);
                Console.WriteLine(IDR);
                Console.WriteLine(NGN);
                Console.WriteLine(RUB);
                Console.WriteLine(TRY);
                Console.WriteLine(UAH);
                Console.WriteLine(ZAR);
              

                



            }


        }
    }
}
