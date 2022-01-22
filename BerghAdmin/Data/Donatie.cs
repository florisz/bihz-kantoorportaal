
namespace BerghAdmin.Data;

#pragma warning disable IDE0060 // Remove unused parameter
public class Donatie
{
    public Donatie()
    {
    }

    public int Id { get; set; } = 0;
    public decimal Bedrag { get; set; }
    public Donateur? Donateur { get; set; }
    public Factuur? Factuur { get; set; }
}

#pragma warning restore IDE0060 // Remove unused parameter
