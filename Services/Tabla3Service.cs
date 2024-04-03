using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using TEST.Dtos;
using TEST.Models;
using TEST.Repositories;

namespace TEST.Services
{
    public class Tabla3Service(ICommonRepository<Tabla3> repository, IMapper mapper, IValidator<Tabla3Dto> validator) : ITabla3Service
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICommonRepository<Tabla3> _repository = repository;
        private readonly IValidator<Tabla3Dto> _validator = validator;

        public async Task<List<Tabla3Dto>> List() => _mapper.Map<List<Tabla3Dto>>(await _repository.GetAll());
        public async Task<(bool status, Tabla3Dto datareturn, List<ValidationFailure>)> Add(Tabla3Dto data)
        {
            var res = _validator.Validate(data);
            if (res.IsValid)
            {
                var datadto = _mapper.Map<Tabla3>(data);
                return (true, _mapper.Map<Tabla3Dto>(await _repository.Add(datadto)), []);
            }
            else
            {
                return (false, data, res.Errors);
            }
        }

        public async Task<Tabla3Dto> Delete(int id)
        {
            var data = await _repository.GetById(id);
            _repository.Delete(data);
            await _repository.Save();
            return _mapper.Map<Tabla3Dto>(data);
        }

        public async Task<Tabla3Dto> Read(int id) => _mapper.Map<Tabla3Dto>(await _repository.GetById(id));

        public async Task<(bool status, Tabla3Dto datareturn, List<ValidationFailure>)> Write(Tabla3Dto data)
        {
            var res = _validator.Validate(data);
            if (res.IsValid)
            {
                _repository.Update(_mapper.Map<Tabla3>(data));
                await _repository.Save();
                return (true, data, []);
            }
            else
            {
                return (false, data, res.Errors);
            }
        }
    }
}
