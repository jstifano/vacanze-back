using System;
using System.Collections.Generic;
using System.Data;
using vacanze_back.VacanzeApi.Common.Entities.Grupo9;
using vacanze_back.VacanzeApi.Common.Exceptions;

namespace vacanze_back.VacanzeApi.Persistence.DAO.Grupo9
{
    public class PostgresClaimDao : IClaimDao
    {

        /// <summary>
        ///     Metodo para obtener un Claim segun su id
        /// </summary>
        /// <param name="id">id del claim a buscar</param>
        /// <returns>Claim Entity</returns>
        /// <exception cref="ClaimNotFoundException">No se encuentra un claim con el id especificado</exception>
        public Claim GetById(int id)
        {
            var resultTable = PgConnection.Instance.ExecuteFunction("getclaim(@cla_id)", id);

            if (resultTable.Rows.Count == 0)
                throw new ClaimNotFoundException("No existe el elemento con id " + id);

            return ExtractClaimFromRow(resultTable.Rows[0]);
        }


        /// <summary>
        ///     Metodo para obtener una lista de claim segun el estatus
        /// </summary>
        /// <param name="status">el estatus actual de los reclamos</param>
        /// <returns>Lista de claim</returns>
        public List<Claim> GetByStatus(string status)
        {
            var claimsByStatus = new List<Claim>();
            var resultTable = PgConnection.Instance.ExecuteFunction("getclaimstatus(@cla_status)", status);
            for (var i = 0; i < resultTable.Rows.Count; i++)
            {
                var claim = ExtractClaimFromRow(resultTable.Rows[i]);
                claimsByStatus.Add(claim);
            }

            return claimsByStatus;
        }


        /// <summary>
        ///     Metodo para obtener los reclamos segun un documento o pasaporte
        /// </summary>
        /// <param name="document">el documento como criterio de busqueda</param>
        /// <returns>Lista de claim</returns>
        public List<Claim> GetByDocument(string document)
        {
            var claimsByDocument = new List<Claim>();
            var resultTable = PgConnection.Instance.ExecuteFunction("GetClaimDocument(@_users_document_id)", document);
            for (var i = 0; i < resultTable.Rows.Count; i++)
            {
                var claim = ExtractClaimFromRow(resultTable.Rows[i]);
                claimsByDocument.Add(claim);
            }

            return claimsByDocument;
        }


        /// <summary>
        ///     Metodo para agregar un claim
        /// </summary>
        /// <param name="claim">el objeto de tipo reclamo que se quiere almacenar</param>
        /// <returns>id del claim agregado</returns>
        public int Add(Claim claim)
        {
            var resultTable = PgConnection.Instance.ExecuteFunction(
                "addclaim(@cla_title,@cla_descr, @bag_int)",
                claim.Title, claim.Description, claim.BaggageId);

            var savedId = Convert.ToInt32(resultTable.Rows[0][0]);
            return savedId;
        }


        /// <summary>
        ///     Metodo para eliminar un claim segun su id
        /// </summary>
        /// <param name="id">id del claim a eliminar</param>
        public void Delete(int id)
        {
            PgConnection.Instance.ExecuteFunction("deleteclaim(@cla_id)", id);
        }


        /// <summary>
        ///     Metodo para modifcar un claim
        /// </summary>
        /// <param name="id">El id del claim que se quiere modificar</param>
        /// <param name="updatedFields">Objeto claim con la data modificada</param>
        public void Update(int id, Claim updatedFields)
        {
            GetById(id);
            if (updatedFields.Status != null)
                PgConnection.Instance.ExecuteFunction(
                    "modifyclaimstatus(@cla_id,@cla_status)",
                    id,
                    updatedFields.Status);
            if (updatedFields.Title != null && updatedFields.Description != null)
                PgConnection.Instance.ExecuteFunction(
                    "modifyclaimtitle(@cla_id,@cla_title,@cla_descr)",
                    id,
                    updatedFields.Title,
                    updatedFields.Description);
        }


        /// <summary>
        ///     Metodo extraer un equipaje de la tabla retornada por las consultas a la base de datos ejecutadas por el PgConnection
        /// </summary>
        /// <param name="row">fila a extraer</param>
        private Claim ExtractClaimFromRow(DataRow row)
        {
            var id = Convert.ToInt32(row[0]);
            var title = row[1].ToString();
            var description = row[2].ToString();
            var status = row[3].ToString();
            var baggageId = Convert.ToInt32(row[4]);
            // TODO: Pila con esta condicion que tenian antes
//            Claim claim;
//            if (table.Columns.Count == 4)
//            {
//                claim = new Claim(id, titulo, descripcion, status);
//            }
//            else
//            {
//                var idEquipaje = Convert.ToInt32(table.Rows[i][4].ToString());
//                claim = new Claim(id, titulo, descripcion, status, idEquipaje);
//            }

            return ClaimBuilder.Create()
                .WithId(id)
                .WithTitle(title)
                .WithStatus(status)
                .WithDescription(description)
                .WithBagagge(baggageId)
                .Build();
        }
    }
}