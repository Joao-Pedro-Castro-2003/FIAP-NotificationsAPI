using MassTransit;
using FiapCloudGames.Contracts;
namespace NotificationsAPI.Messaging;
public sealed class UserCreatedConsumer(ILogger<UserCreatedConsumer> log) : IConsumer<UserCreatedEvent>
{
    public Task Consume(ConsumeContext<UserCreatedEvent> c)
    {
        log.LogInformation("E-MAIL SIMULADO para {Email}: Bem-vindo, {Name}!", c.Message.Email, c.Message.Name);
        return Task.CompletedTask;
    }
}
public sealed class PaymentProcessedConsumer(ILogger<PaymentProcessedConsumer> log) : IConsumer<PaymentProcessedEvent>
{
    public Task Consume(ConsumeContext<PaymentProcessedEvent> c)
    {
        log.LogInformation("E-MAIL SIMULADO para usuario {UserId}: jogo {GameId}, compra {Status}. {Reason}", c.Message.UserId, c.Message.GameId, c.Message.Approved
            ? "aprovada"
            : "rejeitada", c.Message.Reason);

        return Task.CompletedTask;
    }
}
