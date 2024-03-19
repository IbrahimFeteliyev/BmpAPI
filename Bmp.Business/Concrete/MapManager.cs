using AutoMapper;
using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.MapDTOs;


namespace Bmp.Business.Concrete
{
    public class MapManager : IMapService
    {
        private readonly IMapDAL _mapDAL;
        private readonly IMapper _mapper;
        public MapManager(IMapDAL mapDAL, IMapper mapper)
        {
            _mapDAL = mapDAL;
            _mapper = mapper;
        }

        public async Task<IResult> AddMapAsync(MapDTO mapAddDTO)
        {
            var map = _mapper.Map<Map>(mapAddDTO);
            map.CreatedDate = DateTime.UtcNow;
            _mapDAL.Add(map);
            return new SuccessResult("Map Added");
        }

        public IDataResult<List<MapAdminDTO>> GetAllMapsAdmin()
        {
            var maps = _mapDAL.GetAll();
            var mapDTOs = _mapper.Map<List<MapAdminDTO>>(maps);
            return new SuccessDataResult<List<MapAdminDTO>>(mapDTOs);
        }

        public IDataResult<MapAdminDTO> GetMapAdminById(int id)
        {
            var map = _mapDAL.Get(x => x.Id == id);
            var mapDTO = _mapper.Map<MapAdminDTO>(map);
            return new SuccessDataResult<MapAdminDTO>(mapDTO);
        }

        public IResult RemoveMap(int id)
        {
            var map = _mapDAL.Get(x => x.Id == id);
            _mapDAL.Delete(map);
            return new SuccessResult("Map Deleted");
        }

        public async Task<IResult> UpdateMapAsync(MapDTO mapUpdateDTO, int id)
        {
            var map = _mapDAL.Get(x => x.Id == id);
            var mapDTO = _mapper.Map<Map>(map);
            mapDTO.UpdatedDate = DateTime.UtcNow;
            _mapDAL.Update(mapDTO);
            return new SuccessResult("Map Updated");
        }
    }
}
