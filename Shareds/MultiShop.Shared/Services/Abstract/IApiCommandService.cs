namespace MultiShop.Shared.Services.Abstract
{
    public interface IApiCommandService<UpdateDto, CreateDto>
        where UpdateDto : class
        where CreateDto : class
    {
        Task<HttpResponseMessage> CreateAsync(string controllername, CreateDto createDto);
        Task<HttpResponseMessage> RemoveAsync(string controllerName, int id);
        Task<HttpResponseMessage> RemoveAsync(string controllerName, string id);
        Task<HttpResponseMessage> UpdateAsync(string controllerName, UpdateDto updateDto);
    }
}
