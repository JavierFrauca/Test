using AutoMapper;
using FluentValidation.Results;
using TEST.Dtos;
using TEST.Models;
using TEST.Repositories;

namespace TEST.Services
{
    public class Tabla1Service(ICommonRepository<Tabla1> repository, IMapper mapper) : ICommonService<Tabla1Dto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICommonRepository<Tabla1> _repository = repository;

        public async Task<List<Tabla1Dto>> List() => _mapper.Map<List<Tabla1Dto>>(await _repository.GetAll());
        public async Task<(bool status, Tabla1Dto datareturn, List<ValidationFailure>)> Add(Tabla1Dto data)
        {
            var datadto = _mapper.Map<Tabla1>(data);
            return (true, _mapper.Map<Tabla1Dto>(await _repository.Add(datadto)), []);
        }

        public async Task<Tabla1Dto> Delete(int id)
        {
            var data = await _repository.GetById(id);
            _repository.Delete(data);
            await _repository.Save();
            return _mapper.Map<Tabla1Dto>(data);
        }

        public async Task<Tabla1Dto> Read(int id) => _mapper.Map<Tabla1Dto>(await _repository.GetById(id));

        public async Task<(bool status, Tabla1Dto datareturn, List<ValidationFailure>)> Write(Tabla1Dto data)
        {
            _repository.Update(_mapper.Map<Tabla1>(data));
            await _repository.Save();
            return (true, data, []);
        }
    }
}