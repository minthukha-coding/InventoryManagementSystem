using System.Security.Cryptography;

namespace InventoryManagementSystemApi.Shared;

public static class DevCode
{
    #region SHA256 Password HashString

    public static string ToSHA256HexHashString(this string password, string str)
    {
        password = password.Trim();
        str = str.Trim();

        string saltedCode = EncodedBySalted(str);
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.Default.GetBytes(password + saltedCode));
        var hashString = ToHex(hash, false);

        return hashString;
    }

    private static string EncodedBySalted(string decodeString)
    {
        decodeString = decodeString.ToLower()
            .Replace("a", "@")
            .Replace("i", "!")
            .Replace("l", "1")
            .Replace("e", "3")
            .Replace("o", "0")
            .Replace("s", "$")
            .Replace("n", "&");
        return decodeString;
    }

    private static string ToHex(byte[] bytes, bool upperCase)
    {
        var result = new StringBuilder(bytes.Length * 2);
        for (int i = 0; i < bytes.Length; i++)
            result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
        return result.ToString();
    }

    #endregion

}
