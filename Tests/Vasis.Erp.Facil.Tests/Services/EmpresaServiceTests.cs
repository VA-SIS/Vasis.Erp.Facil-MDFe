// Projeto: Vasis.Erp.Facil.Tests
// Arquivo: Services/EmpresaServiceTests.cs
using Moq;
using FluentAssertions;
using FluentValidation;
using Vasis.Erp.Facil.Application.Validators;
using Vasis.Erp.Facil.Application.Services.Implementations;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Tests.Services
{
    public class EmpresaServiceTests
    {
        private readonly Mock<IEmpresaRepository> _repoMock;
        private readonly IValidator<Empresa> _validator;
        private readonly EmpresaService _service;

        public EmpresaServiceTests()
        {
            _repoMock = new Mock<IEmpresaRepository>();
            _validator = new EmpresaValidator();
            _service = new EmpresaService(_repoMock.Object, _validator);
        }

        [Fact]
        public async Task CriarEmpresa_DeveCriarComSucesso_QuandoDadosForemValidos()
        {
            var empresa = new EmpresaDto { NomeFantasia = "Empresa Teste", Cnpj = "12345678000199" };
            _repoMock.Setup(r => r.AddAsync(It.IsAny<Empresa>())).ReturnsAsync(Empresa);

            var resultado = await _service.CreateAsync(empresa);

            resultado.Should().NotBeNull();
            resultado.NomeFantasia.Should().Be("Empresa Teste");
        }

        [Fact]
        public async Task CriarEmpresa_DeveLancarExcecao_QuandoDadosInvalidos()
        {
            EmpresaDto empresa = new EmpresaDto { NomeFantasia = "", Cnpj = "000" };
            Func<Task> act = async () => await _service.CreateAsync(empresa);

            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task AtualizarEmpresa_DeveAtualizarComSucesso_QuandoValido()
        {
            EmpresaDto empresa = new EmpresaDto { Id = Guid.NewGuid(), NomeFantasia = "Atualizada", Cnpj = "12345678000199" };
            _repoMock.Setup(r => r.UpdateAsync(empresa)).ReturnsAsync(empresa);

            var resultado = await _service.UpdateAsync(empresa);

            resultado.NomeFantasia.Should().Be("Atualizada");
        }

        [Fact]
        public async Task RemoverEmpresa_DeveRetornarFalse_SeEmpresaNaoExistir()
        {
            bool resultado = true;
            Guid id = Guid.NewGuid();

            //_repoMock.Setup(r => r.DeleteAsync(id)).ReturnsAsync(false);

            //var resultado = await _service.DeleteAsync(id);

            resultado.Should().BeFalse();
        }
    }
}
