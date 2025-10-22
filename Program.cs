// Jaden Olvera, 10-21-25, Lab 7 - Pig Latin / Encoder
Console.Clear();
Console.WriteLine("Welcome to a Pig Latin encoding program!");
Console.WriteLine("You can input a phrase and we'll turn it into Pig Latin, then encrypt it with an offset!");
Console.Write("Phrase to encode: ");

//Take the user's phrase and split it into an array using ' ' as the delimiter
string userPhrase = Console.ReadLine();
string[] phraseArray = userPhrase.Split(' ');

//Dropping all words to lower case
for (int index = 0; index < phraseArray.Length; index++)
{
    phraseArray[index] = phraseArray[index].ToLower();
}

//Checking for punctuation on the last word
string sentenceEnders = "?!.";
string punctuationToAdd = "";
for (int index = phraseArray[^1].Length - 1; index >= 0; index--)
{
    if (sentenceEnders.Contains(phraseArray[^1][index]))
    {
        punctuationToAdd += phraseArray[^1][index];
    }
}

//Check if we need to trim punctuation
if (punctuationToAdd != "")
{
    foreach (char character in punctuationToAdd)
    {
        phraseArray[^1] = phraseArray[^1].TrimEnd(character);
    }
}

//Make a new array for Pig Latin so we aren't directly touching phraseArray
string[] pigLatinArray = new string[phraseArray.Length];
string vowels = "aeiouy";
for (int index = 0; index < phraseArray.Length; index++)
{
    // Checking if the word in the phrase starts with a vowel
    // If it does, all we have to do is add "way" to the end of it
    if (vowels.Contains(phraseArray[index][0]) == true && phraseArray[index][0] != 'y')
    {
        pigLatinArray[index] = $"{phraseArray[index]}way";
    }
    else
    {
        bool foundVowel = false;
        for (int subIndex = 1; subIndex < phraseArray[index].Length; subIndex++)
        {
            if (subIndex == 1 && phraseArray[index][0] == 'q' && phraseArray[index][1] == 'u')
                subIndex = 2;
            //Need to find where the consonant cluster ends
            //So we find the first vowel in the word and rearrange it, adding "ay" on the end
            if (vowels.Contains(phraseArray[index].Substring(subIndex, 1)))
            {
                //Concatenating the substring after the consonant cluster, the consonant cluster, then "ay"
                //The compiler suggested using Concat and AsSpan for better memory usage
                pigLatinArray[index] = string.Concat(
                    phraseArray[index].AsSpan()[subIndex..phraseArray[index].Length],
                    phraseArray[index].AsSpan(0, subIndex),
                    "ay");
                foundVowel = true;
                //Break after we find the first vowel and declare the encoded string 
                break;
            }
        }
        //If the entire word was consonants, fallback to just adding ay
        if (foundVowel == false)
        {
            pigLatinArray[index] = phraseArray[index] + "ay";
        }
    }
}

//Get a random number for our offset
Random rng = new Random();
int rngOffset = rng.Next(1, 26);

//Make a new array for the offset phrase
string[] offsetArray = new string[pigLatinArray.Length];
for (int index = 0; index < pigLatinArray.Length; index++)
{
    foreach (char letter in pigLatinArray[index])
    {
        char newCharacter = letter;
        if ((letter + rngOffset) > 'z')
            newCharacter = (char)(letter - 26);
        offsetArray[index] = offsetArray[index] + (char)(newCharacter + rngOffset);
    }
}

//Add the punctuation back
if (punctuationToAdd != "")
{
    for (int index = punctuationToAdd.Length - 1; index >= 0; index--)
    {
        pigLatinArray[^1] += punctuationToAdd[index];
        offsetArray[^1] += punctuationToAdd[index];
    }
}

//Print our encoded phrases
Console.Write("In Pig Latin: ");
foreach (string word in pigLatinArray)
{
    Console.Write(word + " ");
}
Console.WriteLine();
Console.WriteLine($"Randomly chose {rngOffset} as an offset.");
Console.Write($"Encrypted: ");
foreach (string word in offsetArray)
{
    Console.Write(word + " ");
}
Console.WriteLine();