using System.Collections;

namespace DayFourteen.Interfaces;

public interface IPolimerInsertionService
{
    string InsertPolimer(string template, Hashtable rules);
    string InsertPolimerReverse(string template, Hashtable rules);
}