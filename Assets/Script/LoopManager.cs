using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LoopManager : SingletonMonoBehaviour<LoopManager>
{
    [SerializeField]
    private List<GameObject> WitnessPrefabList = new List<GameObject>();

    GameObject _WitnessInstance = null;

    public Transform target;

    [SerializeField]
    private float _LoopWaitTimerMax = 3.0f;

    private float _LoopWaitTime = 0.0f;



    public class Entry
    {
        public Entry(int id)
        {
            _Id = id;
        }
        /// <summary>
        /// エントリID
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// そのセットを完了したか
        /// </summary>
        private bool _IsFinish;
        public bool IsFinish { get { return _IsFinish; } set { _IsFinish = value; } }
    }

    /// <summary>
    /// 進行管理のリスト
    /// </summary>
    private List<Entry> Entries = new List<Entry>();


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

    private State _State = State.Init;

    /// <summary>
    /// 事件に関与してる参考人たち（犯人含む）
    /// </summary>
    private List<NavMeshController> _Witnesses = new List<NavMeshController>();

    public class WitnessSetData
    {
        /// <summary>
        /// そのセットの開始位置
        /// </summary>
        private Vector3 _StartPosition = new Vector3();
        public Vector3 StartPosition => _StartPosition;

        /// <summary>
        /// 行動する本人自身のポインタ
        /// </summary>
        private Witness _Witness;

        bool _IsFinish = false;

    }

    public class WitnessAction
    {
        public enum WitnessActionType
        {
            Navi,
            Motion,
        }

        private WitnessActionType _ActionType;
        public WitnessActionType ActionType => _ActionType;
    }

    public class WitnessActionNavi : WitnessAction
    {
        public WitnessActionNavi(Vector3 pos)
        {
            _TargetPosition = pos;
        }

        private Vector3 _TargetPosition;
        public Vector3 TargetPosition => _TargetPosition;

    }

    // Start is called before the first frame update
    void Start()
    {
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
                    _WitnessInstance = Instantiate(WitnessPrefabList[0], Vector3.zero, Quaternion.identity);
                    _State = State.Instantiate_Wait;
                    break;
                }
            case State.Instantiate_Wait:
                {
                    if (_WitnessInstance.activeSelf)
                    {
                        var comp = _WitnessInstance.GetComponent<NavMeshController>();
                        _Witnesses.Add(comp);

                        _State = State.Init_Position;
                    }
                    break;
                }
            case State.Init_Position:
                {
                    foreach (var witness in _Witnesses)
                    {
                        Vector3 pos = new Vector3(2.86f, -0.04f, 10.04f);
                        witness.setTransform(pos, Quaternion.identity);
                    }
                    _State = State.ActionStart;
                    break;
                }
            case State.ActionStart:
                {
                    foreach (var witness in _Witnesses)
                    {
                        witness.enqueueActionState(new WitnessActionNavi(target.position));
                    }

                    _State = State.Wait;
                    break;
                }
            case State.Wait:
                {
                    _LoopWaitTime += Time.deltaTime;
                    if(_LoopWaitTime >= _LoopWaitTimerMax)
                    {
                        foreach(var witness in  _Witnesses)
                        {
                            if(witness.IsActionEnd == false)
                            {
                                // アクション完了してなかったらセットしなおし
                                _LoopWaitTime = 0.0f;

                                _State = State.Init_Position;
                                Debug.Log("アクションループ");

                                return ;
                            }
                        }

                        // アクション完了してなかったらセットしなおし
                        _State = State.Finish;
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
    /// エントリの追加
    /// </summary>
    /// <param name="id"></param>
    public void addEntry(int id)
    {
        if (Entries.Exists(x => x.Id == id))
        {
            print("");
            return;
        }

        Entries.Add(new Entry(id));
    }

    /// <summary>
    /// エントリ終了登録
    /// </summary>
    /// <param name="id"></param>
    public void finishEntry(int id)
    {
        foreach(var entry in Entries)
        {
            if(entry.Id == id)
            {
                entry.IsFinish = true;
                return;
            }
        }

    }

    /// <summary>
    /// エントリのリフレッシュ（エントリの終了フラグをリセット
    /// </summary>
    public void refreshEntry()
    {
        foreach (var entry in Entries)
        {
            entry.IsFinish = false;
        }
    }
}
