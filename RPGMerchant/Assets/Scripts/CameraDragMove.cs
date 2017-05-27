using System.Collections;
using System.Collections.Generic;
using Tiled2Unity;
using UnityEngine;

public class CameraDragMove : MonoBehaviour
{
	public TiledMap Map;
	private Vector3 _resetCamera;
	private Vector3 _origin;
	private Vector3 _diference;
	private float _left = -1.79f;
	private bool _drag = false;
	private float _mapleft;
	private float _mapup;
	private float _vertExtent;
	private float _horzExtent;
	private float _minX;
	private float _maxX;
	private float _minY;
	private float _maxY;
	private float _mapX;
	private float _mapY;

	void Start()
	{
		_resetCamera = Camera.main.transform.position;
		_mapleft = Map.transform.position.x;
		_mapup = Map.transform.position.y;
		_mapX = -_mapleft * 2;
		_mapY = _mapup * 2;
		_vertExtent = Camera.main.orthographicSize;
		_horzExtent = _vertExtent * Screen.width / Screen.height;
		_minX = (_horzExtent - _mapX / 2f);
		_maxX = _mapX / 2f - _horzExtent;
		_minY = _vertExtent - _mapY / 2f;
		_maxY = _mapY / 2f - _vertExtent;

	}
	void LateUpdate()
	{
	
		var v3 = transform.position;
		v3.x = Mathf.Clamp(v3.x, _minX, _maxX);
		v3.y = Mathf.Clamp(v3.y, _minY, _maxY);
		Camera.main.transform.position = v3;

		if (Input.GetMouseButton(0))
		{
			_diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
			if (_drag == false)
			{
				_drag = true;
				_origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		else
		{
			_drag = false;
		}
		if (_drag)
		{
			Camera.main.transform.position = _origin - _diference;
		}
		
		if (Input.GetMouseButton(1))
		{
			Camera.main.transform.position = _resetCamera;
		}
	}
}

