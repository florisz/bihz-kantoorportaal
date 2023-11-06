﻿using BerghAdmin.Data.Kentaa;
using BerghAdmin.DbContexts;
using BerghAdmin.General;
using Microsoft.EntityFrameworkCore;

namespace BerghAdmin.Services.Evenementen;

public class GolfdagenService : IGolfdagenService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPersoonService _persoonService;
    private readonly ILogger<GolfdagenService> _logger;

    public GolfdagenService(ApplicationDbContext dbContext, IPersoonService persoonService, ILogger<GolfdagenService> logger)
    {
        _dbContext = dbContext;
        _persoonService = persoonService;
        _logger = logger;
        logger.LogDebug($"GolfdagenService created; threadid={Thread.CurrentThread.ManagedThreadId}, dbcontext={dbContext.ContextId}");
}

    public IEnumerable<Golfdag>? GetAll()
    {
        return _dbContext
            .Golfdagen?
            .Include(e => e.Deelnemers);
    }
    public Golfdag? GetById(int id)
    {
        return _dbContext
            .Golfdagen?
            .FirstOrDefault(e => e.Id == id);
    }

    public Golfdag? GetByTitel(string? titel)
    {
        return _dbContext
            .Golfdagen?
            .FirstOrDefault(e => e.Titel == titel);
    }

    public async Task<ErrorCodeEnum> SaveAsync(Golfdag golfdag)
    {
        _logger.LogDebug($"Entering save golfdag {golfdag.Titel}");
        if (golfdag == null)
        {
            throw new ApplicationException("Golfdag parameter can not be null");
        }

        if (golfdag.Id == 0)
        {
            if (GetByTitel(golfdag.Titel) != null)
            {
                return ErrorCodeEnum.Conflict;
            }

            _dbContext.Golfdagen?.Add(golfdag);
        }
        else
        {
            _dbContext.Golfdagen?.Update(golfdag);
        }
        await _dbContext.SaveChangesAsync();

        return ErrorCodeEnum.Ok;
    }

    public async Task<ErrorCodeEnum> AddDeelnemerAsync(Golfdag golfdag, Persoon persoon)
    {
        _logger.LogDebug($"Entering Add deelnemer {persoon.VolledigeNaam} to {golfdag.Titel}");

        if (golfdag == null) { throw new ApplicationException("parameter golfdag can not be null"); }
        if (persoon == null) { throw new ApplicationException("parameter persoon can not be null"); }

        if (golfdag.Deelnemers?.FirstOrDefault(p => p.Id == persoon.Id) != null)
        {
            return ErrorCodeEnum.Conflict;
        }

        if (golfdag.Deelnemers == null)
        {
            golfdag.Deelnemers = new HashSet<Persoon>();
        }

        golfdag.Deelnemers.Add(persoon);

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation($"Deelnemer added {persoon.VolledigeNaam} to {golfdag.Titel}");
        return ErrorCodeEnum.Ok;
    }

    public async Task<ErrorCodeEnum> AddDeelnemerAsync(Golfdag golfdag, int persoonId)
    {
        if (golfdag == null) { throw new ApplicationException("parameter golfdag can not be null"); }

        var persoon = _persoonService.GetById(persoonId);
        if (persoon == null)
        {
            return ErrorCodeEnum.NotFound;
        }

        return await AddDeelnemerAsync(golfdag, persoon);
    }

    public async Task<ErrorCodeEnum> DeleteDeelnemerAsync(Golfdag golfdag, Persoon persoon)
    {
        if (golfdag == null) { throw new ApplicationException("parameter golfdag can not be null"); }
        if (persoon == null) { throw new ApplicationException("parameter persoon can not be null"); }

        if (golfdag.Deelnemers == null || golfdag.Deelnemers?.FirstOrDefault(p => p.Id == persoon.Id) == null)
        {
            return ErrorCodeEnum.Ok;
        }

        golfdag.Deelnemers.Remove(persoon);

        await _dbContext.SaveChangesAsync();
        
        return ErrorCodeEnum.Ok;
    }

    public async Task<ErrorCodeEnum> DeleteDeelnemerAsync(Golfdag golfdag, int persoonId)
    {
        if (golfdag == null) { throw new ApplicationException("parameter golfdag can not be null"); }

        var persoon = _persoonService.GetById(persoonId);
        if (persoon == null)
        {
            return ErrorCodeEnum.NotFound;
        }

        return await DeleteDeelnemerAsync(golfdag, persoon);
    }

}
