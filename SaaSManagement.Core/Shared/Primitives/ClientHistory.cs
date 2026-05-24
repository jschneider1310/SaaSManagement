// Project: SaaSManagement, 24/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Primitives;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.Shared.Primitives;

public sealed class ClientHistory : ValueObject
{
    public ClientHistoryId Id { get; private set; }
    [MaxLength(256)] private string Action { get; set; }
    public DateTime Timestamp { get; private set; }
    [MaxLength(60)] public string RecordedBy { get; private set; }
    public ClientId ClientId { get; private set; }


    public ClientHistory(ClientId clientId, string action,
        string recordedBy)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(action, recordedBy))
            throw new ClientHistoryException($"Action or recordedBy parameters are invalid");

        Id = new ClientHistoryId(Guid.CreateVersion7().ToString());
        Timestamp = DateTime.Now;
        ClientId = clientId;
        Action = action;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
        yield return Action;
        yield return Timestamp;
        yield return RecordedBy;
    }
}