﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using vacanze_back.VacanzeApi.Common.Entities.Grupo13;
using vacanze_back.VacanzeApi.Common.Entities;
using vacanze_back.VacanzeApi.Common.Entities.Grupo5;
using vacanze_back.VacanzeApi.Persistence.Repository.Grupo5;

namespace vacanze_back.VacanzeApi.Persistence.Repository.Grupo13
{
    public class ReservationAutomobileRepository
    { 
        const String SP_SELECT = "m13_getResAutos()";
        const String SP_AVAILABLE = "m13_getavailableautomobilereservations('01/03/2019', '01/05/2019')";
        const String SP_FIND = "m13_findByResAutId(@_id)";
        const String SP_ADD = "m13_addautomobilereservation(@_checkin,@_checkout,@_use_fk,@_ra_aut_fk)";
        const String SP_DELETE = "m13_deleteautomobilereservation(@_id)";
        const String SP_ALL_BY_USER_ID = "m13_getallbyuserid(@_id)";
        private Auto _automobile;
        private ReservationAutomobile _reservation;

        /** <summary>Trae de la BD, las reservas de automoviles</summary>
         */
        public List<Entity> GetAutomobileReservations()
                {
                    List<Entity> reservationAutomobileList = new List<Entity>();
                    try
                    {
                    var table = PgConnection.Instance.ExecuteFunction(SP_SELECT);
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                            var id = Convert.ToInt64(table.Rows[i][0]);
                            var pickup = Convert.ToDateTime(table.Rows[i][1]);
                            var returndate = Convert.ToDateTime(table.Rows[i][2]);

                            ReservationAutomobile reservation = new ReservationAutomobile(id,pickup,returndate);
                            reservationAutomobileList.Add(reservation);
                            }
                    return reservationAutomobileList;
                    }
                    catch (NpgsqlException e)
                    {
                        e.ToString();
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                    finally
                    {
                    }
                    return reservationAutomobileList;
                }

        public List<Entity> GetAvailableAutomobileReservations()
        {
            List<Entity> reservationAutomobileList = new List<Entity>();
            try
            {
                var table = PgConnection.Instance.ExecuteFunction(SP_AVAILABLE);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var id = Convert.ToInt64(table.Rows[i][0]);
                    var pickup = Convert.ToDateTime(table.Rows[i][1]);
                    var returndate = Convert.ToDateTime(table.Rows[i][2]);

                    ReservationAutomobile reservation = new ReservationAutomobile(id, pickup, returndate);
                    reservationAutomobileList.Add(reservation);
                }
                return reservationAutomobileList;
            }
            catch (NpgsqlException e)
            {
                e.ToString();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
            }
            return reservationAutomobileList;
        }

        /** <summary>Busca en la BD, la reserva que posee el identificador suministrado</summary>
         * <param name="id">El identificador de la entidad reserva de automovil a buscar</param>
         */
        public Entity Find(int id)
        {
            try
            {
                var table = PgConnection.Instance.ExecuteFunction(SP_FIND, id);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var pickup = Convert.ToDateTime(table.Rows[i][1]);
                    var returndate = Convert.ToDateTime(table.Rows[i][2]);
                    var userid = Convert.ToInt64(table.Rows[i][4]);
                    var autfk = Convert.ToInt64(table.Rows[i][5]);
                   // var payfk = Convert.ToInt64(table.Rows[i][5]);
                    _reservation = new ReservationAutomobile(id,pickup,returndate);
                  //  _reservation.User.Id = userid;
                  //  _reservation.Automobile.Id = autfk;
                    //Falta Payment
                }
                return _reservation;
            }
            catch (NpgsqlException e)
            {
                e.ToString();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return _reservation;
        }

        /** <summary>Inserta en la BD, la reservacion de automovil que es suministrada</summary> 
         * <param name="reservation">La reservacion a agregar en la BD</param>
         */
        public ReservationAutomobile AddReservation(ReservationAutomobile reservation)
        {
            try
            {
                var table = PgConnection.Instance.
                    ExecuteFunction(SP_ADD,
                        reservation.CheckIn,
                        reservation.CheckOut,
                        reservation.Fk_user,
                        reservation.Automobile.getId());
                return reservation;
            }
            catch
            {
                throw;
            }
        }

        /** <summary>Borra de la BD, la reservacion que es suministrada</summary>
         * <param name="entity">La entidad reservacion a borrar de la BD</param>
         */
        public void Delete(Entity entity)
        {
            try
            {
                ReservationAutomobile reservation = (ReservationAutomobile)entity;
                var table = PgConnection.Instance.ExecuteFunction(SP_DELETE,
                   (int)reservation.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public List<Entity> GetAllByUserId(int user_id)
        {
            List<Entity> reservationAutomobileList = new List<Entity>();
            try
            {
                var table = PgConnection.Instance.ExecuteFunction(SP_ALL_BY_USER_ID,
                    user_id);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var id = Convert.ToInt64(table.Rows[i][0]);
                    var pickup = Convert.ToDateTime(table.Rows[i][1]);
                    var returndate = Convert.ToDateTime(table.Rows[i][2]);
                    //current timestamp
                    var userid = Convert.ToInt64(table.Rows[i][4]);
                    var autfk = (int)Convert.ToInt64(table.Rows[i][5]);

                    ReservationAutomobile reservation = new ReservationAutomobile(id, pickup, returndate);
                    reservation.Automobile = ConnectAuto.ConsultforId(autfk).ElementAt(0);
                    reservation.Fk_user = user_id;
                    reservationAutomobileList.Add(reservation);
                }
                return reservationAutomobileList;
            }
            catch (NpgsqlException e)
            {
                e.ToString();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
            }
            return reservationAutomobileList;
        }
    }

}
