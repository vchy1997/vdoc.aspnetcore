# 添加中间件方式

# ASP.NET Core 中间件方法比较

在 ASP.NET Core 中,中间件(Middleware)是一种处理请求和响应的机制，允许你在请求到达处理程序之前或响应发送到客户端之后执行一系列的操作。以下是 `Use`, `Run`, 和 `UseMiddleware` 方法的区别：

## 1. UseMiddleware

`UseMiddleware` 是最常用的中间件添加方法。你可以使用它来添加自定义的中间件。这个方法接受一个 `Type` 参数，该类型必须是一个中间件组件。UseMiddleware 中间件中如果没有return，会继续执行下一个中间件。`UseMiddleware`是一个扩展方法，它位于 `Microsoft.AspNetCore.Builder` 命名空间中。最终实现还是调用的`Use`方法来实现中间件的添加。

```csharp
app.UseMiddleware<CustomMiddleware>();
```

## 2. Use

`Use` 方法允许你指定一个委托(Delegate)来执行中间件逻辑。作用效果等同于 `UseMiddleware` 方法。

```csharp
app.Use(async (context, next) =>
{
    // 调用`next`中间件之前
    await next.Invoke();
    // 调用`next`中间件之后
});
```

## 3. Run

`Run` 方法是 `Use` 方法的一个特例，它仅适用于终止管道并且不调用下一个中间件。因此，它通常作为管道的末尾存在。

```csharp
app.Run(async context =>
{
    //此中间件终止管道并返回响应
});
```

## 4. Map

`Map` 方法用于根据指定的路径前缀将请求传递到一个新的中间件管道。这个方法创建了一个子管道，其中只有满足特定路径前缀的请求才会进入。这种方法可以用于为不同的路径前缀配置不同的中间件处理逻辑。

```csharp
app.Map("/admin", adminApp => {
    adminApp.UseMiddleware<AdminMiddleware>();
});
```

在上述示例中，只有路径为 "/admin" 的请求才会进入 adminApp 子管道，并由 AdminMiddleware 处理

## 5. MapWhen

`MapWhen` 方法用于根据指定的条件将请求传递到一个新的中间件管道。条件委托决定是否要将请求传递到新的管道。这个方法允许你根据更为复杂的条件来创建中间件管道分支。

```csharp
app.MapWhen(context => context.Request.Path.StartsWithSegments("/api"), apiApp => {
    apiApp.UseMiddleware<ApiMiddleware>();
});
```

在上述示例中，只有请求路径以 "/api" 开头的请求才会进入 apiApp 子管道，并由 ApiMiddleware 处理。

!!! Map和MapWhen区别
    `Map` 方法基于路径前缀来分发请求到子管道，适用于对不同路径前缀设置不同中间件处理逻辑。</br>
    `MapWhen` 方法基于条件来分发请求到子管道，适用于根据更复杂的条件来配置中间件处理逻辑。

## 6.


!!! 注意事项

    需要注意的是，Run 方法不会将请求传递给下一个中间件，因此它们在管道中的位置至关重要。而 UseMiddleware 和 Use 方法则可以添加将请求传递给下一个中间件的自定义中间件。
