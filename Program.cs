// Jaden Olvera, 10-21-25, Lab 7 - Pig Latin / Encoder
Console.Clear();
Console.WriteLine("Welcome to a little encoding program!");
Console.WriteLine("We'll take a phrase from you and encode it with an offset, and into Pig Latin, just for fun!");
Console.Write("Give us a phrase to encode:  ");
string userPhrase = Console.ReadLine();
string[] phraseArray = userPhrase.Split(' ');