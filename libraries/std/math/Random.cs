namespace Carp.libraries.std.math;

using exceptions.impl;
using objects;
using utils;
using utils.attributes;

[Doc("Exposes random number generation functionality.")]
public class Random
{
    private readonly int _seed;
    private static readonly Random _global = new(Environment.TickCount / 81);
    private readonly System.Random _random;
    public Random(int seed)
    {
        this._seed = seed;
        this._random = new System.Random(seed);
    }
    public static Random Global => Random._global;
    
    [Doc("Returns a fractional random number between 0 and 1.")]
    public double Fractional()
    {
        return this._random.NextDouble();
    }
    
    [Doc("Returns a random boolean.")]
    public bool Chance()
    {
        return this._random.Next(2) == 0;
    }
    
    [Doc("Returns a random boolean, with a given chance of being true.")]
    public bool Chance(double chance)
    {
        if (chance < 0 || chance > 1)
            throw new IllegalArgumentsException("Chance must be between 0 and 1.");
        
        return this.Fractional() < chance;
    }
    
    [Doc("Randomly chooses an item from the given collection.")]
    public object Choice(IEnumerable<object> items)
    {
        IEnumerable<object> itemsEnumerated = items as object[] ?? items.ToArray();
        
        if (items == null || !itemsEnumerated.Any())
            throw new IllegalArgumentsException("Cannot choose from an empty collection.");
        
        int index = this._random.Next(itemsEnumerated.Count());
        return itemsEnumerated.ElementAt(index);
    }

    [Doc("Randomly picks a number between the given start and end values.")]
    public CarpNumber Range(CarpRange range)
    {
        if (range.GetCarpType().TypeArguments[0].Group != CarpNumber.Group) 
            throw new IllegalArgumentsException("Range must be of number type.");
        
        if (range.End == null)
            throw new IllegalArgumentsException("Range must have an end value.");
        
        double start = range.Start != null ? ((CarpNumber) range.Start).ValueAsFraction : 0;
        double end = ((CarpNumber) range.End).ValueAsFraction;
        
        if (start >= end)
            throw new IllegalArgumentsException("Range start must be less than end.");
        
        if (Math.Floor(start) == start &&
            Math.Floor(end) == end)
        {
            return CarpNumber.Create(this._random.Next((int) Math.Floor(start), (int) Math.Ceiling(end)));
        }
        else return CarpNumber.Create(this.Fractional() * (end - start) + start);
    }

    public override string ToString() => 
        $"Random(seed: {this._seed})";
}