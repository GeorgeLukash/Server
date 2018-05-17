using FitnessTracker.DataModel.Direction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IDirectionOperations
    {
        ICollection<MyDirectionModel> GetDirections(int currUserId);
        ICollection<MyDirectionModel> GetAllDirections(int currUserId);
        int CreateDirection(CreateDirectionModel model, int currUserId);
        void DeleteDirection(int dirId, int currUserId);
        void UpdateDirection(UpdateDirectionModel model, int currUserId);
    }    
}
