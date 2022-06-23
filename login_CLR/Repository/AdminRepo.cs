
using BloodManagement.Repository.sugar;
using login_CLR.Models;
using login_CLR.Models.Helper;
using MySql.Data.MySqlClient;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace login_CLR.Repository
{
    public class AdminRepo
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<admin> entityDB;
       

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public AdminRepo()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            DbContext.DbType = DbType.MySql;
            context = DbContext.GetDbContext();
            db = context.Db;

            entityDB = context.GetEntityDB<admin>(db);
        }

        public List<admin> login(int ID,string password)
        {

            //return entityDB.GetList(whereExpression);
            MySqlConnection mycn = ConnectionUtils.CreateConn();
            try
            {
                mycn.Open();
                Console.WriteLine("已经建立连接");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            MySqlCommand mycm = new MySqlCommand("select * from admin where ID="+ID.ToString()+" and password="+password.ToString(), mycn);

            MySqlDataReader dr = mycm.ExecuteReader();
            List<admin> admins = new List<admin>();
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    Console.WriteLine(dr.GetString("ID") + "<br/>");
                    System.Diagnostics.Debug.Write(dr.GetString("ID") + "<br/>");
                    admins.Add(new admin(dr.GetInt32("ID"), dr.GetString("password")));
                }
            }
            mycn.Close();
            return admins;

        }
    }
}
