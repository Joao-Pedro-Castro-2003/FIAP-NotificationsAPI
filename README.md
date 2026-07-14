# FIAP Cloud Games - NotificationsAPI

Microsservico responsavel por simular notificacoes por e-mail dentro da plataforma Cloud Games.

Este servico faz parte do Tech Challenge Fase 2 da FIAP e atua de forma assincrona, consumindo eventos publicados pelos outros microsservicos.

## Responsabilidades

- Consumir evento de usuario criado.
- Simular envio de e-mail de boas-vindas.
- Consumir evento de pagamento processado.
- Simular envio de e-mail informando compra aprovada ou rejeitada.
- Registrar as notificacoes no console/log.

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- RabbitMQ
- MassTransit
- Swagger
- Docker

## Funcionamento

A NotificationsAPI nao executa o fluxo principal por endpoints de negocio. Sua funcao principal e consumir eventos e registrar notificacoes simuladas.

Quando um usuario e criado, a UsersAPI publica `UserCreatedEvent` e a NotificationsAPI registra um e-mail simulado de boas-vindas.

Quando um pagamento e processado, a PaymentsAPI publica `PaymentProcessedEvent` e a NotificationsAPI registra um e-mail simulado com o resultado da compra.

## Eventos consumidos

```text
UserCreatedEvent
PaymentProcessedEvent
```

## Exemplos de notificacao

```text
E-MAIL SIMULADO para usuario 1: bem-vindo a Cloud Games.
```

```text
E-MAIL SIMULADO para usuario 1: jogo 3, compra aprovada.
```

```text
E-MAIL SIMULADO para usuario 1: jogo 3, compra rejeitada.
```

## Variaveis de ambiente

| Variavel | Descricao | Exemplo |
| --- | --- | --- |
| `ASPNETCORE_ENVIRONMENT` | Ambiente da aplicacao | `Development` |
| `RabbitMq__Host` | Host do RabbitMQ | `rabbitmq` |
| `RabbitMq__Username` | Usuario do RabbitMQ | `guest` |
| `RabbitMq__Password` | Senha do RabbitMQ | `guest` |

## Executando localmente

```bash
dotnet restore
dotnet run --project src/NotificationsAPI/NotificationsAPI.csproj
```

Swagger:

```text
http://localhost:5004/swagger
```

## Executando com Docker

```bash
docker build -t fiap-notifications-api:latest .
docker run -p 5004:8080 fiap-notifications-api:latest
```

No projeto completo, a execucao recomendada e pelo repositorio de orquestracao, usando Docker Compose ou Kubernetes.

