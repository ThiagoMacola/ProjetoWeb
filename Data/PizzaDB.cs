using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Util;

namespace Data
{
    public class PizzaDB : IPizzaDB

    {
        private ConnectionDB _conn; //OBJETO DE CONEXÃO 

        public bool Insert(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format("INSERT INTO[dbo].[TB_REFEICAO]([descricao],[valor]) VALUES('{0}', {1})", pizza.Descricao, pizza.Valor); // FORMART = FORMATA O TEXTO DE ENTRADA

            using (_conn = new ConnectionDB()) // ABIU FECHOU - USING
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

	

		public List<Pizza> Select()
        {
            using (_conn = new ConnectionDB())
            {
                string sql = Pizza.SELECT;
                var returnData = _conn.ExecQueryReturn(sql); // ELA RETORNA SQLREADER
                return TransformSQLReaderToList(returnData);
            }
        }



        public bool Delete(Pizza pizza)
        {
            bool status = false;
            string sqlfinal = string.Format("DELETE FROM [Restaurante].[dbo].[TB_REFEICAO] WHERE [descricao] = '{0}' ", pizza.Descricao);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sqlfinal);
            }
            return status;
        }



        private List<Pizza> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Pizza>();

            while (returnData.Read())
            {
                var item = new Pizza()
                {
                    Id  = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = Decimal.Parse(returnData["valor"].ToString())

                };

                list.Add(item);
            }
            return list;
        }

    }


}
