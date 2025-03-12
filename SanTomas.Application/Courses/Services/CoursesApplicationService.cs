using AutoMapper;
using Microsoft.Extensions.Logging;
using SanTomas.Application.Courses.Dtos.Requests;
using SanTomas.Application.Courses.Dtos.Responses;
using SanTomas.Application.Courses.Services.Interfaces;
using SanTomas.Domain.Courses.Services.Commands;
using SanTomas.Domain.Courses.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;

namespace SanTomas.Application.Courses.Services;

public class CoursesApplicationService : ICoursesApplicationService
{
    private readonly ICoursesService _coursesService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CoursesApplicationService> _logger;

    public CoursesApplicationService(ICoursesService coursesService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<CoursesApplicationService> logger)
    {
        _coursesService = coursesService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public CourseResponse Insert(CourseInsertRequest request)
    {
        var courseInsertCommand = _mapper.Map<CourseInsertCommand>(request);
        
        try
        {
            _unitOfWork.BeginTransaction();
            var course = _coursesService.Insert(courseInsertCommand);
            _unitOfWork.Commit();
            return _mapper.Map<CourseResponse>(course);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public CourseResponse GetById(int id)
    {
        var course = _coursesService.GetById(id);
        return _mapper.Map<CourseResponse>(course);
    }

    public CourseResponse Update(int id, CourseUpdateRequest request)
    {
        var courseUpdateCommand = _mapper.Map<CourseUpdateCommand>(request);
        
        try
        {
            _unitOfWork.BeginTransaction();
            var course = _coursesService.Update(id, courseUpdateCommand);
            _unitOfWork.Commit();
            return _mapper.Map<CourseResponse>(course);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public CourseResponse Delete(int id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var course = _coursesService.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<CourseResponse>(course);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}