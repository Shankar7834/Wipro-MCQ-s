Write a C# program that takes an array of strings as input, concatenates all the elements into a single string, extracts numeric characters from the concatenated
string, and calculates the maximum, minimum, and difference between the extracted numeric values. If no numeric characters are found, return 0 for
maximum, minimum, and difference.
--------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // User input for the array
        Console.WriteLine("Enter the elements of the array separated by spaces:");
        string[] inputArray = Console.ReadLine().Split(' ');

        // Step 1: Concatenate all elements of the array into a single string
        string concatenatedString = string.Join("", inputArray); // More efficient way to concatenate
        Console.WriteLine($"Concatenated String: {concatenatedString}");

        // Step 2: Extract all numeric characters from the concatenated string
        List<int> extractedNumbers = new List<int>();
        foreach (char c in concatenatedString)
        {
            if (char.IsDigit(c))
            {
                extractedNumbers.Add(int.Parse(c.ToString())); // Convert char to int
            }
        }

        // Display extracted numbers
        Console.WriteLine("Extracted Numbers: [" + string.Join(", ", extractedNumbers) + "]");

        // Check if any numbers were extracted
        if (extractedNumbers.Count > 0)
        {
            // Step 3: Find the maximum and minimum numbers
            int maximumNumber = extractedNumbers.Max(); // Use LINQ for max and min
            int minimumNumber = extractedNumbers.Min();
            Console.WriteLine($"Maximum Number: {maximumNumber}");
            Console.WriteLine($"Minimum Number: {minimumNumber}");
            Console.WriteLine($"Difference: {maximumNumber - minimumNumber}");
        }
        else
        {
            // Handle the case where no numbers are found
            Console.WriteLine("Maximum Number: 0");
            Console.WriteLine("Minimum Number: 0");
            Console.WriteLine("Difference: 0");
        }
    }
}
==============================================================================================================================================================
Question :2
Write a C# program to perform the following operations on a given string:
1. Check Substring: Verify if a given substring exists in the main string.
2. Replace Characters: Replace all occurrences of a specified character in the string with another character.
3. Swap Case: Convert uppercase characters to lowercase and lowercase characters to uppercase in the string.
4. Remove Whitespace: Remove all whitespace characters from the string.
5. Count Letters: Count the frequency of each letter (ignoring case) in the string.
1. Input 1: The main string.
2. Input 2: The substring to check.
3. Input 3: The character to be replaced.
4. Input 4: The replacement character.
--------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Input 1: Main String
        string mainString = GetInput("Enter the main string:");
        // Input 2: Substring
        string substring = GetInput("Enter the substring to check:");
        // Input 3: Character to be replaced
        char charToReplace = GetInput("Enter the character to replace:")[0];
        // Input 4: Character to replace with
        char replacementChar = GetInput("Enter the replacement character:")[0];

        bool substringExists = CheckSubstringExists(mainString, substring);
        string replacedString = ReplaceCharacter(mainString, charToReplace, replacementChar);
        string caseSwapped = SwapCase(mainString);
        string noSpaces = RemoveWhitespace(mainString);
        Dictionary<char, int> letterCount = CountLetters(mainString);

        Console.WriteLine($"Substring Exists: {(substringExists ? "Yes" : "No")}");
        Console.WriteLine($"Replaced: {replacedString}");
        Console.WriteLine($"Case Swapped: {caseSwapped}");
        Console.WriteLine($"No Spaces: {noSpaces}");
        Console.WriteLine($"Letter Count: {string.Join(", ", letterCount.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");
    }

    static string GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }

    static bool CheckSubstringExists(string main, string sub)
    {
        return main.Contains(sub);
    }

    static string ReplaceCharacter(string input, char oldChar, char newChar)
    {
        return input.Replace(oldChar, newChar);
    }

    static string SwapCase(string input)
    {
        char[] result = input.ToCharArray();
        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLower(result[i]))
            {
                result[i] = char.ToUpper(result[i]);
            }
            else if (char.IsUpper(result[i]))
            {
                result[i] = char.ToLower(result[i]);
            }
        }
        return new string(result);
    }

    static string RemoveWhitespace(string input)
    {
        return input.Replace(" ", "");
    }

    static Dictionary<char, int> CountLetters(string input)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach (char c in input.ToLower()) // Count case-insensitively
        {
            if (char.IsLetter(c)) // Only count letters
            {
                if (counts.ContainsKey(c))
                {
                    counts[c]++;
                }
                else
                {
                    counts[c] = 1;
                }
            }
        }
        return counts;
    }
}
==============================================================================================================================================================
Question 3:
1. CalculateMedian: Write logic to sort the array and calculate the median.
2. FindSecondLargest: Write logic to find the second largest element in the array.
3. IsPalindrome: Write logic to check if the array is the same when reversed.
4. RotateLeft: Write logic to rotate the array to the left by a specified number of steps
--------------------------------------------------------------------------------------

