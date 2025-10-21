// Jaden Olvera, 10-21-25, Lab 7 - Pig Latin / Encoder
Console.Clear();
Console.WriteLine("Welcome to a little encoding program!");
Console.WriteLine("We'll take a phrase from you and encode it with an offset, and into Pig Latin, just for fun!");
Console.Write("Phrase to encode:  ");
string userPhrase = Console.ReadLine();
string[] phraseArray = userPhrase.Split(' ');
//Dropping all words to lower case
for (int index = 0; index < phraseArray.Length; index++)
{
    phraseArray[index] = phraseArray[index].ToLower();
}
string[] pigLatinArray = new string[phraseArray.Length];
string vowels = "aeiou";
for (int index = 0; index < phraseArray.Length; index++)
{
    // Checking if the word in the phrase starts with a vowel
    // If it does, all we have to do is add "way" to the end of it
    if (vowels.Contains(phraseArray[index][..1]) == true)
    {
        pigLatinArray[index] = $"{phraseArray[index]}way";
    }
    else
    {
        for (int subIndex = 1; subIndex < phraseArray[index].Length; subIndex++)
        {
            //Need to find where the consonant cluster ends
            //So we find the first vowel in the word and rearrange it, adding "ay" on the end
            if (vowels.Contains(phraseArray[index].Substring(subIndex, 1)))
            {
                //Concatenating a string together from the substring after the consonant cluster, the consonant cluster, then "ay"
                //The compiler suggested using Concat and AsSpan for better memory usage
                pigLatinArray[index] = string.Concat(
                    phraseArray[index].AsSpan()[subIndex..phraseArray[index].Length],
                    phraseArray[index].AsSpan(0, subIndex),
                    "ay");
                //Break after we find the first vowel and declare the encoded string 
                break;
            }
        }
    }
}
Console.Write("In Pig Latin:  ");
foreach (string word in pigLatinArray)
{
    Console.Write(word + " ");
}
Console.WriteLine();

Random rng = new Random();
int rngOffset = rng.Next(1, 26);
Console.WriteLine("Randomly generated offset is: " + rngOffset);