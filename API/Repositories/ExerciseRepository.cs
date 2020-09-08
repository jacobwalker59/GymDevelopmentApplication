using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ExerciseRepository : IExerciseRepo
    {
        private readonly DataBaseContext _db;

        public ExerciseRepository(DataBaseContext db)
        {
            _db = db;
        }
        public Task<IReadOnlyList<ExerciseDetails>> getAllExerciseDetailsForTestPurposes()
        {
            throw new System.NotImplementedException();
        }

        public Task<TrainingDay> getExerciseByTrainingDay(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<ExercisePerTrainingDay>> getExercisesPerTrainingDay(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<TrainingDay>> getTrainingDaysAsync()
        {
             var trainingDays = await _db.TrainingDay.ToListAsync();

             return trainingDays;
        }
    }
}