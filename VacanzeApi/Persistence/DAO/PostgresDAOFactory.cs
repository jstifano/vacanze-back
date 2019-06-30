using vacanze_back.VacanzeApi.Persistence.DAO.Grupo13;
using vacanze_back.VacanzeApi.Persistence.DAO.Grupo9;

namespace vacanze_back.VacanzeApi.Persistence.DAO
{
    public class PostgresDAOFactory : DAOFactory
    {
        public override ReservationRoomDAO GetReservationRoomDAO()
        {
            return new PostgresReservationRoomDAO();
        }

        public override IClaimDao GetClaimDao()
        {
            return new PostgresClaimDao();
        }
    }
}