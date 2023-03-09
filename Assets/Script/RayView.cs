using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayView : MonoBehaviour
{

	public float weaponRange = 50f;
	private float _cinemachineTargetPitch;
	private Camera fpsCam;
	public GameObject CinemachineCameraTarget;
	private float _rotationVelocity;
	public float RotationSpeed = 1.0f;
	public float BottomClamp = -90.0f;
	public float TopClamp = 90.0f;
	private const float _threshold = 0.01f;



	private bool IsCurrentDeviceMouse = true;
	

	// Start is called before the first frame update
	void Start()
	{
		fpsCam = GetComponentInChildren<Camera>();
	}

    //Update is called once per frame

    void Update()
    {
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0f, 0f, 0.0f));

        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
    }
    private void LateUpdate()
	{
		CameraRotation();
	}

	private void CameraRotation()
	{
		
		
			//Don't multiply mouse input by Time.deltaTime
			float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

			_cinemachineTargetPitch += (Input.GetAxis("Mouse Y")) * RotationSpeed * deltaTimeMultiplier;
			_rotationVelocity = (Input.GetAxis("Mouse X")) * RotationSpeed * deltaTimeMultiplier;
			
			// clamp our pitch rotation
			_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

			// Update Cinemachine camera target pitch
			CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

			// rotate the player left and right
			transform.Rotate(Vector3.up * _rotationVelocity);
		
	}

	private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}
}

