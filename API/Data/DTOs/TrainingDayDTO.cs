using System.Collections.Generic;
using API.Entities;

namespace API.Data.DTOs
{
    public class TrainingDayDTO
    {
        
        public string DateOfTraining {get;set;}
        // this need set
        public List<ExercisePerTrainingDay> ExercisesPerTrainingDayDTO {get;set;} = new List<ExercisePerTrainingDay>();

    }
}