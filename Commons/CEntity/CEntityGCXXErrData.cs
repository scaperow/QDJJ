using System;
using System.Collections.Generic;
using System.Text;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class CEntityGCXXErrData : CEntity
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _JDName;

        public string JDName
        {
            get { return _JDName; }
            set { _JDName = value; }
        }
        private string _ColContrnts;

        public string ColContrnts
        {
            get { return _ColContrnts; }
            set { _ColContrnts = value; }
        }
        private string _Contents;

        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        private string _AddTime;

        public string AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }
        private int _ResultsState;

        public int ResultsState
        {
            get { return _ResultsState; }
            set { _ResultsState = value; }
        }
        private string _Results;

        public string Results
        {
            get { return _Results; }
            set { _Results = value; }
        }
        private int _IsLOCK;

        public int IsLOCK
        {
            get { return _IsLOCK; }
            set { _IsLOCK = value; }
        }

        private string _interLock;
        public string InterLock
        {
            get { return _interLock; }
            set { _interLock = value; }
        }
        
    }
}
