using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvWriter : MonoBehaviour
{
    public string fileName = null;

    // CSV‚É‘‚«‚Şˆ—
    public void WriteCSV(string txt)
    {
        StreamWriter streamWiter;
        FileInfo fileInfo;

        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");

        streamWiter = fileInfo.AppendText();
        streamWiter.WriteLine(txt);
        streamWiter.Flush();
        streamWiter.Close();
    }
}
