using Financeiro.Domain.Validation;

namespace Financeiro.Domain.Entities
{
    public sealed class Bank : Entity
    {
        public string Name { get; private set; }
        public IEnumerable<Card> Cards { get; private set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }

        public Bank(string name)
        {
            Validate(name);
        }
        public Bank(int id, string name)
        {
            DomainException.When(id < 0,
                "O id não pode ser menor que zero");
            Id = id;
            Validate(name);
        }

        public void Validate(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name),
                "O nome precisa ser preenchido.");

            DomainException.When(name.Length < 3,
                "O nome não pode conter menos que 3 caracteres");
            
            DomainException.When(name.Length > 50,
                "O nome não pode conter mais que 50 caracteres");
            
            Name = name;
        }
    }
}