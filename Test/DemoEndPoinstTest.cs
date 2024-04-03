using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Globalization;
using Xunit;

namespace TEST.Test
{
    public class DemoEndPoinstTest : IDisposable
    {

    //private readonly Mock<IEmployeesService> _mockEmployeesService;
    //private readonly Mock<IEmployeeProfilesService> _mockEmployeeProfilesService;
    //private readonly Mock<IEmployeeCalculationsService> _mockEmployeeCalculationsService;
    //private readonly Mock<IEmployeeSectionsService> _mockEmployeeSectionsService;
    //private readonly Mock<IEmployeeVariablesService> _mockEmployeeVariablesService;
    //private readonly EmployeesController _controllerEmployee;

    //private readonly Mock<IEnterprisesService> _mockEnterpriseService;
    //private readonly Mock<IEnterpriseSectionsService> _mockEnterpriseSectionsService;
    //private readonly Mock<IEnterpriseConceptsService> _mockEnterpriseConceptsService;
    //private readonly EnterprisesController _controllerEnterprise;

    //public ControllersTests()
    //{
    //    _mockEnterpriseService = new Mock<IEnterprisesService>();
    //    _mockEnterpriseSectionsService = new Mock<IEnterpriseSectionsService>();
    //    _mockEnterpriseConceptsService = new Mock<IEnterpriseConceptsService>();
    //    _controllerEnterprise = new EnterprisesController(_mockEnterpriseService.Object, _mockEnterpriseSectionsService.Object, _mockEnterpriseConceptsService.Object);

    //    _mockEmployeesService = new Mock<IEmployeesService>();
    //    _mockEmployeeCalculationsService = new Mock<IEmployeeCalculationsService>();
    //    _mockEmployeeProfilesService = new Mock<IEmployeeProfilesService>();
    //    _mockEmployeeSectionsService = new Mock<IEmployeeSectionsService>();
    //    _mockEmployeeVariablesService = new Mock<IEmployeeVariablesService>();
    //    _controllerEmployee = new EmployeesController(_mockEmployeesService.Object, _mockEmployeeProfilesService.Object, _mockEmployeeCalculationsService.Object, _mockEmployeeSectionsService.Object, _mockEmployeeVariablesService.Object);
    //}
    //[Fact]
    //public async Task GetEnterprisesReturnsOkWithEnterprises()
    //{
    //    // Arrange
    //    var enterprises = new List<EnterprisesDTO>
    //    {
    //        new() { CodEmpresa=1,Razon="Empresa1",Cif="11111111T",Ccc="50123456712" },
    //        new() { CodEmpresa=2,Razon="Empresa2",Cif="11111112T",Ccc="50123456714" }
    //    };
    //    _mockEnterpriseService.Setup(s => s.GetEnterprisesAsync()).ReturnsAsync((true, enterprises, string.Empty));
    //    // Act
    //    var result = await _controllerEnterprise.GetEnterprises();
    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<IEnumerable<EnterprisesDTO>>(objectResult.Value);
    //}

