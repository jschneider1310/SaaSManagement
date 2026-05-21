// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.Collections.ObjectModel;
using SaaSManagement.Core.Features.CustomerManagement.Entities;
using SaaSManagement.Core.Features.ServicesManagement.Primitives;
using SaaSManagement.Core.Features.ServicesManagement.Records;
using SaaSManagement.Core.Shared.Abstractions;

namespace SaaSManagement.Core.Features.ServicesManagement.Entities;

/// <summary>
/// Represents a Service-Level Agreement for a given SaaS service provided.
/// </summary>
public sealed class ServiceLevelAgreement : Entity<SlaId>
{
    private new SlaId Id { get; set; } = $"SLA-{Ulid.NewUlid()}";
    public Customer Customer { get; private set; }
    public string Title { get; private set; }
    private readonly List<AvailabilityDefinition> _availabilityDefinitions = [];

    public ReadOnlyCollection<AvailabilityDefinition> AvailabilityDefinitions
        => _availabilityDefinitions.AsReadOnly();


    public DateTime StartingDate { get; private set; }
    public DateTime EndingDate { get; private set; }
    public bool IsClosed { get; private set; }
    public int ContractLength { get; private set; }

    private ServiceLevelAgreement() { }

    private ServiceLevelAgreement(Customer user, string title, DateTime startingDate,
        int contractLength)
    {
        Customer = user;
        Title = title;
        StartingDate = startingDate;
        ContractLength = contractLength;
    }

    public static ServiceLevelAgreement Create(Customer customer, string title,
        DateTime startingDate, int contractLength)
    {
        var agreement
            = new ServiceLevelAgreement(customer, title, startingDate, contractLength);

        return agreement;
    }

    public void CloseContract(DateTime? endDate)
    {
        EndingDate = endDate is null ? DateTime.UtcNow : endDate.Value;
        IsClosed = true;
    }

    public void AddAvailabilityDefinition(AvailabilityDefinition availabilityDefinition)
        => _availabilityDefinitions.Add(availabilityDefinition);


    public override string GetId() => Id;
}