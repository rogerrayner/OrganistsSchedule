using System.Collections;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Infrastructure.Seeds;

public static class CepSeed
{
    private static ICollection<Cep> _addresses = new List<Cep>
    {
        new Cep { Id = 1, CityId = 1, District = "Adhemar Garcia", ZipCode = "89230792", Street = "Rua Barra Santa Salete" },
        new Cep { Id = 2, CityId = 1, District = "Fátima", ZipCode = "89229040", Street = "Rua Anêmonas" },
        new Cep { Id = 3, CityId = 1, District = "Boa Vista", ZipCode = "89205306", Street = "Rua Erhard Wetzel" },
        new Cep { Id = 4, CityId = 1, District = "Bom Retiro", ZipCode = "89222365", Street = "Rua Piratuba" },
        new Cep { Id = 5, CityId = 1, District = "Canto do Rio", ZipCode = "89226730", Street = "Rua Volans" },
        new Cep { Id = 6, CityId = 1, District = "Comasa", ZipCode = "89224405", Street = "Servidão São Jerônimo Emiliane" },
        new Cep { Id = 7, CityId = 1, District = "Costa e Silva", ZipCode = "89218580", Street = "Rua Helena Degelmann" },
        new Cep { Id = 8, CityId = 1, District = "Cubatão", ZipCode = "89226820", Street = "Rua Nossa Senhora dos Anjos" },
        new Cep { Id = 9, CityId = 1, District = "Distrito Pirabeiraba - Canela", ZipCode = "89239560", Street = "Rua Emílio Hardt" },
        new Cep { Id = 10, CityId = 1, District = "Distrito Pirabeiraba - Centro", ZipCode = "89239220", Street = "Rua Joinville" },
        new Cep { Id = 11, CityId = 1, District = "Distrito Pirabeiraba - Rio Bonito", ZipCode = "89239740", Street = "Rua Theodoro Brietzig" },
        new Cep { Id = 12, CityId = 1, District = "Escolinha", ZipCode = "89232485", Street = "Rua Boehmerwald" },
        new Cep { Id = 13, CityId = 1, District = "Espinheiros", ZipCode = "89228760", Street = "Rua Bertoldo Berkembrock" },
        new Cep { Id = 14, CityId = 1, District = "Fátima", ZipCode = "89210681", Street = "Rua Fátima" },
        new Cep { Id = 15, CityId = 1, District = "Floresta", ZipCode = "89212115", Street = "Rua São Lourenço do Oeste" },
        new Cep { Id = 16, CityId = 1, District = "Iririú", ZipCode = "89227250", Street = "Rua Deputado Lauro Carneiro de Loyola" },
        new Cep { Id = 17, CityId = 1, District = "Jardim das Oliveiras", ZipCode = "89209268", Street = "Rua Paula Mayerle Wulf" },
        new Cep { Id = 18, CityId = 1, District = "Jardim Edilene", ZipCode = "89234173", Street = "Avenida Aulo Abrahão Francisco" },
        new Cep { Id = 19, CityId = 1, District = "Jardim Iririú", ZipCode = "89224424", Street = "Avenida Odilon Rocha Ferreira" },
        new Cep { Id = 20, CityId = 1, District = "Jardim Paraíso", ZipCode = "89226618", Street = "Rua Canis Major" },
        new Cep { Id = 21, CityId = 1, District = "Jardim Sofia", ZipCode = "89223620", Street = "Rua Professor Eunaldo Verdi" },
        new Cep { Id = 22, CityId = 1, District = "Jativoca", ZipCode = "89214720", Street = "Rua Santa Marta" },
        new Cep { Id = 23, CityId = 1, District = "Loteamento São Francisco II", ZipCode = "89226666", Street = "Rua Delphinus" },
        new Cep { Id = 24, CityId = 1, District = "Loteamento Tahiti", ZipCode = "89233780", Street = "Rua Adele Hille" },
        new Cep { Id = 25, CityId = 1, District = "Morro do Meio", ZipCode = "89215200", Street = "Estrada Lagoinha" },
        new Cep { Id = 26, CityId = 1, District = "Nova Brasília", ZipCode = "89213300", Street = "Rua Minas Gerais" },
        new Cep { Id = 27, CityId = 1, District = "Paranaguamirim", ZipCode = "89231740", Street = "Rua Esmirna" },
        new Cep { Id = 28, CityId = 1, District = "Parque Joinville", ZipCode = "89225795", Street = "Avenida Miguel Alves Castanha" },
        new Cep { Id = 29, CityId = 1, District = "Petrópolis", ZipCode = "89208870", Street = "Rua Bauru" },
        new Cep { Id = 30, CityId = 1, District = "Pinotti", ZipCode = "89234100", Street = "Rua Paranaguamirim" },
        new Cep { Id = 31, CityId = 1, District = "Pitaguaras", ZipCode = "89215110", Street = "Rua do Campo" },
        new Cep { Id = 32, CityId = 1, District = "Profipo", ZipCode = "89233240", Street = "Rua Cidade de Sumidouro" },
        new Cep { Id = 33, CityId = 1, District = "Santa Barbara", ZipCode = "89225884", Street = "Rua Dezoito de Janeiro" },
        new Cep { Id = 34, CityId = 1, District = "Ulysses Guimarães", ZipCode = "89230650", Street = "Rua Professor Avelino Marcante" },
        new Cep { Id = 35, CityId = 1, District = "Vila Nova", ZipCode = "89237110", Street = "Rua Joaquim Girardi" },
        new Cep { Id = 36, CityId = 1, District = "Vila Paraná", ZipCode = "89228250", Street = "Rua Carmem Miranda" },
        new Cep { Id = 37, CityId = 1, District = "Zona Industrial Norte", ZipCode = "89219655", Street = "Rua Ricardo Alberto Mebs" }

    };

    
    public static ICollection<Cep> Addresses => _addresses;
}