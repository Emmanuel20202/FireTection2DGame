using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using Unity.Notifications.Android;

public class NotificationManagerScripts : MonoBehaviour
{
    private List<string> tipsList = new List<string>();

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }

        // Retrieve the fire safety tips from PlayerPrefs
        /*tipsList.Add(PlayerPrefs.GetString("TipsH1"));
        tipsList.Add(PlayerPrefs.GetString("TipsH2"));
        tipsList.Add(PlayerPrefs.GetString("TipsH3"));
        tipsList.Add(PlayerPrefs.GetString("TipsH4"));
        tipsList.Add(PlayerPrefs.GetString("TipsH5"));
        tipsList.Add(PlayerPrefs.GetString("TipsH6"));
        tipsList.Add(PlayerPrefs.GetString("TipsH7"));
        tipsList.Add(PlayerPrefs.GetString("TipsH8"));*/

        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB1")))
            tipsList.Add(PlayerPrefs.GetString("TipsB1"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB2")))
            tipsList.Add(PlayerPrefs.GetString("TipsB2"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB3")))
            tipsList.Add(PlayerPrefs.GetString("TipsB3"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB4")))
            tipsList.Add(PlayerPrefs.GetString("TipsB4"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB5")))
            tipsList.Add(PlayerPrefs.GetString("TipsB5"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB6")))
            tipsList.Add(PlayerPrefs.GetString("TipsB6"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB7")))
            tipsList.Add(PlayerPrefs.GetString("TipsB7"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsB8")))
            tipsList.Add(PlayerPrefs.GetString("TipsB8"));

        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH1")))
            tipsList.Add(PlayerPrefs.GetString("TipsH1"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH2")))
            tipsList.Add(PlayerPrefs.GetString("TipsH2"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH3")))
            tipsList.Add(PlayerPrefs.GetString("TipsH3"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH4")))
            tipsList.Add(PlayerPrefs.GetString("TipsH4"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH5")))
            tipsList.Add(PlayerPrefs.GetString("TipsH5"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH6")))
            tipsList.Add(PlayerPrefs.GetString("TipsH6"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH7")))
            tipsList.Add(PlayerPrefs.GetString("TipsH7"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsH8")))
            tipsList.Add(PlayerPrefs.GetString("TipsH8"));

        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS1")))
            tipsList.Add(PlayerPrefs.GetString("TipsS1"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS2")))
            tipsList.Add(PlayerPrefs.GetString("TipsS2"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS3")))
            tipsList.Add(PlayerPrefs.GetString("TipsS3"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS4")))
            tipsList.Add(PlayerPrefs.GetString("TipsS4"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS5")))
            tipsList.Add(PlayerPrefs.GetString("TipsS5"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS6")))
            tipsList.Add(PlayerPrefs.GetString("TipsS6"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS7")))
            tipsList.Add(PlayerPrefs.GetString("TipsS7"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("TipsS8")))
            tipsList.Add(PlayerPrefs.GetString("TipsS8"));


        InvokeRepeating("CreateRandomNotification", 5f, 5f);
    }

    private void CreateRandomNotification()
    {
        if (tipsList.Count == 0)
        {
            Debug.LogWarning("The tips list is empty!");
            return;
        }

        // Pick a random tip from the list
        string message = tipsList[Random.Range(0, tipsList.Count)];

        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Channel Name",
            Importance = Importance.High,
            Description = "Channel Description"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "FIRE SAFETY TIPS -(BFP SJC #09254530777)",
            Text = message,
            SmallIcon = "small_icon",
            FireTime = System.DateTime.Now.AddSeconds(10)
        };

        int notificationId = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        Debug.Log("Notification ID: " + notificationId);
    }
}
