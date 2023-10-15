using System;

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class HasSortingLayer : Attribute
{
    readonly string[] m_Names;
    public string[] Names => m_Names;
    public HasSortingLayer(params string[] _names) { m_Names = _names; }
}
