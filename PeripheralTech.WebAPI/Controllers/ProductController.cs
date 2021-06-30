using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI.Controllers
{
    public class ProductController : BaseCRUDController<Model.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest>
    {
        private static PeripheralTechDbContext _context;
        private static IMapper _mapper;
        private readonly IRecommendationService<Model.Product> _recommendationService;
        public ProductController(PeripheralTechDbContext context, IMapper mapper, IRecommendationService<Model.Product> recommendationService, ICRUDService<Model.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest> service) : base(service)
        {
            _context = context;
            _mapper = mapper;
            _recommendationService = recommendationService;
        }
        [HttpGet("RecommendedProducts/{ProductID}")]
        public List<Model.Product> RecommendedProcedures(int ProductID)
        {
            //keep in mind
            return _recommendationService.GetSimilarProducts(ProductID).Take(3).ToList();
        }
    }
}