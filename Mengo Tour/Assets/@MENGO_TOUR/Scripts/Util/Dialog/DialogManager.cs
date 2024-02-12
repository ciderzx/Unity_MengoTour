using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class DialogManager : MonoBehaviour
{
    private void OnEnable()
    {
        SetupQuestList();
    }

    private void SetupQuestList()
    {
        List<Dictionary<string, object>> orderList = CSVReader.Read("QUEST_LIST");

        for (int index = 0; index < orderList.Count; index++)
        {
            string country = orderList[index]["COUNTRY"].ToString();

            List<Constants.CountryQuest> countryQuests = CSVReader.ReadQuest(country);

            for (int j = 0; j < countryQuests.Count; j++)
            {
                Debug.Log("QUEST_ID : " + countryQuests[j].QUEST_ID + ", TITLE : " + countryQuests[j].TITLE + ", INFO : " + countryQuests[j].INFO);
            }
        }
    }
}
