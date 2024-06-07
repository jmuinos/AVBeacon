using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Experiences.Commands.CreateExperience;

public class CreateExperienceCommandHandler(IExperienceRepository experienceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateExperienceCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        var experience = new Experience(request.Title, request.Description, request.RecruiterName,
                                        request.Start, request.End, request.ApplicantId);

        await experienceRepository.AddAsync(experience, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(experience.Id);
    }
}