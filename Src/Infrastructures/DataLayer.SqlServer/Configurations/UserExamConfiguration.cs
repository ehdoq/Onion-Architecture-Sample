using Domain.UserExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.SqlServer.Configurations
{
    public class UserExamConfiguration : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}