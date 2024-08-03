namespace AvBeacon.Application.Queries.Users.Applicants.GetSkills;

// /// <summary> 
///Representa el manejador de la consulta <see cref="GetApplicantSkillsQuery" /> </summary>
// internal sealed class
//     GetSkillsByApplicantIdQueryHandler : IQueryHandler<GetApplicantSkillsQuery, List<SkillResponse>>
// {
//     private readonly IApplicantRepository _applicantRepository;
//
//     /// <summary> 
///Inicializa una nueva instancia de la clase <see cref="GetSkillsByApplicantIdQueryHandler" />. </summary>
//     /// <param name="applicantRepository"> El repositorio de solicitantes. </param>
//     public GetSkillsByApplicantIdQueryHandler(IApplicantRepository applicantRepository)
//     {
//         _applicantRepository = applicantRepository;
//     }
//
//     /// <inheritdoc />
//     public async Task<List<SkillResponse>> Handle(GetApplicantSkillsQuery request,
//         CancellationToken cancellationToken)
//     {
//         var skills = await _applicantRepository.GetSkillsByApplicantId(request.ApplicantId);
//         return skills.Select(s => new SkillResponse { Id = s.Id, Title = s.Title }).ToList();
//     }
// }
//todo Arreglar