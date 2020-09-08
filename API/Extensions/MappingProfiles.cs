using System.Linq;
using API.Data.DTOs;
using API.Entities;
using AutoMapper;

namespace API
{
    public  class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
           CreateMap<ExercisePerTrainingDay, ExercisePerTrainingDayDTO>();
           CreateMap<ExerciseDetails, ExerciseDetailsDTO>();
           
           CreateMap<TrainingDay, TrainingDayDTO>()
           .ForMember(x => x.ExercisesPerTrainingDayDTO, 
           o => o.MapFrom(x => x.ExercisesPerTrainingDay));
           
           /*

            
           CreateMap<TrainingDay, TrainingDayDTO>()
           .ForMember(d => d.ExercisesPerTrainingDayDTO, opt => opt.MapFrom(src => src.ExercisesPerTrainingDay
           .Select(x=>new ExercisePerTrainingDayDTO {Name=x.Name, ExerciseDetails = 
           
           new System.Collections.Generic.List<ExerciseDetails>{
            new ExerciseDetailsDTO {
                // wanted weight reps and set number in here....
            }
           }
           
           })));
            */
            // see if this works then do a second map within this child to get everything



           




        
        }

    }
}