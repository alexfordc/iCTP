#include "stdafx.h"
#include "Security.h"

AccountData CTPConvert::convertToCTPTradingAccount(String result){
	AccountData cTPTradingAccount;
	//�ʽ��˺���Ϣ����
	vector<String> results = FCStrEx::split(result,L",");
	if (results.size() == 46){
		int i = 0;
		//���͹�˾����
		cTPTradingAccount.m_brokerID = results[i++];
		///Ͷ�����ʺ�
		cTPTradingAccount.m_accountID = results[i++];
		///�ϴ���Ѻ���
		cTPTradingAccount.m_preMortgage = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ϴ����ö��
		cTPTradingAccount.m_preCredit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ϴδ���
		cTPTradingAccount.m_preDeposit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ϴν���׼����
		cTPTradingAccount.m_preBalance = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ϴ�ռ�õı�֤��
		cTPTradingAccount.m_preMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///��Ϣ����
		cTPTradingAccount.m_interestBase = FCStrEx::convertStrToDouble(results[i++].c_str());
		///��Ϣ����
		cTPTradingAccount.m_interest = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����
		cTPTradingAccount.m_deposit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///������
		cTPTradingAccount.m_withdraw = FCStrEx::convertStrToDouble(results[i++].c_str());
		///����ı�֤��
		cTPTradingAccount.m_frozenMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///������ʽ�
		cTPTradingAccount.m_frozenCash = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����������
		cTPTradingAccount.m_frozenCommission = FCStrEx::convertStrToDouble(results[i++].c_str());
		///��ǰ��֤���ܶ�
		cTPTradingAccount.m_currMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ʽ���
		cTPTradingAccount.m_cashIn = FCStrEx::convertStrToDouble(results[i++].c_str());
		///������
		cTPTradingAccount.m_commission = FCStrEx::convertStrToDouble(results[i++].c_str());
		///ƽ��ӯ��
		cTPTradingAccount.m_closeProfit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ֲ�ӯ��
		cTPTradingAccount.m_positionProfit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ڻ�����׼����
		cTPTradingAccount.m_balance = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����ʽ�
		cTPTradingAccount.m_available = FCStrEx::convertStrToDouble(results[i++].c_str());
		///��ȡ�ʽ�
		cTPTradingAccount.m_withdrawQuota = FCStrEx::convertStrToDouble(results[i++].c_str());
		///����׼����
		cTPTradingAccount.m_reserve = FCStrEx::convertStrToDouble(results[i++].c_str());
		///������
		cTPTradingAccount.m_tradingDay = results[i++];
		///������
		cTPTradingAccount.m_settlementID = FCStrEx::convertStrToInt(results[i++].c_str());
		///���ö��
		cTPTradingAccount.m_credit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///��Ѻ���
		cTPTradingAccount.m_mortgage = FCStrEx::convertStrToDouble(results[i++].c_str());
		///��������֤��
		cTPTradingAccount.m_exchangeMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///Ͷ���߽��֤��
		cTPTradingAccount.m_deliveryMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///���������֤��
		cTPTradingAccount.m_exchangeDeliveryMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����ڻ�����׼����
		cTPTradingAccount.m_reserveBalance = FCStrEx::convertStrToDouble(results[i++].c_str());
		///���ִ���
		cTPTradingAccount.m_currencyID = results[i++];
		///�ϴλ���������
		cTPTradingAccount.m_preFundMortgageIn = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�ϴλ����ʳ����
		cTPTradingAccount.m_preFundMortgageOut = FCStrEx::convertStrToDouble(results[i++].c_str());
		///����������
		cTPTradingAccount.m_fundMortgageIn = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����ʳ����
		cTPTradingAccount.m_fundMortgageOut = FCStrEx::convertStrToDouble(results[i++].c_str());
		///������Ѻ���
		cTPTradingAccount.m_fundMortgageAvailable = FCStrEx::convertStrToDouble(results[i++].c_str());
		///����Ѻ���ҽ��
		cTPTradingAccount.m_mortgageableFund = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒռ�ñ�֤��
		cTPTradingAccount.m_specProductMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒ���ᱣ֤��
		cTPTradingAccount.m_specProductFrozenMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒ������
		cTPTradingAccount.m_specProductCommission = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒ����������
		cTPTradingAccount.m_specProductFrozenCommission = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒ�ֲ�ӯ��
		cTPTradingAccount.m_specProductPositionProfit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒƽ��ӯ��
		cTPTradingAccount.m_specProductCloseProfit = FCStrEx::convertStrToDouble(results[i++].c_str());
		///���ݳֲ�ӯ���㷨����������Ʒ�ֲ�ӯ��
		cTPTradingAccount.m_specProductPositionProfitByAlg = FCStrEx::convertStrToDouble(results[i++].c_str());
		///�����Ʒ��������֤��
		cTPTradingAccount.m_specProductExchangeMargin = FCStrEx::convertStrToDouble(results[i++].c_str());
	}
	return cTPTradingAccount;
}

