﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Prism.IocContainer.Avalonia.Tests.Support.Mocks;
using Prism.IocContainer.Avalonia.Tests.Support.Mocks.ViewModels;
using Prism.IocContainer.Avalonia.Tests.Support.Mocks.Views;
using Prism.Mvvm;

namespace Prism.Unity.Wpf.Tests
{
    [TestClass]
    public class UnityViewModelLocatorFixture
    {
        [TestMethod]
        public void ShouldLocateViewModelAndResolveWithContainer()
        {
            var bootstrapper = new DefaultUnityBootstrapper();
            bootstrapper.Run();

            bootstrapper.BaseContainer.RegisterType<IService, MockService>();

            MockView view = new MockView();
            Assert.IsNull(view.DataContext);

            ViewModelLocator.SetAutoWireViewModel(view, true);
            Assert.IsNotNull(view.DataContext);
            Assert.IsInstanceOfType(view.DataContext,typeof(MockViewModel));

            Assert.IsNotNull(((MockViewModel)view.DataContext).MockService);
        }
    }
}
