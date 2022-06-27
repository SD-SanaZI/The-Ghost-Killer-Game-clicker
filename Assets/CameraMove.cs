using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 posMouse, posCam;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
	{
	    posCam = GetComponent<Transform>().position;
	    posMouse = Input.mousePosition;
	} 
	else if(Input.GetMouseButton(0))
	{
	    float x = posCam.x - (Input.mousePosition.x - posMouse.x)/10;
	    float y = posCam.z - (Input.mousePosition.y - posMouse.y)/10;
	    if(x > 7)	x = 7;
	    if(x < -7)	x = -7;
	    if(y > -5)	y = -5;
	    if(y < -12)	y = -12;	
	    GetComponent<Transform>().position = new Vector3(x, posCam.y, y);
	}
    }
}
