/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����è��Ϣ�������޹�˾-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����è��Ϣ�������޹�˾-����ϼ;
 3.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

#ifndef __SECURITY_H__
#define __SECURITY_H__
#pragma once
#include "stdafx.h"
using namespace std;

//CTP�ʽ��˻��ඨ��
class AccountData{
public:
	// Ͷ�����ʺ�
	String m_accountID;
	// �����ʽ�
	double m_available;
	// �ڻ�����׼����
	double m_balance;
	// ���͹�˾����
	String m_brokerID;
	// �ʽ���
	double m_cashIn;
	// ƽ��ӯ��
	double m_closeProfit;
	// ������
	double m_commission;
	// ���ö��
	double m_credit;
	// ���ִ���
	String m_currencyID;
	// ��ǰ��֤���ܶ�
	double m_currMargin;
	// Ͷ���߽��֤��
	double m_deliveryMargin;
	// �����
	double m_deposit;
	// ���������֤��
	double m_exchangeDeliveryMargin;
	// ��������֤��
	double m_exchangeMargin;
	// ������ʽ�
	double m_frozenCash;
	// �����������
	double m_frozenCommission;
	// ����ı�֤��
	double m_frozenMargin;
	// ������Ѻ���
	double m_fundMortgageAvailable;
	// ����������
	double m_fundMortgageIn;
	// �����ʳ����
	double m_fundMortgageOut;
	// ��Ϣ����
	double m_interest;
	// ��Ϣ����
	double m_interestBase;
	// ��Ѻ���
	double m_mortgage;
	// ����Ѻ���ҽ��
	double m_mortgageableFund;
	// �ֲ�ӯ��
	double m_positionProfit;
	// �ϴν���׼����
	double m_preBalance;
	// �ϴ����ö��
	double m_preCredit;
	// �ϴδ���
	double m_preDeposit;
	// �ϴλ���������
	double m_preFundMortgageIn;
	// �ϴλ����ʳ����
	double m_preFundMortgageOut;
	// �ϴ�ռ�õı�֤��
	double m_preMargin;
	// �ϴ���Ѻ���
	double m_preMortgage;
	// ����׼����
	double m_reserve;
	// �����ڻ�����׼����
	double m_reserveBalance;
	// ������
	int m_settlementID;
	// �����Ʒƽ��ӯ��
	double m_specProductCloseProfit;
	// �����Ʒ������
	double m_specProductCommission;
	// �����Ʒ��������֤��
	double m_specProductExchangeMargin;
	// �����Ʒ����������
	double m_specProductFrozenCommission;
	// �����Ʒ���ᱣ֤��
	double m_specProductFrozenMargin;
	// �����Ʒռ�ñ�֤��
	double m_specProductMargin;
	// �����Ʒ�ֲ�ӯ��
	double m_specProductPositionProfit;
	// ���ݳֲ�ӯ���㷨����������Ʒ�ֲ�ӯ��
	double m_specProductPositionProfitByAlg;
	// ������
	String m_tradingDay;
	// ������
	double m_withdraw;
	// ��ȡ�ʽ�
	double m_withdrawQuota;
};

//��Լ��������
class CommissionRate{
public:
	//���͹�˾����
	String m_brokerID;
	//�շѷ�ʽ
	String m_calculateMode;
	//ƽ����������
	double m_closeRatioByMoney;
	//ƽ��������
	double m_closeRatioByVolume;
	//ƽ����������
	double m_closeTodayRatioByMoney;
	//ƽ��������
	double m_closeTodayRatioByVolume;
	//ƽ���
	double m_closeTodayFee;
	//��Լ����
	String m_code;
	//����
	String m_commodityNo;
	//����
	String m_commodityType;
	//���������
	String m_exchangeNo;
	//Ͷ���ߴ���
	String m_investorID;
	//Ͷ���߷�Χ
	String m_investorRange;
	//��Դ
	String m_matchSource;
	//��ƽ��
	double m_openCloseFee;
	//������������
	double m_openRatioByMoney;
	//����������
	double m_openRatioByVolume;
};

