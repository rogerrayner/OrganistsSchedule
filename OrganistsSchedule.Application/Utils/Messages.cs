public static class Messages
{
    public const string NotFound = "{0} não encontrado!";
    public const string AlreadyExists = "{0} já existe!";
    public const string InvalidField = "O campo {0} é inválido!";
    public const string IntegrationError = "Erro na integração com {0}";

    public static string Format(string template, params object[] args)
        => string.Format(template, args);
}