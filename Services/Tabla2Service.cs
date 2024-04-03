using AutoMapper;
using FluentValidation.Results;
using TEST.Dtos;
using TEST.Models;
using TEST.Repositories;

namespace TEST.Services
{
    public class Tabla2Service(ICommonRepository<Tabla2> repository, IMapper mapper) : ICommonService<Tabla2Dto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICommonRepository<Tabla2> _repository = repository;

        public async Task<List<Tabla2Dto>> List() => _mapper.Map<List<Tabla2Dto>>(await _repository.GetAll());
        public async Task<(bool status, Tabla2Dto datareturn, List<ValidationFailure>)> Add(Tabla2Dto data)
        {
            var dataRep = _mapper.Map<Tabla2>(data);
            await _repository.Add(dataRep);
            return (true, data, []);
        }

        public async Task<(bool status, Tabla2Dto datareturn, List<ValidationFailure>)> Delete(int id)
        {
            var data = await _repository.GetById(id);
            _repository.Delete(data);
            await _repository.Save();
            return (true, _mapper.Map<Tabla2Dto>(data), []);
        }

        public async Task<(bool status, Tabla2Dto datareturn, List<ValidationFailure>)> Read(int id) {
            var data = _mapper.Map<Tabla2Dto>(await _repository.GetById(id));
            return (true, data, []);
        } 

        public async Task<(bool status, Tabla2Dto datareturn, List<ValidationFailure>)> Write(Tabla2Dto data)
        {
            _repository.Update(_mapper.Map<Tabla2>(data));
            await _repository.Save();
            return (true, data, []);
        }
    }
}
