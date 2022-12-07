namespace cache
{
    public class Util
    {
        public static bool ValidarDocumento(string documento)
        {
            if(documento.Length <= 11)
                return CpfValido(documento);
                
            return CnpjValido(documento);
        }

        public static bool CnpjValido(string documento)
        {
            var cnpjValidator = new Caelum.Stella.CSharp.Validation.CNPJValidator();
            return cnpjValidator.IsValid(documento);
        }

        public static bool CpfValido(string documento)
        {
            var cpfValidator = new Caelum.Stella.CSharp.Validation.CPFValidator();
            return cpfValidator.IsValid(documento);
        }
    }
}