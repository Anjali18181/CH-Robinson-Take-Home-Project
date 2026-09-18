public static class TransitLogic
{
    public static bool IsValidCountry(string countryCode)
    {
        return NorthAmericaMap.Graph.ContainsKey(countryCode);
    }

    public static List<string> BFS(string destination)
    {
        var queue = new Queue<List<string>>();
        var visited = new HashSet<string>();

        queue.Enqueue(["USA"]);
        visited.Add("USA");

    while (queue.Count > 0)
    {
        var route = queue.Dequeue();
        var country = route[^1];

        if (country == destination)
        {
            return route;
        }

        foreach (var neighbor in NorthAmericaMap.Graph[country])
        {
            if (visited.Add(neighbor))
            {
                var newRoute = new List<string>(route)
                {
                    neighbor
                };

                queue.Enqueue(newRoute);
            }
        }
    }

    return [];
    }
}