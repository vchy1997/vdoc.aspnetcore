## 查询

### 分组后每组的第一条记录

=== "sqlserver"

    在 SQL Server 中，你可以使用 ROW_NUMBER() 函数和子查询来获取分组后每组的第一条记录。可以使用 PARTITION BY 子句指定分组的列，然后按照指定的顺序使用 ORDER BY 子句进行排序。

    以下是一个示例查询，用于从名为 myTable 的表中获取分组后每组的第一条记录：



    ``` sql
    SELECT group_id, value
    FROM (
      SELECT group_id, value, ROW_NUMBER() OVER (PARTITION BY group_id ORDER BY some_column) AS rn
      FROM myTable
    ) t
    WHERE rn = 1;
    ```

    在这个查询中，ROW_NUMBER() OVER (PARTITION BY group_id ORDER BY some_column) 会为每个 group_id 分组内的行分配一个行号，然后 WHERE rn = 1 会只选择行号为1的行，即每个分组的第一条记录。

### 逗号拼接

=== "sqlserver"

    在 SQL Server 中，可以使用 FOR XML PATH() 方法来实现逗号拼接。下面是一个示例：

    假设有一个 Student 表，包含 Name 和 Age 两个字段，我们要将所有学生的 Name 拼接起来，用逗号分隔：


    ``` sql
    SELECT STUFF((SELECT ',' + Name FROM Student FOR XML PATH('')), 1, 1, '') AS NameList
    ```
    上面的查询语句使用了以下几个函数和方法：

    STUFF() 函数：可以用于删除字符串中的一部分，并用另一部分替换。
    FOR XML PATH() 方法：可以将查询结果转换为 XML 格式，通过指定元素名称来控制 XML 格式的生成。在这个示例中，我们将元素名称指定为 ''，表示不生成元素标记，只生成
    文本节点。
    具体来说，我们使用 SELECT 语句查询 Student 表的 Name 字段，并在字段前面添加逗号。然后将查询结果通过 FOR XML PATH('') 方法转换为 XML 格式，生成一个由逗号分
    隔的字符串序列，最后使用 STUFF() 函数删除第一个字符（也就是第一个逗号）。

    需要注意的是，如果需要拼接多个字段，可以在 SELECT 语句中使用 + 运算符将多个字段拼接起来，例如：


    ``` sql
    SELECT STUFF((SELECT ',' + Name + ' (' + CONVERT(VARCHAR(10), Age) + ')' FROM Student FOR XML PATH('')), 1, 1, '') AS NameList
    ```

    上面的查询语句将 Name 和 Age 两个字段拼接起来，并用括号将 Age 包含起来。需要注意的是，由于 Age 是一个整型字段，需要使用 CONVERT() 函数将其转换为字符串类型。

### 区分大小写查询

=== "sqlserver"

      在 SQL Server 中，可以使用 COLLATE 关键字来指定排序规则以区分大小写。通过指定不同的 collation（排序规则），可以在 SQL Server 中实现大小写敏感和大小写不敏感的排序和比较。

      在 SQL Server 中，COLLATE Chinese_PRC_CS_AS 是指定排序规则为中文简体（PRC）大小写敏感和音调敏感的一种排序规则。

      使用该排序规则，将会按照适合中文语言和文化的方式进行排序和比较，考虑中文汉字的笔画顺序和笔画数等因素。此外，它也将区分不同的音调，例如汉字的四声（平、上、去、入）等。

      以下是在 SQL Server 中设置 COLLATE Chinese_PRC_CS_AS 排序规则的示例：

      -- 大小写敏感排序和比较

      ``` sql
      SELECT * FROM MyTable WHERE MyColumn = 'ABC' COLLATE Chinese_PRC_CS_AS;
      ```

      -- 大小写不敏感排序和比较

      ``` sql
      SELECT * FROM MyTable WHERE MyColumn = 'abc' COLLATE Chinese_PRC_CS_AS;

      ```

      注意，改变排序规则可能会影响现有的查询和应用程序代码，因此应该在进行更改之前进行彻底的测试和评估。
