using System;
using System.Linq;
using API.Entities;

namespace API.Data
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabaseSeed(DataBaseContext database)
        {
            if(!database.TrainingDay.Any())
            {
                var TrainingDayList = new TrainingDay[]
                {
                    new TrainingDay {DateOfTraining = DateTime.Now}
                };

                foreach(TrainingDay i in TrainingDayList)
                {
                    database.TrainingDay.Add(i);
                }
                database.SaveChanges();
            }
            if(!database.ExercisePerTrainingDay.Any())
            {
                var ExercisePerTrainingDayList = new ExercisePerTrainingDay[]{
                    new ExercisePerTrainingDay {Name = "Squat", TrainingDayId =1}
                    
                };

                foreach(ExercisePerTrainingDay i in ExercisePerTrainingDayList)
                {
                    database.ExercisePerTrainingDay.Add(i);
                }
                database.SaveChanges();
            }

            if(!database.ExerciseDetail.Any())
            {
                var ExerciseDetails = new ExerciseDetails[]{
                    new ExerciseDetails {Weight=20, Reps =5, SetNumber = 1,ExercisePerTrainingDayId =1 }
                };

                foreach(ExerciseDetails i in ExerciseDetails)
                {
                    database.ExerciseDetail.Add(i);
                }
                database.SaveChanges();
            }

            

            else{
                
                //then give each exercise their details according to whether it is squat deadlift or bench

                return;

            }
        }
    }
}