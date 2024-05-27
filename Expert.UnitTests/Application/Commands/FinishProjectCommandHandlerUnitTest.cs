using Expert.Application.Commands.FinishProject;
using Expert.Domain.DTOs;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Expert.Infrastructure.Payments;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Net.Http;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(FinishProjectCommand))]
    public class FinishProjectCommandHandlerUnitTest
    {
        //[Fact]
        //[Trait("Application", "FinishProject - Command")]
        //public async Task InputDataIsOk_Executed_ReturnOk()
        //{
        //    // Arrange
        //    var projectRepository = new Mock<IProjectRepository>();
        //    var paymentService = new Mock<IPaymentService>();

   
        //    var id = 1;
        //    var creditCardNumber = "1234-5678-9876-5432";
        //    var cvv = "123";
        //    var expiresAt = "2024/05/23";
        //    var fullName = "John Doe";
        //    var finishProjectCommand = new FinishProjectCommand(id);

        //    finishProjectCommand.CreditCardNumber = creditCardNumber;
        //    finishProjectCommand.Cvv = cvv;
        //    finishProjectCommand.FullName = fullName;
        //    finishProjectCommand.ExpiresAt = expiresAt;

        //    var httpClientFactory = new Mock<IHttpClientFactory>();

        //    var configurationSection = new Mock<IConfigurationSection>();
        //    configurationSection.Setup(x => x.Value).Returns("https://localhost:6001");

        //    var configuration = new Mock<IConfiguration>();
        //    configuration.Setup(x => x.GetSection("Services:Payments")).Returns(configurationSection.Object);

        //    var paymentServiceInstance = new PaymentService(httpClientFactory.Object, configuration.Object);

        //    var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepository.Object, paymentServiceInstance);

        //    var project = new Project("Project Title", "Project Description", 100.0m, 1, 2);
        //    projectRepository.Setup(pr => pr.GetByIdAsync(id)).ReturnsAsync(project);

        //    // Act
        //    var result = await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

        //    // Assert
        //    Assert.True(result); 
        //    projectRepository.Verify(p => p.SaveChangesAsync(), Times.Once);
        //    paymentService.Verify(ps => ps.ProcessPayment(It.IsAny<PaymentInfoDto>()), Times.Once);
        //}
    }
}
