using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using SanTomas.Application.CoursesUsers.Dtos.Requests;
using SanTomas.Application.CoursesUsers.Dtos.Responses;
using SanTomas.Application.CoursesUsers.Services.Interfaces;
using SanTomas.Domain.CoursesUsers.Services.Commands;
using SanTomas.Domain.CoursesUsers.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.CoursesUsers.Services;

public class CoursesUsersApplicationService : ICoursesUsersApplicationService
{
    private readonly ICoursesUsersService _coursesUsersService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CoursesUsersApplicationService> _logger;

    public CoursesUsersApplicationService(ICoursesUsersService coursesUsersService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<CoursesUsersApplicationService> logger)
    {
        _coursesUsersService = coursesUsersService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    
    public CourseUserResponse Insert(CourseUserInsertRequest request)
    {
        Console.WriteLine(">>>>>>>>>>>> " + request);
        var courseUserInsertCommand = _mapper.Map<CourseUserInsertCommand>(request);
        Console.WriteLine(">>>>>>>>>>>> " + courseUserInsertCommand);
        
        try
        {
            _unitOfWork.BeginTransaction();
            var courseUser = _coursesUsersService.Insert(courseUserInsertCommand);
            _unitOfWork.Commit();
            
            return _mapper.Map<CourseUserResponse>(courseUser);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public CourseUserResponse GetById(int id)
    {
        var courseUser = _coursesUsersService.GetById(id);
        return _mapper.Map<CourseUserResponse>(courseUser);
    }

    public CourseUserResponse Update(int id, CourseUserUpdateRequest request)
    {
        var courseUserUpdateCommand = _mapper.Map<CourseUserUpdateCommand>(request);
        
        try
        {
            _unitOfWork.BeginTransaction();
            var courseUser = _coursesUsersService.Update(id, courseUserUpdateCommand);
            _unitOfWork.Commit();
            
            return _mapper.Map<CourseUserResponse>(courseUser);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public CourseUserResponse Delete(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var courseUser = _coursesUsersService.Delete(id);
            _unitOfWork.Commit();
            
            return _mapper.Map<CourseUserResponse>(courseUser);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}