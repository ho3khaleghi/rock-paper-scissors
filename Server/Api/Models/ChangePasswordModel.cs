using Core.Kernel.Helper;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Api.Models;

public class ChangePasswordModel
{
  public long UserId { get; set; }
  public string? CurrentPassword { get; set; }
  public string? NewPassword { get; set; }
}

public static class ChangePasswordModelMapper
{
  public static ChangePasswordDto? ToDto(this ChangePasswordModel? model) =>
    model is null
      ? null
      : new ChangePasswordDto
      {
        UserId = model.UserId,
        CurrentPassword = model.CurrentPassword.Decode(),
        NewPassword = model.NewPassword.Decode()
      };
}