using System.Collections.Generic;
using UnityEngine;

namespace Grabli
{
    public static class AppStoreEx
    {
        private static IDictionary<AppStore, ISet<RuntimePlatform>> platformsByStore;

        static AppStoreEx()
        {
            platformsByStore = new Dictionary<AppStore, ISet<RuntimePlatform>>();
            ISet<RuntimePlatform> android = new HashSet<RuntimePlatform>();
            android.Add(RuntimePlatform.Android);
            ISet<RuntimePlatform> ios = new HashSet<RuntimePlatform>();
            ios.Add(RuntimePlatform.IPhonePlayer);

            platformsByStore.Add(AppStore.AmazonAppStore, android);
            platformsByStore.Add(AppStore.AppleAppStore, ios);
            platformsByStore.Add(AppStore.GooglePlayMarket, android);
            platformsByStore.Add(AppStore.HuaweiAppMarket, android);
            platformsByStore.Add(AppStore.OperaMobileStore, android);
            platformsByStore.Add(AppStore.SamsungGalaxyStore, android);
            platformsByStore.Add(AppStore.Undefined, new HashSet<RuntimePlatform>());
            platformsByStore.Add(AppStore.XiaomiAppStore, android);
        }

        public static bool IsSupported(this AppStore store)
        { 
            switch(store)
            {
                case AppStore.Undefined: return false;
                case AppStore.GooglePlayMarket:
                    
#if GRABLI_STORE_SUPPORTED_GOOGLE_PLAY_MARKET
                    return true;
#else
                    return false;
#endif
#if GRABLI_STORE_SUPPORTED_AMAZON_APP_STORE
                case AppStore.AmazonAppStore: return true;
#endif
                case AppStore.AppleAppStore:
#if GRABLI_STORE_SUPPORTED_APPLE_APP_STORE
                    return true;
#else
                    return false
#endif
#if GRABLI_STORE_SUPPORTED_SAMSUNG_GALAXY_STORE
                case AppStore.SamsungGalaxyStore: return true;
#endif
#if GRABLI_STORE_SUPPORTED_HUAWEI_APP_MARKET
                case AppStore.HuaweiAppMarket: return true;
#endif
#if GRABLI_STORE_SUPPORTED_OPERA_MOBILE_STORE
                case AppStore.OperaMobileStore: return true;
#endif
#if GRABLIE_STORE_SUPPORTED_XIAOMI_APP_STORE
                case AppStore.XiaomiAppStore: return true;
#endif
                default: throw new System.NotImplementedException();
            }    
        }

        public static bool IsPlatformSupported(this AppStore store, RuntimePlatform platform)
        {
            return platformsByStore[store].Contains(platform);
        }
    }
}