using cache.Model;

namespace cache.Integration
{
    public interface IConsultaExterna
    {
        public Pessoa GetByCpf(string documento);
    }
}