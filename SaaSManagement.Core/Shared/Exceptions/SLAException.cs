// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Exceptions;

public sealed class SlaException(string message, string? paramName) : Exception($"{message} -  {paramName}")
{
    
}