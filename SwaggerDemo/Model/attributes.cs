using System.Runtime.Serialization;

namespace SwaggerDemo.Model
{
    public class attributes
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }
}
