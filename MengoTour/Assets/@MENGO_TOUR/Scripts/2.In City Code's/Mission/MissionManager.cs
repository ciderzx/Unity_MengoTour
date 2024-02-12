using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace MENGO_TOUR.CITY
{
    [Serializable]
    public class MissionInfo
    {
        public string missionId;
        public List<GameObject> objectList;
    }

    public class MissionManager : Singleton<MissionManager>
    {
        public delegate void ComplateEvent();
        public static event ComplateEvent ComplateEventHandler;

        [Header("Mission Object")]
        [SerializeField] private List<MissionInfo> missionInfoList;
        private Dictionary<string, List<GameObject>> missionObjectDictionary = new Dictionary<string, List<GameObject>>();

        private List<Mission> missionList = new List<Mission>();

        public bool interaction = false;

        public void SetInteraction(bool value)
        {
            interaction = value;
        }

        private void OnEnable()
        {
            ComplateEventHandler = delegate () { };

            foreach (MissionInfo missionInfo in missionInfoList)
            {
                missionObjectDictionary.Add(missionInfo.missionId, missionInfo.objectList);
            }
        }

        private void ActiveMission(Mission mission)
        {
            foreach(MissionInfo info in missionInfoList)
            {
                foreach (GameObject gm in info.objectList)
                {
                    gm.SetActive(mission.EqualsId(info.missionId));
                }
            }
        }

        public void AddMission(Mission mission)
        {
            if (EqualsMission(mission)) return;

            ActiveMission(mission);

            missionList.Add(mission);
            MissionUIFactory.Instance.CreateMissionUI(mission);

            mission.StartMission();
        }

        public void CountUp(Mission mission)
        {
            MissionUIFactory.Instance.CountUp(mission);
        }

        public void RemoveMission(Mission mission)
        {
            int missionIndex = EqualsMissionIndex(mission); // TODO : REFACTORING CODE 
            if (missionIndex < 0) return;

            missionList.RemoveAt(missionIndex);

            MissionUIFactory.Instance.UIDisable(mission);
        }

        private Mission EqualsMission(Mission mission)
        {
            foreach (Mission _mission in missionList)
            {
                if (_mission.EqualsId(mission.Id)) return _mission;
            }

            return null;
        }

        private int EqualsMissionIndex(Mission mission)
        {
            int index = 0;

            foreach (Mission _mission in missionList)
            {
                if (_mission.EqualsId(mission.Id)) return index;
                index++;
            }

            return -1;
        }
    }

}

