using UnityEngine;
using UnityEngine.UI;

public class ScreenManagement : MonoBehaviour
{
    public static ScreenManagement instance;

    [SerializeField]
    private Image screenImage;

    [Header("Screen Image Sprites")]
    [SerializeField]
    private Sprite screenOnSprite;

    [SerializeField]
    private Sprite screenOffSprite;

    private int connectionId = -1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Server.instance.clientDisconnectionEvent += OnScreenDisconnected;
    }

    public void OnScreenConnected(int id)
    {
        SetConnectionId(id);
        screenImage.sprite = screenOnSprite;
        InfoTextView.instance.SetInfo("Established connection with the screen APP");
    }

    public void OnScreenDisconnected(int id)
    {
        if (id == connectionId)
        {
            SetConnectionId(-1);
            screenImage.sprite = screenOffSprite;
            InfoTextView.instance.SetInfo("Connection lost with the screen APP");
        }
    }

    public void SetConnectionId(int id)
    {
        connectionId = id;
    }

    public int GetScreenConnectionId()
    {
        return connectionId;
    }

    public bool screenConnected()
    {
        return connectionId != -1;
    }
}