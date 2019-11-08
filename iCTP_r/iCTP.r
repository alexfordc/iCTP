library("Rcpp")#加载RCpp 调用c++ 方法
library("hash")#加载hash, 返回hash表结构数据
sourceCpp("iCTP.cpp")

iCTP.askClose <- function(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef)
{
  return(askClose(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef))
}

iCTP.askCloseToday <- function(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef)
{
  return(askCloseToday(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef))
}

iCTP.askOpen <- function(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef)
{
  return(askOpen(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef))
}

iCTP.bidClose <- function(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef)
{
  return(bidClose(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef))
}

iCTP.bidCloseToday <- function(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef)
{
  return(bidCloseToday(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef))
}

iCTP.bidOpen <- function(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef)
{
  return(bidOpen(ctpID, requestID, code, exchangeID, price, qty, timeCondition, orderRef))
}

iCTP.cancelOrder <- function(ctpID, requestID, exchangeID, orderSysID, orderRef)
{
  return(cancelOrder(ctpID, requestID, exchangeID, orderSysID, orderRef))
}

#登录成功后创建
iCTP.create <- function()
{
  create()
}

##GenerateReqID
iCTP.generateReqID <- function(ctpID)
{
  return(generateReqID(ctpID))
}

#TODO
iCTP.getAccountData <- function(ctpID)
{
  cppResult <- getAccountData(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("brokerID", 
            "accountID", 
            "preMortgage", 
            "preCredit", 
            "preDeposit", 
            "preBalance", 
            "preMargin", 
            "interestBase", 
            "interest", 
            "deposit", 
            "withdraw", 
            "frozenMargin", 
            "frozenCash", 
            "frozenCommission", 
            "currMargin", 
            "cashIn", 
            "commission", 
            "closeProfit", 
            "positionProfit", 
            "balance", 
            "available", 
            "withdrawQuota", 
            "reserve", 
            "tradingDay", 
            "settlementID", 
            "credit", 
            "mortgage", 
            "exchangeMargin", 
            "deliveryMargin", 
            "exchangeDeliveryMargin", 
            "reserveBalance", 
            "currencyID", 
            "preFundMortgageIn", 
            "preFundMortgageOut", 
            "fundMortgageIn", 
            "fundMortgageOut", 
            "fundMortgageAvailable", 
            "mortgageableFund", 
            "specProductMargin", 
            "specProductFrozenMargin", 
            "specProductCommission", 
            "specProductFrozenCommission", 
            "specProductPositionProfit", 
            "specProductCloseProfit", 
            "specProductPositionProfitByAlg", 
            "specProductExchangeMargin", 
            "dynamicBalance", 
            "risk")
    return(hash(keys = rowNames, values = localIst))
  }
}

iCTP.getBrokerID <- function(ctpID)
{
  return(GetBrokerID(ctpID))
}

iCTP.getCommissionRate <- function(ctpID, code)
{
	cppResult <- GetCommissionRate(ctpID, code)
	if(cppResult == "")
	{
		return("")
	}
	localIst <- unlist(strsplit(cppResult, ","))
	rowNames <- c("code", 
            "investorRange", 
            "brokerID", 
            "investorID", 
            "openRatioByMoney", 
            "openRatioByVolume", 
            "closeRatioByMoney", 
            "closeRatioByVolume", 
            "closeTodayRatioByMoney", 
            "closeTodayRatioByVolume")
	return(hash(keys = rowNames, values = localIst)) 
}

iCTP.getDepthMarketData <- function(ctpID)
{
  cppResult <- getDepthMarketData(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("tradingDay", 
                "code", 
                "exchangeID", 
                "exchangeInstID", 
                "close", 
                "preSettlementPrice", 
                "preClose", 
                "preOpenInterest", 
                "open", 
                "high", 
                "low", 
                "volume", 
                "turnover", 
                "openInterest", 
                "lastClose", 
                "settlementPrice", 
                "upperLimit", 
                "lowerLimit", 
                "preDelta", 
                "currDelta", 
                "updateTime", 
                "updateMillisec", 
                "bidPrice1", 
                "bidVolume1", 
                "askPrice1", 
                "askVolume1", 
                "bidPrice2", 
                "bidVolume2", 
                "askPrice2", 
                "askVolume2", 
                "bidPrice3", 
                "bidVolume3", 
                "askPrice3", 
                "askVolume3", 
                "bidPrice4", 
                "bidVolume4", 
                "askPrice4", 
                "askVolume4", 
                "bidPrice5", 
                "bidVolume5", 
                "askPrice5", 
                "askVolume5", 
                "averagePrice", 
                "actionDay")
    return(hash(keys = rowNames, values = localIst))
  }
}

