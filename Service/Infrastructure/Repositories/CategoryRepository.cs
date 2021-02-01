namespace PersonalFinanceManagement.Infrastructure.Repositories
{
    using System.Linq;
    using Domain.Repositories;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Infrastructure.Database;

    public class CategoryRepository : RepositoryBase<Category, CategoryId>, ICategoryRepository
    {
        public CategoryRepository(PersonalFinanceManagementContext context)
            :base(context)
        {
        }
    }
}