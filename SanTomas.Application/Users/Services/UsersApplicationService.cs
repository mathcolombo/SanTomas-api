using AutoMapper;
using Microsoft.Extensions.Logging;
using SanTomas.Application.Users.Dtos.Requests;
using SanTomas.Application.Users.Dtos.Responses;
using SanTomas.Application.Users.Services.Interfaces;
using SanTomas.Domain.Users.Services.Commands;
using SanTomas.Domain.Users.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.Users.Services;

public class UsersApplicationService : IUsersApplicationService
{
    private readonly IUsersService _usersService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UsersApplicationService> _logger;

    public UsersApplicationService(IUsersService usersService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<UsersApplicationService> logger)
    {
        _usersService = usersService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    
    public UserResponse Insert(UserInsertRequest request)
    {
        var command = _mapper.Map<UserInsertCommand>(request);
        
        try
        {
            _unitOfWork.BeginTransaction();
            var user = _usersService.Insert(command);
            _unitOfWork.Commit();
            return _mapper.Map<UserResponse>(user);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public UserResponse GetById(int id)
    {
        var user = _usersService.GetById(id);
        return _mapper.Map<UserResponse>(user);
    }

    public UserResponse Update(int id, UserUpdateRequest request)
    {
        var command = _mapper.Map<UserUpdateCommand>(request);
        
        try
        {
            _unitOfWork.BeginTransaction();
            var user = _usersService.Update(id, command);
            _unitOfWork.Commit();
            return _mapper.Map<UserResponse>(user);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public UserResponse Delete(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var user = _usersService.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<UserResponse>(user);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}