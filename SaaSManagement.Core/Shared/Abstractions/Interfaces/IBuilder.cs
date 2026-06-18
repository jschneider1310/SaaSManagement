// Project: SaaSManagement, 18/06/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Shared.Abstractions.Interfaces;

public interface IBuilder<out T>
{
    T Build();
}