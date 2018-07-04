namespace Frameworks.Entities
{
    public class Framework
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProgrammingLanguageId { get; set; }

        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
