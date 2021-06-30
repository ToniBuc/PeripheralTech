using AutoMapper;
using PeripheralTech.Model;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class RecommendationService : IRecommendationService<Model.Product>
    {
        private readonly PeripheralTechDbContext _context;
        private readonly IMapper _mapper;
        Dictionary<int, List<Database.UserReview>> productDictionary = new Dictionary<int, List<Database.UserReview>>();
        public RecommendationService(PeripheralTechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Product> GetSimilarProducts(int ProductID)
        {
            LoadProducts(ProductID);
            List<Database.UserReview> subjectProductRatings = _context.UserReview.Where(x => x.ProductID == ProductID).OrderBy(x => x.UserID).ToList();

            List<Database.UserReview> sharedReviews1 = new List<Database.UserReview>();
            List<Database.UserReview> sharedReviews2 = new List<Database.UserReview>();
            List<Model.Product> recommendedProducts = new List<Model.Product>();

            foreach (var x in productDictionary)
            {
                foreach (Database.UserReview y in subjectProductRatings)
                {
                    if (x.Value.Where(i => i.UserID == y.UserID).Count() > 0)
                    {
                        sharedReviews1.Add(y);
                        sharedReviews2.Add(x.Value.Where(i => i.UserID == y.UserID).First());
                    }
                }
                double similarity = GetSimilarity(sharedReviews1, sharedReviews2);
                if (similarity > 0.5)
                {
                    //keep in mind
                    var result = _mapper.Map<Model.Product>(_context.Product.Find(x.Key));
                    recommendedProducts.Add(result);
                }
                sharedReviews1.Clear();
                sharedReviews2.Clear();
            }

            foreach(var x in recommendedProducts)
            {
                x.ProductNamePrice = x.ProductNamePrice = x.Name + " - " + x.Price.ToString();
            }

            return recommendedProducts;
        }

        private double GetSimilarity(List<Database.UserReview> sharedReviews1, List<Database.UserReview> sharedReviews2)
        {
            if (sharedReviews1.Count != sharedReviews2.Count)
            {
                return 0;
            }
            double numerator = 0;
            double denominator1 = 0;
            double denominator2 = 0;

            for (int i = 0; i < sharedReviews1.Count; i++)
            {
                numerator += Convert.ToInt32(sharedReviews1[i].Grade) * Convert.ToInt32(sharedReviews2[i].Grade);
                denominator1 += Convert.ToInt32(sharedReviews1[i].Grade) * Convert.ToInt32(sharedReviews1[i].Grade);
                denominator2 += Convert.ToInt32(sharedReviews2[i].Grade) * Convert.ToInt32(sharedReviews2[i].Grade);
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double denominator = denominator1 * denominator2;
            if (denominator == 0)
            {
                return 0;
            }
            double similarityValue = numerator / denominator;
            return similarityValue;
        }

        private void LoadProducts(int productID)
        {
            List<Database.Product> products = _context.Product.Where(x => x.ProductID != productID && x.AmountInStock > 0).ToList();
            List<Database.UserReview> reviews;
            foreach (Database.Product x in products)
            {
                reviews = _context.UserReview.Where(i => i.ProductID == x.ProductID).OrderBy(i => i.UserID).ToList();
                if (reviews.Count > 0)
                {
                    productDictionary.Add(x.ProductID, reviews);
                }
            }
        }
    }
}
