namespace WebApiDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using WebApiDemo.Data;
    using WebApiDemo.Infrastructure;
    using WebApiDemo.Models;

    [RoutePrefix("api/notes")]
    public class NotesController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public NoteDto Get(int id)
        {
            using (var context = new NotesDatabaseContext(ConnectionStringProvider.EntityDatabaseConnectionString))
            {
                return context.Notes.Single(n => n.Id == id).Map<NoteDto>();
            }
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<NoteDto> GetAll()
        {
            using (var context = new NotesDatabaseContext(ConnectionStringProvider.EntityDatabaseConnectionString))
            {
                return context.Notes.ToList().Select(i => i.Map<NoteDto>()).ToList();
            }
        }

        [HttpPost]
        [Route("")]
        public void Post(NoteDto noteDto)
        {
            using (var context = new NotesDatabaseContext(ConnectionStringProvider.EntityDatabaseConnectionString))
            {
                var dataItem = noteDto.Map<Data.Models.Note>();

                context.Notes.Add(dataItem);
                context.SaveChanges();
            }
        }
    }
}