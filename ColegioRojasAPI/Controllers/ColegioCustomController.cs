using ColegioRojasAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColegioRojasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegioCustomController : ControllerBase
    {

        private readonly ColegioContext _context;

        public ColegioCustomController(ColegioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(Colegio colegio)
        {
            colegio.IsActive = true;
            _context.Colegios.Add(colegio);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int Id)
        {

            //Busco
            var colegio = _context.Colegios.Where(x => x.IsActive == true && x.ColegioID == Id).FirstOrDefault();
            //Preparo para modificarse

            colegio.IsActive = false;
            _context.Entry(colegio).State = EntityState.Modified;

            //Commit
            _context.SaveChanges();

        }

        [HttpGet]
        public List<Colegio> Get()
        {
            //Expresiones lambda
            var response = _context.Colegios.Where(x => x.IsActive == true).ToList();
            return response;

        }


        [HttpPut]

        public void Update(Colegio request)
        {
            var colegio = _context.Colegios.Find(request.ColegioID);

            colegio.Name = request.Name;
            colegio.Aulas = request.Aulas;

            _context.Entry(colegio).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
