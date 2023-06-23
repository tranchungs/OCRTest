using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ManagerData
{
    public List<Data> getData()
    {
        List<Data> listData = null;
        StreamReader read = new StreamReader("input.txt");
        String data = read.ReadToEnd();
        read.Close();
        if (data == "")
        {

        }
        else
        {
            String[] arrData = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            listData = new List<Data>();
            for (int i = 0; i < arrData.Length; i++)
            {
                try
                {
                    String[] sData = arrData[i].Split('|');
                    String namePath = sData[0];
                    String plaintText = sData[1];
                    FileInfo fileInfo = new FileInfo("input.txt");
                    String direc = fileInfo.DirectoryName + "\\Image";
                    String path = direc + "\\"+namePath;
                    Data dataCheck = new Data(path, plaintText);
                    listData.Add(dataCheck);
                }
                catch 
                {

                   
                }
            }
        }
        return listData;
    }
}
