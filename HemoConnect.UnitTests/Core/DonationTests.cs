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
    public class DonationTests
    {
        private HemoConnectDbContext CreateDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<HemoConnectDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new HemoConnectDbContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddDonation_AndReturnId()
        {
            //Arrange
            var context = CreateDbContext(nameof(AddAsync_ShouldAddDonation_AndReturnId));
            var repository = new DonationRepository(context);

            var donation = new Donation(1, new DateTime(1995, 08, 11), 250);

            //Act

            var result = await repository.AddAsync(donation);

            //Assert

            Assert.NotNull(result);
            Assert.True(result > 0);
        }

        [Fact]
        public async Task GetAllDonationsAsync_ShouldReturnListOfDonations()
        {
            //Arrange
            var context = CreateDbContext(nameof(GetAllDonationsAsync_ShouldReturnListOfDonations));
            var repository = new DonationRepository(context);


            var donation1 = new Donation(1, new DateTime(1995, 08, 11), 250);
            var donation2 = new Donation(2, new DateTime(1996, 09, 12), 300);


            var donation_1 = await repository.AddAsync(donation1);
            var donation_2 = await repository.AddAsync(donation2);


            //Act
            var result = await repository.GetAllDonationsAsync();


            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetDonationByDonorIdAsync_ShouldReturnDonation_WhenExists()
        {
            //Arrange
            var context = CreateDbContext(nameof(GetDonationByDonorIdAsync_ShouldReturnDonation_WhenExists));
            var repository = new DonationRepository(context);

            var donation1 = new Donation(1, new DateTime(1995, 08, 11), 250);

            var donation_1 = await repository.AddAsync(donation1);

            //Act

            var result = await repository.GetDonationByDonorIdAsync(donation1.DonorId);

            //Assert

            Assert.NotNull(result);
            Assert.True(result[0].AmountML == donation1.AmountML);
        }

        [Fact]
        public async Task GetDonationByIdAsync_ShouldReturnDonation_WhenExists()
        {
            //Arrange
            var context = CreateDbContext(nameof(GetDonationByIdAsync_ShouldReturnDonation_WhenExists));
            var repository = new DonationRepository(context);

            var donation1 = new Donation(1, new DateTime(1995, 08, 11), 250);
            var donation_1 = await repository.AddAsync(donation1);

            //Act
            var result = await repository.GetDonationByIdAsync(donation_1);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Id == donation1.Id);
        }

        [Fact]
        public async Task GetLastDonationByDonorIdAsync_ShouldReturnLastDonation_WhenExists()
        {
            //Arrange
            var context = CreateDbContext(nameof(GetLastDonationByDonorIdAsync_ShouldReturnLastDonation_WhenExists));
            var repository = new DonationRepository(context);

            var donation1 = new Donation(1, new DateTime(1995, 08, 11), 250);
            var donation2 = new Donation(1, new DateTime(1996, 09, 12), 300);

            await repository.AddAsync(donation1);
            await repository.AddAsync(donation2);

            //Act
            var result = await repository.GetLastDonationByDonorIdAsync(donation1.DonorId);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.DonationDate == donation2.DonationDate);
        }

        [Fact]
        public async Task GetLastDonationByDonorIdAsync_ShouldReturnNull_WhenNoDonationsExist()
        {
            var context = CreateDbContext(nameof(GetLastDonationByDonorIdAsync_ShouldReturnNull_WhenNoDonationsExist));
            var repository = new DonationRepository(context);

            var result = await repository.GetLastDonationByDonorIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetDonationByDonorIdAsync_ShouldReturnAllDonations_ForSameDonor()
        {
            var context = CreateDbContext(nameof(GetDonationByDonorIdAsync_ShouldReturnAllDonations_ForSameDonor));
            var repository = new DonationRepository(context);

            var donation1 = new Donation(1, new DateTime(2020, 01, 01), 200);
            var donation2 = new Donation(1, new DateTime(2021, 01, 01), 300);

            await repository.AddAsync(donation1);
            await repository.AddAsync(donation2);

            var result = await repository.GetDonationByDonorIdAsync(1);

            Assert.Equal(2, result.Count);
            Assert.Contains(result, d => d.AmountML == 200);
            Assert.Contains(result, d => d.AmountML == 300);
        }
    }
}
