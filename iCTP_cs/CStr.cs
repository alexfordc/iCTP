/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����׿Ƽ���ʼ��-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����׿Ƽ���ʼ��-Ԭ����(΢�ź�:wx627378127);
 3.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FaceCat {
    public class FCStrEx {
        /// <summary>
        /// д��־
        /// </summary>
        /// <param name="log">��־</param>
        public static void writeLog(String log) {
            FCFile.append(Application.StartupPath + "\\log.txt", "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + log + "\r\n");
        }
    }
}
