using System;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Diagnostics;

namespace homework_1;

public struct Ratio : IParsable<Ratio>
{
    private int _id;
    private int _month;
    private float _coef;

    public int Id => _id;
    public int Month => _month;
    public float Coef => _coef;

    public Ratio(int id, int month, float coef)
    {
        _id = id;

        Guard.IsBetween<int>(month, 0, 13);
        _month = month;

        Guard.IsGreaterThanOrEqualTo<float>(coef, 0);
        _coef = coef;
    }

    public static Ratio Parse(string s, IFormatProvider? provider)
    {
        Guard.IsNotNullOrWhiteSpace(s);
        
        var parts = s.Split(", ");
        
        Guard.HasSizeEqualTo(parts, 3);
        
        var _id = int.Parse(parts[0]);
        var _month = int.Parse(parts[1]);

        var _coef = MathF.Round(float.Parse(parts[2]), 4, MidpointRounding.AwayFromZero);
        
        return new Ratio(_id, _month, _coef);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Ratio result)
    {
        try
        {
            Guard.IsNotNullOrWhiteSpace(s);
        
            var parts = s.Split(", ");
            
            Guard.HasSizeEqualTo(parts, 3);
            
            var _id = int.Parse(parts[0]);
            var _month = int.Parse(parts[1]);

            var _coef = MathF.Round(float.Parse(parts[2]), 4, MidpointRounding.AwayFromZero);
            
            result = new Ratio(_id, _month, _coef);
        }
        catch
        {
            result = default;
            return false;
        }
        return true;
    }
}