using System;
using System.Linq;

public class ArrayOperations
{
    // Function to calculate the median of an array
    public static double CalculateMedian(int[] arr)
    {
        Array.Sort(arr);
        int mid = arr.Length / 2;
        return (arr.Length % 2 != 0) ? arr[mid] : (arr[mid - 1] + arr[mid]) / 2.0;
    }

    // Function to find the second largest element in an array
    public static int FindSecondLargest(int[] arr)
    {
        return arr.OrderByDescending(x => x).Skip(1).First();
    }

    // Function to check if an array is a palindrome
    public static bool IsPalindrome(int[] arr)
    {
        return arr.SequenceEqual(arr.Reverse());
    }

    // Function to rotate the array to the left by a given number of steps
    public static int[] RotateLeft(int[] arr, int steps)
    {
        steps = steps % arr.Length;
        return arr.Skip(steps).Concat(arr.Take(steps)).ToArray();
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        int[] testArray = { 5, 1, 4, 2, 5 };
        Console.WriteLine("Median: " + CalculateMedian(testArray));
        Console.WriteLine("Second Largest: " + FindSecondLargest(testArray));
        Console.WriteLine("Is Palindrome: " + IsPalindrome(testArray));
        int[] rotatedArray = RotateLeft(testArray, 2);
        Console.WriteLine("Rotated Array: " + string.Join(", ", rotatedArray));
    }
}
==============================================================================================================================================================
Question 4:
1. FindUniqueElements: Write logic to extract all unique elements from an array.
2. FindIntersection: Write logic to find the common elements between two arrays.
3. MergeAndRemoveDuplicates: Write logic to merge two arrays into one, removing duplicate elements.
4. LongestIncreasingSubsequence: Write logic to find the longest sequence of increasing elements in the array.
--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class AdvanceArrayOperations
{
    // Function to find all unique elements in an array
    public static int[] FindUniqueElements(int[] arr)
    {
        return arr.Distinct().ToArray();
    }

    // Function to find the intersection of two arrays
    public static int[] FindIntersection(int[] arr1, int[] arr2)
    {
        return arr1.Intersect(arr2).ToArray();
    }

    // Function to merge two arrays and remove duplicates
    public static int[] MergeAndRemoveDuplicates(int[] arr1, int[] arr2)
    {
        return arr1.Union(arr2).ToArray();
    }

    // Function to find the longest increasing subsequence in an array
    public static int[] LongestIncreasingSubsequence(int[] arr)
    {
        List<int> result = new List<int>();
        List<int> temp = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (temp.Count == 0 || arr[i] > temp.Last())
            {
                temp.Add(arr[i]);
            }
            else
            {
                if (temp.Count > result.Count)
                {
                    result = new List<int>(temp);
                }
                temp.Clear();
                temp.Add(arr[i]);
            }
        }

        return result.Count > temp.Count ? result.ToArray() : temp.ToArray();
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        int[] array1 = { 1, 2, 2, 3, 4, 5 };
        int[] array2 = { 2, 3, 6, 7, 8 };

        Console.WriteLine("Unique Elements: " + string.Join(", ", FindUniqueElements(array1)));
        Console.WriteLine("Intersection: " + string.Join(", ", FindIntersection(array1, array2)));
        Console.WriteLine("Merged Without Duplicates: " + string.Join(", ", MergeAndRemoveDuplicates(array1, array2)));
        Console.WriteLine("Longest Increasing Subsequence: " + string.Join(", ", LongestIncreasingSubsequence(array1)));
    }
}
==============================================================================================================================================================
Question 5:
1. FindMajorityElement: Write logic to identify the majority element, if one exists, in the array.
2. FindSmallestMissingPositive: Write logic to find the smallest positive integer that is missing from the array.
3. FindKthLargest: Implement a function to find the kth largest element in the array.
4. ContainsDuplicate: Write logic to determine if the array contains any duplicate elements.
--------------------------------------------------------------------------------
using System;
using System.Linq;

