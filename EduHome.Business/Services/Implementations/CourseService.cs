using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Business.Exceptions;
using EduHome.Business.Helpers;
using EduHome.Business.Services.Abstractions;
using EduHome.Core.Entities;
using EduHome.Core.Enums;
using EduHome.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EduHome.Business.Services.Implementations;

internal class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly ICategoryService _categoryService;
    private readonly ILanguageService _languageService;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly ICourseImageService _courseImageService;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository repository, IMapper mapper, ICategoryService categoryService, ILanguageService languageService, ICloudinaryService cloudinaryService, ICourseImageService courseImageService)
    {
        _repository = repository;
        _mapper = mapper;
        _categoryService = categoryService;
        _languageService = languageService;
        _cloudinaryService = cloudinaryService;
        _courseImageService = courseImageService;
    }

    public async Task<bool> CreateAsync(CourseCreateDto dto, ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            return false;


        var isExistCategory = await _categoryService.IsExistAsync(dto.CategoryId);

        if (isExistCategory is false)
        {
            modelState.AddModelError("CategoryId", "Bele category movcud deyil");
            return false;
        }





        if (!dto.MainImage.CheckSize(2))
        {
            modelState.AddModelError("MainImage", "Sekil olcusu max 2 mb olmalidir");
            return false;
        }
        if (!dto.MainImage.CheckType())
        {
            modelState.AddModelError("MainImage", "Sekil formatinda datalar daxil edin");
            return false;

        }


        if (!dto.HoverImage.CheckSize(2))
        {
            modelState.AddModelError("HoverImage", "Sekil olcusu max 2 mb olmalidir");
            return false;
        }
        if (!dto.HoverImage.CheckType())
        {
            modelState.AddModelError("HoverImage", "Sekil formatinda datalar daxil edin");
            return false;

        }

        foreach (var image in dto.Images)
        {
            if (!image.CheckSize(2))
            {
                modelState.AddModelError("Images", "Sekil olcusu max 2 mb olmalidir");
                return false;
            }
            if (!image.CheckType())
            {
                modelState.AddModelError("Images", "Sekil formatinda datalar daxil edin");
                return false;

            }
        }


        foreach (var courseDetail in dto.CourseDetails)
        {
            var isExistLanguage = await _languageService.IsExistAsync(courseDetail.LanguageId);

            if (isExistLanguage is false)
            {
                modelState.AddModelError("", "Bu language movcud deyil");
                return false;
            }
        }




        var course = _mapper.Map<Course>(dto);



        var mainImagePath = await _cloudinaryService.FileCreateAsync(dto.MainImage);

        CourseImage mainImage = new()
        {
            IsMain = true,
            Course = course,
            Path = mainImagePath
        };

        course.CourseImages.Add(mainImage);



        var hoverImagePath = await _cloudinaryService.FileCreateAsync(dto.HoverImage);

        CourseImage hoverImage = new()
        {
            IsHover = true,
            Course = course,
            Path = mainImagePath
        };

        course.CourseImages.Add(hoverImage);



        foreach (var image in dto.Images)
        {
            var imagePath = await _cloudinaryService.FileCreateAsync(image);

            CourseImage courseImage = new() { Path = imagePath, Course = course };

            course.CourseImages.Add(courseImage);
        }

        await _repository.CreateAsync(course);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var course = await _repository.GetAsync(id);

        if (course is null)
            throw new NotFoundException();

        _repository.Delete(course);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<CourseGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        var courses = await _repository.GetAll(_getIncludeFunction(language)).ToListAsync();

        var dtos = _mapper.Map<List<CourseGetDto>>(courses);

        return dtos;
    }



    public async Task<CourseGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        var category = await _repository.GetAsync(id, _getIncludeFunction(language));

        if (category is null)
            throw new NotFoundException();

        var dto = _mapper.Map<CourseGetDto>(category);

        return dto;
    }

    public async Task<CourseCreateDto> GetCreatedDtoAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        CourseCreateDto dto = new()
        {
            Categories = categories,
            CourseDetails = [new(), new(), new()]
        };

        return dto;
    }

    public async Task<CourseCreateDto> GetCreatedDtoAsync(CourseCreateDto dto)
    {
        var categories = await _categoryService.GetAllAsync();


        dto.Categories = categories;

        return dto;
    }

    public async Task<CourseUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var course = await _repository.GetAsync(id, x => x.Include(x => x.CourseDetails).Include(x => x.CourseImages));

        if (course is null)
            throw new NotFoundException();

        var categories = await _categoryService.GetAllAsync();

        var dto = _mapper.Map<CourseUpdateDto>(course);

        dto.Categories = categories;

        return dto;
    }


    public async Task<CourseUpdateDto> GetUpdatedDtoAsync(CourseUpdateDto dto)
    {
        var course = await _repository.GetAsync(dto.Id, x => x.Include(x => x.CourseDetails).Include(x => x.CourseImages));

        if (course is null)
            throw new NotFoundException();

        var categories = await _categoryService.GetAllAsync();

        dto = _mapper.Map(course, dto);

        dto.Categories = categories;

        return dto;
    }

    public async Task<bool> UpdateAsync(CourseUpdateDto dto, ModelStateDictionary modelState)
    {

        if (!modelState.IsValid)
            return false;

        var existCourse = await _repository.GetAsync(dto.Id, x => x.Include(x => x.CourseDetails).Include(x => x.CourseImages));

        if (existCourse is null)
            throw new NotFoundException();


        var isExistCategory = await _categoryService.IsExistAsync(dto.CategoryId);

        if (isExistCategory is false)
        {
            modelState.AddModelError("CategoryId", "Bele category movcud deyil");
            return false;
        }





        if (!dto.MainImage?.CheckSize(2) ?? false)
        {
            modelState.AddModelError("MainImage", "Sekil olcusu max 2 mb olmalidir");
            return false;
        }
        if (!dto.MainImage?.CheckType() ?? false)
        {
            modelState.AddModelError("MainImage", "Sekil formatinda datalar daxil edin");
            return false;

        }


        if (!dto.HoverImage?.CheckSize(2) ?? false)
        {
            modelState.AddModelError("HoverImage", "Sekil olcusu max 2 mb olmalidir");
            return false;
        }
        if (!dto.HoverImage?.CheckType() ?? false)
        {
            modelState.AddModelError("HoverImage", "Sekil formatinda datalar daxil edin");
            return false;

        }

        foreach (var image in dto.Images ?? [])
        {
            if (!image.CheckSize(2))
            {
                modelState.AddModelError("Images", "Sekil olcusu max 2 mb olmalidir");
                return false;
            }
            if (!image.CheckType())
            {
                modelState.AddModelError("Images", "Sekil formatinda datalar daxil edin");
                return false;

            }
        }


        foreach (var courseDetail in dto.CourseDetails)
        {
            var isExistLanguage = await _languageService.IsExistAsync(courseDetail.LanguageId);

            if (isExistLanguage is false)
            {
                modelState.AddModelError("", "Bu language movcud deyil");
                return false;
            }
        }



        existCourse = _mapper.Map(dto, existCourse);


        if (dto.MainImage is not null)
        {
            var mainImage = existCourse.CourseImages.FirstOrDefault(x => x.IsMain);

            var newImagePath = await _cloudinaryService.FileCreateAsync(dto.MainImage);

            if (mainImage is null)
            {
                CourseImage newMainImage = new() { IsMain = true, Path = newImagePath, Course = existCourse };

                existCourse.CourseImages.Add(newMainImage);
            }
            else
                mainImage.Path = newImagePath;

        }

        if (dto.HoverImage is not null)
        {
            var hoverImage = existCourse.CourseImages.FirstOrDefault(x => x.IsHover);

            var newHoverImagePath = await _cloudinaryService.FileCreateAsync(dto.HoverImage);

            if (hoverImage is null)
            {
                CourseImage newMainImage = new() { IsMain = true, Path = newHoverImagePath, Course = existCourse };

                existCourse.CourseImages.Add(newMainImage);
            }
            else
                hoverImage!.Path = newHoverImagePath;
        }


        foreach (var newImage in dto.Images ?? [])
        {
            string path = await _cloudinaryService.FileCreateAsync(newImage);

            CourseImage image = new() { Path = path, Course = existCourse };

            existCourse.CourseImages.Add(image);
        }

        _repository.Update(existCourse);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteImageAsync(int id)
    {
        await _courseImageService.DeleteAsync(id);
    }

    private static Func<IQueryable<Course>, IIncludableQueryable<Course, object>> _getIncludeFunction(Languages language)
    {
        return x => x.Include(x => x.CourseDetails.Where(x => x.LanguageId == (int)language)).Include(x => x.CourseImages).Include(x => x.Category).ThenInclude(x => x.CategoryDetails.Where(x => x.LanguageId == (int)language));
    }

}
