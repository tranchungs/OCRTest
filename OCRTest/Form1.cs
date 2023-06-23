using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCRTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index = 0;
        List<ResultAll> listResult = new List<ResultAll>();
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                int correct = 0;

                ManagerData managerData = new ManagerData();
                List<Data> dataList = managerData.getData();


                IronOCR_T ironOCR = new IronOCR_T();
                int count = 0;
                foreach (Data item in dataList)
                {
                    ironOCR.SetData(item);
                    String dataRead = ironOCR.Read();
                    if (dataRead == item.plainText)
                    {
                        Invoke(new Action(() =>
                        {
                            lbResult.Text = $"OCR:{count}/{dataList.Count}";
                        }));
                        correct++;

                    }
                    ResultAll rsItem = new ResultAll(item, dataRead);
                    listResult.Add(rsItem);
                }
                Invoke(new Action(() =>
                {
                    lbResult.Text = $"Kết quả:{correct}/{dataList.Count}";
                }));
              
            });
            t.Start();
            t.IsBackground = true;
           
          
            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(index == 0)
            {
                index = listResult.Count - 1;
            }
            else
            {
                index--;
            }

            ViewData(listResult[index]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (index == listResult.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            ViewData(listResult[index]);
        }
        private void ViewData(ResultAll item)
        {
            picBoxResult.Image = (Image)Image.FromFile(item.dataCheck.pathImg);
            lbPlainText.Text = item.dataCheck.plainText;
            lbResultText.Text = item.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    public class ResultAll
    {
        public Data dataCheck;
        public String Text;
        public ResultAll(Data dataCheck,String Text)
        {
            this.dataCheck = dataCheck;
            this.Text = Text;
        }
    }
}
