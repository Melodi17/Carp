using Carp.objects.types;

namespace Carp.package.packages.standard;

public class MathPackage(IPackageResolver source) : EmbeddedPackage(source, "Math")
{
    [PackageMember]
    public CarpInt Random(CarpInt min, CarpInt max) => new(new Random().Next(min.NativeInt, max.NativeInt));

    [PackageMember]
    public CarpBool Chance(CarpInt chance) => new CarpInt(new Random().Next(0, 100)).Greater(chance);

    [PackageMember]
    public void Wait(CarpInt ms) => Thread.Sleep(ms.NativeInt);

    [PackageMember]
    public CarpInt Abs(CarpInt num) => new(Math.Abs(num.Native));

    [PackageMember]
    public CarpInt Ceil(CarpInt num) => new(Math.Ceiling(num.Native));

    [PackageMember]
    public CarpInt Floor(CarpInt num) => new(Math.Floor(num.Native));

    [PackageMember]
    public CarpInt Round(CarpInt num) => new(Math.Round(num.Native));

    [PackageMember]
    public CarpInt Max(CarpInt a, CarpInt b) => new(Math.Max(a.Native, b.Native));

    [PackageMember]
    public CarpInt Min(CarpInt a, CarpInt b) => new(Math.Min(a.Native, b.Native));

    [PackageMember]
    public CarpInt Clamp(CarpInt num, CarpInt min, CarpInt max) =>
        new(Math.Clamp(num.Native, min.Native, max.Native));

    [PackageMember]
    public CarpInt Sqrt(CarpInt num) => new((int)Math.Sqrt(num.Native));

    [PackageMember]
    public CarpInt Pow(CarpInt num, CarpInt pow) => new((int)Math.Pow(num.Native, pow.Native));
}