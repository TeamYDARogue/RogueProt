using UnityEngine;
using System.Collections;
public class TpsCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public Transform target;
	
	// Update is called once per frame
	void Update () {
        Vector3 A = new Vector3(target.position.x, target.position.y + 1, target.position.z);
        transform.position = target.position;
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0.0f, -90f, 0f));
			
		}		
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0.0f, 90f, 0f)); 
			
		}
	}
}
