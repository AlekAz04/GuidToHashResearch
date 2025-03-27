namespace GuidToHashResearch;

public static class RandomGuidToHashTest
{
    public static void RunRandomGuid()
    {
        RunTestsForRandomGuid("MD5", TestGuidToHashFirstMd5);
        Console.WriteLine();
        RunTestsForRandomGuid("MD5 Random Start", TestGuidToHashSecondMd5);
        Console.WriteLine();
        RunTestsForRandomGuid("Sha256", TestGuidToHashFirstSha256);
        Console.WriteLine();
        RunTestsForRandomGuid("Sha256 Random Start", TestGuidToHashSecondSha256);
        Console.WriteLine();
        RunTestsForRandomGuid("Sha384", TestGuidToHashFirstSha384);
        Console.WriteLine();
        RunTestsForRandomGuid("Sha384 Random Start", TestGuidToHashSecondSha384);
        Console.WriteLine();
        RunTestsForRandomGuid("Sha512", TestGuidToHashFirstSha512);
        Console.WriteLine();
        RunTestsForRandomGuid("Sha512 Random Start", TestGuidToHashSecondSha512);
    }

    private static void RunTestsForRandomGuid(string methodName, Func<int, int, int> testMethod)
    {
        Console.WriteLine($"Хэширование {methodName}");

        foreach (int guidCount in new[] { 1000, 10000, 1000000 }) // Количество гуидов
        {
            for (int i = 5; i < 8; i++)
            {
                int rep = testMethod(guidCount, i);

                Console.WriteLine(
                    $"Повторение при длине {i} на {guidCount} гуидах: {rep}, процент коллизии: {(double)rep / guidCount * 100}");
            }
        }
    }

    private static int TestRandomGuidToHash(int guidCount, int length, Func<string, string> hashFunc, Func<string, int, string> substringFunc)
    {
        var guidList = new Guid[guidCount];
        for (int i = 0; i < guidCount; i++)
        {
            guidList[i] = Guid.NewGuid();
        }

        int collisions = CalculateCollisions.Collisions(length, hashFunc, substringFunc, guidList);
        return collisions;
    }

    private static int TestGuidToHashFirstMd5(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringMD5Hash, (hash, len) => hash[..len]);
    }

    private static int TestGuidToHashSecondMd5(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringMD5Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }

    private static int TestGuidToHashFirstSha256(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringSha256Hash, (hash, len) => hash[..len]);
    }

    private static int TestGuidToHashSecondSha256(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringSha256Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }

    private static int TestGuidToHashFirstSha384(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringSha384Hash, (hash, len) => hash[..len]);
    }

    private static int TestGuidToHashSecondSha384(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringSha384Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }

    private static int TestGuidToHashFirstSha512(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringSha512Hash, (hash, len) => hash[..len]);
    }

    private static int TestGuidToHashSecondSha512(int guidCount, int length)
    {
        return TestRandomGuidToHash(guidCount, length, HashAlgorithm.GetStringSha512Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }
}
