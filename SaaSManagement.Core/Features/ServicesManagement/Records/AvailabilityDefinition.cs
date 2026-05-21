// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Features.ServicesManagement.Records;

public sealed record AvailabilityDefinition(
    int Order, string DefinitionName, string Description, string Definition, string ResponseTime,
    string TargetResolutionTime, string BusinessHours);