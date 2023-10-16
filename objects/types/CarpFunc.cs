﻿namespace Carp.objects.types;

public abstract class CarpFunc : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpFunc>("func");
    public override CarpType GetCarpType() => Type.With(this._returnType);
    
    protected CarpType _returnType;

    protected CarpFunc(CarpType returnType)
    {
        this._returnType = returnType;
    }
    
    public override abstract CarpObject Call(CarpObject[] args);

    public override CarpString String() 
        => new($"func<{this._returnType.String().Native}>");
}