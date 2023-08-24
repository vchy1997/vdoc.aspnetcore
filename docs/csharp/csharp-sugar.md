# 甜甜的语法糖

## C#8.0

### `??=` null合并赋值运算符
（null coalescing assignment operator）

它允许你将一个值分配给变量，但仅在该变量为 null 时进行分配。使用它，你可以更简洁地进行 null 值检查和赋值操作，减少了冗余的代码。例如：

=== "语法糖写法"

    ```csharp
    string name = null;
    name ??= "John";
    ```

=== "以前的写法"

    ```csharp
    string name = null;
    if (name == null)
    {
        name = "John";
    }
    ```
### ILDASM

=== "语法糖写法"

    ``` text hl_lines="10-12"
    .method private hidebysig static void '<Main>$'(string[] args) cil managed
    {
      .entrypoint
      // Code size: 12 (0xc)
      .maxstack 1
      .locals init (string V_0)
      IL_0000: ldnull          ; 将空值加载到堆栈
      IL_0001: stloc.0         ; 将堆栈上的值存储到局部变量 V_0
      IL_0002: ldloc.0         ; 将局部变量 V_0 加载到堆栈
      IL_0003: brtrue.s IL_000b; 如果堆栈上的值不为 null，跳转到标号 IL_000b
      IL_0005: ldstr "John"    ; 将字符串 "John" 加载到堆栈
      IL_000a: stloc.0         ; 将堆栈上的字符串值存储到局部变量 V_0
      IL_000b: ret             ; 返回方法
    } // end of method Program::'<Main>$'
    ```

=== "以前的写法"

    ``` ILDASM hl_lines="10-17"
    .method private hidebysig static void '<Main>$'(string[] args) cil managed
    {
      .entrypoint
      // Code size: 19 (0x13)
      .maxstack 2
      .locals init (string V_0,
                    bool V_1)
      IL_0000: ldnull          ; 将空值加载到堆栈
      IL_0001: stloc.0         ; 将堆栈上的值存储到局部变量 V_0
      IL_0002: ldloc.0         ; 将局部变量 V_0 加载到堆栈
      IL_0003: ldnull          ; 将空值加载到堆栈
      IL_0004: ceq             ; 比较堆栈上的两个值是否相等，结果为布尔值
      IL_0006: stloc.1         ; 将布尔值存储到局部变量 V_1
      IL_0007: ldloc.1         ; 将局部变量 V_1 加载到堆栈
      IL_0008: brfalse.s IL_0012; 如果布尔值为 false，跳转到标号 IL_0012
      IL_000a: nop             ; 空操作
      IL_000b: ldstr "John"    ; 将字符串 "John" 加载到堆栈
      IL_0010: stloc.0         ; 将堆栈上的字符串值存储到局部变量 V_0
      IL_0011: nop             ; 空操作
      IL_0012: ret             ; 返回方法
    } // end of method Program::'<Main>$'
    ```


!!! 说明
    1. `??=` 合并赋值运算符,简化了以前的判断.对于性能方面的话,两者只有一些细微的区别,但是在代码的可读性上,`??=`合并赋值运算符更加的简洁明了.</br>
    2. 生成的中间代码,`??=`的方式,反而中间代码生成的代码会少一些</br>
    3. 上面的语法糖代码可以看得出,`??=`的方式,只是会判断对应的对象是否为null</br>
    4. 但是以前的写法,是判断是否为null,然后将bool结果存储到堆栈中,然后再进行判断,这样的话,就会多出一些中间代码,而且还需要写入一个临时bool变量</br>
    5. 总的来说,我个人认为,这种新的语法糖写法,更加的简洁明了,而且也不会影响性能,所以,我个人是比较推荐使用这种新的语法糖写法的.</br>



