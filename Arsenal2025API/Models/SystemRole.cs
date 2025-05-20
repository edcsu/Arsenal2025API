using System.Text.Json.Serialization;

namespace Arsenal2025API.Models;

[JsonConverter(typeof(JsonStringEnumConverter<SystemRole>))]
public enum SystemRole
{
    Fan,
    Admin,
    Supervisor,
}