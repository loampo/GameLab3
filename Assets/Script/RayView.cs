using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayView : MonoBehaviour
{

	public float weaponRange = 50f;

	private Camera fpsCam;


	

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
   
}

