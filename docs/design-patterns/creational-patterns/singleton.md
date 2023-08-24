# 单例模式

## 说明

单例模式是一种创建型设计模式， 让你能够保证一个类只有一个实例， 并提供一个访问该实例的全局节点。

!!! 问题

    单例模式同时解决了两个问题， 所以违反了单一职责原则：

    保证一个类只有一个实例。 为什么会有人想要控制一个类所拥有的实例数量？ 最常见的原因是控制某些共享资源 （例如数据库或文件） 的访问权限。

    它的运作方式是这样的： 如果你创建了一个对象， 同时过一会儿后你决定再创建一个新对象， 此时你会获得之前已创建的对象， 而不是一个新对象。

    注意， 普通构造函数无法实现上述行为， 因为构造函数的设计决定了它必须总是返回一个新对象。

    为该实例提供一个全局访问节点。 还记得用过的那些存储重要对象的全局变量吗？ 它们在使用上十分方便， 但同时也非常不安全， 因为任何代码都有可能覆盖掉那些变量的内容， 从而引发程序崩溃。

    和全局变量一样， 单例模式也允许在程序的任何地方访问特定对象。 但是它可以保护该实例不被其他代码覆盖。

    还有一点： 你不会希望解决同一个问题的代码分散在程序各处的。 因此更好的方式是将其放在同一个类中， 特别是当其他代码已经依赖这个类时更应该如此。

如今， 单例模式已经变得非常流行， 以至于人们会将只解决上文描述中任意一个问题的东西称为单例。

## 解决方案

所有单例的实现都包含以下两个相同的步骤：

- 将默认构造函数设为私有， 防止其他对象使用单例类的 new 运算符。
- 新建一个静态构建方法作为构造函数。 该函数会 “偷偷” 调用私有构造函数来创建对象， 并将其保存在一个静态成员变量中。 此后所有对于该函数的调用都将返回这一缓存对象。

如果你的代码能够访问单例类， 那它就能调用单例类的静态方法。 无论何时调用该方法， 它总是会返回相同的对象。

## 示例代码

=== "基础单例"

    ```csharp
    // 密封类,是为了防止被继承
    public sealed class Singleton
    (
        // 定义私有方法,保证无法new实现
        private Singleton(){}

        // 单例对象
        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            // 使用 ??= 运算符,如果_instance为空,则实例化
            _instance ??= new Singleton();

            return _instance;
        }
    )
    ```

=== "线程安全单例"

    ```csharp
    // 密封类,是为了防止被继承
    public sealed class Singleton
    (
        private Singleton(){}

        private static Singleton _instance;

        // 使用lock锁,保证线程安全
        private static readonly object _lock = new object();

        public static Singleton GetInstance()
        {
            // 使用双重锁定,保证线程安全
            if(_instance == null)
            {
                lock(_lock)
                {
                    _instance ??= new Singleton();
                }
            }

            return _instance;
        }
    )
    ```

=== "Lazy<T>惰性加载并且线程安全"

    ```csharp
    // 密封类,是为了防止被继承
    public sealed class Singleton
    (
        private Singleton(){}

        // 使用Lazy<T>类,保证惰性加载
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton GetInstance()
        {
            return _instance.Value;
        }
    )
    ```


