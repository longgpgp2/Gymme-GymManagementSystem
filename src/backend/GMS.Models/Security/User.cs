using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace GMS.Models.Security;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public Guid? CreatedById { get; set; }

    public User? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(UpdatedBy))]
    public Guid? UpdatedById { get; set; }

    public User? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    [ForeignKey(nameof(DeletedBy))]
    public Guid? DeletedById { get; set; }

    public User? DeletedBy { get; set; }

    public bool IsDeleted { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? HireDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Salary { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TotalSales { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Commission { get; set; }

    [StringLength(255)]
    public string? Certificate { get; set; }

    public DateTime? PackageEndDate { get; set; }

    [StringLength(50)]
    public string? EmployeeCode { get; set; }

    [ForeignKey(nameof(Manager))]
    public Guid? ManagerId { get; set; }

    public User? Manager { get; set; }

}
