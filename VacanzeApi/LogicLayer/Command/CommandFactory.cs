using System;
using System.Collections.Generic;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.Common.Entities.Grupo1;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo3;
using vacanze_back.VacanzeApi.Common.Entities.Grupo3;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo3;
using vacanze_back.VacanzeApi.Common.Entities.Grupo12;
using vacanze_back.VacanzeApi.Common.Entities.Grupo13;
using vacanze_back.VacanzeApi.Common.Entities.Grupo14;
using vacanze_back.VacanzeApi.Common.Entities.Grupo2;
using vacanze_back.VacanzeApi.Common.Entities.Grupo4;
using vacanze_back.VacanzeApi.Common.Entities.Grupo5;
using vacanze_back.VacanzeApi.Common.Entities.Grupo6;
using vacanze_back.VacanzeApi.Common.Entities.Grupo7;
using vacanze_back.VacanzeApi.Common.Entities.Grupo10;
using vacanze_back.VacanzeApi.Common.Entities.Grupo9;
using vacanze_back.VacanzeApi.Common.Entities.Grupo12;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo9;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo6;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo8;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo8;
using vacanze_back.VacanzeApi.Common.Entities.Grupo8;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo1;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo12;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo13;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo14;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo2;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo4;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo5;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo6;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo7;
using vacanze_back.VacanzeApi.LogicLayer.Command.Grupo9;
using vacanze_back.VacanzeApi.LogicLayer.Command.Locations;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo6;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo7;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo9;
using vacanze_back.VacanzeApi.Services.Controllers.Grupo14;

namespace vacanze_back.VacanzeApi.LogicLayer.Command
{
    public class CommandFactory
    {

        public static AddVehicleCommand CreateAddVehicleCommand(Vehicle vehicle)
        {
            return new AddVehicleCommand(vehicle);
        }

        public static GetVehicleByIdCommand CreateGetVehicleByIdCommand(int vehicleId)
        {
            return new GetVehicleByIdCommand(vehicleId);
        }

        public static GetVehiclesCommand CreateGetVehiclesCommand()
        {
            return new GetVehiclesCommand();
        }

        public static GetAvailableVehiclesByLocationCommand CreateGetAvailableVehiclesByLocationCommand(int locationId)
        {
            return new GetAvailableVehiclesByLocationCommand(locationId);
        }
        
        public static UpdateVehicleCommand CreateUpdateVehicleCommand(Vehicle vehicle)
        {
            return new UpdateVehicleCommand(vehicle);
        }

        public static UpdateVehicleStatusCommand CreateUpdateVehicleStatusCommand(int vehicleId, bool status)
        {
            return new UpdateVehicleStatusCommand(vehicleId, status);
        }

        public static AddBrandCommand CreateAddBrandCommand(Brand brand)
        {
            return new AddBrandCommand(brand);
        }

        public static GetBrandByIdCommand CreateGetBrandByIdCommand(int brandId)
        {
            return new GetBrandByIdCommand(brandId);
        }

        public static GetBrandsCommand CreateGetBrandsCommand()
        {
            return new GetBrandsCommand();
        }

        public static UpdateBrandCommand CreateUpdateBrandCommand(Brand brand)
        {
            return new UpdateBrandCommand(brand);
        }

        public static AddModelCommand CreateAddModelCommand(Model model)
        {
            return new AddModelCommand(model);
        }

        public static GetModelByIdCommand CreateGetModelByIdCommand(int modelId)
        {
            return new GetModelByIdCommand(modelId);
        }

        public static GetModelsCommand CreateGetModelsCommand()
        {
            return new GetModelsCommand();
        }

     
        public static GetModelsByBrandCommand CreateGetModelsByBrandCommand(int brandId)
        {
            return new GetModelsByBrandCommand(brandId);
        }

        public static UpdateModelCommand CreateUpdateModelCommand(Model model)
        {
            return new UpdateModelCommand(model);
        }

        public static RestaurantValidatorCommand CreateGetRestaurantValidatorCommand(Restaurant restaurant)
        {
            return new RestaurantValidatorCommand(restaurant);
        }
        
        public static GetRestaurantCommand CreateGetRestaurantCommand(int id)
        {
            return new GetRestaurantCommand(id);
        }

        public static AddRestaurantCommand CreateAddRestaurantCommand(RestaurantDto restaurantDto)
        {
            return new AddRestaurantCommand(restaurantDto);
        }

