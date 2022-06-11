using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepository;
        public RideRepository()
        {
            rideRepository = new Dictionary<string, List<Ride>>();
        }
        ///<summary>
        ///Adds to ride repository.
        ///</summary>
        ///<param name="userId">The user identifier.</param>
        ///<param name="ride"> The ride.</param>
        public void AddRideRespository(string userId, Ride ride)
        {
            if (rideRepository.ContainsKey(userId))
            {
                rideRepository[userId].Add(ride);
            }
            else
            {
                rideRepository.Add(userId, new List<Ride>());
                rideRepository[userId].Add(ride);
            }
        }
        ///<summary>
        ///Returns the List by user Identifier.
        ///</summary>
        ///<param name="userId">The user identifier</param>
        public List<Ride> returnListByUserId(string userId)
        {
            if (rideRepository.ContainsKey(userId))
            {
                return rideRepository[userId];
            }
            else
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_USER_ID, "Invalid userId");
        }
    }
}
