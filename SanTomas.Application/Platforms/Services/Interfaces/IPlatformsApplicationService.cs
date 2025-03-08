using SanTomas.Application.Platforms.Dtos.Requests;
using SanTomas.Application.Platforms.Dtos.Responses;

namespace SanTomas.Application.Platforms.Services.Interfaces;

public interface IPlatformsApplicationService
{
    PlatformResponse Insert(PlatformInsertRequest request);
    PlatformResponse GetById(int id);
    PlatformResponse Update(int id, PlatformUpdateRequest request);
    PlatformResponse Delete(int id);
}