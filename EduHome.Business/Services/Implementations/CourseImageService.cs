using EduHome.Business.Exceptions;
using EduHome.Business.Services.Abstractions;
using EduHome.DataAccess.Repositories.Abstractions.Generic;
using EduHome.DataAccess.Repositories.Abstractions;

namespace EduHome.Business.Services.Implementations;

internal class CourseImageService : ICourseImageService
{
    private readonly ICourseImageRepository _repository;
    private readonly ICloudinaryService _cloudinaryService;

    public CourseImageService(ICourseImageRepository repository, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _cloudinaryService = cloudinaryService;
    }

    public async Task DeleteAsync(int id)
    {

        var image = await _repository.GetAsync(id);

        if (image is null)
            throw new NotFoundException();


        await _cloudinaryService.FileDeleteAsync(image.Path);
        _repository.Delete(image);
        await _repository.SaveChangesAsync();
    }
}
