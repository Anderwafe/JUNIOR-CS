using CommunityToolkit.Diagnostics;

namespace homework_1;

public class Economics
{
    private IEnumerable<History> _salesHistory;
    
    public Economics(History[] salesHistory)
    {
        _salesHistory = salesHistory.Clone() switch
        {
            null => [],
            History[] value => value,
            _ => ThrowHelper.ThrowArgumentException<History[]>(nameof(salesHistory), "Invalid value"),
        };
    }

    public Economics(StreamReader salesHistoryStream)
    {
        List<History> salesHistoryBuffer = new List<History>();
        for (string line = string.Empty; !salesHistoryStream.EndOfStream; line = salesHistoryStream.ReadLine()!)
        {
            salesHistoryBuffer.Add(new History(line));
        }
    }
    
    public decimal ADS()
    {
        
    }
}