using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Data.Interfaces;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class SecondExerciseRepository : ISecondExerciseRepo
    {
        private readonly DataBaseContext _db;
        public SecondExerciseRepository(DataBaseContext db)
        {
            _db = db;

        }
        public async Task<TrainingDay> getSingleTrainingDayById(int id)
        {
            // eager loading
            var trainingDay =  await _db.TrainingDay.Include(x => x.ExercisesPerTrainingDay)
            .ThenInclude(x => x.ExerciseDetails).FirstOrDefaultAsync(x => x.Id == id);
            return trainingDay;
            
        }

        public async Task<IReadOnlyList<TrainingDay>> getTrainingDaysAsync()
        {
            var trainingDay =  await _db.TrainingDay.Include(x => x.ExercisesPerTrainingDay)
            .ThenInclude(x => x.ExerciseDetails).ToListAsync();
            return trainingDay;
        }
    }
}