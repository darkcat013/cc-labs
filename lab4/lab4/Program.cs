using lab4;

string toFind = "150";

string path1 = "../../../graph1.txt";
string timePath1 = "../../../time1.txt";
string outputPath1 = "../../../output1.txt";
string findPath1 = "../../../find1.txt";
Graph graph = new(path1, timePath1, outputPath1);

graph.BFS(0.ToString());

for (int i = 1; i <= 151; i += 10)
{
    File.AppendAllText(findPath1, i.ToString()+"\n");
    if (graph.BFS(i.ToString()))
    {
        Console.WriteLine("Found");
    }
    else
    {
        Console.WriteLine("Not found");
    }
}
File.AppendAllText(timePath1, "\n");
File.AppendAllText(outputPath1, "\n");
for (int i = 1; i <= 151; i += 10)
{
    if (graph.DFS(i.ToString()))
    {
        Console.WriteLine("Found");
    }
    else
    {
        Console.WriteLine("Not found");
    }
}
string path2 = "../../../graph2.txt";
string timePath2 = "../../../time2.txt";
string outputPath2 = "../../../output2.txt";
graph = new(path2, timePath2, outputPath2);

for (int i = 1; i <= 151; i += 10)
{
    if (graph.BFS(i.ToString()))
    {
        Console.WriteLine("Found");
    }
    else
    {
        Console.WriteLine("Not found");
    }
}
File.AppendAllText(timePath2, "\n");
File.AppendAllText(outputPath2, "\n");
for (int i = 1; i <= 151; i += 10)
{
    if (graph.DFS(i.ToString()))
    {
        Console.WriteLine("Found");
    }
    else
    {
        Console.WriteLine("Not found");
    }
}

//Random rand = new();

//for (int i = 0; i <= 150; i++)
//{
//    List<string> list = new();
//    int a = 61 - rand.Next( 55,62);
//    list.Add($"{i} {i + 1}");

//    for (int j = 0; j < a; j++)
//    {
//        int next = rand.Next(151);
//        while (i == next) next = rand.Next(151);
//        string s = $"{i} {next}";
//        if (!list.Contains(s)) list.Add(s);
//    }
//File.AppendAllLines(path2, list);
//}