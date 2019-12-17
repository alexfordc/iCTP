/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����è��Ϣ�������޹�˾-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����è��Ϣ�������޹�˾-����ϼ;
 3.�ó��򲻿�Դ����Ҫ�õ���Ȩ����ʹ�á�
 */

using System;
using System.Collections.Generic;
using System.Text;
using FaceCat;
using System.Threading;

namespace FaceCat {
    /// <summary>
    /// ����1
    /// </summary>
    public class Strategy1 {
        /// <summary>
        /// ��ȴʱ��1
        /// </summary>
        public static Dictionary<String, int> m_cd1 = new Dictionary<String, int>();

        /// <summary>
        /// ��ȴʱ��2
        /// </summary>
        public static Dictionary<String, int> m_cd2 = new Dictionary<String, int>();

        /// <summary>
        /// CTP��ID
        /// </summary>
        public static int m_ctpID;

        /// <summary>
        /// ��ʷ���ݵļ���
        /// </summary>
        public static Dictionary<String, List<SecurityData>> m_historyDatas = new Dictionary<String, List<SecurityData>>();

        /// <summary>
        /// �ֲ�����
        /// </summary>
        public static Dictionary<String, InvestorPosition> m_investorPositions = new Dictionary<string, InvestorPosition>();

        /// <summary>
        /// �������ݵļ���
        /// </summary>
        public static Dictionary<String, SecurityLatestData> m_latestDatas = new Dictionary<String, SecurityLatestData>();

        /// <summary>
        /// ֤ȯ��
        /// </summary>
        public static Dictionary<String, Security> m_securities = new Dictionary<string, Security>();

        /// <summary>
        /// �ɽ�����
        /// </summary>
        public static Dictionary<String, int> m_tradeVolumes = new Dictionary<string, int>();

