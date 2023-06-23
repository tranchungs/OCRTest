using IronOcr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IronOCR_T
{
    public IronTesseract ironTesseract;
    public Data dataCheck;
    public IronOCR_T()
    {
        ironTesseract = new IronTesseract();
    }
    public void ConfigLanguage()
    {
        ironTesseract.Language = OcrLanguage.English;
    }
    public void SetData(Data dataCheck)
    {
        this.dataCheck = dataCheck;
    }
    public String Read()
    {
        OcrInput input = new OcrInput();
        input.Add(dataCheck.pathImg);
        String result = ironTesseract.Read(input).Text;
        return result;

    }
}