//��Լ��֤����
class MarginRate{
public:
	//���͹�˾����
	String m_brokerID;
	//�շѷ�ʽ
	String m_calculateMode;
	//���ǿ�����ʾ
	String m_callOrPutFlag;
	//��Լ����
	String m_code;
	//����
	String m_commodityNo;
	//����
	String m_commodityType;
	//��Լ
	String m_contractNo;
	//Ͷ���ױ���־
	String m_hedgeFlag;
	double m_initialMargin;
	//Ͷ���ߴ���
	String m_investorID;
	//��ͷ��֤����
	double m_longMarginRatioByMoney;
	//��ͷ��֤���
	double m_longMarginRatioByVolume;
	//Ͷ���߷�Χ
	String m_investorRange;
	//�Ƿ���Խ�������ȡ
	int m_isRelativel;
	double m_lockMargin;
	double m_maintenanceMargin;
	double m_sellInitialMargin;
	double m_sellMaintenanceMargin;
	//��ͷ��֤����
	double m_shortMarginRatioByMoney;
	//��ͷ��֤���
	double m_shortMarginRatioByVolume;
	String m_strikePrice;
};

//��Լ���ݶ���
class Security{
public:
	// �������
	String m_combinationType;
	//������
	String m_createDate;
	//������
	int m_deliveryMonth;
	//�������
	int m_deliveryYear;
	//����������
	String m_endDelivDate;
	//����������
	String m_exchangeID;
	//��Լ�ڽ������Ĵ���
	String m_exchangeInstID;
	//������
	String m_expireDate;
	//����С��λ��
	int m_digit;
	//��Լ��������״̬
	String m_instLifePhase;
	//��Լ����
	String m_instrumentID;
	//��Լ����
	String m_instrumentName;
	//��ǰ�Ƿ���
	String m_isTrading;
	//��ͷ��֤����
	double m_longMarginRatio;
	//�޼۵�����µ���
	int m_maxLimitOrderVolume;
	//�Ƿ�ʹ�ô��߱�֤���㷨
	String m_maxMarginSideAlgorithm;
	//�м۵�����µ���
	int m_maxMarketOrderVolume;
	//�޼۵���С�µ���
	int m_minLimitOrderVolume;
	//�м۵���С�µ���
	int m_minMarketOrderVolume;
	//������
	String m_openDate;
	//��Ȩ����
	String m_optionsType;
	//�ֲ���������
	String m_positionDateType;
	//�ֲ�����
	String m_positionType;
	//��С�䶯��λ
	double m_priceTick;
	//��Ʒ����
	String m_productClass;
	//��Ʒ����
	String m_productID;
	//��ͷ��֤����
	double m_shortMarginRatio;
	//��ʼ������
	String m_startDelivDate;
	//ִ�м�
	double m_strikePrice;
	//������Ʒ����
	String m_underlyingInstrID;
	//������Ʒ����
	String m_underlyingInstrName;
	//��Լ������Ʒ����
	double m_underlyingMultiple;
	//��Լ��������
	int m_volumeMultiple;

	void getNnderlyingInstrName(){
		int size = m_instrumentName.size();
		m_underlyingInstrName = L"";
		for (int i = 0; i < size ; i++){
			char sz = m_instrumentName[i];
			if (!(sz == '0' || sz == '1' || sz == '2' || sz == '3' || sz == '4' ||
				sz == '5' || sz == '6' || sz == '7' || sz == '8' || sz == '9')){
				m_underlyingInstrName += sz;
			}
		}
	}
};

