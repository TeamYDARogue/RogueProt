using UnityEngine;
using System.Collections;
public class TpsCamera : MonoBehaviour {

	void Start () {
	}
    public Transform target;
	/// <summary>
	///使い方
    ///カメラにくっつけてInspectorでTargetを選択すると追従します
    ///現状はPrivateCubeにくっつけています（要するに見えないキューブ）
	///左右キーで回る 
	/// </summary>
	void Update () {
		Vector3 A = new Vector3(target.position.x, target.position.y + 1, target.position.z);
        transform.position = target.position;
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
		}		
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f)); 
			
		}
	}
}
