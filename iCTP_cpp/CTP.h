/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����è��Ϣ�������޹�˾-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����è��Ϣ�������޹�˾-����ϼ;
 3.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

#ifndef __CTP_H__
#define __CTP_H__
#pragma once
#include "stdafx.h"
#include "Security.h"
using namespace std;

class CTP{
private:
	int m_ctpID;
public:
	CTP();
	~CTP();
	int getCtpID();
	void run();
	void setCtpID(int ctpID);
public:
	//�ʽ��˻���Ϣ�ص�
	virtual void onAccountDataCallBack(AccountData *data, int ctpID);
	//�ֲ����ݻص�
	virtual void onInvestorPositionCallBack(vector<InvestorPosition> *data, int ctpID);
	//�ֲ����ݻص�
	virtual void onInvestorPositionDetailCallBack(vector<InvestorPositionDetail> *data, int ctpID);
	//���͵�ί�лر��ص�
	virtual void onOrderInfoCallBack(OrderInfo *data, int ctpID);
	//������ѯ��ί�лر��ص�
	virtual void onOrderInfosCallBack(vector<OrderInfo> *data, int ctpID);
	//���ص�
	virtual void onSecurityCallBack(vector<Security> *data, int ctpID);
	//�������ݻص�
	virtual void onSecurityLatestDataCallBack(SecurityLatestData *data, int ctpID);
	//���͵Ľ�����Ϣ�ص�
	virtual void onTradeRecordCallBack(TradeRecord *data, int ctpID);
	//������ѯ�Ľ�����Ϣ�ص�
	virtual void onTradeRecordsCallBack(vector<TradeRecord> *tradeRecords, int ctpID);
};

#endif
