# Password Generator

**Nível:** 2-Intermediário

Gere senhas com base em determinadas características selecionadas pelo usuário.

O objetivo da criação desse projeto é ele faça parte do portfólio, demonstrando um nível de implementação Intermediário.


## 🚀 Começando

Esta aplicação gera strings de texto adequadas para uso como *senhas*, seguindo as características selecionados como comprimento da senha.

![LoremIpsum WinForm](images/password-generator-2.png)


É permitido que se escolha "incrementos de segurança" como:

- Incluir letras maiúsculas;
- Incluir letras minúsculas;
- Incluir números;
- Incluir símbolos;


### 📋 Pré-requisitos

- [.NET](https://dotnet.microsoft.com/pt-br/download)


## ⚙️ Testes unitários

Para a geração de senhas os testes unitários estão cobrindo os seguintes cenários:

- [x] O comprimento da senha gerada deve ser maior que 1
- [x] O comprimento da senha deve acompanhar a quantidade de incrementos de segurança
- [x] O usuário pode selecionar o comprimento da senha gerada
- [x] O usuário pode selecionar 'Include uppercase letters'
- [x] O usuário pode selecionar 'Include lowercase letters'
- [x] O usuário pode selecionar 'Include numbers'
- [x] O usuário pode selecionar 'Include Symbols'
- [x] O usuário pode selecionar todos os incrementos de segurança


### 🔩 Executando os testes

Para executar os testes unitários:

```
dotnet test PasswordGen\PasswordGen.sln --verbosity n
```


## 📦 Implantação

Para executar o exemplo através do Swagger:

```
dotnet run --project PasswordGen\PwdGen.API\PwdGen.API.csproj
```

Em seguida acessar o hyperlink abaixo:
> http://localhost:5047/swagger/index.html


## 🛠️ Construído com

* [Visual Studio](https://visualstudio.microsoft.com/pt-br/) - IDE
* [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/) - Linguagem


## 📄 Licença

Este projeto está sob a licença MIT - veja o arquivo [LICENSE](https://github.com/caiomeletti/password-generator/blob/main/LICENSE) para detalhes.
