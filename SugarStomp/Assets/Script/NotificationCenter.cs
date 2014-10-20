// NotificationCenter from http://wiki.unity3d.com/index.php?title=CSharpNotificationCenter

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class NotificationCenter : MonoBehaviour {

  private static NotificationCenter _defaultCenter;
  public static NotificationCenter DefaultCenter {
    get {
      if (!_defaultCenter) {
	GameObject notificationObject = new GameObject("Default Notification Center");
	_defaultCenter = notificationObject.AddComponent<NotificationCenter> ();
      }
      return _defaultCenter; 
    }
  }
 
  private Hashtable _notifications = new Hashtable();
 
  public void AddObserver(Component observer, string name) {
    if (string.IsNullOrEmpty(name)) {
      Debug.Log("Null name specified for notification in AddObserver.");
      return;
    }

    if (_notifications[name] == null) {
      _notifications[name] = new List<Component>();
    }
    List<Component> notifyList = (List<Component>)_notifications[name];
    if (!notifyList.Contains(observer)) {
	notifyList.Add(observer);
    }
  }
 
  public void RemoveObserver(Component observer, string name) {
    List<Component> notifyList = (List<Component>)_notifications[name];
    if (notifyList != null) {
      if (notifyList.Contains(observer)) {
	notifyList.Remove(observer);
      }
      if (notifyList.Count == 0) {
	_notifications.Remove(name);
      }
    }
  }
 
  public void PostNotification(Component sender, string name) {
    PostNotification(sender, name, null);
  }

  public void PostNotification(Component sender, string name, Hashtable data) {
    PostNotification(new Notification(sender, name, data));
  }

  public void PostNotification(Notification notification) {
    if (string.IsNullOrEmpty(notification.Name)) {
      Debug.Log("Null name sent to PostNotification.");
      return;
    }

    List<Component> notifyList = (List<Component>)_notifications[notification.Name];
    if (notifyList == null) {
      Debug.Log("Notify list not found in PostNotification: " + notification.Name);
      return;
    }
 
    List<Component> observersToRemove = new List<Component>();
    foreach (Component observer in notifyList) {
      if (!observer) {
	observersToRemove.Add(observer);
      } else {
	observer.SendMessage(notification.Name, notification, SendMessageOptions.DontRequireReceiver);
      }
    }
 
    foreach (Component observer in observersToRemove) {
      notifyList.Remove(observer);
    }
  }
 
  public class Notification {
    public Component Sender;
    public string Name;
    public Hashtable Data;

    public Notification(Component sender, string name) {
      Sender = sender; Name = name; Data = null;
    }

    public Notification(Component sender, string name, Hashtable data) {
      Sender = sender; Name = name; Data = data;
    }
  }
}
