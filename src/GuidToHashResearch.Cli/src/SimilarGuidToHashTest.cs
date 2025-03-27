namespace GuidToHashResearch;

public static class SimilarGuidToHashTest
{
    public static void RunSimilarGuid()
    {
        RunTestsForSimilarGuid("MD5", TestSimilarGuidToHashFirstMd5);
        Console.WriteLine();
        RunTestsForSimilarGuid("MD5 Random Start", TestSimilarGuidToHashSecondMd5);
        Console.WriteLine();
        RunTestsForSimilarGuid("Sha256", TestSimilarGuidToHashFirstSha256);
        Console.WriteLine();
        RunTestsForSimilarGuid("Sha256 Random Start", TestSimilarGuidToHashSecondSha256);
        Console.WriteLine();
        RunTestsForSimilarGuid("Sha384", TestSimilarGuidToHashFirstSha384);
        Console.WriteLine();
        RunTestsForSimilarGuid("Sha384 Random Start", TestSimilarGuidToHashSecondSha384);
        Console.WriteLine();
        RunTestsForSimilarGuid("Sha512", TestSimilarGuidToHashFirstSha512);
        Console.WriteLine();
        RunTestsForSimilarGuid("Sha512 Random Start", TestSimilarGuidToHashSecondSha512);
    }


    private static void RunTestsForSimilarGuid(string methodName, Func<int, int, int> testMethod)
    {
        Console.WriteLine($"Хэширование {methodName}");

        foreach (var guidCount in new[] { 1000, 10000, 1000000 }) // Количество гуидов
        {
            for (int i = 5; i < 8; i++)
            {
                var rep = testMethod(guidCount, i);

                Console.WriteLine(
                    $"Повторение при длине {i} на {guidCount} гуидах: {rep}, процент коллизии: {(double)rep / guidCount * 100}");
            }
        }
    }

    private static int TestSimilarGuidToHash(int take, int length, Func<string, string> hashFunc,
        Func<string, int, string> substringFunc)
    {
        var guidList = CreateSimilarGuids(take);

        int collisions = CalculateCollisions.Collisions(length, hashFunc, substringFunc, guidList);
        return collisions;
    }

    private static Guid[] CreateSimilarGuids(int count)
    {
        var guids = new List<Guid>();

        for (byte i = 0; i < byte.MaxValue; i++)
        {
            for (byte j = 0; j < byte.MaxValue; j++)
            {
                for (byte k = 0; k < byte.MaxValue; k++)
                {
                    guids.Add(new Guid(0, 0, 0, 0, 0, 0, 0, 0, i, j, k));
                }
            }
        }

        return guids.Take(count).ToArray();
    }

    private static int TestSimilarGuidToHashFirstMd5(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringMD5Hash, (hash, len) => hash[..len]);
    }

    private static int TestSimilarGuidToHashSecondMd5(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringMD5Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }
    private static int TestSimilarGuidToHashFirstSha256(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringSha256Hash, (hash, len) => hash[..len]);
    }

    private static int TestSimilarGuidToHashSecondSha256(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringSha256Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }

    private static int TestSimilarGuidToHashFirstSha384(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringSha384Hash, (hash, len) => hash[..len]);
    }

    private static int TestSimilarGuidToHashSecondSha384(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringSha384Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }

    private static int TestSimilarGuidToHashFirstSha512(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringSha512Hash, (hash, len) => hash[..len]);
    }

    private static int TestSimilarGuidToHashSecondSha512(int take, int length)
    {
        return TestSimilarGuidToHash(take, length, HashAlgorithm.GetStringSha512Hash,
            (hash, len) => hash.Substring(Random.Shared.Next(0, hash.Length - len), len));
    }
}
