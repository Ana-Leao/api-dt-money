using APIDtMoney.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDtMoney.Context;

public class ApiDtMoneyContext : DbContext
{
    public ApiDtMoneyContext(DbContextOptions<ApiDtMoneyContext> options) : base(options)
    {}

    public DbSet<Transaction> Transactions { get; set; }
}
