using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API
{
    public interface IExerciseRepo
    {
         Task<TrainingDay> getExerciseByTrainingDay(int id);
         Task<IReadOnlyList<TrainingDay>> getTrainingDaysAsync();
         Task<IReadOnlyList<ExercisePerTrainingDay>> getExercisesPerTrainingDay(int id);
         Task<IReadOnlyList<ExerciseDetails>> getAllExerciseDetailsForTestPurposes();



    }
}