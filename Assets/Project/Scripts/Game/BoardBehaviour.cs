using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Board
{
    public class BoardBehaviour : MonoBehaviour
    {
        public List<CharacterBehaviour> TeamA, TeamB;
        public int membersPerTeam = 5;
       
        void Awake()
        {
            for (int i = 1; i != membersPerTeam; ++i)
            {
                GameObject player = Instantiate(Resources.Load("PufPowNega")) as GameObject;
                player.transform.name = "CharacterA" + i;
                player.transform.parent = transform.FindChild("metaioSDK");
                player.transform.localPosition = new Vector3(-15f, 13 - i * 2);
                CharacterBehaviour cb = player.GetComponent<CharacterBehaviour>();
                cb.TeamNumber = 0;
                player.GetComponent<metaioTracker>().cosID = i;
                TeamA.Add(cb);
            }
            for (int i = 1; i != membersPerTeam; ++i)
            {
                GameObject player = Instantiate(Resources.Load("PufPowBichinho")) as GameObject;
                player.transform.name = "CharacterB" + i;
                player.transform.parent = transform.FindChild("metaioSDK");
                player.transform.localPosition = new Vector3(-2f, 13 - i * 2);
                CharacterBehaviour cb = player.GetComponent<CharacterBehaviour>();
                cb.TeamNumber = 1;
                player.GetComponent<metaioTracker>().cosID = i + membersPerTeam;
                TeamB.Add(cb);
            }
        }

        public void Init()
        {
            foreach (CharacterBehaviour ch in TeamA)
            {
                ch.fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
            }
            foreach (CharacterBehaviour ch in TeamB)
            {
                ch.fsm.ChangeState(new CharacterIdleState<CharacterBehaviour>());
            }
        }

        public void AddToTeam(int teamNo, CharacterBehaviour character)
        {
            if (teamNo == 0) 
                TeamA.Add(character);
            else if (teamNo == 1)
                TeamB.Add(character);
        }

        public List<CharacterBehaviour> GetTeam(int team)
        {
            if (team == 0)
                return TeamA;
            else if (team == 1)
                return TeamB;
            return null;
        }
    }
}