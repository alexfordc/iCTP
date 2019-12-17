/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����è��Ϣ�������޹�˾-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����è��Ϣ�������޹�˾-����ϼ;
 3.�ó��򲻿�Դ����Ҫ�õ���Ȩ����ʹ�á�
 */

#ifndef __CTPDLL_H__
#define __CTPDLL_H__
#pragma once
#include "stdafx.h"
using namespace std;

typedef int(*funcAskClose)(int, int, char*, char*, double, int, char, char*);
typedef int(*funcAskCloseToday)(int, int, char*, char*, double, int, char, char*);
typedef int(*funcAskOpen)(int, int, char*, char*, double, int, char, char*);
typedef int(*funcBidClose)(int, int, char*, char*, double, int, char, char*);
typedef int(*funcBidCloseToday)(int, int, char*, char*, double, int, char, char*);
typedef int(*funcBidOpen)(int, int, char*, char*, double, int, char, char*);
typedef int(*funcCancelOrder)(int, int, char*, char*, char*);
typedef int(*funcCreate)(void);
typedef int(*funcGenerateReqID)(int);
typedef int(*funcGetAccountData)(int, char*);
typedef int(*funcGetBrokerID)(int, char*);
typedef int(*funcGetCommissionRate)(int, char *, char*);
typedef int(*funcGetDepthMarketData)(int, char*);
typedef int(*funcGetInstrumentsData)(int, char*);
typedef int(*funcGetInvestorID)(int, char*);
typedef int(*funcGetMarginRate)(int, char *, char*);
typedef int(*funcGetPositionData)(int, char*);
typedef int(*funcGetPositionDetailData)(int, char*);
typedef int(*funcGetOrderInfo)(int, char*);
typedef int(*funcGetOrderInfos)(int, char*);
typedef int(*funcGetPassword)(int, char*);
typedef int(*funcGetSessionID)(int);
typedef int(*funcGetTradeRecord)(int, char*);
typedef int(*funcGetTradeRecords)(int, char*);
typedef int(*funcGetTradingDate)(int, char*);
typedef int(*funcGetTradingTime)(int , char *);
typedef int(*funcIsClearanced)(int);
typedef int(*funcIsClearanceTime)(int);
typedef int(*funcIsDataOk)(int);
typedef int(*funcIsMdLogined)(int);
typedef int(*funcIsTdLogined)(int);
typedef int(*funcIsTradingTime)(int);
typedef int(*funcIsTradingTimeExact)(int, char*);
typedef int(*funcReqCommissionRate)(int, char*, int);
typedef int(*funcReqQrySettlementInfoConfirm)(int, int);
typedef int(*funcReqQrySettlementInfo)(int, int, char*);
typedef int(*funcReqMarginRate)(int, char*, int);
typedef int(*funcStart)(int, int, char*, char*, char*, char*, char*);
typedef int(*funcSubMarketDatas)(int, int, char*);
typedef int(*funcUnSubMarketDatas)(int, int, char*);

class CTPDLL{
public:
	static string getProgramDir();
	static void init();
public:
	//��ƽ���൥ƽ��
	static int askClose(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//��ƽ��֣�ƽ����Ŀ��ֵĿյ�
	static int askCloseToday(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//�������յ�����
	static int askOpen(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//��ƽ���յ�ƽ��
	static int bidClose(int ctpID, int requestID, char* code, char *exchangeID, double price, int qty, char timeCondition, char* orderRef);
	//��ƽ��֣�ƽ����Ŀ��ֵĿյ�
	static int bidCloseToday(int ctpID, int requestID, char* code, char *exchangeID, double price, int qty, char timeCondition, char* orderRef);
	//�򿪣��൥����
	static int bidOpen(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//����
	static int cancelOrder(int ctpID, int requestID, char *exchangeID, char *orderSysID, char *orderRef);
	//�ͽ�������������
	static int create();
	//����ctp������
	static int generateReqID(int ctpID);
	//��ȡ�ʽ��˻���Ϣ
	static int getAccountData(int ctpID, char *data);
	//��ȡ���͹�˾ID
	static int getBrokerID(int ctpID, char *data);
	//��ȡ��������
	static int getCommissionRate(int ctpID, char *code, char *data);
	//��ȡ����г�����
	static int getDepthMarketData(int ctpID, char *data);
	// ��ȡ��Լ����
	static int getInstrumentsData(int ctpID, char *data);
	//��ȡͶ����ID
	static int getInvestorID(int ctpID, char* data);
	//��ȡ��֤����
	static int getMarginRate(int ctpID, char* code, char* data);
	//��ȡͶ���ֲ߳�����
	static int getPositionData(int ctpID, char* data);
	//��ȡͶ���ֲ߳���ϸ����
	static int getPositionDetailData(int ctpID, char* data);
	//��ȡ���µ�ί�лر�����һ��)
	static int getOrderInfo(int ctpID, char* data);
	//��ȡ���е�����ί�лر������������ί�У�
	static int getOrderInfos(int ctpID, char* data);
	//�õ�Ͷ��������
	static int getPassword(int ctpID, char* data);
	//��ȡsessionID
	static int getSessionID(int ctpID);
	//��ȡ���³ɽ���¼����һ����
	static int getTradeRecord(int ctpID, char* data);
	//��ȡ���½��׼�¼����������н��ף�
	static int getTradeRecords(int ctpID, char* data);
	// ��ȡ��������
	static int getTradingDate(int ctpID, char* data);
	//��ȡ����ʱ��
	static int getTradingTime(int ctpID, char* data);
	//�����Ƿ��Ѿ�����
	static int isClearanced(int ctpID);
	//�Ƿ��ǽ���ʱ��
	static int isClearanceTime(int ctpID);
	//�����Ƿ�ok
	static int isDataOk(int ctpID);
	//�������ݷ������Ƿ��Ѿ���¼
	static int isMdLogined(int ctpID);
	//�����Ƿ��Ѿ���¼
	static int isTdLogined(int ctpID);
	//�Ƿ��ǽ���ʱ��
	static int isTradingTime(int ctpID);
	//�Ƿ��Ǿ�ȷ����ʱ��(ȥ�����Ͼ���ʱ�����Ϣʱ��)
	static int isTradingTimeExact(int ctpID, char* code);
	//������������
	static int reqCommissionRate(int ctpID, char* code, int requestID);
	//����ȷ�Ͻ�����Ϣ
	static int reqQrySettlementInfoConfirm(int ctpID, int requestID);
	//���������Ϣ
	static int reqQrySettlementInfo(int ctpID, int requestID, char* tradingDate);
	//����֤����
	static int reqMarginRate(int ctpID, char* code, int requestID);
	//��������������(��create��ִ��)
	static int start(int ctpID, int requestID, char* mdServer, char* tdServer, char* brokerID, char* investorID, char* password);
	//���Ķ����Լ����������
	static int subMarketDatas(int ctpID, int requestID, char* codes);
	//ȡ�����Ķ����Լ����������
	static int unSubMarketDatas(int ctpID, int requestID, char* codes);
};

#endif