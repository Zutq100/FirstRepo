class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int N = int.Parse(firstLine[0]), M = int.Parse(firstLine[1]);

        int[] houses = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] heaters = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Array.Sort(houses);
        Array.Sort(heaters);

        int maxDistance = 0;

        foreach (int house in houses)
        {
            int left = 0;
            int right = heaters.Length - 1;
            int closest = int.MaxValue;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                closest = Math.Min(closest, Math.Abs(heaters[mid] - house));

                if (heaters[mid] < house)
                {
                    left = mid + 1;
                }
                else if (heaters[mid] > house)
                {
                    right = mid - 1;
                }
                else
                {
                    closest = 0;
                    break;
                }
            }

            maxDistance = Math.Max(maxDistance, closest);
        }

        Console.WriteLine(maxDistance);
    }
}


