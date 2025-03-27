namespace GuidToHashResearch.Cli;

/// <summary>
/// Вычисление количество коллизий 
/// </summary>
public static class CalculateCollisions
{
    /// <summary>
    /// Вычисление количество коллизий 
    /// </summary>
    /// <param name="length">Длинна хэша</param>
    /// <param name="hashFunc">Хэш функция</param>
    /// <param name="substringFunc">Функция выбора </param>
    /// <param name="guidList">Список гуидников</param>
    public static int Collisions(int length, Func<string, string> hashFunc,
        Func<string, int, string> substringFunc, Guid[] guidList)
    {
        var hashed = new HashSet<string>();
        int collisions = 0;

        foreach (var guid in guidList)
        {
            string hash = hashFunc(guid.ToString("N")).ToLower(System.Globalization.CultureInfo.CurrentCulture);
            string subHash = substringFunc(hash, length);

            if (!hashed.Add(subHash))
            {
                collisions++;
            }
        }

        return collisions;
    }
}
