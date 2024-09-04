using CommunityToolkit.Diagnostics;

namespace homework_1;

public class Economics
{
    private IEnumerable<History> _salesHistory;
    private IEnumerable<Ratio> _ratios;
    
    public Economics(History[] salesHistory, Ratio[] ratios)
    {
        _salesHistory = salesHistory.Clone() switch
        {
            null => [],
            History[] value => value,
            _ => ThrowHelper.ThrowArgumentException<History[]>(nameof(salesHistory), "Invalid value"),
        };

        _ratios = ratios.Clone() switch
        {
            null => [],
            Ratio[] value => value,
            _ => ThrowHelper.ThrowArgumentException<Ratio[]>(nameof(ratios), "Invalid value"),
        };
    }

    public Economics(StreamReader salesHistoryStream, StreamReader ratiosStream)
    {
        List<History> salesHistoryBuffer = new List<History>();
        for (string line = string.Empty; !salesHistoryStream.EndOfStream; line = salesHistoryStream.ReadLine()!)
        {
            salesHistoryBuffer.Add(History.Parse(line, null));
        }

        List<Ratio> ratiosBuffer = new List<Ratio>();
        for (string line = string.Empty; !ratiosStream.EndOfStream; line = ratiosStream.ReadLine()!)
        {
            ratiosBuffer.Add(Ratio.Parse(line, null));
        }

        _salesHistory = salesHistoryBuffer;
        _ratios = ratiosBuffer;
    }
    
    public float ADS()
    {
        throw new NotImplementedException();
    }

    public int Prediction()
    {
        throw new NotImplementedException();
    }

    public float Demand()
    {
        throw new NotImplementedException();
    }
}