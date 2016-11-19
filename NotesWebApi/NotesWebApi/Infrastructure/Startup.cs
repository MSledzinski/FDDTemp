namespace WebApiDemo.Infrastructure
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;

    using Owin;

    using WebApiDemo.Infrastructure.Mappings;

    public class Startup
    {
        public void Configuration(IAppBuilder applicationBuilder)
        {
            AutoMapper.Mapper.Initialize(m => m.AddProfile(new ModelsProfile()));

            HttpConfiguration configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.Services.Replace(typeof(IExceptionHandler), new DetailToResponseAppendingExceptionHandler());
            
            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter());
            configuration.EnsureInitialized();

            applicationBuilder.UseWebApi(configuration);
        }
    }

    public class DetailToResponseAppendingExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "ISE: " + context.Exception.ToString()
            };
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}