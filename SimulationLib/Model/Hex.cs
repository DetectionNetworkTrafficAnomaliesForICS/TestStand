namespace PlcLib.Model;

/// <summary>
/// Класс педоставляющий возможность хранения hex значений
/// </summary>
public class Hex
{
    public ushort[] Bytes { get; set; }
    public Hex(ushort[] bytes)
    {
        Bytes = bytes;
    }

    public override string ToString()
    {
        return "Value.ToString(\"X\");";
    }
}