using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Board
{
    public class BoardBehaviour : MonoBehaviour
    {
        public List<CharacterBehaviour> TeamA, TeamB;
        public int membersPerTeam = 5;
       
        private void InstChars(string[] names)
        {
            int size = names.Length;

            for (int i = 0; i < size; i++)
            {
                if(i < (size / 2))
                    TeamA.Add(InstChar(names[i], i, 0));
                else
                    TeamB.Add(InstChar(names[i], i, 1));
            }
        }

        private CharacterBehaviour InstChar(string name, int marker, int team)
        {
            GameObject player = Instantiate(Resources.Load(name)) as GameObject;
            player.transform.name = name;
            player.transform.parent = transform.FindChild("metaioSDK");
            player.transform.localPosition = new Vector3(-15f, 13 - marker * 2);
            CharacterBehaviour cb = player.GetComponent<CharacterBehaviour>();
            cb.TeamNumber = team;
            player.GetComponent<metaioTracker>().cosID = marker;
            return cb;
        }

        void Awake()
        {
            string[] names = {"PufPowBichinho", "PufPowGalego", "PufPowGarotaLoira",
                "PufPowGordo", "PufPowMain", "PufPowNega", "PufPowNego",
                "PufPowNerd", "PufPowPequena", "PufPowPunk"};

            InstChars(names);
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