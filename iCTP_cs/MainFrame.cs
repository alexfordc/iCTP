/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����è��Ϣ�������޹�˾-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����è��Ϣ�������޹�˾-����ϼ;
 3.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FaceCat;
using System.Net;
using System.IO;

namespace FaceCat {
    /// <summary>
    /// ��������
    /// </summary>
    public class MainFrame : UIXmlEx {
        /// <summary>
        /// ���캯��
        /// </summary>
        public MainFrame() {
        }

        public static int CLOSE_INDEX = 0;
        public static int OPEN_INDEX = 1;
        public static int HIGH_INDEX = 2;
        public static int LOW_INDEX = 3;
        public static int VOL_INDEX = 4;
        public static int AMOUNT_INDEX = 5;
        public static int AVGPRICE_INDEX = 6;

        /// <summary>
        /// ͼ��
        /// </summary>
        private FCChart m_chart;

        /// <summary>
        /// ��ǰ�Ĵ���
        /// </summary>
        private String m_currentCode;

        /// <summary>
        /// ��ͼ��
        /// </summary>
        private FCDiv m_divMain;

        /// <summary>
        /// �ֱֲ��
        /// </summary>
        private FCGrid m_gridInvestorPositions;

        /// <summary>
        /// �ֱֲ���������
        /// </summary>
        private Dictionary<int, FCGridColumn> m_gridInvestorPositionColumns = new Dictionary<int, FCGridColumn>();

        /// <summary>
        /// �������ݱ��
        /// </summary>
        private FCGrid m_gridLatestData;

        /// <summary>
        /// �������ݱ���������
        /// </summary>
        private Dictionary<int, FCGridColumn> m_gridLatestDataColumns = new Dictionary<int, FCGridColumn>();

        /// <summary>
        /// ί�лر����
        /// </summary>
        private FCGrid m_gridOrderInfos;

        /// <summary>
        /// ί�лر�����������
        /// </summary>
        private Dictionary<int, FCGridColumn> m_gridOrderInfoColumns = new Dictionary<int, FCGridColumn>();

        /// <summary>
        /// �ɽ��ر����
        /// </summary>
        private FCGrid m_gridTradeRecords;

        /// <summary>
        /// �ɽ��ر�����������
        /// </summary>
        private Dictionary<int, FCGridColumn> m_gridTradeRecordsColumns = new Dictionary<int, FCGridColumn>();

        /// <summary>
        /// �󶨵�K��
        /// </summary>
        /// <param name="datas">����</param>
        private void bindChart(List<SecurityData> datas) {
            if (datas != null) {
                FCDataTable dataSource = m_chart.DataSource;
                int datasCount = datas.Count;
                if (dataSource.RowsCount == 0) {
                    for (int i = 0; i < datasCount; i++) {
                        SecurityData data = datas[i];
                        DateTime dateTime = Convert.ToDateTime(data.m_date);
                        double dateNum = FCStr.getDateNum(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, 0);
                        dataSource.set(dateNum, CLOSE_INDEX, data.m_close);
                        dataSource.set(dateNum, OPEN_INDEX, data.m_open);
                        dataSource.set(dateNum, HIGH_INDEX, data.m_high);
                        dataSource.set(dateNum, LOW_INDEX, data.m_low);
                        dataSource.set(dateNum, AVGPRICE_INDEX, data.m_ma);
                    }
                    m_chart.scrollRightToEnd();
                }
                else {
                    if (datasCount > 0) {
                        SecurityData data = datas[datasCount - 1];
                        DateTime dateTime = Convert.ToDateTime(data.m_date);
                        double dateNum = FCStr.getDateNum(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, 0);
                        dataSource.set(dateNum, CLOSE_INDEX, data.m_close);
                        dataSource.set(dateNum, OPEN_INDEX, data.m_open);
                        dataSource.set(dateNum, HIGH_INDEX, data.m_high);
                        dataSource.set(dateNum, LOW_INDEX, data.m_low);
                        dataSource.set(dateNum, AVGPRICE_INDEX, data.m_ma);
                    }
                }
                m_chart.update();
                m_chart.invalidate();
            }
        }

