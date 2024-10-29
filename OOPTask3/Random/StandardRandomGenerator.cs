namespace OOPTask3.Random;

public sealed class StandardRandomGenerator : IRandomGenerator
{
    private readonly System.Random _random;

    public StandardRandomGenerator()
    {
        _random = new();
    }

    public StandardRandomGenerator(int seed)
    {
        _random = new(seed);
    }

    public int GetNextRandomInt(int minInclusiveValue, int maxExclusiveValue)
    {
        var randomElement = _random.Next(minInclusiveValue, maxExclusiveValue);
        return randomElement;
    }
}