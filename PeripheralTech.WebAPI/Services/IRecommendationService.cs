using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public interface IRecommendationService<T> where T : class
    {
        List<T> GetSimilarProducts(int id);
    }
}
