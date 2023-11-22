## 游标

=== "sqlserver"

    SQL Server游标（cursor）是一种用于逐行处理数据集的数据库对象。游标允许程序员在查询结果集中逐行遍历数据并执行操作。

    以下是使用游标的基本步骤：

    1. 声明游标：使用 `DECLARE CURSOR` 语句声明游标并指定查询结果集。
    2. 打开游标：使用 `OPEN` 语句打开游标并准备开始遍历结果集。
    3. 取出数据：使用 `FETCH` 语句从游标中取出一行数据。
    4. 处理数据：对于每一行数据，执行所需的操作。
    5. 关闭游标：使用 `CLOSE` 语句关闭游标。
    6. 释放游标：使用 `DEALLOCATE` 语句释放游标占用的资源。

    下面是一个简单的示例，展示如何在SQL Server中使用游标：

    ``` sql
    DECLARE @id INT
    DECLARE @name VARCHAR(50)

    DECLARE cursor_name CURSOR FOR
    SELECT id, name
    FROM myTable

    OPEN cursor_name

    FETCH NEXT FROM cursor_name INTO @id, @name

    WHILE @@FETCH_STATUS = 0
    BEGIN
      -- 处理数据
      PRINT 'ID: ' + CAST(@id AS VARCHAR) + ', Name: ' + @name

      FETCH NEXT FROM cursor_name INTO @id, @name
    END

    CLOSE cursor_name
    DEALLOCATE cursor_name
    ```

    在此示例中，我们声明了一个名为 cursor_name 的游标，它从名为 myTable 的表中选择 ID 和 Name 列的值。然后我们打开游标并从中检索第一行数据，使用循环处理每 一行   数据，直到没有更多的数据可用。最后，我们关闭游标并释放资源。
