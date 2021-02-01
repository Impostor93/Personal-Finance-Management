using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceManagement.Application.Common;
using PersonalFinanceManagement.Extensions;

namespace PersonalFinanceManagement
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";

        private IMediator mediator;

        protected IMediator Mediator
        {
            get
            {
                if (ReferenceEquals(this.mediator, null))
                {
                    this.mediator = (IMediator)this.HttpContext.RequestServices.GetService(typeof(IMediator));
                }

                return this.mediator;
            }
        }

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult> Send(IRequest<Result> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
            => this.Mediator.Send(request).ToActionResult();
    }
}