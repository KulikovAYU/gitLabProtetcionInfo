using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingGraph.UserControls;

namespace TestingGraph
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AddChild(ETypeControls.eStartPanel);
        }

        public void LoadStartPage()
        {
            var ctrl = ControlsFactory.CreateControl(ETypeControls.eStartPanel);
            AddChild(ctrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">тип элемкента управления</param>
        public void AddChild(ETypeControls type)
        {
            var ctrl = ControlsFactory.CreateControl(type);
            if (ctrl == null)
                throw new Exception("ctrl is null");
            PresentPanel.Controls.Clear();
            PresentPanel.Controls.Add(ctrl);
        }

        /// <summary>
        /// Добавляет елемент управления на форму
        /// </summary>
        /// <param name="ctrl">элемент управления</param>
        public void AddChild(Control ctrl)
        {
            if (ctrl == null)
                throw new Exception("ctrl is null");
            PresentPanel.Controls.Clear();
            PresentPanel.Controls.Add(ctrl);
           
        }

    }


    /// <summary>
    /// тип элемента управления
    /// </summary>
    public enum ETypeControls
    {
        eStartPanel,
        eAdjacencyMatrixInput,//матрица смежности
        eIncidenceMatrixInput,//матрица инцедентности
        eEdgeListInput,//список ребер
        eMatrix,//заполнение матрицы
        eShowResult
    }

    /// <summary>
    ///Фабрика пользовательских элементов упоравления
    /// </summary>
    public class ControlsFactory
    {
        public static Control CreateControl(ETypeControls type)
        {
            switch (type)
            {
                case ETypeControls.eStartPanel:
                    return new StartPanel();
                case ETypeControls.eAdjacencyMatrixInput:
                    return new eAdjacencyMatrixInput();
                case ETypeControls.eIncidenceMatrixInput:
                    return null;
                case ETypeControls.eEdgeListInput:
                    return null;
                case ETypeControls.eMatrix:
                    return new eMatrix();
                case ETypeControls.eShowResult:
                    return new eShowResult();
                default:
                    return null;
            }
        }
    }
}