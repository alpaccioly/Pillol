using UnityEngine;
using System.Collections;

namespace Board
{
	public class BoardBehaviour : MonoBehaviour 
	{
		private int sizeX = 10;
		private int sizeY = 5;

		public PointBoard? GetPositionBoard(Vector3 point)
		{
			Vector3 scale = transform.Find ("Floor").transform.localScale;
			Vector3 origin = new Vector3(-scale.x/2,0,-scale.z/2);
			Vector3 rel = (point - origin);
			PointBoard p = new PointBoard ();
			p.I = (int)((rel.x / scale.x) * sizeX);
			p.J = (int)((rel.z / scale.z) * sizeY);
			return p;
		}
	}
	public struct PointBoard
	{
		public int I;
		public int J;
	}
}