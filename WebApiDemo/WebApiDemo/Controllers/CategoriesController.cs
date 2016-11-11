namespace WebApiDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using WebApiDemo.Data;
    using WebApiDemo.Infrastructure;
    using WebApiDemo.Models;

    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryDto> GetAll()
        {
            using (var context = new NotesDatabaseContext(ConnectionStringProvider.EntityDatabaseConnectionString))
            {
                return context.Categories.ToList().Select(i => i.Map<CategoryDto>()).ToList();
            }
        }
    }
}