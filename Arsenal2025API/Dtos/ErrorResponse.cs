namespace Arsenal2025API.Dtos;

public record ErrorResponse
{
    public string? TraceId { get; set; }
    public string? Message { get; set; }
    public string? DetailedMessage { get; set; }
    public PathString? Path { get; set; }
    public int StatusCode { get; set; }
    public DateTime Timestamp { get; set; }
}