# Exemplo de uso do Entity Framework Core Value Converter

### Softwares necessários:

- .NET 5
- MySQL


Para realizar a conversão você deve por o atributo ```[SensitiveData]``` na propriedade da classe.

```
    public class ExampleEntity
    {
        public int Id { get; set; }

        [SensitiveData]
        public string SensitiveInfo { get; set; }
    }
```

Isso faz com que antes de persistir o dado, seja feita uma criptografia e conversão para uma string em base64. E ao ler o mesmo dado, é realizada a descriptografia e conversão para a string original.

O provedor de criptografia usado no exemplo é o AES. O mesmo pode ser alterado.

## Como iniciar

### Altere as informações de autenticação de conexão em ```appsettings.Developmentjson```

```
"ApplicationSettings": {
    "DefaultConnection": "server=localhost;port=3306;uid=;pwd=;database=ef_core_value_converter;"
  }
```

### Clone o repositório e execute os seguintes comandos:

```
cd Api
dotnet run
```

Acesse: https://localhost:5001/ para visualizar o Swagger. As rotas mapeadas realizam a listagem dos dados da base e a inserção de um novo, respectivamente.