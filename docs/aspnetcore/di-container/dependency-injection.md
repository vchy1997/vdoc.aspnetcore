# dependency-injection.md

ASP.NET Core 支持依赖关系注入 (DI) 软件设计模式，这是一种在类及其依赖关系之间实现控制反转 (IoC) 的技术。

## 流程

向容器对象注册服务 -> 容器对象管理和创建服务实例 -> 服务实例注入到需要用到的类中

## 示例代码

``` cs
// 1. 创建容器对象
IServiceCollection services = new ServiceCollection();

// 2. 注册服务
services.AddTransient<ITransientService, DefaultTransientService>();
```








