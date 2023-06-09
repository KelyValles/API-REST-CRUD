namespace API.Models
{
    
        public class CarSettings : ICarSettings
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public string Collection { get; set; }
        }

        public interface ICarSettings
        {
            string Server { get; set; }
            string Database { get; set; }
            string Collection { get; set; }
        }
    
}