#TODO
iCTP.getInstrumentsData <- function(ctpID)
{
  temp <- getInstrumentsData(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("instrumentID", 
                "exchangeID", 
                "instrumentName", 
                "exchangeInstID", 
                "productID", 
                "productClass", 
                "deliveryYear", 
                "deliveryMonth", 
                "maxMarketOrderVolume", 
                "minMarketOrderVolume", 
                "maxLimitOrderVolume", 
                "minLimitOrderVolume", 
                "volumeMultiple", 
                "priceTick", 
                "createDate", 
                "openDate", 
                "expireDate", 
                "startDelivDate", 
                "endDelivDate", 
                "instLifePhase", 
                "isTrading", 
                "positionType", 
                "positionDateType",    
                "longMarginRatio", 
                "shortMarginRatio", 
                "maxMarginSideAlgorithm", 
                "underlyingInstrID", 
                "strikePrice", 
                "optionsType", 
                "underlyingMultiple", 
                "combinationType")
    return(hash(keys = rowNames, values = localIst))
  }
}

iCTP.getInvestorID <- function(ctpID)
{
  return(getInvestorID(ctpID))
}

#TODO
iCTP.getMarginRate <- function(ctpID, code)
{
  temp <- getMarginRate(ctpID, code)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("code", 
            "brokerID", 
            "investorID", 
            "hedgeFlag", 
            "longMarginRatioByMoney", 
            "longMarginRatioByVolume", 
            "shortMarginRatioByMoney", 
            "shortMarginRatioByVolume", 
            "isRelativel")
    return(hash(keys = rowNames, values = localIst))
  }
}

#TODO
iCTP.getPositionData <- function(ctpID)
{
  temp <- getPositionData(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("code", 
                "brokerID", 
                "investorID", 
                "posiDirection", 
                "hedgeFlag", 
                "positionDate", 
                "ydPosition", 
                "position", 
                "longFrozen", 
                "shortFrozen", 
                "longFrozenAmount", 
                "shortFrozenAmount", 
                "openVolume", 
                "closeVolume", 
                "openAmount", 
                "closeAmount", 
                "positionCost", 
                "preMargin", 
                "useMargin", 
                "frozenMargin", 
                "frozenCash", 
                "frozenCommission", 
                "cashIn", 
                "margin", 
                "floatProfit", 
                "positionProfit", 
                "preSettlementPrice", 
                "settlementPrice", 
                "tradingDate", 
                "settlementID", 
                "openCost", 
                "exchangeMargin", 
                "combPosition", 
                "combLongFrozen", 
                "combShortFrozen", 
                "closeProfitByDate", 
                "closeProfitByTrade", 
                "todayPosition", 
                "marginRateByMoney", 
                "marginRateByVolume", 
                "strikeFrozen", 
                "strikeFrozenAmount", 
                "abandonFrozen", 
                "openPrice")
    return(hash(keys = rowNames, values = localIst))
  }
}

#TODO
iCTP.getPositionDetailData <- function(ctpID)
{
  temp <- getPositionDetailData(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("code", 
                "brokerID", 
                "investorID", 
                "hedgeFlag", 
                "direction", 
                "openDate", 
                "tradeID", 
                "volume", 
                "openPrice", 
                "tradingDay", 
                "settlementID", 
                "tradeType", 
                "combInstrumentID", 
                "exchangeID", 
                "closeProfitByDate", 
                "closeProfitByTrade", 
                "positionProfitByDate", 
                "positionProfitByTrade", 
                "margin", 
                "exchMargin", 
                "marginRateByMoney", 
                "marginRateByVolume", 
                "lastSettlementPrice", 
                "lastSettlementPrice", 
                "settlementPrice", 
                "closeVolume")
    return(hash(keys = rowNames, values = localIst))
  }
}