//Ͷ���ֲֶ߳���
class InvestorPosition{
public:
	//����ִ�ж���
	int m_abandonFrozen;
	// ���͹�˾����
	String m_brokerID;
	// �ʽ���
	double m_cashIn;
	// ƽ�ֽ��
	double m_closeAmount;
	// ƽ��ӯ��
	double m_closeProfit;
	// ���ն���ƽ��ӯ��
	double m_closeProfitByDate;
	// ��ʶԳ�ƽ��ӯ��
	double m_closeProfitByTrade;
	// ƽ����
	int m_closeVolume;
	// ��Լ����
	String m_code;
	// ��϶�ͷ����
	int m_combLongFrozen;
	// ��ϳɽ��γɵĳֲ�
	int m_combPosition;
	// ��Ͽ�ͷ����
	int m_combShortFrozen;
	// ������
	double m_commission;
	// ��������֤��
	double m_exchangeMargin;
	// ������ʽ�
	double m_frozenCash;
	// �����������
	double m_frozenCommission;
	// ����ı�֤��
	double m_frozenMargin;
	// Ͷ���ױ���־
	String m_hedgeFlag;
	// Ͷ���ߴ���
	String m_investorID;
	// ��ͷ����
	int m_longFrozen;
	// ��ͷ������
	double m_longFrozenAmount;
	// ��֤����
	double m_marginRateByMoney;
	// ��֤����(������)
	double m_marginRateByVolume;
	// ���ֽ��
	double m_openAmount;
	// ���ֳɱ�
	double m_openCost;
	// ������
	int m_openVolume;
	// ���ճֲ�
	int m_position;
	// �ֲ�����
	String m_positionDate;
	// �ֲֶ�շ���
	String m_posiDirection;
	// �ֲֳɱ�
	double m_positionCost;
	// �ֲ�ӯ��
	double m_positionProfit;
	// �ϴ�ռ�õı�֤��
	double m_preMargin;	
	// �ϴν����
	double m_preSettlementPrice;
	// ������
	int m_settlementID;
	// ���ν����
	double m_settlementPrice;
	// ��ͷ����
	int m_shortFrozen;
	// ��ͷ������
	double m_shortFrozenAmount;
	// ִ�ж���
	int m_strikeFrozen;
	// ִ�ж�����
	double m_strikeFrozenAmount;
	// ���ճֲ�
	int m_todayPosition;
	//������
	String m_tradingDate;
	//ռ�õı�֤��
	double m_useMargin;
	//���ճֲ�
	int m_ydPosition;

	//��ȡ���ò�λ
	int getAvailablePosition(){
		int position = 0;
		position = m_position - getFrozenAmount();
		return position;
	};

	int getFrozenAmount(){
		int position = 0;
		if (m_posiDirection == L"��"){
			position = m_longFrozen;
		}
		else if (m_posiDirection == L"��"){
			position = m_shortFrozen;
		}
		return position;
	};
};

//�ֲ���ϸ
class InvestorPositionDetail{
public:
	//���͹�˾����
	String m_brokerID;
	//ƽ�ֽ��
	double m_closeAmount;
	//ƽ��ӯ��
	double m_closeProfit;
	//���ն��гֲ�ӯ��
	double m_closeProfitByDate;
	//��ʶԳ�ֲ�ӯ��
	double m_closeProfitByTrade;
	//ƽ����
	double m_closeVolume;
	//��Լ����
	String m_code;
	//��Ϻ�Լ����
	String m_combInstrumentID;
	//����
	String m_direction;
	//����������
	String m_exchangeID;
	//��������֤��
	double m_exchMargin;
	//����ӯ��
	double m_floatProfit;
	//Ͷ���ױ���־
	String m_hedgeFlag;
	//Ͷ���ߴ���
	String m_investorID;
	//������
	double m_lastPrice;
	//������
	double m_lastSettlementPrice;
	//Ͷ���߱�֤��
	double m_margin;
	//��֤����
	double m_marginRateByMoney;
	//��֤����(������)
	double m_marginRateByVolume;
	//�ڲ����
	String m_orderRef;
	//��������
	String m_openDate;
	//���ּ�
	double m_openPrice;
	//������
	int m_openVolume;
	//���سֲֺţ���������д
	String m_positionNo;
	//�ֲ�ӯ��
	double m_positionProfit;
	//���ն��гֲ�����
	double m_positionProfitByDate;
	//��ʶԳ�ֲ�����
	double m_positionProfitByTrade;
	//�ֲ�����
	int m_positionStreamId;
	//������
	double m_preSettlementPrice;
	//�ֲ�ӯ����׼��
	double m_profitBasePrice;
	//������
	int m_settlementID;
	//�����
	double m_settlementPrice;
	//�ɽ�����
	String m_tradingDay;
	//�ɽ����
	String m_tradeID;
	//�ɽ�����
	String m_tradeType;
	//����
	int m_volume;
};

