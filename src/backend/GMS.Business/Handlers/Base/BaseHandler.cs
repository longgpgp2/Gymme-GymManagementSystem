using AutoMapper;
using GMS.Business.ConfigurationOptions;
using GMS.Data.UnitOfWorks;

namespace GMS.Business.Handlers.Base;

public class BaseHandler(IUnitOfWork unitOfWork, ICustomMapper mapper)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;

    protected readonly ICustomMapper _mapper = mapper;
}
