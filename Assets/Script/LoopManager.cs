using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LoopManager : SingletonMonoBehaviour<LoopManager>
{
    // パート上での経過時間
    [SerializeField]
    private float _LoopWaitTime = 0.0f;

    /// <summary>
    /// 現在のパート
    /// </summary>
    public int _CurrentPart = 0;

    //TODO: ループデータは事前に作ったデータリストを引っ張ってくるように修正
    public cLoopData _CurrentLoopData = new cLoopData();

    public enum State
    {
        Init,
        Instantiate,
        Instantiate_Wait,
        Init_Position,
        ActionStart,
        Wait,
        Finish,
    }

    /// <summary>
    /// 状態
    /// </summary>
    private State _State = State.Init;


    private Arbor.ParameterContainer _PT;


    // Start is called before the first frame update
    void Start()
    {
        _PT = GetComponent<Arbor.ParameterContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_State) 
        {
            case State.Init:
                {
                    _State = State.Instantiate;
                    break;
                }
            case State.Instantiate:
                {
                    //_WitnessInstance = Instantiate(WitnessPrefabList[0], Vector3.zero, Quaternion.identity);
                    _State = State.Instantiate_Wait;
                    break;
                }
            case State.Instantiate_Wait:
                {
                    //if (_WitnessInstance.activeSelf)
                    {
                        //var comp = _WitnessInstance.GetComponent<NavMeshController>();
                        //_Witnesses.Add(comp);

                        _State = State.Init_Position;
                    }
                    break;
                }
            case State.Init_Position:
                {
                    var currentLoop = _PT.GetInt("CurrentLoop");
                    WitnessManager.Instance.resetPartStartTransform(currentLoop);

                    // PLの座標もリセット
                    PlayerManager.Instance.resetPlayerPosition();

                    _State = State.ActionStart;
                    break;
                }
            case State.ActionStart:
                {
                    //foreach (var witness in _Witnesses)
                    //{
                    //    witness.enqueueActionState(new WitnessActionNavi(target.position));
                    //}

                    _State = State.Wait;
                    break;
                }
            case State.Wait:
                {
                    _LoopWaitTime += Time.deltaTime;
                    if(_LoopWaitTime >= _CurrentLoopData.getLoopPartTime())
                    {
                        bool success = WitnessManager.Instance.isAllWitnessPartActionSuccess();

                        if(success)
                        {
                            var currentLoop = _PT.GetInt("CurrentLoop");
                            currentLoop++;
                            _LoopWaitTime = 0.0f;
                            Debug.Log("アクション成功。次のパートに移行");

                            _PT.SetInt("CurrentLoop", currentLoop);

                            int partMax = 99;
                            if(partMax < currentLoop)
                            {
                                _State = State.Finish;
                                return;
                            }

                        }
                        else
                        {
                            // アクション完了してなかったらセットしなおし
                            _LoopWaitTime = 0.0f;

                            _State = State.Init_Position;

                            Debug.Log("アクション失敗。アクションループします");

                        }

                        // 再開させる
                        WitnessManager.Instance.retartThinkFSM();
                    }

                    break;
                }
            case State.Finish:
                {
                    Debug.Log("アクション完了");
                    break;
                }
        }
    }

    /// <summary>
    /// 指定したフラグを立てる
    /// </summary>
    /// <param name="flag"></param>
    public void setActionFlag(bool flag)
    {
        // TODO:フラグIDを指定できるようにする
        _PT.SetBool("NextFlag", flag);
    }
}
