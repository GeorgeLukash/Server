using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel.Exercises;
using FitnessTracker.DataModel.Plan;
using FitnessTracker.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Enums;
using FitnessTracker.DataModel.Direction;

namespace FitnessTracker.Operations.Implementation
{
    public class DirectionOperations:IDirectionOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public DirectionOperations(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public int CreateDirection(CreateDirectionModel model, int currUserId)
        {
            var user = _unitOfWork.Repository<UserEntity>().GetById(currUserId);

            var entityToInsert = new DirectionEntity
            {
                Distance = model.Distance,
                Date=model.Date,
                Street = model.Street,
                StreetId = model.StreetId,
                DirectionName = model.DirectionName,
                Owner = user,
                Duration = model.Duration,                
                Speed = model.Speed                            
            };

            _unitOfWork.Repository<DirectionEntity>().Insert(entityToInsert);
            _unitOfWork.SaveChanges();

            return entityToInsert.Id;
        }

        public ICollection<MyDirectionModel> GetDirections(int currUserId)
        {
            return _unitOfWork.Repository<DirectionEntity>()
                .Include(x => x.Owner)
                .Where(x => x.Owner.Id == currUserId)
                .Select(x => new MyDirectionModel
                {
                    Id = x.Id,
                    Distance = x.Distance,
                    Date = x.Date,
                    Street = x.Street,
                    StreetId = x.StreetId,
                    DirectionName = x.DirectionName,
                    Duration = x.Duration,
                    UserId = x.Owner.Id,
                    UserFirstName = x.Owner.Firstname,
                    UserLastName = x.Owner.Lastname,
                    Speed = x.Speed
                }).ToList();
        }

        public ICollection<MyDirectionModel> GetAllDirections(int currUserId)
        {
            return _unitOfWork.Repository<DirectionEntity>()
                .Include(x => x.Owner)
                .Where(x => x.Owner.Id != currUserId)
                .Select(x => new MyDirectionModel
                {
                    Id = x.Id,
                    Distance = x.Distance,
                    Date = x.Date,
                    Street = x.Street,
                    StreetId = x.StreetId,
                    DirectionName = x.DirectionName,
                    Duration = x.Duration,
                    UserId = x.Owner.Id,
                    UserFirstName = x.Owner.Firstname,
                    UserLastName = x.Owner.Lastname,
                    Speed = x.Speed
                }).ToList();
        }

        public void DeleteDirection(int dirId, int currUserId)
        {
            var direction = _unitOfWork.Repository<DirectionEntity>().Include(x => x.Owner)
                .FirstOrDefault(x => x.Owner.Id == currUserId && x.Id == dirId);

            _unitOfWork.Repository<DirectionEntity>().Delete(direction);
            _unitOfWork.SaveChanges();
        }

        public void UpdateDirection(UpdateDirectionModel model, int currUserId)
        {
            var direction = _unitOfWork.Repository<DirectionEntity>().GetById(model.Id);

            if (direction != null)
            {
                direction.DirectionName = model.DirectionName;
                direction.Speed = model.Speed;
                direction.Duration = model.Duration;
                direction.Distance = model.Distance;
                direction.Street = model.Street;
                direction.StreetId = model.StreetId;
                _unitOfWork.SaveChanges();
            }
        }
    }
}