vector<Security> CTPConvert::convertToCTPInstrumentDatas(String str){
	vector<Security> securitis;
	vector<String> results = FCStrEx::split(str, L":");
	int size = (int)results.size();
	for(int i = 0;i < size; i++){
		vector<String> result = FCStrEx::split(results[i], L",");
		if(result.size() == 31){
			Security security;
			int j = 0;
			//��Լ����
			security.m_instrumentID = result[j++];
			///����������
			security.m_exchangeID = result[j++];
			///��Լ����
			security.m_instrumentName = result[j++];
			///��Լ�ڽ������Ĵ���
			security.m_exchangeInstID = result[j++];
			///��Ʒ����
			security.m_productID = result[j++];
			///��Ʒ����
			security.m_productClass = result[j++];
			///�������
			security.m_deliveryYear = FCStrEx::convertStrToInt(result[j++].c_str());
			///������
			security.m_deliveryMonth = FCStrEx::convertStrToInt(result[j++].c_str());
			///�м۵�����µ���
			security.m_maxMarketOrderVolume = FCStrEx::convertStrToInt(result[j++].c_str());
			///�м۵���С�µ���
			security.m_minMarketOrderVolume = FCStrEx::convertStrToInt(result[j++].c_str());
			///�޼۵�����µ���
			security.m_maxLimitOrderVolume = FCStrEx::convertStrToInt(result[j++].c_str());
			///�޼۵���С�µ���
			security.m_minLimitOrderVolume = FCStrEx::convertStrToInt(result[j++].c_str());
			///��Լ��������
			security.m_volumeMultiple = FCStrEx::convertStrToInt(result[j++].c_str());
			///��С�䶯��λ
			security.m_priceTick = FCStrEx::convertStrToDouble(result[j++].c_str());
			///������
			security.m_createDate = result[j++];
			///������
			security.m_openDate = result[j++];
			///������
			security.m_expireDate = result[j++];
			///��ʼ������
			security.m_startDelivDate = result[j++];
			///����������
			security.m_endDelivDate = result[j++];
			///��Լ��������״̬
			security.m_instLifePhase = result[j++];
			///��ǰ�Ƿ���
			security.m_isTrading = result[j++];
			///�ֲ�����
			security.m_positionType = result[j++];
			///�ֲ���������
			security.m_positionDateType = result[j++];
			///��ͷ��֤����  
			security.m_longMarginRatio = FCStrEx::convertStrToDouble(result[j++].c_str());
			///��ͷ��֤����
			security.m_shortMarginRatio = FCStrEx::convertStrToDouble(result[j++].c_str());
			///�Ƿ�ʹ�ô��߱�֤���㷨
			security.m_maxMarginSideAlgorithm = result[j++];
			///������Ʒ����
			security.m_underlyingInstrID = result[j++];
			///ִ�м�
			security.m_strikePrice = FCStrEx::convertStrToDouble(result[j++].c_str());
			///��Ȩ����
			security.m_optionsType = result[j++];
			///��Լ������Ʒ����
			security.m_underlyingMultiple = FCStrEx::convertStrToDouble(result[j++].c_str());
			///�������
			security.m_combinationType = result[j++];
			security.getNnderlyingInstrName();
			securitis.push_back(security);
		}
	}
	return securitis;
}

