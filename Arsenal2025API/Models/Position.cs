using System.Text.Json.Serialization;

namespace Arsenal2025API.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Position>))]
public enum Position
{
    Goalkeeper,
    CentreBack,
    LeftBack,
    RightBack,
    DefensiveMidfielder,
    CentralMidfielder,
    AttackingMidfielder,
    LeftWinger,
    RightWinger,
    Striker
}