        /// <summary>
        /// ƽ��
        /// </summary>
        /// <param name="investorPosition">�ֲ�</param>
        /// <param name="code">����</param>
        /// <param name="direction">����</param>
        /// <param name="close">���¼�</param>
        /// <param name="openPrice">���ּ�</param>
        /// <param name="state">state=0Ϊ�ֶ�ƽ�֣�����Ϊ�Զ�</param>
        public static void askOrBidClose(InvestorPosition investorPosition, String code, String direction, double close, double openPrice, int state) {
            //����ֲ�Ϊ0���򲻼��
            if (investorPosition.m_position == 0) {
                return;
            }
            //��ȡ��Ӧ����������
            SecurityLatestData latestData = null;
            lock (m_latestDatas) {
                if (m_latestDatas.ContainsKey(code)) {
                    latestData = m_latestDatas[code];
                }
            }
            if (latestData != null) {
                //��ȡ�����
                Security security = null;
                lock (m_securities) {
                    if (m_securities.ContainsKey(investorPosition.m_code)) {
                        security = m_securities[investorPosition.m_code];
                    }
                }
                if (security != null) {
                    bool canTrade = true;
                    //�����ȴʱ�䣬һ��ƽ��10�������ٴ�ƽ��
                    if (state != 0) {
                        lock (m_cd2) {
                            if (m_cd2.ContainsKey(investorPosition.m_code)) {
                                if (m_cd2[investorPosition.m_code] > 0) {
                                    canTrade = false;
                                }
                            }
                        }
                    }
                    //��ȡ���
                    int ydPosition = investorPosition.m_ydPosition;
                    //��ȡ���
                    int todayPosition = investorPosition.m_position - ydPosition;
                    if (canTrade) {
                        bool isSh = security.m_exchangeID == "SHFE";
                        //�򿪲������
                        if (direction == "��") {
                            //������������
                            if (isSh) {
                                //ƽ��
                                if (ydPosition > 0) {
                                    CTPDLL.askClose(m_ctpID, CTPDLL.generateReqID(m_ctpID), investorPosition.m_code, security.m_exchangeID, 0, ydPosition, '3', "");
                                }
                                //ƽ��
                                if (todayPosition > 0) {
                                    CTPDLL.askCloseToday(m_ctpID, CTPDLL.generateReqID(m_ctpID), investorPosition.m_code, security.m_exchangeID, 0, todayPosition, '3', "");
                                }
                            }
                            //����������������
                            else {
                                CTPDLL.askClose(m_ctpID, CTPDLL.generateReqID(m_ctpID), investorPosition.m_code, security.m_exchangeID, 0, investorPosition.m_position, '3', "");
                            }
                            //��ӡ��־
                            if (state == 1) {
                                FCStrEx.writeLog(String.Format("�Զ�ֹӯ,���ּ�{0},��ǰ��{1},��ƽ��,����{2},�۸�{3},����{4}\r\n",
                               openPrice, close, investorPosition.m_code, latestData.m_bidPrice1, investorPosition.m_position));
                            }
                            else if (state == 2) {
                                FCStrEx.writeLog(String.Format("�Զ�ֹ��,���ּ�{0},��ǰ��{1},��ƽ��,����{2},�۸�{3},����{4}\r\n",
                                           openPrice, close, investorPosition.m_code, latestData.m_bidPrice1, investorPosition.m_position));
                            }
                            //������ȴʱ��+10
                            lock (m_cd1) {
                                if (m_cd1.ContainsKey(investorPosition.m_code)) {
                                    m_cd1[investorPosition.m_code] += 10;
                                }
                                else {
                                    m_cd1[investorPosition.m_code] = 10;
                                }
                            }
                            //ƽ����ȴʱ������
                            lock (m_cd2) {
                                m_cd2[investorPosition.m_code] = 10;
                            }
                        }
                        //�����������
                        else if (direction == "��") {
                            //������������
                            if (isSh) {
                                //ƽ��
                                if (ydPosition > 0) {
                                    CTPDLL.bidClose(m_ctpID, CTPDLL.generateReqID(m_ctpID), investorPosition.m_code, security.m_exchangeID, 0, ydPosition, '3', "");
                                }
                                //ƽ��
                                if (todayPosition > 0) {
                                    CTPDLL.bidCloseToday(m_ctpID, CTPDLL.generateReqID(m_ctpID), investorPosition.m_code, security.m_exchangeID, 0, todayPosition, '3', "");
                                }
                            }
                            //����������������
                            else {
                                CTPDLL.bidClose(m_ctpID, CTPDLL.generateReqID(m_ctpID), investorPosition.m_code, security.m_exchangeID, 0, investorPosition.m_position, '3', "");
                            }
                            //��ӡ��־
                            if (state == 1) {
                                FCStrEx.writeLog(String.Format("�Զ�ֹӯ,���ּ�{0},��ǰ��{1},��ƽ��,����{2},�۸�{3},����{4}\r\n",
                                        openPrice, close, investorPosition.m_code, latestData.m_bidPrice1, investorPosition.m_position));
                            }
                            else if (state == 2) {
                                FCStrEx.writeLog(String.Format("�Զ�ֹ��,���ּ�{0},��ǰ��{1},��ƽ��,����{2},�۸�{3},����{4}\r\n",
                                         openPrice, close, investorPosition.m_code, latestData.m_bidPrice1, investorPosition.m_position));
                            }
                            //������ȴʱ��+10
                            lock (m_cd1) {
                                if (m_cd1.ContainsKey(investorPosition.m_code)) {
                                    m_cd1[investorPosition.m_code] += 10;
                                }
                                else {
                                    m_cd1[investorPosition.m_code] = 10;
                                }
                            }
                            //ƽ����ȴʱ������
                            lock (m_cd2) {
                                m_cd2[investorPosition.m_code] = 10;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���ƽ��
        /// </summary>
        /// <param name="data">���³ֲ�����</param>
        /// <param name="ceil">ֹӯλ</param>
        /// <param name="floor">ֹ��λ</param>
        public static void checkClose(List<InvestorPosition> data, double ceil, double floor) {
            //ȡС�����֣�ֹӯΪ����ֹ��λ��
            int dataSize = data.Count;
            Dictionary<String, String> codes = new Dictionary<string, string>();
            //ѭ����������
            for (int i = 0; i < dataSize; i++) {
                InvestorPosition investorPosition = data[i];
                String key = investorPosition.m_code + investorPosition.m_posiDirection;
                //�жϸóֲ��������Ļ��Ǽ��ٵ�
                lock (m_investorPositions) {
                    if (m_investorPositions.ContainsKey(key)) {
                        if (m_investorPositions[key].m_position != investorPosition.m_position) {
                            codes[investorPosition.m_code] = "";
                        }
                    }
                    else {
                        codes[investorPosition.m_code] = "";
                    }
                    //�����ڴ�
                    m_investorPositions[key] = investorPosition;
                }
                //��ȡ��������
                SecurityLatestData latestData = null;
                lock (m_latestDatas) {
                    if (m_latestDatas.ContainsKey(investorPosition.m_code)) {
                        latestData = m_latestDatas[investorPosition.m_code];
                    }
                }
                //openPrice�ֶ���0
                if (latestData != null && investorPosition.m_position > 0) {
                    double openPrice = investorPosition.m_openCost / investorPosition.m_position;
                    //��ȡ��ǰ�۸��뿪�ּ۵Ĳ��
                    if (openPrice != 0) {
                        //��ȡ����
                        String code = investorPosition.m_code;
                        //��ȡ����
                        String direction = investorPosition.m_posiDirection;
                        //�����򿪲�
                        if (investorPosition.m_posiDirection == "��") {
                            //��ȡӯ������
                            double ratio = latestData.m_close / openPrice;
                            String strClose = String.Format("�ּ�/���ּ�:{0},ֹӯλ:{1},ֹ��λ:{2}", ratio, ceil, floor);
                            //�ж�ֹӯ
                            if (ratio >= ceil) //�����ֹӯ���ұ�Ӧ��1.03
                            {
                                askOrBidClose(investorPosition, code, direction, latestData.m_close, openPrice, 1);
                            }
                            //�ж�ֹ��
                            else if (ratio <= floor) //�����ֹ���ұ�Ӧ����0.99
                            {
                                askOrBidClose(investorPosition, code, direction, latestData.m_close, openPrice, 2);
                            }
                        }
                        //����������
                        else if (investorPosition.m_posiDirection == "��") {
                            //��ȡ��ǰ�۸��뿪�ּ۵Ĳ����Ƿ����෴
                            double ratio = latestData.m_close / openPrice;
                            double subCeil = ceil - 1; //Ҳ����0.03
                            double subFloor = 1 - floor; //Ҳ����0.01
                            String strClose = String.Format("�ּ�/���ּ�:{0},ֹӯλ:{1},ֹ��λ:{2}", ratio, 1 - subCeil, 1 + subFloor);
                            //�ж�ֹӯ
                            if (ratio <= 1 - subCeil) //���ֹӯ��0.03���ұ�Ӧ����0.97
                            {
                                askOrBidClose(investorPosition, code, direction, latestData.m_close, openPrice, 1);
                            }
                            //�ж�ֹ��
                            else if (ratio >= 1 + subFloor) //���ֹ����0.01���ұ�Ӧ����1.01
                            {
                                askOrBidClose(investorPosition, code, direction, latestData.m_close, openPrice, 2);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ����Ƿ񿪲�
        /// </summary>
        /// <param name="latestData">��������</param>
        /// <param name="datas">����</param>
        /// <param name="n">���¸߲���</param>
        /// <param name="m">���߲���</param>
        /// <returns>�Ƿ񿪲� 1:�� 2:���� 0:������</returns>
        public static void checkOpen(SecurityLatestData latestData, List<SecurityData> datas, int n, int m) {
            int datasSize = datas.Count;
            //�����ж������ direction = 0 �� direction = 1��
            for (int direction = 0; direction <= 1; direction++) {
                //��ֵ
                double extrem = 0;
                //�ж��Ƿ������ֵ
                double lastClose = datas[datasSize - 1].m_close;
                //ѭ�������������������ǰn-1������
                for (int i = datasSize - n; i < datasSize - 1; i++) {
                    SecurityData data = datas[i];
                    if (direction == 0) {
                        //��ȡ�׶���߼�
                        if (extrem == 0 || extrem < data.m_close) {
                            extrem = data.m_close;
                        }
                    }
                    else if (direction == 1) {
                        //��ȡ�׶���ͼ�
                        if (extrem == 0 || extrem > data.m_close) {
                            extrem = data.m_close;
                        }
                    }
                }
                //�ж��Ƿ��¸�
                bool newExtrem = false;
                if (direction == 0) {
                    //��ǰ�۸���ǰn-1����߼�
                    if (lastClose > extrem) {
                        newExtrem = true;
                    }
                }
                else if (direction == 1) {
                    //��ǰ�۵���ǰn-1����ͼ�
                    if (lastClose < extrem) {
                        newExtrem = true;
                    }
                }
                //ѭ���������ݣ�����60���ھ���
                for (int i = 0; i < datasSize; i++) {
                    SecurityData data = datas[i];
                    int startIndex = i - (m - 1);
                    int realM = m;
                    if (startIndex <= 0) {
                        startIndex = 0;
                        realM = i + 1;
                    }
                    double sum = 0;
                    for (int j = startIndex; j <= i; j++) {
                        sum += datas[j].m_close;
                    }
                    data.m_ma = sum / realM;
                }
                //�ж�60���ھ����Ƿ����̻�����
                bool newWards = false;
                if (direction == 0) {
                    newWards = datas[datasSize - 1].m_ma > datas[datasSize - 2].m_ma;
                }
                else if (direction == 1) {
                    newWards = datas[datasSize - 1].m_ma < datas[datasSize - 2].m_ma;
                }
                //�ж��Ƿ��򿪲�
                if (direction == 0) {
                    if (newExtrem) {
                        latestData.m_state1 = 1; //state1=1 �����Ǵ��¸�
                    }
                    if (newWards) {
                        latestData.m_state2 = 1; //state2=1 �����Ǿ�������
                    }
                }
                //�ж��Ƿ�������
                else if (direction == 1) {
                    if (newExtrem) {
                        latestData.m_state3 = 1; //state3=1 �����Ǵ��µ�
                    }
                    if (newWards) {
                        latestData.m_state4 = 1; //state4=1 �����Ǿ�������
                    }
                }
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="data">��������</param>
        public static void doOpen(SecurityLatestData data) {
            //ִ���򿪲�
            if (data.m_state1 == 1 && data.m_state2 == 1) {
                //�ж��Ƿ��гֲ�
                bool hasTrade = inTrade(data.m_code);
                if (!hasTrade) {
                    String key = data.m_code + "��";
                    //�ж���ȴʱ��
                    bool canTrade = true;
                    lock (Strategy1.m_cd1) {
                        if (Strategy1.m_cd1.ContainsKey(data.m_code)) {
                            if (Strategy1.m_cd1[data.m_code] > 0) {
                                canTrade = false;
                            }
                        }
                    }
                    if (canTrade) {
                        //��ȡĬ�Ͻ�������
                        int tradeVol = 1;
                        if (m_tradeVolumes.ContainsKey(key)) {
                            tradeVol = m_tradeVolumes[key];
                        }
                        //��ӡ��־
                        FCStrEx.writeLog(String.Format("����20���¸�,��������,�򿪲�,����{0},�۸�{1},����{2}\r\n",
                            data.m_code, data.m_askPrice1, tradeVol));
                        Security security = null;
                        lock (m_securities) {
                            if (m_securities.ContainsKey(data.m_code)) {
                                security = m_securities[data.m_code];
                            }
                        }
                        //�򿪲�
                        CTPDLL.bidOpen(Strategy1.m_ctpID, CTPDLL.generateReqID(Strategy1.m_ctpID), data.m_code, security.m_exchangeID, data.m_askPrice1, tradeVol, '3', "");
                        //ˢ�¿�����ȴʱ��
                        lock (Strategy1.m_cd1) {
                            Strategy1.m_cd1[data.m_code] = 60;
                        }
                    }
                }
            }
            //ִ��������
            if (data.m_state3 == 1 && data.m_state4 == 1) {
                //�ж��Ƿ��гֲ�
                bool hasTrade = inTrade(data.m_code);
                if (!hasTrade) {
                    String key = data.m_code + "��";
                    //�ж���ȴʱ��
                    bool canTrade = true;
                    lock (Strategy1.m_cd1) {
                        if (Strategy1.m_cd1.ContainsKey(data.m_code)) {
                            if (Strategy1.m_cd1[data.m_code] > 0) {
                                canTrade = false;
                            }
                        }
                    }
                    if (canTrade) {
                        //��ȡĬ�Ͻ�������
                        int tradeVol = 1;
                        if (m_tradeVolumes.ContainsKey(key)) {
                            tradeVol = m_tradeVolumes[key];
                        }
                        //��ӡ��־
                        FCStrEx.writeLog(String.Format("����20���µ�,��������,������,����{0},�۸�{1},����{2}\r\n",
                            data.m_code, data.m_askPrice1, tradeVol));
                        Security security = null;
                        lock (m_securities) {
                            if (m_securities.ContainsKey(data.m_code)) {
                                security = m_securities[data.m_code];
                            }
                        }
                        //������
                        CTPDLL.askOpen(Strategy1.m_ctpID, CTPDLL.generateReqID(Strategy1.m_ctpID), data.m_code, security.m_exchangeID, data.m_bidPrice1, tradeVol, '3', "");
                        //ˢ�¿�����ȴʱ��
                        lock (Strategy1.m_cd1) {
                            Strategy1.m_cd1[data.m_code] = 60;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �Ƿ�ӵ�гֲ�
        /// </summary>
        /// <param name="code">����</param>
        /// <param name="direction">����</param>
        /// <returns>�Ƿ�ӵ��</returns>
        public static bool hasInvestorPosition(String code, String direction) {
            bool hasPosition = false;
            lock (Strategy1.m_investorPositions) {
                if (Strategy1.m_investorPositions.ContainsKey(code + direction)) {
                    if (Strategy1.m_investorPositions[code + direction].m_position > 0) {
                        hasPosition = true;
                    }
                }
            }
            return hasPosition;
        }

        /// <summary>
        /// �Ƿ����ڽ���
        /// </summary>
        /// <param name="code">����</param>
        /// <returns>�Ƿ��ڽ���</returns>
        public static bool inTrade(String code) {
            if (hasInvestorPosition(code, "��") || hasInvestorPosition(code, "��")) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ������ȴʱ��
        /// </summary>
        public static void updateCD() {
            while (true) {
                lock (m_cd1) {
                    List<String> reduceCodes = new List<String>();
                    foreach (String code in m_cd1.Keys) {
                        if (m_cd1[code] > 0) {
                            reduceCodes.Add(code);
                        }
                    }
                    foreach (String code in reduceCodes) {
                        m_cd1[code] = m_cd1[code] - 1;
                    }
                }
                lock (m_cd2) {
                    List<String> reduceCodes = new List<String>();
                    foreach (String code in m_cd2.Keys) {
                        if (m_cd2[code] > 0) {
                            reduceCodes.Add(code);
                        }
                    }
                    foreach (String code in reduceCodes) {
                        m_cd2[code] = m_cd2[code] - 1;
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