SecurityLatestData CTPConvert::convertToCTPDepthMarketData(String str){
	SecurityLatestData cTPDepthMarketData;
	vector<String> results = FCStrEx::split(str, L",");
	if (results.size() >= 44){
		int i = 0;
		cTPDepthMarketData.m_tradingDay = results[i++];
		cTPDepthMarketData.m_code = results[i++];
		String exchangeID = results[i++];
		String exchangeInstID = results[i++];
		cTPDepthMarketData.m_lastClose = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_preSettlementPrice = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_preClose = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_preOpenInterest = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_open = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_high = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_low = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_volume = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_turnover = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_openInterest = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_close = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_settlementPrice = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_upperLimit = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_lowerLimit = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_preDelta = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_currDelta = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_updateTime = results[i++];
		cTPDepthMarketData.m_updateMillisec = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_bidPrice1 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_bidVolume1 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_askPrice1 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_askVolume1 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_bidPrice2 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_bidVolume2 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_askPrice2 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_askVolume2 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_bidPrice3 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_bidVolume3 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_askPrice3 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_askVolume3 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_bidPrice4 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_bidVolume4 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_askPrice4 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_askVolume4 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_bidPrice5 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_bidVolume5 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_askPrice5 = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_askVolume5 = FCStrEx::convertStrToInt(results[i++].c_str());
		cTPDepthMarketData.m_averagePrice = FCStrEx::convertStrToDouble(results[i++].c_str());
		cTPDepthMarketData.m_actionDay = results[i++];
	}
	return cTPDepthMarketData;
}

vector<InvestorPosition> CTPConvert::convertToCTPInvestorPosition(String str){
	vector<InvestorPosition> investorPositions;
	vector<String> results = FCStrEx::split(str, L";");
	int size = (int)results.size();
	for(int i = 0; i < size; i++){
		vector<String> result = FCStrEx::split(results[i], L",");
		if(result.size() == 43){
			InvestorPosition investorPosition;
			int k = 0;
			///��Լ����
			investorPosition.m_code = result[k++];
			///���͹�˾����
			investorPosition.m_brokerID = result[k++];
			///Ͷ���ߴ���
			investorPosition.m_investorID = result[k++];
			///�ֲֶ�շ���
			investorPosition.m_posiDirection = result[k++];
			///Ͷ���ױ���־
			investorPosition.m_hedgeFlag = result[k++];
			///�ֲ�����
			investorPosition.m_positionDate = result[k++];
			///���ճֲ�
			investorPosition.m_ydPosition = FCStrEx::convertStrToInt(result[k++].c_str());
			///���ճֲ�
			investorPosition.m_position = FCStrEx::convertStrToInt(result[k++].c_str());
			///��ͷ����
			investorPosition.m_longFrozen = FCStrEx::convertStrToInt(result[k++].c_str());
			///��ͷ����
			investorPosition.m_shortFrozen = FCStrEx::convertStrToInt(result[k++].c_str());
			///���ֶ�����
			investorPosition.m_longFrozenAmount = FCStrEx::convertStrToDouble(result[k++].c_str());
			///���ֶ�����
			investorPosition.m_shortFrozenAmount = FCStrEx::convertStrToDouble(result[k++].c_str());
			///������
			investorPosition.m_openVolume = FCStrEx::convertStrToInt(result[k++].c_str());
			///ƽ����
			investorPosition.m_closeVolume = FCStrEx::convertStrToInt(result[k++].c_str());
			///���ֽ��
			investorPosition.m_openAmount = FCStrEx::convertStrToDouble(result[k++].c_str());
			///ƽ�ֽ��
			investorPosition.m_closeAmount = FCStrEx::convertStrToDouble(result[k++].c_str());
			///�ֲֳɱ�
			investorPosition.m_positionCost = FCStrEx::convertStrToDouble(result[k++].c_str());
			///�ϴ�ռ�õı�֤��
			investorPosition.m_preMargin = FCStrEx::convertStrToDouble(result[k++].c_str());
			///ռ�õı�֤��
			investorPosition.m_useMargin = FCStrEx::convertStrToDouble(result[k++].c_str());
			///����ı�֤��
			investorPosition.m_frozenMargin = FCStrEx::convertStrToDouble(result[k++].c_str());
			///������ʽ�
			investorPosition.m_frozenCash = FCStrEx::convertStrToDouble(result[k++].c_str());
			///�����������
			investorPosition.m_frozenCommission = FCStrEx::convertStrToDouble(result[k++].c_str());
			///�ʽ���
			investorPosition.m_cashIn = FCStrEx::convertStrToDouble(result[k++].c_str());
			///������
			investorPosition.m_commission = FCStrEx::convertStrToDouble(result[k++].c_str());
			///ƽ��ӯ��
			investorPosition.m_closeProfit = FCStrEx::convertStrToDouble(result[k++].c_str());
			///�ֲ�ӯ��
			investorPosition.m_positionProfit = FCStrEx::convertStrToDouble(result[k++].c_str());
			///�ϴν����
			investorPosition.m_preSettlementPrice = FCStrEx::convertStrToDouble(result[k++].c_str());
			///���ν����
			investorPosition.m_settlementPrice = FCStrEx::convertStrToDouble(result[k++].c_str());
			///������
			investorPosition.m_tradingDate = result[k++];
			///������
			investorPosition.m_settlementID = FCStrEx::convertStrToInt(result[k++].c_str());
			///���ֳɱ�
			investorPosition.m_openCost = FCStrEx::convertStrToDouble(result[k++].c_str());
			///��������֤��
			investorPosition.m_exchangeMargin = FCStrEx::convertStrToDouble(result[k++].c_str());
			///��ϳɽ��γɵĳֲ�
			investorPosition.m_combPosition = FCStrEx::convertStrToInt(result[k++].c_str());
			///��϶�ͷ����
			investorPosition.m_combLongFrozen = FCStrEx::convertStrToInt(result[k++].c_str());
			///��Ͽ�ͷ����
			investorPosition.m_combShortFrozen = FCStrEx::convertStrToInt(result[k++].c_str());
			///���ն���ƽ��ӯ��
			investorPosition.m_closeProfitByDate = FCStrEx::convertStrToDouble(result[k++].c_str());
			///��ʶԳ�ƽ��ӯ��
			investorPosition.m_closeProfitByTrade = FCStrEx::convertStrToDouble(result[k++].c_str());
			///���ճֲ�
			investorPosition.m_todayPosition = FCStrEx::convertStrToInt(result[k++].c_str());
			///��֤����
			investorPosition.m_marginRateByMoney = FCStrEx::convertStrToDouble(result[k++].c_str());
			///��֤����(������)
			investorPosition.m_marginRateByVolume = FCStrEx::convertStrToDouble(result[k++].c_str());
			///ִ�ж���
			investorPosition.m_strikeFrozen = FCStrEx::convertStrToInt(result[k++].c_str());
			///ִ�ж�����
			investorPosition.m_strikeFrozenAmount = FCStrEx::convertStrToDouble(result[k++].c_str());
			///����ִ�ж���
			investorPosition.m_abandonFrozen = FCStrEx::convertStrToInt(result[k++].c_str());
			investorPositions.push_back(investorPosition);
		}
	}
	return investorPositions;
}

