namespace GuidToHashResearch.Cli;

/// <summary>
/// Алгоритмы хэширования
/// </summary>
public static class HashAlgorithm
{
    /// <summary>
    /// Получить хэш текста по алгоритму MD5
    /// </summary>
    public static string GetStringMD5Hash(string text)
    {
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }

    /// <summary>
    /// Получить хэш текста по алгоритму Sha256
    /// </summary>
    public static string GetStringSha256Hash(string text)
    {
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = System.Security.Cryptography.SHA256.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }

    /// <summary>
    /// Получить хэш текста по алгоритму Sha384
    /// </summary>
    public static string GetStringSha384Hash(string text)
    {
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = System.Security.Cryptography.SHA384.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }

    /// <summary>
    /// Получить хэш текста по алгоритму Sha512
    /// </summary>
    public static string GetStringSha512Hash(string text)
    {
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = System.Security.Cryptography.SHA512.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}
