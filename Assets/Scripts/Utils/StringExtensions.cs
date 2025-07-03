using UnityEngine;

public static class StringExtensions
{
    /// <summary>
    /// computes FNV-1a hash for input string.
    /// useful for Dictionary keys instead of strings
    /// </summary>
    /// <param name="str">The input string to hash</param>
    /// <returns>An integer representing the FNV-1a hash of the input string.</returns>
    public static int ComputeFNV1aHash(this string str)
    {
        uint hash = 2166136261;
        foreach (char c in str)
        {
            hash = (hash ^ c) * 16777619;//prime number
        }

        return unchecked((int)hash);
    }
}