using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private Transform[] _vCamsTransforms;
    [SerializeField]
    private CinemachineVirtualCamera[] _vCams = new CinemachineVirtualCamera[5];
    private CinemachineVirtualCamera _switchToVCam;
    [SerializeField]
    private Transform[] _targetGOs;
    private int _currTarget = 1;
    private int _currZoom = 40;

    // Start is called before the first frame update
    void Start()
    {
        //Assign VCam components to array
        _vCams[0] = _vCamsTransforms[0].GetComponent<CinemachineVirtualCamera>();
        _vCams[1] = _vCamsTransforms[1].GetComponent<CinemachineVirtualCamera>();
        _vCams[1].gameObject.SetActive(false);
        _vCams[2] = _vCamsTransforms[2].GetComponent<CinemachineVirtualCamera>();
        _vCams[2].gameObject.SetActive(false);
        _vCams[3] = _vCamsTransforms[3].GetComponent<CinemachineVirtualCamera>();
        _vCams[3].gameObject.SetActive(false);
        _vCams[4] = _vCamsTransforms[4].GetComponent<CinemachineVirtualCamera>();
        _vCams[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Change targets for _vCams[0]
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            SwitchTarget();
        }

        //Zoom in and out on _vCams[0]
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            ChangeFoV();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            //Enable VCam 1
            _switchToVCam = _vCams[0];
            _switchToVCam.gameObject.SetActive(true);
            _switchToVCam.Priority = 100;
            ResetVCamsPriorities(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            //Enable VCam 2
            _switchToVCam = _vCams[1];
            _switchToVCam.gameObject.SetActive(true);
            _switchToVCam.Priority = 100;
            ResetVCamsPriorities(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) == true)
        {

            //Enable VCam 3
            _switchToVCam = _vCams[2];
            _switchToVCam.gameObject.SetActive(true);
            _switchToVCam.Priority = 100;
            ResetVCamsPriorities(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) == true)
        {
            //Enable VCam 4
            _switchToVCam = _vCams[3];
            _switchToVCam.gameObject.SetActive(true);
            _switchToVCam.Priority = 100;
            ResetVCamsPriorities(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) == true)
        {
            //Enable VCam 5
            _switchToVCam = _vCams[4];
            _switchToVCam.gameObject.SetActive(true);
            _switchToVCam.Priority = 100;
            ResetVCamsPriorities(4);
        }
    }

    private void ResetVCamsPriorities(int nextVCamIndex)
    {
        switch (nextVCamIndex)
        {
            case 0:
                for (int i = 1; i < 5; i++) {
                    _vCams[i].Priority = 10;
                    _vCams[i].gameObject.SetActive(false);
                }
                break;
            case 1:
                _vCams[0].Priority = 10;
                _vCams[0].gameObject.SetActive(false);
                _vCams[2].Priority = 10;
                _vCams[2].gameObject.SetActive(false);
                _vCams[3].Priority = 10;
                _vCams[3].gameObject.SetActive(false);
                _vCams[4].Priority = 10;
                _vCams[4].gameObject.SetActive(false);
                break;
            case 2:
                _vCams[0].Priority = 10;
                _vCams[0].gameObject.SetActive(false);
                _vCams[1].Priority = 10;
                _vCams[1].gameObject.SetActive(false);
                _vCams[3].Priority = 10;
                _vCams[3].gameObject.SetActive(false);
                _vCams[4].Priority = 10;
                _vCams[4].gameObject.SetActive(false);
                break;
            case 3:
                _vCams[0].Priority = 10;
                _vCams[0].gameObject.SetActive(false);
                _vCams[1].Priority = 10;
                _vCams[1].gameObject.SetActive(false);
                _vCams[2].Priority = 10;
                _vCams[2].gameObject.SetActive(false);
                _vCams[4].Priority = 10;
                _vCams[4].gameObject.SetActive(false);
                break;
            case 4:
                for (int i = 3; i > -1; i--)
                {
                    _vCams[i].Priority = 10;
                    _vCams[i].gameObject.SetActive(false);
                }
                break;
            default:
                Debug.Log("GameLogic::ResetVCamsPriorities - nextVCamIndex out of range!");
                break;
        }
    }

    private void SwitchTarget()
    {
        //Set new _currTarget
        if (_currTarget == 1)
        {
            _currTarget = 2;
            _vCams[0].LookAt = _targetGOs[1];
        }
        else
        {
            _currTarget = 1;
            _vCams[0].LookAt = _targetGOs[0];
        }
    }

    private void ChangeFoV()
    {
        if(_currZoom == 40)
        {
            _currZoom = 60;
        } else if (_currZoom == 60)
        {
            _currZoom = 20;
        } else if(_currZoom == 20)
        {
            _currZoom = 40;
        }

        _vCams[0].m_Lens.FieldOfView = _currZoom;
    }
}
