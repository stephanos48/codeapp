using codeapp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace codeapp.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base 
        (options) {}

        public DbSet<Value> Values { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerDivision> CustomerDivisions { get; set; }

        public DbSet<Scrum> Scrums { get; set; }

        public DbSet<Responsible> Responsibles { get; set; } 

        public DbSet<Ncr> Ncrs { get; set; }

        public DbSet<Disposition> Dispositions { get; set; }

        public DbSet<NcrStatus> NcrStatuses { get; set; }

        public DbSet<NcrType> NcrTypes { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Audit> Audits { get; set; }

        public DbSet<AuditType> AuditTypes { get; set; }

        public DbSet<Finding> Findings { get; set; }

        public DbSet<FindingType> FindingTypes { get; set; }

        public DbSet<PhotoAudit> PhotoAudits { get; set; }

        public DbSet<ScrumStatus> ScrumStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();                    
            });

            builder.Entity<Like>()
                .HasKey(k => new { k.LikerId, k.LikeeId} );

            builder.Entity<Like>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Likers)
                .HasForeignKey(u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likees)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(u => u.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(u => u.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Audit>()
                .HasMany(a => a.Findings)
                .WithOne(f => f.Audit)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

           /* builder.Entity<Scrum>()
                .HasOne<Responsible>(g => g.CurrentResponsible)
                .WithOne(b => b.Scrum)
                .HasForeignKey<Scrum>(b => b.CurrentResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);
            */
            builder.Entity<Photo>().HasQueryFilter(p => p.IsApproved); 

            builder.Entity<PhotoAudit>().HasQueryFilter(p => p.IsApproved);   
        }
    }
}