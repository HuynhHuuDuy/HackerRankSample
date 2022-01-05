using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public const string Positive = "Positive";
    public const string Negative = "Negative";
    public const string Zero = "Zero";
    public const string RoundDigitsOutput = "0.000000";
    public const int RoundDigitsNumber = 6;

    public static void plusMinus(List<int> arr)
    {
        var dicRatios = new Dictionary<string, int>()
        {
            {Positive, 0},
            {Negative, 0},
            {Zero, 0}
        };

        CalculateRatios(0, arr.Count() / 2, dicRatios, arr);
        CalculateRatios(arr.Count() / 2, arr.Count(), dicRatios, arr);

        Console.WriteLine(Math.Round((double)dicRatios[Positive] / arr.Count(), RoundDigitsNumber).ToString(RoundDigitsOutput));
        Console.WriteLine(Math.Round((double)dicRatios[Negative] / arr.Count(), RoundDigitsNumber).ToString(RoundDigitsOutput));
        Console.WriteLine(Math.Round((double)dicRatios[Zero] / arr.Count(), RoundDigitsNumber).ToString(RoundDigitsOutput));
    }

    static void CalculateRatios(int startEle, int endEle, IDictionary<string, int> dicRatios, List<int> arr)
    {
        for (int i = startEle; i < endEle; i++)
        {
            if (arr[i] > 0)
            {
                dicRatios[Positive] = dicRatios[Positive] + 1;
            }
            if (arr[i] < 0)
            {
                dicRatios[Negative] = dicRatios[Negative] + 1;
            }
            if (arr[i] == 0)
            {
                dicRatios[Zero] = dicRatios[Zero] + 1;
            }
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
