using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1131405_BMI
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);
            if (isHeightValid) // 檢查身高是否為有效數字
            {
                if (height <= 0)
                {
                    MessageBox.Show("請輸入大於0的數字", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
            }
            else {
                MessageBox.Show("請輸入有效的數字", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isWeightValid) // 檢查體重是否為有效數字
            {
                if (weight <= 0)
                {
                    MessageBox.Show("請輸入大於0的數字", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的數字", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 將身高從公分轉換為公尺
            height = height / 100.0; 

            double dBMI = weight / (height * height);

            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };

            Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };

            string strBMI =" ";
            Color resultColor = Color.Black;
            int iResultIndex = 0;
            if (dBMI < 18.5)
            {
                iResultIndex = 0;
            }
            else if (dBMI >= 18.5 && dBMI < 24)
            {
                iResultIndex = 1;
            }
            else if (dBMI >= 24 && dBMI < 27)
            {
                iResultIndex = 2;
            }
            else if (dBMI >= 27 && dBMI < 30)
            {
                iResultIndex = 3;
            }
            else if (dBMI >= 30 && dBMI < 35)
            {
                iResultIndex = 4;
            }
            else
            {
                iResultIndex = 5;
            }
            strBMI=strResultList[iResultIndex];
            resultColor = colorList[iResultIndex];

            
            lblResult.Text = $"{dBMI:F2} ({strBMI})";
            lblResult.BackColor = resultColor;

        }
    }
}
