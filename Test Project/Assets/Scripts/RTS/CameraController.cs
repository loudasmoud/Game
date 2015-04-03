using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject player;
	public float fixedCameraSpeed;
	public bool alwaysLockedCam;
	float cameraSpeed;
	public int screenBounrdy;
	Quaternion lockCameraRotation;
	int screenWidth;
	int screenHeight;
	bool locked;
	Vector3 lockedCameraPos;
	bool scrolling;

	// Use this for initialization
	void Awake () {
		lockCameraRotation = mainCamera.transform.rotation;
	}

	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height; 
		lockedCameraPos = new Vector3 (player.transform.position.x, mainCamera.transform.position.y, (player.transform.position.z - 9));
		mainCamera.transform.position = lockedCameraPos;
		if (alwaysLockedCam)
			locked = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) || locked) {
			//Debug.Log ("Lock Camera");
			mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, (player.transform.position.z - 9));
			locked = true;
		}
		if (Input.GetKeyUp (KeyCode.Space) && !alwaysLockedCam) {
			locked = false;
		}
		if (!locked) {
			scrolling = false;
			// STILL NEED TO STOP THE JUMPING OF THE CAMERA WHEN THE PLAYER IS MOVING AND THE CAMERA IS AT THE EDGE
			if ((Input.mousePosition.x < 0 + screenBounrdy) && (mainCamera.transform.position.x >= player.transform.position.x - 10)) {
				//Debug.Log ("Left");
				scrolling = true;
				cameraSpeed = (screenBounrdy - Input.mousePosition.x)/5;
				//Debug.Log (cameraSpeed);
				mainCamera.transform.Translate (Vector3.left * cameraSpeed * Time.deltaTime, Space.World);
			}
			if (Input.mousePosition.x > screenWidth - screenBounrdy && (mainCamera.transform.position.x <= player.transform.position.x + 10)) {
				//Debug.Log ("Right");
				scrolling = true;
				cameraSpeed = (screenBounrdy - (screenWidth - Input.mousePosition.x))/5;
				//Debug.Log (cameraSpeed);
				mainCamera.transform.Translate (Vector3.right * cameraSpeed * Time.deltaTime, Space.World);
			}
			if (Input.mousePosition.y > screenHeight - screenBounrdy && (mainCamera.transform.position.z <= player.transform.position.z - 3)) {
				//Debug.Log("Forward");
				scrolling = true;
				cameraSpeed = (screenBounrdy - (screenHeight - Input.mousePosition.y))/5;
				//Debug.Log (cameraSpeed);
				mainCamera.transform.Translate (Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
			}
			if (Input.mousePosition.y < 0 + screenBounrdy && (mainCamera.transform.position.z >= player.transform.position.z - 20)) {
				//Debug.Log ("Back");
				scrolling = true;
				cameraSpeed = (screenBounrdy - Input.mousePosition.y)/5;
				//Debug.Log (cameraSpeed);
				mainCamera.transform.Translate (Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
			}
			if (!scrolling){
				Debug.Log("stop this");
				MoveToLockPos();
			}
		}
	}

	void LateUpdate(){
		mainCamera.transform.rotation = lockCameraRotation;
	}

	void MoveToLockPos(){
		mainCamera.transform.position = Vector3.MoveTowards (mainCamera.transform.position, lockedCameraPos, fixedCameraSpeed *Time.deltaTime);
	}

}