/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海卷卷猫信息技术有限公司-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海卷卷猫信息技术有限公司-周淋霞;
 3.该程序不开源，需要得到授权才能使用。
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
	//卖平：多单平仓
	static int askClose(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//卖平今仓：平今天的开仓的空单
	static int askCloseToday(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//卖开：空单开仓
	static int askOpen(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//买平：空单平仓
	static int bidClose(int ctpID, int requestID, char* code, char *exchangeID, double price, int qty, char timeCondition, char* orderRef);
	//买平今仓：平今天的开仓的空单
	static int bidCloseToday(int ctpID, int requestID, char* code, char *exchangeID, double price, int qty, char timeCondition, char* orderRef);
	//买开：多单开仓
	static int bidOpen(int ctpID, int requestID, char *code, char *exchangeID, double price, int qty, char timeCondition, char *orderRef);
	//撤单
	static int cancelOrder(int ctpID, int requestID, char *exchangeID, char *orderSysID, char *orderRef);
	//和交易所建立连接
	static int create();
	//生成ctp请求编号
	static int generateReqID(int ctpID);
	//获取资金账户信息
	static int getAccountData(int ctpID, char *data);
	//获取经纪公司ID
	static int getBrokerID(int ctpID, char *data);
	//获取手续费率
	static int getCommissionRate(int ctpID, char *code, char *data);
	//获取深度市场行情
	static int getDepthMarketData(int ctpID, char *data);
	// 获取合约数据
	static int getInstrumentsData(int ctpID, char *data);
	//获取投资者ID
	static int getInvestorID(int ctpID, char* data);
	//获取保证金率
	static int getMarginRate(int ctpID, char* code, char* data);
	//获取投资者持仓数据
	static int getPositionData(int ctpID, char* data);
	//获取投资者持仓明细数据
	static int getPositionDetailData(int ctpID, char* data);
	//获取最新的委托回报（上一条)
	static int getOrderInfo(int ctpID, char* data);
	//获取所有的最新委托回报（今天的所有委托）
	static int getOrderInfos(int ctpID, char* data);
	//得到投资者密码
	static int getPassword(int ctpID, char* data);
	//获取sessionID
	static int getSessionID(int ctpID);
	//获取最新成交记录（上一条）
	static int getTradeRecord(int ctpID, char* data);
	//获取最新交易记录（今天的所有交易）
	static int getTradeRecords(int ctpID, char* data);
	// 获取交易日期
	static int getTradingDate(int ctpID, char* data);
	//获取交易时间
	static int getTradingTime(int ctpID, char* data);
	//当天是否已经结算
	static int isClearanced(int ctpID);
	//是否是结算时间
	static int isClearanceTime(int ctpID);
	//数据是否ok
	static int isDataOk(int ctpID);
	//行情数据服务器是否已经登录
	static int isMdLogined(int ctpID);
	//交易是否已经登录
	static int isTdLogined(int ctpID);
	//是否是交易时间
	static int isTradingTime(int ctpID);
	//是否是精确交易时间(去掉集合竞价时间和休息时间)
	static int isTradingTimeExact(int ctpID, char* code);
	//请求手续费率
	static int reqCommissionRate(int ctpID, char* code, int requestID);
	//请求确认结算信息
	static int reqQrySettlementInfoConfirm(int ctpID, int requestID);
	//请求结算信息
	static int reqQrySettlementInfo(int ctpID, int requestID, char* tradingDate);
	//请求保证金率
	static int reqMarginRate(int ctpID, char* code, int requestID);
	//启动创建的连接(在create后执行)
	static int start(int ctpID, int requestID, char* mdServer, char* tdServer, char* brokerID, char* investorID, char* password);
	//订阅多个合约的行情数据
	static int subMarketDatas(int ctpID, int requestID, char* codes);
	//取消订阅多个合约的行情数据
	static int unSubMarketDatas(int ctpID, int requestID, char* codes);
};

#endif