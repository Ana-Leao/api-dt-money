using APIDtMoney.Context;
using APIDtMoney.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDtMoney.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly ApiDtMoneyContext _context;

        public BillsController(ApiDtMoneyContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Bill>> Get()
        {
            //AsNoTracking otimiza consulta GET - somente leitura 
            //Take() limita a consulta para o número especificado
            var bills = _context.Bills.AsNoTracking().Take(20).ToList();

            if (bills is null)
            {
                return NotFound("Contas não encontradas...");
            }
            return bills;
        }

        [HttpGet("{id:int}", Name = "GetBill")]
        public ActionResult<Bill> Get(int id)
        {
            var bill = _context.Bills.FirstOrDefault(p => p.BillId == id);

            if (bill is null)
            {
                return NotFound("Conta não encontrada...");
            }

            return bill;
        }

        [HttpPost]
        public ActionResult Post(Bill bill)
        {
            if (bill is null)
            {
                return BadRequest();
            }

            _context.Bills.Add(bill);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetBill",
                new { id = bill.BillId }, bill);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Bill bill)
        {
            if (id != bill.BillId)
            {
                return BadRequest("ID não corresponde!");
            }

            _context.Entry(bill).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(bill);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var bill = _context.Bills.FirstOrDefault(p => p.BillId == id);

            if (bill is null)
            {
                return NotFound("Conta não encontrada");
            }

            _context.Bills.Remove(bill);
            _context.SaveChanges();

            return Ok(bill);
        }

    }
}
