using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using API.Entities;
using Microsoft.AspNetCore.Hosting;

namespace API.Data
{
    public static class JsonDBInitializer
    {
        
        public static void SeedDbWithJsonData(DataBaseContext db)
        {
            /*
           var path = File.ReadAllText("../API/wwwroot/AppDataFile/TrainingDay.json");
            // first get the path name
           List<TrainingDay> jsonTrainingDay = JsonSerializer.Deserialize<List<TrainingDay>>(path);
            // convert the path name to json
            foreach(TrainingDay t in jsonTrainingDay)
            {
                db.Add(t);

            }
            db.SaveChanges();
            */
            
            /*
            var path = File.ReadAllText("../API/wwwroot/AppDataFile/ExercisePerTrainingDay.json");
            // first get the path name
           List<ExercisePerTrainingDay> jsonExercisePerTrainingDay = JsonSerializer.Deserialize<List<ExercisePerTrainingDay>>(path);
            // convert the path name to json
            foreach(ExercisePerTrainingDay t in jsonExercisePerTrainingDay)
            {
                db.Add(t);

            }
            db.SaveChanges();
            */

            var path = File.ReadAllText("../API/wwwroot/AppDataFile/ExerciseDetails.json");
            // first get the path name
           List<ExerciseDetails> jsonExerciseDetails = JsonSerializer.Deserialize<List<ExerciseDetails>>(path);
            // convert the path name to json
            foreach(ExerciseDetails t in jsonExerciseDetails)
            {
                db.Add(t);

            }
            db.SaveChanges();







            
        }
    }
}