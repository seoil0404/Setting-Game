using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    [SerializeField] private TetrisSetting SettingData;
    [SerializeField] private TextMeshProUGUI m_lineNumText;
    [SerializeField] private GameObject m_clearUi;

    public GameObject[] Tetris;
    public int m_deleteLineNum;
    [SerializeField] private AudioSource m_clearSound;
    [SerializeField] private AudioSource m_getPointSound;
    [SerializeField] private AudioSource m_dropSound;
    [SerializeField] private AudioSource m_bgm;
    bool clear = false;

    public static Spawn Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void Start()
    {
        NewTetris();
        m_bgm.Play();

    }

    public void NewTetris()
    {
        if (SettingData.IsMinoRandom)
            Instantiate(Tetris[Random.Range(0, Tetris.Length)], transform.position, Quaternion.identity);
        else
            Instantiate(Tetris[0], transform.position, Quaternion.identity);
    }

    private void LineNumUiUpdate()
    {
        m_lineNumText.text = m_deleteLineNum.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("TetrisScene");
    }

    public void Clear()
    {
        if(m_deleteLineNum <= 0 && !clear)
        {
        m_clearUi.SetActive(true);
            clear = true;
            SoundPlay("clear");
        }
    }

    public void ClearUi()
    {
        SceneManager.LoadScene("PlatformScene");
    }

    public void SoundPlay(string name)
    {
        m_clearSound.volume = SettingData.EffectSoundScale / 10;
        m_getPointSound.volume = SettingData.EffectSoundScale / 10;
        m_dropSound.volume = SettingData.EffectSoundScale / 10;
        switch (name)
        {
            case "drop": m_dropSound.Play(); break;
            case "getPoint": m_getPointSound.Play(); break;
            case "clear": m_clearSound.Play(); break;
        }
    }

    void Update()
    {
        LineNumUiUpdate();
        Clear();
        m_bgm.volume = SettingData.BackGroundMusicScale / 10;

    }
}