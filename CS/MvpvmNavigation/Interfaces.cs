using DevExpress.XtraBars.Ribbon;

namespace MvpvmNavigation {
    public interface IRibbonModule {
        RibbonControl Ribbon { get; }
    }
    public interface ISupportTransitions {
        void StartTransition(bool forward, object waitParameter);
        void EndTransition();
    }
    public interface ISupportViewModel {
        object ViewModel { get; }
    }
}