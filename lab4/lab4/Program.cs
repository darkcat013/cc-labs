using lab4;

string path = "../../../graph1.txt";
Graph graph = new(path);

graph.BFS(0.ToString());

if(graph.BFS("13"))
{
    Console.WriteLine("Found");
}
else
{
    Console.WriteLine("Not found");
}
if (graph.DFS("13"))
{
    Console.WriteLine("Found");
}
else
{
    Console.WriteLine("Not found");
}