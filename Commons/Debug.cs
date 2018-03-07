using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public partial class Debug : Form
    {
        public DataSet Dataset { private set; get; }
        public static Debug Form { private set; get; }

        public Debug(DataSet set)
        {
            Dataset = set;
            InitializeComponent();
        }

        private void Debug_Load(object sender, EventArgs e)
        {
            foreach (DataTable table in Dataset.Tables)
            {
                this.List.Items.Add(table.TableName);
            }
        }

        public void Show(string tableName)
        {
            if (Dataset.Tables.Contains(tableName))
            {
                Data.DataSource = Dataset.Tables[tableName];
            }

            Show();
        }

        public static void Show(DataSet dataset, string tableName)
        {
            Form = new Debug(dataset)
            {
                 Dataset =  dataset
            };

            Form.Show(tableName);
        }


        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.DataSource = Dataset.Tables[List.SelectedItem.ToString()];
           
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            //Debug.Show(Dataset, List.SelectedItem.ToString());
        }
    }
}
