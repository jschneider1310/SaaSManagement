// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Features.CustomerManagement.Entities;
using SaaSManagement.Core.Features.ServicesManagement.Records;
using SaaSManagement.Core.Shared.Abstractions;

namespace SaaSManagement.Core.Features.ServicesManagement.Entities;
/// <summary>
/// Class that represents a template to be used to generate a new <see cref="ServiceLevelAgreement"/>
/// for a particular <see cref="Customer"/>
/// </summary>
public sealed class ServiceLevelAgreementTemplate : Entity<string>
{
    public ServiceLevelAgreementTemplate(string? title, 
        List<AvailabilityDefinition> availabilityDefinitions)
    {
        Title = title ?? "Service-Level Agreement";

        AvailabilityDefinitions = availabilityDefinitions;

    }

    public string TemplateId { get; } = $"SLATemplate_{Guid.NewGuid()}";
    public string Title { get; init; }
    public List<AvailabilityDefinition> AvailabilityDefinitions { get; set; }

    public override string GetId() => TemplateId;
}