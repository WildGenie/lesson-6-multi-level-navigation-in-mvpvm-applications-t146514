using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using MvpvmNavigation.ViewModels;
using DevExpress.Mvvm;
using MvpvmNavigation.Model;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace MvpvmNavigation.Presenter {
    public class MainFormPresenter : IDisposable {
        PanelControl modulesPanel;
        MainFormViewModel viewModelCore;
        public MainFormPresenter(PanelControl modulesPanel, MainFormViewModel viewModel) {
            this.modulesPanel = modulesPanel;
            this.viewModelCore = viewModel;
            ViewModel.SelectedModuleTypeChanged += ViewModel_SelectedModuleTypeChanged;
        }
        public void Dispose() {
            ViewModel.SelectedModuleTypeChanged -= ViewModel_SelectedModuleTypeChanged;
        }
        public MainFormViewModel ViewModel {
            get { return viewModelCore; }
        }
        void ViewModel_SelectedModuleTypeChanged(object sender, System.EventArgs e) {
            RibbonForm mainForm = modulesPanel.FindForm() as RibbonForm;
            if (mainForm != null) {
                mainForm.Ribbon.UnMergeRibbon();
                if (mainForm.Ribbon.StatusBar != null)
                    mainForm.Ribbon.StatusBar.UnMergeStatusBar();
            }
            modulesPanel.Controls.Clear();
            Control module = ViewModel.GetModule(ViewModel.SelectedModuleType) as Control;
            ViewModelHelper.EnsureModuleViewModel(module, ViewModel);
            if (module != null) {
                module.Dock = DockStyle.Fill;
                modulesPanel.Controls.Add(module);
            }
            if (mainForm != null) {
                IRibbonModule ribbonModule = module as IRibbonModule;
                if (ribbonModule != null) {
                    mainForm.Ribbon.MergeRibbon(ribbonModule.Ribbon);
                    if (mainForm.Ribbon.StatusBar != null)
                        mainForm.Ribbon.StatusBar.MergeStatusBar(ribbonModule.Ribbon.StatusBar);
                }
            }
        }
    }
}
