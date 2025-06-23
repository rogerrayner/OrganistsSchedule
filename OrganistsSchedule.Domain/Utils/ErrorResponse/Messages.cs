using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Utils;

public static class Messages
{
    public static readonly ErrorMessage NotFound = new(1001, "{0} não encontrado!");
    public static readonly ErrorMessage AlreadyExists = new(1002, "{0} já existe!");
    public static readonly ErrorMessage InvalidField = new(1003, "O campo {0} é inválido!");
    public static readonly ErrorMessage IntegrationError = new(1004, "Erro na integração com {0}");
    public static readonly ErrorMessage InvalidCpf = new(1005, "O CPF informado é inválido!");
    public static readonly ErrorMessage FullNameError = new(1006, "O nome completo deve ter pelo menos 10 caracteres!");
    public static readonly ErrorMessage FieldRequiredMale = new(1007, "O {0} é obrigatório!");
    public static readonly ErrorMessage FieldRequiredFemale = new(1008, "A {0} é obrigatória!");
    public static readonly ErrorMessage ListNullOrBlank = new(1009, "É necessário informar ao menos um(a) {0}!");
    public static readonly ErrorMessage ListEmpty = new(1010, "A lista de {0} não pode ser vazia!");
    public static readonly ErrorMessage CpfAlreadyExists = new(1011, "Já existe um(a) {0} cadastrado(a) com esse CPF!");
    public static readonly ErrorMessage CepCreateNotFound = new(1012, "O CEP informado não foi encontrado na base de dados dos Correios!");
    public static readonly ErrorMessage GenerationSchedule1013 = new(1013, "Não existem organistas cadastradas para a congregação selecionada!");
    public static readonly ErrorMessage GenerationSchedule1014 = new(1014, "Existe dia de culto sem organista vinculada! Valide os parâmetros de dias de culto de cada organista!");
    public static readonly ErrorMessage GenerationSchedule1015 = new(1015, "Já existe Rodízio gerado com as datas informadas, ou com datas sobrepostas!");
    
}