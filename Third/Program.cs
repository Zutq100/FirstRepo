
class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);

        int[] target = Console.ReadLine().Split().Select(int.Parse).ToArray();

        if (target.Any(c => c < 1 || c > M))
        {
            Console.WriteLine(-1);
            return;
        }

        var colorRanges = new Dictionary<int, (int first, int last)>();
        for (int i = 0; i < N; i++)
        {
            int color = target[i];
            colorRanges[color] = (target.ToList().IndexOf(color), target.ToList().LastIndexOf(color));
        }

        var operations = new List<(int color, int l, int r)>();
        int currentPos = 0;

        foreach (var colorInfo in colorRanges)
        {
            int color = colorInfo.Key;
            int first = colorInfo.Value.first;
            int last = colorInfo.Value.last;

            operations.Add((color, first + 1, last + 1));
            currentPos = last + 1;
        }

        if (currentPos > N)
        {
            Console.WriteLine(-1);
            return;
        }

        Console.WriteLine(operations.Count);
        foreach (var op in operations)
        {
            Console.WriteLine($"{op.color} {op.l} {op.r}");
        }
    }
}