using UnityEngine;
using UnityEngine.AddressableAssets;
using ZBase.UnityScreenNavigator.Core.Screens;

public class UIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var windowOption = new ScreenOptions(ScreenType.screen_campaign.ToString(), false);
        var container = ScreenContainer.Find(UIConstant.Screens);
        container.PushAsync(windowOption);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public sealed class UIConstant
{
    public const string Screens = nameof(Screens);
    public const string Modals = nameof(Modals);
    public const string ActivitiesHub = nameof(ActivitiesHub);
    public const string Activities = nameof(Activities);
    public const string ModalPreview = nameof(ModalPreview);
    public const string ActivitiesNotification = nameof(ActivitiesNotification);
    public const string ActivityTutorial = nameof(ActivityTutorial);
    public const string ActivitySleepMode = nameof(ActivitySleepMode);
}

public enum ScreenType
{
    screen_campaign = 0,
}
