# 装饰模式

## 示例代码

``` csharp
// 第一次需求,我们只需要一个邮件发送
ISender emailSender = new emailSender();

Console.WriteLine("========================================");
Console.WriteLine("第一次需求");
emailSender.Send();

// 第二次需求,我们需要在邮件的基础上,增加一个短信发送,使用装饰器来实现
SMSSenderDecorator smsSender = new SMSSenderDecorator(emailSender);

Console.WriteLine("========================================");
Console.WriteLine("第二次需求");
smsSender.Send();

// 第三次需求,我们需要在邮件/短信的基础上,增加一个微信消息发送,使用装饰器来实现
WeChatSenderDecorator weChatSenderDecorator = new WeChatSenderDecorator(smsSender);

Console.WriteLine("========================================");
Console.WriteLine("第三次需求");

weChatSenderDecorator.Send();


// 消息发送
interface ISender
{
    void Send();
}

// 消息发送实现
class emailSender : ISender
{
    public void Send()
    {
        Console.WriteLine($"Email发送消息");
    }
}

// 装饰器基类
abstract class Decorator : ISender
{
    protected ISender _sender;

    public Decorator(ISender sender)
    {
        _sender = sender;
    }

    public virtual void Send()
    {
        _sender?.Send();
    }
}

// 短信发送装饰器
class SMSSenderDecorator : Decorator
{
    public SMSSenderDecorator(ISender sender) : base(sender)
    {
    }

    public override void Send()
    {
        Console.WriteLine($"SMS装饰器发送消息");
        base.Send();
    }
}

// 微信发送装饰器
class WeChatSenderDecorator : Decorator
{
    public WeChatSenderDecorator(ISender sender) : base(sender)
    {
    }

    public override void Send()
    {
        Console.WriteLine($"WeChat装饰器发送消息");
        base.Send();
    }
}
```

## 输出结果

``` text
========================================
第一次需求
Email发送消息
========================================
第二次需求
SMS装饰器发送消息
Email发送消息
========================================
第三次需求
WeChat装饰器发送消息
SMS装饰器发送消息
Email发送消息
```