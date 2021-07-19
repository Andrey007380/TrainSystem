using Common.Enums;

namespace Common.Delegates
{
    // <summary> Делегат события изменения списка. </summary> 
    public delegate void ActioListHandler<T>(object sender, ActionListEnum action, T item);
}
