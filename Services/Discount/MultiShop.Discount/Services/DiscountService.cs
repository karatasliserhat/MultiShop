using Dapper;
using MultiShop.Discount.Dtos;
using System.Data;
namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDbConnection _connection;
        public DiscountService(IDbConnection connection)
        {
            _connection = connection;
        }
        DynamicParameters parameters = new DynamicParameters();

        public async Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto)
        {

            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values(@code, @rate, @isActive, @validData)";
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validData", createCouponDto.ValidDate);

            await _connection.ExecuteAsync(query, parameters);

        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete from Coupons where CouponId=@couponId";
            parameters.Add("couponId", id);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            var values = await _connection.QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            parameters.Add("@couponId", id);
            return await _connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);


        }

        public async Task UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where CouponId=@couponId ";
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);

            await _connection.ExecuteAsync(query, parameters);
        }
    }
}
