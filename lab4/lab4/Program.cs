using lab4;

string path = "../../../graph.txt";
Graph graph = new(path);

if(graph.BFS("5"))
{
    Console.WriteLine("Found");
}
else
{
    Console.WriteLine("Not found");
}
if (graph.DFS("5"))
{
    Console.WriteLine("Found");
}
else
{
    Console.WriteLine("Not found");
}