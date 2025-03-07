using SanTomas.Application.Users.Dtos.Requests;
using SanTomas.Application.Users.Dtos.Responses;

namespace SanTomas.Application.Users.Services.Interfaces;

public interface IUsersApplicationService
{
    UserResponse Insert(UserInsertRequest request);
    UserResponse GetById(int id);
    UserResponse Update(int id, UserUpdateRequest request);
    UserResponse Delete(int id);
}