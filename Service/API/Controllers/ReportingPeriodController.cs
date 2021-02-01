namespace PersonalFinanceManagement.Controllers
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PersonalFinanceManagement.Application.Commands;

    [Route("ReportingPeriod")]
    public class ReportingPeriodController : ApiController
    {
        private readonly ILogger<ReportingPeriodController> logger;
        private readonly IMediator mediator;

        public ReportingPeriodController(ILogger<ReportingPeriodController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("StartPeriod")]
        public async Task<IActionResult> StartPeriod(StartNewReportingPeriodCommand command)
            => await this.Send(command);

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateNewCategoryCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route("AddExpense")]
        public async Task<IActionResult> AddExpense(AddNewExpenseCommand command)
            => await this.Send(command);
    }
}