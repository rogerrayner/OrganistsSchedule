using System.Reflection;

namespace OrganistsSchedule.Bff;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}