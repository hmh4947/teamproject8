
public interface IBaseState<T>
{
    void OperateEnter(T sender);
    void OperateUpdate(T sender);   
    void OperateExit(T sender); 

}
