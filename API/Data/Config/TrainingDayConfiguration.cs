using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class TrainingDayConfiguration : IEntityTypeConfiguration<TrainingDay>
    {
        public void Configure(EntityTypeBuilder<TrainingDay> builder)
        {
            builder.HasMany(e => e.ExercisesPerTrainingDay)
           .WithOne(t => t.TrainingDay).HasForeignKey(x => x.TrainingDayId);
        }
    }
}