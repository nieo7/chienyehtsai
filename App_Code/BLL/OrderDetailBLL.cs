using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OrderTableAdapters;
using Model;
/// <summary>
/// OrderDetailBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class OrderDetailBLL
    {
        OrderDetailTableAdapter db = new OrderDetailTableAdapter();
        public OrderDetailBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public DataTable GetOrderDetailByOid(int o_id)
        {
            return db.GetDataByOid(o_id);
        }
        public void DeleteByOid(int o_id)
        {
            db.DeleteByOid(o_id);
        }
    }
}