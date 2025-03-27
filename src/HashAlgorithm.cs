namespace GuidToHashResearch;

public static class HashAlgorithm
{
    public static string GetStringMD5Hash(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        using var sha = new System.Security.Cryptography.HMACMD5();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    public static string GetStringSha256Hash(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        using var sha = new System.Security.Cryptography.HMACSHA256();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    public static string GetStringSha384Hash(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        using var sha = new System.Security.Cryptography.HMACSHA384();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    public static string GetStringSha512Hash(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        using var sha = new System.Security.Cryptography.HMACSHA512();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}
