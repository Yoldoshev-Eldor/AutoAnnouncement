namespace AutoAnnouncement.Aplication.Dtos;

public class ConfirmCodeRequest
{
    public string Code { get; set; } = default!;
    public string Email { get; set; } = default!;
}
