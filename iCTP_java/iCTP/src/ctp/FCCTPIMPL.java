/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海宁米科技创始人-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海宁米科技创始人-袁立涛(微信号:wx627378127);
 3.联合创始人-肖添龙(微信号:xiaotianlong_luu);
 4.联合开发者-陈晓阳(微信号:chenxiaoyangzxy)，助理-朱炜(微信号:cnnic_zhu);
 5.该程序开源协议为BSD，欢迎对我们的创业活动进行各种支持，欢迎更多开发者加入。
 */

package ctp;

import java.util.List;

import ctp.model.Security;
import ctp.model.SecurityLatestData;

/**
 * Lord CTP java 接口
 * 
 * @author todd
 *
 */
public class FCCTPIMPL implements FCCTP {

	private static IFCCTP m_ctpBridge;

	public FCCTPIMPL() {
		if (m_ctpBridge == null) {
			m_ctpBridge = new IFCCTP();
		}
	}

	public int askClose(int ctpID, int requestID, String code, double price, char qty, char timeCondition,
			String orderRef) {
		return m_ctpBridge.askClose(ctpID, requestID, code, price, qty, timeCondition, orderRef);
	}

	public int askCloseToday(int ctpID, int requestID, String code, double price, char qty, char timeCondition,
			String orderRef) {
		return m_ctpBridge.askCloseToday(ctpID, requestID, code, price, qty, timeCondition, orderRef);
	}

	public int askOpen(int ctpID, int requestID, String code, double price, char qty, char timeCondition,
			String orderRef) {
		return m_ctpBridge.askOpen(ctpID, requestID, code, price, qty, timeCondition, orderRef);
	}

	public int bidClose(int ctpID, int requestID, String code, double price, char qty, char timeCondition,
			String orderRef) {
		return m_ctpBridge.bidClose(ctpID, requestID, code, price, qty, timeCondition, orderRef);
	}

	public int bidCloseToday(int ctpID, int requestID, String code, double price, char qty, char timeCondition,
			String orderRef) {
		return m_ctpBridge.bidCloseToday(ctpID, requestID, code, price, qty, timeCondition, orderRef);
	}

	public int bidOpen(int ctpID, int requestID, String code, double price, char qty, char timeCondition,
			String orderRef) {
		return m_ctpBridge.bidOpen(ctpID, requestID, code, price, qty, timeCondition, orderRef);
	}

	public int cancelOrder(int ctpID, int requestID, String exchangeID, String orderSysID, String orderRef) {
		return m_ctpBridge.cancelOrder(ctpID, requestID, exchangeID, orderSysID, orderRef);
	}

	public int create() {
		return m_ctpBridge.create();
	}

	public int generateReqID(int ctpID) {
		return m_ctpBridge.generateReqID(ctpID);
	}

	public String getAccountData(int ctpID) {
		return m_ctpBridge.getAccountData(ctpID);
	}

	public String getBrokerID(int ctpID) {
		return m_ctpBridge.getBrokerID(ctpID);
	}
        
	public String getCommissionRate(int ctpID, String code) {
		return m_ctpBridge.getCommissionRate(ctpID, code);
	}

	public SecurityLatestData getDepthMarketData(int ctpID) {
		String ctpRetStr = m_ctpBridge.getDepthMarketData(ctpID);
		if (ctpRetStr != null && ctpRetStr.trim().length() != 0) {
			return CTPConvert.ConvertToCTPDepthMarketData(ctpRetStr);
		}
		return null;
	}

	public List<Security> getInstrumentsData(int ctpID) {
		String ctpRetStr = m_ctpBridge.getInstrumentsData(ctpID);
		if (ctpRetStr != null && ctpRetStr.trim().length() != 0) {
			return CTPConvert.ConvertToCTPInstrumentDatas(ctpRetStr);
		}
		return null;
	}

	public String getInvestorID(int ctpID) {
		return m_ctpBridge.getInvestorID(ctpID);
	}

	public String getMarginRate(int ctpID, String code) {
		return m_ctpBridge.getMarginRate(ctpID, code);
	}

	public String getOrderInfo(int ctpID) {
		return m_ctpBridge.getOrderInfo(ctpID);
	}

	public String getOrderInfos(int ctpID) {
		return m_ctpBridge.getOrderInfos(ctpID);
	}

	public String getPassword(int ctpID) {
		return m_ctpBridge.getPassword(ctpID);
	}
        
	public String getPositionData(int ctpID) {
		return m_ctpBridge.getPositionData(ctpID);
	}

	public String getPositionDetailData(int ctpID) {
		return m_ctpBridge.getPositionDetailData(ctpID);
	}

	public int getSessionID(int ctpID) {
		return m_ctpBridge.getSessionID(ctpID);
	}

	public String getTradeRecord(int ctpID) {

		return m_ctpBridge.getTradeRecord(ctpID);
	}

	public String getTradeRecords(int ctpID) {

		return m_ctpBridge.getTradeRecords(ctpID);
	}

	public String getTradingDate(int ctpID) {
		return m_ctpBridge.getTradingDate(ctpID);
	}

	public String getTradingTime(int ctpID) {
		return m_ctpBridge.getTradingTime(ctpID);
	}

	public int isClearanced(int ctpID) {
		return m_ctpBridge.isClearanced(ctpID);
	}

	public int isClearanceTime(int ctpID) {
		return m_ctpBridge.isClearanceTime(ctpID);
	}
        
        public int isDataOk(int ctpID) {
		return m_ctpBridge.isDataOk(ctpID);
	}

	public boolean isMdLogined(int ctpID) {
		return m_ctpBridge.isMdLogined(ctpID) > 0 ? true : false;
	}

	public boolean isTdLogined(int ctpID) {
		return m_ctpBridge.isTdLogined(ctpID) > 0 ? true : false;
	}

	public int isTradingTime(int ctpID) {
		return m_ctpBridge.isTradingTime(ctpID);
	}

	public int isTradingTimeExact(int ctpID, String code) {
		return m_ctpBridge.isTradingTimeExact(ctpID, code);
	}

	public int reqCommissionRate(int ctpID, String code, int requestID) {
		return m_ctpBridge.reqCommissionRate(ctpID, code, requestID);
	}

	public int reqMarginRate(int ctpID, String code, int requestID) {

		return m_ctpBridge.reqMarginRate(ctpID, code, requestID);
	}

	public int reqQrySettlementInfoConfirm(int ctpID, int requestID) {
		return m_ctpBridge.reqQrySettlementInfoConfirm(ctpID, requestID);
	}
        
        public int reqQrySettlementInfo(int ctpID, int requestID, String tradingDate) {
		return m_ctpBridge.reqQrySettlementInfo(ctpID, requestID, tradingDate);
	}

	public int start(int ctpID, int requestID, String mdServer, String tdServer, String brokerID, String investorID,
			String password) {
		return m_ctpBridge.start(ctpID, requestID, mdServer, tdServer, brokerID, investorID, password);
	}

	public int subMarketDatas(int ctpID, int requestID, String code) {
		return m_ctpBridge.subMarketDatas(ctpID, requestID, code);
	}

	public int unSubMarketDatas(int ctpID, int requestID, String codes) {
		return m_ctpBridge.subMarketDatas(ctpID, requestID, codes);
	}
}
