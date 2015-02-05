using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	namespace Board
	{
		public class BoardBehaviour : MonoBehaviour {
		public List<CharacterBehaviour> TeamA, TeamB;

		public void AddToTeam (int teamNo, CharacterBehaviour character){
			if (teamNo == 0) 
			{
				TeamA.Add (character);
			} 
			else if (teamNo == 1) 
			{
				TeamB.Add (character);
			}
		}
		public List<CharacterBehaviour> GetTeam(int team)
		{
			if (team == 0) 
			{
				return TeamA;
			}
			else if (team == 1)
			{
				return TeamB;
			}
			return null;
	}
	}
}