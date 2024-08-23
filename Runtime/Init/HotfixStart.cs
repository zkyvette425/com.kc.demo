
using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace KC
{
    public static class HotfixStart 
    {
        public static void Start()
        {
            Debug.Log("进入热更");

            Init().Forget();
        }

        private static async UniTaskVoid Init()
        {
            await YooAssets.LoadSceneAsync("Assets/com.kc.demo/Bundles/Scene/Entry").ToUniTask();
            await RootHelper.Create(RootType.Init);
        }
    }
}

