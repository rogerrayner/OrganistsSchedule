using System.Reflection;

namespace OrganistsSchedule.Infra.Data;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}