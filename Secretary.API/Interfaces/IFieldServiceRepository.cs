using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IFieldServiceRepository
    {
        Task<List<ServicoCampo>> getAllFieldServicesAsync();
        Task<ServicoCampo> getFieldServiceAsync(long id);
        Task<ServicoCampo> getSingleOrDefaultAsync(long id);
        Task<ServicoCampo> getSCSingleOrDefaultAsync(long id);
        Task<string> initializeFieldService(DateTime deliveryDate);
        bool VerifyExistFieldServiceByPublisher(DateTime deliveryDate, long publisherId);
        Task<List<ServicoCampo>> getFieldServiceByPeriodAsync(DateTime fromDate, DateTime toDate);
        Task<ServicoCampo> getFieldServiceByPublisherIdAsync(long publisherId);

        Task<double> getMediaYearlyFieldServiceAsync(long id);
        Task<double> getMediaQuarterlyFieldServiceSAsync(long id);
        Task<double> getMediaSemesterFieldServiceAsync(long id);
        Task<double> getMediaFieldServiceAsync(long publisherId, int months);
        Task<bool> SaveAllAsync();
    }
}