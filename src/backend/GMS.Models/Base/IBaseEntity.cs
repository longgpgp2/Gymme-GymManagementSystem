using GMS.Models.Security;

namespace GMS.Models.Base;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreatedAt { get; set; }
    Guid? CreatedById { get; set; }
    User? CreatedBy { get; set; }
    DateTime? UpdatedAt { get; set; }
    Guid? UpdatedById { get; set; }
    User? UpdatedBy { get; set; }
    DateTime? DeletedAt { get; set; }
    Guid? DeletedById { get; set; }
    User? DeletedBy { get; set; }
    bool IsDeleted { get; set; }
}
