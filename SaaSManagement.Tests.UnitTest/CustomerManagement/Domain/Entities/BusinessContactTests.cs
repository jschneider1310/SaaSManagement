// Project: SaaSManagement, 03/06/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.CustomerManagement.Domain.Entities;
using SaaSManagement.Core.CustomerManagement.Domain.Primitives;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Tests.UnitTest.CustomerManagement.Domain.Entities;

public class BusinessContactTests
{
    private readonly PhoneNumber DefaultPhone = new PhoneNumber("0044 7957758436");
    private readonly Email DefaultEmail = Email.Create("john.doe@email.com");
    [Theory]
    [InlineData("John Doe", nameof(DefaultPhone), nameof(DefaultEmail), "", "C-01H6X5JQJ3X0YQZ7YQZ7YQZ7YQ")]
    [InlineData("", nameof(DefaultPhone), nameof(DefaultEmail), "Manager", "C-01H6X5JQJ3X0YQZ7YQZ7YQZ7YQ")]
    [InlineData("   ", nameof(DefaultPhone), nameof(DefaultEmail), "Manager", "C-01H6X5JQJ3X0YQZ7YQZ7YQZ7YQ")]
    [InlineData("John Doe", nameof(DefaultPhone), nameof(DefaultEmail), "   ", "C-01H6X5JQJ3X0YQZ7YQZ7YQZ7YQ")]
    public void BusinessContactCannotBeCreatedWithoutRequiredFields(string fullName, string phoneNumber,
        string email, string positionName, string clientId)
    {
        // Arrange
        var phone = new PhoneNumber(phoneNumber);
        var mail = Email.Create(email);
        var cId = new ClientId(clientId);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            BusinessContact.Create(fullName, phone, mail, positionName, cId));

        Assert.NotNull(exception);
    }


}