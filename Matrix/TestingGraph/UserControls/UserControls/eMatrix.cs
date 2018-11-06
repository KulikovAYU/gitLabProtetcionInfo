using System;
using System.Data;
using System.Windows.Forms;

namespace TestingGraph
{
    public partial class eMatrix : UserControl
    {
        DataSet ds = new DataSet();
        private readonly algorit m_algo;

        public eMatrix()
        {
            InitializeComponent();
            m_algo = algorit.GetInstance;
        }

        public int m_Val1 { get; set; }

        public int m_Val2 { get; set; }

        public  void FillTable(ETypeControls currentVar)
        {
            int n = 0;
            int n1 = 0;

            switch (currentVar)
            {
                case ETypeControls.eAdjacencyMatrixInput:
                    n = m_Val1;
                    n1 = m_Val1;
                    break;

                case ETypeControls.eEdgeListInput:
                case ETypeControls.eIncidenceMatrixInput:
                    n = m_Val1;
                    n1 = m_Val2;
                    break;
            }
            //текущий вариант
            int var = (int)currentVar;
            m_algo.create_mas(n, n1, var);

            ds.Tables.Clear();
            ds.Tables.Add("matriza");

            if (currentVar == ETypeControls.eEdgeListInput)
            {
                for (int i = 0; i < 2; i++)
                {
                    ds.Tables[0].Columns.Add((i + 1).ToString());
                }
                for (int i = 0; i < n1; i++)
                {
                    ds.Tables[0].Rows.Add(m_algo.RetRow(m_algo.mas, i));
                }
            }
            else
            {
                for (int i = 0; i < n1; i++)
                {
                    ds.Tables[0].Columns.Add((i + 1).ToString());
                }
                for (int i = 0; i < n; i++)
                {
                    ds.Tables[0].Rows.Add(m_algo.RetRow(m_algo.mas, i));
                }
            }
           
            setka.DataSource = ds.Tables[0];
            setka.Show();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.LoadStartPage();
            }
        }

        /// <summary>
        /// Инцедентности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Boolean flaggy = Check();
            
            if (!flaggy)
            {
                m_algo.DoInt(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }

        /// <summary>
        /// Ребра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setkaOK_Click(object sender, EventArgs e)
        {
            var flaggy = Check();
            if (!flaggy)
            {
                m_algo.DoLinks(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }

        private bool Check()
        {
            Boolean flaggy = false;

            TextBox.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                int nnn = 0;
                var isNumeric = int.TryParse(Convert.ToString(ds.Tables[0].Rows[i][j]), out nnn);
                if (isNumeric)
                {
                    m_algo.mas[i, j] = Convert.ToInt32(ds.Tables[0].Rows[i][j]);

                    if (((m_algo.type == 3) && (m_algo.mas[i, j] > m_algo.len))
                        || ((m_algo.type == 3) && (m_algo.mas[i, j] < 1))
                        || ((m_algo.type == 1) && (m_algo.mas[i, j] > 1))
                        || ((m_algo.type == 1) && (m_algo.mas[i, j] < 0))
                        || ((m_algo.type == 2) && (m_algo.mas[i, j] > 1))
                        || ((m_algo.type == 2) && (m_algo.mas[i, j] < 0)))
                    {
                        MessageBox.Show("Ошибка Ввода","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        flaggy = true;
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка Ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flaggy = true;
                    break;
                }
            }
            return flaggy;
        }

        /// <summary>
        /// Смежности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            var flaggy = Check();
            if (!flaggy)
            {
                m_algo.DoSmez(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }
    }
}
