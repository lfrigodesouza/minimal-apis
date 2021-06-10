namespace MinimalApis.Data
{
    public class User
    {
        public User() { }
        public User(long id, string name, string surname, long document)
        {
            Id = id;
            Document = document;
            Name = name;
            SurName = surname;
        }

        public long Id { get; set; }
        public long Document { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
