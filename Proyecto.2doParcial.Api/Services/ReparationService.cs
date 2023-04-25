using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Services;

public class ReparationService : IReparationService
{
    
    private readonly IReparationRepository _reparationRepository;

    public ReparationService(IReparationRepository reparationRepository)
    {
        _reparationRepository = reparationRepository;
    }
    
    public async Task<ReparationDto> SaveAsync(ReparationDto reparationDto)
    {
        var reparation = new Reparation
        {
            
            FK_idAparato = reparationDto.FK_idAparato,
            FK_idUsuario = reparationDto.FK_idUsuario,
            descripcionReparacion = reparationDto.descripcionReparacion,
            fecha = reparationDto.fecha,

            CreatedBy = "",
            CreateDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
            
        };

        reparation = await _reparationRepository.SaveAsync(reparation);
        reparation.Id = reparation.Id;

        return reparationDto;
    }

    public async Task<ReparationDto> UpdateAsync(ReparationDto reparationDto)
    {
        var reparation = await _reparationRepository.GetById(reparationDto.Id);

        if (reparation == null)
            throw new Exception("Reparation Not Found");

        reparation.FK_idAparato = reparationDto.FK_idAparato;
        reparation.FK_idUsuario = reparationDto.FK_idUsuario;
        reparation.descripcionReparacion = reparationDto.descripcionReparacion;
        reparation.fecha = reparationDto.fecha;

        reparation.UpdatedBy = "";
        reparation.UpdateDate = DateTime.Now;

        await _reparationRepository.UpdateAsync(reparation);

        return reparationDto;
    }

    public async Task<List<ReparationDto>> GetAllAsync()
    {
        var reparations = await _reparationRepository.GetAllAsync();
        var reparationsDto =
            reparations.Select(c => new ReparationDto(c)).ToList();
        return reparationsDto;
        
    }

    public async Task<bool> ReparationExist(int id)
    {
        var reparation = await _reparationRepository.GetById(id);
        return (reparation != null);
    }

    public async Task<ReparationDto> GetById(int id)
    {
        var reparation = await _reparationRepository.GetById(id);
        if (reparation == null)
            throw new Exception("Reparation Not Found");
        var reparationDto = new ReparationDto(reparation);
        return reparationDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _reparationRepository.DeleteAsync(id);
    }
    
}