        public static GetRestaurantsCommand CreateGetRestaurantsCommand()
        {
            return new GetRestaurantsCommand();
        }
        
        public static GetRestaurantsByCityCommand CreateGetRestaurantsByCityCommand(int locationId)
        {
            return new GetRestaurantsByCityCommand(locationId);
        }
        
        public static UpdateRestaurantCommand CreateUpdateRestaurantCommand(RestaurantDto restaurantDto)
        {
            return new UpdateRestaurantCommand(restaurantDto);
        }
        
        public static DeleteRestaurantCommand CreateDeleteRestaurantCommand(int id)
        {
            return new DeleteRestaurantCommand(id);
        }

        public static GetClaimByIdCommand CreateGetClaimByIdCommand(int claimId)
        {
            return new GetClaimByIdCommand(claimId);
        }

        public static GetClaimsByStatusCommand CreateGetClaimsByStatusCommand(string status)
        {
            return new GetClaimsByStatusCommand(status);
        }

        public static GetClaimsByDocumentCommand CreateGetClaimsByDocumentCommand(string document)
        {
            return new GetClaimsByDocumentCommand(document);
        }

        public static AddClaimCommand CreateAddClaimCommand(ClaimDto dto)
        {
            return new AddClaimCommand(dto);
        }

        public static DeleteClaimByIdCommand CreateDeleteClaimByIdCommand(int id)
        {
            return new DeleteClaimByIdCommand(id);
        }

        public static UpdateClaimCommand CreateUpdateClaimCommand(int id, ClaimDto fieldsToUpdate)
        {
            return new UpdateClaimCommand(id, fieldsToUpdate);
        }

        public static ValidateClaimUpdateCommand CreateValidateClaimUpdateCommand(Claim claim)
        {
            return new ValidateClaimUpdateCommand(claim);
        }

        public static ValidateClaimCreationCommand CreateValidateClaimCreationCommand(Claim claim)
        {
            return new ValidateClaimCreationCommand(claim);
        }

        public static GetBaggageByPassportCommand CreateGetBaggageByPassportCommand(string passport)
        {
            return new GetBaggageByPassportCommand(passport);
        }

        public static GetBaggageByStatusCommand CreateGetBaggageByStatusCommand(string status)
        {
            return new GetBaggageByStatusCommand(status);
        }

        public static UpdateBaggageCommand CreateUpdateBaggageCommand(int id, BaggageDTO baggage)
        {
            return new UpdateBaggageCommand(id, baggage);
        }

        public static GetBaggageByIdCommand CreateGetBaggageByIdCommand(int id)
        {
            return new GetBaggageByIdCommand(id);
        }

        public static ValidateBaggageUpdateCommand CreateValidateBaggageUpdateCommand(Baggage baggage)
        {
            return new ValidateBaggageUpdateCommand(baggage);
        }

        public static AddHotelCommand createAddHotelCommand(Hotel hotel)
        {
            return new AddHotelCommand(hotel);
        }

        public static GetHotelByIdCommand GetHotelByIdCommand(int id)
        {
            return new GetHotelByIdCommand(id);
        }

        public static GetHotelImageCommand GetHotelImageCommand(int id)
        {
            return new GetHotelImageCommand(id);
        }

        public static GetHotelsCommand GetHotelsCommand()
        {
            return new GetHotelsCommand();
        }

        public static GetHotelsByCityCommand GetHotelsByCityCommand(int city)
        {
            return new GetHotelsByCityCommand(city);
        }

        public static DeleteHotelCommand DeleteHotelCommand(int id)
        {
            return new DeleteHotelCommand(id);
        }

        public static UpdateHotelCommand UpdateHotelCommand(int id, Hotel hotel)
        {
            return new UpdateHotelCommand(id, hotel);
        }

        public static AddFlightCommand AddFlightCommand(FlightDTO _flight)
        {
            return new AddFlightCommand(_flight);
        }

        public static GetFindFlightCommand GetFlightIdCommand(int _id)
        {
            return new GetFindFlightCommand(_id);
        }

        public static GetFindFlightIdCommand GetFindFlightIdEntityCommand(int _id)
        {
            return new GetFindFlightIdCommand(_id);
        }
        public static GetAirplaneByIdCommand GetFindPlaneIdCommand(int _id)
        {
            return new GetAirplaneByIdCommand(_id);
        }


