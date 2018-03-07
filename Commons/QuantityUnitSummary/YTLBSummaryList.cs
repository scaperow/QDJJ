using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 用途类别汇总集合
    /// </summary>
    [Serializable]
    public class YTLBSummaryList : _List
    {
        /// <summary>
        /// 
        /// </summary>
        public YTLBSummaryList() { }
        /// <summary>
        /// 初始化：工料机汇总集合
        /// </summary>
        /// <param name="p_Parent">所属</param>
        public YTLBSummaryList(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取或设置： 所属对象
        /// </summary>
        public _UnitProject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="p_Info">材料信息</param>
        /// <param name="p_Automatic">是否自动绑定</param>
        /// <returns>是否成功</returns>
        public YTLBSummaryInfo Insert(_ObjectQuantityUnitInfo p_Info, bool p_Automatic)
        {
            return Insert(0, p_Info, p_Automatic);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="p_Index">插入位置</param>
        /// <param name="p_Info">材料信息</param>
        /// <param name="p_Automatic">是否自动绑定</param>
        /// <returns>是否成功</returns>
        public YTLBSummaryInfo Insert(int p_Index, _ObjectQuantityUnitInfo p_Info, bool p_Automatic)
        {
            YTLBSummaryInfo m_info = this.GetBindingInfo(p_Info.BH);
            if (m_info != null) return m_info;
            YTLBSummaryInfo new_info = new YTLBSummaryInfo(this.Parent);
            new_info.BDBH = p_Automatic ? p_Info.BH : string.Empty;
            new_info.BH = p_Info.BH;
            new_info.MC = p_Info.MC;
            new_info.DW = p_Info.DW;
            new_info.GGXH = p_Info.GGXH;
            new_info.DEDJ = p_Info.DEDJ;
            new_info.SCDJ = p_Info.SCDJ;
            new_info.JSDJ = p_Info.JSDJ;
            new_info.SLH = p_Info.SLH;
            new_info.YTLB = p_Info.YTLB;
            (this as System.Collections.ArrayList).Insert(p_Index, new_info);
            return null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_info"></param>
        public void Remove(YTLBSummaryInfo p_info)
        {
            this.CanceledBinding(p_info);
            base.Remove(p_info);
        }

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="p_YTLB">原信息</param>
        /// <param name="p_info">新信息</param>
        /// <param name="iszd"></param>
        /// <returns></returns>
        public bool Replace(YTLBSummaryInfo p_YTLB, _ObjectQuantityUnitInfo p_info)
        {
            if (p_YTLB == null) return false;
            if (p_info == null) return false;
            this.CanceledBinding(p_YTLB);
            p_YTLB.BDBH = p_info.BH;
            p_YTLB.DEDJ = p_info.DEDJ;
            p_YTLB.SCDJ = p_info.SCDJ;
            p_YTLB.JSDJ = p_info.JSDJ;
            p_YTLB.SLH = p_info.SLH;
            IEnumerable<_ObjectQuantityUnitInfo> list = this.Parent.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == p_info.BH);
            foreach (_ObjectQuantityUnitInfo item in list)
            {
                item.STATUS = Status.Update;
                item.YTLB = p_YTLB.YTLB;
            }
            return true;
        }

        /// <summary>
        /// 取消绑定
        /// </summary>
        /// <param name="p_info"></param>
        public void CanceledBinding(YTLBSummaryInfo p_info)
        {
            if (p_info == null) return;
            if (p_info.BDBH == string.Empty) return;
            IEnumerable<_ObjectQuantityUnitInfo> list = this.Parent.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == p_info.BDBH);
            foreach (_ObjectQuantityUnitInfo item in list)
            {
                item.STATUS = Status.Update;
                item.YTLB = string.Empty;
            }
            p_info.BDBH = string.Empty;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public YTLBSummaryInfo GetInfo(string bh)
        {
            IEnumerable<YTLBSummaryInfo> re = this.Cast<YTLBSummaryInfo>().Where(p => p.BH == bh);
            return re.Count() == 0 ? null : re.First();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public YTLBSummaryInfo GetBDBHInfo(string bh)
        {
            IEnumerable<YTLBSummaryInfo> re = this.Cast<YTLBSummaryInfo>().Where(p => p.BDBH == bh);
            return re.Count() == 0 ? null : re.First();
        }

        /// <summary>
        /// 获取绑定对象
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public YTLBSummaryInfo GetBindingInfo(string bh)
        {
            IEnumerable<YTLBSummaryInfo> re = this.Cast<YTLBSummaryInfo>().Where(p => p.BDBH == bh || p.BH == bh);
            return re.Count() == 0 ? null : re.First();
        }

        /// <summary>
        /// 自动绑定
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public void AutoBindingInfo(UseType p_UseType)
        {
            IEnumerable<YTLBSummaryInfo> re = this.Cast<YTLBSummaryInfo>().Where(p => p.BDBH.Trim() == string.Empty && p.YTLB == p_UseType.ToString());
            foreach (YTLBSummaryInfo item in re)
            {
                YTLBSummaryInfo m_info = GetBDBHInfo(item.BH);
                if (m_info == null)
                {
                    IEnumerable<_ObjectQuantityUnitInfo> m_ObjectQuantityUnitInfo = this.Parent.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == item.BH);
                    if (m_ObjectQuantityUnitInfo.Count() > 0)
                    {
                        _ObjectQuantityUnitInfo m_defanyl = m_ObjectQuantityUnitInfo.FirstOrDefault();
                        item.BDBH = m_defanyl.BH;
                        item.SLH = m_defanyl.SLH;
                        item.SCDJ = m_defanyl.SCDJ;
                        item.DEDJ = m_defanyl.DEDJ;
                        item.GGXH = m_defanyl.GGXH;
                        foreach (_ObjectQuantityUnitInfo items in m_ObjectQuantityUnitInfo)
                        {
                            items.STATUS = Status.Update;
                            items.YTLB = item.YTLB;
                        }
                    }
                    this.Parent.Property.TemporaryCalculate.Calculate();
                }
            }
            this.Parent.Property.YTLBSummaryList_BindingSource.ResetBindings(false);
        }
    }
}
