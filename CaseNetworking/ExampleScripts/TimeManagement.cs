using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour
{
    public static TimeManagement instance;

    [Header("Panels")]
    [SerializeField]
    private GameObject addTimePanel;

    [SerializeField]
    private GameObject removeTimePanel;

    [Header("Texts")]
    public TextMeshProUGUI countDownText;

    public Timer countDown;

    [Header("Buttons")]
    [SerializeField]
    private Button addTimeButton;

    [SerializeField]
    private Button removeTimeButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        countDown = new Timer(30, () => Debug.Log("TimeUp"), () => OnCountDownUpdate());
    }

    private void OnCountDownUpdate()
    {
        countDownText.text = countDown.CurrentTimeFormat();
    }

    public void StartCountDown()
    {
        StopAllCoroutines();
        StartCoroutine(countDown.StartCountDown());
    }

    public void OnClickAddTime()
    {
        if (!OperationPanelLock.operationPanelOn)
        {
            addTimePanel.SetActive(true);
            OperationPanelLock.OnOpen();
        }
    }

    public void OnClickRemoveTime()
    {
        if (!OperationPanelLock.operationPanelOn)
        {
            removeTimePanel.SetActive(true);
            OperationPanelLock.OnOpen();
        }
    }

    public void SetTimeManagementToNotInteractable()
    {
        addTimeButton.interactable = false;
        removeTimeButton.interactable = false;
    }

    public void SetTimeManagementToInteractable()
    {
        addTimeButton.interactable = true;
        removeTimeButton.interactable = true;
    }
}