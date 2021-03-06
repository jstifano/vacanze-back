using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.Common.Entities.Grupo3;
using vacanze_back.VacanzeApi.Persistence.DAO;
using vacanze_back.VacanzeApi.Persistence.DAO.Grupo3;
using vacanze_back.VacanzeApi.LogicLayer.DTO.Grupo3;
namespace vacanze_back.VacanzeApi.LogicLayer.Command.Grupo3
{
    public class UpdateFlightCommand: Command
    {

        private Flight _flight;
         int i;
        public UpdateFlightCommand (Flight _flight) {
            this._flight = _flight;
        }

        public void Execute()
        {
            try
            {
                DAOFactory factory = DAOFactory.GetFactory(DAOFactory.Type.Postgres);
                IFlightDAO flightDao = factory.GetFlight();
                flightDao.Update(_flight);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
