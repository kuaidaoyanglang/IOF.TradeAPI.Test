using IQF.Framework.Dao;
using System;

namespace IQF.TradeAccess.Entity
{
    public partial class OrderLogEntity : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BrokerAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BrokerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Exchange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderSide { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// ί�б��
        /// </summary>
        public string OderID { get; set; }
        /// <summary>
        /// ҵ�����ͣ�0��ί�У�1��������
        /// </summary>
        public int BizType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ErrorNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mac { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PackType { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public DateTime TradeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
    } //end of class

    public enum OrderSource
    {
        /// <summary>
        /// �ֶ�ί��
        /// </summary>
        SendOrder = 0,
        /// <summary>
        /// ��ƽ
        /// </summary>
        QuickClose = 1,
        /// <summary>
        /// ֹӯֹ��
        /// </summary>
        AutoStopPrice = 2,
        /// <summary>
        /// ���й�
        /// </summary>
        FollowOrder = 3,
        /// <summary>
        /// ������
        /// </summary>
        ConditionOrder = 4,
        /// <summary>
        /// ���ֵ�
        /// </summary>
        ReverseOrder = 5
    }

} //end of namespace
