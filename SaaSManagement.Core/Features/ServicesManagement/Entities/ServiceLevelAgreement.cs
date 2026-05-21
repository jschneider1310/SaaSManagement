// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Features.CustomerManagement.Entities;
using SaaSManagement.Core.Features.ServicesManagement.Primitives;
using SaaSManagement.Core.Features.ServicesManagement.Records;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.Features.ServicesManagement.Entities;

/// <summary>
/// Represents a Service-Level Agreement for a given SaaS service provided.
/// </summary>
public sealed class ServiceLevelAgreement : Entity<SlaId>
{
    private new SlaId Id { get; set; } = $"SLA-{Ulid.NewUlid()}";
    public Customer Customer { get; private set; }
    public string Title { get; private set; }
    public HtmlEncodedText AgreementText { get; private set; }
    public DateTime StartingDate { get; private set; }
    public DateTime EndingDate { get; private set; }
    public bool IsClosed { get; private set; }
    public int ContractLength { get; private set; }

    private ServiceLevelAgreement() { }

    private ServiceLevelAgreement(Customer user, string title,
        HtmlEncodedText agreementText, DateTime startingDate, int contractLength)
    {
        Customer = user;
        Title = title;
        AgreementText = agreementText;
        StartingDate = startingDate;
        ContractLength = contractLength;
    }

    public static ServiceLevelAgreement Create(Customer customer, string title,
        HtmlEncodedText text, DateTime startingDate, int contractLength)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(title))
            throw new SLAException("The title must be a non-empty string.", nameof(ServiceLevelAgreement));
        
        var agreement
            = new ServiceLevelAgreement(customer, title, text, startingDate, contractLength);

        return agreement;
    }

    public void CloseContract(DateTime? endDate)
    {
        EndingDate = endDate is null ? DateTime.UtcNow : endDate.Value;
        IsClosed = true;
    }

    public override string GetId() => Id;
}