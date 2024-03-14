namespace TestStand.Core.Cycle;


/// <summary>
/// Конфигурация сервиса тактирования <see cref="CycleService"/> class.
/// </summary>
public class CycleConfiguration
{
    /// <summary>
    /// Длина одного такта в милисекундах 
    /// </summary>
    public required long Duration { get; init; }
}