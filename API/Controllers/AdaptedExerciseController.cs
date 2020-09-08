using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdaptedExerciseController : BaseAPIController
    {
        private readonly ISecondExerciseRepo _repo;
        private readonly IMapper _mapper;
        public AdaptedExerciseController(ISecondExerciseRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("exercise")]
        public async Task<ActionResult<TrainingDayDTO>> getTrainingDayById()
        {
            var trainingDay = await _repo.getSingleTrainingDayById(1);
            var data = _mapper.Map<TrainingDay,TrainingDayDTO>(trainingDay);
            return Ok(data);
        }

        [HttpGet("trainingDay")]
        public async Task<ActionResult<TrainingDayDTO>> getTrainingDays()
        {
            var trainingDay = await _repo.getTrainingDaysAsync();
            var data = _mapper.Map<IReadOnlyList<TrainingDay>,IReadOnlyList<TrainingDayDTO>>(trainingDay);
            return Ok(data);
        }
    }
}