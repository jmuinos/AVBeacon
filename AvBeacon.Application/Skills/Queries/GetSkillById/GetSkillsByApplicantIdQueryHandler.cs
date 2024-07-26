namespace AvBeacon.Application.Skills.Queries.GetSkillById { }

// /// <summary> Representa el manejador de la consulta <see cref="GetSkillsByApplicantIdQuery" /> </summary>
// internal sealed class
//     GetSkillsByApplicantIdQueryHandler : IQueryHandler<GetSkillsByApplicantIdQuery, List<SkillResponse>>
// {
//     private readonly IApplicantRepository _applicantRepository;
//
//     /// <summary> Inicializa una nueva instancia de la clase <see cref="GetSkillsByApplicantIdQueryHandler" />. </summary>
//     /// <param name="applicantRepository"> El repositorio de solicitantes. </param>
//     public GetSkillsByApplicantIdQueryHandler(IApplicantRepository applicantRepository)
//     {
//         _applicantRepository = applicantRepository;
//     }
//
//     /// <inheritdoc />
//     public async Task<List<SkillResponse>> Handle(GetSkillsByApplicantIdQuery request,
//         CancellationToken cancellationToken)
//     {
//         var skills = await _applicantRepository.GetSkillsByApplicantId(request.ApplicantId);
//         return skills.Select(s => new SkillResponse { Id = s.Id, Title = s.Title }).ToList();
//     }
// }
//todo Arreglar