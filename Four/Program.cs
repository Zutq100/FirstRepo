string[] firstLine = Console.ReadLine().Split();
int N = int.Parse(firstLine[0]);
int M = int.Parse(firstLine[1]);
long K = long.Parse(firstLine[2]);

List<Tuple<int, int, long>> corridors = new List<Tuple<int, int, long>>();
for (int i = 0; i < M; i++)
{
    string[] corridorData = Console.ReadLine().Split();
    int u = int.Parse(corridorData[0]);
    int v = int.Parse(corridorData[1]);
    long s = long.Parse(corridorData[2]);
    corridors.Add(Tuple.Create(u, v, s));
}
