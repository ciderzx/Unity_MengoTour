using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Util;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    static string CSV_LOCATION = "CSV\\";

    /// <summary>
    /// 공용 CSV READER
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static List<Dictionary<string, object>> Read(string file)
    {
        var list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(CSV_LOCATION + file) as TextAsset;

        if(data == null)
        {
            //Debug.Log(file + "  파일 없음");
            return null;
        }

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }

    /// <summary>
    /// 퀘스트 전용 CSV READER
    /// </summary>
    /// <param name="countryID"></param>
    /// <returns></returns>
    public static List<Constants.CountryQuest> ReadQuest(string countryID)
    {
        string filePath = countryID + "\\" + countryID;

        var list = new List<Constants.CountryQuest>();
        TextAsset data = Resources.Load(CSV_LOCATION + filePath) as TextAsset;

        if (data == null)
        {
            Debug.Log(countryID + "  파일 없음");
            return null;
        }

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Constants.CountryQuest();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                bool b;

                // 순서대로 구조체 변수에 값을 넣어줌.
                switch (j)
                {
                    case 0:
                        entry.QUEST_ID = value;
                        break;
                    case 1:
                        entry.TITLE = value;
                        break;
                    case 2:
                        entry.INFO = value;
                        break;
                }
            }
            list.Add(entry);
        }
        return list;
    }

    #region NO USED 
    //public static List<Constants.DialogContents> ReadQuest(string file)
    //{
    //    var list = new List<Constants.DialogContents>();
    //    TextAsset data = Resources.Load(file) as TextAsset;

    //    if (data == null)
    //    {
    //        Debug.Log(file + "  파일 없음");
    //        return null;
    //    }

    //    var lines = Regex.Split(data.text, LINE_SPLIT_RE);

    //    if (lines.Length <= 1) return list;

    //    var header = Regex.Split(lines[0], SPLIT_RE);
    //    for (var i = 1; i < lines.Length; i++)
    //    {

    //        var values = Regex.Split(lines[i], SPLIT_RE);
    //        if (values.Length == 0 || values[0] == "") continue;

    //        var entry = new Constants.DialogContents();
    //        for (var j = 0; j < header.Length && j < values.Length; j++)
    //        {
    //            string value = values[j];
    //            value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
    //            object finalvalue = value;
    //            bool b;

    //            switch(j)
    //            {
    //                case 0:
    //                    entry.ID = int.Parse(value);
    //                    break;
    //                case 1:
    //                    break;
    //                case 2:
    //                    entry.Name = value;
    //                    break;
    //                case 3:
    //                    entry.Script = value;
    //                    break;
    //                case 4:
    //                    if (value.Equals("true", StringComparison.OrdinalIgnoreCase))
    //                        b = true;
    //                    else
    //                        b = false;
    //                    entry.IsTouchEnd = b;
    //                    break;
    //                case 5:
    //                    entry.Sound = value;
    //                    break;
    //                case 6:
    //                    if (byte.TryParse(value, out byte n))
    //                        entry.LongScript = n;
    //                    else
    //                        entry.LongScript = 2;

    //                    break;
    //                case 7:
    //                    entry.Etc = value;
    //                    break;
    //            }
    //        }
    //        list.Add(entry);
    //    }
    //    return list;
    //}
    #endregion
}