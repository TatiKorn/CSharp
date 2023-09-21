namespace CardGame
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static async Task Main()
        {
            // Step 1: Navigate to https://deckofcardsapi.com/
            string baseUrl = "https://deckofcardsapi.com/";

            // Step 2: Confirm the site is up
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage siteResponse = await httpClient.GetAsync(baseUrl);
                    if (!siteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Deck of Cards API site is not available.");
                        return;
                    }

                    // Step 3: Get a new deck
                    HttpResponseMessage newDeckResponse = await httpClient.GetAsync(baseUrl + "api/deck/new/");
                    if (!newDeckResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Failed to create a new deck.");
                        return;
                    }

                    string deckJson = await newDeckResponse.Content.ReadAsStringAsync();
                    JObject deckData = JObject.Parse(deckJson);
                    string deckId = deckData["deck_id"].ToString();

                    // Step 4: Shuffle the deck
                    HttpResponseMessage shuffleResponse = await httpClient.GetAsync(baseUrl + $"api/deck/{deckId}/shuffle/");
                    if (!shuffleResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Failed to shuffle the deck.");
                        return;
                    }

                    // Step 5: Deal three cards to each of two players
                    HttpResponseMessage dealResponse = await httpClient.GetAsync(baseUrl + $"api/deck/{deckId}/draw/?count=6");
                    if (!dealResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Failed to deal cards.");
                        return;
                    }

                    string cardsJson = await dealResponse.Content.ReadAsStringAsync();
                    JObject cardsData = JObject.Parse(cardsJson);
                    JArray cards = (JArray)cardsData["cards"];

                    // Step 6: Check whether either has blackjack
                    bool player1HasBlackjack = HasBlackjack(cards.Take(3));
                    bool player2HasBlackjack = HasBlackjack(cards.Skip(3).Take(3));

                    // Step 7: If either has, write out which one does
                    if (player1HasBlackjack)
                    {
                        Console.WriteLine("Player 1 has blackjack!");
                    }
                    if (player2HasBlackjack)
                    {
                        Console.WriteLine("Player 2 has blackjack!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Blackjack checking logic
        static bool HasBlackjack(IEnumerable<JToken> playerCards)
        {
            return false; // Placeholder logic
        }
    }
}