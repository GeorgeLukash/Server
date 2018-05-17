using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Filters;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Collections.Generic;
using System.Web.Http;
using FitnessTracker.DataModel.Direction;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("user")]
    public class DirectionController : ApiControllerBase
    {
        private readonly IDirectionOperations _directionOperations;

        public DirectionController(IDirectionOperations dirOper, ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
            _directionOperations = dirOper;
        }

        [Route("direction")]
        [AuthorizeIfTokenValid]
        [HttpPost]
        public IHttpActionResult AddDirection(CreateDirectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _directionOperations.CreateDirection(model, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("directions")]
        [AuthorizeIfTokenValid]
        [HttpGet]
        public IHttpActionResult GetDirections()
        {
            try
            {
                return Ok(_directionOperations.GetDirections(_currentUserProvider.CurrentUserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("alldirections")]
        [AuthorizeIfTokenValid]
        [HttpGet]
        public IHttpActionResult GetAllDirections()
        {
            try
            {
                return Ok(_directionOperations.GetAllDirections(_currentUserProvider.CurrentUserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("deletdirection/{id:int}")]
        [AuthorizeIfTokenValid]
        [HttpDelete]
        public IHttpActionResult DeleteDirection(int id)
        {
            try
            {
                _directionOperations.DeleteDirection(id, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("updatedirection")]
        [AuthorizeIfTokenValid]
        [HttpPost]
        public IHttpActionResult UpdateDirection(UpdateDirectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _directionOperations.UpdateDirection(model, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
