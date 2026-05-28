// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.CustomerManagement.Entities;
using SaaSManagement.Core.ServicesManagement.Domain.Primitives;
using SaaSManagement.Core.ServicesManagement.Records;
using SaaSManagement.Core.Shared.Abstractions;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.ServicesManagement.Domain.Entities;

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
    /// <summary>
    /// Method for creating a new <see cref="ServiceLevelAgreement"/> with the given
    /// parameters.
    /// </summary>
    /// <param name="customer"><see cref="Customer"/></param>
    /// <param name="title">String</param>
    /// <param name="text"><see cref="HtmlEncodedText"/></param>
    /// <param name="startingDate">DateTime</param>
    /// <param name="contractLength">Integer</param>
    /// <returns>A new ServiceLevelAgreement object</returns>
    /// <exception cref="SLAException"><see cref="SLAException"/> if title is null, empty, or white spaces.</exception>
    public static ServiceLevelAgreement Create(Customer customer, string title,
        HtmlEncodedText text, DateTime startingDate, int contractLength)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(title))
            throw new SLAException("The title must be a non-empty string.", nameof(ServiceLevelAgreement));
        
        var agreement
            = new ServiceLevelAgreement(customer, title, text, startingDate, contractLength);

        return agreement;
    }
    /// <summary>
    /// Updates the SLA title
    /// </summary>
    /// <param name="title">String</param>
    /// <exception cref="SLAException">If the title is null, empty, or white spaces.</exception>
    public void UpdateTitle(string title)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(title))
            throw new SLAException("The title must be a non-empty string.", nameof(ServiceLevelAgreement));
        Title = title;
    }
    /// <summary>
    /// Updates the AgreementText with the new <see cref="HtmlEncodedText"/> object.
    /// </summary>
    /// <param name="text"><see cref="HtmlEncodedText"/></param>
    public void UpdateAgreementText(HtmlEncodedText text) => AgreementText = text;
    /// <summary>
    /// Closes (inactivate) the contract.
    /// </summary>
    /// <param name="endDate">The date the contract was closed.</param>
    public void CloseContract(DateTime? endDate)
    {
        EndingDate = endDate is null ? DateTime.UtcNow : endDate.Value;
        IsClosed = true;
        Archive();
    }

    public override string GetId() => Id;
}