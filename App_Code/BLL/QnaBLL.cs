using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data;
using QnaTableAdapters;
/// <summary>
/// QnaBLL 的摘要描述
/// </summary>
public class QnaBLL
{
    QnaTableAdapter db = new QnaTableAdapter();
    public QnaBLL()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    public int InsertSorting()
    {
        QnaInfo info = new QnaInfo();
        IDataReader reader = db.InsertSorting().CreateDataReader();
        if (reader.Read())
        {
            info = QnaInfo.Populate(reader);
            return info.q_sort + 1;
        }
        return 1;
    }
    public QnaInfo GetDataById(int q_id)
    {
        QnaInfo info = new QnaInfo();
        IDataReader reader = db.GetDataById(q_id).CreateDataReader();
        if (reader.Read())
        {
            info = QnaInfo.Populate(reader);
        }
        return info;
    }
    public List<QnaInfo> GetDataBySorting(int sorting)
    {
        List<QnaInfo> infos = new List<QnaInfo>();
        IDataReader reader = db.GetDataBySorting(sorting).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(QnaInfo.Populate(reader));
        }
        return infos;
    }
    public int Insert(QnaInfo info)
    {
        return db.Insert(info.q_title, info.q_content, InsertSorting(), info.q_show, info.q_CreateDate, info.q_EditDate);
    }
    public int Update(QnaInfo info)
    {
        return db.Update(info.q_title, info.q_content, info.q_sort, info.q_show, info.q_CreateDate, info.q_EditDate, info.q_id);
    }
    public int Delete(int q_id)
    {
        QnaInfo info = GetDataById(q_id);
        List<QnaInfo> infos = GetDataBySorting(info.q_sort);
        foreach (QnaInfo Sortinfo in infos)
        {
            db.Update(Sortinfo.q_title, Sortinfo.q_content, Sortinfo.q_sort - 1, Sortinfo.q_show, Sortinfo.q_CreateDate, Sortinfo.q_EditDate, Sortinfo.q_id);
        }
        return db.Delete(q_id);
    }
}