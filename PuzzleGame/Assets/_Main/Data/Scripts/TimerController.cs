using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public static class SceneLoaderParams
{
    public static string mainScene;
    public static float timeSet;
    public static float beforeTimeFinish;

}
public class TimerController : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] public bool isMainLevel = true;
    [SerializeField] private float _time;
    private float _currentTime;
    [SerializeField] public float beforeTimeEnds;
    
    
    [Header("UI")]
    [SerializeField] private TMP_Text _timeText;

    [Header("Event")] 
    public UnityEvent onBeforeTimeEnds;

    private void Start()
    { 
        _currentTime = _time;
        if (isMainLevel)
        {
            SceneLoaderParams.mainScene = SceneManager.GetActiveScene().name;
            SceneLoaderParams.beforeTimeFinish = beforeTimeEnds;
            _currentTime = _time;
        } 
        else
            _currentTime = SceneLoaderParams.timeSet;
    }

    void Update()
    {
        DisplayTime(ref _currentTime);
        ChangeTextColor(Color.yellow, _time/3);
        ChangeTextColor(Color.red, _time/9);
        BeforeItEnds();
        EndOfTimer();
    }

    private void DisplayTime(ref float currentTime)
    {
        currentTime = Mathf.Abs(_currentTime - Time.deltaTime);
        
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void ChangeTextColor(in Color color, in float time)
    {
        if (_currentTime <= time)
            _timeText.color = color;
    }

    private void EndOfTimer()
    {
        if (_currentTime <= 0.5f)
        {
            _currentTime = 0;
            SceneManager.LoadScene(SceneLoaderParams.mainScene);
        }
    }

    private void BeforeItEnds()
    {
        if (_currentTime <= beforeTimeEnds)
        {
            onBeforeTimeEnds.Invoke();
        }
    }

}

