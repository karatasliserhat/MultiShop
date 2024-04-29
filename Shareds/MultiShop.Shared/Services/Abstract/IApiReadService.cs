namespace MultiShop.Shared.Services.Abstract
{
    public interface IApiReadService<ResultDto> where ResultDto : class
    {
        Task<ResultDto> GetByIdAsync(string controllerName, int id);
        Task<ResultDto> GetByIdAsync(string controllerName, string id);
        Task<List<ResultDto>> GetListAsync(string controllerName, string token);
        Task<List<ResultDto>> GetListAsync(string controllerName, string actionName, string token);
    }
}
