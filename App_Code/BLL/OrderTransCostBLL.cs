using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OrderTableAdapters;
using Model;
/// <summary>
/// OrderTransCost 的摘要描述
/// </summary>
namespace BLL
{
    public class OrderTransCostBLL
    {
        OrderTransCostTableAdapter db = new OrderTransCostTableAdapter();
        public OrderTransCostBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public OrderTransCostInfo GetDataById(int otc_id)
        {
            OrderTransCostInfo info = new OrderTransCostInfo();
            IDataReader reader = db.GetDataById(otc_id).CreateDataReader();
            if (reader.Read())
            {
                info = OrderTransCostInfo.Populate(reader);
            }
            return info;
        }
        public int GetDataByIdForCost(int otc_id)
        {
            OrderTransCostInfo info = new OrderTransCostInfo();
            IDataReader reader = db.GetDataById(otc_id).CreateDataReader();
            if (reader.Read())
            {
                info = OrderTransCostInfo.Populate(reader);
                return info.otc_cost;
            }
            return 0;
        }

        public int Insert(OrderTransCostInfo info)
        {
            return db.Insert(info.otc_name, info.otc_cost, info.otc_show, info.otc_detail);
        }
        public int Update(OrderTransCostInfo info)
        {
            return db.Update(info.otc_name, info.otc_cost, info.otc_show, info.otc_detail, info.otc_id);
        }
        public int Delete(int otc_id)
        {
            return db.Delete(otc_id);
        }
    }
}