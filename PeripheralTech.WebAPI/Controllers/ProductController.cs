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
    //public class ProductController : BaseCRUDController<Model.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private static PeripheralTechDbContext _context;
        //private static IMapper _mapper;
        private readonly IRecommendationService<Model.Product> _recommendationService;
        private readonly IProductService _service;
        public ProductController(IProductService service, IRecommendationService<Model.Product> recommendationService)
        {
            //_context = context;
            //_mapper = mapper;
            _service = service;
            _recommendationService = recommendationService;
        }
        [HttpGet]
        public List<Model.Product> Get([FromQuery]ProductSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Product GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet("RecommendedProducts/{ProductID}")]
        public List<Model.Product> RecommendedProcedures(int ProductID)
        {
            //keep in mind
            return _recommendationService.GetSimilarProducts(ProductID).Take(3).ToList();
        }
        [HttpGet("GetRecentProducts")]
        public List<Model.Product> GetRecentProducts([FromQuery]ProductSearchRequest request)
        {
            return _service.GetRecentProducts(request);
        }
        [HttpGet("GetDiscountedProducts")]
        public List<Model.Product> GetDiscountedProducts([FromQuery]ProductSearchRequest request)
        {
            return _service.GetDiscountedProducts(request);
        }
        [HttpGet("GetProductsForCustomOrder")]
        public List<Model.Product> GetProductsForCustomOrder([FromQuery]ProductSearchRequest request)
        {
            return _service.GetProductsForCustomOrder(request);
        }
        [HttpPost]
        public Model.Product Insert(ProductUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.Product Update(int id, [FromBody]ProductUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}