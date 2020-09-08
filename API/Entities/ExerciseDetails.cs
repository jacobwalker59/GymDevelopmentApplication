using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class ExerciseDetails
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int SetNumber { get; set; }
        public ExercisePerTrainingDay ExercisePerTrainingDay { get; set; }
        public int ExercisePerTrainingDayId { get;set; }

    }
}