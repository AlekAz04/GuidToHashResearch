namespace GuidToHashResearch;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Рандомные Guid");
        RandomGuidToHashTest.RunRandomGuid();
            
        Console.WriteLine("GUid'ы Которые отличаются друг от друга по 1 символ ");
        SimilarGuidToHashTest.RunSimilarGuid();
        
        Console.WriteLine("Тест скорости хэширования на 10 миллионов гуидов");
        SpeedTestHashAlgorithm.RunHashSpeedTest();
    }
}