using GMS.Core.Constants;
using GMS.Models.Base;

namespace GMS.Data.Repositories;

public class Repository<T> : RepositoryBase<T, GMSDbContext> where T : class, IBaseEntity
{
    private readonly IUserIdentity _currentUser;

    public Repository(GMSDbContext dataContext, IUserIdentity currentUser)
        : base(dataContext)
    {
        _currentUser = currentUser;
    }

    protected override Guid CurrentUserId
    {
        get
        {
            if (_currentUser != null)
            {
                return _currentUser.UserId;
            }

            return CoreConstants.AdminId;
        }
    }

    protected override string CurrentUserName
    {
        get
        {
            if (_currentUser != null)
            {
                return _currentUser.UserName;
            }

            return "Anonymous";
        }
    }
}