public class ArrayAdvanceChallenges
{
    // Function to find the majority element in an array
    public static int? FindMajorityElement(int[] arr)
    {
        var groups = arr.GroupBy(x => x);
        var majority = groups.FirstOrDefault(g => g.Count() > arr.Length / 2);
        return majority?.Key;
    }

    // Function to find the smallest missing positive integer
    public static int FindSmallestMissingPositive(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            while (arr[i] > 0 && arr[i] <= n && arr[arr[i] - 1] != arr[i])
            {
                int temp = arr[arr[i] - 1];
                arr[arr[i] - 1] = arr[i];
                arr[i] = temp;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (arr[i] != i + 1)
            {
                return i + 1;
            }
        }

        return n + 1;
    }

    // Function to find the kth largest element in the array
    public static int FindKthLargest(int[] arr, int k)
    {
        return arr.OrderByDescending(x => x).Skip(k - 1).First();
    }

    // Function to check if the array contains a duplicate
    public static bool ContainsDuplicate(int[] arr)
    {
        return arr.Length != arr.Distinct().Count();
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        int[] testArray = { 3, 1, 2, 3, 4, 2, 1 };

        Console.WriteLine("Majority Element: " + FindMajorityElement(testArray));
        Console.WriteLine("Smallest Missing Positive: " + FindSmallestMissingPositive(testArray));
        Console.WriteLine("3rd Largest Element: " + FindKthLargest(testArray, 3));
        Console.WriteLine("Contains Duplicate: " + ContainsDuplicate(testArray));
    }
}
==============================================================================================================================================================
Question 6:
1. ReverseString: Write logic to reverse the input string.
2. IsPalindrome: Write logic to check if the input string is the same forwards and backwards.
3. CharacterFrequency: Implement logic to count and display the frequency of each character in the input string.
4. FirstNonRepeatingCharacter: Write logic to find the first character in the string that does not repeat.
--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class StringFunctions
{
    // Function to reverse a string
    public static string ReverseString(string input)
    {
        return new string(input.Reverse().ToArray());
    }

    // Function to check if a string is a palindrome
    public static bool IsPalindrome(string input)
    {
        return input == ReverseString(input);
    }

    // Function to count the frequency of each character in a string
    public static void CharacterFrequency(string input)
    {
        var frequency = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        foreach (var kvp in frequency)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    // Function to find the first non-repeating character in a string
    public static char? FirstNonRepeatingCharacter(string input)
    {
        var frequency = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        return frequency.FirstOrDefault(kvp => kvp.Value == 1).Key;
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "civic";

        Console.WriteLine("Reversed String: " + ReverseString(testString));
        Console.WriteLine("Is Palindrome: " + IsPalindrome(testString));

        Console.WriteLine("Character Frequency:");
        CharacterFrequency(testString);

        Console.WriteLine("First Non-Repeating Character: " + FirstNonRepeatingCharacter(testString));
    }
}
==============================================================================================================================================================
Question 7:
1. LongestUniqueSubstring: Write logic to find the longest substring of the input string without repeating characters.
2. AreAnagrams: Write logic to check if two input strings are anagrams of each other.
3. CapitalizeWords: Implement logic to capitalize the first letter of each word in the input string.
4. CountVowelsAndConsonants: Write logic to count the number of vowels and consonants in the input string.
--------------------------------------------------------------------------------
using System;
using System.Linq;

public class AdvancedStringFunctions
{
    // Function to find the longest substring without repeating characters
    public static string LongestUniqueSubstring(string input)
    {
        string result = "";
        for (int i = 0; i < input.Length; i++)
        {
            string temp = "";
            for (int j = i; j < input.Length; j++)
            {
                if (temp.Contains(input[j]))
                {
                    break;
                }
                temp += input[j];
            }
            if (temp.Length > result.Length)
            {
                result = temp;
            }
        }
        return result;
    }

    // Function to check if two strings are anagrams
    public static bool AreAnagrams(string str1, string str2)
    {
        return str1.OrderBy(c => c).SequenceEqual(str2.OrderBy(c => c));
    }

    // Function to capitalize the first letter of each word in a string
    public static string CapitalizeWords(string input)
    {
        return string.Join(" ", input.Split(' ').Select(word => word.Length > 0 ? char.ToUpper(word[0]) + word.Substring(1) : word));
    }

    // Function to count the number of vowels and consonants in a string
    public static (int vowels, int consonants) CountVowelsAndConsonants(string input)
    {
        int vowels = input.Count("aeiouAEIOU".Contains);
        int consonants = input.Count(char.IsLetter) - vowels;
        return (vowels, consonants);
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "programming";
        string testString2 = "margorp";

        Console.WriteLine("Longest Unique Substring: " + LongestUniqueSubstring(testString));
        Console.WriteLine("Are Anagrams: " + AreAnagrams(testString, testString2));
        Console.WriteLine("Capitalized Words: " + CapitalizeWords("hello world from csharp"));
        var counts = CountVowelsAndConsonants(testString);
        Console.WriteLine("Vowels: " + counts.vowels + ", Consonants: " + counts.consonants);
    }
}
==============================================================================================================================================================
Question 8:
1. InsertAtEveryNthPosition: Write logic to insert a specified character at every nth position in the input string.
2. RemoveAllOccurrences: Write logic to remove all occurrences of a specific character from the input string.
3. ReplaceNthOccurrence: Implement logic to replace the nth occurrence of a substring in the input string with another substring.
4. RemoveAfterIndex: Write logic to remove all characters from the string after a specified index
--------------------------------------------------------------------------------
using System;
using System.Text;

public class StringModification
{
    // Function to insert a character at every nth position in a string
    public static string InsertAtEveryNthPosition(string input, char toInsert, int n)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            result.Append(input[i]);
            if ((i + 1) % n == 0)
            {
                result.Append(toInsert);
            }
        }
        return result.ToString();
    }

    // Function to remove every occurrence of a specific character from a string
    public static string RemoveAllOccurrences(string input, char toRemove)
    {
        return input.Replace(toRemove.ToString(), "");
    }

    // Function to replace the nth occurrence of a substring with another substring
    public static string ReplaceNthOccurrence(string input, string toReplace, string replacement, int n)
    {
        int count = 0;
        int index = -1;
        while ((index = input.IndexOf(toReplace, index + 1)) != -1)
        {
            count++;
            if (count == n)
            {
                return input.Substring(0, index) + replacement + input.Substring(index + toReplace.Length);
            }
        }
        return input;
    }

    // Function to modify a string by removing all characters after a specific index
    public static string RemoveAfterIndex(string input, int index)
    {
        return input.Substring(0, Math.Min(index, input.Length));
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "hello-world-hello-world";

        Console.WriteLine("Insert at Every 3rd Position: " + InsertAtEveryNthPosition(testString, '*', 3));
        Console.WriteLine("Remove All Occurrences of '-': " + RemoveAllOccurrences(testString, '-'));
        Console.WriteLine("Replace 2nd Occurrence of 'world': " + ReplaceNthOccurrence(testString, "world", "C#", 2));
        Console.WriteLine("Remove After Index 10: " + RemoveAfterIndex(testString, 10));
    }
}
==============================================================================================================================================================
Question 9:
1. InsertAfterCharacter: Write logic to insert a substring after every occurrence of a specified character in the input string.
2. RemoveFirstNCharacters: Write logic to remove the first n characters from the input string.
3. ReplaceVowels: Implement logic to replace all vowels in the input string with a specified character.
4. ReverseWords: Write logic to reverse only the words in a sentence, maintaining the order of spaces.
--------------------------------------------------------------------------------
using System;
using System.Text;
using System.Linq; // This is the crucial missing line

