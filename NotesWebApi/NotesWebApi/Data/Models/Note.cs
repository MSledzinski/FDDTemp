namespace WebApiDemo.Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}