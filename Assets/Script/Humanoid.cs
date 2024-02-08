using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Humanoid : MonoBehaviour
{

    /// <summary>
    /// キャラのID。
    /// </summary>
    [SerializeField]  
    protected int _Id;
    public int Id => _Id;

    protected Animator _animator;

    // animation IDs
    protected int _animIDSpeed;
    protected int _animIDGrounded;
    protected int _animIDJump;
    protected int _animIDFreeFall;
    protected int _animIDMotionSpeed;

    protected bool _hasAnimator;

    protected CharacterController _controller;

    /// <summary>
    /// ループリセット時の戻り先（rotが必要になったら作る）
    /// </summary>
    protected Vector3[] _PartStartPosList;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);

        AssignAnimationIDs();

        _controller = GetComponent<CharacterController>();

        _PartStartPosList = new Vector3[5];

        _PartStartPosList[0] = transform.localPosition;

    }

    public AudioClip LandingAudioClip;
    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;


    // Update is called once per frame
    void Update()
    {
        
    }

    protected void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    protected void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
        }
    }

    protected void OnLand(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(_controller.center), FootstepAudioVolume);
        }
    }


    /// <summary>
    /// 座標セット
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="quat"></param>
    public virtual void setTransform(Vector3 pos, Quaternion quat)
    {
        transform.localPosition = pos;
        transform.localRotation = quat;
    }

    /// <summary>
    /// パート開始位置に移動
    /// </summary>
    public virtual void resetPartTransform(int partNo)
    {
        Debug.Log("PLの位置をリセット");
        transform.localPosition = _PartStartPosList[partNo];
    }

    /// <summary>
    /// パート開始位置設定
    /// </summary>
    /// <param name="partNo"></param>
    /// <param name="pos"></param>
    public virtual void setPartStartPos(int partNo)
    {
        _PartStartPosList[partNo] = transform.localPosition;
    }


    public virtual void OnTriggerStay(Collider other)
    {
        Debug.Log("子リジョンヒット");

    }
}
