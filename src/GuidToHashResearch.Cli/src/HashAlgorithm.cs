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
        using var md5 = new System.Security.Cryptography.HMACMD5();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = md5.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    /// <summary>
    /// Получить хэш текста по алгоритму Sha256
    /// </summary>
    public static string GetStringSha256Hash(string text)
    {
        using var sha256 = new System.Security.Cryptography.HMACSHA256();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha256.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    /// <summary>
    /// Получить хэш текста по алгоритму Sha384
    /// </summary>
    public static string GetStringSha384Hash(string text)
    {
        using var sha384 = new System.Security.Cryptography.HMACSHA384();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha384.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    /// <summary>
    /// Получить хэш текста по алгоритму Sha512
    /// </summary>
    public static string GetStringSha512Hash(string text)
    {
        using var sha512 = new System.Security.Cryptography.HMACSHA512();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hash = sha512.ComputeHash(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}
