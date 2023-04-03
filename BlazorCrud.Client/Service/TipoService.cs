using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Service
{
    public class TipoService : ITipoService
    {
        private readonly HttpClient _http;
        public TipoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TipoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TipoDTO>>>("api/Tipo/Lista");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
    }
}
