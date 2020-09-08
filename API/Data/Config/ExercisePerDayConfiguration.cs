using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class ExercisePerDayConfiguration : IEntityTypeConfiguration<ExercisePerTrainingDay>
    {
        public void Configure(EntityTypeBuilder<ExercisePerTrainingDay> builder)
        {
            builder.HasOne(t => t.TrainingDay)
           .WithMany(e => e.ExercisesPerTrainingDay).HasForeignKey(x => x.TrainingDayId);

            builder.HasMany(ex => ex.ExerciseDetails)
          .WithOne(e => e.ExercisePerTrainingDay).HasForeignKey(x => x.ExercisePerTrainingDayId);
        }
    }
}