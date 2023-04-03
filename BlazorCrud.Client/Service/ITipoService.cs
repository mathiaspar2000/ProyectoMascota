using BlazorCrud.Shared;

namespace BlazorCrud.Client.Service
{
    public interface ITipoService 
    {
        Task<List<TipoDTO>> Lista();
    }
}
