using Financeiro.Domain.Validation;

namespace Financeiro.Domain.Entities
{
    public sealed class Person : Entity
    {
        public string Name { get; private set; }
        public decimal Income { get; private set; }
        public ICollection<Bank> Banks { get; private set; }
        public Person(string name, decimal income)
        {
            Validate(name, income);
        }
        public Person(int id, string name, decimal income)
        {
            DomainException.When(id < 0,
                "O id não pode ser menor que zero");
            Id = id;
            Validate(name, income);
        }

        public void Validate(string name, decimal income)
        {
            DomainException.When(string.IsNullOrEmpty(name),
                "O nome precisa ser preenchido.");

            DomainException.When(name.Length < 3,
                "O nome não pode conter menos que 3 caracteres");
            
            DomainException.When(name.Length > 100,
                "O nome não pode conter mais que 100 caracteres");
            
            DomainException.When(income <= 0,
                "O salário precisa ser um valor positivo maior que zero.");
            
            Name = name;
            Income = income;
        }
    }
}