    //[Fact]
    //public async Task GetEnterpriseReturnsOkWithEnterprise()
    //{
    //    // Arrange
    //    var enterprise = new EnterpriseDTO { CodEmpresa = 1, Razon = "Empresa1", Cif = "11111111T", Ccc = "50123456712" };
    //    _mockEnterpriseService.Setup(s => s.GetEnterpriseAsync(It.IsAny<int>())).ReturnsAsync((true, enterprise, string.Empty));
    //    // Act
    //    var result = await _controllerEnterprise.GetEnterprise(1);

    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<EnterpriseDTO>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEnterpriseSectionsReturnsOkWithEnterprise()
    //{
    //    // Arrange
    //    var sections = new List<EnterpriseSectionDTO> {
    //        new(){ Id = 1, CodEmpresa = 1, CodSeccion = 1, Seccion = "textoseccion1"},
    //        new(){ Id = 1, CodEmpresa = 1, CodSeccion = 2, Seccion = "textoseccion2"},
    //        new(){ Id = 1, CodEmpresa = 1, CodSeccion = 3, Seccion = "textoseccion3"}
    //    };
    //    _mockEnterpriseSectionsService.Setup(s => s.GetSectionsAsync(It.IsAny<int>())).ReturnsAsync((true, sections, string.Empty));
    //    // Act
    //    var result = await _controllerEnterprise.GetSections(1);

    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<List<EnterpriseSectionDTO>>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEnterpriseConceptsReturnsOkWithEnterprise()
    //{
    //    // Arrange
    //    var sections = new List<EnterpriseConceptDTO> {
    //        new(){ Id = 1, CodEmpresa = 1, CodConcepto = 1, Texto = "Concepto1"},
    //        new(){ Id = 1, CodEmpresa = 1, CodConcepto = 2, Texto = "Concepto2"},
    //        new(){ Id = 1, CodEmpresa = 1, CodConcepto = 3, Texto = "Concepto3"}
    //    };
    //    _mockEnterpriseConceptsService.Setup(s => s.GetConceptsAsync(It.IsAny<int>())).ReturnsAsync((true, sections, string.Empty));
    //    // Act
    //    var result = await _controllerEnterprise.GetConcetps(1);

    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<List<EnterpriseConceptDTO>>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEmployeesReturnsOkWithEmployees()
    //{
    //    // Arrange
    //    var employees = new List<EmployeesDTO> {
    //        new (){CodEmpleado=10001,Nombre="Empleado 1",Nif="11111111T"},
    //        new (){CodEmpleado=10002,Nombre="Empleado 2",Nif="11111112T"}
    //    };
    //    _mockEmployeesService.Setup(s => s.GetEmployeesAsync(1)).ReturnsAsync((true, employees, string.Empty));
    //    // Act
    //    var result = await _controllerEmployee.GetEmployees(1);
    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<IEnumerable<EmployeesDTO>>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEmployeeReturnsOkWithEmployees()
    //{
    //    // Arrange
    //    var employee = new EmployeeDTO { CodEmpleado = 10001, Nombre = "Empleado 1", Nif = "11111111T" };
    //    _mockEmployeesService.Setup(s => s.GetEmployeeAsync(It.IsAny<int>())).ReturnsAsync((true, employee, string.Empty));
    //    // Act
    //    var result = await _controllerEmployee.GetEmployee(10001);
    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<EmployeeDTO>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEmployeeProfilesReturnsOkWithEmployees()
    //{
    //    // Arrange
    //    var datetime = DateTime.Parse("01-01-2024", new CultureInfo("es-ES"), DateTimeStyles.AssumeLocal);
    //    var employeeProfiles = new List<EmployeeProfileDTO> {
    //        new (){CodEmpleado=10001,Fecha_Desde=datetime,Dato="CTO", Valor="100"},
    //        new (){CodEmpleado=10001,Fecha_Desde=datetime,Dato="OCU", Valor=""},
    //        new (){CodEmpleado=10001,Fecha_Desde=datetime,Dato="GRC", Valor="5"},
    //        new (){CodEmpleado=10001,Fecha_Desde=datetime,Dato="COE", Valor="100"},
    //        new (){CodEmpleado=10001,Fecha_Desde=datetime,Dato="RCE", Valor=""}
    //    };
    //    _mockEmployeeProfilesService.Setup(s => s.GetProfilesAsync(10001)).ReturnsAsync((true, employeeProfiles, string.Empty));
    //    // Act
    //    var result = await _controllerEmployee.GetProfiles(10001);

    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<IEnumerable<EmployeeProfileDTO>>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEmployeeCalculationsReturnsOkWithEmployees()
    //{
    //    // Arrange
    //    var datetimeIni = DateTime.Parse("01-01-2024", new CultureInfo("es-ES"), DateTimeStyles.AssumeLocal);
    //    var datetimeEnd = DateTime.Parse("31-01-2024", new CultureInfo("es-ES"), DateTimeStyles.AssumeLocal);
    //    var employeeCalculations = new List<EmployeeCalculationDTO> {
    //        new (){Id=1,CodEmpleado=10001,FechaDesde=datetimeIni,FechaHasta=datetimeEnd,PeriodoAAAAMM = "202401",TipoLQ = "M", Mpd = [100.1m,100.2m,100.3m,100.4m] }
    //    };
    //    _mockEmployeeCalculationsService.Setup(s => s.GetCalculationsAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((true, employeeCalculations, string.Empty));
    //    // Act
    //    var result = await _controllerEmployee.GetCalculations(10001, "M", "202401");
    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<IEnumerable<EmployeeCalculationDTO>>(objectResult.Value);
    //}
    //[Fact]
    //public async Task GetEmployeeVariablesReturnsOkWithEmployees()
    //{
    //    // Arrange
    //    var employeeVariables = new List<EmployeeVariableDTO> {
    //        new (){Id=1,CodEmpleado=10001,CodConcepto=2, PeriodoAAAAMM="202301", CodSeccion=0,Devengo="",Tributacion="",Importe = 101.0m },
    //        new (){Id=1,CodEmpleado=10001,CodConcepto=3,PeriodoAAAAMM="202301", CodSeccion=0,Devengo="",Tributacion="",Importe = 102.0m },
    //        new (){Id=1,CodEmpleado=10001,CodConcepto=4,PeriodoAAAAMM="202301", CodSeccion=0,Devengo="",Tributacion="",Importe = 103.0m }
    //    };
    //    _mockEmployeeVariablesService.Setup(s => s.GetVariableAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((true, employeeVariables, string.Empty));
    //    // Act
    //    var result = await _controllerEmployee.GetVariables(10001, "202401");
    //    // Assert
    //    var objectResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsAssignableFrom<IEnumerable<EmployeeVariableDTO>>(objectResult.Value);
    //}
    //[Fact]
    //public async Task SetEmployeeVariablesReturnsOkWithEmployees()
    //{
    //    // Arrange
    //    var employeeVariables = new List<EmployeeVariableDTO> {
    //        new (){Id=1,CodEmpleado=10001,CodConcepto=2, PeriodoAAAAMM="202301", CodSeccion=0,Devengo="",Tributacion="",Importe = 101.0m },
    //        new (){Id=1,CodEmpleado=10001,CodConcepto=3,PeriodoAAAAMM="202301", CodSeccion=0,Devengo="",Tributacion="",Importe = 102.0m },
    //        new (){Id=1,CodEmpleado=10001,CodConcepto=4,PeriodoAAAAMM="202301", CodSeccion=0,Devengo="",Tributacion="",Importe = 103.0m }
    //    };
    //    _mockEmployeeVariablesService.Setup(s => s.SetVariableAsync(10001, "202401", employeeVariables)).ReturnsAsync((true));
    //    // Act
    //    var result = await _controllerEmployee.SetVariables(10001, "202401", employeeVariables);
    //    var objectResult = result.Result as ObjectResult;
    //    // Assert
    //    Assert.NotNull(objectResult);
    //    Assert.Equal(200, objectResult.StatusCode);
    //    Assert.IsType<bool>(objectResult.Value);
    //}

    public void Dispose()
    {
        //_controllerEmployee.Dispose();
        //_controllerEnterprise.Dispose();
        GC.SuppressFinalize(this);
    }
}
}
