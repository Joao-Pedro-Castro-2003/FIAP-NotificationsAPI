using MassTransit;
using NotificationsAPI.Messaging;

var b = WebApplication.CreateBuilder(args); 

b.Services.AddControllers(); 
b.Services.AddEndpointsApiExplorer(); 
b.Services.AddSwaggerGen(); 

b.Services.AddMassTransit(x => 
{ 
    x.AddConsumer<UserCreatedConsumer>(); 
    x.AddConsumer<PaymentProcessedConsumer>(); 
    x.UsingRabbitMq((c, q) => 
    { 
        q.Host(b.Configuration["RabbitMq:Host"] ?? "localhost", h => 
        { 
            h.Username("guest"); h.Password("guest"); 
        }); 

        q.ReceiveEndpoint("notifications-user-created", e => e.ConfigureConsumer<UserCreatedConsumer>(c)); 
        q.ReceiveEndpoint("notifications-payment-processed", e => e.ConfigureConsumer<PaymentProcessedConsumer>(c)); 
    }); 
}); 

var app = b.Build(); 

app.UseSwagger(); 
app.UseSwaggerUI(); 
app.MapControllers();
app.Run(); 
public partial class Program { }
