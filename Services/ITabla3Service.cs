using FluentValidation.Results;
using TEST.Dtos;

namespace TEST.Services
{
    public interface ITabla3Service
    {
        Task<List<Tabla3Dto>> List();
        Task<Tabla3Dto> Read(int id);
        Task<(bool status, Tabla3Dto datareturn, List<ValidationFailure>)> Write(Tabla3Dto data);
        Task<Tabla3Dto> Delete(int id);
        Task<(bool status, Tabla3Dto datareturn, List<ValidationFailure>)> Add(Tabla3Dto data);
    }
}