vector<InvestorPositionDetail> CTPConvert::convertToCTPInvestorPositionDetail(String str){
	vector<InvestorPositionDetail> investorPositionDetails;
	vector<String> results = FCStrEx::split(str, L";");
	int size = (int)results.size();
	for(int i = 0; i < size; i++){
		vector<String> result = FCStrEx::split(results[i], L",");
		if(result.size() == 43){
			InvestorPositionDetail investorPositionDetail;
			int k = 0;
			investorPositionDetail.m_code = result[k++];
			investorPositionDetail.m_brokerID = result[k++];
			investorPositionDetail.m_investorID = result[k++];
			investorPositionDetail.m_hedgeFlag = result[k++];
			investorPositionDetail.m_direction = result[k++];
			investorPositionDetail.m_openDate = result[k++];
			investorPositionDetail.m_tradeID = result[k++];
			investorPositionDetail.m_volume = FCStrEx::convertStrToInt(result[k++].c_str());
			investorPositionDetail.m_openPrice = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_tradingDay = result[k++];
			investorPositionDetail.m_settlementID = FCStrEx::convertStrToInt(result[k++].c_str());
			investorPositionDetail.m_tradeType = result[k++];
			investorPositionDetail.m_combInstrumentID = result[k++];
			investorPositionDetail.m_exchangeID = result[k++];
			investorPositionDetail.m_closeProfitByDate = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_closeProfitByTrade = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_positionProfitByDate = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_positionProfitByTrade = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_margin = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_exchMargin = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_marginRateByMoney = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_marginRateByVolume = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_lastSettlementPrice = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_lastSettlementPrice = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_settlementPrice = FCStrEx::convertStrToDouble(result[k++].c_str());
			investorPositionDetail.m_closeVolume = FCStrEx::convertStrToInt(result[k++].c_str());
			investorPositionDetails.push_back(investorPositionDetail);
		}
	}
	return investorPositionDetails;
}

vector<OrderInfo> CTPConvert::convertToCTPOrderList(String str){
	vector<OrderInfo> orderInfos;
	vector<String> results = FCStrEx::split(str, L";");
	int size = (int)results.size();
	for(int i = 0; i < size; i++){
		if(results[i].size() != 0){	
			OrderInfo orderInfo = convertToCTPOrder(results[i]);
			orderInfos.push_back(orderInfo);
		}
	}
	return orderInfos;
}

