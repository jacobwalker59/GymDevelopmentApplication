using System;
using System.Linq.Expressions;
using API.Entities;

namespace API.Data.Specifications
{
    public class GetExerciseSpecification : BaseSpecification<TrainingDay>
    {
        public GetExerciseSpecification(int id) : base(x => x.Id == id)
        {
          //  AddInclude(x => x.ExercisesPerTrainingDay);
        }

        public GetExerciseSpecification()
        {
           // AddInclude(x => x.ExercisesPerTrainingDay);
            AddInclude("ExercisesPerTrainingDay");

            AddInclude("ExercisesPerTrainingDay.ExerciseDetails");

        
            //  AddInclude($"{nameof(User.Recipes)}.{nameof(Recipe.Ingredients)}");
            // could have a second one as per before with using a select statement
        }
    }
}