        public static UpdateFlightCommand UpdateFlightCommand(Flight _flight)
        {
            return new UpdateFlightCommand(_flight);
        }

         public static DeleteFlightCommand DeleteFlightCommand(int _idflight)
        {
            return new DeleteFlightCommand(_idflight);
        }
        
        public static GetFlightListCommand getListFlightCommand(){
            return new GetFlightListCommand();
        }
        public static GetByDateCommand getByDateFlightCommand(string a, string b){
            return new GetByDateCommand(a,b);
        }
		public static HotelValidatorCommand HotelValidatorCommand(Hotel hotel)
        {
            return new HotelValidatorCommand(hotel);
        }
        public static HotelDTOValidatorCommand HotelDTOValidatorCommand(HotelDTO hotel)
        {
            return new HotelDTOValidatorCommand(hotel);
        }

        public static AddLocationCommand createAddLocationCommand(Location location)
        {
            return new AddLocationCommand(location);
        }

        public static GetLocationByIdCommand GetLocationByIdCommand(int id)
        {
            return new GetLocationByIdCommand(id);
        }

        public static DeleteLocationCommand DeleteLocationCommand(int id)
        {
            return new DeleteLocationCommand(id);
        }

        public static GetLocationsCommand GetLocationsCommand()
        {
            return new GetLocationsCommand();
        }

        public static GetCountriesCommand GetCountriesCommand()
        {
            return new GetCountriesCommand();
        }  

        public static GetAirplaneCommand GetAirplaneCommand()
        {
            return new GetAirplaneCommand();
        } 
        public static GetCitiesByCountryCommand GetCitiesByCountryCommand(int id)
        {
            return new GetCitiesByCountryCommand(id);
        }

        public static GetSaleFlightCommand GetSaleFlightCommand(int origin, int destination, DateTime dateArrival, DateTime dateDeparute)
        {
            return new GetSaleFlightCommand(origin, destination, dateArrival, dateDeparute);
        }
        public static PostSaleFlightCommand PostSaleFlightCommand(List<PostSaleFlight> postflight)
        {
            return new PostSaleFlightCommand(postflight);
        }

        public static PostCheckBaggageCommand PostCheckBaggageCommand(List<CheckinBaggage> checkbag)
        {
            return new PostCheckBaggageCommand(checkbag);
        }



        public static GetEmployeesCommand CreateGetEmployeesCommand()
        {
            return new GetEmployeesCommand();
        }

        public static GetRolesCommand CreateGetRolesCommand()
        {
            return new GetRolesCommand();
        }

        public static GetRolesForUserCommand CreateGetRolesForUserCommand(User user)
        {
            return new GetRolesForUserCommand(user);
        }

        public static GetUserByIdCommand CreateGetUserByIdCommand(int id)
        {
            return new GetUserByIdCommand(id);
        }

        public static UpdateUserCommand CreateUpdateUserCommand(User user, int id)
        {
            return new UpdateUserCommand(user, id);
        }

        public static AddReservationFlightCommand CreateAddReservationFlightCommand(FlightRes flight)
        {
            return new AddReservationFlightCommand(flight);
        }

        public static GetReservationFlightByUserCommand CreateGetReservationFlightByUserCommand(int id_user)
        {
            return new GetReservationFlightByUserCommand(id_user);
        }

        public static GetIdReturnCityCommand CreateGetIdReturnCityCommand(List<string> city_names)
        {
            return new GetIdReturnCityCommand(city_names);
        }

        public static DeleteReservationCommand CreateDeleteReservationCommand(int id)
        {
            return new DeleteReservationCommand(id);
        }

        public static GetReservationsByDateICommand CreateGetReservationsByDateICommand(int departure, int arrival, string departuredate, int numpas)
        {
            return new GetReservationsByDateICommand(departure, arrival, departuredate, numpas);
        }

        public static GetReservationsByDateIVCommand CreateGetReservationsByDateIVCommand(int departure, int arrival, string departuredate, string arrivaldate, int numpas)
        {
            return new GetReservationsByDateIVCommand(departure, arrival, departuredate, arrivaldate, numpas);
        }

        public static AddCruiserCommand CreateAddCruiserCommand(CruiserDTO cruiserDto)
        {
            return new AddCruiserCommand(cruiserDto);
        }