public class AdvancedStringModification
{
    // Function to insert a substring after every occurrence of a specified character
    public static string InsertAfterCharacter(string input, char target, string toInsert)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input)
        {
            result.Append(c);
            if (c == target)
            {
                result.Append(toInsert);
            }
        }
        return result.ToString();
    }

    // Function to remove the first n characters from a string
    public static string RemoveFirstNCharacters(string input, int n)
    {
        if (n >= input.Length) {
            return ""; // Or throw an exception
        }
        return input.Substring(n);
    }

    // Function to replace all vowels in a string with a specified character
    public static string ReplaceVowels(string input, char replacement)
    {
        return new string(input.Select(c => "aeiouAEIOU".Contains(c) ? replacement : c).ToArray());
    }

    // Function to reverse only the words in a sentence while preserving spaces
    public static string ReverseWords(string input)
    {
        return string.Join(" ", input.Split(' ').Select(word => new string(word.Reverse().ToArray())));
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "hello world this is C#";

        Console.WriteLine("Insert After Character 'o': " + InsertAfterCharacter(testString, 'o', "-inserted"));
        Console.WriteLine("Remove First 5 Characters: " + RemoveFirstNCharacters(testString, 5));
        Console.WriteLine("Replace Vowels with '*': " + ReplaceVowels(testString, '*'));
        Console.WriteLine("Reverse Words: " + ReverseWords(testString));
    }
}
==============================================================================================================================================================
Question 10:
1. InsertBetweenCharacters: Write logic to insert a given sequence of characters between each character of the input string.
2. RemoveDuplicates: Write logic to remove all duplicate characters from the input string while preserving the first occurrence.
3. ReplaceLastOccurrence: Implement logic to replace only the last occurrence of a specified substring in the input string.
4. KeepUniqueWords: Write logic to keep only the unique words in a sentence, removing all repeated words.
--------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class ComplexStringModification
{
    // Function to insert a sequence of characters in between each character of the string
    public static string InsertBetweenCharacters(string input, string toInsert)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            result.Append(input[i]);
            if (i < input.Length - 1)
            {
                result.Append(toInsert);
            }
        }
        return result.ToString();
    }

    // Function to remove all duplicate characters from a string
    public static string RemoveDuplicates(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return new string(input.ToCharArray().Distinct().ToArray());
    }

    // Function to replace the last occurrence of a substring with another substring
    public static string ReplaceLastOccurrence(string input, string toReplace, string replacement)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(toReplace))
        {
            return input; // Or throw an exception, depending on desired behavior
        }

        int lastIndex = input.LastIndexOf(toReplace);
        if (lastIndex >= 0)
        {
            return input.Substring(0, lastIndex) + replacement + input.Substring(lastIndex + toReplace.Length);
        }
        return input;
    }

    // Function to modify a string by keeping only unique words
    public static string KeepUniqueWords(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        string[] words = input.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", words.Distinct());
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "hello world hello universe";
        Console.WriteLine("Insert Between Characters: " + InsertBetweenCharacters(testString, "-"));
        Console.WriteLine("Remove Duplicates: " + RemoveDuplicates(testString));
        Console.WriteLine("Replace Last Occurrence of 'hello': " + ReplaceLastOccurrence(testString, "hello", "hi"));
        Console.WriteLine("Keep Unique Words: " + KeepUniqueWords(testString));
    }
}
==============================================================================================================================================================
Question 11:
1. RotateRight: Write logic to rotate the array to the right by a given number of steps.
2. FindTripletsWithSum: Implement logic to find all unique triplets in the array that sum up to the given target value.
3. MaxProductOfThree: Write logic to calculate the maximum product of any three numbers in the array.
4. FindUniqueElement: Write logic to find the element that appears only once in an array where all other elements appear twice.
--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayOperationsAdvanced
{
    // Function to rotate an array to the right by a given number of steps
    public static int[] RotateRight(int[] arr, int steps)
    {
        if (arr == null || arr.Length == 0 || steps < 0)
        {
            return arr; // Or throw an exception if you prefer
        }

        int n = arr.Length;
        steps %= n; // Handle steps larger than array length
        int[] rotated = new int[n];

        Array.Copy(arr, n - steps, rotated, 0, steps);
        Array.Copy(arr, 0, rotated, steps, n - steps);

        return rotated;
    }

    // Function to find all triplets in an array that sum to a specific value
    public static void FindTripletsWithSum(int[] arr, int targetSum)
    {
        if (arr == null || arr.Length < 3)
        {
            return; // Not enough elements for triplets
        }

        Array.Sort(arr); // Important for efficiency and avoiding duplicates

        for (int i = 0; i < arr.Length - 2; i++)
        {
            int left = i + 1;
            int right = arr.Length - 1;

            while (left < right)
            {
                int sum = arr[i] + arr[left] + arr[right];
                if (sum == targetSum)
                {
                    Console.WriteLine(arr[i] + ", " + arr[left] + ", " + arr[right]);
                    left++;
                    right--;

                    // Skip duplicates (important!)
                    while (left < right && arr[left] == arr[left - 1]) left++;
                    while (left < right && arr[right] == arr[right + 1]) right--;

                }
                else if (sum < targetSum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }
    }

    // Function to find the maximum product of three numbers in an array
    public static int MaxProductOfThree(int[] arr)
    {
        if (arr == null || arr.Length < 3)
        {
            return 0; // Or throw an exception
        }

        Array.Sort(arr);

        int n = arr.Length;
        // Consider the product of the three largest numbers OR the product of the two smallest and the largest (if there are negative numbers)
        return Math.Max(arr[n - 1] * arr[n - 2] * arr[n - 3], arr[0] * arr[1] * arr[n - 1]);
    }

    // Function to find the element that appears only once in an array where every other element appears twice
    public static int FindUniqueElement(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return 0; // Or throw an exception
        }

        // XOR approach:  a ^ a = 0, a ^ 0 = a.  Duplicates cancel out.
        int result = 0;
        foreach (int num in arr)
        {
            result ^= num;
        }
        return result;
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        int[] testArray = { 1, 2, 3, 4, 5, 6, 7 };
        int targetSum = 12;
        Console.WriteLine("Rotated Array (Right by 2): " + string.Join(", ", RotateRight(testArray, 2)));
        Console.WriteLine("Triplets with Sum " + targetSum + ":");
        FindTripletsWithSum(testArray, targetSum);
        Console.WriteLine("Max Product of Three: " + MaxProductOfThree(testArray));
        int[] uniqueArray = { 2, 2, 3, 4, 4 };
        Console.WriteLine("Unique Element: " + FindUniqueElement(uniqueArray));

        int[] test2 = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
        Console.WriteLine("Max Product of Three (with negatives): " + MaxProductOfThree(test2));

    }
}
==============================================================================================================================================================
Question 12:
1. ReverseString: Use StringBuilder to reverse the input string.
2. RemoveVowels: Implement logic to remove all vowels (a, e, i, o, u) from the input string using StringBuilder .
3. AppendToWords: Use StringBuilder to append a specified character at the start and end of each word in a sentence.
4. ReplaceWord: Implement logic to replace all occurrences of a specific word in the input string with another word using StringBuilder .
--------------------------------------------------------------------------------
using System;
using System.Text;
using System.Text.RegularExpressions; // For RemoveVowels (optional, but cleaner)

public class StringBuilderOperations
{
    // Function to reverse a string using StringBuilder
    public static string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder(input);
        for (int i = 0, j = sb.Length - 1; i < j; i++, j--)
        {
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;
        }
        return sb.ToString();
    }

    // Function to remove all vowels from a string using StringBuilder
    public static string RemoveVowels(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (!"aeiouAEIOU".Contains(c)) // Or use Regex for more complex vowel removal
            {
                sb.Append(c);
            }
        }
        return sb.ToString();

        // Alternative using Regex (more flexible for complex vowel definitions)
        // return Regex.Replace(input, "[aeiouAEIOU]", ""); 
    }

    // Function to append a specified character at the start and end of each word in a sentence
    public static string AppendToWords(string input, char toAppend)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        string[] words = input.Split(' '); // Split into words

        for (int i = 0; i < words.Length; i++)
        {
            sb.Append(toAppend);
            sb.Append(words[i]);
            sb.Append(toAppend);

            if (i < words.Length - 1)
            {
                sb.Append(' '); // Add space between words
            }
        }
        return sb.ToString();
    }

    // Function to replace all occurrences of a specific word in a string with another word using StringBuilder
    public static string ReplaceWord(string input, string targetWord, string replacementWord)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(targetWord) || replacementWord == null)
        {
            return input;  // Or throw an exception, depending on requirements.
        }

        StringBuilder sb = new StringBuilder(input);
        int index = sb.ToString().IndexOf(targetWord, StringComparison.OrdinalIgnoreCase); // Case-insensitive search

        while (index >= 0)
        {
            sb.Remove(index, targetWord.Length);
            sb.Insert(index, replacementWord);
            index = sb.ToString().IndexOf(targetWord, index + replacementWord.Length, StringComparison.OrdinalIgnoreCase); // Find next occurrence
        }

        return sb.ToString();
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "StringBuilder is powerful";
        Console.WriteLine("Reversed String: " + ReverseString(testString));
        Console.WriteLine("String Without Vowels: " + RemoveVowels(testString));
        Console.WriteLine("Appended to Words: " + AppendToWords(testString, '*'));
        Console.WriteLine("Replace 'powerful' with 'amazing': " + ReplaceWord(testString, "powerful", "amazing"));
    }
}
==============================================================================================================================================================
Question 13:
1. ReverseWords: Write logic to reverse every word in the input sentence while keeping the words in order.
2. RemoveVowels: Implement logic to remove all vowels from the input string using StringBuilder .
3. ReplaceEveryNthCharacter: Write logic to replace every nth character in the input string with a specified character.
4. GeneratePalindrome: Implement logic to generate a palindrome by appending the reverse of the input string to itself.
--------------------------------------------------------------------------------
using System;
using System.Text;
using System.Text.RegularExpressions;

