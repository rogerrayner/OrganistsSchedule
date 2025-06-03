public static class Messages
{
    public const string NotFound = "{0} não encontrado!";
    public const string AlreadyExists = "{0} já existe!";
    public const string InvalidField = "O campo {0} é inválido!";
    public const string IntegrationError = "Erro na integração com {0}";
    public const string InvalidCpf = "O CPF informado é inválido!";
    public const string FullNameError = "O nome completo deve ter pelo menos 10 caracteres!";
    public const string FieldRequiredMale = "O {0} é obrigatório!";
    public const string FieldRequiredFemale = "A {0} é obrigatória!";
    public const string ListNullOrBlank = "É necessário informar ao menos um(a) {0}!";
    public const string ListEmpty = "A lista de {0} não pode ser vazia!";
    public const string CpfAlreadyExists = "Já existe um(a) {0} cadastrado(a) com esse CPF!";


    public static string Format(string template, params object[] args)
        => string.Format(template, args);
}