/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海卷卷猫信息技术有限公司-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海卷卷猫信息技术有限公司-周淋霞;
 3.该程序不开源，需要得到授权才能使用。
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FaceCat {
    public class FCStrEx {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">日志</param>
        public static void writeLog(String log) {
            FCFile.append(Application.StartupPath + "\\log.txt", "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + log + "\r\n");
        }
    }
}
