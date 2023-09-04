using APIDtMoney.Context;
using APIDtMoney.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDtMoney.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApiDtMoneyContext _context;

        public TransactionsController(ApiDtMoneyContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            //AsNoTracking otimiza consulta GET - somente leitura 
            //Take() limita a consulta para o número especificado
            var transactions = _context.Transactions.AsNoTracking().Take(20).ToList();

            if (transactions is null)
            {
                return NotFound("Contas não encontradas...");
            }
            return transactions;
        }

        [HttpGet("{id:int}", Name = "GetBill")]
        public ActionResult<Transaction> Get(int id)
        {
            var bill = _context.Transactions.FirstOrDefault(p => p.Id == id);

            if (bill is null)
            {
                return NotFound("Conta não encontrada...");
            }

            return bill;
        }

        [HttpPost]
        public ActionResult Post(Transaction bill)
        {
            if (bill is null)
            {
                return BadRequest();
            }

            _context.Transactions.Add(bill);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetBill",
                new { id = bill.Id }, bill);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Transaction bill)
        {
            if (id != bill.Id)
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
            var bill = _context.Transactions.FirstOrDefault(p => p.Id == id);

            if (bill is null)
            {
                return NotFound("Conta não encontrada");
            }

            _context.Transactions.Remove(bill);
            _context.SaveChanges();

            return Ok(bill);
        }

    }
}
