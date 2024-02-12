using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace MENGO_TOUR.CITY
{
    public class MissionUIFactory : Singleton<MissionUIFactory>
    {
        private List<MissionUI> missionUIPool = new List<MissionUI>();

        [SerializeField] private MissionUI missionUIPrefab;

        public void CreateMissionUI(Mission mission)
        {
            MissionUI missionUI = null;

            foreach (MissionUI ui in missionUIPool)
            {
                if (!ui.gameObject.activeSelf)
                {
                    missionUI = ui;
                }
            }

            if(missionUI == null)
            {
               missionUI = Instantiate(missionUIPrefab, transform);
            }

            missionUIPool.Add(missionUI);

            missionUI.mission = mission;
            missionUI.Init();
            missionUI.gameObject.SetActive(true);
        }

        public void CountUp(Mission mission)
        {
            foreach (MissionUI ui in missionUIPool)
            {
                if (ui.gameObject.activeSelf)
                {
                    if (ui.mission.EqualsId(mission.Id))
                    {
                        ui.mission.CountUp();
                        ui.missionCntText.text = ui.mission.MissionCnt + "/" + ui.mission.missionMaxCnt;
                    }    
                }
            }
        }

        public void UIDisable(Mission mission)
        {
            foreach (MissionUI ui in missionUIPool)
            {
                if (ui.gameObject.activeSelf)
                {
                    if (ui.mission.EqualsId(mission.Id))
                    {
                        ui.Disable();
                    }
                }
            }
        }
    }
}

