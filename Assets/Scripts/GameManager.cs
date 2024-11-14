using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum MAP_TYPE
    {
        LIVE,
        DEATH,
    }
    public GameObject[] Maps;
    public MAP_TYPE CurrentMapType;

    public void HandleActiveMap(MAP_TYPE type)
    {
        CurrentMapType = type;
        Maps[0].SetActive(false);
        Maps[1].SetActive(false);
        Maps[(int)type].SetActive(true);
    }

    public void HandleLoadLevel(bool reload = false)
    {
        int levelIndex = reload ? SceneManager.GetActiveScene().buildIndex : SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(levelIndex);
    }

    public void HandleSwitchMap()
    {
        MAP_TYPE nextType = CurrentMapType == MAP_TYPE.LIVE ? MAP_TYPE.DEATH : MAP_TYPE.LIVE;
        HandleActiveMap(nextType);
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
         if(Maps.Length!=0) HandleActiveMap(MAP_TYPE.LIVE);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            HandleSwitchMap();
        }
    }
}
