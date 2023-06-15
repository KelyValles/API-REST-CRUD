namespace API.Models
{

    public class Settings : ISettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public CollectionSettings Collection { get; set; }
    }

    public class CollectionSettings
    {
        public string Car { get; set; }
        public string Categories { get; set; }
    }

    public interface ISettings
    {
        string Server { get; set; }
        string Database { get; set; }
        CollectionSettings Collection { get; set; }
    }

}

