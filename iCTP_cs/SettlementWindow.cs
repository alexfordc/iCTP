/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����׿Ƽ���ʼ��-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����׿Ƽ���ʼ��-Ԭ����(΢�ź�:wx627378127);
 3.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceCat;

namespace FaceCat {
    /// <summary>
    /// ���㴰��
    /// </summary>
    public partial class SettlementWindow : Form {
        /// <summary>
        /// �������㴰��
        /// </summary>
        public SettlementWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// CTP���
        /// </summary>
        private int m_ctpID;

        /// <summary>
        /// �������øı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSetDate_CheckedChanged(object sender, EventArgs e) {
            dtpDate.Enabled = cbSetDate.Checked;
        }

        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="ctpID"></param>
        /// <param name="tradingDay"></param>
        public void QuerySettlementInfo(int ctpID, String tradingDay) {
            CTPDLL.reqQrySettlementInfo(ctpID, CTPDLL.generateReqID(m_ctpID), tradingDay);
            m_ctpID = ctpID;
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e) {
            if (cbSetDate.Checked) {
                CTPDLL.reqQrySettlementInfo(m_ctpID, CTPDLL.generateReqID(m_ctpID), dtpDate.Value.ToString("yyyyMMdd"));
            }
            else {
                CTPDLL.reqQrySettlementInfo(m_ctpID, CTPDLL.generateReqID(m_ctpID), "");
            }
        }

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();
            CTPDLL.getSettlementInfo(m_ctpID, sb);
            if (sb.Length > 0) {
                rtbSettlement.Text = sb.ToString();
            }
        }
    }
}