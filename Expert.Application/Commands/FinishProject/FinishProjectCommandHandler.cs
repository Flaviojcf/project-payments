using Expert.Domain.DTOs;
using Expert.Domain.Repositories;
using Expert.Infrastructure.Payments;
using MediatR;

namespace Expert.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService _paymentService) : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        private readonly IPaymentService _paymentService = _paymentService;
        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project?.Finish();

            var paymentInfoDto = new PaymentInfoDto(request.Id, request.CreditCardNumber, request.Cvv,
                                                    request.ExpiresAt, request.FullName, project.TotalCost);

            await _paymentService.ProcessPayment(paymentInfoDto);

            await _projectRepository.SaveChangesAsync();

            return true;
        }
    }
}
