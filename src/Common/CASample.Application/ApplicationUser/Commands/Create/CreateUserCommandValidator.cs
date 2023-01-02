using System.Threading;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CASample.Application.ApplicationUser.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Cities.AllAsync(x => x.Name != name, cancellationToken);
        }
    }
}
