using System;

namespace Api.DataProtection
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class SensitiveDataAttribute : Attribute { }
}
