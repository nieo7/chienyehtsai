using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OrderTableAdapters;
using Model;
/// <summary>
/// OrderBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class OrderBLL
    {
        OrderTableAdapter db = new OrderTableAdapter();
        OrderDetailBLL odBLL = new OrderDetailBLL();
        public OrderBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public OrderInfo GetOrderById(int o_id)
        {
            OrderInfo info = new OrderInfo();
            IDataReader reader = db.GetDataById(o_id).CreateDataReader();
            if (reader.Read())
            {
                info = OrderInfo.Populate(reader);
            }
            return info;
        }
        public DataTable GetDataOrderDate()
        {
            return db.GetDataOrderDate();
        }
        public DataTable GetDateByThreadDate(DateTime StartTime, DateTime EndTime)
        {
            return db.GetDataByThreadTime(StartTime, EndTime);
        }
        public DataTable GetDataByThreadDateAndPay(DateTime StartTime, DateTime EndTime)
        {
            return db.GetDataByThreadTimeAndPay(StartTime, EndTime);
        }
        public DataTable GetDataByThreadTimeAndOut(DateTime StartTime, DateTime EndTime)
        {
            return db.GetDataByThreadTimeAndOut(StartTime, EndTime);
        }
        public int Update(OrderInfo info)
        {            
            return db.Update(info.o_number, info.o_type, info.otc_id, info.p_cls_id, info.m_id, info.o_name, info.o_mail, info.o_account_number, info.o_phone1, info.o_phone2, info.o_zipCode, info.o_city, info.o_address, info.o_detail
                , info.o_detail_date, info.o_detail_time, info.o_payMethod, info.o_check_Order, info.o_check_Read, info.o_check_Pay, info.o_check_Out, info.o_out_Date, info.o_cancel, info.o_order_info, info.o_totalPrice, info.o_ts,
                info.o_editDate, info.o_inv_chk, info.o_inv_id, info.o_inv_title,info.o_area,info.o_id);
        }
        public int Delete(int o_id)
        {
            odBLL.DeleteByOid(o_id);
            return db.Delete(o_id);
        }
    }
}