using System.Collections.Generic;

namespace API.Entities
{
    public class ExercisePerTrainingDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrainingDay TrainingDay { get; set;}
        public int TrainingDayId {get;set;}
        // one to many from Training Day to Exercise
        public List<ExerciseDetails> ExerciseDetails { get; set; }
        
        // this should have a dictionary of exercise details, which are then stored in a list.

        
    }
}