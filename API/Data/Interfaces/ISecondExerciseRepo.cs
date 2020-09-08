using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data.Interfaces
{
    public interface ISecondExerciseRepo
    {
         Task<TrainingDay> getSingleTrainingDayById(int id);
         Task<IReadOnlyList<TrainingDay>> getTrainingDaysAsync();
    }
}