//��������
class OrderInfo{
public:
	//����ʱ��	
	String m_activeTime;
	//����޸Ľ���������Ա����	
	String m_activeTraderID;
	//�����û�����	
	String m_activeUserID;
	//���͹�˾����	
	String m_brokerID;
	//���͹�˾�������	
	int m_brokerOrderSeq;
	//ҵ��Ԫ	
	String m_businessUnit;
	//����ʱ��	
	String m_cancelTime;
	//�����Ա���	
	String m_clearingPartID;
	//�ͻ�����	
	String m_clientID;
	//��Լ����	
	String m_code;
	//���Ͷ���ױ���־	
	String m_combHedgeFlag;
	//��Ͽ�ƽ��־	
	String m_combOffsetFlag;
	//��������	
	String m_contingentCondition;
	//��������	
	String m_direction;
	//����������	
	String m_exchangeID;
	//��Լ�ڽ������Ĵ���	
	String m_exchangeInstID;
	//ǿƽԭ��	
	String m_forceCloseReason;
	//ǰ�ñ��	
	int m_frontID;
	//GTD����	
	String m_gTDDate;
	//�۸�	
	double m_limitPrice;
	//��������	
	String m_insertDate;
	//ί��ʱ��	
	String m_insertTime;
	//��װ���	
	String m_installID;
	//Ͷ���ߴ���	
	String m_investorID;
	//�Զ������־	
	int m_isAutoSuspend;
	//��������־	
	int m_isSwapOrder;
	//��С�ɽ���	
	int m_minVolume;
	//������ʾ���	
	int m_notifySequence;
	//���ر������	
	String m_orderLocalID;
	//�����۸�����	
	String m_orderPriceType;
	//��������	
	String m_orderRef;
	//����״̬	
	String m_orderStatus;
	//������Դ	
	String m_orderSource;
	//�����ύ״̬	
	String m_orderSubmitStatus;
	//�������	
	String m_orderSysID;
	//��������	
	String m_orderType;
	//��Ա����	
	String m_participantID;
	//��ر���	
	String m_relativeOrderSysID;
	//������	
	int m_requestID;
	//���	
	int m_sequenceNo;
	//�Ự���	
	int m_sessionID;
	//������	
	int m_settlementID;
	//״̬��Ϣ	
	String m_statusMsg;
	//ֹ���	
	double m_stopPrice;
	//����ʱ��	
	String m_suspendTime;
	//��Ч������	
	String m_timeCondition;
	//����������Ա����	
	String m_traderID;
	//������	
	String m_tradingDay;
	//����޸�ʱ��	
	String m_updateTime;
	//�û�ǿ����־	
	int m_userForceClose;
	//�û�����	
	String m_userID;
	//�û��˲�Ʒ��Ϣ	
	String m_userProductInfo;
	//�ɽ�������	
	String m_volumeCondition;
	//ʣ������	
	int m_volumeTotal;
	//����	
	int m_volumeTotalOriginal;
	//��ɽ�����	
	int m_volumeTraded;
	//֣�����ɽ�����	
	int m_zCETotalTradedVolume;
};

