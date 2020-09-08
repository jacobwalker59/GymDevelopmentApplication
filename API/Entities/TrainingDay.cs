using System;
using System.Collections.Generic;


namespace API.Entities
{
    public class TrainingDay
    {
        // training day has many exercises
        // training day has a list of many training details.
        // training details ... have to discern whether it is many to many for now
        
        public int Id { get; set; }
        public DateTime DateOfTraining {get;set;}
         public List<ExercisePerTrainingDay> ExercisesPerTrainingDay {get;set;}
    }
}