using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageDectector : MonoBehaviour
{
    private Dictionary<Transform, IDamageable> _damageableObjects = new();
    private HashSet<int> _objectIdOnEnter = new();

    private event Action<IDamageable> OnEnterActionEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ProcessAction(other.transform, _objectIdOnEnter, ProcessEnterAction);
    }
    private void ProcessAction(Transform colTransform, HashSet<int> objectIdList, Action<IDamageable> action)
    {
        if (!this.enabled)
            return;
        if (colTransform == null)
            return;
        bool foundInCache = _damageableObjects.TryGetValue(colTransform, out var damageable);
        if (!foundInCache)
        {
            damageable = colTransform.GetComponent<IDamageable>();
            if (damageable != null)
                _damageableObjects.Add(colTransform, damageable);
        }

        if (damageable == null)
            return;

        int uniqueId = colTransform.GetInstanceID();

        if (objectIdList.Contains(uniqueId))
            return;
        
        objectIdList.Add(uniqueId);
        if (action != null)
            action(damageable);
    }

    private void ProcessEnterAction(IDamageable damageable)
    {
        OnEnterActionEvent?.Invoke(damageable);
    }

    private void LateUpdate()
    {
        if (_objectIdOnEnter.Count != 0)
            _objectIdOnEnter.Clear();
    }
}
