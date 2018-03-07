using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using GOLDSOFT.QDJJ.COMMONS;
using System.Drawing;
using DevExpress.XtraPrinting;
using System.Data;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 通用报表
    /// </summary>
    public class GenerateReport : DevExpress.XtraReports.UI.XtraReport
    {
        /// <summary>
        /// 初始化报表
        /// </summary>
        /// <param name="p_info">报表格式对象</param>
        public GenerateReport(_ObjectReport p_info)
        {
            this.ReportUnit = ReportUnit.TenthsOfAMillimeter; //使用0.1毫米计量单位
            this.Dpi = 254F;
            this.Bands.Clear();
            if (p_info != null)
            {
                switch (p_info.GetType().Name)
                {
                    case "TableReport":
                        TableReport m_info = p_info as TableReport;
                        this.DataSource = m_info.DataSource;
                        this.Margins = m_info.Margins;
                        this.PaperKind = m_info.PaperKind;
                        this.Landscape = this.IsDirection(m_info.Landscape);
                        DetailBand new_Detail = CreateTableDetail(m_info);
                        PageHeaderBand new_PageHeaderBand = CreateTableHeader(m_info);
                        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { new_PageHeaderBand, new_Detail });
                        break;
                    case "PageReport":
                        PageReport m_pinfo = p_info as PageReport;
                        this.Margins = m_pinfo.Margins;
                        this.PaperKind = m_pinfo.PaperKind;
                        this.Landscape = this.IsDirection(m_pinfo.Landscape);
                        DetailBand new_pDetail = this.CreateRowDetail(m_pinfo);
                        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { new_pDetail });
                        break;
                    case "ExplainReport":
                        ExplainReport m_ExplainReport = p_info as ExplainReport;
                        this.Margins = m_ExplainReport.Margins;
                        this.PaperKind = m_ExplainReport.PaperKind;
                        this.DataSource = null;
                        this.Landscape = this.IsDirection(m_ExplainReport.Landscape);
                        DetailBand new_EDetail = this.CreateRowDetail(m_ExplainReport);
                        PageHeaderBand new_ExplainPageHeaderBand = CreateTitleHeader(m_ExplainReport);
                        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { new_ExplainPageHeaderBand, new_EDetail });
                        break;
                    default:
                        break;
                }
            }
        }

        #region 创建表格报表
        /// <summary>
        /// 创建页头
        /// </summary>
        /// <param name="p_info">表格报表对象</param>
        /// <returns>页头内容</returns>
        private XRTable CreateTitleHeader(TableReport p_info)
        {
            XRTable headerTable = new XRTable();
            headerTable.Dpi = 254F;
            headerTable.Name = "Page";
            headerTable.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
            headerTable.Height = 56;

            if (p_info.TitleCaption != string.Empty)
            {
                XRTableRow titleRow = new XRTableRow();
                titleRow.Dpi = 254F;
                //标题
                XRTableCell titleCell = new XRTableCell();
                titleCell.Dpi = 254F;
                titleCell.Text = p_info.TitleCaption;
                titleCell.TextAlignment = this.Alignments(p_info.TitleTextAlignment);
                titleCell.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
                titleCell.Font = p_info.TitleFont;
                titleCell.BorderWidth = 0;
                titleRow.Height = (int)MeasureString(p_info.TitleCaption, p_info.TitleFont, titleCell.Width).Height + 1;
                titleRow.Cells.Add(titleCell);
                headerTable.Rows.Add(titleRow);
            }

            XRTableRow x_titleRow = new XRTableRow();
            x_titleRow.Dpi = 254F;
            x_titleRow.Height = 56;
            //项目名称
            XRTableCell l_titleCell = new XRTableCell();
            l_titleCell.Dpi = 254F;
            l_titleCell.TextAlignment = TextAlignment.MiddleLeft;
            l_titleCell.Width = (headerTable.Width / 2);
            l_titleCell.Font = new Font("宋体", 9F);
            l_titleCell.BorderWidth = 0;
            x_titleRow.Cells.Add(l_titleCell);
            //专业名称
            XRTableCell r_titleCell = new XRTableCell();
            r_titleCell.Dpi = 254F;
            r_titleCell.Width = (headerTable.Width / 2);
            r_titleCell.BorderWidth = 0;
            XRPageInfo m_pageInfo = new XRPageInfo();
            m_pageInfo.Dpi = 254F;
            m_pageInfo.Font = new Font("宋体", 9F);
            m_pageInfo.TextAlignment = TextAlignment.MiddleRight;
            m_pageInfo.Width = (headerTable.Width / 2);
            m_pageInfo.Height = 56;

            switch (p_info.ReportType)
            {
                case "项目报表":
                    l_titleCell.Text = string.Format("项目名称：{0}", p_info.XMMC);
                    m_pageInfo.Format = "\t第{0}页/共{1}页";
                    break;
                case "单位报表":
                    l_titleCell.Text = string.Format("工程名称：{0}", p_info.XMMC);
                    m_pageInfo.Format = string.Format("专业名称：{0}", p_info.ZYMC) + "\t第{0}页/共{1}页";
                    break;
                default:
                    break;
            }
            r_titleCell.Controls.Add(m_pageInfo);
            x_titleRow.Cells.Add(r_titleCell);
            headerTable.Rows.Add(x_titleRow);
            return headerTable;
        }


        /// <summary>
        /// 创建表格头
        /// </summary>
        /// <param name="rpf">报表个字段格式</param>
        /// <param name="border"></param>
        /// <returns></returns>
        private PageHeaderBand CreateTableHeader(TableReport p_info)
        {
            PageHeaderBand new_PageHeaderBand = new PageHeaderBand();
            new_PageHeaderBand.Controls.Add(CreateTitleHeader(p_info));
            if (p_info.ReportFields != null)
            {
                XRTable headerTable = null;
                XRTableRow headerOneRow = null;//一级表头
                XRTableRow headerTwoRow = null;//二级表头
                string bands = "**********";//上一和并列的值
                for (int i = 0; i < p_info.ReportFields.Length; i++)
                {
                    FieldReport item = p_info.ReportFields[i];
                    if (item.Bands == string.Empty)
                    {
                        if (item.Bands != bands)
                        {
                            bands = item.Bands;
                            headerTable = new XRTable();
                            headerTable.Dpi = 254F;
                            headerTable.Width = 0;
                            headerTable.Height = 112;
                            headerOneRow = new XRTableRow();
                            headerOneRow.Dpi = 254F;
                            headerOneRow.Height = 112;
                        }
                        XRTableCell headerCell = new XRTableCell();
                        headerCell.Dpi = 254F;
                        headerCell.Font = item.HeaderFont;
                        headerCell.Borders = (BorderSide)(BorderSide.Top | BorderSide.Right | BorderSide.Left | BorderSide.Bottom);
                        headerCell.BorderWidth = 1;
                        int width = 0;
                        if (new_PageHeaderBand.Controls.Count > 1 && headerTable.Width == 5)
                        {
                            width = 3;
                        }
                        headerCell.Width = item.RowWidth + width;
                        headerCell.WordWrap = true;
                        headerCell.CanGrow = true;
                        headerCell.TextAlignment = this.Alignments(item.TopAlignment);
                        headerCell.Text = item.Caption;
                        headerCell.Tag = item.Field;
                        headerTable.Width += item.RowWidth - (headerTable.Width == 5 ? 5 : 0);
                        headerOneRow.Cells.Add(headerCell);
                        if (item.Bands != p_info.ReportFields[i + (i == p_info.ReportFields.Length - 1 ? 0 : 1)].Bands || i == p_info.ReportFields.Length - 1)
                        {
                            headerTable.Rows.Add(headerOneRow);
                            headerTable.Location = GetTable(new_PageHeaderBand);
                            if (new_PageHeaderBand.Controls.Count > 1)
                            {
                                headerTable.Width = headerTable.Width + 3;
                            }
                            new_PageHeaderBand.Controls.Add(headerTable);
                            new_PageHeaderBand.Height = 0;
                        }
                    }
                    else
                    {
                        if (item.Bands != bands)
                        {
                            bands = item.Bands;
                            headerTable = new XRTable();
                            headerTable.Dpi = 254F;
                            headerTable.Width = 0;
                            headerTable.Height = 112;
                            headerOneRow = new XRTableRow();
                            headerOneRow.Dpi = 254F;
                            headerOneRow.Height = 56;

                            XRTableCell headerOneCell = new XRTableCell();
                            headerOneCell.Dpi = 254F;
                            headerOneCell.Font = item.HeaderFont;
                            headerOneCell.Borders = (BorderSide)(BorderSide.Top | BorderSide.Right | BorderSide.Left);
                            headerOneCell.BorderWidth = 1;
                            headerOneCell.Width = item.RowWidth;
                            headerOneCell.WordWrap = true;
                            headerOneCell.CanGrow = true;
                            headerOneCell.TextAlignment = this.Alignments(item.TopAlignment);
                            headerOneCell.Text = item.Bands;
                            headerOneCell.Tag = item.Field;
                            headerOneRow.Cells.Add(headerOneCell);
                            headerTable.Rows.Add(headerOneRow);

                            headerTwoRow = new XRTableRow();
                            headerTwoRow.Dpi = 254F;
                            headerTwoRow.Height = 56;
                        }

                        XRTableCell headerTwoCell = new XRTableCell();
                        headerTwoCell.Dpi = 254F;
                        headerTwoCell.Font = item.HeaderFont;
                        headerTwoCell.Borders = (BorderSide)(BorderSide.Top | BorderSide.Right | BorderSide.Left | BorderSide.Bottom);
                        headerTwoCell.BorderWidth = 1;
                        int width = 0;
                        if (new_PageHeaderBand.Controls.Count > 1 && headerTable.Width == 5)
                        {
                            width = 3;
                        }
                        headerTwoCell.Width = item.RowWidth + width;
                        headerTwoCell.WordWrap = true;
                        headerTwoCell.CanGrow = true;
                        headerTwoCell.TextAlignment = this.Alignments(item.TopAlignment);
                        headerTwoCell.Text = item.Caption;
                        headerTable.Width += item.RowWidth - (headerTable.Width == 5 ? 5 : 0);
                        headerTwoRow.Cells.Add(headerTwoCell);
                        if (item.Bands != p_info.ReportFields[i + (i == p_info.ReportFields.Length - 1 ? 0 : 1)].Bands || i == p_info.ReportFields.Length - 1)
                        {
                            headerTable.Rows.Add(headerTwoRow);
                            headerTable.Location = GetTable(new_PageHeaderBand);
                            if (new_PageHeaderBand.Controls.Count > 1)
                            {
                                headerTable.Width = headerTable.Width + 3;
                            }
                            new_PageHeaderBand.Controls.Add(headerTable);
                            new_PageHeaderBand.Height = 0;
                        }
                    }
                }
            }
            return new_PageHeaderBand;
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="rpf">报表个字段格式</param>
        /// <param name="rowHeight"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        private DetailBand CreateTableDetail(TableReport p_info)
        {
            DetailBand new_Detail = new DetailBand();
            if (p_info.ReportFields != null)
            {
                XRTable tableDetail = new XRTable();
                tableDetail.Dpi = 254F;
                tableDetail.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
                tableDetail.Height = 56;
                XRTableRow detailRow = new XRTableRow();
                detailRow.Dpi = 254F;
                detailRow.Height = 56;

                foreach (FieldReport item in p_info.ReportFields)
                {
                    XRTableCell detailCell = new XRTableCell();
                    detailCell.Dpi = 254F;
                    detailCell.Font = item.FormFont;
                    detailCell.Width = item.RowWidth;
                    if (item.Field != null) detailCell.DataBindings.Add("Text", null, item.Field);
                    detailCell.TextAlignment = this.Alignments(item.ContentAlignment);
                    detailCell.Padding = new PaddingInfo(5, 254F);
                    detailCell.Multiline = true;
                    detailCell.WordWrap = true;
                    detailCell.CanGrow = true;
                    detailCell.Borders = (BorderSide)(BorderSide.Right | BorderSide.Left | BorderSide.Bottom);
                    detailCell.BorderWidth = 1;
                    detailRow.Cells.Add(detailCell);
                }
                tableDetail.Rows.Add(detailRow);

                XRTableRow m_Row = (tableDetail.Controls[0] as XRTableRow);
                for (int i = 0; i < m_Row.Controls.Count; i++)
                {
                    XRTableCell m_Cell = (m_Row.Controls[i] as XRTableCell);
                    m_Cell.WidthF = m_Cell.Width;
                    p_info.ReportFields[i].RowWidth = m_Cell.Width;
                }
                tableDetail.WidthF = tableDetail.Width;
                new_Detail.Controls.Add(tableDetail);
            }
            new_Detail.HeightF = 0;
            return new_Detail;
        }

        #endregion

        #region 创建填空表格
        private DetailBand CreateRowDetail(PageReport p_info)
        {
            DetailBand new_Detail = new DetailBand();
            XRLabel m_Title = new XRLabel();
            m_Title.Dpi = 245F;
            m_Title.Font = p_info.TitleFont;
            m_Title.TextAlignment = this.Alignments(p_info.TitleTextAlignment);
            m_Title.Text = p_info.TitleCaption;
            int tw = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 70;
            m_Title.HeightF = MeasureString(p_info.TitleCaption, p_info.TitleFont, tw).Height;
            m_Title.WidthF = tw;
            m_Title.Top = p_info.TopDistance;
            new_Detail.Controls.Add(m_Title);
            if (p_info.RowReports != null)
            {
                foreach (RowReport item in p_info.RowReports)
                {
                    //左标题
                    XRLabel m_LeftTitle = new XRLabel();
                    m_LeftTitle.Font = item.LeftFont;
                    m_LeftTitle.Text = item.LeftContent;
                    SizeF m_lsf = this.LeftMeasureString(item);
                    m_LeftTitle.HeightF = m_lsf.Height;
                    m_LeftTitle.WidthF = m_lsf.Width;
                    m_LeftTitle.TopF = item.TopDistance;
                    m_LeftTitle.LeftF = item.LeftDistance;
                    m_LeftTitle.Padding = new PaddingInfo(1, 0, 1, 0);
                    new_Detail.Controls.Add(m_LeftTitle);
                    //内容
                    XRLabel m_Content = new XRLabel();
                    XRLine m_ContentLength = new XRLine();
                    if (item.ContentLength > 0)
                    {
                        m_Content.Font = item.ContentFont;
                        m_Content.TextAlignment = this.Alignments(item.ContentAlignment);
                        m_Content.Text = this.GetRowContent(p_info.DataSource, item);
                        SizeF m_csf = this.MeasureString(m_Content.Text == string.Empty ? "预测占位" : m_Content.Text, item.ContentFont, item.ContentLength);
                        m_Content.HeightF = m_csf.Height;
                        m_Content.WidthF = item.ContentLength;
                        m_Content.TopF = item.TopDistance + (m_LeftTitle.HeightF - m_Content.HeightF) - 2;
                        m_Content.LeftF = item.LeftDistance + m_LeftTitle.Width;
                        m_Content.Padding = new PaddingInfo(1, 0, 1, 0);
                        new_Detail.Controls.Add(m_Content);
                        //底线
                        m_ContentLength.HeightF = 5;
                        m_ContentLength.WidthF = item.ContentLength;
                        m_ContentLength.TopF = item.TopDistance + (m_LeftTitle.HeightF - m_ContentLength.HeightF);
                        m_ContentLength.LeftF = item.LeftDistance + m_LeftTitle.Width;
                        new_Detail.Controls.Add(m_ContentLength);
                    }
                    //右标题
                    XRLabel m_RightTitle = new XRLabel();
                    m_RightTitle.Font = item.RightFont;
                    m_RightTitle.Text = item.RightContent;
                    SizeF m_rsf = this.RightMeasureString(item);
                    m_RightTitle.HeightF = m_rsf.Height;
                    m_RightTitle.WidthF = m_rsf.Width;
                    m_RightTitle.TopF = item.TopDistance + (m_LeftTitle.HeightF - m_RightTitle.HeightF);
                    m_RightTitle.LeftF = 15 + item.LeftDistance + m_LeftTitle.WidthF + m_Content.Width;
                    m_RightTitle.Padding = new PaddingInfo(1, 0, 1, 0);
                    new_Detail.Controls.Add(m_RightTitle);
                }
            }
            return new_Detail;
        }
        #endregion

        #region 创建说明表格
        /// <summary>
        /// 创建页头
        /// </summary>
        /// <param name="p_info">表格报表对象</param>
        /// <returns>页头内容</returns>
        private PageHeaderBand CreateTitleHeader(ExplainReport p_info)
        {
            PageHeaderBand new_PageHeaderBand = new PageHeaderBand();
            XRTable headerTable = new XRTable();
            headerTable.Dpi = 254F;
            headerTable.Name = "Page";
            headerTable.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
            headerTable.Height = 56;

            if (p_info.TitleCaption != string.Empty)
            {
                XRTableRow titleRow = new XRTableRow();
                titleRow.Dpi = 254F;
                //标题
                XRTableCell titleCell = new XRTableCell();
                titleCell.Dpi = 254F;
                titleCell.Text = p_info.TitleCaption;
                titleCell.TextAlignment = this.Alignments(p_info.TitleTextAlignment);
                titleCell.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
                titleCell.Font = p_info.TitleFont;
                titleCell.BorderWidth = 0;
                titleRow.Height = (int)MeasureString(p_info.TitleCaption, p_info.TitleFont, titleCell.Width).Height + 1;
                titleRow.Cells.Add(titleCell);
                headerTable.Rows.Add(titleRow);
            }

            XRTableRow x_titleRow = new XRTableRow();
            x_titleRow.Dpi = 254F;
            x_titleRow.Height = 56;
            //项目名称
            XRTableCell l_titleCell = new XRTableCell();
            l_titleCell.Dpi = 254F;
            l_titleCell.TextAlignment = TextAlignment.MiddleLeft;
            l_titleCell.Width = (headerTable.Width / 2);
            l_titleCell.Font = new Font("宋体", 9F);
            l_titleCell.BorderWidth = 0;
            x_titleRow.Cells.Add(l_titleCell);
            //专业名称
            XRTableCell r_titleCell = new XRTableCell();
            r_titleCell.Dpi = 254F;
            r_titleCell.Width = (headerTable.Width / 2);
            r_titleCell.BorderWidth = 0;
            XRPageInfo m_pageInfo = new XRPageInfo();
            m_pageInfo.Dpi = 254F;
            m_pageInfo.Font = new Font("宋体", 9F);
            m_pageInfo.TextAlignment = TextAlignment.MiddleRight;
            m_pageInfo.Width = (headerTable.Width / 2);
            m_pageInfo.Height = 56;
            r_titleCell.Controls.Add(m_pageInfo);
            x_titleRow.Cells.Add(r_titleCell);
            headerTable.Rows.Add(x_titleRow);
            XRLine m_ContentLength = new XRLine();
            //底线
            m_ContentLength.Dpi = 254F;
            m_ContentLength.Top = headerTable.Height;
            m_ContentLength.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
            switch (p_info.ReportType)
            {
                case "项目报表":
                    l_titleCell.Text = string.Format("项目名称：{0}", p_info.XMMC);
                    m_pageInfo.Format = "\t第{0}页/共{1}页";
                    break;
                case "单位报表":
                    l_titleCell.Text = string.Format("工程名称：{0}", p_info.XMMC);
                    m_pageInfo.Format = string.Format("专业名称：{0}", p_info.ZYMC) + "\t第{0}页/共{1}页";
                    break;
                default:
                    break;
            }
            new_PageHeaderBand.Controls.Add(headerTable);
            new_PageHeaderBand.Controls.Add(m_ContentLength);
            new_PageHeaderBand.HeightF = 0;
            return new_PageHeaderBand;
        }

        private DetailBand CreateRowDetail(ExplainReport p_info)
        {
            DetailBand new_Detail = new DetailBand();
            new_Detail.Dpi = 254F;
            if (p_info != null)
            {
                XRLabel m_Explain = new XRLabel();
                m_Explain.Dpi = 254F;
                m_Explain.Font = p_info.ExplainFont;
                m_Explain.Text = p_info.ExplainContent;
                m_Explain.Multiline = true;
                m_Explain.Width = this.PageWidth - (this.Margins.Left + this.Margins.Right) - 4;
                new_Detail.Controls.Add(m_Explain);
            }
            return new_Detail;
        }
        #endregion

        #region 辅助方法
        /// <summary>
        /// 解析对齐方式
        /// </summary>
        /// <param name="p_Alignment"></param>
        /// <returns></returns>
        private TextAlignment Alignments(Alignment p_Alignment)
        {
            switch (p_Alignment)
            {
                case Alignment.居左:
                    return TextAlignment.MiddleLeft;
                case Alignment.居中:
                    return TextAlignment.MiddleCenter;
                case Alignment.居右:
                    return TextAlignment.MiddleRight;
                default:
                    return TextAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// 解析是与否
        /// </summary>
        /// <param name="p_Alignment"></param>
        /// <returns></returns>
        private bool IsBool(Whether p_Whether)
        {
            if (p_Whether == Whether.是)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 解析纸张方向
        /// </summary>
        /// <param name="p_Alignment"></param>
        /// <returns></returns>
        private bool IsDirection(Direction p_Direction)
        {
            if (p_Direction == Direction.横向)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 填空报表专用（获取绑定内容）
        /// </summary>
        /// <param name="p_info"></param>
        /// <returns></returns>
        private string GetRowContent(object p_DataSource, RowReport p_info)
        {
            string m_Content = string.Empty;
            if (p_DataSource != null)
            {
                DataTable dt = p_DataSource as DataTable;
                if (dt.Rows.Count == 1)
                {
                    if (p_info.Field != string.Empty)
                    {
                        object m_obj = dt.Rows[0][p_info.Field];
                        if (m_obj != null)
                        {
                            m_Content = m_obj.ToString();
                        }
                    }
                }
            }
            return m_Content;
        }

        /// <summary>
        /// 填空报表专用（获取左标题大小）
        /// </summary>
        /// <param name="p_info"></param>
        /// <returns></returns>
        private SizeF LeftMeasureString(RowReport p_info)
        {
            SizeF m_sf = new SizeF();
            if (p_info.LeftLength > 0)
            {
                m_sf = MeasureString(p_info.LeftContent, p_info.LeftFont, p_info.LeftLength);
            }
            else
            {
                m_sf = MeasureString(p_info.LeftContent, p_info.LeftFont);
            }
            return m_sf;
        }

        /// <summary>
        /// 填空报表专用（获取右标题大小）
        /// </summary>
        /// <param name="p_info"></param>
        /// <returns></returns>
        private SizeF RightMeasureString(RowReport p_info)
        {
            SizeF m_sf = new SizeF();
            if (p_info.RightLength > 0)
            {
                m_sf = MeasureString(p_info.RightContent, p_info.RightFont, p_info.RightLength);
            }
            else
            {
                m_sf = MeasureString(p_info.RightContent, p_info.RightFont);
            }
            return m_sf;
        }

        //测量字符的打印范围(单行)
        private SizeF MeasureString(string text, Font font)
        {
            return MeasureString(text, font, 10000);
        }

        //测量字符的打印范围(多行)
        private SizeF MeasureString(string text, Font font, int width)
        {
            SizeF size = BrickGraphics.MeasureString(text, font, width, null, GraphicsUnit.Pixel);
            size.Width = size.Width;
            size.Height = size.Height;
            return size;
        }

        /// <summary>
        /// 控制XRTable位置
        /// </summary>
        /// <param name="p_info">Page容器（只存在XRTable才有效）</param>
        /// <returns>整理完成</returns>
        private Point GetTable(PageHeaderBand p_info)
        {
            Point point = new Point();
            point.X = 0;
            point.Y = 56;
            foreach (XRTable item in p_info.Controls)
            {
                if (item.Name != "Page")
                {
                    point.X += item.Width - 3;
                }
            }
            return point;
        }
        #endregion

        #region 报表控件
        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private BottomMarginBand bottomMarginBand1;

        private void InitializeComponent()
        {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 100F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.HeightF = 100F;
            this.detailBand1.Name = "detailBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 100F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // TableXReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Version = "9.3";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}