#TODO
iCTP.getOrderInfo <- function(ctpID)
{
  temp <- getOrderInfo(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("brokerID", 
            "investorID", 
            "code", 
            "orderRef", 
            "userID", 
            "orderPriceType", 
            "direction", 
            "combOffsetFlag", 
            "combHedgeFlag", 
            "limitPrice", 
            "volumeTotalOriginal", 
            "timeCondition", 
            "gTDDate", 
            "volumeCondition", 
            "minVolume", 
            "contingentCondition", 
            "stopPrice", 
            "forceCloseReason", 
            "isAutoSuspend", 
            "businessUnit", 
            "requestID", 
            "orderLocalID", 
            "exchangeID", 
            "participantID", 
            "clientID", 
            "exchangeInstID", 
            "traderID", 
            "installID", 
            "orderSubmitStatus", 
            "notifySequence", 
            "tradingDay", 
            "settlementID", 
            "orderSysID", 
            "orderSource", 
            "orderStatus", 
            "orderType", 
            "volumeTraded", 
            "volumeTotal", 
            "insertDate", 
            "insertTime", 
            "activeTime", 
            "suspendTime", 
            "updateTime", 
            "cancelTime", 
            "activeTraderID", 
            "clearingPartID", 
            "sequenceNo", 
            "frontID", 
            "sessionID", 
            "userProductInfo", 
            "statusMsg", 
            "userForceClose", 
            "activeUserID", 
            "brokerOrderSeq", 
            "relativeOrderSysID", 
            "zCETotalTradedVolume", 
            "isSwapOrder")
    return(hash(keys = rowNames, values = localIst))
  }
}

#TODO
iCTP.getOrderInfos <- function(ctpID)
{
  temp <- getOrderInfos(ctpID)
  return(temp)
}

iCTP.getPassword <- function(ctpID)
{
	temp <- getPassword(ctpID)
	return(temp)
}

iCTP.getSessionID <- function(ctpID)
{
  temp <- getSessionID(ctpID)
  return(temp)
}

#TODO
iCTP.getTradeRecord <- function(ctpID)
{
  temp <- getTradeRecord(ctpID)
  if(cppResult == "")
  {
    return("")
  }
  else
  {
    localIst <- unlist(strsplit(cppResult, ","))
    rowNames <- c("brokerID", 
            "investorID", 
            "code", 
            "orderRef", 
            "userID", 
            "exchangeID", 
            "tradeID", 
            "direction", 
            "orderSysID", 
            "participantID", 
            "clientID", 
            "tradingRole", 
            "exchangeInstID", 
            "offsetFlag", 
            "hedgeFlag", 
            "price", 
            "volume", 
            "tradeDate", 
            "tradeTime", 
            "tradeType", 
            "priceSource", 
            "traderID", 
            "orderLocalID", 
            "clearingPartID", 
            "businessUnit", 
            "sequenceNo", 
            "tradingDay", 
            "settlementID", 
            "brokerOrderSeq", 
            "tradeSource", 
            "commission")
    return(hash(keys = rowNames, values = localIst))
  }
}

iCTP.getTradeRecords <- function(ctpID)
{
  temp <- getTradeRecords(ctpID)
}

iCTP.getTradingDate <- function(ctpID)
{
  temp <- getTradingDate(ctpID)
  return(temp)
}

iCTP.getTradingTime <- function(ctpID)
{
  temp <- getTradingTime(ctpID)
  return(temp)
}

iCTP.isClearanced <- function(ctpID)
{
  temp <- isClearanced(ctpID)
  return(temp)
}

iCTP.isClearanceTime <- function(ctpID)
{
  temp <- isClearanceTime(ctpID)
  return(temp)
}

iCTP.isDataOk <- function(ctpID)
{
  temp <- isDataOk(ctpID)
  return(temp)
}

iCTP.isMdLogined <- function(ctpID)
{
  return(isMdLogined(ctpID))
}

iCTP.isTdLogined <- function(ctpID)
{
  return(isTdLogined(ctpID))
}

iCTP.isTradingTime <- function(ctpID)
{
  return(isTradingTime(ctpID))
}

iCTP.isTradingTimeExact <- function(ctpID, code)
{
  return(isTradingTimeExact(ctpID, code))
}

iCTP.reqCommissionRate <- function(ctpID, code, requestID)
{
  return(reqCommissionRate(ctpID, code, requestID))
}

iCTP.reqQrySettlementInfoConfirm <- function(ctpID, requestID)
{
  return(reqQrySettlementInfoConfirm(ctpID, requestID))
}

iCTP.reqQrySettlementInfo <- function(ctpID, requestID, code)
{
  return(reqQrySettlementInfo(ctpID, requestID, code))
}

iCTP.reqMarginRate <- function(ctpID, code, requestID)
{
  return(reqMarginRate(ctpID, code, requestID))
}

#Start
iCTP.start <- function(ctpID, ctpRequestID, tradIP, quoteIP, brokerID, userID, userPWd)
{
  return(start(ctpID, ctpRequestID, tradIP, quoteIP, brokerID, userID, userPWd))
}

iCTP.subMarketDatas <- function(ctpID, ctpRequestID, stockID)
{
  return (subMarketDatas(ctpID, ctpRequestID, stockID))
}

iCTP.unSubMarketDatas <- function(ctpID, requestID, codes)
{
  return(unSubMarketDatas(ctpID, requestID, codes))
}


