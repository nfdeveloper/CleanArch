using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Id inválido.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Nome da Categoria tem que ser maior que 3 caracteres.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Nome da Categoria é obrigatório.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Nome da Categoria é obrigatório.");
        }
    }
}