using System;
using UnityEngine;

public static class Bootstrapper
{
    public static event Action OnBootstrapperInitialized;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        UnityEngine.Object.DontDestroyOnLoad(UnityEngine.Object.Instantiate(Resources.Load("Bootstrapper")));
        OnBootstrapperInitialized.Invoke();
    }
}
