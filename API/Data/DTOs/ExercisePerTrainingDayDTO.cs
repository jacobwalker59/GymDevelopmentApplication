using System.Collections.Generic;
using API.Entities;

namespace API.Data.DTOs
{
    public class ExercisePerTrainingDayDTO
    {
        public string Name { get; set; }
        // one to many from Training Day to Exercise
        public List<ExerciseDetails> ExerciseDetails { get; set; } = new List<ExerciseDetails>();
    }
}