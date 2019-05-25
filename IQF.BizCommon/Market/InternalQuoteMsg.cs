using IQF.Framework;
using IQF.Framework.Util;
using System;
using System.Runtime.InteropServices;

namespace IQF.BizCommon.Market
{

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PRICE_VOLUME
    {
        [MarshalAs(UnmanagedType.R4)]
        public float px;                                //price
        [MarshalAs(UnmanagedType.I4)]
        public int size;                                //volume 
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Snapshot
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] symbol;

        /// <summary>
        /// ������   ������ 1,������ 2,֣���� 3,�н��� 4
        /// </summary>
        [MarshalAs(UnmanagedType.I8)]
        public Int64 ExchangeId;

        /// <summary>
        /// ǰ����
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float PreSettlementPrice;

        /// <summary>
        /// ǰ����
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float PreClosePrice;

        /// <summary>
        /// ��ֲ�
        /// </summary>
        [MarshalAs(UnmanagedType.I8)]
        public Int64 PreOpenInterest;

        /// <summary>
        /// �����
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float SettlementPrice;

        /// <summary>
        /// ��ͣ��
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float UpperLimitPrice;

        /// <summary>
        /// ��ͣ��
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float LowerLimitPrice;

        /// <summary>
        /// ����ʵ��
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float PreDelta;

        /// <summary>
        /// ����ʵ��
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float CurrDelta;

        /// <summary>
        /// �ɽ�����
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float AveragePrice;

        /// <summary>
        /// �ֲ���
        /// </summary>
        [MarshalAs(UnmanagedType.I8)]
        public Int64 OpenInterest;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public PRICE_VOLUME[] bidUnits = new PRICE_VOLUME[5];             //��


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public PRICE_VOLUME[] askUnits = new PRICE_VOLUME[5];             //��

        [MarshalAs(UnmanagedType.R4)]
        public float OpenPx;                               //open price

        [MarshalAs(UnmanagedType.R4)]
        public float HighPx;                               //high price

        [MarshalAs(UnmanagedType.R4)]
        public float LowPx;                                //low price

        [MarshalAs(UnmanagedType.R4)]
        public float LastPx;                               //last price

        /// <summary>
        /// �ɽ���
        /// </summary>
        [MarshalAs(UnmanagedType.I8)]
        public Int64 liTotalVolumeTrade;                   //�ɽ���

        /// <summary>
        /// �ɽ���
        /// </summary>
        [MarshalAs(UnmanagedType.R4)]
        public float liTotalValueTrade;                    //turnover (3 decimals) �����ڻ�,����ŵ��ǳֲ���       

        [MarshalAs(UnmanagedType.R4)]
        public float ClosePx;                         //preclose

        /// <summary>
        ///  UTCʱ����� ��������ʱ��
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public int nTime;

    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class InternalQuoteMsg
    {
        private readonly string quoteID = Guid.NewGuid().ToString("N");

        /// <summary>
        /// ������
        /// </summary>
        public string QuoteID
        {
            get
            {
                return this.quoteID;
            }
        }

        //��������
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] symbol;		//��Ʊ���� 

        /// <summary>
        ///  UTCʱ�䣬 ��������ʱ��
        /// </summary>
        public int nTime;  // unixʱ���
        //public allStructs allstructs;
        public Snapshot lev1;

        public string GetSymbol()
        {
            int len = 0;
            while (symbol[len] != '\0' && len < symbol.Length)
            {
                len++;
            }
            string ss = new string(symbol, 0, len);
            return ss;
        }

        /// <summary>
        /// ��ȡ����ʱ��
        ///  - 
        /// DateTime.ToString()��ʽ�� ������ yyyyMMdd ʱ���� HHmmss
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            var dt = TimeZoneHelper.GetTimeBeijing(nTime);
            return dt;
        }

        /// <summary>
        /// ����ExchangeId�����г�
        /// </summary>
        /// <returns></returns>
        public Exchange GetMarket()
        {
            Exchange mkt;
            switch (lev1.ExchangeId)
            {
                case 1:
                    mkt = Exchange.DCE;
                    break;
                case 2:
                    mkt = Exchange.SHFE;
                    break;
                case 3:
                    mkt = Exchange.CZCE;
                    break;
                case 4:
                    mkt = Exchange.CFFEX;
                    break;
	            case 5:
		            mkt = Exchange.INE;
		            break;
                default:
                    mkt = Exchange.NONE;
                    break;
            }
            return mkt;
        }
    };
}