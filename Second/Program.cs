
class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int r1 = input[0], s1 = input[1], r2 = input[2], s2 = input[3];

        List<string> grayPapers = new List<string>();
        for (int i = 0; i < r1 + s1; i++)
            grayPapers.Add(Console.ReadLine());

        List<string> whitePapers = new List<string>();
        for (int i = 0; i < r2 + s2; i++)
            whitePapers.Add(Console.ReadLine());

        double grayProbability = CalculateProbability(grayPapers, r1, s1);
        double whiteProbability = CalculateProbability(whitePapers, r2, s2);

        Console.WriteLine(Math.Max(grayProbability, whiteProbability).ToString("F2"));
    }

    static HashSet<string> Cards(string desc)
    {
        HashSet<string> cards = new HashSet<string>();
        string ranks = "23456789TJQKA";
        string suits = "CDHS";

        var rankChars = new HashSet<char>();
        var suitChars = new HashSet<char>();

        foreach (char c in desc)
        {
            if (ranks.Contains(c))
                rankChars.Add(c);
            else if (suits.Contains(c))
                suitChars.Add(c);
        }

        if (rankChars.Count == 0)
            rankChars = new HashSet<char>(ranks);

        if (suitChars.Count == 0)
            suitChars = new HashSet<char>(suits);

        foreach (char rank in rankChars)
        {
            foreach (char suit in suitChars)
            {
                cards.Add($"{rank}{suit}");
            }
        }

        return cards;
    }

    static double CalculateProbability(List<string> subsets, int r, int s)
    {
        var allCards = new HashSet<string>();
        foreach (char rank in "23456789TJQKA")
            foreach (char suit in "CDHS")
                allCards.Add($"{rank}{suit}");

        for (int i = 0; i < r; i++)
        {
            HashSet<string> cardsToRemove = Cards(subsets[i]);
            allCards.ExceptWith(cardsToRemove);
            if (allCards.Count == 0)
                return 0.0;
        }

        if (allCards.Count == 0)
            return 0.0;

        HashSet<string> winningCards = new HashSet<string>();
        for (int i = r; i < r + s; i++)
        {
            winningCards.UnionWith(Cards(subsets[i]));
        }

        int goodCards = allCards.Count(x => winningCards.Contains(x));

        return (double)goodCards / allCards.Count;
    }
}







