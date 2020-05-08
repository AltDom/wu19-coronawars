using System;
using System.Collections.Generic;
using System.Linq;

namespace Corona_Wars
{
    class Program
    {
        static int TableWidth = 120;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CORONA WARS!"); 
            Console.WriteLine("The Coronavirus has taken hold of Gothenburg and the world as you know it!");
            Console.WriteLine("You've spent your last krona and you're all out of luck.");
            Console.WriteLine("Thankfully a sinister LOAN SHARK has lent you 200kr with 10% daily interest to \"help\" you get back on your feet again.");
            Console.WriteLine("It's your job to navigate Gothenburg's infected supermarket aisles in search of the best deals on essential supplies.");
            Console.WriteLine("You can then profit by selling them to desperate hopefuls from the boot of your Volvo V70 in the carparks outside.");
            Console.WriteLine("In order to compete with the supermarket you visit each day, you price-beat them by selling your stock with a 10% discount.");
            Console.WriteLine("Unfortunately OFFICER HARDASS is quickly catching on to your scheming black marketing ways and you only have 10 supermarket visits left");
            Console.WriteLine("before the patrol vans and surveillance cameras are too many.");
            Console.WriteLine("Dang! What a drag man!");
            PrintLine();
            Console.WriteLine("Note: You can return to your main options and escape a BUY, SELL or BAIL command by typing ABORT");
            PrintLine();
            double loan = 200;
            double cash = 200;
            double carspace = 150;
            bool trailerPurchaseComplete = false;
            bool newVisit = true;
            bool itemExistsInBootAndMarket = false;
            bool tobaccoSurgeTomorrow = false;
            bool tobaccoSurgeToday = false;
            bool maccheroniSurgeTomorrow = false;
            bool maccheroniSurgeToday = false;
            bool officerHardassAlreadyEncountered = false;
            bool truckAlreadyToppled = false;
            int unitsAvailable = 0;
            int supplyPrice = 0;
            int visit = 0;
            int purchaseAttemptQuantity = 0;
            int sellAttemptQuantity = 0;
            int index = 0;
            string purchaseAttemptName = "";
            string sellAttemptName = "";
            string lastSupermarket = "";
            string selectedSupermarket = "";
            string purchaseAttempt = "";
            string sellAttempt = "";
            string selectedOption = "";
            string name = "";
            var rand = new Random();
            var bakedBeans = new EssentialSupply("Baked Beans", 5, 3, 25);
            var toiletPaper = new EssentialSupply("Toilet Paper", 20, 38, 110);
            var coffee = new EssentialSupply("Coffee", 8, 35, 140);
            var frozenVeggies = new EssentialSupply("Frozen Veggies", 10, 18, 70);
            var longlifeMilk = new EssentialSupply("Longlife Milk", 10, 16, 85);
            var babyWipes = new EssentialSupply("Baby Wipes", 15, 60, 200);
            var paracetamol = new EssentialSupply("Paracetamol", 4,50, 100);
            var plasticGloves = new EssentialSupply("Plastic Gloves", 30, 35, 300);
            var tobacco = new EssentialSupply("Tobacco 10-Pack", 12, 195, 500);
            var rigatoni = new EssentialSupply("Rigatoni", 6, 25, 80);
            var maccheroni = new EssentialSupply("Maccheroni", 6, 15, 60);
            var tinnedTuna = new EssentialSupply("Tinned Tuna", 5, 5, 30);
            var handSanitiser = new EssentialSupply("Hand Sanitiser", 8, 45, 150);
            var ventilationMasks = new EssentialSupply("Ventilation Masks", 10, 50, 250);
            var ventolinInhalers = new EssentialSupply("Ventolin Inhalers", 15, 80, 250);
            var essentialSupplies = new List<EssentialSupply> {babyWipes, bakedBeans, coffee, frozenVeggies, handSanitiser, longlifeMilk, maccheroni, paracetamol, plasticGloves, rigatoni, tinnedTuna, tobacco, toiletPaper, ventilationMasks, ventolinInhalers};
            var essentialSuppliesSubset = new List<EssentialSupplyMarketItem>{};
            var carBoot = new List<BootItem>{};
            var allSupermarkets = new List<string> { "ICA", "NETTO", "COOP", "Willys", "Hemköp", "Konsum", "TEMPO", "ICA Kvantum", "Pressbyrån", "LIVS OCH SÅNT", "ICA MAXI", "ICA NÄRA", "City Gross", "Lidl"};
            var supermarkets = new List<string> {};
            var supermarketsSubset = new List<string>{};
            var supermarketsClone = new List<string>(allSupermarkets);
            
