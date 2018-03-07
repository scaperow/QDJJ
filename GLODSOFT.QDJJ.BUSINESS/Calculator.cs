using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class Calculator : IDisposable
    {
        public List<GOLDSOFT.QDJJ.COMMONS._Entity_SubInfo> Entities = new List<GOLDSOFT.QDJJ.COMMONS._Entity_SubInfo>();
        public List<DataRow> Rows = new List<DataRow>();
        private _Business Business;
        private GOLDSOFT.QDJJ.COMMONS._UnitProject Project;
        public event EventHandler CalculateFinish;
        public event EventHandler BeforeCalculate;

        public Calculator(_Business business, GOLDSOFT.QDJJ.COMMONS._UnitProject project)
        {
            Business = business;
            Project = project;
        }

        public void Dispose()
        {
            Entities.AddRange(GOLDSOFT.QDJJ.COMMONS._Entity_SubInfo.ParseMore(Rows.ToArray()));

            if (Entities.Count == 0)
            {
                return;
            }

            if (BeforeCalculate != null)
            {
                BeforeCalculate(this, EventArgs.Empty);
            }

            _Methods.Calculate(Business, Project, Entities.ToArray());

            if (CalculateFinish != null)
            {
                CalculateFinish(this, EventArgs.Empty);
            }
        }

        public static void Calculate(_Business business, GOLDSOFT.QDJJ.COMMONS._UnitProject project, params DataRow[] rows)
        {
                _Methods.Calculate(business, project, rows);
        }

        public static void Calculate(_Business business, GOLDSOFT.QDJJ.COMMONS._UnitProject project, params GOLDSOFT.QDJJ.COMMONS._Entity_SubInfo[] entities)
        {
                _Methods.Calculate(business, project, entities);
         
        }
    }
}
