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
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solução");
            }
        }

        [HttpGet("{id:int}", Name = "GetBill")]
        public ActionResult<Transaction> Get(int id)
        {
            try
            {
                var bill = _context.Transactions.FirstOrDefault(p => p.Id == id);

                if (bill is null)
                {
                    return NotFound($"Transação '{id}' não encontrada...");
                }

                return bill;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solução");
            }
        }

        [HttpPost]
        public ActionResult Post(Transaction bill)
        {
            try
            {
                if (bill is null)
                {
                    return BadRequest("Dados inválidos.");
                }

                _context.Transactions.Add(bill);
                _context.SaveChanges();

                return new CreatedAtRouteResult("GetBill",
                    new { id = bill.Id }, bill);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solução");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Transaction bill)
        {
            try
            {
                if (id != bill.Id)
                {
                    return BadRequest("ID não corresponde!");
                }

                _context.Entry(bill).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(bill);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solução");
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solução");
            }
        }

    }
}
