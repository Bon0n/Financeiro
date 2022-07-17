using Financeiro.Domain.Validation;

namespace Financeiro.Domain.Entities
{
    public sealed class Card : Entity
    {
        public string Name { get; private set; }
        public int Number { get; private set; }
        public int Limit { get; private set; }
        public Bank Bank { get; set; }
        public int BankId { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }

        public Card(string name, int number, int limit)
        {
            Validate(name, number, limit);
        }

        public Card(int id, string name, int number, int limit)
        {
            DomainException.When(id < 0,
                "O id não pode ser menor que zero");
            Id = id;
            Validate(name, number, limit);
        }
        public void Validate(string name, int number, int limit)
        {
            DomainException.When(string.IsNullOrEmpty(name),
                "O nome precisa ser preenchido.");

            DomainException.When(name.Length < 3,
                "O nome não pode conter menos que 3 caracteres");
            
            DomainException.When(name.Length > 50,
                "O nome não pode conter mais que 50 caracteres");
        
            DomainException.When(number != 16,
                "O número do cartão é inválido");

            DomainException.When(limit <= 0,
                "O valor do limite precisa ser maior que zero");
            
            Name = name;
            Number = number;
            Limit = limit;
        }
    }
}