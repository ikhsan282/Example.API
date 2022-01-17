using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.API.Utilities
{
    public abstract class BaseController : ControllerBase
    {
        public abstract Task<ActionResult> getAllData();

        public abstract Task<ActionResult> getDataById(Guid id);

        public abstract Task<ActionResult> postData(object request);

        public abstract Task<ActionResult> putData(Guid id, object request);

        public abstract Task<ActionResult> deleteData(Guid id);
    }
}