﻿using Common;
using UI;
using UI.NotificationsSystem;
using UI.WindowsSystem;
using UI.WindowsSystem.WindowTypes;
using UnityEngine;

namespace Startup.Initializers
{
    public class GameUIInitializer : IInitializer
    {
        public void Initialize()
        {
            var uiRootPrefab = Resources.Load<UIRoot>("UI/UIRoot");
            var uiRoot = Object.Instantiate(uiRootPrefab);
            GameContainer.Common.Register(uiRoot);
            
            var gameWindows = Resources.Load<GameWindows>("WindowsSystem/Game Windows");
            var windowsSystem = new WindowsSystem();
            windowsSystem.Initialize(gameWindows, uiRoot);
            GameContainer.Common.Register(windowsSystem);
            
            var loadingScreenPrefab = Resources.Load<LoadingScreen>("UI/LoadingScreen");
            var loadingScreen = Object.Instantiate(loadingScreenPrefab, uiRoot.OverlayParent);
            loadingScreen.Active = true;
            GameContainer.Common.Register(loadingScreen);

            var notificationsManagerPrefab = Resources.Load<NotificationsManager>("UI/NotificationsScreen");
            var notificationsManager = Object.Instantiate(notificationsManagerPrefab, uiRoot.NotificationsParent);
            GameContainer.Common.Register(notificationsManager);

            windowsSystem.GetWindow<MainMenu>();
        }

        public void Dispose()
        {
        }
    }
}