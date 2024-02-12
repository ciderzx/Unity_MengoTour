using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MENGO_TOUR.CITY
{
    [CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Object/Mission", order = int.MaxValue)]
    public class Mission : ScriptableObject
    {
        [SerializeField] private string missionId;

        public string missionTitle;

        public int missionMaxCnt;
        private int missionCnt;
        public int MissionCnt
        {
            get { return missionCnt; }
        }

        public int time;

        private void OnEnable()
        {
            
        }

        public string Id
        {
            get { return missionId; }
        }

        public bool EqualsId(string id)
        {
            return missionId.Equals(id);
        }

        public void StartMission()
        {
            missionCnt = 0;
        }

        public void CountUp()
        {
            missionCnt++;

            if(missionCnt >= missionMaxCnt)
            {
                Clear();
                missionCnt = 0;
            }
        }

        public void Clear()
        {
            MissionManager.Instance.RemoveMission(this);
        }

        
    }
}


