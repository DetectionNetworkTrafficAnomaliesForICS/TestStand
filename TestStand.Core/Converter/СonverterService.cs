using System.Runtime.CompilerServices;
using TestStand.Lib.Converter.Interfaces;
using TestStand.Lib.Modbus.Interfaces;

namespace TestStand.Core.Converter;

public class СonverterService: IСonverterService
{
    private readonly IConverter<float> _converterFloat;

    public СonverterService(IConverter<float> converterFloat)
    {
        _converterFloat = converterFloat;
    }

    public IConverter<T>? GetConverter<T>()
    {
        if (typeof(T) == typeof(float))
        {
            return (IConverter<T>)_converterFloat;
        }
        return null;
    }
}