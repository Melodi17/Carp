using Carp.objects.types;

namespace Carp.package.packages.standard;

public class MathPackage(IPackageResolver source) : EmbeddedPackage(source, "Math")
{
    /// <summary>
    /// Generates a random integer within the specified range.
    /// </summary>
    /// <param name="min">The lower bound of the random number to be generated.</param>
    /// <param name="max">The upper bound of the random number to be generated.</param>
    /// <returns>A random integer within the specified range.</returns>
    [PackageMember]
    public CarpInt Random(CarpInt min, CarpInt max) => new(new Random().Next(min.NativeInt, max.NativeInt));

    /// <summary>
    /// Determines if a random event occurs based on the specified chance.
    /// </summary>
    /// <param name="chance">The chance of the event occurring, expressed as an integer between 0 and 100.</param>
    /// <returns>A boolean indicating whether the event occurred.</returns>
    [PackageMember]
    public CarpBool Chance(CarpInt chance) => new CarpInt(new Random().Next(0, 100)).Greater(chance);

    /// <summary>
    /// Pauses the execution of the current thread for the specified amount of time.
    /// </summary>
    /// <param name="ms">The amount of time to pause execution, in milliseconds.</param>
    [PackageMember]
    public void Wait(CarpInt ms) => Thread.Sleep(ms.NativeInt);

    /// <summary>
    /// Returns the absolute value of the specified number.
    /// </summary>
    /// <param name="num">The number to find the absolute value of.</param>
    /// <returns>The absolute value of the specified number.</returns>
    [PackageMember]
    public CarpInt Abs(CarpInt num) => new(Math.Abs(num.Native));

    /// <summary>
    /// Rounds the specified number up to the nearest integer.
    /// </summary>
    /// <param name="num">The number to round up.</param>
    /// <returns>The specified number rounded up to the nearest integer.</returns>
    [PackageMember]
    public CarpInt Ceil(CarpInt num) => new(Math.Ceiling(num.Native));

    /// <summary>
    /// Rounds the specified number down to the nearest integer.
    /// </summary>
    /// <param name="num">The number to round down.</param>
    /// <returns>The specified number rounded down to the nearest integer.</returns>
    [PackageMember]
    public CarpInt Floor(CarpInt num) => new(Math.Floor(num.Native));

    /// <summary>
    /// Rounds the specified number to the nearest integer.
    /// </summary>
    /// <param name="num">The number to round.</param>
    /// <returns>The specified number rounded to the nearest integer.</returns>
    [PackageMember]
    public CarpInt Round(CarpInt num) => new(Math.Round(num.Native));

    /// <summary>
    /// Returns the larger of two specified numbers.
    /// </summary>
    /// <param name="a">The first number to compare.</param>
    /// <param name="b">The second number to compare.</param>
    /// <returns>The larger of the two numbers.</returns>
    [PackageMember]
    public CarpInt Max(CarpInt a, CarpInt b) => new(Math.Max(a.Native, b.Native));

    /// <summary>
    /// Returns the smaller of two specified numbers.
    /// </summary>
    /// <param name="a">The first number to compare.</param>
    /// <param name="b">The second number to compare.</param>
    /// <returns>The smaller of the two numbers.</returns>
    [PackageMember]
    public CarpInt Min(CarpInt a, CarpInt b) => new(Math.Min(a.Native, b.Native));

    /// <summary>
    /// Clamps a number to a specified range.
    /// </summary>
    /// <param name="num">The number to clamp.</param>
    /// <param name="min">The lower bound of the range.</param>
    /// <param name="max">The upper bound of the range.</param>
    /// <returns>The clamped number.</returns>
    [PackageMember]
    public CarpInt Clamp(CarpInt num, CarpInt min, CarpInt max) =>
        new(Math.Clamp(num.Native, min.Native, max.Native));

    /// <summary>
    /// Calculates the square root of a specified number.
    /// </summary>
    /// <param name="num">The number to find the square root of.</param>
    /// <returns>The square root of the specified number.</returns>
    [PackageMember]
    public CarpInt Sqrt(CarpInt num) => new((int)Math.Sqrt(num.Native));

    /// <summary>
    /// Raises a specified number to the power of another specified number.
    /// </summary>
    /// <param name="num">The base number.</param>
    /// <param name="pow">The exponent.</param>
    /// <returns>The result of raising the base to the power of the exponent.</returns>
    [PackageMember]
    public CarpInt Pow(CarpInt num, CarpInt pow) => new((int)Math.Pow(num.Native, pow.Native));
}