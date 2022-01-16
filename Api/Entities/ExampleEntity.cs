using Api.DataProtection;

namespace Api.Entities
{
    public class ExampleEntity
    {
        public int Id { get; set; }

        [SensitiveData]
        public string SensitiveInfo { get; set; }
    }
}
