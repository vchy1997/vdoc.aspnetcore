var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var logger = app.Services.GetService<ILogger<Program>>()!;

// ������һ����`Run`�ܵ����������ӵĹܵ���û��Ч��: ��ʵ֤��,����ܵ���ִ��,��Ϊ����ܵ���˳����`Run`�ܵ�֮ǰ
app.Use(async (context, next) =>
{
    // ��Ϊf5������,Ĭ�Ϸ��ʸ�Ŀ¼��Դ + favicon.ico��ַ,����f5�մ򿪵�ʱ��,��ִ�������м��,Ϊ����ʾЧ��,���⴦����Դ�ļ�
    if (context.Request.Path == "/favicon.ico")
        return;

    logger.LogInformation("============================");
    // ����`next`�м��֮ǰ
    logger.LogInformation("`use1`�ܵ�,����`run`�ܵ�֮ǰ");
    await next.Invoke();
    // ����`next`�м��֮��
    logger.LogInformation("`use1`�ܵ�,����`run`�ܵ�֮��");
});

//`Run` ������ `Use` ������һ��������������������ֹ�ܵ����Ҳ�������һ���м������ˣ���ͨ����Ϊ�ܵ���ĩβ���ڡ�
app.Run(async context =>
{
    //���м����ֹ�ܵ���������Ӧ
    logger.LogInformation("`run`�ܵ�");
    await context.Response.WriteAsync("success");
});

// ������һ����`Run`�ܵ�֮�����ӵĹܵ���û��Ч��:
// ��ʵ֤��,����ܵ���û���κ�Ч��,��Ϊ����ܵ���`Run`֮��,`Run`�ܵ��Ѿ���Ϊ�˹ܵ���ĩβ������
app.Use(async (context, next) =>
{
    // ����`next`�м��֮ǰ
    logger.LogInformation("`use2`�ܵ�,����`run`�ܵ�֮ǰ");
    await next.Invoke();
    // ����`next`�м��֮��
    logger.LogInformation("`use2`�ܵ�,����`run`�ܵ�֮��");
});

app.Run();


