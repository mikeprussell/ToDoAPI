using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoAPI.DATA.EF;//to connect in to the EF layer
using ToDoAPI.API.Models;//access to the DTO's
using System.Web.Http.Cors;

namespace ToDoAPI.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToDoController : ApiController
    {
        ToDoEntities db = new ToDoEntities();

        public IHttpActionResult GetToDos()
        {
            List<ToDoViewModel> todos = db.TodoItems.Include("Category").Select(t => new ToDoViewModel()
            {
                TodoId = t.TodoId,
                Action = t.Action,
                Done = t.Done,
                CategoryId = t.CategoryId,
                Category = new CategoryViewModel()
                {
                    CategoryId = t.CategoryId,
                    CategoryName = t.Category.Name,
                    CategoryDescription = t.Category.Description
                }
            }).ToList<ToDoViewModel>();

            if (todos.Count == 0)
            {
                return NotFound();
            }

            return Ok(todos);

        }//End GetToDos()

        public IHttpActionResult GetToDo(int id)
        {
            ToDoViewModel todo = db.TodoItems.Include("Category").Where(t => t.TodoId == id).Select(t => new ToDoViewModel()
            {
                TodoId = t.TodoId,
                Action = t.Action,
                Done = t.Done,
                CategoryId = t.CategoryId,
                Category = new CategoryViewModel()
                {
                    CategoryId = t.CategoryId,
                    CategoryName = t.Category.Name,
                    CategoryDescription = t.Category.Description
                }
            }).FirstOrDefault();

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);

        }//end GetToDo()

    }//End Class

}//End Namespace