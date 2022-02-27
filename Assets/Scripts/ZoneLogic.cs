using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLogic : MonoBehaviour
{
    [SerializeField]
    private int _zoneID;
    [SerializeField]
    private SimpleCharacterController _charControlScript;


    // Start is called before the first frame update
    void Start()
    {
       _charControlScript = GameObject.Find("Target3").GetComponent<SimpleCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered for ZoneID: " + _zoneID);
        switch (_zoneID)
        {
            //Go to Higher Elev VCam
            case 1:
                _charControlScript.SwitchToHighElevVCam();
                break;
            //Go to Track VCam
            case 2:
                _charControlScript.SwitchToTrackVCam();
                break;
            //Go to Static Look At VCam
            case 3:
                _charControlScript.SwitchToStaticLookAtVCam();
                break;
            //Go to 3rd Person VCam
            case 4:
                _charControlScript.SwitchTo3rdPersonCamera();
                break;
        }
    }
}
