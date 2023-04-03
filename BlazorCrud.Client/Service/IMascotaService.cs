using BlazorCrud.Shared;

namespace BlazorCrud.Client.Service
{
    public interface IMascotaService
    {
        Task<List<MascotaDTO>> Lista();

        Task<MascotaDTO> Buscar(int id);

        Task<int> Guardar(MascotaDTO mascotaDTO);

        Task<int> Editar(MascotaDTO mascotaDTO);

        Task<bool> Eliminar(int id);
    }
}
