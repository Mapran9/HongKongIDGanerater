using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var hkidList = GenerateValidHKIDs(10);
        Console.WriteLine("Valid HKIDs (total %11 == 0):");
        foreach (var id in hkidList)
        {
            Console.WriteLine(id);
        }
    }

    public static List<string> GenerateValidHKIDs(int count)
    {
        var result = new List<string>();
        var rnd = new Random();

        while (result.Count < count)
        {
            char prefix;
            do
            {
                prefix = (char)rnd.Next('A', 'Z' + 1);
            } while (prefix == 'W'); // W is invalid

            string digits = rnd.Next(0, 999999).ToString("D6");

            for (int lastDigit = 0; lastDigit <= 9; lastDigit++)
            {
                string candidate = prefix + digits + lastDigit;
                if (IsValidHKID(candidate))
                {
                    result.Add(candidate);
                    break;
                }
            }
        }

        return result;
    }

    public static bool IsValidHKID(string id)
    {
        if (id.Length != 8) return false;

        char prefix = id[0];
        if (prefix == 'W' || prefix < 'A' || prefix > 'Z') return false;

        int prefixValue = prefix - 'A' + 1; // A=1, B=2, ..., Z=26

        int total = prefixValue * 8;
        int weight = 7;

        for (int i = 1; i < 8; i++)
        {
            if (!char.IsDigit(id[i])) return false;
            total += (id[i] - '0') * weight;
            weight--;
        }

        return total % 11 == 0;
    }
}
