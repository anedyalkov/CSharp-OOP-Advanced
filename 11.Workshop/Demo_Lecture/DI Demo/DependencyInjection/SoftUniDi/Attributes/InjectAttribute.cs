namespace SoftUniDi.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}
