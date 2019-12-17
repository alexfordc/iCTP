﻿/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海卷卷猫信息技术有限公司-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海卷卷猫信息技术有限公司-周淋霞;
 3.该程序不开源，需要得到授权才能使用。
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Text;
using FaceCat;

namespace FaceCat {
    /// <summary>
    /// XML界面生成类
    /// </summary>
    public class UIXmlEx : FCUIXml {
        private double m_scaleFactor = 1;

        /// <summary>
        /// 获取或设置缩放因子
        /// </summary>
        public double ScaleFactor {
            get { return m_scaleFactor; }
            set { m_scaleFactor = value; }
        }

        /// <summary>
        /// 创建控件
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="type">类型</param>
        /// <returns>控件</returns>
        public override FCView createControl(XmlNode node, String type) {
            return base.createControl(node, type);
        }

        /// <summary>
        /// 重置缩放尺寸
        /// </summary>
        /// <param name="clientSize">客户端大小</param>
        public void resetScaleSize(FCSize clientSize) {
            FCNative native = Native;
            if (native != null) {
                native.ScaleSize = new FCSize((int)(clientSize.cx * m_scaleFactor), (int)(clientSize.cy * m_scaleFactor));
                native.update();
            }
        }
    }
}