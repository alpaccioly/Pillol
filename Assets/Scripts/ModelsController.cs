using UnityEngine;
using System.Collections;

public class ModelsController : MonoBehaviour {

	public metaioTracker myMetaioTracker;
	public metaioSDK myMetaioSDK;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Demo # 1
		if(Input.GetKeyDown("a"))
		{
			Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
			//this.transform.localScale = new Vector3 (myMetaioTracker.cameraPosition.transform.rotation.eulerAngles.z / 100, myMetaioTracker.cameraPosition.transform.rotation.eulerAngles.z / 100, myMetaioTracker.cameraPosition.transform.rotation.eulerAngles.z / 100);

		}
	}
}
