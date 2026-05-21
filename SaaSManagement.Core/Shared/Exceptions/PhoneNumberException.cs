// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Exceptions;

public sealed class PhoneNumberException(string message) : Exception(message)
{
}