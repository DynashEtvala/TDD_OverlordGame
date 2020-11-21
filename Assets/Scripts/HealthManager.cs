using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthManager
{
    private static Dictionary<int, IHealth> HealthComponents = new Dictionary<int, IHealth>();

    public static void Initialize()
    {
        HealthComponents.Clear();
    }

    public static void AddToTable(IHealth health, Transform transform)
    {
        HealthComponents.Add(transform.GetInstanceID(), health);
    }

    public static IHealth GetFromTable(Transform transform)
    {
        HealthComponents.TryGetValue(transform.GetInstanceID(), out IHealth health);
        return health;
    }

    public static void RemoveFromTable(Transform transform)
    {
        HealthComponents.Remove(transform.GetInstanceID());
    }

    public static int GetHealthCount()
    {
        return HealthComponents.Count;
    }
}
