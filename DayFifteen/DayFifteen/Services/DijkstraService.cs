namespace DayFifteen.Services;

public class DijkstraService : IDijkstraService
{
    public void ConsiderNode(Node currentNode, List<Node> neighbours)
    {
        foreach (var neighbour in neighbours)
        {
            var calculatedDistance = currentNode.Distance + neighbour.RiskFactor; 
            if (calculatedDistance < neighbour.Distance)
            {
                neighbour.Distance = calculatedDistance;
            }
        }

        currentNode.Visited = true;
    }

    public List<Node> GetNeighbours(Node currentNode, List<Node> allNodes)
    {
        var neighbours = new List<Node>();
        neighbours.Add(allNodes.SingleOrDefault(x => x.X == currentNode.X + 1 && x.Y == currentNode.Y));
        neighbours.Add(allNodes.SingleOrDefault(x => x.X == currentNode.X - 1 && x.Y == currentNode.Y));
        neighbours.Add(allNodes.SingleOrDefault(x => x.X == currentNode.X && x.Y == currentNode.Y+1));
        neighbours.Add(allNodes.SingleOrDefault(x => x.X == currentNode.X && x.Y == currentNode.Y-1));
        return neighbours.Where(x => x != null).ToList();
    }
}