using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class RoomFixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	[ContextMenu("Fix rooms")]
	void FixRooms() {
		var roomsCamera = GetComponent<ProCamera2DRooms>();

		foreach (var room in roomsCamera.Rooms)
		{
			var width = Mathf.Round( room.Dimensions.width );
			var height = Mathf.Round( room.Dimensions.height );

			room.Dimensions = new Rect(
				Mathf.Floor(room.Dimensions.xMin) + ((width % 2 == 0) ? 0 : 0.5f),
				Mathf.Floor(room.Dimensions.yMin) + ((height % 2 == 0) ? 0 : 0.5f),
				width,
				height
			);
		}
	}
}
