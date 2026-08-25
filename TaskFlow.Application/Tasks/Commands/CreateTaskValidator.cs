using FluentValidation;

namespace TaskFlow.Application.Tasks.Commands
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskValidator() 
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        }
    }
}