public class StringBuilderOperations
{
    // Function to reverse every word in a sentence using StringBuilder
    public static string ReverseWords(StringBuilder input)
    {
        if (input == null || input.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder result = new StringBuilder();
        string[] words = input.ToString().Split(' ');

        foreach (string word in words)
        {
            StringBuilder reversedWord = new StringBuilder(word);
            for (int i = 0, j = reversedWord.Length - 1; i < j; i++, j--)
            {
                char temp = reversedWord[i];
                reversedWord[i] = reversedWord[j];
                reversedWord[j] = temp;
            }
            result.Append(reversedWord);
            result.Append(' '); // Add space after each word
        }
        return result.ToString().Trim(); // Remove trailing space
    }

    // Function to remove all vowels from a string using StringBuilder
    public static string RemoveVowels(StringBuilder input)
    {
        if (input == null || input.Length == 0)
        {
            return string.Empty;
        }

        return Regex.Replace(input.ToString(), "[aeiouAEIOU]", ""); // Efficient vowel removal
    }

    // Function to replace every nth character in a string with a specific character using StringBuilder
    public static string ReplaceEveryNthCharacter(StringBuilder input, char replacement, int n)
    {
        if (input == null || input.Length == 0 || n <= 0)
        {
            return input?.ToString() ?? string.Empty; // Handle null input and invalid n
        }

        for (int i = n - 1; i < input.Length; i += n)
        {
            input[i] = replacement;
        }
        return input.ToString();
    }

    // Function to generate a palindrome from a string using StringBuilder
    public static string GeneratePalindrome(StringBuilder input)
    {
        if (input == null || input.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder reversed = new StringBuilder(input.ToString());
        for (int i = 0, j = reversed.Length - 1; i < j; i++, j--)
        {
            char temp = reversed[i];
            reversed[i] = reversed[j];
            reversed[j] = temp;
        }
        return input.ToString() + reversed.ToString(); // Concatenate original and reversed
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        StringBuilder testInput = new StringBuilder("hello world from csharp");
        Console.WriteLine("Reversed Words: " + ReverseWords(testInput));

        testInput = new StringBuilder("hello world from csharp"); // Reset for other tests
        Console.WriteLine("Without Vowels: " + RemoveVowels(testInput));

        testInput = new StringBuilder("hello world from csharp"); // Reset
        Console.WriteLine("Replace Every 3rd Character with '*': " + ReplaceEveryNthCharacter(testInput, '*', 3));

        Console.WriteLine("Generated Palindrome: " + GeneratePalindrome(new StringBuilder("race")));
    }
}
==============================================================================================================================================================
Question 14:
1. InsertAfterEachWord: Write logic to insert a specific substring after each word in the sentence using StringBuilder .
2. CountCharacterFrequency: Implement logic to count the frequency of a specific character in the string using StringBuilder .
3. ReplaceSubstring: Write logic to replace all occurrences of one substring with another in the input using StringBuilder .
4. CompressString: Implement logic to remove all spaces from the string and return the compressed version using StringBuilder .
--------------------------------------------------------------------------------
using System;
using System.Text;

public class AdvancedStringBuilderOperations
{
    // Function to insert a specific substring after every word in a sentence
    public static string InsertAfterEachWord(StringBuilder input, string toInsert)
    {
        if (input == null || input.Length == 0 || string.IsNullOrEmpty(toInsert))
        {
            return input?.ToString() ?? string.Empty; // Handle null input or empty toInsert
        }

        StringBuilder result = new StringBuilder();
        string[] words = input.ToString().Split(' ');

        foreach (string word in words)
        {
            result.Append(word);
            result.Append(toInsert);
            result.Append(' ');
        }
        return result.ToString().Trim(); // Remove trailing space
    }

    // Function to count the frequency of a specific character in the string
    public static int CountCharacterFrequency(StringBuilder input, char target)
    {
        if (input == null || input.Length == 0)
        {
            return 0;
        }

        int count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (char.ToLower(input[i]) == char.ToLower(target)) // Case-insensitive count
            {
                count++;
            }
        }
        return count;
    }

    // Function to replace all occurrences of a substring with another substring
    public static string ReplaceSubstring(StringBuilder input, string oldValue, string newValue)
    {
        if (input == null || input.Length == 0 || string.IsNullOrEmpty(oldValue) || newValue == null)
        {
            return input?.ToString() ?? string.Empty; // Handle null input or invalid parameters
        }

        return input.ToString().Replace(oldValue, newValue); // String.Replace is efficient enough
    }

    // Function to remove all spaces and compress the string using StringBuilder
    public static string CompressString(StringBuilder input)
    {
        if (input == null || input.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (!char.IsWhiteSpace(input[i])) // Check for whitespace
            {
                result.Append(input[i]);
            }
        }
        return result.ToString();
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        StringBuilder testInput = new StringBuilder("hello world from csharp hello");
        Console.WriteLine("Insert After Each Word: " + InsertAfterEachWord(testInput, "-inserted"));

        testInput = new StringBuilder("hello world from csharp hello"); // Reset
        Console.WriteLine("Frequency of 'o': " + CountCharacterFrequency(testInput, 'o'));

        testInput = new StringBuilder("hello world from csharp hello"); // Reset
        Console.WriteLine("Replace 'hello' with 'hi': " + ReplaceSubstring(testInput, "hello", "hi"));

        testInput = new StringBuilder("hello world from csharp hello"); // Reset
        Console.WriteLine("Compressed String: " + CompressString(testInput));
    }
}
==============================================================================================================================================================
Question 15:
1. ExtractWordsStartingWith: Write logic to split the input sentence into words and extract all words that start with a specific character using Split and Substring .
2. FindAllIndicesOfSubstring: Implement logic to find and return all starting indices of a given substring in the input string using IndexOf .
3. AllWordsContainCharacter: Write logic to check if every word in the input string contains a specific character using Contains .
4. ReplaceWordsContainingSubstring: Implement logic to replace all words containing a given substring with a specified replacement word
--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StringFunctionOperations
{
    // Function to extract all words starting with a specific character using Split and Substring
    public static string[] ExtractWordsStartingWith(string input, char startingChar)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new string[0];
        }

