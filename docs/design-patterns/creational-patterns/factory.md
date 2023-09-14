# 工厂模式

## 说明

工厂模式是一种创建型设计模式，它提供了一种创建对象的最佳方式。

## 适用场景

当你在编写代码的过程中， 如果无法预知对象确切类别及其依赖关系时， 可使用工厂方法。

工厂方法将创建产品的代码与实际使用产品的代码分离， 从而能在不影响其他代码的情况下扩展产品创建部分代码。

例如， 如果需要向应用中添加一种新产品， 你只需要开发新的创建者子类， 然后重写其工厂方法即可。

如果你希望用户能扩展你软件库或框架的内部组件， 可使用工厂方法。

## 工厂方法模式优缺点

优点

- 你可以避免创建者和具体产品之间的紧密耦合。
- 单一职责原则。 你可以将产品创建代码放在程序的单一位置， 从而使得代码更容易维护。
- 开闭原则。 无需更改现有客户端代码， 你就可以在程序中引入新的产品类型。

缺点

- 应用工厂方法模式需要引入许多新的子类， 代码可能会因此变得更复杂。 最好的情况是将该模式引入创建者类的现有层次结构中。

## 示例代码

```csharp
// 运行代码
var audiCarFactory = new AudiCarFactory();
audiCarFactory.Show();

var bmwCarFactory = new BmwCarFactory();
bmwCar.Show();

// 定义汽车接口
public interface ICar
{
    void Run();
}

// 定义汽车工厂抽象类
public abstract class CarFactory
{
    // 工厂方法,返回一个汽车
    public abstract ICar Factory();

    public string Show()
    {
        var car = Factory();
        car.Run();
    }
}

// 定义奥迪汽车
public class AudiCar : ICar
{
    public void Run() => Console.WriteLine("奥迪汽车启动了");
}

// 定义奥迪汽车工厂
public class AudiCarFactory : CarFactory
{
    public override ICar CreateCar() => new AudiCar();
}

// 定义宝马汽车
public class BmwCar : ICar
{
    public void Run() =>Console.WriteLine("宝马汽车启动了");
}

// 定义宝马汽车工厂
public class BmwCarFactory : CarFactory
{
    public override ICar CreateCar() => new BmwCar();
}
```
