using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvpvmNavigation.Model;
using DevExpress.Mvvm;
using DevExpress.XtraNavBar;
using DevExpress.Mvvm.POCO;
using MvpvmNavigation.ViewModels;
using MvpvmNavigation.Presenter;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars;
using DevExpress.Utils;
using DevExpress.Utils.Animation;


namespace MvpvmNavigation {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm, ISupportTransitions {
        public Form1() {
            InitializeComponent();
            this.viewModelCore = ViewModelSource.Create<MainFormViewModel>();
            this.presenterCore = CreatePresenter();
            ViewModel.RegisterServices(this);
        }
        MainFormViewModel viewModelCore;
        public MainFormViewModel ViewModel {
            get { return viewModelCore; }
        }
        MainFormPresenter presenterCore;
        public MainFormPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual MainFormPresenter CreatePresenter() {
            return new MainFormPresenter(panelControl1, ViewModel);
        }
        protected override void OnClosed(EventArgs e) {
            Presenter.Dispose();
            base.OnClosed(e);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            ModuleType[] modules = new ModuleType[] { 
                ModuleType.ModuleA, ModuleType.ModuleB 
            };
            ViewModel.SelectedModuleType = modules[0];
            RegisterNavigationItems(navBarControl1, modules);
            RegisterNavigationMenuItems(barSubItem1, modules);
        }
        void RegisterNavigationItems(NavBarControl navBar, ModuleType[] modules) {
            NavBarGroup[] groups = new NavBarGroup[modules.Length];
            for(int i = 0; i < modules.Length; i++) {
                ModuleType moduleType = modules[i];
                NavBarGroup navGroup = new NavBarGroup();
                navGroup.Tag = modules[i];
                navGroup.Name = "navGroup" + ViewModel.GetName(moduleType);
                navGroup.Caption = ViewModel.GetCaption(moduleType);
                groups[i] = navGroup;
            }
            navBar.Groups.AddRange(groups);
        }
        void RegisterNavigationMenuItems(BarLinkContainerItem menuItem, ModuleType[] modules) {
            BarItem[] items = new BarItem[modules.Length];
            for(int i = 0; i < modules.Length; i++) {
                ModuleType moduleType = modules[i];
                BarCheckItem biModule = new BarCheckItem();
                biModule.Caption = ViewModel.GetCaption(moduleType);
                biModule.Name = "biModule" + ViewModel.GetName(moduleType);
                biModule.GroupIndex = 1;
                biModule.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => moduleType);
                items[i] = biModule;
            }
            menuItem.AddItems(items);
        }
        void officeNavigationBar1_RegisterItem(object sender, NavigationBarNavigationClientItemEventArgs e) {
            NavBarGroup navGroup = (NavBarGroup)e.NavigationItem;
            ModuleType moduleType = (ModuleType)navGroup.Tag;
            e.Item.Tag = moduleType;
            e.Item.Text = ViewModel.GetCaption(moduleType);
            e.Item.Name = "navItem" + ViewModel.GetName(moduleType);
            e.Item.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => moduleType);
        }

        #region ISupportTransitions Members
        void ISupportTransitions.StartTransition(bool forward, object waitParameter) {
            var transition = transitionManager1.Transitions[panelControl1];
            var animator = transition.TransitionType as DevExpress.Utils.Animation.SlideFadeTransition;
            animator.Parameters.EffectOptions = forward ? PushEffectOptions.FromRight : PushEffectOptions.FromLeft;
            if (waitParameter == null)
                transition.ShowWaitingIndicator = DefaultBoolean.False;
            else {
                transition.ShowWaitingIndicator = DefaultBoolean.True;
                transition.WaitingIndicatorProperties.Caption = ViewModel.GetCaption((ModuleType)waitParameter);
                transition.WaitingIndicatorProperties.Description = "Loading...";
                transition.WaitingIndicatorProperties.ContentMinSize = new System.Drawing.Size(160, 0);
            }
            transitionManager1.StartTransition(panelControl1);
        }
        void ISupportTransitions.EndTransition() {
            transitionManager1.EndTransition();
        }
        #endregion
    }
}
