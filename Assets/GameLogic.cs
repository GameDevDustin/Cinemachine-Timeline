using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private Transform[] vCamsTransforms;
    [SerializeField]
    private CinemachineVirtualCamera[] vCams = new CinemachineVirtualCamera[5];
    private CinemachineVirtualCamera switchToVCam;

    // Start is called before the first frame update
    void Start()
    {
        //Assign VCam components to array
        vCams[0] = vCamsTransforms[0].GetComponent<CinemachineVirtualCamera>();
        vCams[1] = vCamsTransforms[1].GetComponent<CinemachineVirtualCamera>();
        vCams[1].gameObject.SetActive(false);
        vCams[2] = vCamsTransforms[2].GetComponent<CinemachineVirtualCamera>();
        vCams[2].gameObject.SetActive(false);
        vCams[3] = vCamsTransforms[3].GetComponent<CinemachineVirtualCamera>();
        vCams[3].gameObject.SetActive(false);
        vCams[4] = vCamsTransforms[4].GetComponent<CinemachineVirtualCamera>();
        vCams[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            //Enable VCam 1
            switchToVCam = vCams[0];
            switchToVCam.gameObject.SetActive(true);
            switchToVCam.Priority = 100;
            ResetVCamsPriorities(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            //Enable VCam 2
            switchToVCam = vCams[1];
            switchToVCam.gameObject.SetActive(true);
            switchToVCam.Priority = 100;
            ResetVCamsPriorities(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) == true)
        {

            //Enable VCam 3
            switchToVCam = vCams[2];
            switchToVCam.gameObject.SetActive(true);
            switchToVCam.Priority = 100;
            ResetVCamsPriorities(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) == true)
        {
            //Enable VCam 4
            switchToVCam = vCams[3];
            switchToVCam.gameObject.SetActive(true);
            switchToVCam.Priority = 100;
            ResetVCamsPriorities(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) == true)
        {
            //Enable VCam 5
            switchToVCam = vCams[4];
            switchToVCam.gameObject.SetActive(true);
            switchToVCam.Priority = 100;
            ResetVCamsPriorities(4);
        }
    }

    private void ResetVCamsPriorities(int nextVCamIndex)
    {
        switch (nextVCamIndex)
        {
            case 0:
                for (int i = 1; i < 5; i++) {
                    vCams[i].Priority = 10;
                    vCams[i].gameObject.SetActive(false);
                }
                break;
            case 1:
                vCams[0].Priority = 10;
                vCams[0].gameObject.SetActive(false);
                vCams[2].Priority = 10;
                vCams[2].gameObject.SetActive(false);
                vCams[3].Priority = 10;
                vCams[3].gameObject.SetActive(false);
                vCams[4].Priority = 10;
                vCams[4].gameObject.SetActive(false);
                break;
            case 2:
                vCams[0].Priority = 10;
                vCams[0].gameObject.SetActive(false);
                vCams[1].Priority = 10;
                vCams[1].gameObject.SetActive(false);
                vCams[3].Priority = 10;
                vCams[3].gameObject.SetActive(false);
                vCams[4].Priority = 10;
                vCams[4].gameObject.SetActive(false);
                break;
            case 3:
                vCams[0].Priority = 10;
                vCams[0].gameObject.SetActive(false);
                vCams[1].Priority = 10;
                vCams[1].gameObject.SetActive(false);
                vCams[2].Priority = 10;
                vCams[2].gameObject.SetActive(false);
                vCams[4].Priority = 10;
                vCams[4].gameObject.SetActive(false);
                break;
            case 4:
                for (int i = 3; i > -1; i--)
                {
                    vCams[i].Priority = 10;
                    vCams[i].gameObject.SetActive(false);
                }
                break;
            default:
                Debug.Log("GameLogic::ResetVCamsPriorities - nextVCamIndex out of range!");
                break;
        }
    }
}
