namespace GuidToHashResearch;

public static class CalculateCollisions
{
    public static int Collisions(int length, Func<string, string> hashFunc,
        Func<string, int, string> substringFunc, Guid[] guidList)
    {
        var hashed = new HashSet<string>();
        var rep = 0;

        foreach (var guid in guidList)
        {
            var hash = hashFunc(guid.ToString("N")).ToLower();
            var subHash = substringFunc(hash, length);

            if (!hashed.Add(subHash))
            {
                rep++;
            }
        }

        return rep;
    }

}