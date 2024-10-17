using PwdGen.Services.DTO;

namespace PwdGen.Services.Interfaces
{
    public interface IPasswordService
    {
        PasswordDTO Generate(PasswordDTO passwordDTO);
    }
}
