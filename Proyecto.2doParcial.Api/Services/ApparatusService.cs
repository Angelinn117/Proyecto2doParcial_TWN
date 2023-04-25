using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Services;

public class ApparatusService : IApparatusService
{
    
    private readonly IApparatusRepository _apparatusRepository;

    public ApparatusService(IApparatusRepository apparatusRepository)
    {
        _apparatusRepository = apparatusRepository;
    }
    
    public async Task<ApparatusDto> SaveAsync(ApparatusDto apparatusDto)
    {
        var apparatus = new Apparatus
        {
            FK_idCliente = apparatusDto.FK_idCliente,
            fechaRecepcion = apparatusDto.fechaRecepcion,
            tipoAparato = apparatusDto.tipoAparato,
            marca = apparatusDto.marca,
            descripcionProblematica = apparatusDto.descripcionProblematica,
            descripcionAdicional = apparatusDto.descripcionAdicional,
            ubicacionEstante = apparatusDto.ubicacionEstante,

            CreatedBy = "",
            CreateDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
            
        };

        apparatus = await _apparatusRepository.SaveAsync(apparatus);
        apparatus.Id = apparatus.Id;

        return apparatusDto;
    }

    public async Task<ApparatusDto> UpdateAsync(ApparatusDto apparatusDto)
    {
        var apparatus = await _apparatusRepository.GetById(apparatusDto.Id);

        if (apparatus == null)
            throw new Exception("Apparatus Not Found");

        apparatus.FK_idCliente = apparatusDto.FK_idCliente;
        apparatus.fechaRecepcion = apparatusDto.fechaRecepcion;
        apparatus.tipoAparato = apparatusDto.tipoAparato;
        apparatus.marca = apparatusDto.marca;
        apparatus.descripcionProblematica = apparatusDto.descripcionProblematica;
        apparatus.descripcionAdicional = apparatusDto.descripcionAdicional;
        apparatus.ubicacionEstante = apparatusDto.ubicacionEstante;

        apparatus.UpdatedBy = "";
        apparatus.UpdateDate = DateTime.Now;

        await _apparatusRepository.UpdateAsync(apparatus);

        return apparatusDto;
    }

    public async Task<List<ApparatusDto>> GetAllAsync()
    {
        var apparatuss = await _apparatusRepository.GetAllAsync();
        var apparatussDto =
            apparatuss.Select(c => new ApparatusDto(c)).ToList();
        return apparatussDto;
        
    }

    public async Task<bool> ApparatusExist(int id)
    {
        var apparatus = await _apparatusRepository.GetById(id);
        return (apparatus != null);
    }

    public async Task<ApparatusDto> GetById(int id)
    {
        var apparatus = await _apparatusRepository.GetById(id);
        if (apparatus == null)
            throw new Exception("Apparatus Not Found");
        var apparatusDto = new ApparatusDto(apparatus);
        return apparatusDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _apparatusRepository.DeleteAsync(id);
    }
    
}