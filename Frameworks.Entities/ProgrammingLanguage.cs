using System.Collections.Generic;

namespace Frameworks.Entities
{
    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            Frameworks = new List<Framework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Framework> Frameworks { get; set; }
    }
}
