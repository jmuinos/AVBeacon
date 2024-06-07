using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Educations.Commands;

public class CreateEducationCommandHandler(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateEducationCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
    {
        var education = new Education(request.EducationType, request.Description, request.Start,
                                      request.End, request.ApplicantId);

        await educationRepository.AddAsync(education, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(education.Id);
    }
}