## 视图创建

=== "sqlserver"

    在 SQL Server 中，可以使用以下语法来创建视图：

    ``` sql

    CREATE VIEW [schema_name.]view_name
    AS
    SELECT column1, column2, ...
    FROM table1
    JOIN table2 ON ...
    WHERE condition;

    ```

    其中：

    CREATE VIEW 是用于创建视图的关键字。
    schema_name 是可选的，用于指定视图所属的模式（数据库对象的命名空间）。如果不指定模式名称，则视图将被创建在默认模式下（通常是dbo模式）。
    view_name 是视图的名称，用于在数据库中标识该视图。
    AS 是用于指定视图定义的关键字。
    SELECT column1, column2, ... 是视图的查询部分，用于指定视图要返回的列。
    FROM table1 JOIN table2 ON ... 是用于指定视图查询的表和表之间的连接关系。
    WHERE condition 是可选的，用于指定视图的筛选条件。

    下面是一个创建视图的示例：

    ``` sql

    CREATE VIEW dbo.EmployeeView
    AS
    SELECT EmployeeID, FirstName, LastName, Department
    FROM Employees
    WHERE Department = 'Sales';

    ```

    以上示例创建了名为 "EmployeeView" 的视图，它从 "Employees" 表中选择了员工ID、名字、姓氏和部门，并仅返回部门为 "Sales" 的员工记录。

    请注意，视图只是一个查询的封装，并且可以像表一样被查询。它们可以被用作查询的源、子查询的一部分或与其他视图进行关联。
