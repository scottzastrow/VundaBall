using UnityEngine;
using System.Collections;

public class GyroAlignAxis : MonoBehaviour {
	
	private Gyroscope gyroscope;
	private RemoteGyroscope remoteGyroscope;
	public Transform gravity;
	
	// Use this for initialization
	void Start () {
		gyroscope = Input.gyro;
	}
	
	// Update is called once per frame
	void Update () {
		if (SystemInfo.supportsGyroscope) {
			Vector3 position = new Vector3( gyroscope.gravity.z * -1, gyroscope.gravity.y, gyroscope.gravity.x );
			gravity.transform.position = position;
		}
		else {
			if (remoteGyroscope == null)
				remoteGyroscope = GyroMote.gyro();
			
			if (remoteGyroscope) {
				gravity.transform.position = new Vector3(remoteGyroscope.gravity.z * -1, remoteGyroscope.gravity.y, remoteGyroscope.gravity.x);	
			}
		}
		
		transform.LookAt(gravity);
	}
}
