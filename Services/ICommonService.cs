using FluentValidation.Results;

namespace TEST.Services
{
    public interface ICommonService<TDto>
    {
        Task<List<TDto>> List();
        Task<TDto> Read(int id);
        Task<(bool status, TDto datareturn, List<ValidationFailure>)> Write(TDto data);
        Task<TDto> Delete(int id);
        Task<(bool status, TDto datareturn, List<ValidationFailure>)> Add(TDto data);
    }
}
