using CommunityToolkit.Diagnostics;

namespace homework_1;

public struct History
{
    private int _id;
    private DateOnly _date;
    private int _sales;
    private int _stock;
    
    public History(int id, DateOnly date, int sales, int stock)
    {
        _id = id;
        _date = date;
        _sales = sales;
        _stock = stock;
    }

    public History(string inputCsvString)
    {
        Guard.IsNotNullOrWhiteSpace(inputCsvString);
        
        var parts = inputCsvString.Split(", ");
        
        Guard.HasSizeEqualTo(parts, 4);
        
        _id = int.Parse(parts[0]);
        _date = DateOnly.Parse(parts[1]);
        _sales = int.Parse(parts[2]);
        _stock = int.Parse(parts[3]);
    }
}