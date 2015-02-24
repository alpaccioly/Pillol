using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Board
{
    public class BoardBehaviour : MonoBehaviour
    {
        public List<CharacterBehaviour> TeamA, TeamB;
        public int membersPerTeam = 5;
       
        public void setCharState(int id, bool onScene)
        {
            List<CharacterBehaviour> list = new List<CharacterBehaviour>();

            list.AddRange(TeamA);
            list.AddRange(TeamB);

            foreach (CharacterBehaviour cb in list)
            {
                if(cb.cosID == id)
                {
                    cb.isOnScene = onScene;
                    return;
                }
            }
        }

        private void InstChars(string[] names)
        {
            int size = names.Length;

            for (int i = 1; i <= size; i++)
            {
                if (i <= (size / 2))
                    TeamA.Add(InstChar(names[i - 1], i, 0));
                else
                    TeamB.Add(InstChar(names[i - 1], i, 1));
            }
        }

        private CharacterBehaviour InstChar(string name, int marker, int team)
        {
            GameObject player = Instantiate(Resources.Load(name)) as GameObject;
            player.transform.name = name;
            player.transform.parent = transform.FindChild("metaioSDK");
            CharacterBehaviour cb = player.GetComponent<CharacterBehaviour>();
            cb.TeamNumber = team;
			cb.NameChar = name;
			cb.LoadParametersBalance();
            player.GetComponent<metaioTracker>().cosID = marker;
            cb.cosID = marker;
            return cb;
        }

        void Awake()
        {
			Debug.Log("LOL " + PlayerPrefs.GetString ("Characters"));
			string[] names = PlayerPrefs.GetString ("Characters").Split(new char[] {','});
			Debug.Log (names);
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