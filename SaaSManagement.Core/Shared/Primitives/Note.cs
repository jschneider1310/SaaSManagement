// Project: SaaSManagement, 24/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.CustomerManagement.Primitives;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.Shared.Primitives;

public class Note : ValueObject
{
    private NoteId NoteId { get; set; }
    [MaxLength(40)] private string Title { get; set; }
    [MaxLength(400)] private string Content { get; set; }
    private DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; private set; }
    public NoteType NoteType { get; private set; }
    private ClientId ClientId { get; set; }

    public Note(string title, string content, NoteType noteType, ClientId clientId)
    {
        VerifyValidNoteArgument(title, content);
        NoteId = new NoteId(Guid.CreateVersion7().ToString());
        Title = title;
        Content = content;
        NoteType = noteType;
        ClientId = clientId;
        CreatedAt = DateTime.UtcNow;
    }
    /// <summary>
    /// Updates the Note's title.
    /// </summary>
    /// <param name="title">String with max length of 40 characters</param>
    /// <exception cref="NoteArgumentException">If the parameter title is null, empty, or white spaces.</exception>
    public void UpdateTitle(string title)
    { 
        if(!VerifyIf.IsNotEmptyOrNullString(title)) throw new NoteArgumentException($"The Title ({title}) must not be null or empty.");
        Title = title;
        UpdatedAt = DateTime.UtcNow;
    }
    /// <summary>
    /// Updates the Note's content.
    /// </summary>
    /// <param name="content">String with max length of 400 characters</param>
    /// <exception cref="NoteArgumentException">If the parameter content is null, empty, or white spaces.</exception>
    public void UpdateContent(string content)
    { 
        if(!VerifyIf.IsNotEmptyOrNullString(content)) throw new NoteArgumentException($"The Content ({content}) must not be null or empty.");
        Content = content;
        UpdatedAt = DateTime.UtcNow;

    }
    /// <summary>
    /// Updates the title, content, and <see cref="NoteType"/>
    /// </summary>
    /// <param name="title">String with maximum length of 40 characters.</param>
    /// <param name="content">String with maximum length of 400 characters.</param>
    /// <param name="noteType"><see cref="NoteType"/></param>
    /// <exception cref="NoteArgumentException">If the parameters title and content are null, empty, or white spaces.</exception>
    public void UpdateNote(string title, string content, NoteType noteType)
    {
        VerifyValidNoteArgument(title, content);
        Title = title;
        Content = content;
        NoteType = noteType;
        UpdatedAt = DateTime.UtcNow;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return NoteId;
        yield return Title;
        yield return Content;
        yield return CreatedAt;
        yield return ClientId;
    }
    /// <summary>
    /// Private method that validates the string parameters.
    /// </summary>
    /// <param name="title">String with maximum length of 40 characters.</param>
    /// <param name="content">String with maximum length of 400 characters.</param>
    /// <exception cref="NoteArgumentException">If one or both parameters are null, empty, or white spaces.</exception>
    private static void VerifyValidNoteArgument(string title, string content)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(title, content))
            throw new NoteArgumentException($"The arguments Title ({title}) and/or Content ({content}) must not be null or empty.");
    }
}