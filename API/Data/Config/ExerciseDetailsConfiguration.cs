using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class ExerciseDetailsConfiguration : IEntityTypeConfiguration<ExerciseDetails>
    {
        public void Configure(EntityTypeBuilder<ExerciseDetails> builder)
        {
            builder.HasOne(ex => ex.ExercisePerTrainingDay)
            .WithMany(ex => ex.ExerciseDetails).HasForeignKey(x => x.ExercisePerTrainingDayId);
        }
    }
}