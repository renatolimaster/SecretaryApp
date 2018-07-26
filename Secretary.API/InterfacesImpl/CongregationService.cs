using System.Collections.Generic;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class CongregationService : ICongregation
    {
        private readonly ApplicationDbContext _dbContext;
        public CongregationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Congregacao> getAllCongregations()
        {
            throw new System.NotImplementedException();
        }

        /*
            public List<Congregacao> getAllCongregations()
            {
                List<Congregacao> cong = _dbContext.Congregacao.FindAsync();
                return cong;
            }
             */
    }
}