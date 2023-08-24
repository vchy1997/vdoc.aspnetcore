# 观察者模式

## 示例代码

``` csharp
// 创建主题
ConcreteSubject subject = new ConcreteSubject();

// 创建观察者
ConcreteObserver observer1 = new ConcreteObserver("观察者1");
ConcreteObserver observer2 = new ConcreteObserver("观察者2");
ConcreteObserver observer3 = new ConcreteObserver("观察者3");

// 添加观察者
subject.Attach(observer1);
subject.Attach(observer2);
subject.Attach(observer3);
// 通知观察者
subject.Notify();

// 移除观察者
subject.Detach(observer2);

// 通知观察者
subject.Notify();

// 观察者接口
public interface IObservable
{
    // 如果订阅更新，就会调用这个方法
    void Update(ISubject subject);
}

// 主题事件
public interface ISubject
{
    // 添加一个观察者
    void Attach(IObservable observer);

    // 移除一个观察者
    void Detach(IObservable observer);

    // 消息通知
    void Notify();
}

// 主题事件
public class ConcreteSubject : ISubject
{
    // 保存观察者列表
    private List<IObservable> _observer = new List<IObservable>();

    // 添加一个观察者
    public void Attach(IObservable observer)
    {
        _observer.Add(observer);
    }

    // 移除一个观察者
    public void Detach(IObservable observer)
    {
        _observer.Remove(observer);
    }

    // 消息通知
    public void Notify()
    {
        Console.WriteLine("=======================================");
        foreach (IObservable observer in _observer)
        {
            observer.Update(this);
        }
    }
}

// 观察者
public class ConcreteObserver : IObservable
{
    // 观察者名称
    private string _name;

    // 构造函数
    public ConcreteObserver(string name)
    {
        _name = name;
    }

    // 如果订阅更新，就会调用这个方法
    public void Update(ISubject subject)
    {
        Console.WriteLine($"观察者{_name}收到了消息通知");
    }
}
```