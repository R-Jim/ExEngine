using System;

class RawValueMapper
{
    public static object GetValue(string value)
    {
        try
        {
            return int.Parse(value);
        }
        catch (FormatException)
        {
            try
            {
                return float.Parse(value);
            }
            catch (FormatException)
            {
                try
                {
                    return bool.Parse(value);
                }
                catch (FormatException)
                {
                    return value;
                }
            }
        }
    }

}
