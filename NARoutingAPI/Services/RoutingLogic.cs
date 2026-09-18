public class RoutingLogic
{
    public bool IsValidCountry(string countryCode)
    {
        return Map.Graph.ContainsKey(countryCode);
    }

    public List<string> BFSRoute(string destination)
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

        foreach (var neighbor in Map.Graph[country])
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