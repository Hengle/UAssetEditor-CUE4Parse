﻿namespace UnrealExtractor.Encryption.Aes;

public class FAesKey
{
    public byte[] Key;
    
    public FAesKey(byte[] key)
    {
        if (key.Length != 32)
            throw new InvalidDataException("AES key must be 32 bytes long.");
        
        Key = key;
    }

    public FAesKey(string key)
    {
        if (key.StartsWith("0x"))
            key = key.Substring(2);

        Key = key.ParseHexBinary();
    }
}

// Directly from 
// https://github.com/FabianFG/CUE4Parse/blob/master/CUE4Parse/Utils/HexUtils.cs
// Sorry, really didn't feel like rewriting this.. ;) - Owen
public static class HexUtils
{
    public static byte[] ParseHexBinary(this string hex)
    {
        if (hex.Length % 2 == 1)
            throw new ArgumentException("The binary key cannot have an odd number of digits");

        byte[] arr = new byte[hex.Length >> 1];

        for (var i = 0; i < hex.Length >> 1; ++i)
        {
            arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
        }

        return arr;
    }
    
    private static int GetHexVal(char hex) {
        int val = hex;
        //For uppercase A-F letters:
        //return val - (val < 58 ? 48 : 55);
        //For lowercase a-f letters:
        //return val - (val < 58 ? 48 : 87);
        //Or the two combined, but a bit slower:
        return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
    }
}