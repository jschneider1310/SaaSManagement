// Project: SaaSManagement, 29/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.ServicesManagement.Domain.Constants;
using SaaSManagement.Core.ServicesManagement.Domain.Primitives;
using SaaSManagement.Core.Shared.Abstractions.Classes;

namespace SaaSManagement.Core.ServicesManagement.Domain.Entities;
/// <summary>
/// Abstract class that represents a service into the system. It is the aggregate root base.
/// </summary>
public abstract class Service : AggregateRoot<ServiceId>
{
    
    public new ServiceId Id { get; private set; } = $"SER-{Ulid.NewUlid()}";
    public ServiceType ServiceType { get; private set; }
    public ServiceLevelAgreement ServiceLevelAgreement { get; private set; }
    [MaxLength(80)] public string ServiceTitle { get; private set; }
    [MaxLength(4096)] public string ServiceDescription { get; private set; }
    private readonly List<Jurisdiction> _jurisdictions = [];
    public IReadOnlyCollection<Jurisdiction> Jurisdictions => _jurisdictions;

    protected Service(ServiceType serviceType,
        ServiceLevelAgreement serviceLevelAgreement, string serviceTitle,
        string serviceDescription)
    {
        ServiceType = serviceType;
        ServiceLevelAgreement = serviceLevelAgreement;
        ServiceTitle = serviceTitle;
        ServiceDescription = serviceDescription;
    }
    
    
}