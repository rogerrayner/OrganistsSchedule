public static class Permissions
{
    public static readonly string[] Policies = [
        "admin", "teste",
        "read:address", "create:address", "update:address", "delete:address",
        "read:cep", "create:cep", "update:cep", "delete:cep",
        "read:city", "create:city", "update:city", "delete:city",
        "read:country", "create:country", "update:country", "delete:country",
        "read:email", "create:email", "update:email", "delete:email",
        "read:phone", "create:phone", "update:phone", "delete:phone",
        "read:congregation", "create:congregation", "update:congregation", "delete:congregation",
        "read:holy-service", "create:holy-service", "update:holy-service", "delete:holy-service",
        "read:organist", "create:organist", "update:organist", "delete:organist",
        "read:parameter-schedule", "create:parameter-schedule", "update:parameter-schedule", "delete:parameter-schedule",
        "process:generate-schedule", "process:set-organist-congregation", "process:export-schedule",
    ];
}