//��������
class SecurityLatestData{
public:
	//������
	String m_actionDay;
	//����
    double m_askPrice1;
	//����
    double m_askPrice2;
	//����
    double m_askPrice3;
	//����
    double m_askPrice4;
	//����
    double m_askPrice5;
	//����
    int m_askVolume1;
	//����
    int m_askVolume2;
	//����
    int m_askVolume3;
	//����
    int m_askVolume4;
	//����
    int m_askVolume5;
	//ƽ���۸�
    double m_averagePrice;
	//���
    double m_bidPrice1;
	//���
    double m_bidPrice2;
	//���
    double m_bidPrice3;
	//���
    double m_bidPrice4;
	//���
    double m_bidPrice5;
	//����
    int m_bidVolume1;
	//����
    int m_bidVolume2;
	//����
    int m_bidVolume3;
	//����
    int m_bidVolume4;
	//����
    int m_bidVolume5;
	//���¼�
    double m_close;
	//��Լ����
    String m_code;
	//����ʵ��
    double m_currDelta;
	//������ID
    String m_exchangeID;
	//������InstID
    String exchangeInstID;
	//��߼�
    double m_high;
	//�������̼�
    double m_lastClose;
	//��ͼ�
    double m_low;
	//��ͣ��
    double m_lowerLimit;
	//���̼�
    double m_open;
	//�ֲ���
    double m_openInterest;
	//������
    double m_preClose;
	//����ʵ��
    double m_preDelta;
	//��ֲ���
    double m_preOpenInterest;
	//�ϴν����
    double m_preSettlementPrice;
	//���ν����
    double m_settlementPrice;
	//������
    String m_tradingDay;
	//�ɽ����
    double m_turnover;
	//����޸ĺ���
    int m_updateMillisec;
	//����޸�ʱ��
    String m_updateTime;
	//��ͣ��
    double m_upperLimit;
	//�ɽ���
    int m_volume;
};

//CTP���׶���
class TradeRecord{
public:
	//���͹�˾����
	String m_brokerID;
	///���͹�˾�������
	int m_brokerOrderSeq;
	///ҵ��Ԫ
	String m_businessUnit;
	///�����Ա���
	String m_clearingPartID;
	///�ͻ�����
	String m_clientID;
	//��Լ����
	String m_code;
	//��������
	String m_direction;
	//�г�����
	String m_exchangeID;
	//��Լ�ڽ������Ĵ���
	String m_exchangeInstID;
	//Ͷ���ױ���־
	String m_hedgeFlag;
	//Ͷ���ߴ���
	String m_investorID;
	//��ƽ��־
	String m_offsetFlag;
	//���ر������
	String m_orderLocalID;
	//��������
	String m_orderRef;
	//�������
	String m_orderSysID;
	//��Ա����
	String m_participantID;
	//�۸�
	double m_price;
	//�ɽ�����Դ
	String m_priceSource;
	//���
	int m_sequenceNo;
	//������
	int m_settlementID;
	//�ɽ����
	String m_tradeID;
	//����������Ա����
	String m_traderID;
	//�ɽ�ʱ��
	String m_tradeDate;
	//�ɽ���Դ
	String m_tradeSource;
	//�ɽ�ʱ��
	String m_tradeTime;
	//������
	String m_tradingDay;
	//�ɽ�����
	String m_tradeType;
	//���׽�ɫ
	String m_tradingRole;
	//����
	int m_volume;
	//�û�����
	String m_userID;
};

class CTPConvert{
public:
	//ת����CTP�ʽ��˻�
	static AccountData convertToCTPTradingAccount(String result);
	//ת��CTP��Լ��Ϣ
	static vector<Security> convertToCTPInstrumentDatas(String str);
	//ת��CTP����г�����
	static SecurityLatestData convertToCTPDepthMarketData(String result);
	//ת��CTP�ֲ���Ϣ
	static vector<InvestorPosition> convertToCTPInvestorPosition(String result);
	//ת��CTP�ֲ���ϸ��Ϣ
	static vector<InvestorPositionDetail> convertToCTPInvestorPositionDetail(String result);
	// ת��CTP������Ϣ
	static vector<OrderInfo> convertToCTPOrderList(String result);
	// ת��CTP������Ϣ
	static OrderInfo convertToCTPOrder(String result);
	//ת��CTP������Ϣ
	static TradeRecord convertToCTPTrade(String result);
	//ת��CTP������Ϣ�б�
	static vector<TradeRecord> convertToCTPTradeRecords(String result);
};

#endif