using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : SingletonMonoBehaviour<LoopManager>
{
    public class Entry
    {
        public Entry(int id)
        {
            _Id = id;
        }
        /// <summary>
        /// �G���g��ID
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        /// <summary>
        /// ���̃Z�b�g������������
        /// </summary>
        private bool _IsFinish;
        public bool IsFinish { get { return _IsFinish; } set { _IsFinish = value; } }
    }

    /// <summary>
    /// �i�s�Ǘ��̃��X�g
    /// </summary>
    private List<Entry> Entries = new List<Entry>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �G���g���̒ǉ�
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
    /// �G���g���I���o�^
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
    /// �G���g���̃��t���b�V���i�G���g���̏I���t���O�����Z�b�g
    /// </summary>
    public void refreshEntry()
    {
        foreach (var entry in Entries)
        {
            entry.IsFinish = false;
        }
    }
}
