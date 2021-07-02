using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtpServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtpServiceClient)
        {
            _discountProtpServiceClient = discountProtpServiceClient;
        }
        public async Task<CouponModel> GetDiscount(string productName) {
            var discountRequest = new GetDiscountRequest { ProductName = productName };
            return await _discountProtpServiceClient.GetDiscountAsync(discountRequest);
        }
    }
}
