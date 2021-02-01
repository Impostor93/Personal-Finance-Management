namespace Application.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using PersonalFinanceManagement.Application.Commands;
    using PersonalFinanceManagement.Application.Common;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Infrastructure.Repositories;

    public class CategoryCommandHandler :
        IRequestHandler<CreateNewCategoryCommand, Result>
    {
        private readonly IUnitOfWork unitOfWork;
        
        public CategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken)
        {
            using(unitOfWork)
            {
                var newCategory = new Category(request.Name);
                await unitOfWork.CategoryRepository.StoreAsync(newCategory);

                await unitOfWork.CommitAsync(cancellationToken);

                return Result.Success;
            }
        }
    }
}