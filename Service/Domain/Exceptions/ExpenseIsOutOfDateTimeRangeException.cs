namespace PersonalFinanceManagement.Domain.Exceptions
{
    public class ExpenseIsOutOfDateTimeRangeException : BaseDomainException
    {
        public ExpenseIsOutOfDateTimeRangeException()
        {

        }
        
        public ExpenseIsOutOfDateTimeRangeException(string error) => this.Error = error;

    }
}