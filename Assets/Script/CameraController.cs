using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public enum CameraState
    {

        Wait,
        Follow,
    }

    /// <summary>
    /// 追従対象
    /// </summary>
    public GameObject _FollowObj;


    /// <summary>
    /// カメラ位置のオフセット
    /// </summary>
    [SerializeField]
    private Vector3 _PositionOffset = new Vector3(0.0f, 3.0f, -6.0f);

    private Quaternion _RotationX;
    private Quaternion _RotationY;

    [SerializeField]
    private float _RotationSpeed = 3.0f;

    public void setFollowObject(GameObject obj)
    {
        _FollowObj = obj;
    }

    public Quaternion getRotationX()
    {
        return _RotationX;
    }

    // Start is called before the first frame update
    void Start()
    {
        _RotationX = _RotationY = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        updateInput();
    }

    private void LateUpdate()
    {
        updateRotation();
        updatePosition();
    }

    private void updateInput()
    {
       // float rotX = Input.GetAxis("CameraX") * _RotationSpeed;
       // float rotY = Input.GetAxis("CameraY") * _RotationSpeed;

        //_RotationX *= Quaternion.Euler(0.0f, rotX, 0.0f);

    }

    private void updatePosition()
    {
        if (_FollowObj == null)
        {
            return;
        }

        Vector3 followPosition = _FollowObj.transform.position;
        Vector3 posisionVec = _PositionOffset;

        transform.position = followPosition + (transform.rotation * posisionVec);

    }

    private void updateRotation()
    {
        transform.rotation = _RotationX * _RotationY;

    }
}
