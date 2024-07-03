
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Models
{
    public class BulletinBoardContext
    {
        public class TodoContext : DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<BulletinBoardContext> Board { get; set; } = null!;
        }
    }
}
