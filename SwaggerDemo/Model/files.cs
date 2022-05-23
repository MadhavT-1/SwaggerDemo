using System.Runtime.Serialization;

namespace SwaggerDemo.Model
{
    public class files
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        public string filename { get; set; }
        public int fileSize { get; set; }
        public string mimeType { get; set; }
        public string hash { get; set; }

        public attributes attr { get; set; }
    }
}
