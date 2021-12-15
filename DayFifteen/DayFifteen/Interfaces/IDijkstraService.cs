namespace DayFifteen.Interfaces;

public interface IDijkstraService
{
    List<Node> GetNeighbours(Node currentNode, List<Node> allNodes);
    void ConsiderNode(Node currentNode, List<Node> neighbours);
}