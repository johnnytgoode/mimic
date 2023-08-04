using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{

    /// <summary>
    /// プレイヤーコントローラ
    /// </summary>
    private CharacterController _CharacterCtrl;

    /// <summary>
    /// カメラ起点移動用回転量参照
    /// </summary>
    private CameraController _CameraCtrl;

    /// <summary>
    /// インプット
    /// </summary>
    private PlayerInput _Input;

    /// <summary>
    /// 移動速度
    /// </summary>
    private Vector3 _Velocity;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float _MoveSpeed = 6.0f;

    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField]
    private float _RotSpeed = 0.5f;

    [SerializeField]
    private float _Gravity = -10.0f;

    [SerializeField]
    private float _JumpSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        _CharacterCtrl = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        // 追従カメラのセットアップ
        var cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        _CameraCtrl = cameraObj.GetComponent<CameraController>();
        _CameraCtrl.setFollowObject(this.gameObject);

        _Input = gameObject.GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        updateMoveInput();
    }

    private void LateUpdate()
    {
        updatePosition();
        updateRotation();
    }


    private void updateMoveInput()
    {
        var input = _Input.currentActionMap["Move"].ReadValue<Vector2>();
        float h = input.x;
        float v = input.y;

        _Velocity.x = h;
        _Velocity.z = v;

        if (_CharacterCtrl.isGrounded)
        {
            print("isOnGround");

            // CharacterController.isGroundedが安定しない問題の解決策
            _Velocity.y = -_CharacterCtrl.stepOffset / Time.deltaTime; ;

            //if (Input.GetButtonDown("Jump"))
            //{
            //    _Velocity.y = 0.0f;
            //    _Velocity.y += _JumpSpeed;
            //}
        }
        else
        {
            _Velocity.y += _Gravity * Time.deltaTime;
            print("isOnAir");
        }
    }

    private void updateRotation()
    {
        // カメラの回転に合わせた向き回転
        Vector3 dir = _Velocity;
        dir.y = 0.0f;

        if (dir.magnitude > 0.0f)
        {
           Quaternion target = Quaternion.LookRotation(_CameraCtrl.getRotationX() * dir);

           transform.rotation = Quaternion.Slerp(transform.rotation, target, _RotSpeed);
        }
    }

    private void updatePosition()
    {
        _Velocity.x *= _MoveSpeed;
        _Velocity.z *= _MoveSpeed;

        _CharacterCtrl.Move(_CameraCtrl.getRotationX() * _Velocity * Time.deltaTime);
    }
}
