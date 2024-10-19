using System.Collections;

namespace OrganistsSchedule.Application.Interfaces;

public interface IReadOnlyList<out T> : IEnumerable<T>, IEnumerable
{
    /// <summary>Gets the element at the specified index in the read-only list.</summary>
    /// <param name="index">The zero-based index of the element to get.</param>
    /// <returns>The element at the specified index in the read-only list.</returns>
    T this[int index] { get; }
}