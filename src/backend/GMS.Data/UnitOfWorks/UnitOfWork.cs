using System;
using GMS.Data.Repositories;
using GMS.Models.Security;
using Microsoft.EntityFrameworkCore.Storage;

namespace GMS.Data.UnitOfWorks;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly GMSDbContext _context;

    private readonly IUserIdentity _currentUser;

     private IRepository<RefreshToken>? _refreshTokenRepository;

    public IRepository<RefreshToken> RefreshTokenRepository => _refreshTokenRepository ??= new Repository<RefreshToken>(_context, _currentUser);


    private bool _disposed = false;

    public UnitOfWork(GMSDbContext context, IUserIdentity currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public GMSDbContext Context => _context;


    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}