using AutoMapper;
using GMS.Models.ConfigurationOptions;
using GMS.Data.UnitOfWorks;

namespace GMS.Models.Handlers.Base;

public class BaseHandler(IUnitOfWork unitOfWork, ICustomMapper mapper)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;

    protected readonly ICustomMapper _mapper = mapper;
}