        /// <summary>
        /// �󶨳ֲ�
        /// </summary>
        /// <param name="investorPositions">�ֲ�����</param>
        private void bindInvestorPositions(List<InvestorPosition> investorPositions) {
            FCGridRow[] gridRows = m_gridInvestorPositions.m_rows.ToArray();
            Dictionary<String, String> codes = new Dictionary<String, String>();
            Dictionary<String, String> removeCodes = new Dictionary<String, String>();
            List<InvestorPosition> bindInvestorPositions = new List<InvestorPosition>();
            foreach (InvestorPosition investorPosition in investorPositions) {
                if (investorPosition.m_position > 0) {
                    codes[investorPosition.m_code + investorPosition.m_posiDirection] = "";
                    bindInvestorPositions.Add(investorPosition);
                }
                else {
                    removeCodes[investorPosition.m_code + investorPosition.m_posiDirection] = "";
                }
            }
            Dictionary<String, FCGridRow> rowsMap = new Dictionary<string, FCGridRow>();
            foreach (FCGridRow row in gridRows) {
                String key = row.GetCell("colI1").getString() + row.GetCell("colI2").getString();
                if (codes.ContainsKey(key)) {
                    rowsMap[key] = row;
                }
                if (removeCodes.ContainsKey(key)) {
                    m_gridInvestorPositions.removeRow(row);
                    rowsMap.Remove(key);
                    row.delete();
                }
            }
            m_gridInvestorPositions.update();
            m_gridInvestorPositions.beginUpdate();
            foreach (InvestorPosition investorPosition in bindInvestorPositions) {
                FCGridRow row = null;
                String key = investorPosition.m_code + investorPosition.m_posiDirection;
                bool newData = false;
                if (rowsMap.ContainsKey(key)) {
                    row = rowsMap[key];
                }
                else {
                    newData = true;
                    row = new FCGridRow();
                    row.Height = 20;
                    m_gridInvestorPositions.addRow(row);
                    rowsMap[key] = row;
                }
                foreach (int col in m_gridInvestorPositionColumns.Keys) {
                    FCGridColumn column = m_gridInvestorPositionColumns[col];
                    FCGridCell cell = null;
                    if (newData) {
                        cell = createCell(column.ColumnType);
                        row.addCell(column.Index, cell);
                    }
                    else {
                        cell = row.getCell(column.Index);
                    }
                    switch (col) {
                        case 1:
                            cell.setString(investorPosition.m_code);
                            break;
                        case 2:
                            cell.setString(investorPosition.m_posiDirection);
                            break;
                        case 3:
                            cell.setInt(investorPosition.m_position);
                            break;
                        case 4:
                            cell.setInt(investorPosition.m_ydPosition);
                            break;
                        case 5:
                            cell.setInt(investorPosition.m_position - investorPosition.m_ydPosition);
                            break;
                        case 6:
                            cell.setInt(investorPosition.m_position);
                            break;
                        case 7:
                            if (investorPosition.m_position > 0) {
                                cell.setDouble(investorPosition.m_positionCost / investorPosition.m_position);
                            }
                            else {
                                cell.setDouble(0);
                            }
                            break;
                        case 8:
                            cell.setDouble(investorPosition.m_positionProfit);
                            break;
                        case 9:
                            cell.setDouble(investorPosition.m_floatProfit);
                            break;
                        case 10:
                            cell.setDouble(investorPosition.m_margin);
                            break;
                    }
                }
            }
            m_gridInvestorPositions.endUpdate();
            m_gridInvestorPositions.invalidate();
            bindInvestorPositions.Clear();
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="latestDatas">��������</param>
        private void bindLatestData(List<SecurityLatestData> latestDatas) {
            foreach (SecurityLatestData latestData in latestDatas) {
                if (m_currentCode == null) {
                    m_currentCode = latestData.m_code;
                }
                dealStrategy(latestData);
            }
            FCGridRow[] gridRows = m_gridLatestData.m_rows.ToArray();
            Dictionary<String, FCGridRow> rowsMap = new Dictionary<string, FCGridRow>();
            foreach (FCGridRow row in gridRows) {
                String code = row.GetCell("colL1").getString();
                rowsMap[code] = row;
            }
            m_gridLatestData.beginUpdate();
            foreach (SecurityLatestData latestData in latestDatas) {
                FCGridRow row = null;
                String key = latestData.m_code;
                bool newData = false;
                if (rowsMap.ContainsKey(key)) {
                    row = rowsMap[key];
                }
                else {
                    newData = true;
                    row = new FCGridRow();
                    row.Height = 20;
                    m_gridLatestData.addRow(row);
                    rowsMap[latestData.m_code] = row;
                }
                foreach (int col in m_gridLatestDataColumns.Keys) {
                    FCGridColumn column = m_gridLatestDataColumns[col];
                    FCGridCell cell = null;
                    if (newData) {
                        cell = createCell(column.ColumnType);
                        row.addCell(column.Index, cell);
                    }
                    else {
                        cell = row.getCell(column.Index);
                    }
                    switch (col) {
                        case 1:
                            cell.setString(latestData.m_code);
                            break;
                        case 2:
                            cell.setDouble(latestData.m_close);
                            break;
                        case 3:
                            cell.setDouble(latestData.m_bidPrice1);
                            break;
                        case 4:
                            cell.setInt(latestData.m_bidVolume1);
                            break;
                        case 5:
                            cell.setDouble(latestData.m_askPrice1);
                            break;
                        case 6:
                            cell.setInt(latestData.m_askVolume1);
                            break;
                        case 7:
                            cell.setDouble(latestData.m_openInterest);
                            break;
                        case 8:
                            cell.setDouble(latestData.m_volume);
                            break;
                        case 9:
                            cell.setString(latestData.m_updateTime);
                            break;
                        case 10:
                            cell.setString(latestData.m_state1 == 1 ? "��" : "��");
                            break;
                        case 11:
                            cell.setString(latestData.m_state2 == 1 ? "��" : "��");
                            break;
                        case 12:
                            cell.setString(latestData.m_state3 == 1 ? "��" : "��");
                            break;
                        case 13:
                            cell.setString(latestData.m_state4 == 1 ? "��" : "��");
                            break;
                        case 14:
                            if (Strategy1.m_tradeVolumes.ContainsKey(latestData.m_code)) {
                                cell.setString("��");
                            }
                            else {
                                cell.setString("��");
                            }
                            break;
                    }
                }
            }
            m_gridLatestData.endUpdate();
            m_gridLatestData.invalidate();
        }

        /// <summary>
        /// �󶨹ҵ�
        /// </summary>
        /// <param name="orderInfos">ί�лر�</param>
        private void bindOrderInfos(List<OrderInfo> orderInfos, bool isNew) {
            Dictionary<String, OrderInfo> filterOrderInfos = new Dictionary<string, OrderInfo>();
            foreach (OrderInfo orderInfo in orderInfos) {
                filterOrderInfos[orderInfo.m_orderSysID] = orderInfo;
            }
            FCGridRow[] gridRows = m_gridOrderInfos.m_rows.ToArray();
            Dictionary<String, FCGridRow> rowsMap = new Dictionary<string, FCGridRow>();
            foreach (FCGridRow row in gridRows) {
                String orderID = row.GetCell("colP1").getString();
                rowsMap[orderID] = row;
            }
            m_gridOrderInfos.update();
            m_gridOrderInfos.beginUpdate();
            foreach (OrderInfo orderInfo in filterOrderInfos.Values) {
                FCGridRow row = null;
                String key = orderInfo.m_orderSysID;
                bool newData = false;
                if (rowsMap.ContainsKey(key)) {
                    row = rowsMap[key];
                }
                else {
                    newData = true;
                    row = new FCGridRow();
                    row.Height = 20;
                    if (isNew) {
                        m_gridOrderInfos.insertRow(0, row);
                    }
                    else {
                        m_gridOrderInfos.addRow(row);
                    }
                    rowsMap[key] = row;
                }
                foreach (int col in m_gridOrderInfoColumns.Keys) {
                    FCGridColumn column = m_gridOrderInfoColumns[col];
                    FCGridCell cell = null;
                    if (newData) {
                        cell = createCell(column.ColumnType);
                        row.addCell(column.Index, cell);
                    }
                    else {
                        cell = row.getCell(column.Index);
                    }
                    switch (col) {
                        case 1:
                            cell.setString(orderInfo.m_orderSysID);
                            break;
                        case 2:
                            cell.setString(orderInfo.m_code);
                            break;
                        case 3:
                            cell.setString(orderInfo.m_direction);
                            break;
                        case 4:
                            cell.setString(orderInfo.m_combOffsetFlag);
                            break;
                        case 5:
                            cell.setInt(orderInfo.m_volumeTotalOriginal);
                            break;
                        case 6:
                            cell.setInt(orderInfo.m_volumeTraded);
                            break;
                        case 7:
                            cell.setDouble(orderInfo.m_limitPrice);
                            break;
                        case 8:
                            cell.setString(orderInfo.m_orderStatus);
                            break;
                        case 9:
                            cell.setString(orderInfo.m_insertTime);
                            break;
                    }
                }
            }
            m_gridOrderInfos.endUpdate();
            m_gridOrderInfos.invalidate();
        }

        /// <summary>
        /// ���ʽ��˻�����
        /// </summary>
        /// <param name="accountData">�ʽ�����</param>
        private void bindAccountData(AccountData accountData) {
            getLabel("fundLabel1").Text = accountData.m_dynamicBalance.ToString();
            getLabel("fundLabel2").Text = accountData.m_positionProfit.ToString();
            getLabel("fundLabel3").Text = accountData.m_closeProfit.ToString();
            getLabel("fundLabel4").Text = accountData.m_commission.ToString();
            getLabel("fundLabel5").Text = accountData.m_frozenMargin.ToString();
            getLabel("fundLabel6").Text = accountData.m_risk.ToString();
            Native.invalidate();
        }


        /// <summary>
        /// �󶨳ɽ��ر�
        /// </summary>
        /// <param name="tradeRecords">�ɽ��ر�</param>
        private void bindTradeRecords(List<TradeRecord> tradeRecords, bool isNew) {
            FCGridRow[] gridRows = m_gridTradeRecords.m_rows.ToArray();
            Dictionary<String, FCGridRow> rowsMap = new Dictionary<string, FCGridRow>();
            foreach (FCGridRow row in gridRows) {
                String traderID = row.GetCell("colT1").getString();
                rowsMap[traderID] = row;
            }
            m_gridTradeRecords.update();
            m_gridTradeRecords.beginUpdate();
            foreach (TradeRecord tradeRecord in tradeRecords) {
                FCGridRow row = null;
                String key = tradeRecord.m_tradeID;
                bool newData = false;
                if (rowsMap.ContainsKey(key)) {
                    row = rowsMap[key];
                }
                else {
                    newData = true;
                    row = new FCGridRow();
                    row.Height = 20;
                    if (isNew) {
                        m_gridTradeRecords.insertRow(0, row);
                    }
                    else {
                        m_gridTradeRecords.addRow(row);
                    }
                    rowsMap[key] = row;
                }
                foreach (int col in m_gridTradeRecordsColumns.Keys) {
                    FCGridColumn column = m_gridTradeRecordsColumns[col];
                    FCGridCell cell = null;
                    if (newData) {
                        cell = createCell(column.ColumnType);
                        row.addCell(column.Index, cell);
                    }
                    else {
                        cell = row.getCell(column.Index);
                    }
                    switch (col) {
                        case 1:
                            cell.setString(tradeRecord.m_tradeID);
                            break;
                        case 2:
                            cell.setString(tradeRecord.m_code);
                            break;
                        case 3:
                            cell.setString(tradeRecord.m_direction);
                            break;
                        case 4:
                            cell.setString(tradeRecord.m_offsetFlag);
                            break;
                        case 5:
                            cell.setDouble(tradeRecord.m_price);
                            break;
                        case 6:
                            cell.setInt(tradeRecord.m_volume);
                            break;
                        case 7:
                            cell.setString(tradeRecord.m_tradeTime);
                            break;
                        case 8:
                            cell.setString(tradeRecord.m_orderSysID);
                            break;
                        case 9:
                            cell.setString(tradeRecord.m_tradeType);
                            break;
                        case 10:
                            cell.setDouble(tradeRecord.m_commission);
                            break;
                        case 11:
                            cell.setString(tradeRecord.m_exchangeID);
                            break;
                    }
                }
            }
            m_gridTradeRecords.endUpdate();
            m_gridTradeRecords.invalidate();
        }


        /// <summary>
        /// ����¼�
        /// </summary>
        /// <param name="sender">������</param>
        /// <param name="mp">����</param>
        /// <param name="button">��ť</param>
        /// <param name="clicks">�������</param>
        /// <param name="delta">����ֵ/param>
        private void clickEvent(object sender, FCTouchInfo touchInfo) {
            if (touchInfo.m_firstTouch && touchInfo.m_clicks == 1) {
                FCView control = sender as FCView;
                String name = control.Name;
                if (name == "btnStart") {
                    String codes = getTextBox("txtCodes").Text;
                    String filePath = Application.StartupPath + "\\TradeCodes.txt";
                    FCFile.write(filePath, codes);
                    //ע�����µ�����
                    CTPDLL.subMarketDatas(Strategy1.m_ctpID, CTPDLL.generateReqID(Strategy1.m_ctpID), codes);
                    control.Enabled = false;
                    control.Text = "������";
                    String[] splitCodes = codes.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    int splitCodesSize = (int)splitCodes.Length;
                    lock (Strategy1.m_historyDatas) {
                        for (int i = 0; i < splitCodesSize; i++) {
                            Strategy1.m_historyDatas[splitCodes[i]] = null;
                            lock (Strategy1.m_cd1) {
                                Strategy1.m_cd1[splitCodes[i]] = 30;
                            }
                            if (!Strategy1.m_tradeVolumes.ContainsKey(splitCodes[i])) {
                                Strategy1.m_tradeVolumes[splitCodes[i]] = 1;
                            }
                        }
                    }
                    m_m = (int)(findControl("spinM") as FCSpin).Value;
                    m_n = (int)(findControl("spinN") as FCSpin).Value;
                    Thread.Sleep(1000);
                    Thread tThread = new Thread(new ThreadStart(run));
                    tThread.Start();
                    Thread tThread2 = new Thread(new ThreadStart(Strategy1.updateCD));
                    tThread2.Start();
                }
                else if (name == "btnSettlementInfo") {
                    SettlementWindow settlementWindow = new SettlementWindow();
                    settlementWindow.Show();
                    settlementWindow.QuerySettlementInfo(Strategy1.m_ctpID, "");
                }
            }
        }

        /// <summary>
        /// �����е����ʹ�����Ԫ��
        /// </summary>
        /// <param name="columnType">�е�����</param>
        /// <returns>��Ԫ��</returns>
        public static FCGridCell createCell(String columnType) {
            FCGridCell cell = null;
            if (columnType == "int") {
                cell = new FCGridIntCell();
            }
            else if (columnType == "double") {
                cell = new FCGridDoubleCell();
            }
            else {
                cell = new FCGridStringCell();
            }
            return cell;
        }

        /// <summary>
        /// ��ȡ�е�����
        /// </summary>
        /// <param name="grid">���</param>
        /// <param name="columnsIndex">�е�����</param>
        /// <returns>״̬</returns>
        public static int getColumnsIndex(FCGrid grid, Dictionary<int, FCGridColumn> columnsIndex) {
            List<FCGridColumn> columns = grid.m_columns;
            int columnsSize = columns.Count;
            for (int i = 0; i < columnsSize; i++) {
                FCGridColumn column = columns[i];
                columnsIndex[FCStr.convertStrToInt(column.Name.Substring(4))] = column;
            }
            return 1;
        }

        /// <summary>
        /// ��Ԫ�����¼�
        /// </summary>
        /// <param name="sender">������</param>
        /// <param name="cell">��Ԫ��</param>
        /// <param name="mp">����</param>
        /// <param name="button">��ť</param>
        /// <param name="clicks">�������</param>
        /// <param name="delta">����ֵ</param>
        private void gridCellClick(object sender, FCGridCell cell, FCTouchInfo touchInfo) {
            if (touchInfo.m_firstTouch) {
                if (sender == m_gridLatestData) {
                    m_currentCode = cell.Row.GetCell("colL1").getString();
                    m_chart.clear();
                    m_chart.invalidate();
                    lock (Strategy1.m_historyDatas) {
                        if (Strategy1.m_historyDatas.ContainsKey(m_currentCode)) {
                            bindChart(Strategy1.m_historyDatas[m_currentCode]);
                        }
                    }
                }
                else if (sender == m_gridInvestorPositions) {
                    if (touchInfo.m_clicks == 2) {
                        String code = cell.Row.GetCell("colI1").getString();
                        String direction = cell.Row.GetCell("colI2").getString();
                        if (DialogResult.Yes == MessageBox.Show("�Ƿ��м�ƽ��? ����:" + code + " ����:" + (direction == "��" ? "��" : "��"), "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {

                            InvestorPosition investorPosition = null;
                            lock (Strategy1.m_investorPositions) {
                                if (Strategy1.m_investorPositions.ContainsKey(code + direction)) {
                                    investorPosition = Strategy1.m_investorPositions[code + direction];
                                }
                            }
                            if (investorPosition != null) {
                                Strategy1.askOrBidClose(investorPosition, code, direction, 0, 0, 0);
                            }
                        }
                    }
                }
                else if (sender == m_gridOrderInfos) {
                    if (touchInfo.m_clicks == 2) {
                        String orderSysID = cell.Row.GetCell("colP1").getString();
                        String code = cell.Row.GetCell("colP2").getString();
                        Security security = null;
                        lock (Strategy1.m_securities) {
                            if (Strategy1.m_securities.ContainsKey(code)) {
                                security = Strategy1.m_securities[code];
                            }
                        }
                        if (security != null) {
                            CTPDLL.cancelOrder(Strategy1.m_ctpID, CTPDLL.generateReqID(Strategy1.m_ctpID), security.m_exchangeID, orderSysID, "");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��ʼ��ͼ��
        /// </summary>
        /// <param name="chart">ͼ��</param>
        private void initChart(FCChart chart) {
            FCDataTable dataSource = chart.DataSource;
            chart.LeftVScaleWidth = 85;
            chart.RightVScaleWidth = 85;
            chart.HScalePixel = 10;
            chart.HScaleFieldText = "����";
            chart.ScrollAddSpeed = true;
            ChartDiv candleDiv = chart.addDiv();
            CandleShape candle = new CandleShape();
            candleDiv.addShape(candle);
            candle.CloseField = CLOSE_INDEX;
            candle.OpenField = OPEN_INDEX;
            candle.HighField = HIGH_INDEX;
            candle.LowField = LOW_INDEX;
            candle.CloseFieldText = "����";
            candle.HighFieldText = "���";
            candle.LowFieldText = "���";
            candle.OpenFieldText = "����";
            candleDiv.TitleBar.Titles.Add(new CTitle(CLOSE_INDEX, "CLOSE", FCColor.argb(255, 255, 255), 2, true));
            candleDiv.TitleBar.Titles.Add(new CTitle(HIGH_INDEX, "HIGH", FCColor.argb(255, 255, 255), 2, true));
            candleDiv.TitleBar.Titles.Add(new CTitle(LOW_INDEX, "LOW", FCColor.argb(255, 255, 255), 2, true));
            candleDiv.TitleBar.Titles.Add(new CTitle(OPEN_INDEX, "OPEN", FCColor.argb(255, 255, 255), 2, true));
            candleDiv.TitleBar.Titles.Add(new CTitle(AVGPRICE_INDEX, "MA" + m_m.ToString(), FCColor.argb(255, 255, 80), 2, true));
            PolylineShape polyLineShape = new PolylineShape();
            polyLineShape.FieldText = "MA" + m_m.ToString();
            candleDiv.addShape(polyLineShape);
            polyLineShape.FieldName = AVGPRICE_INDEX;
            dataSource.addColumn(CLOSE_INDEX);
            dataSource.addColumn(OPEN_INDEX);
            dataSource.addColumn(HIGH_INDEX);
            dataSource.addColumn(LOW_INDEX);
            dataSource.addColumn(AVGPRICE_INDEX);
            dataSource.setColsCapacity(16);
            dataSource.setColsGrowStep(4);
        }

        /// <summary>
        /// �������̷߳���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void invoke(object sender, object args) {
            if (args is AccountData) {
                bindAccountData(args as AccountData);
            }
            else if (args is List<InvestorPosition>) {
                bindInvestorPositions(args as List<InvestorPosition>);
            }
            else if (args is TradeRecord) {
                List<TradeRecord> tradeRecords = new List<TradeRecord>();
                tradeRecords.Add(args as TradeRecord);
                bindTradeRecords(tradeRecords, true);
            }
            else if (args is List<TradeRecord>) {
                bindTradeRecords(args as List<TradeRecord>, false);
            }
            else if (args is OrderInfo) {
                List<OrderInfo> orderInfos = new List<OrderInfo>();
                orderInfos.Add(args as OrderInfo);
                bindOrderInfos(orderInfos, true);
            }
            else if (args is List<OrderInfo>) {
                bindOrderInfos(args as List<OrderInfo>, false);
            }
            else if (args is List<SecurityLatestData>) {
                bindLatestData(args as List<SecurityLatestData>);
            }
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="control">�ؼ�</param>
        public override void loadFile(string fileName, FCView control) {
            base.loadFile(fileName, control);
            m_gridLatestData = getGrid("gridLatestData");
            getColumnsIndex(m_gridLatestData, m_gridLatestDataColumns);
            m_gridLatestData.addEvent(new FCGridCellTouchEvent(gridCellClick), FCEventID.GRIDCELLCLICK);
            m_gridOrderInfos = getGrid("gridOrderInfos");
            getColumnsIndex(m_gridOrderInfos, m_gridOrderInfoColumns);
            m_gridOrderInfos.addEvent(new FCGridCellTouchEvent(gridCellClick), FCEventID.GRIDCELLCLICK);
            m_gridInvestorPositions = getGrid("gridInvestorPositions");
            m_gridInvestorPositions.addEvent(new FCGridCellTouchEvent(gridCellClick), FCEventID.GRIDCELLCLICK);
            getColumnsIndex(m_gridInvestorPositions, m_gridInvestorPositionColumns);
            m_gridTradeRecords = getGrid("gridTradeRecords");
            getColumnsIndex(m_gridTradeRecords, m_gridTradeRecordsColumns);
            String filePath = Application.StartupPath + "\\TradeCodes.txt";
            if (FCFile.isFileExist(filePath)) {
                String content = "";
                FCFile.read(filePath, ref content);
                getTextBox("txtCodes").Text = content;
            }
            m_divMain = getDiv("divMain");
            registerEvents(m_divMain);
            m_divMain.addEvent(new FCInvokeEvent(invoke), FCEventID.INVOKE);
            m_chart = getChart("chartLeft");
            initChart(m_chart);
            Strategy1.m_tradeVolumes = getTradeVolumes();
        }

        /// ע���¼�
        /// </summary>
        /// <param name="control">�ؼ�</param>
        private void registerEvents(FCView control) {
            FCTouchEvent clickButtonEvent = new FCTouchEvent(clickEvent);
            List<FCView> controls = control.getControls();
            int controlsSize = controls.Count;
            for (int i = 0; i < controlsSize; i++) {
                FCView subControl = controls[i];
                FCButton button = subControl as FCButton;
                if (button != null) {
                    button.addEvent(clickButtonEvent, FCEventID.CLICK);
                }
                registerEvents(controls[i]);
            }
        }

        /****************************�������*********************************/
        /// <summary>
        /// ��������
        /// </summary>
        private int m_m = 60;

        /// <summary>
        /// ��ֵ����
        /// </summary>
        private int m_n = 20;

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="data">����</param>
        public void dealStrategy(SecurityLatestData data) {
            lock (Strategy1.m_latestDatas) {
                Strategy1.m_latestDatas[data.m_code] = data;
            }
            lock (Strategy1.m_historyDatas) {
                //��ӵ�����
                if (!Strategy1.m_historyDatas.ContainsKey(data.m_code)) {
                    Strategy1.m_historyDatas[data.m_code] = null;
                }
                //������ʷ����
                if (Strategy1.m_historyDatas.ContainsKey(data.m_code)) {
                    //��ȡ����
                    if (Strategy1.m_historyDatas[data.m_code] == null) {
                        List<SecurityData> historyDatas = getMinuteKLine(30, data.m_code);
                        if (historyDatas != null) {
                            Strategy1.m_historyDatas[data.m_code] = historyDatas;
                        }
                    }
                    //��������
                    if (Strategy1.m_historyDatas[data.m_code] != null) {
                        List<SecurityData> historyDatas = Strategy1.m_historyDatas[data.m_code];
                        int historyDatasSize = historyDatas.Count;
                        if (historyDatas.Count > 0) {
                            String lastDate = historyDatas[historyDatasSize - 1].m_date;
                            String newDate = DateTime.Now.ToString("yyyy-MM-dd") + " " + data.m_updateTime;
                            DateTime dt1 = Convert.ToDateTime(lastDate);
                            DateTime dt2 = Convert.ToDateTime(newDate);
                            //���쳣ʱ������⴦��
                            if (dt2.Hour == 11 && dt2.Minute >= 30) {
                                dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, dt2.Hour, 29, 59);
                            }
                            else if (dt2.Hour == 15 && dt2.Minute >= 0) {
                                dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 14, 59, 59);
                            }
                            else if (dt2.Hour == 0 && dt2.Minute >= 0) {
                                dt2 = dt2.AddDays(-1);
                                dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 23, 59, 59);
                            }
                            double dateNum1 = FCStr.getDateNum(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second, 0);
                            double dateNum2 = FCStr.getDateNum(dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second, 0);
                            int tt1 = (int)(dateNum1 / 60);
                            int tt2 = (int)(dateNum2 / 60);
                            int t1 = (int)(dateNum1 / 1800);
                            int t2 = (int)(dateNum2 / 1800);
                            //����
                            if (tt2 < tt1) {
                                historyDatas[historyDatasSize - 1].m_close = data.m_close;
                                if (historyDatas[historyDatasSize - 1].m_high < data.m_close) {
                                    historyDatas[historyDatasSize - 1].m_high = data.m_close;
                                }
                                if (historyDatas[historyDatasSize - 1].m_low > data.m_close) {
                                    historyDatas[historyDatasSize - 1].m_low = data.m_close;
                                }
                            }
                            //����
                            else {
                                SecurityData newHistoryData = new SecurityData();
                                newHistoryData.m_close = data.m_close;
                                newHistoryData.m_high = data.m_close;
                                newHistoryData.m_low = data.m_close;
                                newHistoryData.m_open = data.m_close;
                                double newDateNum = (double)t2 * 1800 + 1800;
                                int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0, ms = 0;
                                FCStr.getDateByNum(newDateNum, ref year, ref month, ref day, ref hour, ref minute, ref second, ref ms);
                                DateTime newDateTime = new DateTime(year, month, day, hour, minute, second);
                                newHistoryData.m_date = newDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                historyDatas.Add(newHistoryData);
                            }
                        }
                        bool canTrade = false;
                        if (Strategy1.m_tradeVolumes.ContainsKey(data.m_code)) {
                            canTrade = true;
                        }
                        Strategy1.checkOpen(data, Strategy1.m_historyDatas[data.m_code], m_n, m_m);
                        if (canTrade) {
                            if (!getCheckBox("cbStopOpen").Checked && data.m_bidPrice1 > 0 && data.m_askPrice1 > 0) {
                                Strategy1.doOpen(data);
                            }
                        }
                        if (data.m_code == m_currentCode) {
                            bindChart(historyDatas);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��ȡ��ʱ������
        /// </summary>
        /// <param name="minute">����</param>
        /// <param name="code">����</param>
        /// <returns>����</returns>
        public List<SecurityData> getMinuteKLine(int minute, String code) {
            String result = getMinuteKLineStrBySina(minute, code);
            if (result != null && result.Length > 0) {
                String[] vecData = result.Split(new String[] { "],[" }, StringSplitOptions.None);
                char[] str = new char[102400];
                List<SecurityData> datas = new List<SecurityData>();
                Dictionary<String, String> dateKeys = new Dictionary<String, String>();
                for (int i = (int)vecData.Length - 1; i >= 0; i--) {
                    string strData = vecData[i];
                    int size = (int)strData.Length;
                    strData = strData.Substring(1, size - 2);
                    String[] vecStr = strData.Split(new String[] { "\",\"" }, StringSplitOptions.None);
                    size = (int)vecStr.Length;
                    SecurityData latestData = new SecurityData();
                    latestData.m_open = FCStr.convertStrToDouble(vecStr[1]);
                    latestData.m_high = FCStr.convertStrToDouble(vecStr[2]);
                    latestData.m_low = FCStr.convertStrToDouble(vecStr[3]);
                    latestData.m_close = FCStr.convertStrToDouble(vecStr[4]);
                    latestData.m_date = vecStr[0];
                    dateKeys[latestData.m_date] = "";
                    datas.Add(latestData);
                }
                return datas;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// �����˻�ȡ��ʱ���ַ���
        /// </summary>
        /// <param name="minute">��ʱ</param>
        /// <param name="code">����</param>
        /// <returns>�ַ���</returns>
        public static String getMinuteKLineStrBySina(int minute, String code) {
            Security security = new Security();
            lock (Strategy1.m_securities) {
                if (Strategy1.m_securities.ContainsKey(code)) {
                    security = Strategy1.m_securities[code];
                }
            }
            String requestCode = code;
            if (security.m_exchangeID == "CZCE") {
                requestCode = "";
                bool append = true;
                foreach (char ch in code) {
                    if (ch >= 48 && ch <= 57) {
                        if (append) {
                            requestCode += "1";
                            append = false;
                        }
                    }
                    requestCode += ch;
                }
            }
            String result = "";
            String url = String.Format("http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine{0}m?symbol={1}", minute, requestCode);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) {
                result = reader.ReadToEnd();
            }
            int size = (int)result.Length;
            result = result.Substring(2, size - 4);
            return result.Replace("\t\n", "");
        }

        /// <summary>
        /// ��ȡ��ƷID
        /// </summary>
        /// <param name="code">����</param>
        /// <returns>��ƷID</returns>
        public String getProductID(String code) {
            String productID = "";
            foreach (char ch in code) {
                if (ch > 65) {
                    productID += ch.ToString();
                }
            }
            return productID;
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, int> getTradeVolumes() {
            Dictionary<String, int> tradeVolumes = new Dictionary<string, int>();
            String filePath = Application.StartupPath + "\\TradeVolume.txt";
            if (FCFile.isFileExist(filePath)) {
                String content = "";
                FCFile.read(filePath, ref content);
                String[] strs = content.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int strsSize = strs.Length;
                for (int i = 0; i < strsSize; i++) {
                    String[] subStrs = strs[i].Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    tradeVolumes[subStrs[0] + subStrs[1]] = FCStr.convertStrToInt(subStrs[2]);
                }
            }
            return tradeVolumes;
        }

        /// <summary>
        /// ��½��CTP
        /// </summary>
        /// <param name="mdServer">�����ַ</param>
        /// <param name="tdServer">���׵�ַ</param>
        /// <param name="brokerID">����ID</param>
        /// <param name="investorID">Ͷ����ID</param>
        /// <param name="password">����</param>
        public void loginCTP(String mdServer, String tdServer, String brokerID, String investorID, String password) {
            try {
                Strategy1.m_ctpID = CTPDLL.create();
                int reqID = CTPDLL.generateReqID(Strategy1.m_ctpID);
                CTPDLL.start(Strategy1.m_ctpID, reqID, mdServer, tdServer, brokerID, investorID, password);
                //CTPDLL.Start(m_ctpID, m_reqID, "218.202.237.33:10012", "218.202.237.33:10002", "9999", "021739", "123456");
                while (CTPDLL.isDataOk(Strategy1.m_ctpID) <= 0) {
                    Thread.Sleep(1000);
                }
                FCStrEx.writeLog("CTP��¼�ɹ�!");
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// �ʽ��˻���Ϣ�ص�
        /// </summary>
        /// <param name="data">�ʽ��˻�</param>
        public virtual void onAccountDataCallBack(AccountData data, int ctpID) {
            m_divMain.beginInvoke(data);
        }

        /// <summary>
        /// �ֲ����ݻص�
        /// </summary>
        /// <param name="data">�ֲ�</param>
        public virtual void onInvestorPositionCallBack(List<InvestorPosition> data, int ctpID) {
            //ȡֹӯλ
            double ceil = (double)(findControl("Spin") as FCSpin).Value;
            //ȡֹ��λ
            double floor = (double)(findControl("Spin2") as FCSpin).Value;
            Strategy1.checkClose(data, ceil, floor);
            m_divMain.beginInvoke(data);
        }


        /// <summary>
        /// �ֲ����ݻص�
        /// </summary>
        /// <param name="data">�ֲ���ϸ</param>
        public virtual void onInvestorPositionDetailCallBack(List<InvestorPositionDetail> data, int ctpID) {
        }

        /// <summary>
        /// ���͵�ί�лر��ص�
        /// </summary>
        /// <param name="data">ί�лر�</param>
        public virtual void onOrderInfoCallBack(OrderInfo data, int ctpID) {
            m_divMain.beginInvoke(data);
        }

        /// <summary>
        /// ������ѯ��ί�лر��ص�
        /// </summary>
        /// <param name="data">ί�лر��б�</param>
        public virtual void onOrderInfosCallBack(List<OrderInfo> orderInfos, int ctpID) {
            m_divMain.beginInvoke(orderInfos);
        }

        /// <summary>
        /// ���ص�
        /// </summary>
        /// <param name="data">���</param>
        public virtual void onSecurityCallBack(List<Security> data, int ctpID) {
            lock (Strategy1.m_securities) {
                StringBuilder sb = new StringBuilder();
                foreach (Security security in data) {
                    Strategy1.m_securities[security.m_instrumentID] = security;
                    sb.Append(security.m_instrumentID + "," + security.m_instrumentName + "," + security.m_exchangeID + "\r\n");
                }
                FCFile.write(Application.StartupPath + "\\codes.txt", sb.ToString());
            }
        }

        /// <summary>
        /// �������ݻص�
        /// </summary>
        /// <param name="data">��������</param>
        public virtual void onSecurityLatestDataCallBack(List<SecurityLatestData> data, int ctpID) {
            m_divMain.beginInvoke(data);
        }

        /// <summary>
        /// ���͵Ľ�����Ϣ�ص�
        /// </summary>
        /// <param name="data">������Ϣ</param>
        public virtual void onTradeRecordCallBack(TradeRecord data, int ctpID) {
            m_divMain.beginInvoke(data);
        }

        /// <summary>
        /// ������ѯ�Ľ�����Ϣ�ص�
        /// </summary>
        /// <param name="tradeRecords">������Ϣ�б�</param>
        public virtual void onTradeRecordsCallBack(List<TradeRecord> tradeRecords, int ctpID) {
            m_divMain.beginInvoke(tradeRecords);
        }

        /// <summary>
        /// ���з���
        /// </summary>
        public void run() {
            while (true) {
                StringBuilder data = new StringBuilder(102400);
                bool doSomeThing = false;
                if (CTPDLL.getDepthMarketData(Strategy1.m_ctpID, data) > 0) {
                    List<SecurityLatestData> latestData = CTPConvert.convertToCTPDepthMarketData(data.ToString());
                    onSecurityLatestDataCallBack(latestData, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getInstrumentsData(Strategy1.m_ctpID, data) > 0) {
                    List<Security> instrumentDatas = CTPConvert.convertToCTPInstrumentDatas(data.ToString());
                    onSecurityCallBack(instrumentDatas, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getAccountData(Strategy1.m_ctpID, data) > 0) {
                    AccountData accountData = CTPConvert.convertToCTPAccountData(data.ToString());
                    onAccountDataCallBack(accountData, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getOrderInfos(Strategy1.m_ctpID, data) > 0) {
                    List<OrderInfo> orderInfos = CTPConvert.convertToCTPOrderList(data.ToString());
                    onOrderInfosCallBack(orderInfos, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getTradeRecords(Strategy1.m_ctpID, data) > 0) {
                    List<TradeRecord> tradeRecords = CTPConvert.convertToCTPTradeRecords(data.ToString());
                    onTradeRecordsCallBack(tradeRecords, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getPositionData(Strategy1.m_ctpID, data) > 0) {
                    List<InvestorPosition> investorPositions = CTPConvert.convertToCTPInvestorPosition(data.ToString());
                    onInvestorPositionCallBack(investorPositions, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getPositionDetailData(Strategy1.m_ctpID, data) > 0) {
                    List<InvestorPositionDetail> investorPositionDetails = CTPConvert.convertToCTPInvestorPositionDetail(data.ToString());
                    onInvestorPositionDetailCallBack(investorPositionDetails, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getTradeRecord(Strategy1.m_ctpID, data) > 0) {
                    TradeRecord tradeRecord = CTPConvert.convertToCTPTrade(data.ToString());
                    onTradeRecordCallBack(tradeRecord, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (CTPDLL.getOrderInfo(Strategy1.m_ctpID, data) > 0) {
                    OrderInfo orderInfo = CTPConvert.convertToCTPOrder(data.ToString());
                    onOrderInfoCallBack(orderInfo, Strategy1.m_ctpID);
                    data = new StringBuilder(102400);
                    doSomeThing = true;
                }
                if (!doSomeThing) {
                    Thread.Sleep(10);
                }
            }
        }
    }
}