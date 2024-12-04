using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Abstractions;
using EduHome.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Business.Services.Implementations;

internal class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _repository;
    private readonly IMapper _mapper;

    public LanguageService(ILanguageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<LanguageGetDto>> GetAllAsync()
    {
        var query = _repository.GetAll();

        query = _repository.OrderByDescendingQuery(query, x => x.UpdatedTime);

        var languages = await query.ToListAsync();

        var dtos = _mapper.Map<List<LanguageGetDto>>(languages);

        return dtos;
    }

    public async Task<LanguageGetDto> GetAsync(int id)
    {
        var entity = await _repository.GetAsync(id);

        if (entity is null)
            throw new NotFoundException();

        var dto = _mapper.Map<LanguageGetDto>(entity);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        var result = await _repository.IsExistAsync(x => x.Id == id);

        return result;
    }
}
