# 原型模式

## 示例代码

```csharp
var student = new Student
{
    Name = "张三",
    Age = "18",
    IdCard = new IdCard
    {
        Id = "123456789"
    }
};

// 深拷贝
var deepCloneStudent = student.DeepClone();

// 浅拷贝
var shallowCloneStudent = student.ShallowClone();

Console.WriteLine($"原始对象：{student}");
Console.WriteLine($"深拷贝对象：{deepCloneStudent}");
Console.WriteLine($"浅拷贝对象：{shallowCloneStudent}");

System.Console.WriteLine("=======================================");

student.Name = "李四";
student.Age = "20";
student.IdCard.Id = "987654321";

Console.WriteLine($"原始对象：{student}");
Console.WriteLine($"深拷贝对象：{deepCloneStudent}");
Console.WriteLine($"浅拷贝对象：{shallowCloneStudent}");


public interface ICloneable<T>
{
    // 深拷贝
    T DeepClone();

    // 浅拷贝
    T ShallowClone();
}

public class Student : ICloneable<Student>
{
    // 姓名
    public string? Name { get; set; }

    // 年龄
    public string? Age { get; set; }

    // 身份证
    public IdCard? IdCard { get; set; }

    // 深拷贝: 深拷贝只会拷贝对象的内容，而不会拷贝对象的引用地址,会生成一个新的对象和新的引用地址
    // 对于深拷贝的修改, 是根据新对象的引用地址去修改的, 所以不会影响到原始对象
    public Student DeepClone()
    {
        Student student = new Student();
        student.Name = Name;
        student.Age = Age;
        student.IdCard = new IdCard
        {
            Id = IdCard?.Id
        };
        return student;
    }

    // 浅拷贝: 浅拷贝只会拷贝对象的引用地址，而不会拷贝对象的内容
    // 对于浅拷贝的修改, 是根据引用地址去修改的, 所以会影响到原始对象
    public Student ShallowClone()
    {
        return (Student)this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"姓名：{Name}，年龄：{Age}，身份证号：{IdCard?.Id}";
    }
}


// class为了演示深拷贝和浅拷贝
public class IdCard
{
    // 身份证号
    public string? Id { get; set; }
}
```