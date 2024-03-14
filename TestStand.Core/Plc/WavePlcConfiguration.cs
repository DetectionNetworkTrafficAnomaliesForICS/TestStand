namespace TestStand.Core.Plc;

/// <summary>
/// Конфигурация PLC <see cref="WavePlc"/> class.
/// </summary>
public class WavePlcConfiguration
{
    /// <summary>
    /// Угловая скорость волны
    /// </summary>
    public required float AngularVelocity { get; init; }

    /// <summary>
    /// Амплитуда волны
    /// </summary>
    public required float Amplitude { get; init; }
}