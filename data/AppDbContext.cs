using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace Staj
{
    public class AppDbContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageReply>()
                .HasOne(p => p.message)
                .WithMany(t => t.messageReplies)
                .HasForeignKey(p => p.Id_MessageForward);


        }

       

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Participants> Participants { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<MessageReply> MessageReply { get;set;}

      
    }
}
