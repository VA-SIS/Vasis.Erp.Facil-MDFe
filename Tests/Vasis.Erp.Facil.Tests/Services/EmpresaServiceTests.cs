// Projeto: Vasis.Erp.Facil.Tests
// Arquivo: Services/EmpresaServiceTests.cs
using Moq;
using FluentAssertions;
using AutoMapper;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Application.Services.Implementations;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Dtos.Profiles;

namespace Vasis.Erp.Facil.Tests.Services
{
    public class EmpresaServiceTests
    {
        private readonly Mock<IEmpresaRepository> _repoMock;
        private readonly IMapper _mapper;
        private readonly EmpresaService _service;

        public EmpresaServiceTests()
        {
            _repoMock = new Mock<IEmpresaRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmpresaProfile>();
            });
            _mapper = config.CreateMapper();

            _service = new EmpresaService(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task CreateAsync_DeveRetornarEmpresaCriada_QuandoDadosValidos()
        {
            // Arrange
            var dto = new EmpresaDto
            {
                Cnpj = "12345678000199",
                RazaoSocial = "Empresa Teste",
                NomeFantasia = "Fantasia Teste"
            };

            var empresaCriada = _mapper.Map<Empresa>(dto);
            _repoMock.Setup(r => r.AddAsync(It.IsAny<Empresa>())).ReturnsAsync(empresaCriada);

            // Act
            var resultado = await _service.CreateAsync(dto);

            // Assert
            resultado.Should().NotBeNull();
            resultado.RazaoSocial.Should().Be("Empresa Teste");
        }

        [Fact]
        public async Task UpdateAsync_DeveRetornarEmpresaAtualizada_QuandoDadosValidos()
        {
            // Arrange
            var dto = new EmpresaDto
            {
                Id = Guid.NewGuid(),
                Cnpj = "12345678000199",
                RazaoSocial = "Empresa Atualizada",
                NomeFantasia = "Fantasia Atualizada"
            };

            var empresaAtualizada = _mapper.Map<Empresa>(dto);
            _repoMock.Setup(r => r.UpdateAsync(It.IsAny<Empresa>())).ReturnsAsync(empresaAtualizada);

            // Act
            var resultado = await _service.UpdateAsync(dto);

            // Assert
            resultado.Should().NotBeNull();
            resultado.RazaoSocial.Should().Be("Empresa Atualizada");
        }

        [Fact]
        public async Task DeleteAsync_DeveExecutarSemExcecao_QuandoIdValido()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repoMock.Setup(r => r.DeleteAsync(id)).Returns(Task.CompletedTask);

            // Act & Assert
            var exception = await Record.ExceptionAsync(() => _service.DeleteAsync(id));
            exception.Should().BeNull();
        }
    }
}
