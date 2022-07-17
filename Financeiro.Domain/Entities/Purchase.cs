using Financeiro.Domain.Validation;

namespace Financeiro.Domain.Entities
{
    public sealed class Purchase : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Installments { get; private set; }
        public Card Card { get; private set; }
        public int CardId { get; set; }
        
        public Purchase(string name, string description, decimal price, int installments)
        {
            Validate(name, description, price, installments);
        }

        public Purchase(int id, string name, string description, decimal price, int installments)
        {
            DomainException.When(id < 0,
                "O id não pode ser menor que zero");
            Id = id;
            Validate(name, description, price, installments);
        }

        public void Validate(string name, string description, decimal price, int installments)
        {
            DomainException.When(string.IsNullOrEmpty(name),
                "O nome precisa ser preenchido.");

            DomainException.When(name.Length < 3,
                "O nome não pode conter menos que 3 caracteres");
            
            DomainException.When(name.Length > 50,
                "O nome não pode conter mais que 50 caracteres");

            DomainException.When(description.Length > 100,
                "A descrição não pode conter mais de 100 caracteres");
        
            DomainException.When(price <= 0,
                "O preço precisa ser maior que zero");
            
            Name = Name;
            Description = description;
            Price = price;
            Installments = installments;
        }
    }
}