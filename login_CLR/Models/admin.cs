using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;


namespace login_CLR.Models
{
    [SugarTable("admin")]
    public class admin
    {
        public admin()
        {
        }

        public admin(int iD, string password)
        {
            ID = iD;
            this.password = password;
        }

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string password { get; set; }

    }
}
