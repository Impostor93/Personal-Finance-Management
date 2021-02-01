namespace PersonalFinanceManagement.Application.Commands
{
    using MediatR;
    using PersonalFinanceManagement.Application.Common;

    public class CreateNewCategoryCommand : IRequest<Result>
    {
        public CreateNewCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}