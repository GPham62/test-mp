using UnityEngine;

namespace Utils
{
    public static class CustomUtils
    {
        /// <summary>
        /// Gets a "target" component within a particular branch (inside the hierarchy). The branch is defined by the "branch root object", which is also defined by the chosen 
        /// "branch root component". The returned component must come from a child of the "branch root object".
        /// </summary>
        /// <param name="callerComponent"></param>
        /// <param name="includeInactive">Include inactive objects?</param>
        /// <typeparam name="T1">Branch root component type.</typeparam>
        /// <typeparam name="T2">Target component type.</typeparam>
        /// <returns>The target component.</returns>
        public static T2 GetComponentInBranch<T1, T2>(this Component callerComponent, bool includeInactive = true)
            where T1 : Component where T2 : Component
        {
            T1[] rootComponents = callerComponent.transform.root.GetComponentsInChildren<T1>(includeInactive);

            if (rootComponents.Length == 0)
            {
#if UNITY_EDITOR
                Debug.LogWarning($"Root component: No objects found with {typeof(T1).Name} component");
#endif
                return null;
            }

            for (int i = 0; i < rootComponents.Length; i++)
            {
                T1 rootComponent = rootComponents[i];

                // Is the caller a child of this root?
                if (!callerComponent.transform.IsChildOf(rootComponent.transform) &&
                    !rootComponent.transform.IsChildOf(callerComponent.transform))
                    continue;

                T2 targetComponent = rootComponent.GetComponentInChildren<T2>(includeInactive);

                if (targetComponent == null)
                    continue;

                return targetComponent;
            }

            return null;
        }

        /// <summary>
        /// Gets a "target" component within a particular branch (inside the hierarchy). The branch is defined by the "branch root object", which is also defined by the chosen 
        /// "branch root component". The returned component must come from a child of the "branch root object".
        /// </summary>
        /// <param name="callerComponent"></param>
        /// <param name="includeInactive">Include inactive objects?</param>
        /// <typeparam name="T1">Target component type.</typeparam>	
        /// <returns>The target component.</returns>
        public static T1 GetComponentInBranch<T1>(this Component callerComponent, bool includeInactive = true)
            where T1 : Component
        {
            return callerComponent.GetComponentInBranch<T1, T1>(includeInactive);
        }
    }
}
