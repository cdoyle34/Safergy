namespace SafErgyReal.Models
{
    public class ClarifaiApiResponse
    {
        public List<Output> Outputs { get; set; } = new List<Output>();
    }

    public class Output
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<Concept> Concepts { get; set; } = new List<Concept>();
    }

    public class Concept
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}


