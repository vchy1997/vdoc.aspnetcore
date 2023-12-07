# 源码解析

## 源码目录结构

github地址:https://github.com/dotnet/runtime
根路径:src\libraries\

* Microsoft.Extensions.DependencyInjection:(默认实现类)
* Microsoft.Extensions.DependencyInjection.Abstractions:(抽象类)
    * src
        * IServiceCollection.cs:(服务集合管理接口)
        * IServiceScope.cs:(服务作用域接口)
        * IServiceScopeFactory.cs:(服务作用域工厂接口)
        * ServiceCollection.cs:
            * 说明:定义依赖注入类型管理集合
            * 作用:用于管理注册服务基础信息
        * ServiceCollectionServiceExtensions.cs:
            * 说明:定义依赖注入类型管理集合扩展方法
            * 作用:用于注册不同生命周期的服务
        * ServiceDescriptor.cs:
            * 说明:定义服务描述信息
            * 作用:用于记录服务基础信息
        * ServiceLifetime.cs
            * 说明:定义服务生命周期枚举
            * 作用:用于ServiceDescriptor标识服务生命周期
        * ServiceProviderServiceExtensions
            * 说明:定义IServiceProvider扩展方法
            * 作用:用于获取服务实例对象
