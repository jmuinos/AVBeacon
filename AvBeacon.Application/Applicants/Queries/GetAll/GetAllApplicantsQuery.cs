using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.Applicants.Queries.GetAll;

/// <summary> Representa la consulta para obtener todos los solicitantes. </summary>
public sealed class GetAllApplicantsQuery : IQuery<Maybe<List<UserResponse>>>;