         public static GetCruiserCommand CreateGetCruiserCommand(int id)
        {
            return new GetCruiserCommand(id);
        }

        public static AddLayoverCommand CreateAddLayoverCommand(LayoverDTO layoverDto)
        {
            return new AddLayoverCommand(layoverDto);
        }

        public static DeleteLayoverCommand CreateDeleteLayoverCommand(int id)
        {
            return new DeleteLayoverCommand(id);
        }

        public static DeleteCruiserCommand CreateDeleteCruiserCommand(int id)
        {
            return new DeleteCruiserCommand(id);
        }

        public static CruiserValidatorCommand CreateGetCruiserValidatorCommand(Cruiser cruiser)
        {
            return new CruiserValidatorCommand(cruiser);
        }

        public static UpdateCruiserCommand CreateUpdateCruiserCommand(CruiserDTO cruiserDto)
        {
            return new UpdateCruiserCommand(cruiserDto);
        }

        public static GetCruisersCommand CreateGetCruisersCommand()
        {
            return new GetCruisersCommand();
        }

        public static GetLayoversCommand CreateGetLayoversCommand(int id)
        {
            return new GetLayoversCommand(id);
        }
    
        /*GRUPO14*/
        public static GetResRestaurantByIdCommand GetResRestaurantByIdCommand(int id)
        {
            return new GetResRestaurantByIdCommand(id);
        }
        public static DeleteResRestaurantCommand DeleteResRestaurantCommand(int id)
        {
            return new DeleteResRestaurantCommand(id);
        }

        public static GetResRestaurantNotPayByIdCommand GetResRestaurantNotPayByIdCommand(int id)
        {
            return new GetResRestaurantNotPayByIdCommand(id);
        }

        #region Grupo 13
        public static AddReservationRoomCommand CreateAddReservationRoomCommand(ReservationRoom reservationRoom)
        {
            return new AddReservationRoomCommand(reservationRoom);
        }

        public static DeleteReservationRoomCommand CreateDeleteReservationRoomCommand(int reservationId)
        {
            return new DeleteReservationRoomCommand(reservationId);
        }

        public static GetReservationRoomsForUserCommand CreateGetReservationRoomsForUserCommand(int id)
        {
            return new GetReservationRoomsForUserCommand(id);
        }

        public static GetReservationRoomCommand CreateGetReservationRoomCommand(int reservationId)
        {
            return new GetReservationRoomCommand(reservationId);
        }

        public static UpdateReservationRoomCommand CreateUpdateReservationRoomCommand(ReservationRoom reservationRoom)
        {
            return new UpdateReservationRoomCommand(reservationRoom);
        }

        public static AddReservationVehicleCommand CreateAddReservationVehicleCommand(
            ReservationVehicle reservationVehicle)
        {
            return new AddReservationVehicleCommand(reservationVehicle);
        }

        public static FindReservationVehicleCommand CreateFindReservationVehicleCommand(int reservationId)
        {
            return new FindReservationVehicleCommand(reservationId);
        }

        public static GetReservationVehicleByUserCommand CreateGetReservationVehicleByUserCommand(int userId)
        {
            return new GetReservationVehicleByUserCommand(userId);
        }
        
        public static DeleteReservationVehicleCommand CreateDeleteReservationVehicleCommand(int id)
        {
            return new DeleteReservationVehicleCommand(id);
        }

        public static UpdateReservationVehicleCommand CreateUpdateReservationVehicleCommand(
            ReservationVehicle reservationVehicle)
        {
            return new UpdateReservationVehicleCommand(reservationVehicle);
        }
        #endregion
        
        //Grupo 1
        public static GetUserCommand loginGetUserCommand(Login loginE){
            return new GetUserCommand(loginE);
        } 

        public static RecoveryPasswordCommand RecoveryPasswordCommand(Login loginE){
            return new RecoveryPasswordCommand(loginE);
        }

        public static AddResRestaurantCommand AddResRestaurantCommand(Restaurant_res restaurantDTO)
        {
            return new AddResRestaurantCommand(restaurantDTO);
        }
        public static UpdateResRestaurantCommand UpdateResRestaurantCommand(int idPay, reservationRestaurant Rest)
        {
            return new UpdateResRestaurantCommand(idPay, Rest);
        }
    }
}
