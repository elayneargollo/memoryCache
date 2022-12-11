using cache.Model;

namespace cache.Integration
{
    public interface IConsultaExterna
    {
        public T GetByDocumento<T>(string documento);
    }
}