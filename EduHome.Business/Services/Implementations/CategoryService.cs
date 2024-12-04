using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Abstractions;
using EduHome.Core.Entities;
using EduHome.Core.Enums;
using EduHome.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EduHome.Business.Services.Implementations;

internal class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly ILanguageService _languageService;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper, ILanguageService languageService)
    {
        _repository = repository;
        _mapper = mapper;
        _languageService = languageService;
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            return false;


        foreach (var categoryDetail in dto.CategoryDetails)
        {

            var isExist = await _languageService.IsExistAsync(categoryDetail.LanguageId);

            if (isExist is false)
            {
                modelState.AddModelError("", "Bu language movcud deyil");
                return false;
            }
        }


        var category = _mapper.Map<Category>(dto);

        await _repository.CreateAsync(category);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repository.GetAsync(id);

        if (category is null)
            throw new NotFoundException();

        _repository.Delete(category);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<CategoryGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        var categories = await _repository.GetAll(include: _getIncludeFunction(language)).ToListAsync();

        var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

        return dtos;
    }



    public async Task<CategoryGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        var category = await _repository.GetAsync(id, include: _getIncludeFunction(language));

        if (category is null)
            throw new NotFoundException();

        var dto = _mapper.Map<CategoryGetDto>(category);

        return dto;
    }

    public async Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var category = await _repository.GetAsync(id, include: x => x.Include(x => x.CategoryDetails));

        if (category is null)
            throw new NotFoundException();

        var dto = _mapper.Map<CategoryUpdateDto>(category);

        return dto;
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            return false;

        var existCategory = await _repository.GetAsync(dto.Id, include: x => x.Include(x => x.CategoryDetails));

        if (existCategory is null)
            throw new NotFoundException();

        foreach (var categoryDetail in dto.CategoryDetails)
        {

            var isExist = await _languageService.IsExistAsync(categoryDetail.LanguageId);

            if (isExist is false)
            {
                modelState.AddModelError("", "Bu language movcud deyil");
                return false;
            }
        }


        existCategory = _mapper.Map(dto, existCategory);

        _repository.Update(existCategory);
        await _repository.SaveChangesAsync();

        return true;
    }


    private static Func<IQueryable<Category>, IIncludableQueryable<Category, object>> _getIncludeFunction(Languages language)
    {
        return x => x.Include(x => x.CategoryDetails.Where(x => x.LanguageId == (int)language));
    }

    public async Task<bool> IsExistAsync(int id)
    {
        var result = await _repository.IsExistAsync(x => x.Id == id);

        return result;
    }
}
