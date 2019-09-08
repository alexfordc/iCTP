/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����è��Ϣ�������޹�˾-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����è��Ϣ�������޹�˾-����ϼ;
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
using System.IO;
using System.Threading;
namespace FaceCat {
    /// <summary>
    /// ������
    /// </summary>
    public partial class MainForm : Form {
        /// <summary>
        ///  ����ͼ�οؼ�
        /// </summary>
        public MainForm() {
            InitializeComponent();
            m_xml = new MainFrame();
            m_xml.createNative();
            m_native = m_xml.Native;
            m_native.ResourcePath = Application.StartupPath + "\\image";
            //m_native.Paint = new GdiPlusPaintEx();
            m_host = new WinHost();
            m_host.Native = m_native;
            m_native.Host = m_host;
            m_host = m_native.Host as WinHost;
            m_host.HWnd = Handle;
            m_native.AllowScaleSize = true;
            m_native.DisplaySize = new FCSize(ClientSize.Width, ClientSize.Height);
            m_native.ScaleSize = new FCSize(ClientSize.Width, ClientSize.Height);
            m_xml.loadFile(Application.StartupPath + "\\config\\MainFrame.html", null);
            m_xml.resetScaleSize(m_native.DisplaySize);
            Invalidate();
            //�ַ���+
            m_native.update();
            m_native.invalidate();
        }

        /// <summary>
        /// �ؼ�������
        /// </summary>
        private WinHost m_host;

        /// <summary>
        /// �ؼ���
        /// </summary>
        private FCNative m_native;

        private MainFrame m_xml;

        /// <summary>
        /// ��ȡ������XML�����
        /// </summary>
        public MainFrame Xml {
            get { return m_xml; }
            set { m_xml = value; }
        }

        /// <summary>
        /// ��ȡ�ͻ��˳ߴ�
        /// </summary>
        /// <returns>�ͻ��˳ߴ�</returns>
        public FCSize getClientSize() {
            return new FCSize(ClientSize.Width, ClientSize.Height);
        }

        /// <summary>
        /// ����ر��¼�
        /// </summary>
        /// <param name="e">�¼�����</param>
        protected override void OnFormClosing(FormClosingEventArgs e) {
            Environment.Exit(0);
        }

        /// <summary>
        /// ������ط���
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.MainForm = this;
            loginWindow.ShowDialog();
            if (loginWindow.DialogResult != DialogResult.OK) {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="e">����</param>
        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);
            if (m_host.isKeyPress(0x11)) {
                double scaleFactor = m_xml.ScaleFactor;
                if (e.Delta > 0) {
                    if (scaleFactor > 0.2) {
                        scaleFactor -= 0.1;
                    }
                }
                else if (e.Delta < 0) {
                    if (scaleFactor < 10) {
                        scaleFactor += 0.1;
                    }
                }
                m_xml.ScaleFactor = scaleFactor;
                m_xml.resetScaleSize(getClientSize());
                Invalidate();
            }
        }

        /// <summary>
        /// �ߴ�ı䷽��
        /// </summary>
        /// <param name="e">����</param>
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (m_host != null) {
                if (m_xml != null) {
                    m_xml.resetScaleSize(getClientSize());
                }
                Invalidate();
            }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m) {
            if (m_host != null) {
                if (m_host.onMessage(ref m) > 0) {
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}