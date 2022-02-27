using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private Vector3 _direction;
    [SerializeField]
    private CinemachineVirtualCamera _orbitalVCam;
    [SerializeField]
    private CinemachineVirtualCamera _3rdPersonVCam;
    private int _currVCam = 3; //0 High Elev Cam | 1 Track Cam | 2 Static Look At Cam | 3 3rd Person Cam | 4 Orbital Cam
    [SerializeField]
    private CinemachineVirtualCamera[] _triggerVCams; //0 High Elev | 1 Track | 2 Static Look At

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        _direction = new Vector3(0, 0, _vertical);
        _direction *= _moveSpeed * Time.deltaTime;
        _controller.Move(_direction);

        Vector3 rotation = new Vector3(0, _horizontal * _rotateSpeed * Time.deltaTime, 0);
        this.transform.Rotate(rotation);

        //Check for Right mouse click
        if (Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            switch (_currVCam)
            {
                //High Elev
                case 0:
                    SwitchTo3rdPersonCamera();
                    break;
                //Track
                case 1:
                    SwitchTo3rdPersonCamera();
                    break;
                //Static Look At
                case 2:
                    SwitchTo3rdPersonCamera();
                    break;
                //3rd Person
                case 3:
                    SwitchToOrbitalCamera();
                    break;
                //Orbital 
                case 4:
                    SwitchTo3rdPersonCamera();
                    break;
            }
        }
    }

    public void SwitchToOrbitalCamera()
    {
        _orbitalVCam.m_Priority = 150;
        _orbitalVCam.gameObject.SetActive(true);
        DisableRemainingVCams(4);
        //Disable3rdPersonVCam();
        _currVCam = 4;
    }

    public void SwitchTo3rdPersonCamera()
    {
        _3rdPersonVCam.m_Priority = 150;
        _3rdPersonVCam.gameObject.SetActive(true);
        DisableRemainingVCams(3);
        //DisableOrbitalVCam();
        _currVCam = 3;
    }

    public void SwitchToHighElevVCam()
    {
        _triggerVCams[0].m_Priority = 150;
        _triggerVCams[0].gameObject.SetActive(true);
        DisableRemainingVCams(0);
        _currVCam = 0;
    }

    public void SwitchToTrackVCam()
    {
        _triggerVCams[1].m_Priority = 150;
        _triggerVCams[1].gameObject.SetActive(true);
        DisableRemainingVCams(1);
        _currVCam = 1;
    }

    public void SwitchToStaticLookAtVCam()
    {
        _triggerVCams[2].m_Priority = 150;
        _triggerVCams[2].gameObject.SetActive(true);
        DisableRemainingVCams(2);
        _currVCam = 2;
    }

    private void DisableRemainingVCams(int CamInUse)
    {
        //CamInUse - 0 High Elev Cam | 1 Track Cam | 2 Static Look At Cam | 3 3rd Person Cam | 4 Orbital Cam
        switch (CamInUse)
        {
            case 0:
                DisableTrackVCam();
                DisableStaticLookAtVCam();
                Disable3rdPersonVCam();
                DisableOrbitalVCam();
                break;
            case 1:
                DisableHighElevVCam();
                DisableStaticLookAtVCam();
                Disable3rdPersonVCam();
                DisableOrbitalVCam();
                break;
            case 2:
                DisableHighElevVCam();
                DisableTrackVCam();
                Disable3rdPersonVCam();
                DisableOrbitalVCam();
                break;
            case 3:
                DisableHighElevVCam();
                DisableTrackVCam();
                DisableStaticLookAtVCam();
                DisableOrbitalVCam();
                break;
            case 4:
                DisableHighElevVCam();
                DisableTrackVCam();
                DisableStaticLookAtVCam();
                Disable3rdPersonVCam();
                break;
        }
    }

    private void DisableOrbitalVCam()
    {
        _orbitalVCam.m_Priority = 100;
        _orbitalVCam.gameObject.SetActive(false);
    }

    private void Disable3rdPersonVCam()
    {
        _3rdPersonVCam.m_Priority = 100;
        _3rdPersonVCam.gameObject.SetActive(false);
    }

    private void DisableHighElevVCam()
    {
        _triggerVCams[0].m_Priority = 100;
        _triggerVCams[0].gameObject.SetActive(false);
    }

    private void DisableTrackVCam()
    {
        _triggerVCams[1].m_Priority = 100;
        _triggerVCams[1].gameObject.SetActive(false);
    }

    private void DisableStaticLookAtVCam()
    {
        _triggerVCams[2].m_Priority = 100;
        _triggerVCams[2].gameObject.SetActive(false);
    }
}
