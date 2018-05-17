using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class DirectionConfiguration : EntityTypeConfiguration<DirectionEntity>
    {
        public DirectionConfiguration()
        {
            ToTable("Direction");

            HasKey(x => x.Id);

            Property(x => x.DirectionName);
            Property(x => x.Street);
            Property(x => x.StreetId);
            Property(x => x.Distance);
            Property(x => x.Duration);
            Property(x => x.Speed);
            Property(x => x.Date);
            HasRequired(x => x.Owner);                        

        }
    }
}
