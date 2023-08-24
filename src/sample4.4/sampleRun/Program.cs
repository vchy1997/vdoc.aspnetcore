var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var logger = app.Services.GetService<ILogger<Program>>()!;

// 我们试一下在`Run`管道的上面增加的管道有没有效果: 事实证明,这个管道先执行,因为这个管道的顺序在`Run`管道之前
app.Use(async (context, next) =>
{
    // 因为f5启动后,默认访问根目录资源 + favicon.ico地址,所以f5刚打开的时候,会执行两次中间件,为了演示效果,特殊处理资源文件
    if (context.Request.Path == "/favicon.ico")
        return;

    logger.LogInformation("============================");
    // 调用`next`中间件之前
    logger.LogInformation("`use1`管道,调用`run`管道之前");
    await next.Invoke();
    // 调用`next`中间件之后
    logger.LogInformation("`use1`管道,调用`run`管道之后");
});

//`Run` 方法是 `Use` 方法的一个特例，它仅适用于终止管道并且不调用下一个中间件。因此，它通常作为管道的末尾存在。
app.Run(async context =>
{
    //此中间件终止管道并返回响应
    logger.LogInformation("`run`管道");
    await context.Response.WriteAsync("success");
});

// 我们试一下在`Run`管道之后增加的管道有没有效果:
// 事实证明,这个管道并没有任何效果,因为这个管道在`Run`之后,`Run`管道已经作为了管道的末尾结束了
app.Use(async (context, next) =>
{
    // 调用`next`中间件之前
    logger.LogInformation("`use2`管道,调用`run`管道之前");
    await next.Invoke();
    // 调用`next`中间件之后
    logger.LogInformation("`use2`管道,调用`run`管道之后");
});

app.Run();


