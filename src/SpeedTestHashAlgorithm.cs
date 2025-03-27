using System.Diagnostics;

namespace GuidToHashResearch;

public static class SpeedTestHashAlgorithm
{
    public static void RunHashSpeedTest()
    {
        HashAlgorithmSpeedTest("MD5", HashAlgorithm.GetStringMD5Hash);
        HashAlgorithmSpeedTest("Sha256", HashAlgorithm.GetStringSha256Hash);
        HashAlgorithmSpeedTest("Sha384", HashAlgorithm.GetStringSha384Hash);
        HashAlgorithmSpeedTest("Sha512", HashAlgorithm.GetStringSha512Hash);
    }

    private static void HashAlgorithmSpeedTest(string algorithm, Func<string, string> hashAlgorithm)
    {
        var guidCount = 10000000;
        
        var guidList = new string[guidCount];
        for (var i = 0; i < guidCount; i++)
        {
            guidList[i] = Guid.NewGuid().ToString("N");
        }

        var hashArray = new string[guidCount];
        
        var watch = Stopwatch.StartNew();
        for (int i = 0; i < guidCount; i++)
        {
            hashArray[i] = hashAlgorithm(guidList[i]);
        }
        watch.Stop();
        Console.WriteLine($"Затрачено времени на {guidCount} гуидов, алгоритмом {algorithm}: {watch.Elapsed}");
    }
}