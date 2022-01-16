using Api.DataProtection.Encryption;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace Api.DataProtection
{
    public class DataProtectionConverter : ValueConverter<string, string>
    {
        static readonly Expression<Func<string, string>> _encrypt = (data) => AesProvider.EncryptAes(data);
        static readonly Expression<Func<string, string>> _decrypt = (data) => AesProvider.DecryptAes(data);

        public DataProtectionConverter() : base(_encrypt, _decrypt, default) { }
    }
}
