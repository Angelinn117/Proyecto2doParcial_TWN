using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Services;

public class WarrantyService : IWarrantyService
{
    
    private readonly IWarrantyRepository _warrantyRepository;

    public WarrantyService(IWarrantyRepository warrantyRepository)
    {
        _warrantyRepository = warrantyRepository;
    }
    
    public async Task<WarrantyDto> SaveAsync(WarrantyDto warrantyDto)
    {
        var warranty = new Warranty
        {
            
            FK_idAparato = warrantyDto.FK_idAparato,
            FK_idReparacion = warrantyDto.FK_idReparacion,
            aplicacionGarantia = warrantyDto.aplicacionGarantia,
                
            CreatedBy = "",
            CreateDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
            
        };

        warranty = await _warrantyRepository.SaveAsync(warranty);
        warranty.Id = warranty.Id;

        return warrantyDto;
    }

    public async Task<WarrantyDto> UpdateAsync(WarrantyDto warrantyDto)
    {
        var warranty = await _warrantyRepository.GetById(warrantyDto.Id);

        if (warranty == null)
            throw new Exception("Warranty Not Found");

        warranty.FK_idAparato = warrantyDto.FK_idAparato;
        warranty.FK_idReparacion = warrantyDto.FK_idReparacion;
        warranty.aplicacionGarantia = warrantyDto.aplicacionGarantia;

        warranty.UpdatedBy = "";
        warranty.UpdateDate = DateTime.Now;

        await _warrantyRepository.UpdateAsync(warranty);

        return warrantyDto;
    }

    public async Task<List<WarrantyDto>> GetAllAsync()
    {
        var warrantys = await _warrantyRepository.GetAllAsync();
        var warrantysDto =
            warrantys.Select(c => new WarrantyDto(c)).ToList();
        return warrantysDto;
        
    }

    public async Task<bool> WarrantyExist(int id)
    {
        var warranty = await _warrantyRepository.GetById(id);
        return (warranty != null);
    }

    public async Task<WarrantyDto> GetById(int id)
    {
        var warranty = await _warrantyRepository.GetById(id);
        if (warranty == null)
            throw new Exception("Warranty Not Found");
        var warrantyDto = new WarrantyDto(warranty);
        return warrantyDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _warrantyRepository.DeleteAsync(id);
    }
    
}