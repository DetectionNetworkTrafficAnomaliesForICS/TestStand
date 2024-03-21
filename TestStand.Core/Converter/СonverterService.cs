using System.Runtime.CompilerServices;
using TestStand.Lib.Converter.Interfaces;
using TestStand.Lib.Modbus.Interfaces;

namespace TestStand.Core.Converter;

public class СonverterService: IСonverterService
{
    private readonly IConverter<float> _converterFloat;
    private readonly IConverter<bool> _converterBool;

    public СonverterService(IConverter<float> converterFloat, IConverter<bool> converterBool)
    {
        _converterFloat = converterFloat;
        _converterBool = converterBool;
    }

    public IConverter<T>? GetConverter<T>()
    {
        if (typeof(T) == typeof(float))
        {
            return (IConverter<T>)_converterFloat;
        }
        if (typeof(T) == typeof(bool))
        {
            return (IConverter<T>)_converterBool;
        }
        return null;
    }
}