namespace TestStand.Abstractions.Net.Interfaces;


public interface INetService
{
   public INetConfiguration NetConfiguration { get; }

   public byte[] Send(byte[] request);
}