OrderInfo CTPConvert::convertToCTPOrder(String str){
	OrderInfo orderInfo;
	vector<String> result = FCStrEx::split(str, L",");
	int size = (int)result.size();
	if(size == 57){
		int i = 0;
		///���͹�˾����
		orderInfo.m_brokerID = result[i++];
		///Ͷ���ߴ���
		orderInfo.m_investorID = result[i++];
		///��Լ����
		orderInfo.m_code = result[i++];
		///��������
		orderInfo.m_orderRef = result[i++];
		///�û�����
		orderInfo.m_userID = result[i++];
		///�����۸�����
		orderInfo.m_orderPriceType = result[i++];
		///��������
		orderInfo.m_direction = result[i++];
		///��Ͽ�ƽ��־
		orderInfo.m_combOffsetFlag = result[i++];
		///���Ͷ���ױ���־
		orderInfo.m_combHedgeFlag = result[i++];
		///�۸�
		orderInfo.m_limitPrice = FCStrEx::convertStrToDouble(result[i++].c_str());
		///����
		orderInfo.m_volumeTotalOriginal = FCStrEx::convertStrToInt(result[i++].c_str());
		///��Ч������
		orderInfo.m_timeCondition = result[i++];
		///GTD����
		orderInfo.m_gTDDate = result[i++];
		///�ɽ�������
		orderInfo.m_volumeCondition = result[i++];
		///��С�ɽ���
		orderInfo.m_minVolume = FCStrEx::convertStrToInt(result[i++].c_str());
		///��������
		orderInfo.m_contingentCondition = result[i++];
		///ֹ���
		orderInfo.m_stopPrice = FCStrEx::convertStrToDouble(result[i++].c_str());
		///ǿƽԭ��
		orderInfo.m_forceCloseReason = result[i++];
		///�Զ������־
		orderInfo.m_isAutoSuspend = FCStrEx::convertStrToInt(result[i++].c_str());
		///ҵ��Ԫ
		orderInfo.m_businessUnit = result[i++];
		///������
		orderInfo.m_requestID = FCStrEx::convertStrToInt(result[i++].c_str());
		///���ر������
		orderInfo.m_orderLocalID = result[i++];
		///����������
		orderInfo.m_exchangeID = result[i++];
		///��Ա����
		orderInfo.m_participantID = result[i++];
		///�ͻ�����
		orderInfo.m_clientID = result[i++];
		///��Լ�ڽ������Ĵ���
		orderInfo.m_exchangeInstID = result[i++];
		///����������Ա����
		orderInfo.m_traderID = result[i++];
		///��װ���
		orderInfo.m_installID = result[i++];
		///�����ύ״̬
		orderInfo.m_orderSubmitStatus = result[i++];
		///������ʾ���
		orderInfo.m_notifySequence = FCStrEx::convertStrToInt(result[i++].c_str());
		///������
		orderInfo.m_tradingDay = result[i++];
		///������
		orderInfo.m_settlementID = FCStrEx::convertStrToInt(result[i++].c_str());
		///�������
		orderInfo.m_orderSysID = result[i++];
		///������Դ
		orderInfo.m_orderSource = result[i++];
		///����״̬
		orderInfo.m_orderStatus = result[i++];
		///��������
		orderInfo.m_orderType = result[i++];
		///��ɽ�����
		orderInfo.m_volumeTraded = FCStrEx::convertStrToInt(result[i++].c_str());
		///ʣ������
		orderInfo.m_volumeTotal = FCStrEx::convertStrToInt(result[i++].c_str());
		///��������
		orderInfo.m_insertDate = result[i++];
		///ί��ʱ��
		orderInfo.m_insertTime = result[i++];
		///����ʱ��
		orderInfo.m_activeTime = result[i++];
		///����ʱ��
		orderInfo.m_suspendTime = result[i++];
		///����޸�ʱ��
		orderInfo.m_updateTime = result[i++];
		///����ʱ��
		orderInfo.m_cancelTime = result[i++];
		///����޸Ľ���������Ա����
		orderInfo.m_activeTraderID = result[i++];
		///�����Ա���
		orderInfo.m_clearingPartID = result[i++];
		///���
		orderInfo.m_sequenceNo = FCStrEx::convertStrToInt(result[i++].c_str());
		///ǰ�ñ��
		orderInfo.m_frontID = FCStrEx::convertStrToInt(result[i++].c_str());
		///�Ự���
		orderInfo.m_sessionID = FCStrEx::convertStrToInt(result[i++].c_str());
		///�û��˲�Ʒ��Ϣ
		orderInfo.m_userProductInfo = result[i++];
		///״̬��Ϣ
		orderInfo.m_statusMsg = result[i++];
		///�û�ǿ����־
		orderInfo.m_userForceClose = FCStrEx::convertStrToInt(result[i++].c_str());
		///�����û�����
		orderInfo.m_activeUserID = result[i++];
		///���͹�˾�������
		orderInfo.m_brokerOrderSeq = FCStrEx::convertStrToInt(result[i++].c_str());
		///��ر���
		orderInfo.m_relativeOrderSysID = result[i++];
		///֣�����ɽ�����
		orderInfo.m_zCETotalTradedVolume = FCStrEx::convertStrToInt(result[i++].c_str());
		///��������־
		orderInfo.m_isSwapOrder = FCStrEx::convertStrToInt(result[i++].c_str());
	}
	return orderInfo;
}

