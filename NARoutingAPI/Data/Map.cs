public static class Map
{
    public static Dictionary<string, string[]> Graph = new Dictionary<string, string[]>
    {
        ["CAN"] = ["USA"],
            ["USA"] = ["CAN", "MEX"],
            ["MEX"] = ["USA", "GTM", "BLZ"],
            ["BLZ"] = ["MEX", "GTM"],
            ["GTM"] = ["MEX", "BLZ", "SLV", "HND"],
            ["SLV"] = ["GTM", "HND"],
            ["HND"] = ["GTM", "SLV", "NIC"],
            ["NIC"] = ["HND", "CRI"],
            ["CRI"] = ["NIC", "PAN"],
            ["PAN"] = ["CRI"]
    };
}