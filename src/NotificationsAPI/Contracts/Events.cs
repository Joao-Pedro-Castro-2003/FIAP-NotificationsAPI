namespace FiapCloudGames.Contracts; 
public sealed record UserCreatedEvent(int UserId, string Name, string Email);
public sealed record PaymentProcessedEvent(Guid OrderId, int UserId, int GameId, decimal Price, bool Approved, string Reason);
