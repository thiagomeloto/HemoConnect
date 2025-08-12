using HemoConnect.Core.Entities;
using HemoConnect.Infrastructure.Persistence;
using HemoConnect.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.UnitTests.Core
{
    public class DonorTests
    {

        private HemoConnectDbContext CreateDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<HemoConnectDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new HemoConnectDbContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddDonor_AndReturnId()
        {
            //Arrange: Preparar: Criar objetos que serão testados/Criar dados de entrada/Configurar mocks/stubs/fakes

            var context = CreateDbContext(nameof(AddAsync_ShouldAddDonor_AndReturnId));

            var repository = new DonorRepository(context);

            var donor = new Donor("Thiago Mendes Meloto", "thiagomeloto@gmail.com", new DateTime(1995, 08, 11), "M", 72.0, "0", "Negativo");

            //Act: Chamar o método ou função que está sendo testado/Passar os parâmetros preparados na etapa Arrange

            var id = await repository.AddAsync(donor);

            //Assert: Verificar: confirmar se o resultado obtido é o esperado./Usar asserts (por exemplo, Assert.Equal, result.Should().Be(...)) para verificar saídas

            Assert.NotNull(id);
            Assert.True(id > 0);

            var result = await context.Donors.FindAsync(id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDonor_WhenExists()
        {
            //Arrange
            var context = CreateDbContext(nameof(GetByIdAsync_ShouldReturnDonor_WhenExists));
            var repository = new DonorRepository(context);

            var donor = new Donor("Thiago Mendes Meloto", "thiagomeloto@gmail.com", new DateTime(1995, 08, 11), "M", 72.0, "0", "Negativo");

            var id = await repository.AddAsync(donor);

            //Act

            var result = await repository.GetByIdAsync(id);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTrue_WhenExists()
        {
            //Arrange
            var context = CreateDbContext(nameof(GetByIdAsync_ShouldReturnTrue_WhenExists));
            var repository = new DonorRepository(context);

            var donor = new Donor("Thiago Mendes Meloto", "thiagomeloto@gmail.com", new DateTime(1995, 08, 11), "M", 72.0, "0", "Negativo");

            var id = await repository.AddAsync(donor);

            //Act

            var result = await repository.ExistsAsync(id);

            //Assert

            Assert.True(result);
        }

        [Fact]
        public async Task EmailExistsAsync_ShouldReturnTrue_WhenEmailExists()
        {
            //Arrange
            var context = CreateDbContext(nameof(EmailExistsAsync_ShouldReturnTrue_WhenEmailExists));
            var repository = new DonorRepository(context);
            var donor = new Donor("Thiago Mendes Meloto", "thiagomeloto@gmail.com", new DateTime(1995, 08, 11), "M", 72.0, "0", "Negativo");

            var id = await repository.AddAsync(donor);

            //Act

            var result = await repository.EmailExistsAsync(donor.Email);

            //Assert

            Assert.True(result);
        }

    }
}
