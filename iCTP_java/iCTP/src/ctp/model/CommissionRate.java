/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海卷卷猫信息技术有限公司-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海卷卷猫信息技术有限公司-周淋霞;
 3.该程序不开源，需要得到授权才能使用。
 */

package ctp.model;

public class CommissionRate {
	// 经纪公司代码
	public String m_brokerID;
	// 收费方式
	public String m_calculateMode;
	// 平仓手续费率
	public double m_closeRatioByMoney;
	// 平仓手续费
	public double m_closeRatioByVolume;
	// 平今手续费率
	public double m_closeTodayRatioByMoney;
	// 平今手续费
	public double m_closeTodayRatioByVolume;
	// 平今费
	public double m_closeTodayFee;
	// 合约代码
	public String m_code;
	// 代码
	public String m_commodityNo;
	// 类型
	public String m_commodityType;
	// 交易所编号
	public String m_exchangeNo;
	// 投资者代码
	public String m_investorID;
	// 投资者范围
	public String m_investorRange;
	// 来源
	public String m_matchSource;
	// 开平费
	public double m_openCloseFee;
	// 开仓手续费率
	public double m_openRatioByMoney;
	// 开仓手续费
	public double m_openRatioByVolume;
}
