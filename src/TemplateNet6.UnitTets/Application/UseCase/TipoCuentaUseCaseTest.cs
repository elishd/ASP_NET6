using NSubstitute;
using TemplateNet6.Application.InterfacesRepositories;
using TemplateNet6.Application.UseCase;
using TemplateNet6.Domain.Entities.TipoCuenta;

namespace TemplateNet6.UnitTets.Application.UseCase
{
    [TestClass]
    public class TipoCuentaUseCaseTest
    {
        private ITipoCuentaRepository _tipoCuentaRepository;

        [TestInitialize]
        public void Setup()
        {
            _tipoCuentaRepository = Substitute.For<ITipoCuentaRepository>();
        }

        [TestMethod]
        public async Task InsertAsync_Should_CallTipoCuentaRepositoryInsertAsync()
        {
            // Arrange
            var command = new TipoCuenta();
            var TipoCuentaUseCase = GetTipoCuentaUseCase();

            // Act
            await TipoCuentaUseCase.InsertAsync(command);

            // Assert
            await _tipoCuentaRepository.Received(1).InsertAsync(command);
        }

        [TestMethod]
        public async Task UpdateAsync_Should_CallTipoCuentaRepositoryUpdateAsync()
        {
            // Arrange
            var command = new TipoCuenta();
            var TipoCuentaUseCase = GetTipoCuentaUseCase();

            // Act
            await TipoCuentaUseCase.UpdateAsync(command);

            // Assert
            await _tipoCuentaRepository.Received(1).UpdateAsync(command);
        }

        [TestMethod]
        public async Task DeleteAsync_Should_CallTipoCuentaRepositoryDeleteAsync()
        {
            // Arrange
            var command = new TipoCuenta();
            var TipoCuentaUseCase = GetTipoCuentaUseCase();

            // Act
            await TipoCuentaUseCase.DeleteAsync(command);

            // Assert
            await _tipoCuentaRepository.Received(1).DeleteAsync(command);
        }

        [TestMethod]
        public async Task GetAllAsync_Should_CallTipoCuentaRepositoryGetAllAsync()
        {
            // Arrange
            var TipoCuentaUseCase = GetTipoCuentaUseCase();

            // Act
            await TipoCuentaUseCase.GetAllAsync();

            // Assert
            await _tipoCuentaRepository.Received(1).GetAllAsync();
        }

        [TestMethod]
        public async Task GetByCodigoAsync_Should_CallTipoCuentaRepositoryGetByCodigoAsync()
        {
            // Arrange
            int codigo = 123;
            var TipoCuentaUseCase = GetTipoCuentaUseCase();

            // Act
            await TipoCuentaUseCase.GetByCodigoAsync(codigo);

            // Assert
            await _tipoCuentaRepository.Received(1).GetByCodigoAsync(codigo);
        }

        private TipoCuentaUseCase GetTipoCuentaUseCase()
        {
            return new TipoCuentaUseCase(_tipoCuentaRepository);
        }
    }
}