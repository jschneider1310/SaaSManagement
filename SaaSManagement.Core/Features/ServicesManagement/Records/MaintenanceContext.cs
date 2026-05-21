// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Features.ServicesManagement.Records;

public record MaintenanceContext(
    string ContextTitle, string ContextDescription, string ContextWindow,
    string ContextExceptions);