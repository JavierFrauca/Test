using AutoMapper;
using Xunit;

namespace TEST.Test
{
    public class DemoServiceTest
    {
        //private readonly IConfiguration _configuration;
        //private readonly string _ip;
        //private readonly string _username;
        //private readonly string _password;
        //private readonly IMapper _mapper;
        //private readonly TokenService _tokenService;
        //private readonly EnterprisesEntity _enterprisesEntity;
        //private readonly EnterpriseConceptsEntity _enterpriseConceptsEntity;
        //private readonly EnterpriseSectionsEntity _enterpriseSectionsEntity;

        //private readonly EmployeesEntity _employeesEntity;
        //private readonly EmployeeProfilesEntity _employeeProfilesEntity;
        //private readonly EmployeeCalculationsEntity _employeeCalculationsEntity;
        //private readonly EmployeeSectionsEntity _employeeSectionsEntity;
        //private readonly EmployeeVariableEntity _employeeVariablesEntity;

        //public ServicesTest()
        //{
        //    _username = "Administrador";
        //    _password = "pez3tres";
        //    _ip = "127.0.0.1";
        //    _configuration = new ConfigurationBuilder()
        //                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Establece la base del path al directorio de salida del test
        //                    .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
        //                    .Build();
        //    _tokenService = new TokenService(_configuration);

        //    var mappingConfig = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
        //    _mapper = mappingConfig.CreateMapper();

        //    var (_, token) = _tokenService.Create(_ip, _username, _password);
        //    var _ = _tokenService.Validate(token, _ip);
        //    _enterprisesEntity = new EnterprisesEntity(_mapper, _tokenService);
        //    _enterpriseSectionsEntity = new EnterpriseSectionsEntity(_mapper, _tokenService);
        //    _enterpriseConceptsEntity = new EnterpriseConceptsEntity(_mapper, _tokenService);

        //    _employeesEntity = new EmployeesEntity(_mapper, _tokenService);
        //    _employeeProfilesEntity = new EmployeeProfilesEntity(_mapper, _tokenService);
        //    _employeeCalculationsEntity = new EmployeeCalculationsEntity(_mapper, _tokenService);
        //    _employeeSectionsEntity = new EmployeeSectionsEntity(_mapper, _tokenService);
        //    _employeeVariablesEntity = new EmployeeVariableEntity(_mapper, _tokenService);

        //}

        //[Fact]
        //public void Login()
        //{
        //    var serviceToken = new TokenService(_configuration);
        //    var (succeded, token) = serviceToken.Create(_ip, _username, _password);
        //    Assert.True(succeded);
        //    var validate = serviceToken.Validate(token, _ip);
        //    Assert.True(validate);
        //}
        //[Fact]
        //public async Task GetEnterprises()
        //{
        //    var serviceEnterprise = new EnterprisesService(_mapper, _enterprisesEntity);
        //    var (succeded, list, errmessage) = await serviceEnterprise.GetEnterprisesAsync();
        //    Assert.True(succeded);
        //    Console.Write(list.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEnterprise()
        //{
        //    var serviceEnterprise = new EnterprisesService(_mapper, _enterprisesEntity);
        //    var (_, list, _) = await serviceEnterprise.GetEnterprisesAsync();
        //    foreach (var entry in list)
        //    {
        //        var (succeded, data, errmessage) = await serviceEnterprise.GetEnterpriseAsync(entry.CodEmpresa);
        //        Assert.True(succeded);
        //        Console.Write(data.ToString());
        //        Console.Write(errmessage);
        //    }
        //}
        //[Fact]
        //public async Task GetEnterpriseSections()
        //{
        //    var serviceEnterpriseSections = new EnterpriseSectionsService(_mapper, _enterpriseSectionsEntity);
        //    var (succeded, data, errmessage) = await serviceEnterpriseSections.GetSectionsAsync(1);
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEnterpriseConcepts()
        //{
        //    var serviceEnterpriseConcepts = new EnterpriseConceptsService(_mapper, _enterpriseConceptsEntity);
        //    var (succeded, data, errmessage) = await serviceEnterpriseConcepts.GetConceptsAsync(1);
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEmployees()
        //{
        //    var serviceEmployee = new EmployeesService(_mapper, _employeesEntity);
        //    var (succeded, list, errmessage) = await serviceEmployee.GetEmployeesAsync(1);
        //    Assert.True(succeded);
        //    Console.Write(list.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEmployee()
        //{
        //    var serviceEmployee = new EmployeesService(_mapper, _employeesEntity);
        //    var (succeded, data, errmessage) = await serviceEmployee.GetEmployeeAsync(10001);
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEmployeeProfiles()
        //{
        //    var serviceEmployee = new EmployeeProfilesService(_mapper, _employeeProfilesEntity);
        //    var (succeded, data, errmessage) = await serviceEmployee.GetProfilesAsync(10001);
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEmployeeCalculations()
        //{
        //    var serviceEmployee = new EmployeeCalculationsService(_mapper, _employeeCalculationsEntity);
        //    var (succeded, data, errmessage) = await serviceEmployee.GetCalculationsAsync(10001, "M", "202301");
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEmployeeSections()
        //{
        //    var serviceEmployeeSections = new EmployeeSectionsService(_mapper, _employeeSectionsEntity);
        //    var (succeded, data, errmessage) = await serviceEmployeeSections.GetSectionsAsync(10001);
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
        //[Fact]
        //public async Task GetEmployeeVariables()
        //{
        //    var serviceEmployeeVariables = new EmployeeVariablesService(_mapper, _employeeVariablesEntity);
        //    var (succeded, data, errmessage) = await serviceEmployeeVariables.GetVariableAsync(10001, "202301");
        //    Assert.True(succeded);
        //    Console.Write(data.ToString());
        //    Console.Write(errmessage);
        //}
    }
}
