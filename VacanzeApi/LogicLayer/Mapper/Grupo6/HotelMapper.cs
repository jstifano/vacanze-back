using System.Collections.Generic;
using vacanze_back.VacanzeApi.LogicLayer.DTO;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo6;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.Common.Entities.Grupo6;
using vacanze_back.VacanzeApi.LogicLayer.Command;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo6;
using vacanze_back.VacanzeApi.Common.Exceptions;


namespace vacanze_back.VacanzeApi.LogicLayer.Mapper.Grupo6{

    public class HotelMapper : Mapper<HotelDTO, Hotel> {

        public HotelDTO CreateDTO(Hotel entity){
            HotelValidatorCommand command =  CommandFactory.HotelValidatorCommand(entity);
            command.Execute();
            Hotel hotel =  (Hotel) entity;
            HotelDTO HotelDTO = DTOFactory.CreateHotelDTO(hotel.Id, hotel.Name, hotel.AmountOfRooms, 
                                            hotel.RoomCapacity , hotel.IsActive, hotel.AddressSpecification,
                                            hotel.PricePerRoom, hotel.Website, hotel.Phone, hotel.Picture,
                                            hotel.Stars, hotel.Location.Id);
            return HotelDTO;
        }

        public Hotel CreateEntity(HotelDTO hotelDto){
            HotelDTOValidatorCommand command =  CommandFactory.HotelDTOValidatorCommand(hotelDto);
            command.Execute();
            Hotel entity = EntityFactory.createHotel(hotelDto.Id, hotelDto.Name, hotelDto.AmountOfRooms, 
                                            hotelDto.RoomCapacity, hotelDto.IsActive, hotelDto.AddressSpecification,
                                            hotelDto.PricePerRoom, hotelDto.Website, hotelDto.Phone ,
                                            hotelDto.Picture, hotelDto.Stars, hotelDto.Location.Id);
            
            return entity;
        }

        public List<HotelDTO> CreateDTOList(List<Hotel> entities){
            List<HotelDTO> dtos = new List<HotelDTO>();
            foreach(Entity entity in entities){
                Hotel hotel = (Hotel) entity;            
                HotelValidatorCommand command =  CommandFactory.HotelValidatorCommand(hotel);
                command.Execute();
                dtos.Add(DTOFactory.CreateHotelDTO(hotel.Id, hotel.Name, hotel.AmountOfRooms, 
                                            hotel.RoomCapacity , hotel.IsActive, hotel.AddressSpecification,
                                            hotel.PricePerRoom, hotel.Website, hotel.Phone, hotel.Picture,
                                            hotel.Stars, hotel.Location.Id));
            }
            return dtos;
        }

        public List<Hotel> CreateEntityList(List<HotelDTO> dtos){
            List<Hotel> entities = new List<Hotel>();
            foreach(HotelDTO hotelDto in dtos){
                HotelDTOValidatorCommand command =  CommandFactory.HotelDTOValidatorCommand(hotelDto);
                command.Execute();
                entities.Add(EntityFactory.createHotel(hotelDto.Id, hotelDto.Name, hotelDto.AmountOfRooms, 
                                            hotelDto.RoomCapacity, hotelDto.IsActive, hotelDto.AddressSpecification,
                                            hotelDto.PricePerRoom, hotelDto.Website, hotelDto.Phone ,
                                            hotelDto.Picture, hotelDto.Stars, hotelDto.Location.Id));
            }
            return entities;
        }
    }

}
