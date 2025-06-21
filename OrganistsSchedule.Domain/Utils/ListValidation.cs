namespace OrganistsSchedule.Domain.Utils;

public static class ListValidation
{
    public static bool IsNullOrEmpty<T>(IEnumerable<T>? lista)
    {
        return lista == null || !lista.Any();
    }
}