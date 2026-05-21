// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.Collections.ObjectModel;
using SaaSManagement.Core.Features.ServicesManagement.Records;
using SaaSManagement.Core.Shared.Abstractions;

namespace SaaSManagement.Core.Features.ServicesManagement.Entities;

public sealed class ServiceLevelAgreementTemplate : Entity<string>
{
    public ServiceLevelAgreementTemplate(string title, ServiceOverview serviceOverview,
        ServiceAvailability serviceAvailability,
        List<AvailabilityDefinition> availabilityDefinitions,
        List<OutOfScopeThirdParty> outOfScopeThirdParty,
        List<MaintenanceContext> maintenanceContext,
        List<RecoveryContext> recoveryContext,
        List<AvailabilityExclusion> availabilityExclusion)
    {
        Title = title;
        ServiceOverview = serviceOverview;
        ServiceAvailability = serviceAvailability;
        AvailabilityDefinitions = availabilityDefinitions;
        OutOfScopeThirdParty = outOfScopeThirdParty;
        MaintenanceContext = maintenanceContext;
        RecoveryContext = recoveryContext;
        AvailabilityExclusion = availabilityExclusion;
    }

    public string TemplateId { get; } = $"SLATemplate_{Guid.NewGuid()}";
    public string Title { get; init; }
    public ServiceOverview ServiceOverview { get; init; }
    public ServiceAvailability ServiceAvailability { get; init; }
    public List<AvailabilityDefinition> AvailabilityDefinitions { get; set; }
    public List<OutOfScopeThirdParty> OutOfScopeThirdParty { get; set; }
    public List<MaintenanceContext> MaintenanceContext { get; set; }
    public List<RecoveryContext> RecoveryContext { get; set; }
    public List<AvailabilityExclusion> AvailabilityExclusion { get; set; }
    public override string GetId() => TemplateId;
}