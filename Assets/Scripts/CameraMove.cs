using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector2 _UpperCameraLimit, _LowerCameraLimit;
    private Vector3 _posMouse, _posCam;

    void Start()
    {
	_UpperCameraLimit = new Vector2(35, -25);
	_LowerCameraLimit = new Vector2(-35, -60);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
	{
	    _posCam = GetComponent<Transform>().position;
	    _posMouse = Input.mousePosition;
	} 
	else if(Input.GetMouseButton(0))
	{
	    float x = _posCam.x - (Input.mousePosition.x - _posMouse.x)/10;
	    float y = _posCam.z - (Input.mousePosition.y - _posMouse.y)/10;
	    if(x > _UpperCameraLimit.x)
		x = _UpperCameraLimit.x;
	    if(x < _LowerCameraLimit.x)
		x = _LowerCameraLimit.x;
	    if(y > _UpperCameraLimit.y)
		y = _UpperCameraLimit.y;
	    if(y < _LowerCameraLimit.y)
		y = _LowerCameraLimit.y;	
	    GetComponent<Transform>().position = new Vector3(x, _posCam.y, y);
	}
    }
}