TradeRecord CTPConvert::convertToCTPTrade(String str){
	TradeRecord tradeRecord;
	vector<String> result = FCStrEx::split(str, L",");
	if(result.size() == 30){
		int i = 0;
		///���͹�˾����
		tradeRecord.m_brokerID = result[i++];
		///Ͷ���ߴ���
		tradeRecord.m_investorID = result[i++];
		///��Լ����
		tradeRecord.m_code = result[i++];
		///��������
		tradeRecord.m_orderRef = result[i++];
		///�û�����
		tradeRecord.m_userID = result[i++];
		///����������
		tradeRecord.m_exchangeID = result[i++];
		///�ɽ����
		tradeRecord.m_tradeID = result[i++];
		///��������
		tradeRecord.m_direction = result[i++];
		///�������
		tradeRecord.m_orderSysID = result[i++];
		///��Ա����
		tradeRecord.m_participantID = result[i++];
		///�ͻ�����
		tradeRecord.m_clientID = result[i++];
		///���׽�ɫ
		tradeRecord.m_tradingRole = result[i++];
		///��Լ�ڽ������Ĵ���
		tradeRecord.m_exchangeInstID = result[i++];
		///��ƽ��־
		tradeRecord.m_offsetFlag = result[i++];
		///Ͷ���ױ���־
		tradeRecord.m_hedgeFlag = result[i++];
		///�۸�
		tradeRecord.m_price = FCStrEx::convertStrToDouble(result[i++].c_str());
		///����
		tradeRecord.m_volume = FCStrEx::convertStrToInt(result[i++].c_str());
		///�ɽ�ʱ��
		tradeRecord.m_tradeDate = result[i++];
		///�ɽ�ʱ��
		tradeRecord.m_tradeTime = result[i++];
		///�ɽ�����
		tradeRecord.m_tradeType = result[i++];
		///�ɽ�����Դ
		tradeRecord.m_priceSource = result[i++];
		///����������Ա����
		tradeRecord.m_traderID = result[i++];
		///���ر������
		tradeRecord.m_orderLocalID = result[i++];
		///�����Ա���
		tradeRecord.m_clearingPartID = result[i++];
		///ҵ��Ԫ
		tradeRecord.m_businessUnit = result[i++];
		///���
		tradeRecord.m_sequenceNo = FCStrEx::convertStrToInt(result[i++].c_str());
		///������
		tradeRecord.m_tradingDay = result[i++];
		///������
		tradeRecord.m_settlementID = FCStrEx::convertStrToInt(result[i++].c_str());
		///���͹�˾�������
		tradeRecord.m_brokerOrderSeq = FCStrEx::convertStrToInt(result[i++].c_str());
		///�ɽ���Դ
		tradeRecord.m_tradeSource = result[i++];
	}
	return tradeRecord;
}

vector<TradeRecord> CTPConvert::convertToCTPTradeRecords(String str){
	vector<TradeRecord> tradeRecords;
	vector<String> results = FCStrEx::split(str, L";");
	int size = (int)results.size();
	for(int i = 0 ; i < size ; i++){
		if(results[i].size() != 0){
			TradeRecord tradeRecord =  convertToCTPTrade(results[i]);
			tradeRecords.push_back(tradeRecord);
		}
	}
	return  tradeRecords;
}