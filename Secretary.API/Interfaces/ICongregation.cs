using System.Collections.Generic;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface ICongregation
    {
         List<Congregacao> getAllCongregations();
    }
}