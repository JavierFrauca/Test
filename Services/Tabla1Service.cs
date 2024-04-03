using AutoMapper;
using FluentValidation.Results;
using TEST.Dtos;
using TEST.Models;
using TEST.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TEST.Services
{
    public class Tabla1Service(ICommonRepository<Tabla1> repository, IMapper mapper) : ICommonService<Tabla1Dto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICommonRepository<Tabla1> _repository = repository;

        public async Task<List<Tabla1Dto>> List() => _mapper.Map<List<Tabla1Dto>>(await _repository.GetAll());
        public async Task<(bool status, Tabla1Dto datareturn, List<ValidationFailure>)> Add(Tabla1Dto data)
        {
            try
            {
                var datadto = _mapper.Map<Tabla1>(data);
                return (true, _mapper.Map<Tabla1Dto>(await _repository.Add(datadto)), []);
            }
            catch
            {
                return (false, data, [new ValidationFailure { ErrorMessage="No se ha podido añadir el registro"}]);

            }
        }
        public async Task<(bool status, Tabla1Dto datareturn, List<ValidationFailure>)> Delete(int id)
        {
            var data = await _repository.GetById(id);
            try
            {
                _repository.Delete(data);
                if(data != null)
                {
                    await _repository.Save();
                    return (true, _mapper.Map<Tabla1Dto>(data), []);
                }
                else
                {
                    return (false, _mapper.Map<Tabla1Dto>(data), [new ValidationFailure { ErrorMessage = "El registro que pretende eliminar no existe" }]);
                }
            }
            catch
            {
                return (false, _mapper.Map<Tabla1Dto>(data), [new ValidationFailure { ErrorMessage = "No se ha podido eliminar" }]);
            }
        }

        public async Task<(bool status, Tabla1Dto datareturn, List<ValidationFailure>)> Read(int id)
        {
            try
            {
                return (true,_mapper.Map<Tabla1Dto>(await _repository.GetById(id)), []);
            }
            catch(Exception ex) 
            {
                return(false,new Tabla1Dto(), [new ValidationFailure { ErrorMessage = ex.Message }]);
            }
        }

        public async Task<(bool status, Tabla1Dto datareturn, List<ValidationFailure>)> Write(Tabla1Dto data)
        {
            _repository.Update(_mapper.Map<Tabla1>(data));
            await _repository.Save();
            return (true, data, []);
        }
    }
}