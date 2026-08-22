namespace LeetCode;

public class Graph
{
    private IList<int[]>[] Nodes { get; }

    public Graph(int n, int[][] edges)
    {
        Nodes = new IList<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            Nodes[i] = [];
        }

        foreach (int[] edge in edges)
        {
            AddEdgeCore(edge);
        }
    }

    private void AddEdgeCore(int[] edge)
    {
        int x = edge[0];
        int y = edge[1];
        int cost = edge[2];
        Nodes[x].Add([y, cost]);
    }

    public void AddEdge(int[] edge)
    {
        AddEdgeCore(edge);
    }

    public int ShortestPath(int node1, int node2)
    {
        var pq = new PriorityQueue<int[], int>();
        int[] distances = new int[Nodes.Length];
        Array.Fill(distances, int.MaxValue);
        distances[node1] = 0;
        pq.Enqueue([0, node1], 0);

        while (pq.Count > 0)
        {
            int[] arr = pq.Dequeue();
            int cost = arr[0], currentNode = arr[1];
            if (currentNode == node2)
            {
                return cost;
            }

            foreach (int[] nextArr in Nodes[currentNode])
            {
                int next = nextArr[0], nextCost = nextArr[1];
                int currentCost = cost + nextCost;
                if (distances[next] > currentCost)
                {
                    distances[next] = currentCost;
                    pq.Enqueue([currentCost, next], currentCost);
                }
            }
        }
        return -1;
    }
}
