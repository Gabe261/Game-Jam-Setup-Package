using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StartingMenu : MonoBehaviour
{
    private VisualElement root;
    private Button button1, button2;
    private Label label;
    
    
    [SerializeField] private string titleText, button1Text, button2Text;
    
    public UnityEvent OnButton1Clicked;
    public UnityEvent OnButton2Clicked;
    
    private void Start()
    {
        OnButton1Clicked ??= new UnityEvent();
        OnButton2Clicked ??= new UnityEvent();
        
        root = GetComponent<UIDocument>().rootVisualElement;
        
        button1 = root.Q<Button>("Button1");
        button2 = root.Q<Button>("Button2");
        label = root.Q<Label>("TitleText");
        
        button1.clicked += () => { OnButton1Clicked?.Invoke(); };
        button2.clicked += () => { OnButton2Clicked?.Invoke(); };
        
        label.text = titleText;
        button1.text = button1Text;
        button2.text = button2Text;
    }

    public void Hide()
    {
        root.style.display = DisplayStyle.None;
    }

    public void Show()
    {
        root.style.display = DisplayStyle.Flex;
    }
}