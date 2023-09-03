using Core.Model;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System;

namespace Core.Helpers.Validation
{
    public class UserCreateValidator : AbstractValidator<User>
    {
        public UserCreateValidator()
        {

            RuleFor(user => user.FirstName).NotEmpty().MaximumLength(150).WithMessage("O campo Primeiro Nome é obrigatório e deve ter no máximo 50 caracteres.");
            RuleFor(user => user.LastName).NotEmpty().MaximumLength(150).WithMessage("O campo Sobrenome é obrigatório e deve ter no máximo 50 caracteres.");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("O campo Email é obrigatório e deve ser um endereço de email válido.");
            RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage("O campo Senha é obrigatório e deve ter pelo menos 6 caracteres.");
            RuleFor(user => user.Birthday).NotEmpty().WithMessage("O campo Data de Nascimento é obrigatório.");

        }
    }

    public class UserUpdateValidator : AbstractValidator<User>
    {
        public UserUpdateValidator()
        {

            RuleFor(user => user.FirstName).NotEmpty().MaximumLength(150).WithMessage("O campo Primeiro Nome é obrigatório e deve ter no máximo 50 caracteres.");
            RuleFor(user => user.LastName).NotEmpty().MaximumLength(150).WithMessage("O campo Sobrenome é obrigatório e deve ter no máximo 50 caracteres.");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("O campo Email é obrigatório e deve ser um endereço de email válido.");
            RuleFor(user => user.Birthday).NotEmpty().WithMessage("O campo Data de Nascimento é obrigatório.");

        }
    }

    public class ProjectCreateUpdateValidator : AbstractValidator<Project>
    {
        public ProjectCreateUpdateValidator()
        {
            RuleFor(x => x.CreateUserId).NotEmpty().WithMessage("CreateUserId é obrigatório.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Título é obrigatório.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição é obrigatória.");
            RuleFor(x => x.StartProjectDate).NotEmpty().WithMessage("Data de início do projeto é obrigatória.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status é obrigatório.");
        }
    }

}


