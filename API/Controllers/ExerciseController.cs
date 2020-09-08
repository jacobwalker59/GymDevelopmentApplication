using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Interfaces;
using API.Data.Specifications;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ExerciseController:BaseAPIController
    {
        private readonly IGenericRepo<TrainingDay> _trainingDayRepo;
        private readonly IMapper _mapper;

        public ExerciseController(IGenericRepo<TrainingDay> trainingDayRepo, IMapper mapper)
        {
            _trainingDayRepo = trainingDayRepo;
            _mapper = mapper;
        }

        [HttpGet("PracticeForTrainingDay")]
        public async Task<ActionResult<TrainingDay>> getTrainingDayProto()
        {
            TrainingDay trainingDay = await _trainingDayRepo.GetByIdAsync(1);
          //  trainingDay = trainingDay;
          //  var trainingDayFlattened = trainingDay.
            return trainingDay;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDayDTO>> getTrainingInfo(int id)
        {
            var spec = new GetExerciseSpecification(id);
            var trainingDay = await _trainingDayRepo.GetEntityWithSpec(spec);
            if(trainingDay == null)return NotFound();
            var changedTrainingDay = _mapper.Map<TrainingDay, TrainingDayDTO>(trainingDay);
            return Ok(changedTrainingDay);
        }

        [HttpGet("AllTrainingDays")]
        public async Task<ActionResult<IReadOnlyList<TrainingDayDTO>>> getEveryTrainingDay()
        {
            var spec = new GetExerciseSpecification();
            var trainingDays = await _trainingDayRepo.ListOnlyAsync(spec);
            if(trainingDays == null){
            return NotFound();
            }
        
           var changedTrainingDay = _mapper.Map<IReadOnlyList<TrainingDay>, IReadOnlyList<TrainingDayDTO>>(trainingDays);
           return Ok(changedTrainingDay);
        }


    }
}