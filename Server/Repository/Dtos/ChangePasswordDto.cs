using Core.Kernel.Service;

namespace RockPaperScissors.Repository.Dtos;

public class ChangePasswordDto : IDto
{
    public long UserId { get; set; }
    public byte[]? CurrentPassword { get; set; }
    public byte[]? NewPassword { get; set; }
}