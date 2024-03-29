﻿using TestStand.Lib.Converter.Interfaces;

namespace TestStand.Lib.Register.Interfaces;

public interface IRegister<T> : IConverter<T>
{
    RegisterConfiguration Configuration { get; init; }

    /// <summary>
    /// Адресс регистра
    /// </summary>
    ushort Address => Convert.ToUInt16(Configuration.Address, 16);

    /// <summary>
    /// Тип регистра 
    /// </summary>
    TypeRegister Type =>
        Configuration.Type switch
        {
            "Holding" => TypeRegister.Holding,
            "Coil" => TypeRegister.Coil,
            "Input" => TypeRegister.Input,
            "DiscreteInput" => TypeRegister.DiscreteInput,
            _ => Type
        };
}