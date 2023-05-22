namespace Lab4;

public class CommStruct
{
    private int[,] roads;
    public int Size => roads.GetLength(0);

    public CommStruct(int[,] roads)
    {
        this.roads = roads;
        if (roads.GetLength(0) != roads.GetLength(1))
            throw new Exception("Initialization error");
        if(Enumerable.Range(0, roads.GetLength(0)).Any(i => roads[i, i] != 0))
            throw new Exception("Initialization error");
    }

    public int Resolve()
    {
        int minPathLen = Int32.MaxValue;
        int[] pathPoints = new int[Size];
        int[] pathMin = new int[Size];
        foreach (var path in Helper.Permute(Enumerable.Range(0, Size).ToArray()))
        {
            var pathLen = 0;
            var prev = path.First();
            pathPoints[0] = prev;
            int i = 1;
            foreach (var town in path.Skip(1))
            {
                pathLen += roads[prev, town];
                pathPoints[i++] = town;
                prev = town;
            }

            if (pathLen < minPathLen)
            {
                minPathLen = pathLen;
                pathMin = pathPoints;
            }
        }

        Console.WriteLine(string.Join("->", pathMin));
        return minPathLen;
    }
}