            // Create random selection of 10 supermarkets for the game.
            for (int i = 0; i < 10; i++)
            {
                index = rand.Next(supermarketsClone.Count);
                name = supermarketsClone[index];
                supermarkets.Add(name);
                supermarketsClone.RemoveAt(index);
            }

            while (visit < 11)
            {
                // Define supermarket options for the next visit.
                if (supermarkets.Count > 2)
                {
                    supermarketsClone = new List<string>(supermarkets);
                    for (int i = 0; i < 3; i++)
                    {
                        index = rand.Next(supermarketsClone.Count);
                        name = supermarketsClone[index];
                        supermarketsSubset.Add(name);
                        supermarketsClone.RemoveAt(index);
                    }
                } 
                else if (supermarkets.Count == 2)
                {
                    supermarketsClone = new List<string>(supermarkets);
                    for (int i = 0; i < 2; i++)
                    {
                        index = rand.Next(supermarketsClone.Count);
                        name = supermarketsClone[index];
                        supermarketsSubset.Add(name);
                        supermarketsClone.RemoveAt(index);
                    }
                }
                else if (visit == 10)
                {
                    supermarketsSubset.Add(lastSupermarket);
                }
                else 
                {
                    supermarketsSubset.Add(supermarkets[0]);
                }
                
                // Print visit summary.
                if (visit == 0)
                {
                    Console.WriteLine($"VISIT #: {visit} / LOCATION: LOAN SHARK's Hideout");
                }
                else
                {
                    Console.WriteLine($"VISIT #: {visit} / SUPERMARKET: {selectedSupermarket}");
                }

                if (Convert.ToInt32(loan) == 0)
                {
                    Console.WriteLine($"CASH: {cash}kr / BOOTSPACE: {carspace}units / LOAN SHARK DEBT: PAID!");
                }
                else
                {
                    Console.WriteLine($"CASH: {cash}kr / BOOTSPACE: {carspace}units / LOAN SHARK DEBT: {Math.Round(loan)}kr");
                }
                // Print car boot inventory if it exists.
                if (carBoot.Count != 0)
                {
                    PrintLine();
                    PrintRow("Items in the boot of your V70", "Bootspace occupied (Bootspace units)", "Quantity (Units)");
                    PrintLine();
                    foreach (var asset in carBoot)
                    {
                        PrintRow(asset.SupplyName, (asset.Quantity * asset.Size).ToString(), (asset.Quantity).ToString());
                    }
                    PrintLine();
                }
                PrintLine();
                // Print different table header depending on if at LOAN SHARK or supermarket.
                if (visit != 0)
                {
                    PrintRow($"{selectedSupermarket}'s market items", "Size (Carspace units)", "Quantity available (Units)", "Going rate (kr)");
                }
                else
                {
                    PrintRow("LOAN SHARK's market items", "Size (Carspace units)", "Quantity available (Units)", "Going rate (kr)");
                }
                PrintLine();
                // Print same market table if still at the same supermarket.
                if (!newVisit)
                {
                    foreach (var supplyItem in essentialSuppliesSubset)
                    {
                        PrintRow(supplyItem.SupplyName, supplyItem.Size.ToString(), supplyItem.QuantityAvailable.ToString(), supplyItem.GoingRate.ToString());
                    }
                }
                else // Print new random market table if visiting a new supermarket.
                {
                    foreach (var supplyItem in essentialSupplies)
                    {
                        Random supplyItemForSale = new Random();
                        if (supplyItemForSale.Next(100) < 50)
                        {
                            Random units = new Random();
                            Random price = new Random();
                            unitsAvailable = units.Next(1, Convert.ToInt32(Math.Round(carspace * 6 / supplyItem.MinPrice)));
                            if (tobaccoSurgeToday && supplyItem.SupplyName == "Tobacco 10-Pack")
                            {
                                supplyPrice = price.Next(Convert.ToInt32(Math.Round(supplyItem.MaxPrice*0.9*2)), Convert.ToInt32(supplyItem.MaxPrice*2));
                            }
                            else if (maccheroniSurgeToday && supplyItem.SupplyName == "Maccheroni")
                            {
                                supplyPrice = price.Next(Convert.ToInt32(Math.Round(supplyItem.MaxPrice*0.9*2)), Convert.ToInt32(supplyItem.MaxPrice*2));
                            }
                            else
                            {
                                supplyPrice = price.Next(Convert.ToInt32(supplyItem.MinPrice), Convert.ToInt32(supplyItem.MaxPrice));
                            }
                            essentialSuppliesSubset.Add(new EssentialSupplyMarketItem(supplyItem.SupplyName, supplyItem.Size, unitsAvailable, supplyPrice));
                            PrintRow(supplyItem.SupplyName, supplyItem.Size.ToString(), unitsAvailable.ToString(), supplyPrice.ToString());
                        }
                    }
                    newVisit = false;
                }
                PrintLine();
                // Print command line options.
                if (cash >= loan + 200 && Convert.ToInt32(loan) != 0)
                {
                    Console.WriteLine($"What would you like to do? BUY, SELL, BAIL or PAY LOAN SHARK DEBT");
                }
                else if (visit != 0)
                {
                    Console.WriteLine($"What would you like to do? BUY, SELL or BAIL");
                }
                else
                {
                    Console.WriteLine($"What would you like to do? BUY or BAIL");
                }
                selectedOption = Console.ReadLine();
                
                // If player would like to buy market items.
                if (selectedOption == "BUY")
                {
                    PrintLine();
                    bool purchaseAttemptSuccess = false;
                    bool itemForSale = false;
                    while (!purchaseAttemptSuccess)
                    {
                        Random dummyPurchaseQuantity = new Random();
                        Console.WriteLine($"What would you like to buy and how many units? e.g. {essentialSuppliesSubset[0].SupplyName} {dummyPurchaseQuantity.Next(essentialSuppliesSubset[0].QuantityAvailable)}");
                        purchaseAttempt = Console.ReadLine();
                        PrintLine();
                        if (purchaseAttempt == "ABORT")
                        {
                            break;
                        }
                        // Deconstruct a player's desired purchase.
                        string[] purchaseAttemptArray = purchaseAttempt.Split(" ");
                        if (purchaseAttemptArray.Length == 2)
                        {
                            if (!string.IsNullOrEmpty(purchaseAttemptArray[0]) &&
                                int.TryParse(purchaseAttemptArray[1], out int result))
                            {
                                purchaseAttemptName = purchaseAttemptArray[0];
                                purchaseAttemptQuantity = result;
                            }
                        } 
                        else if (purchaseAttemptArray.Length == 3)
                        {
                            if (!string.IsNullOrEmpty(purchaseAttemptArray[0]) &&
                                !string.IsNullOrEmpty(purchaseAttemptArray[1]) &&
                                int.TryParse(purchaseAttemptArray[2], out int result))
                            {
                                purchaseAttemptName = purchaseAttemptArray[0] + ' ' + purchaseAttemptArray[1];
                                purchaseAttemptQuantity = result;
                            }
                        }

                        foreach (var essentialItemForSale in essentialSuppliesSubset)
                        {
                            // Check if item is for sale.
                            if (purchaseAttemptName == essentialItemForSale.SupplyName)
                            {
                                itemForSale = true;
                                // Check item quantity is for sale.
                                if (purchaseAttemptQuantity > essentialItemForSale.QuantityAvailable)
                                {
                                    Console.WriteLine("Do you see that many items on the shelf? Go on ..try again!");
                                }
                                // Check item will fit in the player's car boot.
                                else if (carspace < purchaseAttemptQuantity * essentialItemForSale.Size)
                                {
                                    Console.WriteLine(
                                        "You're tripping if you think that's going to fit in your boot! ");
                                }
                                // Check player can afford the desired purchase.
                                else if (cash < purchaseAttemptQuantity * essentialItemForSale.GoingRate)
                                {
                                    Console.WriteLine(
                                        "Check your pockets and your math man! You can't afford that ..so put it back on the shelf!");
                                }
                                else
                                {
                                    // Purchase item and put it in the boot of your V70. Remove it from the supermarket. Update cash and carspace.
                                    bool itemAlreadyInBoot = false;
                                    supermarketsSubset.Clear();
                                    purchaseAttemptSuccess = true;
                                    cash = cash - (purchaseAttemptQuantity * essentialItemForSale.GoingRate);
                                    essentialItemForSale.QuantityAvailable =
                                        essentialItemForSale.QuantityAvailable - purchaseAttemptQuantity;
                                    carspace = carspace - essentialItemForSale.Size * purchaseAttemptQuantity;
                                    foreach (var carBootItem in carBoot)
                                    {
                                        if (essentialItemForSale.SupplyName == carBootItem.SupplyName)
                                        {
                                            carBootItem.Quantity = carBootItem.Quantity + purchaseAttemptQuantity;
                                            itemAlreadyInBoot = true;
                                        }
                                    }

                                    if (!itemAlreadyInBoot)
                                    {
                                        carBoot.Add(new BootItem(essentialItemForSale.SupplyName,
                                            essentialItemForSale.Size, purchaseAttemptQuantity));
                                    }
                                }
                            }
                        }
                        if (!itemForSale)
                        {
                            Console.WriteLine("That doesn't seem to be for sale here or you're doing it wrong! Trying buying something else?");
                        }
                    }
                }
                
                // If player would like to sell market items.
                if (selectedOption == "SELL" && carBoot.Count > 0)
                {
                    PrintLine();
                    bool sellAttemptSuccess = false;
                    while (!sellAttemptSuccess)
                    {
                        Random dummySellQuantity = new Random();
                        Console.WriteLine("Remember to factor in the 10% supermarket price-beat discount that you give to all of your customers!");
                        Console.WriteLine($"What would you like to sell and how many units? e.g. {carBoot[0].SupplyName} {dummySellQuantity.Next(1, carBoot[0].Quantity)} if it's a current market item.");
                        sellAttempt = Console.ReadLine();
                        PrintLine();
                        if (sellAttempt == "ABORT")
                        {
                            break;
                        }
                        // Deconstruct a player's desired sale.
                        string[] sellAttemptArray = sellAttempt.Split(" ");
                        if (sellAttemptArray.Length == 2)
                        {
                            if (!string.IsNullOrEmpty(sellAttemptArray[0]) &&
                                int.TryParse(sellAttemptArray[1], out int result))
                            {
                                sellAttemptName = sellAttemptArray[0];
                                sellAttemptQuantity = result;
                            }
                        } else if (sellAttemptArray.Length == 3)
                        {
                            if (!string.IsNullOrEmpty(sellAttemptArray[0]) && !string.IsNullOrEmpty(sellAttemptArray[1]) && int.TryParse(sellAttemptArray[2], out int result))
                            {
                                sellAttemptName = sellAttemptArray[0] + ' ' + sellAttemptArray[1];
                                sellAttemptQuantity = result;
                            }
                        }
                        foreach (var essentialSupplyMarketItem in essentialSuppliesSubset)
                        {
                            foreach (var essentialItemBought in carBoot.ToList())
                            {
                                // If item is in your boot and on sale at this supermarket.
                                if (sellAttemptName == essentialItemBought.SupplyName && sellAttemptName == essentialSupplyMarketItem.SupplyName)
                                {
                                    itemExistsInBootAndMarket = true;
                                    // Check that the quantity is in the boot of the car. 
                                    if (sellAttemptQuantity > essentialItemBought.Quantity)
                                    {
                                        Console.WriteLine("You own less of those than you thought! Try another unit value!");
                                    }
                                    else
                                    {
                                        // Sell item and remove it from the boot of your V70. Update cash and carspace.
                                        sellAttemptSuccess = true;
                                        supermarketsSubset.Clear();
                                        cash = cash + Math.Round(sellAttemptQuantity * essentialSupplyMarketItem.GoingRate*0.90); // 90% after discount.
                                        carspace = carspace + essentialItemBought.Size * sellAttemptQuantity;
                                        essentialItemBought.Quantity = essentialItemBought.Quantity - sellAttemptQuantity;
                                        if (essentialItemBought.Quantity == 0)
                                        {
                                            carBoot.Remove(essentialItemBought);
                                        }
                                    }
                                }
                            }
                        }
                        if (!itemExistsInBootAndMarket)
                        {
                            Console.WriteLine("You don't own that item or its not for sale here ..or your query is weird! Try again!");
                            itemExistsInBootAndMarket = false;
                        }
                    }
                }
                
                // If player would like to go to the next day/visit.
                if (selectedOption == "BAIL")
                {
                    PrintLine();
                    // Exit the main game while loop if it's the last visit. 
                    if (visit == 10)
                    {
                        break;
                    }
                    bool supermarketChosen = false;
                    while (!supermarketChosen)
                    {
                        // Print supermarket options and determine a selected supermarket.
                        if (supermarketsSubset.Count > 2)
                        {
                            Console.WriteLine($"Where would you like to visit?");
                            Console.WriteLine($"{supermarketsSubset[0]}, {supermarketsSubset[1]} or {supermarketsSubset[2]} appear to be the best options right now.");
                            selectedSupermarket = Console.ReadLine();
                        } 
                        else if (supermarketsSubset.Count == 2)
                        {
                            Console.WriteLine($"Where would you like to visit?");
                            Console.WriteLine($"{supermarketsSubset[0]} or {supermarketsSubset[1]} are your only two remaining options.");
                            selectedSupermarket = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($"It's your last day man!");
                            selectedSupermarket = supermarketsSubset[0];
                        }
                        if (selectedSupermarket == "ABORT")
                        {
                            break;
                        }
                        // Check it's a valid supermarket.
                        foreach (var supermarket in supermarkets)
                        {
                            if (selectedSupermarket == supermarket)
                            {
                                supermarketChosen = true;
                            }
                        }
                    }
                    
                    // If supermarket successfully chosen, update loan & visit and remove selected supermarket from remaining supermarkets.
                    if (supermarketChosen)
                    {
                        newVisit = true;
                        PrintLine();
                        loan = loan * 1.1;
                        visit++;
                        supermarketsClone.Clear();
                        supermarketsSubset.Clear(); 
                        essentialSuppliesSubset.Clear();
                        
                        for (int i = 0; i < supermarkets.Count; i++)
                        {
                            if (supermarkets[i] == selectedSupermarket)
                            {
                                lastSupermarket = selectedSupermarket;
                                supermarkets.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    
                    // 20% chance of a one-time OFFICER HARDASS encounter with each new visit.
                    if (!officerHardassAlreadyEncountered)
                    {
                        Random officerHardassBust = new Random();
                        if (officerHardassBust.Next(100) < 20) 
                        {
                            Console.WriteLine("OFFICER HARDASS is on pursuit!");
                            Console.WriteLine("You lost him by ducking behind a shelf of Kalles Kaviar");
                            if (cash < 50)
                            {
                                Console.WriteLine("but unfortunately you dropped all of your cash!");
                                cash = 0;
                            }
                            else
                            {
                                Console.WriteLine("but unfortunately 50kr fell out of your ICA Hemma bomber jacket.");
                                cash = cash - 50;
                            }
                            Console.WriteLine("Drats man!");
                            officerHardassAlreadyEncountered = true;
                        }
                    }
                    
                    // Restore price surge variables.
                    Random oldLadyEncounter = new Random();
                    if (tobaccoSurgeToday)
                    {
                        tobaccoSurgeToday = false;
                    }
                    if (tobaccoSurgeTomorrow)
                    {
                        tobaccoSurgeToday = true;
                        tobaccoSurgeTomorrow = false;
                    }
                    if (maccheroniSurgeToday)
                    {
                        maccheroniSurgeToday = false;
                    }
                    if (maccheroniSurgeTomorrow)
                    {
                        maccheroniSurgeToday = true;
                        maccheroniSurgeTomorrow = false;
                    }
                    
                    // 20% chance of OLD LADY encounter, surge or other event occuring with each new visit.
                    if (oldLadyEncounter.Next(100) < 20) 
                    {
                        Random rnd = new Random();
                        int whichQuote = rnd.Next(1, 9);
                        if (whichQuote == 1)
                        {
                            Console.WriteLine("An OLD LADY on tram #1 screams \"Max von Sydow's chess moves were brilliant in The Seventh Seal!\"");
                        }
                        else if (whichQuote == 2)
                        {
                            Console.WriteLine("An OLD LADY sitting on a nearby bench yells \"I knew Axel well before they started calling him Evert Taube!\"");
                        }
                        else if (whichQuote == 3)
                        {
                            Console.WriteLine("An OLD LADY shrieks at the top of her lungs \"I hear Tobacco demand will be high tomorrow!\"");
                            tobaccoSurgeTomorrow = true;
                        }
                        else if (whichQuote == 5)
                        {
                            Console.WriteLine("An OLD LADY screeches \"A large shipment of Rigatoni sunk off the coast of Öckerö this morning!\"");
                            maccheroniSurgeTomorrow = true;
                        }
                        else if (whichQuote == 6)
                        {
                            if (!trailerPurchaseComplete && cash >= 40)
                            {
                                while (!trailerPurchaseComplete)
                                {
                                    Console.WriteLine("An SHADY LOOKING CHARACTER inquires \"Would you like to buy a trailer for 40kr to increase your bootspace by 200units?\" YES or NO");
                                    string trailerPurchase = Console.ReadLine();
                                    if (trailerPurchase == "YES")
                                    {
                                        if (cash >= 40)
                                        {
                                            cash = cash - 40;
                                            carspace = carspace + 200;
                                            trailerPurchaseComplete = true;
                                        }
                                    } else if (trailerPurchase == "NO")
                                    {
                                        trailerPurchaseComplete = true; // This ensures the player is only asked to buy the trailer once per game.
                                        break;
                                    }
                                }
                            }
                            
                        }
                        else if (whichQuote == 7)
                        {
                            Console.WriteLine("You see OFFICER HARDASS busting a pleb for hoarding toilet paper. Phew, that was a close one!");
                        }
                        else
                        {
                            if (carspace >= 20 && !truckAlreadyToppled)
                            {
                                bool frozenVeggiesAlreadyInBoot = false;
                                Console.WriteLine("A truck of refrigerated goods topples over after hitting the curb! You make away with 2 packs of frozen veggies!");
                                carspace = carspace - 20;
                                foreach (var carBootItem in carBoot)
                                {
                                    if (carBootItem.SupplyName == "Frozen Veggies")
                                    {
                                        carBootItem.Quantity = carBootItem.Quantity + 2;
                                        frozenVeggiesAlreadyInBoot = true;
                                    }
                                }
                                if (!frozenVeggiesAlreadyInBoot)
                                {
                                    carBoot.Add(new BootItem("Frozen Veggies", 10, 2));
                                }
                                truckAlreadyToppled = true;
                            }
                        }
                        
                    }
                }
                
                // If player chooses to pay off the LOAN SHARK debt.
                if (selectedOption == "PAY LOAN SHARK DEBT" && cash >= loan + 200)
                {
                    cash = cash - Math.Round(loan);
                    loan = 0;
                    supermarketsSubset.Clear();
                    PrintLine();
                    Console.WriteLine("DEBT PAID! Loan Shark has set you free!");
                }
                
            }
            if (loan > 0)
            {
                Console.WriteLine("GAME OVER");
                Console.WriteLine("Oh no! The game is up and LOAN SHARK came for his cash!");
                Console.WriteLine("He was surprisingly really nice to you about it, but unfortunately he gave you Coronavirus when he shook your hand.");
                Console.WriteLine("Always pay your debts man!");
                Console.WriteLine($"Cash: +{cash}kr");
                Console.WriteLine($"Loan: -{Math.Round(loan)}kr X2 = -{Math.Round(loan * 2)}kr (Corona double debt penalty)");
                Console.WriteLine($"FINAL SCORE: {Math.Round(cash - (loan * 2))} !!"); // Double debt Corona penalty.
            }
            if (Convert.ToInt32(loan) == 0 && carBoot.Count > 0)
            {
                Console.WriteLine("GAME OVER");
                Console.WriteLine("You've got the right idea paying your debts but you never want to hold onto your stash.");
                Console.WriteLine("Always empty your boot man!");
                Console.WriteLine($"Cash: +{cash}kr");
                Console.WriteLine($"Boot: -{carBoot.Count}kr X50 = -{carBoot.Count * 50}kr (50kr per unsold boot item penalty)");
                Console.WriteLine($"FINAL SCORE: {cash - (carBoot.Count * 50)} !!"); // 50kr per boot item penalty.
            }
            if (Convert.ToInt32(loan) == 0 && carBoot.Count == 0)
            {
                Console.WriteLine("GAME COMPLETE");
                Console.WriteLine("Nice one! You payed LOAN SHARK and OFFICER HARDASS has no idea where you're hiding!");
                Console.WriteLine($"FINAL SCORE: {Math.Round(cash)} !!"); // Game completed without penalty.
            }
        }
        
        static void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        
    }
}