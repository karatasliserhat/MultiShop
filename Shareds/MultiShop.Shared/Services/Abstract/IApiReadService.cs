namespace MultiShop.Shared.Services.Abstract
{
    public interface IApiReadService<ResultDto> where ResultDto : class
    {
        Task<ResultDto> GetByIdAsync(string controllerName, int id);
        Task<ResultDto> GetByIdAsync(string controllerName, string id);
        Task<List<ResultDto>> GetListAsync(string controllerName);
        Task<List<ResultDto>> GetListAsync(string controllerName, string actionName);
    }
}