        string[] words = input.Split(' ');
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (word.Length > 0 && char.ToLower(word[0]) == char.ToLower(startingChar)) // Case-insensitive comparison
            {
                result.Add(word);
            }
        }
        return result.ToArray();
    }

    // Function to find all indices of a substring in a string
    public static int[] FindAllIndicesOfSubstring(string input, string substring)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(substring))
        {
            return new int[0];
        }

        List<int> indices = new List<int>();
        int index = input.IndexOf(substring, StringComparison.OrdinalIgnoreCase); // Case-insensitive

        while (index != -1)
        {
            indices.Add(index);
            index = input.IndexOf(substring, index + substring.Length, StringComparison.OrdinalIgnoreCase); // Find next occurrence
        }
        return indices.ToArray();
    }

    // Function to check if all words in a sentence contain a specific character
    public static bool AllWordsContainCharacter(string input, char targetChar)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            if (!word.ToLower().Contains(char.ToLower(targetChar))) // Case-insensitive check
            {
                return false;
            }
        }
        return true;
    }

    // Function to replace all words containing a specific substring with another word
    public static string ReplaceWordsContainingSubstring(string input, string substring, string replacement)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(substring) || replacement == null)
        {
            return input; // Or throw exception as needed
        }

        string[] words = input.Split(' ');
        StringBuilder result = new StringBuilder();

        foreach (string word in words)
        {
            if (word.ToLower().Contains(substring.ToLower())) // Case-insensitive contains check
            {
                result.Append(replacement);
            }
            else
            {
                result.Append(word);
            }
            result.Append(' ');
        }
        return result.ToString().Trim(); // Remove trailing space
    }

    // Main method for testing
    public static void Main(string[] args)
    {
        string testString = "hello world from C# programming language";
        Console.WriteLine("Words Starting with 'h': " + string.Join(", ", ExtractWordsStartingWith(testString, 'h')));
        Console.WriteLine("Indices of 'world': " + string.Join(", ", FindAllIndicesOfSubstring(testString, "world")));
        Console.WriteLine("All Words Contain 'o': " + AllWordsContainCharacter(testString, 'o'));
        Console.WriteLine("Replace Words Containing 'pro': " + ReplaceWordsContainingSubstring(testString, "pro", "awesome"));
    }
}
==============================================================================================================================================================
