using MultiProjectSolutions.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiProjectSolution.BL
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IDbRepository _dbRepository;
        public BusinessLogic(IDbRepository dbRepository)
        {
        
        }
    }
}
