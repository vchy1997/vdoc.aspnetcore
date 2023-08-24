# 适配器模式

## 示例代码

```csharp
var adaptee = new Adaptee();

var adapter = new Adapter(adaptee);

adapter.Process();

// 已存在不兼容的类
class Adaptee
{
    public void Execute()
    {
        Console.WriteLine("执行Adaptee");
    }
}

// 目标接口
interface ITarget
{
    void Process();
}

// 适配器
class Adapter : ITarget
{
    // VGA接口对象
    private Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    // 执行适配逻辑
    public void Process()
    {
        Console.WriteLine("Adapter适配器加工处理");

        _adaptee.Execte();
    }
}
```