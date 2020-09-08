using System.Collections.Generic;
using System.Reflection;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data

{
    public class DataBaseContext:DbContext
    // dotnet ef database update!!!! to get it running
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options){}

        public DbSet<TrainingDay>  TrainingDay {get;set;}
        public DbSet<ExercisePerTrainingDay> ExercisePerTrainingDay {get;set;}
        public DbSet<ExerciseDetails> ExerciseDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        


    }
}