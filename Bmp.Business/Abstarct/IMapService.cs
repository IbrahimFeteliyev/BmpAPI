using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.MapDTOs;


namespace Bmp.Business.Abstarct
{
    public interface IMapService
    {
        IDataResult<List<MapAdminDTO>> GetAllMapsAdmin();
        Task<IResult> AddMapAsync(MapDTO mapAddDTO);
        Task<IResult> UpdateMapAsync(MapDTO mapUpdateDTO, int id);
        IDataResult<MapAdminDTO> GetMapAdminById(int id);
        IResult RemoveMap(int id);
    }
}
