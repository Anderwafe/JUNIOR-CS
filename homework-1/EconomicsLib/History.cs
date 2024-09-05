using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Diagnostics;

namespace homework_1;

public struct History : IParsable<History>
{
    // ?: Delete ID's from history and ratio structs and use dictionaries with id's as keys in economics class.
    private int _id;
    private DateTime _date;
    private int _sales;
    private int _stock;

    public int Id => _id;
    public DateTime Date => _date;
    public int Sales => _sales;
    public int Stock => _stock;
    
    public History(int id, DateTime date, int sales, int stock)
    {
        _id = id;
        _date = date;

        Guard.IsGreaterThanOrEqualTo<int>(sales, 0);
        _sales = sales;

        Guard.IsGreaterThanOrEqualTo<int>(stock, 0);
        _stock = stock;

        Guard.IsGreaterThanOrEqualTo<int>(_stock, _sales);
    }

    public static History Parse(string s, IFormatProvider? provider)
    {
        Guard.IsNotNullOrWhiteSpace(s);
        
        var parts = s.Split(", ");
        
        Guard.HasSizeEqualTo(parts, 4);
        
        var _id = int.Parse(parts[0]);
        var _date = DateOnly.Parse(parts[1]);
        var _sales = int.Parse(parts[2]);
        
        var _stock = int.Parse(parts[3]);

        return new History(_id, _date.ToDateTime(new TimeOnly()), _sales, _stock);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out History result)
    {
        try
        {
            Guard.IsNotNullOrWhiteSpace(s);
            
            var parts = s.Split(", ");
            
            Guard.HasSizeEqualTo(parts, 4);
            
            var _id = int.Parse(parts[0]);
            var _date = DateOnly.Parse(parts[1]);
            var _sales = int.Parse(parts[2]);
            
            var _stock = int.Parse(parts[3]);

            result = new History(_id, _date.ToDateTime(new TimeOnly()), _sales, _stock);
        }
        catch
        {
            result = default;
            return false;
        }
        return true;
    }
}