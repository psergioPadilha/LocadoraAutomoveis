# Locadora de Veículos

## Projeto
Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net/) 2024.
### Arquitetura:
- DDD
- N-Camadas
### Stack:
- NET 8.0
- ASP.NET MVC
- Microsoft Identity
- Microsoft SQL Server
- Entity Framework Core
- AutoMapper
- Dapper
- FluentResults
- Selenium
### Inclui:
- Testes de Unidade
- Testes de Integração
- Autenticação e Autorização com Microsoft Identity
## Detalhes
O sistema visa facilitar o gerenciamento das operações de uma locadora de automóveis, abrangendo desde o cadastro de funcionários, grupos de automóveis, veículos e clientes até a configuração de preços de aluguéis e devoluções.

O sistema permitirá a criação de usuários para empresas que desejam utilizar a plataforma para gerenciar o aluguel de seus veículos. Usuários administradores dessas empresas terão a capacidade de cadastrar e gerenciar seus funcionários, incluindo a ativação e desativação de contas de usuário. Esses funcionários realizarão tarefas operacionais, como o cadastro de veículos, registro de locações, entre outras atividades relacionadas.

Além disso, o sistema calcula o valor dos aluguéis considerando diversos fatores, como tipo do veículo, plano escolhido e taxas adicionais.

A locadora oferecerá uma lista de taxas e serviços que os clientes poderão adicionar aos aluguéis. Cada taxa ou serviço terá um preço e indicação se é fixo ou calculado por dia, afetando o preço total do aluguel.

Será possível registrar a devolução dos veículos, aplicando multas em caso de atraso. O sistema também permitirá configurar o preço do combustível para inclusão no cálculo dos aluguéis.

O objetivo é proporcionar uma gestão eficiente e uma experiência positiva tanto para os funcionários quanto para os clientes da locadora.

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

---

## Como Usar

#### Clone o Repositório
```
git clone https://github.com/academia-do-programador/LocadoraAutomoveis.git
```

#### Navegue até a pasta raiz da solução
```
cd ControleLocadoraDeAutomoveis
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd ControleLocadoraDeAutomoveis.WebApp
```

#### Execute o projeto
```
dotnet run
```
