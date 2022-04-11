using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bolt.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Bolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekekController : ControllerBase
    {
        [HttpGet]

        public JsonResult Get()
        {
            List<Termekek> termekek = new List<Termekek>();
            using (var context = new boltContext())
            {
                try
                {
                    return new JsonResult(context.Termekeks.ToList());
                }
                catch (Exception ex)
                {
                    return new JsonResult(termekek);
                }
            }
            //return new JsonResult("");
        }

        [HttpPut]
        public JsonResult Put(Termekek egyTermek)
        {
            using (var context = new boltContext())
            {
                try
                {
                    context.Termekeks.Update(egyTermek);
                    context.SaveChanges();
                    return new JsonResult("A termék adatai sikeresen megváltoztatva.");
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]

        public JsonResult Post(Termekek egyTermek)
        {
            using (var context = new boltContext())
            {
                try
                {
                    context.Termekeks.Add(egyTermek);
                    context.SaveChanges();
                    return new JsonResult("Új termék felvétele sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            using (var context = new boltContext())
            {
                try
                {
                    Termekek termekek = new Termekek();
                    termekek.Id = id;
                    context.Termekeks.Remove(termekek);
                    context.SaveChanges();
                    return new JsonResult("A törlés sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }
    }
}
